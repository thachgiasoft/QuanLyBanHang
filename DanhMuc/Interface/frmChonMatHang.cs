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
    public partial class frmChonMatHang : Form
    {
        private int _type = 0;//0:Không hiển thị tschon; 1:Hiển thị tschon
        public int type { get { return _type; } set { this._type = value; } }
        public string sreturn = "";

        public frmChonMatHang()
        {
            InitializeComponent();
        }

        public void Getresult()
        {
            sreturn = ucMatHang1.sreturn;
        }

        private void frmChonMatHang_Load(object sender, EventArgs e)
        {
            ucMatHang1.type = type;
        }
    }
}
