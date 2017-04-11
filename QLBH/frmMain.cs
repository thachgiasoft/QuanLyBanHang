using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using HoaDon.Interface;
using QTHT.Interface;
using CGCN.Configure.Interface;
using DanhMuc.Interface;
using CGCN.DataAccess;
using QTHT.BusinesLogic;
using ThongKe.Interface;
using QTHT.DataAccess;
using PhieuNhapKho.Interface;

namespace QLBH
{
    public partial class frmMain : Form
    {
        public bool isActiveclose = false;
        #region Method
        private bool CheckTabPageExits(string strNameTabPage, ref int iTabIndex)
        {
            bool bKiemTra = false;
            for (int i = 0; i < tabMain.TabPages.Count; i++)
            {
                if (tabMain.TabPages[i].Text == strNameTabPage)
                { iTabIndex = i; bKiemTra = true; break; }

            }
            if (!bKiemTra) iTabIndex = tabMain.TabPages.Count;
            return bKiemTra;
        }
        private void AddTabDefault()
        {
            //Add tab bán hàng
            ucHoaDonBan _ucHoaDonBan = new ucHoaDonBan();
            C1.Win.C1Command.C1DockingTabPage mPageHDB = new C1.Win.C1Command.C1DockingTabPage();
            _ucHoaDonBan.Dock = DockStyle.Fill;
            mPageHDB.Controls.Add(_ucHoaDonBan);
            mPageHDB.Text = "Bán hàng";
            int iTabIndex = 0;
            if (!CheckTabPageExits("Bán hàng", ref iTabIndex)) tabMain.TabPages.Add(mPageHDB);
            //Add tab mặt hàng
            ucMatHang _ucMatHang = new ucMatHang();
            C1.Win.C1Command.C1DockingTabPage mPageMH = new C1.Win.C1Command.C1DockingTabPage();
            _ucMatHang.Dock = DockStyle.Fill;
            mPageMH.Controls.Add(_ucMatHang);
            mPageMH.Text = "Danh mục mặt hàng";
            if (!CheckTabPageExits("Danh mục mặt hàng", ref iTabIndex)) tabMain.TabPages.Add(mPageMH);
            //Add tab khách hàng
            ucKhachHang _ucKhachHang = new ucKhachHang();
            C1.Win.C1Command.C1DockingTabPage mPageKH = new C1.Win.C1Command.C1DockingTabPage();
            _ucKhachHang.Dock = DockStyle.Fill;
            mPageKH.Controls.Add(_ucKhachHang);
            mPageKH.Text = "Khách hàng";
            if (!CheckTabPageExits("Khách hàng", ref iTabIndex)) tabMain.TabPages.Add(mPageKH);
            tabMain.SelectedIndex = 0;
        }
        private void DisableAllMenu()
        {
            #region QTHT
            tsQTHT.Visible = false;
            tsChucVu.Visible = false;
            tsPhongBan.Visible = false;
            tsGroup.Visible = false;
            tsUserOfGroup.Visible = false;
            tsRoleOfUse.Visible = false;
            tsUsers.Visible = false;
            tsLog.Visible = false;
            tsMenu.Visible = false;
            #endregion
            #region Danh mục
            tsDanhMuc.Visible = false;
            tsHangSX.Visible = false;
            tsLoaiMH.Visible = false;
            tsKhachHang.Visible = false;
            tsMatHang.Visible = false;
            #endregion
            #region Hàng hóa
            tsHangHoa.Visible = false;
            tsExport.Visible = false;
            tsImport.Visible = true;
            tsNhapHang.Visible = true;
            #endregion
            #region Báo cáo - Thống kê
            tsReport.Visible = false;
            tsTKDoanhThu.Visible = false;
            tsTKCongNo.Visible = false;
            tsTKCongNoNhap.Visible = false;
            tsMatHangSapHet.Visible = false;
            #endregion
            #region Help
            tsHelp.Visible = false;
            #endregion
        }
        private void DisplayMenu()
        {
            try
            {
                DisableAllMenu();
                quyennguoidungBL ctr = new quyennguoidungBL();
                DataTable dt = new DataTable();
                dt = ctr.GetByIDNhanVien(Data.iduse);
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    #region QTHT
                    if (dt.Rows[i]["kyhieucn"].ToString().Trim().Trim().Equals("tsQTHT") == true)
                    {
                        tsQTHT.Visible = true;
                    }
                    if (dt.Rows[i]["kyhieucn"].ToString().Trim().Trim().Equals("tsChucVu") == true)
                    {
                        tsChucVu.Visible = true;
                    }
                    if (dt.Rows[i]["kyhieucn"].ToString().Trim().Trim().Equals("tsPhongBan") == true)
                    {
                        tsPhongBan.Visible = true;
                    }
                    if (dt.Rows[i]["kyhieucn"].ToString().Trim().Trim().Equals("tsGroup") == true)
                    {
                        tsGroup.Visible = true;
                    }
                    if (dt.Rows[i]["kyhieucn"].ToString().Trim().Trim().Equals("tsUserOfGroup") == true)
                    {
                        tsUserOfGroup.Visible = true;
                    }
                    if (dt.Rows[i]["kyhieucn"].ToString().Trim().Trim().Equals("tsRoleOfUse") == true)
                    {
                        tsRoleOfUse.Visible = true;
                    }
                    if (dt.Rows[i]["kyhieucn"].ToString().Trim().Trim().Equals("tsUsers") == true)
                    {
                        tsUsers.Visible = true;
                    }
                    if (dt.Rows[i]["kyhieucn"].ToString().Trim().Trim().Equals("tsLog") == true)
                    {
                        tsLog.Visible = true;
                    }
                    if (dt.Rows[i]["kyhieucn"].ToString().Trim().Trim().Equals("tsMenu") == true)
                    {
                        tsMenu.Visible = true;
                    }
                    #endregion
                    #region Danh mục
                    if (dt.Rows[i]["kyhieucn"].ToString().Trim().Trim().Equals("tsDanhMuc") == true)
                    {
                        tsDanhMuc.Visible = true;
                    }
                    if (dt.Rows[i]["kyhieucn"].ToString().Trim().Trim().Equals("tsHangSX") == true)
                    {
                        tsHangSX.Visible = true;
                    }
                    if (dt.Rows[i]["kyhieucn"].ToString().Trim().Trim().Equals("tsLoaiMH") == true)
                    {
                        //tsLoaiMH.Visible = true;
                        //tắt vì yêu cầu
                        tsLoaiMH.Visible = false;
                    }
                    if (dt.Rows[i]["kyhieucn"].ToString().Trim().Trim().Equals("tsKhachHang") == true)
                    {
                        tsKhachHang.Visible = true;
                    }
                    if (dt.Rows[i]["kyhieucn"].ToString().Trim().Trim().Equals("tsMatHang") == true)
                    {
                        tsMatHang.Visible = true;
                    }
                    #endregion
                    #region Hàng hóa
                    if (dt.Rows[i]["kyhieucn"].ToString().Trim().Trim().Equals("tsHangHoa") == true)
                    {
                        tsHangHoa.Visible = true;
                    }
                    if (dt.Rows[i]["kyhieucn"].ToString().Trim().Trim().Equals("tsExport") == true)
                    {
                        tsExport.Visible = true;
                    }
                    if (dt.Rows[i]["kyhieucn"].ToString().Trim().Trim().Equals("tsImport") == true)
                    {
                        tsImport.Visible = true;
                    }
                    if (dt.Rows[i]["kyhieucn"].ToString().Trim().Trim().Equals("tsNhapHang") == true)
                    {
                        tsNhapHang.Visible = true;
                    }
                    
                    #endregion
                    #region Báo cáo - Thống kê
                    if (dt.Rows[i]["kyhieucn"].ToString().Trim().Trim().Equals("tsReport") == true)
                    {
                        tsReport.Visible = true;
                    }
                    if (dt.Rows[i]["kyhieucn"].ToString().Trim().Trim().Equals("tsTKDoanhThu") == true)
                    {
                        tsTKDoanhThu.Visible = true;
                    }
                    if (dt.Rows[i]["kyhieucn"].ToString().Trim().Trim().Equals("tsTKCongNo") == true)
                    {
                        tsTKCongNo.Visible = true;
                    }
                    if (dt.Rows[i]["kyhieucn"].ToString().Trim().Trim().Equals("tsTKCongNoNhap") == true)
                    {
                        tsTKCongNoNhap.Visible = true;
                    }
                    if (dt.Rows[i]["kyhieucn"].ToString().Trim().Trim().Equals("tsMatHangSapHet") == true)
                    {
                        tsMatHangSapHet.Visible = true;
                    }
                    #endregion
                    #region Help
                    if (dt.Rows[i]["kyhieucn"].ToString().Trim().Trim().Equals("tsHelp") == true)
                    {
                        tsHelp.Visible = true;
                    }
                    #endregion
                }
            }
            catch { }
        }
        #endregion

        public frmMain()
        {
            InitializeComponent();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            DisplayMenu();
            AddTabDefault();
            nhanvienBL ctrnv = new nhanvienBL();
            nhanvien objnv = new nhanvien();
            objnv = ctrnv.GetByID(Data.iduse.Trim());
            if (objnv != null) { tslbUser.Text = "Người dùng: " + Data.use.Trim() + "(" + objnv.hoten.Trim() + ")"; }
            else { tslbUser.Text = "Người dùng: " + Data.use.Trim(); }
            tslbPointTime.Text = "Đăng nhập lúc: " + DateTime.Now.ToString("HH:mm:ss - dd/MM/yyyy");
        }

        #region Menu chung
        private void tsChangePass_Click(object sender, EventArgs e)
        {
            frmChangePass frm = new frmChangePass();
            frm.ShowDialog();
        }
        private void tsConfigure_Click(object sender, EventArgs e)
        {
            frmConfigure frm = new frmConfigure();
            frm.ShowDialog();
        }
        private void tsPause_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void tsExit_Click(object sender, EventArgs e)
        {
            isActiveclose = true;
            this.Dispose();
        }
        #endregion

        #region Menu Quản trị hệ thống
        private void tsChucVu_Click(object sender, EventArgs e)
        {
            ucChucVu _uc = new ucChucVu();
            C1.Win.C1Command.C1DockingTabPage mPage = new C1.Win.C1Command.C1DockingTabPage();
            _uc.Dock = DockStyle.Fill;
            mPage.Controls.Add(_uc);
            mPage.Text = "Danh mục chức vụ";
            mPage.ToolTipText = "Quản lý danh mục chức vụ";
            int iTabIndex = 0;
            if (!CheckTabPageExits("Danh mục chức vụ", ref iTabIndex)) tabMain.TabPages.Add(mPage);
            tabMain.SelectedIndex = iTabIndex;
            _uc.Focus();
        }
        private void tsPhongBan_Click(object sender, EventArgs e)
        {
            ucPhongBan _uc = new ucPhongBan();
            C1.Win.C1Command.C1DockingTabPage mPage = new C1.Win.C1Command.C1DockingTabPage();
            _uc.Dock = DockStyle.Fill;
            mPage.Controls.Add(_uc);
            mPage.Text = "Danh mục phòng ban";
            mPage.ToolTipText = "Quản lý danh mục phòng ban";
            int iTabIndex = 0;
            if (!CheckTabPageExits("Danh mục phòng ban", ref iTabIndex)) tabMain.TabPages.Add(mPage);
            tabMain.SelectedIndex = iTabIndex;
            _uc.Focus();
        }
        private void tsGroup_Click(object sender, EventArgs e)
        {
            frmNhomNguoiDung frm = new frmNhomNguoiDung();
            frm.ShowDialog();
        }
        private void tsUserOfGroup_Click(object sender, EventArgs e)
        {
            frmNguoiDungOfNhom frm = new frmNguoiDungOfNhom();
            frm.ShowDialog();
        }
        private void tsRoleOfUse_Click(object sender, EventArgs e)
        {
            frmPhanQuyenNguoiDung frm = new frmPhanQuyenNguoiDung();
            frm.ShowDialog();
        }
        private void tsUsers_Click(object sender, EventArgs e)
        {
            frmManagerUser frm = new frmManagerUser();
            frm.ShowDialog();
        }
        private void tsLog_Click(object sender, EventArgs e)
        {
            ucLog _uc = new ucLog();
            C1.Win.C1Command.C1DockingTabPage mPage = new C1.Win.C1Command.C1DockingTabPage();
            _uc.Dock = DockStyle.Fill;
            mPage.Controls.Add(_uc);
            mPage.Text = "Nhật ký hệ thống";
            mPage.ToolTipText = "Quản lý nhật ký hệ thống";
            int iTabIndex = 0;
            if (!CheckTabPageExits("Nhật ký hệ thống", ref iTabIndex)) tabMain.TabPages.Add(mPage);
            tabMain.SelectedIndex = iTabIndex;
            _uc.Focus();
        }
        private void tsMenu_Click(object sender, EventArgs e)
        {
            frmChucNang frm = new frmChucNang();
            frm.ShowDialog();
        }
        #endregion

        #region Menu Danh mục
        private void tsHangSX_Click(object sender, EventArgs e)
        {
            ucHangSX _uc = new ucHangSX();
            C1.Win.C1Command.C1DockingTabPage mPage = new C1.Win.C1Command.C1DockingTabPage();
            _uc.Dock = DockStyle.Fill;
            mPage.Controls.Add(_uc);
            mPage.Text = "Danh mục hãng sản xuất";
            mPage.ToolTipText = "Cập nhật danh mục hàng sản xuất";
            int iTabIndex = 0;
            if (!CheckTabPageExits("Danh mục hãng sản xuất", ref iTabIndex)) tabMain.TabPages.Add(mPage);
            tabMain.SelectedIndex = iTabIndex;
            _uc.Focus();
        }
        private void tsLoaiMH_Click(object sender, EventArgs e)
        {
            ucLoaiMatHang _uc = new ucLoaiMatHang();
            C1.Win.C1Command.C1DockingTabPage mPage = new C1.Win.C1Command.C1DockingTabPage();
            _uc.Dock = DockStyle.Fill;
            mPage.Controls.Add(_uc);
            mPage.Text = "Danh mục loại mặt hàng";
            mPage.ToolTipText = "Cập nhật danh mục loại mặt hàng";
            int iTabIndex = 0;
            if (!CheckTabPageExits("Danh mục loại mặt hàng", ref iTabIndex)) tabMain.TabPages.Add(mPage);
            tabMain.SelectedIndex = iTabIndex;
            _uc.Focus();
        }
        private void tsKhachHang_Click(object sender, EventArgs e)
        {
            ucKhachHang _uc = new ucKhachHang();
            C1.Win.C1Command.C1DockingTabPage mPage = new C1.Win.C1Command.C1DockingTabPage();
            _uc.Dock = DockStyle.Fill;
            mPage.Controls.Add(_uc);
            mPage.Text = "Khách hàng";
            mPage.ToolTipText = "Quản lý danh mục khách hàng";
            int iTabIndex = 0;
            if (!CheckTabPageExits("Khách hàng", ref iTabIndex)) tabMain.TabPages.Add(mPage);
            tabMain.SelectedIndex = iTabIndex;
            _uc.Focus();
        }
        private void tsMatHang_Click(object sender, EventArgs e)
        {
            ucMatHang _uc = new ucMatHang();
            C1.Win.C1Command.C1DockingTabPage mPage = new C1.Win.C1Command.C1DockingTabPage();
            _uc.Dock = DockStyle.Fill;
            mPage.Controls.Add(_uc);
            mPage.Text = "Danh mục mặt hàng";
            mPage.ToolTipText = "Quản lý danh mục mặt hàng";
            int iTabIndex = 0;
            if (!CheckTabPageExits("Danh mục mặt hàng", ref iTabIndex)) tabMain.TabPages.Add(mPage);
            tabMain.SelectedIndex = iTabIndex;
            _uc.Focus();
        }
        private void tsNhaCungCap_Click(object sender, EventArgs e)
        {
            ucNhaCungCap _uc = new ucNhaCungCap();
            C1.Win.C1Command.C1DockingTabPage mPage = new C1.Win.C1Command.C1DockingTabPage();
            _uc.Dock = DockStyle.Fill;
            mPage.Controls.Add(_uc);
            mPage.Text = "Danh mục nhà cung cấp";
            mPage.ToolTipText = "Quản lý danh mục nhà cung cấp";
            int iTabIndex = 0;
            if (!CheckTabPageExits("Danh mục nhà cung cấp", ref iTabIndex)) tabMain.TabPages.Add(mPage);
            tabMain.SelectedIndex = iTabIndex;
            _uc.Focus();
        }
        #endregion

        #region Hàng hóa
        private void tsExport_Click(object sender, EventArgs e)
        {
            ucHoaDonBan _uc = new ucHoaDonBan();
            C1.Win.C1Command.C1DockingTabPage mPage = new C1.Win.C1Command.C1DockingTabPage();
            _uc.Dock = DockStyle.Fill;
            mPage.Controls.Add(_uc);
            mPage.Text = "Bán hàng";
            mPage.ToolTipText = "Quản lý hóa đơn bán";
            int iTabIndex = 0;
            if (!CheckTabPageExits("Bán hàng", ref iTabIndex)) tabMain.TabPages.Add(mPage);
            tabMain.SelectedIndex = iTabIndex;
            _uc.Focus();
        }
        private void tsImport_Click(object sender, EventArgs e)
        {
            ucHoaDonTra _uc = new ucHoaDonTra();
            C1.Win.C1Command.C1DockingTabPage mPage = new C1.Win.C1Command.C1DockingTabPage();
            _uc.Dock = DockStyle.Fill;
            mPage.Controls.Add(_uc);
            mPage.Text = "Trả hàng";
            mPage.ToolTipText = "Quản lý hóa đơn trả lại hàng";
            int iTabIndex = 0;
            if (!CheckTabPageExits("Trả hàng", ref iTabIndex)) tabMain.TabPages.Add(mPage);
            tabMain.SelectedIndex = iTabIndex;
            _uc.Focus();
        }
        private void tsNhapHang_Click(object sender, EventArgs e)
        {
            ucPhieuNhapKho _uc = new ucPhieuNhapKho();
            C1.Win.C1Command.C1DockingTabPage mPage = new C1.Win.C1Command.C1DockingTabPage();
            _uc.Dock = DockStyle.Fill;
            mPage.Controls.Add(_uc);
            mPage.Text = "Nhập hàng";
            mPage.ToolTipText = "Quản lý phiếu nhập hàng";
            int iTabIndex = 0;
            if (!CheckTabPageExits("Nhập hàng", ref iTabIndex)) tabMain.TabPages.Add(mPage);
            tabMain.SelectedIndex = iTabIndex;
            _uc.Focus();
        }
        #endregion

        #region Thống kê - Báo cáo
        private void tsTKDoanhThu_Click(object sender, EventArgs e)
        {
            frmTKDoanhThu frm = new frmTKDoanhThu();
            frm.ShowDialog();
        }
        private void tsTKCongNo_Click(object sender, EventArgs e)
        {
            frmTKCongNo frm = new frmTKCongNo();
            frm.ShowDialog();
        }
        private void tsTKCongNoNhap_Click(object sender, EventArgs e)
        {
            frmTKCongNoNhap frm = new frmTKCongNoNhap();
            frm.ShowDialog();
        }
        private void tsMatHangSapHet_Click(object sender, EventArgs e)
        {
            ucTKMatHangSapHet _uc = new ucTKMatHangSapHet();
            C1.Win.C1Command.C1DockingTabPage mPage = new C1.Win.C1Command.C1DockingTabPage();
            _uc.Dock = DockStyle.Fill;
            mPage.Controls.Add(_uc);
            mPage.Text = "TK mặt hàng sắp hết";
            mPage.ToolTipText = "Thống kê mặt hàng sắp hết trong kho";
            int iTabIndex = 0;
            if (!CheckTabPageExits("TK mặt hàng sắp hết", ref iTabIndex)) tabMain.TabPages.Add(mPage);
            tabMain.SelectedIndex = iTabIndex;
            _uc.Focus();
        }
        #endregion
    }
}
