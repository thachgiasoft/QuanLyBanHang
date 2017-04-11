using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace HoaDon.Interface
{
    public partial class frmTienThanhToan : Form
    {
        private string _sidhd = "";
        public string sidhd { get { return this._sidhd; } set { this._sidhd = value; } }

        public frmTienThanhToan()
        {
            InitializeComponent();
        }

        private void frmTienThanhToan_Load(object sender, EventArgs e)
        {
            ucTienThanhToan1.sidhd = sidhd;
        }
    }
}
