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

namespace HoaDon.Interface
{
    public partial class frmMatHangTra : Form
    {
        private logBL _ctrlog = new logBL();
        public string sreturn = "";
        public bool flagload = false;
        private string sidkh = "";

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
        private void HienThiDanhSach()
        {
            try
            {
                tblmathangBL ctr = new tblmathangBL();
                string sidhang = "";
                try { sidhang = cbTKHangSX.SelectedValue.ToString().Trim(); }
                catch { }
                DataTable dt = new DataTable();
                if (chkAll.Checked) { dt = ctr.filtermathangtraall(txtKeyword.Text.Trim(), sidhang, "", sidkh); }
                else
                {
                    dt = ctr.filtermathangtra(txtKeyword.Text.Trim(), sidhang, "", sidkh);
                }
                c1FlexGrid1.DataSource = dt;
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
            tblkhachhang objkh = new tblkhachhang();
            tblkhachhangBL ctrkh = new tblkhachhangBL();
            objkh = ctrkh.GetByID(sidkh);
            for (int i = 0; i < c1FlexGrid1.Cols.Count; i++)
            {
                if (c1FlexGrid1.Cols[i].Caption.Equals("stt"))
                { c1FlexGrid1[0, i] = "Stt"; c1FlexGrid1.Cols[i].Visible = true; c1FlexGrid1.Cols[i].AllowEditing = false; }
                else if (c1FlexGrid1.Cols[i].Caption.Equals("tenhang"))
                { c1FlexGrid1[0, i] = "Hãng(*)"; c1FlexGrid1.Cols[i].Visible = true; }
                else if (c1FlexGrid1.Cols[i].Caption.Equals("tenloai"))
                { c1FlexGrid1[0, i] = "Loại(*)"; c1FlexGrid1.Cols[i].Visible = false; }
                else if (c1FlexGrid1.Cols[i].Caption.Equals("ten"))
                {
                    c1FlexGrid1[0, i] = "Tên(*)"; c1FlexGrid1.Cols[i].Visible = true;
                }
                else if (c1FlexGrid1.Cols[i].Caption.Equals("donvi"))
                {
                    c1FlexGrid1[0, i] = "ĐV";
                    c1FlexGrid1.Cols[i].Visible = true;
                }
                else if (c1FlexGrid1.Cols[i].Caption.Equals("giadl1") == true && objkh.id_capdl.ToLower().Trim().Equals("đại lý cấp 1") == true)
                { c1FlexGrid1[0, i] = "Giá bán"; c1FlexGrid1.Cols[i].Visible = true; }
                else if (c1FlexGrid1.Cols[i].Caption.Equals("giadl2") == true && objkh.id_capdl.ToLower().Trim().Equals("đại lý cấp 2") == true)
                { c1FlexGrid1[0, i] = "Giá bán"; c1FlexGrid1.Cols[i].Visible = true; }
                else if (c1FlexGrid1.Cols[i].Caption.Equals("giadl3") == true && objkh.id_capdl.ToLower().Trim().Equals("đại lý cấp 3") == true)
                { c1FlexGrid1[0, i] = "Giá bán"; c1FlexGrid1.Cols[i].Visible = true; }
                else if (c1FlexGrid1.Cols[i].Caption.Equals("giadl4") == true && objkh.id_capdl.ToLower().Trim().Equals("đại lý cấp 4") == true)
                { c1FlexGrid1[0, i] = "Giá bán"; c1FlexGrid1.Cols[i].Visible = true; }
                else if (c1FlexGrid1.Cols[i].Caption.Equals("giadl5") == true && objkh.id_capdl.ToLower().Trim().Equals("đại lý cấp 5") == true)
                { c1FlexGrid1[0, i] = "Giá bán"; c1FlexGrid1.Cols[i].Visible = true; }
                else { c1FlexGrid1.Cols[i].Visible = false; }
                c1FlexGrid1.Cols[i].TextAlignFixed = TextAlignEnum.CenterCenter;
            }
            Font _font = new Font("Time new Roman", 14);
            c1FlexGrid1.Font = _font;
            //for (int j = 1; j < c1FlexGrid1.Rows.Count; j++)
            //{
            //    c1FlexGrid1[j, 0] = j;
            //}
            c1FlexGrid1.Cols[0].TextAlign = TextAlignEnum.CenterCenter;
            c1FlexGrid1.AutoSizeCols();
            c1FlexGrid1.AutoSizeRows();
            txtKeyword.Focus();
        }
        #endregion

        public frmMatHangTra(string sidkh)
        {
            this.sidkh = sidkh;
            InitializeComponent();
        }
        private void frmMatHangTra_Load(object sender, EventArgs e)
        {
            try
            {
                LoadCBTKHangSX();
                cbTKHangSX.Text = ""; cbTKHangSX.SelectedValue = "";
                c1FlexGrid1.KeyActionEnter = KeyActionEnum.MoveAcross;
                c1FlexGrid1.Rows.DefaultSize = 30;
                HienThiDanhSach();
            }
            catch { }
            txtKeyword.Focus();
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
        private void chkAll_CheckedChanged(object sender, EventArgs e)
        {
            if (flagload == false)
            {
                HienThiDanhSach();
            }
        }
        #endregion

        private void c1FlexGrid1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Right) { contextMenuStrip1.Show(c1FlexGrid1, e.X, e.Y); }
        }
        private void tsChon_Click(object sender, EventArgs e)
        {
            if (c1FlexGrid1.Rows.Count - 1 > 0)
            {
                try { sreturn = c1FlexGrid1[c1FlexGrid1.RowSel, "id"].ToString().Trim(); }
                catch { }
            }
            else { sreturn = ""; }
            this.Dispose();
        }
    }
}
