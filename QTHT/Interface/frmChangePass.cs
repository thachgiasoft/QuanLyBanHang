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
    public partial class frmChangePass : Form
    {
        private logBL _ctrlog = new logBL();
        private InputValidation.Validation _validation = new InputValidation.Validation();

        #region Method
        private void ChangePass()
        {
            string loi = "";
            string sidnhanvien = "";
            try { sidnhanvien = Data.iduse; }
            catch { }
            nhanvien _obj = new nhanvien();
            nhanvienBL _ctr = new nhanvienBL();
            _obj = _ctr.GetByID(sidnhanvien);
            string soldpass = "";
            soldpass = _validation.EncryptPassword(_obj.taikhoan.Trim(), txtOldPass.Text.Trim());
            if (soldpass.Trim().Equals(_obj.matkhau) == false)
            {
                MessageBox.Show("Mật khẩu cũ không đúng.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtOldPass.Focus();
                return;
            }
            if (txtNewPass.Text.Trim().Equals(txtReNewPass.Text.Trim()) == false)
            {
                MessageBox.Show("Mật nhắc lại không đúng.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNewPass.Focus();
                return;
            }
            string snewpass = "";
            snewpass = _validation.EncryptPassword(_obj.taikhoan.Trim(), txtNewPass.Text.Trim());
            if (_obj != null)
            {
                _obj.matkhau = snewpass;
                loi = _ctr.ChangePass(sidnhanvien, snewpass);
                if (loi.Trim().Equals("") == true)
                {
                    _ctrlog.Append(Data.use, "Đổi mật khẩu người dùng: " + _obj.taikhoan.Trim() + "(" + _obj.hoten + ")");
                    MessageBox.Show("Đổi mật khẩu người dùng thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show(loi, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
        }
        #endregion

        public frmChangePass()
        {
            InitializeComponent();
        }

        private void btnChangePass_Click(object sender, EventArgs e)
        {
            ChangePass();
        }
    }
}
