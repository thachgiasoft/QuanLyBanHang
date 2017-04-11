using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using QTHT.BusinesLogic;
using CGCN.DataAccess;
using CGCN.Configure.Interface;

namespace QLBH
{
    public partial class frmDangNhap : Form
    {
        private logBL _ctrlog = new logBL();
        private InputValidation.Validation _validation = new InputValidation.Validation();

        #region Method
        private void DangNhap()
        {
            if (txtAccount.Text.Trim().Equals("") == true)
            {
                MessageBox.Show("Tài khoản không được để trắng.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtAccount.Focus();
                return;
            }
            if (txtPass.Text.Trim().Equals("") == true)
            {
                MessageBox.Show("Mật khẩu không được để trắng.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPass.Focus();
                return;
            }
            string shashPass = "";
            shashPass = _validation.EncryptPassword(txtAccount.Text.Trim(), txtPass.Text.Trim());
            nhanvienBL ctr = new nhanvienBL();
            if (ctr.DangNhap(txtAccount.Text.Trim(), shashPass) == true)
            {
                try
                {
                    Data.iduse = ctr.GetIDNhanVienByAccount(txtAccount.Text.Trim());
                    Data.use = txtAccount.Text.Trim();
                    this.Hide();
                    _ctrlog.Append(Data.use, "Đăng nhập hệ thống.");
                    frmMain frm = new frmMain();
                    frm.ShowDialog();
                    if (frm.isActiveclose == false)
                    {
                        this.Show();
                    }
                    else { this.Dispose(); }
                }
                catch (Exception e) { this.Dispose(); }
            }
            else
            {
                MessageBox.Show("Đăng nhập không thành công.\nVui lòng kiểm tra lại tài khoản và mật khẩu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtAccount.Focus();
                return;
            }
        }
        #endregion
        public frmDangNhap()
        {
            InitializeComponent();
        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            DangNhap();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btnConfig_Click(object sender, EventArgs e)
        {
            frmConfigure frm = new frmConfigure();
            frm.ShowDialog();
        }

        private void frmDangNhap_Load(object sender, EventArgs e)
        {
            txtAccount.Focus();
        }

        private void txtPass_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnDangNhap_Click(sender, e);
            }
        }
    }
}
