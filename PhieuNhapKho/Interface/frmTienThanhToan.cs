using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PhieuNhapKho.Interface
{
    public partial class frmTienThanhToan : Form
    {
        private string _sidpn = "";
        public string sidpn { get { return this._sidpn; } set { this._sidpn = value; } }

        public frmTienThanhToan()
        {
            InitializeComponent();
        }

        private void frmTienThanhToan_Load(object sender, EventArgs e)
        {
            ucTienThanhToan1.sidpn = sidpn;
        }
    }
}
