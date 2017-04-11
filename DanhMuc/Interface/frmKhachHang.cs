using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DanhMuc.Interface
{
    public partial class frmKhachHang : Form
    {
        private int _type = 0;//0:Không hiển thị tschon; 1:Hiển thị tschon
        public int type { get { return _type; } set { this._type = value; } }
        public string sreturn = "";

        public void Getresult()
        {
            sreturn = ucKhachHang1.sreturn;
        }

        public frmKhachHang()
        {
            InitializeComponent();
        }

        private void frmKhachHang_Load(object sender, EventArgs e)
        {
            ucKhachHang1.type = type;
        }
    }
}
