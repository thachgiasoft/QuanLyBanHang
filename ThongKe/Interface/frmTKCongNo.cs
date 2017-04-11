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
using DanhMuc.BusinesLogic;

namespace ThongKe.Interface
{
    public partial class frmTKCongNo : Form
    {
        public frmTKCongNo()
        {
            InitializeComponent();
        }

        private void btnPath_Click(object sender, EventArgs e)
        {
            SaveFileDialog sodlg = new SaveFileDialog();
            sodlg.Title = "Chọn thư mục lưu báo cáo";
            sodlg.Filter = "Excel 97-2003 (*.xls)|*.xls|Excel 2007 (*.xlsx)|*.xlsx";
            sodlg.FileName = "TKCongNoBanHang_" + DateTime.Now.ToString("dd-MM-yyyy");
            if (sodlg.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                txtpath.Text = sodlg.FileName.Trim();
            }
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            Application.DoEvents();
            progressBar1.PerformStep();
            Application.DoEvents();
            DateTime dtdenngay = dpkDenNgay.Value;
            tblkhachhangBL ctrkh = new tblkhachhangBL();
            DataTable dtkh = new DataTable();
            try
            {
                Application.DoEvents();
                progressBar1.PerformStep();
                Application.DoEvents();
                dtkh = ctrkh.GetByHoaDonBan();
                Application.DoEvents();
                progressBar1.PerformStep();
                Application.DoEvents();
                if (dtkh != null)
                {
                    TKCongNo ctr = new TKCongNo();
                    string kq = "";
                    kq = ctr.Generate(txtpath.Text, dtdenngay, dtkh, progressBar1);
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
                    progressBar1.Value = 0;
                    Application.DoEvents();
                }
            }
            catch(Exception ex) {
                MessageBox.Show("Lỗi không tổng hợp được dữ liệu.\nChi tiết lỗi: " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                progressBar1.Value = 0;
                Application.DoEvents();
            }
        }

        private void frmTKCongNo_Load(object sender, EventArgs e)
        {
            dpkDenNgay.Value = DateTime.Now;
        }
    }
}
