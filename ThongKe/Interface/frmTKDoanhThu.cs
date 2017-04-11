using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ThongKe.Controls;
using HoaDonDataAccess.BusinesLogic;
using QTHT.BusinesLogic;

namespace ThongKe.Interface
{
    public partial class frmTKDoanhThu : Form
    {
        #region Method
        private void LoadCBNhanVien()
        {
            nhanvienBL ctrNhanVien = new nhanvienBL();
            DataTable dt = new DataTable();
            dt = ctrNhanVien.LoadDSCBNV();
            cbNhanVien.DataSource = dt;
            cbNhanVien.DisplayMember = "hoten";
            cbNhanVien.ValueMember = "taikhoan";
        }
        #endregion

        public frmTKDoanhThu()
        {
            InitializeComponent();
        }

        private void btnPath_Click(object sender, EventArgs e)
        {
            SaveFileDialog sodlg = new SaveFileDialog();
            sodlg.Title = "Chọn thư mục lưu báo cáo";
            sodlg.Filter = "Excel 97-2003 (*.xls)|*.xls|Excel 2007 (*.xlsx)|*.xlsx";
            sodlg.FileName = "TKDoanhThu_" + DateTime.Now.ToString("dd-MM-yyyy");
            if (sodlg.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                txtpath.Text = sodlg.FileName.Trim();
            }
        }

        private void frmTKDoanhThu_Load(object sender, EventArgs e)
        {
            LoadCBNhanVien();
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            nhanvienBL ctrNhanVien = new nhanvienBL();
            if (dpkTuNgay.Value.ToString("dd/MM/yyyy").Equals(dpkDenNgay.Value.ToString("dd/MM/yyyy")) == true
                || dpkTuNgay.Value > dpkDenNgay.Value)
            {
                MessageBox.Show("Ngày đầu kỳ thống kê phải nhỏ hơn ngày kết thúc kỳ thống kê.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dpkTuNgay.Focus();
                return;
            }
            Application.DoEvents();
            progressBar1.PerformStep();
            Application.DoEvents();
            DateTime dttungay = dpkTuNgay.Value;
            DateTime dtdenngay = dpkDenNgay.Value;
            tblhoadonbanBL ctrhd = new tblhoadonbanBL();
            DataTable dtnv = new DataTable();
            try
            {
                Application.DoEvents();
                progressBar1.PerformStep();
                Application.DoEvents();
                string sidnv = "-1";
                try { sidnv = cbNhanVien.SelectedValue.ToString().Trim(); }
                catch { }
                if (sidnv.Trim().Equals("-1") == true)
                {
                    try
                    {
                        dtnv = ctrNhanVien.LoadDSCBNV();
                        dtnv.Rows.RemoveAt(0);
                    }
                    catch { }
                }
                else
                {
                    try
                    {
                        object[] obj = { cbNhanVien.SelectedValue.ToString().Trim(), cbNhanVien.Text.Trim() };
                        dtnv.Columns.Add("taikhoan");
                        dtnv.Columns.Add("hoten");
                        dtnv.Rows.Add(obj);
                    }
                    catch { }
                }
                Application.DoEvents();
                progressBar1.PerformStep();
                Application.DoEvents();
            }
            catch { }
            if (dtnv != null)
            {
                TKDoanhThuByIDNV ctr = new TKDoanhThuByIDNV();
                string kq = "";
                kq = ctr.Generate(txtpath.Text, dttungay, dtdenngay, dtnv, progressBar1);
                Application.DoEvents();
                progressBar1.Value = progressBar1.Maximum;
                Application.DoEvents();
                if (kq.Trim().Equals("") == true)
                {
                    MessageBox.Show("Tổng hợp dữ liệu thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Tổng hợp dữ liệu không thành công.\nChi tiết lỗi: " + kq, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                progressBar1.Value = 0;
                Application.DoEvents();
            }
            else
            {
                MessageBox.Show("Lỗi không tổng hợp được dữ liệu.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
