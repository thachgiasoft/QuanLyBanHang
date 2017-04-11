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
    public partial class ucTKMatHangSapHet : UserControl
    {
        public bool flagload = false;
        private CellStyle cssl;

        #region Method
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
                int isoluong = 0;
                try
                {
                    isoluong = Convert.ToInt32(txtSoLuong.Text.Trim());
                }
                catch { }
                dt = ctr.filterallforthongke(txtKeyword.Text.Trim(), sidhang, sidloai, isoluong);
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
                lbCount.Text = "Tìm thấy: " + dt.Rows.Count.ToString() + " mặt hàng";
                //txtKeyword.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi mở dữ liệu.\nChi tiết lỗi : " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                lbCount.Text = "Tìm thấy:...";
            }
        }
        private void FormatGrid()
        {
            for (int i = 0; i < c1FlexGrid1.Cols.Count; i++)
            {
                if (c1FlexGrid1.Cols[i].Caption.Equals("stt"))
                {
                    c1FlexGrid1.Cols[i].AllowEditing = false;
                    c1FlexGrid1[0, i] = "Stt"; c1FlexGrid1.Cols[i].Visible = true; 
                    //c1FlexGrid1.Cols[i].Width = 50;
                }
                else if (c1FlexGrid1.Cols[i].Caption.Equals("tenhang"))
                { 
                    c1FlexGrid1[0, i] = "Hãng(*)"; c1FlexGrid1.Cols[i].Visible = true; 
                    //c1FlexGrid1.Cols[i].Width = 90; 
                }
                else if (c1FlexGrid1.Cols[i].Caption.Equals("tenloai"))
                { 
                    c1FlexGrid1[0, i] = "Loại(*)"; c1FlexGrid1.Cols[i].Visible = false; 
                    //c1FlexGrid1.Cols[i].Width = 90; 
                }
                else if (c1FlexGrid1.Cols[i].Caption.Equals("ten"))
                {
                    c1FlexGrid1[0, i] = "Tên(*)"; c1FlexGrid1.Cols[i].Visible = true; 
                    //c1FlexGrid1.Cols[i].Width = 350;
                }
                else if (c1FlexGrid1.Cols[i].Caption.Equals("gianhap"))
                {
                    c1FlexGrid1[0, i] = "Giá nhập(*)";
                    //c1FlexGrid1.Cols[i].Width = 130;
                    try
                    {
                        quyennguoidung obj = new quyennguoidung();
                        quyennguoidungBL ctr = new quyennguoidungBL();
                        obj = ctr.GetByIDNhanVienvsMenuName(Data.iduse, "tsMatHang");
                        string[] arrquyendl = obj.quyendl.Split(';');
                        if (arrquyendl[0].Trim().Equals("EDIT") == true)
                        {
                            c1FlexGrid1.Cols[i].Visible = true;
                        }
                        else { c1FlexGrid1.Cols[i].Visible = false; }
                    }
                    catch
                    {
                        c1FlexGrid1.Cols[i].Visible = false; 
                    }
                }
                else if (c1FlexGrid1.Cols[i].Caption.Equals("soluong"))
                { 
                    c1FlexGrid1[0, i] = "SL(*)"; c1FlexGrid1.Cols[i].Visible = true; 
                    //c1FlexGrid1.Cols[i].Width = 60; 
                    c1FlexGrid1.Cols[i].Style = cssl;
                }
                else if (c1FlexGrid1.Cols[i].Caption.Equals("ghichu"))
                { 
                    c1FlexGrid1[0, i] = "Ghi chú"; 
                    c1FlexGrid1.Cols[i].Visible = true; 
                    //c1FlexGrid1.Cols[i].Width = 150; 
                }
                else if (c1FlexGrid1.Cols[i].Caption.Equals("donvi"))
                {
                    c1FlexGrid1[0, i] = "ĐV";
                    //c1FlexGrid1.Cols[i].Width = 55;
                    c1FlexGrid1.Cols[i].Visible = true;
                }
                //else if (c1FlexGrid1.Cols[i].Caption.Equals("giabanbuon"))
                //{
                //    c1FlexGrid1[0, i] = "Bán buôn";
                //    //c1FlexGrid1.Cols[i].Width = 110;
                //    c1FlexGrid1.Cols[i].Visible = false;
                //}
                //else if (c1FlexGrid1.Cols[i].Caption.Equals("giabanle"))
                //{ c1FlexGrid1[0, i] = "Bán lẻ"; c1FlexGrid1.Cols[i].Visible = false; c1FlexGrid1.Cols[i].Width = 105; }
                //else if (c1FlexGrid1.Cols[i].Caption.Equals("giadl1"))
                //{ c1FlexGrid1[0, i] = "ĐL 1"; c1FlexGrid1.Cols[i].Visible = true; c1FlexGrid1.Cols[i].Width = 105; }
                //else if (c1FlexGrid1.Cols[i].Caption.Equals("giadl2"))
                //{ c1FlexGrid1[0, i] = "ĐL 2"; c1FlexGrid1.Cols[i].Visible = true; c1FlexGrid1.Cols[i].Width = 105; }
                //else if (c1FlexGrid1.Cols[i].Caption.Equals("giadl3"))
                //{ c1FlexGrid1[0, i] = "ĐL 3"; c1FlexGrid1.Cols[i].Visible = true; c1FlexGrid1.Cols[i].Width = 105; }
                //else if (c1FlexGrid1.Cols[i].Caption.Equals("giadl4"))
                //{ c1FlexGrid1[0, i] = "ĐL 4"; c1FlexGrid1.Cols[i].Visible = true; c1FlexGrid1.Cols[i].Width = 105; }
                //else if (c1FlexGrid1.Cols[i].Caption.Equals("giadl5"))
                //{ c1FlexGrid1[0, i] = "ĐL 5"; c1FlexGrid1.Cols[i].Visible = true; c1FlexGrid1.Cols[i].Width = 105; }
                //else if (c1FlexGrid1.Cols[i].Caption.Equals("tt"))
                //{ c1FlexGrid1[0, i] = "TT"; c1FlexGrid1.Cols[i].Visible = false; }
                else { c1FlexGrid1.Cols[i].Visible = false; }
                c1FlexGrid1.Cols[i].TextAlignFixed = TextAlignEnum.CenterCenter;
            }
            Font _font = new Font("Time new Roman", 14);
            c1FlexGrid1.Font = _font;
            c1FlexGrid1.Cols[0].TextAlign = TextAlignEnum.CenterCenter;
            c1FlexGrid1.AutoSizeCols();
            c1FlexGrid1.AutoSizeRows();
            //txtKeyword.Focus();
        }
        #endregion

        public ucTKMatHangSapHet()
        {
            InitializeComponent();
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
            HienThiDanhSach();
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
        private void txtSoLuong_TextChanged(object sender, EventArgs e)
        {
            HienThiDanhSach();
        }
        #endregion

        private void ucTKMatHangSapHet_Load(object sender, EventArgs e)
        {
            try
            {
                LoadCBTKHangSX();
                LoadCBTKLoaiMH();
                LoadCBDVTinh();
                cbTKHangSX.Text = ""; cbTKHangSX.SelectedValue = "";
                cbHangSX.SelectedValue = ""; cbHangSX.Text = "";
                cbTKLoaiMH.Text = ""; cbTKLoaiMH.SelectedValue = "";
                cbLoaiMH.SelectedValue = ""; cbLoaiMH.Text = "";
                cbDonVi.Text = "";
                c1FlexGrid1.Rows.DefaultSize = 30;
                cssl = c1FlexGrid1.Styles.Add("gianhap");
                cssl.BackColor = Color.Aquamarine;
                HienThiDanhSach();
            }
            catch { }
            txtKeyword.Focus();
        }
    }
}
