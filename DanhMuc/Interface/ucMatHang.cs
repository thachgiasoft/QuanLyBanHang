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
    public partial class ucMatHang : UserControl
    {
        private CellStyle cserror;
        private CellStyle csten;
        private CellStyle csgiaban;
        private CellStyle csgianhap;
        private logBL _ctrlog = new logBL();
        private int _type = 0;//0:Không hiển thị tschon; 1:Hiển thị tschon
        public int type { get { return _type; } set { this._type = value; } }
        public string sreturn = "";
        public bool flagload = false;
        public bool xemgianhap = false;

        public ucMatHang()
        {
            InitializeComponent();
        }
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
                obj = ctr.GetByIDNhanVienvsMenuName(Data.iduse, "tsMatHang");
                string[] arrquyendl = obj.quyendl.Split(';');
                if (arrquyendl[0].Trim().Equals("EDIT") == true)
                {
                    ultraToolbarsManager1.Tools["btn_Add"].SharedProps.Visible = true;
                    ultraToolbarsManager1.Tools["btn_Save"].SharedProps.Visible = true;
                    //xemgianhap = true;
                }
                if (arrquyendl[1].Trim().Equals("DEL") == true)
                {
                    ultraToolbarsManager1.Tools["btn_Del"].SharedProps.Visible = true;
                    xemgianhap = false;
                }
            }
            catch
            {
                ultraToolbarsManager1.Tools["btn_Add"].SharedProps.Visible = false;
                ultraToolbarsManager1.Tools["btn_Save"].SharedProps.Visible = false;
                ultraToolbarsManager1.Tools["btn_Del"].SharedProps.Visible = false;
            }
        }
        private void LoadCBTKHangSX()
        {
            flagload = true;
            tblhangsanxuatBL ctr = new tblhangsanxuatBL();
            DataTable dt = new DataTable();
            dt = ctr.GetAll();
            cbTKHangSX.DataSource = dt;
            cbTKHangSX.DisplayMember = "ten";
            cbTKHangSX.ValueMember = "id";
            flagload = false;
        }
        private void LoadCBHangSX()
        {
            tblhangsanxuatBL ctr = new tblhangsanxuatBL();
            DataTable dt = new DataTable();
            dt = ctr.GetAll();
            cbHangSX.DataSource = dt;
            cbHangSX.DisplayMember = "ten";
            cbHangSX.ValueMember = "id";
        }
        private void LoadCBTKLoaiMH()
        {
            flagload = true;
            tblloaimathangBL ctr = new tblloaimathangBL();
            DataTable dt = new DataTable();
            dt = ctr.GetAll();
            cbTKLoaiMH.DataSource = dt;
            cbTKLoaiMH.DisplayMember = "ten";
            cbTKLoaiMH.ValueMember = "id";
            flagload = false;
        }
        private void LoadCBLoaiMH()
        {
            tblloaimathangBL ctr = new tblloaimathangBL();
            DataTable dt = new DataTable();
            dt = ctr.GetAll();
            cbLoaiMH.DataSource = dt;
            cbLoaiMH.DisplayMember = "ten";
            cbLoaiMH.ValueMember = "id";
        }
        private void LoadCBDVTinh()
        {
            tblmathangBL ctr = new tblmathangBL();
            DataTable dt = new DataTable();
            dt = ctr.GetDonViTinh();
            cbDonVi.DataSource = dt;
            cbDonVi.DisplayMember = "donvi";
            cbDonVi.ValueMember = "donvi";
        }
        private void HienThiDanhSach()
        {
            try
            {
                tblmathangBL ctr = new tblmathangBL();
                string sidhang = "";
                try { sidhang = cbTKHangSX.SelectedValue.ToString().Trim(); }
                catch { }
                string sidloai = "";
                try { sidloai = cbTKLoaiMH.SelectedValue.ToString().Trim(); }
                catch { }
                DataTable dt = new DataTable();
                if (chkAll.Checked) { dt = ctr.filterall(txtKeyword.Text.Trim(), sidhang, sidloai); }
                else
                {
                    dt = ctr.filter(txtKeyword.Text.Trim(), sidhang, sidloai);
                }
                //dt.Columns.Add("TT", typeof(Int32));
                c1FlexGrid1.DataSource = dt;
                try { c1FlexGrid1.Cols[c1FlexGrid1.Cols["tenhang"].Index].Editor = cbHangSX; }
                catch { }
                try { c1FlexGrid1.Cols[c1FlexGrid1.Cols["tenloai"].Index].Editor = cbLoaiMH; }
                catch { }
                try { c1FlexGrid1.Cols[c1FlexGrid1.Cols["donvi"].Index].Editor = cbDonVi; }
                catch { }
                try { c1FlexGrid1.Cols["gianhap"].Format = "N0"; }
                catch { }
                try { c1FlexGrid1.Cols["giabanbuon"].Format = "N0"; }
                catch { }
                try { c1FlexGrid1.Cols["giabanle"].Format = "N0"; }
                catch { }
                try { c1FlexGrid1.Cols["giadl1"].Format = "N0"; }
                catch { }
                try { c1FlexGrid1.Cols["giadl2"].Format = "N0"; }
                catch { }
                try { c1FlexGrid1.Cols["giadl3"].Format = "N0"; }
                catch { }
                try { c1FlexGrid1.Cols["giadl4"].Format = "N0"; }
                catch { }
                try { c1FlexGrid1.Cols["giadl5"].Format = "N0"; }
                catch { }
                FormatGrid();
                txtKeyword.Focus();
            }
            catch (Exception ex)
            { MessageBox.Show("Lỗi mở dữ liệu.\nChi tiết lỗi : " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }
        private void FormatGrid()
        {
            for (int i = 0; i < c1FlexGrid1.Cols.Count; i++)
            {
                if (c1FlexGrid1.Cols[i].Caption.Equals("stt"))
                {
                    c1FlexGrid1.Cols[i].AllowEditing = false;
                    c1FlexGrid1[0, i] = "Stt"; c1FlexGrid1.Cols[i].Visible = true; c1FlexGrid1.Cols[i].Width = 50;
                }

               
                else if (c1FlexGrid1.Cols[i].Caption.Equals("tenhang"))
                { c1FlexGrid1[0, i] = "Hãng(*)"; c1FlexGrid1.Cols[i].Visible = true; c1FlexGrid1.Cols[i].Width = 90; }
                else if (c1FlexGrid1.Cols[i].Caption.Equals("tenloai"))
                { c1FlexGrid1[0, i] = "Loại(*)"; c1FlexGrid1.Cols[i].Visible = false; c1FlexGrid1.Cols[i].Width = 90; }
                else if (c1FlexGrid1.Cols[i].Caption.Equals("ten"))
                {
                    c1FlexGrid1[0, i] = "Tên(*)"; c1FlexGrid1.Cols[i].Visible = true; c1FlexGrid1.Cols[i].Width = 350;
                }
                else if (c1FlexGrid1.Cols[i].Caption.Equals("gianhap"))
                {
                    c1FlexGrid1[0, i] = "Giá nhập(*)";
                    c1FlexGrid1.Cols[i].Width = 130;
                    if (ultraToolbarsManager1.Tools["btn_Del"].SharedProps.Visible == true)
                    {
                        c1FlexGrid1.Cols[i].Visible = true;
                    }
                    else { c1FlexGrid1.Cols[i].Visible = false; }
                }
                else if (c1FlexGrid1.Cols[i].Caption.Equals("soluong"))
                { c1FlexGrid1[0, i] = "SL(*)"; c1FlexGrid1.Cols[i].Visible = true; c1FlexGrid1.Cols[i].Width = 60; }
                else if (c1FlexGrid1.Cols[i].Caption.Equals("ghichu"))
                { c1FlexGrid1[0, i] = "Ghi chú"; c1FlexGrid1.Cols[i].Visible = true; c1FlexGrid1.Cols[i].Width = 150; }
                else if (c1FlexGrid1.Cols[i].Caption.Equals("donvi"))
                {
                    c1FlexGrid1[0, i] = "ĐV";
                    c1FlexGrid1.Cols[i].Width = 55;
                    c1FlexGrid1.Cols[i].Visible = true;
                }
                else if (c1FlexGrid1.Cols[i].Caption.Equals("giabanbuon"))
                {
                    c1FlexGrid1[0, i] = "Bán buôn";
                    c1FlexGrid1.Cols[i].Width = 110;
                    c1FlexGrid1.Cols[i].Visible = false;
                }
                else if (c1FlexGrid1.Cols[i].Caption.Equals("giabanle"))
                { c1FlexGrid1[0, i] = "Bán lẻ"; c1FlexGrid1.Cols[i].Visible = false; c1FlexGrid1.Cols[i].Width = 105; }
                else if (c1FlexGrid1.Cols[i].Caption.Equals("giadl1"))
                { c1FlexGrid1[0, i] = "ĐL 1"; c1FlexGrid1.Cols[i].Visible = true; c1FlexGrid1.Cols[i].Width = 105; }
                else if (c1FlexGrid1.Cols[i].Caption.Equals("giadl2"))
                { c1FlexGrid1[0, i] = "ĐL 2"; c1FlexGrid1.Cols[i].Visible = true; c1FlexGrid1.Cols[i].Width = 105; }
                else if (c1FlexGrid1.Cols[i].Caption.Equals("giadl3"))
                { c1FlexGrid1[0, i] = "ĐL 3"; c1FlexGrid1.Cols[i].Visible = true; c1FlexGrid1.Cols[i].Width = 105; }
                else if (c1FlexGrid1.Cols[i].Caption.Equals("giadl4"))
                { c1FlexGrid1[0, i] = "ĐL 4"; c1FlexGrid1.Cols[i].Visible = true; c1FlexGrid1.Cols[i].Width = 105; }
                else if (c1FlexGrid1.Cols[i].Caption.Equals("giadl5"))
                { c1FlexGrid1[0, i] = "ĐL 5"; c1FlexGrid1.Cols[i].Visible = true; c1FlexGrid1.Cols[i].Width = 105; }
                else if (c1FlexGrid1.Cols[i].Caption.Equals("tt"))
                { c1FlexGrid1[0, i] = "TT"; c1FlexGrid1.Cols[i].Visible = false;}
                else    if (c1FlexGrid1.Cols[i].Caption.Equals("mavach"))
                {
                   
                    c1FlexGrid1[0, i] = "Mã vạch"; c1FlexGrid1.Cols[i].Visible = true; c1FlexGrid1.Cols[i].Width = 150;
                }

                else if (c1FlexGrid1.Cols[i].Caption.Equals("giamua"))
                {

                    c1FlexGrid1[0, i] = "Giá mua(*)"; c1FlexGrid1.Cols[i].Visible = true; c1FlexGrid1.Cols[i].Width = 100;
                }

                else if (c1FlexGrid1.Cols[i].Caption.Equals("giavanchuyen"))
                {

                    c1FlexGrid1[0, i] = "Giá vận chuyển(*)"; c1FlexGrid1.Cols[i].Visible = true; c1FlexGrid1.Cols[i].Width = 150;
                }
                else { c1FlexGrid1.Cols[i].Visible = false; }
                c1FlexGrid1.Cols[i].TextAlignFixed = TextAlignEnum.CenterCenter;
            }
            Font _font = new Font("Time new Roman", 14);
            c1FlexGrid1.Font = _font;
            //for (int j = 1; j < c1FlexGrid1.Rows.Count; j++)
            //{
            //    c1FlexGrid1[j, 0] = j;
            //    c1FlexGrid1[j, "TT"] = 0;
            //}
            c1FlexGrid1.Cols[0].TextAlign = TextAlignEnum.CenterCenter;
            //c1FlexGrid1.AutoSizeCols();
            //c1FlexGrid1.AutoSizeRows();
            txtKeyword.Focus();
        }
        private List<tblmathang> GetData()
        {
            List<tblmathang> lst = new List<tblmathang>();
            string loi = "";
            for (int i = 1; i < c1FlexGrid1.Rows.Count; i++)
            {
                if (c1FlexGrid1[i, "TT"].ToString().Equals("0") == false)
                {
                    try
                    {
                        loi = "";
                        tblmathang _obj = new tblmathang();
                        if (c1FlexGrid1[i, "tenhang"].ToString().Trim().Equals("") == true)
                        {
                            if (c1FlexGrid1[i, "id_hangsx"].ToString().Trim().Equals("") == true || c1FlexGrid1[i, "id_hangsx"] == null)
                            {
                                loi = "Hãng sản xuất chưa được chọn.";
                                c1FlexGrid1.SetUserData(i, "ten", loi);
                                c1FlexGrid1.Rows[i].Style = cserror;
                            }
                        }
                        else
                        {
                            if (c1FlexGrid1[i, "id_hangsx"].ToString().Trim().Equals("") == true || c1FlexGrid1[i, "id_hangsx"] == null)
                            {
                                loi = "Hãng sản xuất không có trong CSDL.";
                                c1FlexGrid1.SetUserData(i, "ten", loi);
                                c1FlexGrid1.Rows[i].Style = cserror;
                            }
                        }
                        //if (c1FlexGrid1[i, "tenloai"].ToString().Trim().Equals("") == true)
                        //{
                        //    if (c1FlexGrid1[i, "id_loai"].ToString().Trim().Equals("") == true || c1FlexGrid1[i, "id_loai"] == null)
                        //    {
                        //        loi = "Loại mặt hàng chưa được chọn.";
                        //        c1FlexGrid1.SetUserData(i, "ten", loi);
                        //        c1FlexGrid1.Rows[i].Style = cserror;
                        //    }
                        //}
                        //else
                        //{
                        //    if (c1FlexGrid1[i, "id_loai"].ToString().Trim().Equals("") == true || c1FlexGrid1[i, "id_loai"] == null)
                        //    {
                        //        loi = "Loại mặt hàng không có trong CSDL.";
                        //        c1FlexGrid1.SetUserData(i, "ten", loi);
                        //        c1FlexGrid1.Rows[i].Style = cserror;
                        //    }
                        //}
                        if (c1FlexGrid1[i, "ten"].ToString().Trim().Equals("") == true || c1FlexGrid1[i, "ten"] == null)
                        {
                            loi = "Tên mặt hàng không được để trắng.";
                            c1FlexGrid1.SetUserData(i, "ten", loi);
                            c1FlexGrid1.Rows[i].Style = cserror;
                            return null;
                        }
                        
                        if (c1FlexGrid1[i, "TT"].ToString().Equals("1") == true)
                        { _obj.id = Guid.NewGuid().ToString(); c1FlexGrid1[i, "id"] = _obj.id.Trim(); }
                        if (c1FlexGrid1[i, "TT"].ToString().Equals("2") == true)
                        { _obj.id = c1FlexGrid1[i, "id"].ToString(); }
                        try
                        {
                            _obj.gianhap = Convert.ToDouble(c1FlexGrid1[i, "gianhap"].ToString());
                        }
                        catch { _obj.gianhap = 0; }
                        try
                        {
                            _obj.soluong = Convert.ToInt32(c1FlexGrid1[i, "soluong"].ToString());
                        }
                        catch { _obj.soluong = 0; }
                        try
                        {
                            _obj.giabanbuon = Convert.ToDouble(c1FlexGrid1[i, "giabanbuon"].ToString());
                        }
                        catch { _obj.giabanbuon = 0; }
                        try
                        {
                            _obj.giabanle = Convert.ToDouble(c1FlexGrid1[i, "giabanle"].ToString());
                        }
                        catch { _obj.giabanle = 0; }
                        try
                        {
                            _obj.giadl1 = Convert.ToDouble(c1FlexGrid1[i, "giadl1"].ToString());
                        }
                        catch { _obj.giadl1 = 0; }
                        try
                        {
                            _obj.giadl2 = Convert.ToDouble(c1FlexGrid1[i, "giadl2"].ToString());
                        }
                        catch { _obj.giadl2 = 0; }
                        try
                        {
                            _obj.giadl3 = Convert.ToDouble(c1FlexGrid1[i, "giadl3"].ToString());
                        }
                        catch { _obj.giadl3 = 0; }
                        try
                        {
                            _obj.giadl4 = Convert.ToDouble(c1FlexGrid1[i, "giadl4"].ToString());
                        }
                        catch { _obj.giadl4 = 0; }
                        try
                        {
                            _obj.giadl5 = Convert.ToDouble(c1FlexGrid1[i, "giadl5"].ToString());
                        }
                        catch { _obj.giadl5 = 0; }

                        try
                        {
                            _obj.giamua = Convert.ToDouble(c1FlexGrid1[i, "giamua"].ToString());
                        }
                        catch { _obj.giamua = 0; }

                        try
                        {
                            _obj.giavanchuyen = Convert.ToDouble(c1FlexGrid1[i, "giavanchuyen"].ToString());
                        }
                        catch { _obj.giavanchuyen = 0; }

                        try
                        {
                            _obj.mavach =(c1FlexGrid1[i, "mavach"].ToString());
                        }
                        catch { _obj.mavach =""; }
                        tblmathang objMaVach = new tblmathang();
                        tblmathangBL ctrMaVach = new tblmathangBL();
                        if(ctrMaVach.GetByMaVach(_obj.mavach) != null)
                        {
                            loi = "Mã mặt hàng đã tồn tại.\nVui lòng nhập một mã vạch khác";
                            c1FlexGrid1.SetUserData(i, "ten", loi);
                            c1FlexGrid1.Rows[i].Style = cserror;
                            //return null;
                        }
                        _obj.id_hangsx = c1FlexGrid1[i, "id_hangsx"].ToString();
                        //Loại mặt hàng được gán cứng vì yêu cầu không sử dụng loại mặt hàng
                        _obj.id_loai = "25dd7dd517fe464bb338d40d96a5bdbe";// c1FlexGrid1[i, "id_loai"].ToString();
                        _obj.ten = c1FlexGrid1[i, "ten"].ToString().Trim();
                        string stenkhongdau = "";
                        stenkhongdau = Data.ChuyenTVKhongDau(_obj.ten);
                        //Xử lý tên viết tắt
                        string[] arrten = stenkhongdau.Trim().Replace("(", "").Replace(")", "").Replace("-", "").Split(' ');
                        string skyhieu = "";
                        for (int j = 0; j < arrten.Length; j++)
                        {
                            if (arrten[j].Trim().Equals("") == false)
                            {
                                skyhieu = skyhieu + arrten[j].Substring(0, 1);
                            }
                        }
                        _obj.tenkhongdau = skyhieu + ";" + stenkhongdau;
                        try { _obj.ghichu = c1FlexGrid1[i, "ghichu"].ToString().Trim(); }
                        catch { _obj.ghichu = ""; }
                        _obj.ngaynhap = Convert.ToDateTime(DateTime.Now.ToShortDateString());
                        _obj.donvi = c1FlexGrid1[i, "donvi"].ToString();
                        if (loi.Trim().Equals("") == true) { c1FlexGrid1.SetUserData(i, "ten", ""); }
                        lst.Add(_obj);
                    }
                    catch { }
                }
            }
            return lst;
        }
        #endregion
        #region Method xử lý cập nhật dữ liệu
        private void Delete()
        {
            tblmathangBL ctr = new tblmathangBL();
            string loi = "";
            string sten = "";
            string sid = "";
            int n = c1FlexGrid1.RowSel;
            if (n >= 1)
            {
                try { sten = c1FlexGrid1[c1FlexGrid1.RowSel, "ten"].ToString().Trim(); }
                catch { }
                try { sid = c1FlexGrid1[c1FlexGrid1.RowSel, "id"].ToString().Trim(); }
                catch { }
                if (sid.Trim().Equals("") == false)
                {
                    DialogResult bien;
                    bien = MessageBox.Show("Xác nhận xóa dữ liệu?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (bien == DialogResult.Yes)
                    {
                        loi = ctr.Delete(sid);
                        if (loi.Equals("") == true)
                        {
                            try { _ctrlog.Append(Data.use, "Xóa mặt hàng: " + sten.Trim()); }
                            catch { }
                            HienThiDanhSach();
                        }
                        else
                        {
                            MessageBox.Show(loi, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                else
                {
                    c1FlexGrid1.Rows.Remove(c1FlexGrid1.RowSel);
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
            tblmathangBL _ctr = new tblmathangBL();
            List<tblmathang> lst = new List<tblmathang>();
            lst = GetData();
            if (lst != null)
            {
                for (int i = 0; i < lst.Count; i++)
                {
                    loi = "";
                    tblmathang _obj = new tblmathang();
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
                                _ctrlog.Append(Data.use, "Thêm mới mặt hàng: " + lst[i].ten.Trim());
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
                                _ctrlog.Append(Data.use, "Cập nhật mặt hàng: " + lst[i].ten.Trim());
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
                HienThiDanhSach();
                c1FlexGrid1.Select(1, c1FlexGrid1.Cols["ten"].Index, true);
                MessageBox.Show("Cập nhật dữ liệu thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else { MessageBox.Show("Cập nhật dữ liệu không thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }
        private void Cancel()
        {
            HienThiDanhSach();
        }
        private void Add()
        {
            c1FlexGrid1.Rows.Add();
            c1FlexGrid1[c1FlexGrid1.Rows.Count - 1, "TT"] = 1;
            c1FlexGrid1[c1FlexGrid1.Rows.Count - 1, "id"] = "";
            c1FlexGrid1[c1FlexGrid1.Rows.Count - 1, 0] = (c1FlexGrid1.Rows.Count - 1).ToString();
            c1FlexGrid1.StartEditing(c1FlexGrid1.Rows.Count - 1, 2);
        }
        #endregion
        #region Xử lý Grid
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
        private void c1FlexGrid1_AfterEdit(object sender, C1.Win.C1FlexGrid.RowColEventArgs e)
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
                if (c1FlexGrid1.Cols[c1FlexGrid1.ColSel].Name.ToLower().Equals("giadl5") == true && c1FlexGrid1.RowSel == c1FlexGrid1.Rows.Count - 1)
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

                //tinh gia nhap =gia mua+gia van chuyen
                double giamua = 0;
                double giavanchuyen = 0;
                try
                {
                    giamua = Convert.ToDouble(c1FlexGrid1[c1FlexGrid1.RowSel, "giamua"].ToString());
                }
                catch { }
                try
                {
                    giavanchuyen = Convert.ToDouble(c1FlexGrid1[c1FlexGrid1.RowSel, "giavanchuyen"].ToString());
                }
                catch { }
                c1FlexGrid1[c1FlexGrid1.RowSel, "gianhap"] = (giamua + giavanchuyen).ToString().Trim();
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
            if (type == 1)
            {
                if (e.Button == System.Windows.Forms.MouseButtons.Right) { contextMenuStrip1.Show(c1FlexGrid1, e.X, e.Y); }
            }
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
        private void btnTim_Click(object sender, EventArgs e)
        {
            HienThiDanhSach();
        }
        private void txtKeyword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) { HienThiDanhSach(); }
        }
        private void txtKeyword_TextChanged(object sender, EventArgs e)
        {
            if (chkAll.Checked == false)
            {
                HienThiDanhSach();
            }
        }
        private void cbTKHangSX_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (flagload == false)
            {
                HienThiDanhSach();
            }
        }
        private void cbTKHangSX_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) { HienThiDanhSach(); }
        }
        private void cbTKLoaiMH_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (flagload == false)
            {
                HienThiDanhSach();
            }
        }
        private void cbTKLoaiMH_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) { HienThiDanhSach(); }
        }
        private void chkAll_CheckedChanged(object sender, EventArgs e)
        {
            if (flagload == false)
            {
                HienThiDanhSach();
            }
        }
        #endregion
        private void ucMatHang_Load(object sender, EventArgs e)
        {
            try
            {
                CheckQuyenDL();
                LoadCBTKHangSX();
                LoadCBHangSX();
                LoadCBTKLoaiMH();
                LoadCBLoaiMH();
                LoadCBDVTinh();
                cbTKHangSX.Text = ""; cbTKHangSX.SelectedValue = ""; 
                cbHangSX.SelectedValue = ""; cbHangSX.Text = "";
                cbTKLoaiMH.Text = ""; cbTKLoaiMH.SelectedValue = "";
                cbLoaiMH.SelectedValue = ""; cbLoaiMH.Text = ""; 
                cbDonVi.Text = "";
                c1FlexGrid1.KeyActionEnter = KeyActionEnum.MoveAcross;
                c1FlexGrid1.Rows.DefaultSize = 30;
                cserror = c1FlexGrid1.Styles.Add("Error");
                cserror.BackColor = Color.Red;
                csten = c1FlexGrid1.Styles.Add("ten");
                csten.BackColor = Color.Aquamarine;
                csgiaban = c1FlexGrid1.Styles.Add("giaban");
                csgiaban.BackColor = Color.YellowGreen;
                csgianhap = c1FlexGrid1.Styles.Add("gianhap");
                csgianhap.BackColor = Color.Yellow;
                HienThiDanhSach();
            }
            catch { }
            txtKeyword.Focus();
        }
        #region Xử lý sự kiện combobox SelectedIndexChanged
        private void cbHangSX_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (c1FlexGrid1.RowSel > 0)
            {
                if (cbHangSX.SelectedValue != null)
                {
                    c1FlexGrid1[c1FlexGrid1.RowSel, c1FlexGrid1.Cols["id_hangsx"].Index] = cbHangSX.SelectedValue.ToString().Trim();
                }
            }
        }
        private void cbLoaiMH_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (c1FlexGrid1.RowSel > 0)
            {
                if (cbLoaiMH.SelectedValue != null)
                {
                    c1FlexGrid1[c1FlexGrid1.RowSel, c1FlexGrid1.Cols["id_loai"].Index] = cbLoaiMH.SelectedValue.ToString().Trim();
                }
            }
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
           ((frmChonMatHang)this.FindForm()).sreturn = sreturn;
            this.Parent.Dispose();
        }
        private void c1FlexGrid1_DoubleClick(object sender, EventArgs e)
        {
            if (_type != 0)
            {
                if (c1FlexGrid1.Rows.Count - 1 > 0)
                {
                    try { sreturn = c1FlexGrid1[c1FlexGrid1.RowSel, "id"].ToString().Trim(); }
                    catch { }
                }
                else { sreturn = ""; }
            ((frmChonMatHang)this.FindForm()).sreturn = sreturn;
                this.Parent.Dispose();
            }
        }
    }
}
