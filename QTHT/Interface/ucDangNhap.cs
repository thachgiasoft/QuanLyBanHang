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

namespace QTHT.Interface
{
    public partial class ucDangNhap : UserControl
    {
        private InputValidation.Validation _validation = new InputValidation.Validation();
        public bool success = false;
        #region Method
        private void DangNhap()
        {
            if (txtAccount.Text.Trim().Equals("") == true) {
                MessageBox.Show("Tài khoản không được để trắng.","Thông báo",MessageBoxButtons.OK,MessageBoxIcon.Warning);
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
                Data.use = txtAccount.Text.Trim();
                success = true;
            }
            else
            {
                MessageBox.Show("Đăng nhập không thành công.\nVui lòng kiểm tra lại tài khoản và mật khẩu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtAccount.Focus();
                return;
            }
        }
        #endregion
        public ucDangNhap()
        {
            InitializeComponent();
        }
    }
}
