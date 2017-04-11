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
using DanhMuc.DataAccess;
using CGCN.DataAccess;
using DanhMuc.BusinesLogic;
using QTHT.DataAccess;

namespace DanhMuc.Interface
{
    public partial class ucLoaiMatHang : UserControl
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
                obj = ctr.GetByIDNhanVienvsMenuName(Data.iduse, "tsHangSX");
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
            tblloaimathangBL _ctr = new tblloaimathangBL();
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
                else if (c1FlexGrid1.Cols[i].Caption.Equals("kyhieu"))
                { c1FlexGrid1[0, i] = "Ký hiệu(*)"; c1FlexGrid1.Cols[i].Visible = true; }
                else if (c1FlexGrid1.Cols[i].Caption.Equals("ten"))
                { c1FlexGrid1[0, i] = "Loại mặt hàng(*)"; c1FlexGrid1.Cols[i].Visible = true; }
                else if (c1FlexGrid1.Cols[i].Caption.Equals("ghichu"))
                { c1FlexGrid1[0, i] = "Mô tả"; c1FlexGrid1.Cols[i].Visible = true; }
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
        private List<tblloaimathang> GetData()
        {
            tblloaimathangBL ctr = new tblloaimathangBL();
            List<tblloaimathang> lst = new List<tblloaimathang>();
            string loi = "";
            for (int i = 1; i < c1FlexGrid1.Rows.Count; i++)
            {
                if (c1FlexGrid1[i, "TT"].ToString().Equals("0") == false)
                {
                    try
                    {
                        loi = "";
                        tblloaimathang _obj = new tblloaimathang();
                        if (c1FlexGrid1[i, "kyhieu"].ToString().Trim().Equals("") == true || c1FlexGrid1[i, "kyhieu"] == null)
                        {
                            loi = "Ký hiệu loại mặt hàng không được để trắng.";
                            c1FlexGrid1.SetUserData(i, "ten", loi);
                            c1FlexGrid1.Rows[i].Style = cserror;
                        }
                        _obj.kyhieu = c1FlexGrid1[i, "kyhieu"].ToString();
                        if (c1FlexGrid1[i, "TT"].ToString().Equals("1") == true)
                        {
                            if (ctr.CheckExit("", _obj.kyhieu,"") == true)
                            {
                                loi = "Ký hiệu loại mặt hàng đã có trong cơ sở dữ liệu.";
                                c1FlexGrid1.SetUserData(i, "ten", loi);
                                c1FlexGrid1.Rows[i].Style = cserror;
                            }
                            _obj.id = Guid.NewGuid().ToString();
                            c1FlexGrid1[i, "id"] = _obj.id.Trim();
                        }
                        if (c1FlexGrid1[i, "TT"].ToString().Equals("2") == true)
                        {
                            _obj.id = c1FlexGrid1[i, "id"].ToString().Trim();
                            if (ctr.CheckExit(_obj.id, _obj.kyhieu, "") == true)
                            {
                                loi = "Ký hiệu loại mặt hàng đã có trong cơ sở dữ liệu.";
                                c1FlexGrid1.SetUserData(i, "ten", loi);
                                c1FlexGrid1.Rows[i].Style = cserror;
                            }
                        }
                        if (c1FlexGrid1[i, "ten"].ToString().Trim().Equals("") == true || c1FlexGrid1[i, "ten"] == null)
                        {
                            loi = "Tên loại mặt hàng không được để trắng.";
                            c1FlexGrid1.SetUserData(i, "ten", loi);
                            c1FlexGrid1.Rows[i].Style = cserror;
                        }
                        _obj.ten = c1FlexGrid1[i, "ten"].ToString();
                        if (c1FlexGrid1[i, "TT"].ToString().Equals("1") == true)
                        {
                            if (ctr.CheckExit("", "",_obj.ten) == true)
                            {
                                loi = "Tên loại mặt hàng đã có trong cơ sở dữ liệu.";
                                c1FlexGrid1.SetUserData(i, "ten", loi);
                                c1FlexGrid1.Rows[i].Style = cserror;
                            }
                            _obj.id = Guid.NewGuid().ToString();
                            c1FlexGrid1[i, "id"] = _obj.id.Trim();
                        }
                        if (c1FlexGrid1[i, "TT"].ToString().Equals("2") == true)
                        {
                            _obj.id = c1FlexGrid1[i, "id"].ToString().Trim();
                            if (ctr.CheckExit(_obj.id, "", _obj.ten) == true)
                            {
                                loi = "Tên loại mặt hàng đã có trong cơ sở dữ liệu.";
                                c1FlexGrid1.SetUserData(i, "ten", loi);
                                c1FlexGrid1.Rows[i].Style = cserror;
                            }
                        }
                        _obj.ghichu = c1FlexGrid1[i, "ghichu"].ToString();
                        lst.Add(_obj);
                    }
                    catch { }
                }
            }
            return lst;
        }
        private void Delete()
        {
            tblloaimathangBL _ctr = new tblloaimathangBL();
            string loi = "";
            string sten = "";
            string iid = "";
            int n = c1FlexGrid1.RowSel;
            if (n >= 1)
            {
                try { sten = c1FlexGrid1[c1FlexGrid1.RowSel, "ten"].ToString().Trim(); }
                catch { }
                try { iid = c1FlexGrid1[c1FlexGrid1.RowSel, "id"].ToString().Trim(); }
                catch { }
                DialogResult bien;
                bien = MessageBox.Show("Xác nhận xóa dữ liệu", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (bien == DialogResult.Yes)
                {
                    loi = _ctr.Delete(iid);
                    if (loi.Equals("") == true)
                    {
                        try { _ctrlog.Append(Data.use, "Xóa loại mặt hàng: " + sten.Trim()); }
                        catch { }
                        HienThiDS();
                    }
                    else
                    {
                        MessageBox.Show(loi, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            tblloaimathangBL _ctr = new tblloaimathangBL();
            List<tblloaimathang> lst = new List<tblloaimathang>();
            lst = GetData();
            if (lst != null)
            {
                for (int i = 0; i < lst.Count; i++)
                {
                    loi = "";
                    tblloaimathang _obj = new tblloaimathang();
                    try { _obj = _ctr.GetByID(lst[i].id); }
                    catch { }
                    if (_obj == null)
                    {
                        try { loi = c1FlexGrid1.GetUserData(c1FlexGrid1.FindRow(lst[i].id.ToString().Trim(), 1, c1FlexGrid1.Cols["id"].Index, true, true, true), "ten").ToString().Trim(); }
                        catch { }
                        if (loi.Equals("") == true)
                        {
                            loi = _ctr.Insert(lst[i]);
                            if (loi.Equals("") == false)
                            {
                                c1FlexGrid1.Rows[c1FlexGrid1.FindRow(lst[i].id.ToString().Trim(), 1, c1FlexGrid1.Cols["id"].Index, true, true, true)].Style = cserror;
                            }
                            else
                            {
                                _ctrlog.Append(Data.use, "Thêm mới loại mặt hàng: " + lst[i].ten.Trim());
                            }
                        }
                        else
                        {
                            c1FlexGrid1.Rows[c1FlexGrid1.FindRow(lst[i].id.ToString().Trim(), 1, c1FlexGrid1.Cols["id"].Index, true, true, true)].Style = cserror;
                        }
                        if (loi.Trim().Equals("") == false)
                        {
                            temploi = loi;
                        }
                    }
                    else
                    {
                        try { loi = c1FlexGrid1.GetUserData(c1FlexGrid1.FindRow(lst[i].id.ToString().Trim(), 1, c1FlexGrid1.Cols["id"].Index, true, true, true), "ten").ToString().Trim(); }
                        catch { }
                        if (loi.Equals("") == true)
                        {
                            loi = _ctr.Update(lst[i]);
                            if (loi.Equals("") == false)
                            {
                                c1FlexGrid1.SetUserData(c1FlexGrid1.FindRow(lst[i].id.ToString().Trim(), 1, c1FlexGrid1.Cols["id"].Index, true, true, true), "ten", loi);
                                c1FlexGrid1.Rows[c1FlexGrid1.FindRow(lst[i].id.ToString().Trim(), 1, c1FlexGrid1.Cols["id"].Index, true, true, true)].Style = cserror;
                            }
                            else
                            {
                                _ctrlog.Append(Data.use, "Cập nhật loại mặt hàng: " + lst[i].ten.Trim());
                            }
                        }
                        else
                        {
                            c1FlexGrid1.SetUserData(c1FlexGrid1.FindRow(lst[i].id.ToString().Trim(), 1, c1FlexGrid1.Cols["id"].Index, true, true, true), "ten", loi);
                            c1FlexGrid1.Rows[c1FlexGrid1.FindRow(lst[i].id.ToString().Trim(), 1, c1FlexGrid1.Cols["id"].Index, true, true, true)].Style = cserror;
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
            c1FlexGrid1.Focus();
            c1FlexGrid1.Rows.Add();
            c1FlexGrid1[c1FlexGrid1.Rows.Count - 1, "TT"] = 1;
            c1FlexGrid1[c1FlexGrid1.Rows.Count - 1, "id"] = "";
            c1FlexGrid1[c1FlexGrid1.Rows.Count - 1, 0] = (c1FlexGrid1.Rows.Count - 1).ToString();
            c1FlexGrid1.StartEditing(c1FlexGrid1.Rows.Count - 1, 2);
        }
        #endregion
        public ucLoaiMatHang()
        {
            InitializeComponent();
        }
        private void ucLoaiMatHang_Load(object sender, EventArgs e)
        {
            //CheckQuyenDL();
            c1FlexGrid1.KeyActionEnter = KeyActionEnum.MoveAcross;
            cserror = c1FlexGrid1.Styles.Add("Error");
            cserror.BackColor = Color.Red;
            HienThiDS();
        }
        #region Xử lý sự kiện trên grid
        private void c1FlexGrid1_Click(object sender, EventArgs e)
        {
            //Hiển thị lỗi nếu có
            try
            {
                string loi = "";
                try { loi = c1FlexGrid1.GetUserData(c1FlexGrid1.RowSel, "ten").ToString().Trim(); }
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
                c1FlexGrid1.AutoSizeCol(e.Col);
                int hang = c1FlexGrid1.Row;
                int cot = c1FlexGrid1.Cols.Count - 1;
                if (Convert.ToInt32(c1FlexGrid1[hang, cot]) == 0)
                {
                    c1FlexGrid1[c1FlexGrid1.RowSel, c1FlexGrid1.Cols.Count - 1] = 2;
                }
                if (c1FlexGrid1.ColSel == c1FlexGrid1.Cols.Count - 2 && c1FlexGrid1.RowSel == c1FlexGrid1.Rows.Count - 1)
                {
                    if (c1FlexGrid1.RowSel == c1FlexGrid1.Rows.Count - 1)
                    {
                        Add();
                        c1FlexGrid1.StartEditing(c1FlexGrid1.Rows.Count - 1, 1);
                    }
                    else
                    {
                        c1FlexGrid1.StartEditing(c1FlexGrid1.RowSel + 1, 2);
                    }
                    //Add(); c1FlexGrid1.StartEditing(c1FlexGrid1.Rows.Count - 1, 1);
                }
            }
            catch { }
        }
        private void c1FlexGrid1_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.Control && e.KeyCode == Keys.A) || e.KeyCode == Keys.Add) { Add(); }
            if (e.Control && e.KeyCode == Keys.S) { Save(); }
            if (e.KeyCode == Keys.Delete) { Delete(); }
        }
        private void c1FlexGrid1_KeyUp(object sender, KeyEventArgs e)
        {
            c1FlexGrid1_KeyDown(sender, e);
        }
        #endregion
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
