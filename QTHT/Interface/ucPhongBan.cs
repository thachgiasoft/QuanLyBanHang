using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using QTHT.BusinesLogic;
using C1.Win.C1FlexGrid;
using QTHT.DataAccess;
using CGCN.DataAccess;

namespace QTHT.Interface
{
    public partial class ucPhongBan : UserControl
    {
        private CellStyle cserror;
        private logBL _ctrlog = new logBL();
        #region Method
        private void CheckQuyenDL()
        {
            ultraToolbarsManager1.Tools["btn_Add"].SharedProps.Visible = false;
            ultraToolbarsManager1.Tools["btn_Save"].SharedProps.Visible = false;
            ultraToolbarsManager1.Tools["btn_Del"].SharedProps.Visible = false;
            try
            {
                quyennguoidung obj = new quyennguoidung();
                quyennguoidungBL ctr = new quyennguoidungBL();
                obj = ctr.GetByIDNhanVienvsMenuName(Data.iduse, "tsPhongBan");
                string[] arrquyendl = obj.quyendl.Split(';');
                if (arrquyendl[0].Trim().Equals("EDIT") == true)
                {
                    ultraToolbarsManager1.Tools["btn_Add"].SharedProps.Visible = true;
                    ultraToolbarsManager1.Tools["btn_Save"].SharedProps.Visible = true;
                }
                if (arrquyendl[1].Trim().Equals("DEL") == true)
                {
                    ultraToolbarsManager1.Tools["btn_Del"].SharedProps.Visible = true;
                }
            }
            catch
            {
                ultraToolbarsManager1.Tools["btn_Add"].SharedProps.Visible = false;
                ultraToolbarsManager1.Tools["btn_Save"].SharedProps.Visible = false;
                ultraToolbarsManager1.Tools["btn_Del"].SharedProps.Visible = false;
            }
        }
        private void HienThiDS()
        {
            phongbanBL _ctr = new phongbanBL();
            DataTable dt = new DataTable();
            dt = _ctr.GetAll();
            if (dt != null)
            {
                c1FlexGrid1.DataSource = dt;
                dt.Columns.Add("TT", typeof(Int32));
                FormatGrid();
            }
        }
        private void FormatGrid()
        {
            for (int i = 0; i < c1FlexGrid1.Cols.Count; i++)
            {
                if (i == 0)
                { c1FlexGrid1[0, i] = "STT"; c1FlexGrid1.Cols[i].Visible = true; c1FlexGrid1.Cols[i].Width = 60; }
                else if (c1FlexGrid1.Cols[i].Caption.Equals("tenphongban"))
                { c1FlexGrid1[0, i] = "Tên phòng ban(*)"; c1FlexGrid1.Cols[i].Visible = true;}
                else if (c1FlexGrid1.Cols[i].Caption.Equals("mota"))
                { c1FlexGrid1[0, i] = "Mô tả"; c1FlexGrid1.Cols[i].Visible = true;  }
                else { c1FlexGrid1.Cols[i].Visible = false; }
                c1FlexGrid1.Cols[i].TextAlignFixed = TextAlignEnum.CenterCenter;
            }
            Font _font = new Font("Time new Roman", 14);
            c1FlexGrid1.Font = _font;
            for (int j = 1; j < c1FlexGrid1.Rows.Count; j++)
            {
                c1FlexGrid1[j, 0] = j;
                c1FlexGrid1[j, "TT"] = 0;
            }
            c1FlexGrid1.Cols[0].TextAlign = TextAlignEnum.CenterCenter;
            c1FlexGrid1.AutoSizeCols();
            c1FlexGrid1.AutoSizeRows();
        }
        private List<phongban> GetData()
        {
            phongbanBL ctr = new phongbanBL();
            List<phongban> lst = new List<phongban>();
            string loi = "";
            for (int i = 1; i < c1FlexGrid1.Rows.Count; i++)
            {
                if (c1FlexGrid1[i, "TT"].ToString().Equals("0") == false)
                {
                    try
                    {
                        loi = "";
                        phongban _obj = new phongban();
                        if (c1FlexGrid1[i, "tenphongban"].ToString().Trim().Equals("") == true || c1FlexGrid1[i, "tenphongban"] == null)
                        {
                            loi = "Tên phòng ban không được để trắng.";
                            c1FlexGrid1.SetUserData(i, "tenphongban", loi);
                            c1FlexGrid1.Rows[i].Style = cserror;
                        }
                        _obj.tenphongban = c1FlexGrid1[i, "tenphongban"].ToString();
                        _obj.idphongban = c1FlexGrid1[i, 1].ToString().Trim();
                        if (c1FlexGrid1[i, "TT"].ToString().Equals("1") == true)
                        {
                            if (ctr.CheckExit("", _obj.tenphongban) == true)
                            {
                                loi = "Tên phòng ban đã có trong cơ sở dữ liệu.";
                                c1FlexGrid1.SetUserData(i, "tenphongban", loi);
                                c1FlexGrid1.Rows[i].Style = cserror;
                            }
                        }
                        if (c1FlexGrid1[i, "TT"].ToString().Equals("2") == true)
                        {
                            if (ctr.CheckExit(_obj.idphongban, _obj.tenphongban) == true)
                            {
                                loi = "Tên phòng ban đã có trong cơ sở dữ liệu.";
                                c1FlexGrid1.SetUserData(i, "tenphongban", loi);
                                c1FlexGrid1.Rows[i].Style = cserror;
                            }
                        }
                        _obj.mota = c1FlexGrid1[i, "mota"].ToString();
                        lst.Add(_obj);
                    }
                    catch { }
                }
            }
            return lst;
        }
        private void Delete()
        {
            phongbanBL _ctr = new phongbanBL();
            string loi = "";
            string sten = "";
            string sid = "";
            int n = c1FlexGrid1.RowSel;
            if (n >= 1)
            {
                try { sten = c1FlexGrid1[c1FlexGrid1.RowSel, "tenphongban"].ToString().Trim(); }
                catch { }
                try { sid = c1FlexGrid1[c1FlexGrid1.RowSel, "idphongban"].ToString().Trim(); }
                catch { }
                DialogResult bien;
                bien = MessageBox.Show("Xác nhận xóa dữ liệu", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (bien == DialogResult.Yes)
                {
                    loi = _ctr.Delete(sid);
                    if (loi.Equals("") == true)
                    {
                        HienThiDS();
                        //c1FlexGrid1.Select(c1FlexGrid1.FindRow(objID.ToString(), 1, c1FlexGrid1.Cols["OBJECTID"].Index, true, true, true), c1FlexGrid1.Cols["SoGPTD"].Index, true);
                    }
                    else
                    {
                        MessageBox.Show(loi,"Thông báo",MessageBoxButtons.OK,MessageBoxIcon.Error);
                    }
                }
            }
            else
                MessageBox.Show("Dữ liệu hiện tại đang trắng.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            c1FlexGrid1.Focus();
        }
        private void Save()
        {
            string temploi = "";
            string loi = "";
            phongbanBL _ctr = new phongbanBL();
            List<phongban> lst = new List<phongban>();
            lst = GetData();
            if (lst != null)
            {
                for (int i = 0; i < lst.Count; i++)
                {
                    loi = "";
                    phongban _obj = new phongban();
                    try { _obj = _ctr.GetByID(lst[i].idphongban); }
                    catch { }
                    if (_obj == null)
                    {
                        try { loi = c1FlexGrid1.GetUserData(c1FlexGrid1.FindRow(lst[i].idphongban, 1, c1FlexGrid1.Cols["idphongban"].Index, true, true, true), "tenphongban").ToString().Trim(); }
                        catch { }
                        if (loi.Equals("") == true)
                        {
                            loi = _ctr.Insert(lst[i]);
                            if (loi.Equals("") == false)
                            {
                                c1FlexGrid1.Rows[c1FlexGrid1.FindRow(lst[i].idphongban, 1, c1FlexGrid1.Cols["idphongban"].Index, true, true, true)].Style = cserror;
                            }
                            else
                            {
                                _ctrlog.Append(Data.use, "Thêm mới phòng ban: " + lst[i].tenphongban.Trim());
                            }
                        }
                        else
                        {
                            c1FlexGrid1.Rows[c1FlexGrid1.FindRow(lst[i].idphongban, 1, c1FlexGrid1.Cols["idphongban"].Index, true, true, true)].Style = cserror;
                        }
                        if (loi.Trim().Equals("") == false)
                        {
                            temploi = loi;
                        }
                    }
                    else
                    {
                        try { loi = c1FlexGrid1.GetUserData(c1FlexGrid1.FindRow(lst[i].idphongban, 1, c1FlexGrid1.Cols["idphongban"].Index, true, true, true), "tenphongban").ToString().Trim(); }
                        catch { }
                        if (loi.Equals("") == true)
                        {
                            loi = _ctr.Update(lst[i]);
                            if (loi.Equals("") == false)
                            {
                                c1FlexGrid1.SetUserData(c1FlexGrid1.FindRow(lst[i].idphongban, 1, c1FlexGrid1.Cols["idphongban"].Index, true, true, true), "tenphongban", loi);
                                c1FlexGrid1.Rows[c1FlexGrid1.FindRow(lst[i].idphongban, 1, c1FlexGrid1.Cols["idphongban"].Index, true, true, true)].Style = cserror;
                            }
                            else
                            {
                                _ctrlog.Append(Data.use, "Cập nhật phòng ban: " + lst[i].tenphongban.Trim());
                            }
                        }
                        else
                        {
                            c1FlexGrid1.SetUserData(c1FlexGrid1.FindRow(lst[i].idphongban, 1, c1FlexGrid1.Cols["idphongban"].Index, true, true, true), "tenphongban", loi);
                            c1FlexGrid1.Rows[c1FlexGrid1.FindRow(lst[i].idphongban, 1, c1FlexGrid1.Cols["idphongban"].Index, true, true, true)].Style = cserror;
                        }
                        if (loi.Trim().Equals("") == false)
                        {
                            temploi = loi;
                        }
                    }
                }
            }
            if (temploi.Trim().Equals("") == true)
            {
                HienThiDS();
                MessageBox.Show("Cập nhật dữ liệu thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else { MessageBox.Show("Cập nhật dữ liệu không thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }
        private void Cancel()
        {
            HienThiDS();
        }
        private void Add()
        {
            c1FlexGrid1.Rows.Add();
            c1FlexGrid1[c1FlexGrid1.Rows.Count - 1, "TT"] = 1;
            c1FlexGrid1[c1FlexGrid1.Rows.Count - 1, "idphongban"] = Guid.NewGuid().ToString();
            c1FlexGrid1[c1FlexGrid1.Rows.Count - 1, 0] = (c1FlexGrid1.Rows.Count - 1).ToString();
            c1FlexGrid1.StartEditing(c1FlexGrid1.Rows.Count - 1, 2);
        }
        #endregion

        public ucPhongBan()
        {
            InitializeComponent();
        }

        private void ucPhongBan_Load(object sender, EventArgs e)
        {
            CheckQuyenDL();
            c1FlexGrid1.KeyActionEnter = KeyActionEnum.MoveAcross;
            cserror = c1FlexGrid1.Styles.Add("Error");
            cserror.BackColor = Color.Red;
            HienThiDS();
        }

        private void c1FlexGrid1_Click(object sender, EventArgs e)
        {
            //Hiển thị lỗi nếu có
            try
            {
                string loi = "";
                try { loi = c1FlexGrid1.GetUserData(c1FlexGrid1.RowSel, "tenphongban").ToString().Trim(); }
                catch { }
                toolTip1.SetToolTip(c1FlexGrid1, loi);
            }
            catch { }
        }

        private void c1FlexGrid1_AfterEdit(object sender, RowColEventArgs e)
        {
            try
            {
                c1FlexGrid1.AutoSizeRow(e.Row);
                int hang = c1FlexGrid1.Row;
                int cot = c1FlexGrid1.Cols.Count - 1;
                if (Convert.ToInt32(c1FlexGrid1[hang, cot]) == 0)
                {
                    c1FlexGrid1[c1FlexGrid1.RowSel, c1FlexGrid1.Cols.Count - 1] = 2;
                }
                if (c1FlexGrid1.ColSel == c1FlexGrid1.Cols.Count - 2 && c1FlexGrid1.RowSel == c1FlexGrid1.Rows.Count - 1)
                {
                    Add(); c1FlexGrid1.StartEditing(c1FlexGrid1.Rows.Count - 1, 1);
                }
            }
            catch { }
        }

        private void c1FlexGrid1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete) { Delete(); }
            if (e.KeyCode == Keys.A) { Add(); }
            if (e.KeyCode == Keys.S) { Save(); }
        }

        private void ultraToolbarsManager1_ToolClick(object sender, Infragistics.Win.UltraWinToolbars.ToolClickEventArgs e)
        {
            switch (e.Tool.Key)
            {
                case "btn_Add":    // ButtonTool
                    Add();
                    break;

                case "btn_Save":    // ButtonTool
                    c1FlexGrid1.Focus();
                    Save();
                    break;

                case "btn_Abort":    // ButtonTool
                    Cancel();
                    break;

                case "btn_Del":    // ButtonTool
                    Delete();
                    break;
            }
        }
    }
}
