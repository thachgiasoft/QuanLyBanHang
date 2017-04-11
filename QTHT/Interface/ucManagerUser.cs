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
    public enum TrangThai { add,update,none}
    public partial class ucManagerUser : UserControl
    {
        private logBL _ctrlog = new logBL();
        private TrangThai trangthai;
        private InputValidation.Validation _validation = new InputValidation.Validation();

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
                obj = ctr.GetByIDNhanVienvsMenuName(Data.iduse, "tsUsers");
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
        private void LoadCBCV()
        {
            try
            {
                chucvuBL _ctr = new chucvuBL();
                DataTable dt = new DataTable();
                dt = _ctr.GetAll();
                cbChucVu.DataSource = dt;
                cbChucVu.DisplayMember = "tenchucvu";
                cbChucVu.ValueMember = "idchucvu";
            }
            catch { }
        }
        private void LoadCBPB()
        {
            try
            {
                phongbanBL _ctr = new phongbanBL();
                DataTable dt = new DataTable();
                dt = _ctr.GetAll();
                cbPhongBan.DataSource = dt;
                cbPhongBan.DisplayMember = "tenphongban";
                cbPhongBan.ValueMember = "idphongban";
            }
            catch { }
        }
        private void LoadTKCBCV()
        {
            try
            {
                chucvuBL _ctr = new chucvuBL();
                DataTable dt = new DataTable();
                dt = _ctr.GetAll();
                cbTK_ChucVu.DataSource = dt;
                cbTK_ChucVu.DisplayMember = "tenchucvu";
                cbTK_ChucVu.ValueMember = "idchucvu";
            }
            catch { }
        }
        private void LoadTKCBPB()
        {
            try
            {
                phongbanBL _ctr = new phongbanBL();
                DataTable dt = new DataTable();
                dt = _ctr.GetAll();
                cbTK_PhongBan.DataSource = dt;
                cbTK_PhongBan.DisplayMember = "tenphongban";
                cbTK_PhongBan.ValueMember = "idphongban";
            }
            catch { }
        }
        private void FindUse()
        {
            nhanvienBL _ctr = new nhanvienBL();
            DataTable dt = new DataTable();
            string sidphongban = "";try{sidphongban = cbTK_PhongBan.SelectedValue.ToString().Trim();}catch{}
            int sidchucvu = 0;try{sidchucvu = Convert.ToInt32(cbTK_ChucVu.SelectedValue.ToString().Trim());}catch{}
            dt = _ctr.TimKiem(txtTK_HoTen.Text.Trim(), sidphongban, sidchucvu);
            c1FlexGrid1.DataSource = dt;
            FormatGrid();
        }
        private void FormatGrid()
        {
            for (int i = 0; i < c1FlexGrid1.Cols.Count; i++)
            {
                if (i == 0)
                { c1FlexGrid1[0, i] = "STT"; c1FlexGrid1.Cols[i].Visible = true; c1FlexGrid1.Cols[i].Width = 60; }
                else if (c1FlexGrid1.Cols[i].Caption.Equals("hoten"))
                { c1FlexGrid1[0, i] = "Họ tên"; c1FlexGrid1.Cols[i].Visible = true; }
                else if (c1FlexGrid1.Cols[i].Caption.Equals("tenchucvu"))
                { c1FlexGrid1[0, i] = "Chức vụ"; c1FlexGrid1.Cols[i].Visible = true; }
                else if (c1FlexGrid1.Cols[i].Caption.Equals("tenphongban"))
                { c1FlexGrid1[0, i] = "Phòng"; c1FlexGrid1.Cols[i].Visible = true; }
                else { c1FlexGrid1.Cols[i].Visible = false; }
                c1FlexGrid1.Cols[i].TextAlignFixed = TextAlignEnum.CenterCenter;
            }
            Font _font = new Font("Time new Roman", 14);
            c1FlexGrid1.Font = _font;
            for (int j = 1; j < c1FlexGrid1.Rows.Count; j++)
            {
                c1FlexGrid1[j, 0] = j;
            }
            c1FlexGrid1.Cols[0].TextAlign = TextAlignEnum.CenterCenter;
            c1FlexGrid1.AutoSizeCols();
            c1FlexGrid1.AutoSizeRows();
        }
        private void DisplayInfoUser(string sid)
        {
            nhanvien _obj = new nhanvien();
            nhanvienBL _ctr = new nhanvienBL();
            _obj = _ctr.GetByID(sid);
            if (_obj != null)
            {
                trangthai = TrangThai.update;
                txtAccount.Text = _obj.taikhoan.Trim();
                txtAccount.Enabled = false;
                txtDiaChi.Text = _obj.diachi.Trim();
                txtDienThoai.Text = _obj.dienthoai.Trim();
                txtEmail.Text = _obj.email.Trim();
                txtGhiChu.Text = _obj.ghichu.Trim();
                txtHoTen.Text = _obj.hoten.Trim();
                txtPass.Text = _obj.matkhau;
                txtPass.Enabled = false;
                dpkNgaySinh.Value = _obj.ngaysinh;
                cbGioiTinh.Checked = _obj.gioitinh;
                if (_obj.idchucvu == 0) { cbChucVu.SelectedIndex = -1; } else { cbChucVu.SelectedValue = _obj.idchucvu; }
                if (_obj.idphongban.Trim().Equals("") == true) { cbPhongBan.SelectedIndex = -1; } else { cbPhongBan.SelectedValue = _obj.idphongban.Trim(); }
                txtAccount.Focus();
            }
        }
        private nhanvien GetDataValue()
        {
            nhanvien _obj = new nhanvien();
            int iidchucvu = 0; try { iidchucvu = Convert.ToInt32(cbChucVu.SelectedValue.ToString().Trim()); }
            catch { }
            string sidphongban = ""; try { sidphongban = cbPhongBan.SelectedValue.ToString().Trim(); }
            catch { }
            if (trangthai == TrangThai.add) { _obj.idnhanvien = Guid.NewGuid().ToString(); }
            if (trangthai == TrangThai.update) { _obj.idnhanvien = c1FlexGrid1[c1FlexGrid1.RowSel,"idnhanvien"].ToString().Trim(); }
            if (txtAccount.Text.Equals("") == true)
            { MessageBox.Show("Tài khoản không được để trắng.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning); txtAccount.Focus(); return null; }
            if (txtPass.Text.Equals("") == true && trangthai == TrangThai.add)
            { MessageBox.Show("Mật khẩu không được để trắng.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning); txtPass.Focus(); return null; }
            if (iidchucvu == 0)
            { MessageBox.Show("Chức vụ không được để trắng.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning); cbChucVu.Focus(); return null; }
            if (sidphongban.Trim().Equals("") == true)
            { MessageBox.Show("Phòng ban không được để trắng.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning); cbPhongBan.Focus(); return null; }
            if (txtHoTen.Text.Equals("") == true)
            { MessageBox.Show("Họ tên không được để trắng.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning); txtHoTen.Focus(); return null; }
            if (dpkNgaySinh.Value == null)
            { MessageBox.Show("Ngày sinh không được để trắng.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning); dpkNgaySinh.Focus(); return null; }
            if (txtDienThoai.Text.Equals("") == true)
            { MessageBox.Show("Điện thoại không được để trắng.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning); txtDienThoai.Focus(); return null; }
            if (txtEmail.Text.Equals("") == true)
            { MessageBox.Show("Email không được để trắng.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning); txtEmail.Focus(); return null; }
            _obj.diachi = txtDiaChi.Text.Trim();
            _obj.dienthoai = txtDienThoai.Text.Trim();
            _obj.email = txtEmail.Text.Trim();
            _obj.ghichu = txtGhiChu.Text.Trim();
            _obj.gioitinh = cbGioiTinh.Checked;
            _obj.hoten = txtHoTen.Text.Trim();
            _obj.idphongban = sidphongban;
            _obj.idchucvu = iidchucvu;
            _obj.ngaysinh = dpkNgaySinh.Value;
            _obj.taikhoan = txtAccount.Text.Trim();
            _obj.matkhau = _validation.EncryptPassword(_obj.taikhoan.Trim(), txtPass.Text);
            return _obj;
        }
        private void ClearText()
        {
            txtAccount.Text = "";
            txtAccount.Enabled = true;
            txtDiaChi.Text = "";
            txtDienThoai.Text = "";
            txtEmail.Text = "";
            txtGhiChu.Text = "";
            txtHoTen.Text = "";
            txtPass.Text = "";
            txtPass.Enabled = true;
            cbChucVu.SelectedIndex = -1;
            cbPhongBan.SelectedIndex = -1;
            dpkNgaySinh.Value = DateTime.Now;
            cbGioiTinh.Checked = true;
        }
        private void Add()
        {
            trangthai = TrangThai.add;
            ClearText();
            txtAccount.Focus();
        }
        private void Save()
        {
            string loi = "";
            nhanvien _obj = new nhanvien();
            nhanvienBL _ctr = new nhanvienBL();
            _obj = GetDataValue();
            if (_obj != null)
            {
                if (trangthai == TrangThai.add)
                {
                    loi = _ctr.Insert(_obj);
                    if (loi.Trim().Equals("") == true)
                    {
                        _ctrlog.Append(Data.use, "Thêm mới người dùng: " + _obj.taikhoan.Trim() + "(" + _obj.hoten + ")");
                        FindUse();
                        c1FlexGrid1.Select(c1FlexGrid1.FindRow(_obj.idnhanvien.Trim(), 1, c1FlexGrid1.Cols["idnhanvien"].Index, true), c1FlexGrid1.Cols["hoten"].Index, true);
                        MessageBox.Show("Thêm mới người dùng thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show(loi, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                if (trangthai == TrangThai.update)
                {
                    loi = _ctr.Update(_obj);
                    if (loi.Trim().Equals("") == true)
                    {
                        _ctrlog.Append(Data.use, "Cập nhật thông tin người dùng: " + _obj.taikhoan.Trim() + "(" + _obj.hoten + ")");
                        trangthai = TrangThai.update;
                        FindUse();
                        c1FlexGrid1.Select(c1FlexGrid1.FindRow(_obj.idnhanvien.Trim(), 1, c1FlexGrid1.Cols["idnhanvien"].Index, true), c1FlexGrid1.Cols["hoten"].Index, true);
                        MessageBox.Show("Cập nhật thông tin người dùng thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show(loi, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            if (loi.Trim().Equals("") == true)
            {
                trangthai = TrangThai.update;
                DisplayInfoUser(_obj.idnhanvien);
            }
        }
        private void Cancel()
        {
            string sidnhanvien = "";
            try { sidnhanvien = c1FlexGrid1[c1FlexGrid1.RowSel,"idnhanvien"].ToString().Trim();}
            catch { }
            trangthai = TrangThai.update;
            DisplayInfoUser(sidnhanvien);
        }
        private void Delete()
        {
            string staikhoan = "";
            try { staikhoan = c1FlexGrid1[c1FlexGrid1.RowSel, "taikhoan"].ToString().Trim(); }
            catch { }
            if (staikhoan.Trim().Equals("admin") == false)
            {
                if (MessageBox.Show("Xác nhận xóa người dùng.", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    string sidnhanvien = "";
                    try { sidnhanvien = c1FlexGrid1[c1FlexGrid1.RowSel, "idnhanvien"].ToString().Trim(); }
                    catch { }
                    nhanvien _obj = new nhanvien();
                    nhanvienBL _ctr = new nhanvienBL();
                    _obj = _ctr.GetByID(sidnhanvien);
                    string loi = "";
                    loi = _ctr.Delete(sidnhanvien);
                    if (loi.Trim().Equals("") == true)
                    {
                        try { _ctrlog.Append(Data.use, "Xóa người dùng: " + _obj.hoten.Trim() + "(" + _obj.taikhoan.Trim() + ")"); }
                        catch { }
                        FindUse();
                        ClearText();
                        trangthai = TrangThai.none;
                        MessageBox.Show("Xóa người dùng thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            else
            {
                MessageBox.Show("Bạn không thể xóa người dùng này.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void Resetpass()
        {
            if (MessageBox.Show("Xác nhận đặt lại mật khẩu người dùng.\nSau khi thiết lập lại thì mật khẩu mặc định là: \"123456\".", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                string loi = "";
                string spass = "";
                string sidnhanvien = "";
                try { sidnhanvien = c1FlexGrid1[c1FlexGrid1.RowSel, "idnhanvien"].ToString().Trim(); }
                catch { }
                nhanvien _obj = new nhanvien();
                nhanvienBL _ctr = new nhanvienBL();
                _obj = _ctr.GetByID(sidnhanvien);
                spass = _validation.EncryptPassword(_obj.taikhoan.Trim(), "123456");
                if (_obj != null)
                {
                    _obj.matkhau = spass;
                    loi = _ctr.ChangePass(sidnhanvien, spass);
                    if (loi.Trim().Equals("") == true)
                    {
                        c1FlexGrid1.Select(c1FlexGrid1.FindRow(_obj.idnhanvien.Trim(), 1, c1FlexGrid1.Cols["idnhanvien"].Index, true), c1FlexGrid1.Cols["hoten"].Index, true);
                        DisplayInfoUser(sidnhanvien);
                        _ctrlog.Append(Data.use, "Đặt lập lại mật khẩu người dùng: " + _obj.taikhoan.Trim() + "(" + _obj.hoten + ")");
                        trangthai = TrangThai.update;
                        MessageBox.Show("Đặt lập lại mật khẩu người dùng thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show(loi, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
        #endregion
        public ucManagerUser()
        {
            InitializeComponent();
        }
        private void ucManagerUser_Load(object sender, EventArgs e)
        {
            CheckQuyenDL();
            LoadCBCV();
            LoadCBPB();
            LoadTKCBPB();
            LoadTKCBCV();
            cbChucVu.SelectedIndex = -1;
            cbPhongBan.SelectedIndex = -1;
            cbTK_ChucVu.SelectedIndex = -1;
            cbTK_PhongBan.SelectedIndex = -1;
            FindUse();
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
        private void c1FlexGrid1_Click(object sender, EventArgs e)
        {
            string sidnhanvien = "";
            try { sidnhanvien = c1FlexGrid1[c1FlexGrid1.RowSel, "idnhanvien"].ToString().Trim(); }
            catch { }
            if (sidnhanvien.Trim().Equals("") == false) { DisplayInfoUser(sidnhanvien); }
        }
        private void c1FlexGrid1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Right)
            {
                if (c1FlexGrid1.Rows.Count - 1 > 0 && c1FlexGrid1.RowSel != 0)
                {
                    contextMenuStrip1.Show(c1FlexGrid1, e.X, e.Y);
                }
            }
        }
        private void tsResetPass_Click(object sender, EventArgs e)
        {
            Resetpass();
        }
        #region Xử lý sự kiện tìm kiếm
        private void btnSearch_Click(object sender, EventArgs e)
        {
            FindUse();
        }
        private void cbTK_PhongBan_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) { btnSearch_Click(sender, e); }
        }
        private void cbTK_ChucVu_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) { btnSearch_Click(sender, e); }
        }
        private void txtTK_HoTen_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) { btnSearch_Click(sender, e); }
        }
        #endregion
    }
}
