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
    public partial class ucNhaCungCap : UserControl
    {
        private CellStyle cserror;
        private logBL _ctrlog = new logBL();
        public string sreturn = "";
        private int _type = 0;//0:Không hiển thị tschon; 1:Hiển thị tschon
        public int type { get { return _type; } set { this._type = value; } }

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
                obj = ctr.GetByIDNhanVienvsMenuName(Data.iduse, "tsKhachHang");
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
            nhacungcapBL _ctr = new nhacungcapBL();
            DataTable dt = new DataTable();
            dt = _ctr.Filter(txtKeyword.Text.Trim());
            if (dt != null)
            {
                c1FlexGrid1.DataSource = dt;
                FormatGrid();
            }
        }
        private void FormatGrid()
        {
            for (int i = 0; i < c1FlexGrid1.Cols.Count; i++)
            {
                if (c1FlexGrid1.Cols[i].Caption.Equals("stt"))
                { 
                    c1FlexGrid1[0, i] = "STT"; 
                    c1FlexGrid1.Cols[i].Visible = true;
                    c1FlexGrid1.Cols[i].AllowEditing = false;
                    c1FlexGrid1.Cols[i].TextAlign = TextAlignEnum.CenterCenter;
                    c1FlexGrid1.Cols[i].Width = 60; 
                }
                else if (c1FlexGrid1.Cols[i].Caption.Equals("ten"))
                { c1FlexGrid1[0, i] = "Tên(*)"; c1FlexGrid1.Cols[i].Visible = true; }
                else if (c1FlexGrid1.Cols[i].Caption.Equals("diachi"))
                { c1FlexGrid1[0, i] = "Địa chỉ"; c1FlexGrid1.Cols[i].Visible = true; }
                else if (c1FlexGrid1.Cols[i].Caption.Equals("dienthoai"))
                { c1FlexGrid1[0, i] = "Điện thoại"; c1FlexGrid1.Cols[i].Visible = true; }
                else if (c1FlexGrid1.Cols[i].Caption.Equals("ghichu"))
                { c1FlexGrid1[0, i] = "Ghi chú"; c1FlexGrid1.Cols[i].Visible = true; }
                else if (c1FlexGrid1.Cols[i].Caption.Equals("tt"))
                { c1FlexGrid1[0, i] = "TT"; c1FlexGrid1.Cols[i].Visible = false; }
                else { c1FlexGrid1.Cols[i].Visible = false; }
                c1FlexGrid1.Cols[i].TextAlignFixed = TextAlignEnum.CenterCenter;
            }
            Font _font = new Font("Time new Roman", 14);
            c1FlexGrid1.Font = _font;
            c1FlexGrid1.Cols[0].TextAlign = TextAlignEnum.CenterCenter;
            c1FlexGrid1.AutoSizeCols();
            c1FlexGrid1.AutoSizeRows();
        }
        private List<nhacungcap> GetData()
        {
            List<nhacungcap> lst = new List<nhacungcap>();
            string loi = "";
            for (int i = 1; i < c1FlexGrid1.Rows.Count; i++)
            {
                if (c1FlexGrid1[i, "TT"].ToString().Equals("0") == false)
                {
                    try
                    {
                        loi = "";
                        nhacungcap _obj = new nhacungcap();
                        if (c1FlexGrid1[i, "ten"].ToString().Trim().Equals("") == true || c1FlexGrid1[i, "ten"] == null)
                        {
                            loi = "Tên nhà cung cấp không được để trắng.";
                            c1FlexGrid1.SetUserData(i, "ten", loi);
                            c1FlexGrid1.Rows[i].Style = cserror;
                        }
                        _obj.diachi = c1FlexGrid1[i, "diachi"].ToString();
                        _obj.dienthoai = c1FlexGrid1[i, "dienthoai"].ToString();
                        _obj.ghichu = c1FlexGrid1[i, "ghichu"].ToString();
                        if (c1FlexGrid1[i, "TT"].ToString().Equals("1") == true)
                        { _obj.id = Guid.NewGuid().ToString(); c1FlexGrid1[i, "id"] = _obj.id.Trim(); }
                        if (c1FlexGrid1[i, "TT"].ToString().Equals("2") == true)
                        { _obj.id = c1FlexGrid1[i, "id"].ToString(); }
                        _obj.ten = c1FlexGrid1[i, "ten"].ToString();
                        _obj.daxoa = 0;
                        lst.Add(_obj);
                    }
                    catch { }
                }
            }
            return lst;
        }
        private void Delete()
        {
            nhacungcapBL _ctr = new nhacungcapBL();
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
                        try { _ctrlog.Append(Data.use, "Xóa nhà cung cấp: " + sten.Trim()); }
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
            nhacungcapBL _ctr = new nhacungcapBL();
            List<nhacungcap> lst = new List<nhacungcap>();
            lst = GetData();
            if (lst != null)
            {
                for (int i = 0; i < lst.Count; i++)
                {
                    loi = "";
                    nhacungcap _obj = new nhacungcap();
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
                                _ctrlog.Append(Data.use, "Thêm mới nhà cung cấp: " + lst[i].ten.Trim());
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
                                _ctrlog.Append(Data.use, "Cập nhật thông tin nhà cung cấp: " + lst[i].ten.Trim());
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
            c1FlexGrid1.Rows.Add();
            c1FlexGrid1[c1FlexGrid1.Rows.Count - 1, "TT"] = 1;
            c1FlexGrid1[c1FlexGrid1.Rows.Count - 1, "id"] = "";
            c1FlexGrid1[c1FlexGrid1.Rows.Count - 1, "STT"] = (c1FlexGrid1.Rows.Count - 1).ToString();
            c1FlexGrid1.Select(c1FlexGrid1.Rows.Count - 1, 1);
            c1FlexGrid1.StartEditing(c1FlexGrid1.Rows.Count - 1, 1);
        }
        #endregion
        public ucNhaCungCap()
        {
            InitializeComponent();
        }
        private void ucNhaCungCap_Load(object sender, EventArgs e)
        {
            try
            {
                CheckQuyenDL();
                c1FlexGrid1.KeyActionEnter = KeyActionEnum.MoveAcross;
                cserror = c1FlexGrid1.Styles.Add("Error");
                cserror.BackColor = Color.Red;
                if (type == 0) { type = 1; }
                HienThiDS();
            }
            catch { }
            txtKeyword.Focus();
        }
        #region Xử lý sự kiện trên Grid
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
                if (c1FlexGrid1.Cols[c1FlexGrid1.ColSel].Name.ToUpper().Equals("GHICHU") == true && c1FlexGrid1.RowSel == c1FlexGrid1.Rows.Count - 1)
                {
                    if (c1FlexGrid1.RowSel == c1FlexGrid1.Rows.Count - 1)
                    {
                        Add();
                        c1FlexGrid1.StartEditing(c1FlexGrid1.Rows.Count - 1, 1);
                    }
                    else
                    {
                        c1FlexGrid1.StartEditing(c1FlexGrid1.RowSel + 1, 1);
                    }
                }
                //c1FlexGrid1.AutoSizeRows();
                //c1FlexGrid1.AutoSizeCols();
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
        private void c1FlexGrid1_MouseDown(object sender, MouseEventArgs e)
        {
            //if (type == 1 || type == 2)
            //{
            //    if (e.Button == System.Windows.Forms.MouseButtons.Right) { contextMenuStrip1.Show(c1FlexGrid1, e.X, e.Y); }
            //}
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
        #region Xử lý sự kiện tìm kiếm
        private void txtKeyword_KeyDown(object sender, KeyEventArgs e)
        {
            //if (e.KeyCode == Keys.Enter) { HienThiDS(); }
            HienThiDS();
        }
        private void btnTim_Click(object sender, EventArgs e)
        {
            HienThiDS();
        }
        #endregion
        private void tsChon_Click(object sender, EventArgs e)
        {
            if (c1FlexGrid1.Rows.Count - 1 > 0)
            {
                try { sreturn = c1FlexGrid1[c1FlexGrid1.RowSel, "id"].ToString().Trim(); }
                catch { }
            }
            else { sreturn = ""; }
            ((frmKhachHang)this.FindForm()).sreturn = sreturn;
            this.Parent.Dispose();
        }
        private void c1FlexGrid1_DoubleClick(object sender, EventArgs e)
        {
            string sidnhacc = "";
            if (c1FlexGrid1.Rows.Count - 1 > 0)
            {
                try { sidnhacc = c1FlexGrid1[c1FlexGrid1.RowSel, "id"].ToString().Trim(); }
                catch { }
            }
            else { sidnhacc = ""; }
            if (sidnhacc.Trim().Equals("") == false)
            {
                //if (type == 1)
                //{
                //    type = 1;
                //    CreatHDBanForCustome _frm = new CreatHDBanForCustome(sidnhacc);
                //    _frm.ShowDialog();
                //}
                if (type == 2)
                {
                    sreturn = sidnhacc;
                    ((frmChonNhaCungCap)this.FindForm()).sreturn = sreturn;
                    this.Parent.Dispose();
                    type = 1;
                }
            }
            
        }
    }
}
