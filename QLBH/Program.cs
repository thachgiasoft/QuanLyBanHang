using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace QLBH
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new frmDangNhap());
            //Application.Run(new frmMain());
            //Application.Run(new HoaDon.Interface.frmMatHangTra("01b7e59e-659c-4223-9de1-050109949fd2"));
            //Application.Run(new Form1());
        }
    }
}
