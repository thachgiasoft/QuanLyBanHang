namespace QLBH
{
    partial class frmMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.tsMenuGeneral = new System.Windows.Forms.ToolStripMenuItem();
            this.tsChangePass = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsConfigure = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.tsPause = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripSeparator();
            this.tsExit = new System.Windows.Forms.ToolStripMenuItem();
            this.tsQTHT = new System.Windows.Forms.ToolStripMenuItem();
            this.tsChucVu = new System.Windows.Forms.ToolStripMenuItem();
            this.tsPhongBan = new System.Windows.Forms.ToolStripMenuItem();
            this.tsGroup = new System.Windows.Forms.ToolStripMenuItem();
            this.tsUserOfGroup = new System.Windows.Forms.ToolStripMenuItem();
            this.tsRoleOfUse = new System.Windows.Forms.ToolStripMenuItem();
            this.tsUsers = new System.Windows.Forms.ToolStripMenuItem();
            this.tsLog = new System.Windows.Forms.ToolStripMenuItem();
            this.tsMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.tsDanhMuc = new System.Windows.Forms.ToolStripMenuItem();
            this.tsHangSX = new System.Windows.Forms.ToolStripMenuItem();
            this.tsLoaiMH = new System.Windows.Forms.ToolStripMenuItem();
            this.tsKhachHang = new System.Windows.Forms.ToolStripMenuItem();
            this.tsMatHang = new System.Windows.Forms.ToolStripMenuItem();
            this.tsNhaCungCap = new System.Windows.Forms.ToolStripMenuItem();
            this.tsHangHoa = new System.Windows.Forms.ToolStripMenuItem();
            this.tsExport = new System.Windows.Forms.ToolStripMenuItem();
            this.tsImport = new System.Windows.Forms.ToolStripMenuItem();
            this.tsNhapHang = new System.Windows.Forms.ToolStripMenuItem();
            this.tsReport = new System.Windows.Forms.ToolStripMenuItem();
            this.tsTKDoanhThu = new System.Windows.Forms.ToolStripMenuItem();
            this.tsTKCongNo = new System.Windows.Forms.ToolStripMenuItem();
            this.tsMatHangSapHet = new System.Windows.Forms.ToolStripMenuItem();
            this.tsTKCongNoNhap = new System.Windows.Forms.ToolStripMenuItem();
            this.tsHelp = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.tslbUser = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.tslbPointTime = new System.Windows.Forms.ToolStripStatusLabel();
            this.tabMain = new C1.Win.C1Command.C1DockingTab();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.menuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tabMain)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsMenuGeneral,
            this.tsQTHT,
            this.tsDanhMuc,
            this.tsHangHoa,
            this.tsReport,
            this.tsHelp});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(714, 24);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // tsMenuGeneral
            // 
            this.tsMenuGeneral.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsChangePass,
            this.toolStripMenuItem1,
            this.tsConfigure,
            this.toolStripMenuItem2,
            this.tsPause,
            this.toolStripMenuItem3,
            this.tsExit});
            this.tsMenuGeneral.Image = global::QLBH.Properties.Resources.settings;
            this.tsMenuGeneral.Name = "tsMenuGeneral";
            this.tsMenuGeneral.Size = new System.Drawing.Size(28, 20);
            // 
            // tsChangePass
            // 
            this.tsChangePass.Name = "tsChangePass";
            this.tsChangePass.Size = new System.Drawing.Size(161, 22);
            this.tsChangePass.Text = "Đổi mật khẩu";
            this.tsChangePass.Click += new System.EventHandler(this.tsChangePass_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(158, 6);
            // 
            // tsConfigure
            // 
            this.tsConfigure.Name = "tsConfigure";
            this.tsConfigure.Size = new System.Drawing.Size(161, 22);
            this.tsConfigure.Text = "Cấu hình kết nối";
            this.tsConfigure.Click += new System.EventHandler(this.tsConfigure_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(158, 6);
            // 
            // tsPause
            // 
            this.tsPause.Name = "tsPause";
            this.tsPause.Size = new System.Drawing.Size(161, 22);
            this.tsPause.Text = "Tạm dừng";
            this.tsPause.Click += new System.EventHandler(this.tsPause_Click);
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(158, 6);
            // 
            // tsExit
            // 
            this.tsExit.Name = "tsExit";
            this.tsExit.Size = new System.Drawing.Size(161, 22);
            this.tsExit.Text = "Thoát";
            this.tsExit.Click += new System.EventHandler(this.tsExit_Click);
            // 
            // tsQTHT
            // 
            this.tsQTHT.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsChucVu,
            this.tsPhongBan,
            this.tsGroup,
            this.tsUserOfGroup,
            this.tsRoleOfUse,
            this.tsUsers,
            this.tsLog,
            this.tsMenu});
            this.tsQTHT.Name = "tsQTHT";
            this.tsQTHT.Size = new System.Drawing.Size(113, 20);
            this.tsQTHT.Text = "Quản trị hệ thống";
            // 
            // tsChucVu
            // 
            this.tsChucVu.Name = "tsChucVu";
            this.tsChucVu.Size = new System.Drawing.Size(207, 22);
            this.tsChucVu.Text = "Chức vụ";
            this.tsChucVu.Click += new System.EventHandler(this.tsChucVu_Click);
            // 
            // tsPhongBan
            // 
            this.tsPhongBan.Name = "tsPhongBan";
            this.tsPhongBan.Size = new System.Drawing.Size(207, 22);
            this.tsPhongBan.Text = "Phòng ban";
            this.tsPhongBan.Click += new System.EventHandler(this.tsPhongBan_Click);
            // 
            // tsGroup
            // 
            this.tsGroup.Name = "tsGroup";
            this.tsGroup.Size = new System.Drawing.Size(207, 22);
            this.tsGroup.Text = "Nhóm người dùng";
            this.tsGroup.Click += new System.EventHandler(this.tsGroup_Click);
            // 
            // tsUserOfGroup
            // 
            this.tsUserOfGroup.Name = "tsUserOfGroup";
            this.tsUserOfGroup.Size = new System.Drawing.Size(207, 22);
            this.tsUserOfGroup.Text = "Người dùng thuộc nhóm";
            this.tsUserOfGroup.Click += new System.EventHandler(this.tsUserOfGroup_Click);
            // 
            // tsRoleOfUse
            // 
            this.tsRoleOfUse.Name = "tsRoleOfUse";
            this.tsRoleOfUse.Size = new System.Drawing.Size(207, 22);
            this.tsRoleOfUse.Text = "Phân quyền người dùng";
            this.tsRoleOfUse.Click += new System.EventHandler(this.tsRoleOfUse_Click);
            // 
            // tsUsers
            // 
            this.tsUsers.Name = "tsUsers";
            this.tsUsers.Size = new System.Drawing.Size(207, 22);
            this.tsUsers.Text = "Quản trị người dùng";
            this.tsUsers.Click += new System.EventHandler(this.tsUsers_Click);
            // 
            // tsLog
            // 
            this.tsLog.Name = "tsLog";
            this.tsLog.Size = new System.Drawing.Size(207, 22);
            this.tsLog.Text = "Nhật ký hệ thống";
            this.tsLog.Click += new System.EventHandler(this.tsLog_Click);
            // 
            // tsMenu
            // 
            this.tsMenu.Name = "tsMenu";
            this.tsMenu.Size = new System.Drawing.Size(207, 22);
            this.tsMenu.Text = "Danh mục chức năng";
            this.tsMenu.Click += new System.EventHandler(this.tsMenu_Click);
            // 
            // tsDanhMuc
            // 
            this.tsDanhMuc.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsHangSX,
            this.tsLoaiMH,
            this.tsKhachHang,
            this.tsMatHang,
            this.tsNhaCungCap});
            this.tsDanhMuc.Name = "tsDanhMuc";
            this.tsDanhMuc.Size = new System.Drawing.Size(74, 20);
            this.tsDanhMuc.Text = "Danh mục";
            // 
            // tsHangSX
            // 
            this.tsHangSX.Name = "tsHangSX";
            this.tsHangSX.Size = new System.Drawing.Size(150, 22);
            this.tsHangSX.Text = "Hãng sản xuất";
            this.tsHangSX.Click += new System.EventHandler(this.tsHangSX_Click);
            // 
            // tsLoaiMH
            // 
            this.tsLoaiMH.Name = "tsLoaiMH";
            this.tsLoaiMH.Size = new System.Drawing.Size(150, 22);
            this.tsLoaiMH.Text = "Loại mặt hàng";
            this.tsLoaiMH.Click += new System.EventHandler(this.tsLoaiMH_Click);
            // 
            // tsKhachHang
            // 
            this.tsKhachHang.Name = "tsKhachHang";
            this.tsKhachHang.Size = new System.Drawing.Size(150, 22);
            this.tsKhachHang.Text = "Khách hàng";
            this.tsKhachHang.Click += new System.EventHandler(this.tsKhachHang_Click);
            // 
            // tsMatHang
            // 
            this.tsMatHang.Name = "tsMatHang";
            this.tsMatHang.Size = new System.Drawing.Size(150, 22);
            this.tsMatHang.Text = "Mặt hàng";
            this.tsMatHang.Click += new System.EventHandler(this.tsMatHang_Click);
            // 
            // tsNhaCungCap
            // 
            this.tsNhaCungCap.Name = "tsNhaCungCap";
            this.tsNhaCungCap.Size = new System.Drawing.Size(150, 22);
            this.tsNhaCungCap.Text = "Nhà cung cấp";
            this.tsNhaCungCap.Click += new System.EventHandler(this.tsNhaCungCap_Click);
            // 
            // tsHangHoa
            // 
            this.tsHangHoa.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsExport,
            this.tsImport,
            this.tsNhapHang});
            this.tsHangHoa.Name = "tsHangHoa";
            this.tsHangHoa.Size = new System.Drawing.Size(71, 20);
            this.tsHangHoa.Text = "Hàng hóa";
            // 
            // tsExport
            // 
            this.tsExport.Name = "tsExport";
            this.tsExport.Size = new System.Drawing.Size(133, 22);
            this.tsExport.Text = "Bán hàng";
            this.tsExport.Click += new System.EventHandler(this.tsExport_Click);
            // 
            // tsImport
            // 
            this.tsImport.Name = "tsImport";
            this.tsImport.Size = new System.Drawing.Size(133, 22);
            this.tsImport.Text = "Trả hàng";
            this.tsImport.Click += new System.EventHandler(this.tsImport_Click);
            // 
            // tsNhapHang
            // 
            this.tsNhapHang.Name = "tsNhapHang";
            this.tsNhapHang.Size = new System.Drawing.Size(133, 22);
            this.tsNhapHang.Text = "Nhập hàng";
            this.tsNhapHang.Click += new System.EventHandler(this.tsNhapHang_Click);
            // 
            // tsReport
            // 
            this.tsReport.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsTKDoanhThu,
            this.tsTKCongNo,
            this.tsTKCongNoNhap,
            this.tsMatHangSapHet});
            this.tsReport.Name = "tsReport";
            this.tsReport.Size = new System.Drawing.Size(122, 20);
            this.tsReport.Text = "Báo cáo - Thống kê";
            // 
            // tsTKDoanhThu
            // 
            this.tsTKDoanhThu.Name = "tsTKDoanhThu";
            this.tsTKDoanhThu.Size = new System.Drawing.Size(219, 22);
            this.tsTKDoanhThu.Text = "Tổng hợp doanh thu";
            this.tsTKDoanhThu.Click += new System.EventHandler(this.tsTKDoanhThu_Click);
            // 
            // tsTKCongNo
            // 
            this.tsTKCongNo.Name = "tsTKCongNo";
            this.tsTKCongNo.Size = new System.Drawing.Size(219, 22);
            this.tsTKCongNo.Text = "Tổng hợp công nợ (Bán)";
            this.tsTKCongNo.Click += new System.EventHandler(this.tsTKCongNo_Click);
            // 
            // tsMatHangSapHet
            // 
            this.tsMatHangSapHet.Name = "tsMatHangSapHet";
            this.tsMatHangSapHet.Size = new System.Drawing.Size(219, 22);
            this.tsMatHangSapHet.Text = "Thống kê mặt hàng sắp hết";
            this.tsMatHangSapHet.Click += new System.EventHandler(this.tsMatHangSapHet_Click);
            // 
            // tsTKCongNoNhap
            // 
            this.tsTKCongNoNhap.Name = "tsTKCongNoNhap";
            this.tsTKCongNoNhap.Size = new System.Drawing.Size(219, 22);
            this.tsTKCongNoNhap.Text = "Tổng hợp công nợ (Nhập)";
            this.tsTKCongNoNhap.Click += new System.EventHandler(this.tsTKCongNoNhap_Click);
            // 
            // tsHelp
            // 
            this.tsHelp.Name = "tsHelp";
            this.tsHelp.Size = new System.Drawing.Size(64, 20);
            this.tsHelp.Text = "Trợ giúp";
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tslbUser,
            this.toolStripStatusLabel2,
            this.tslbPointTime});
            this.statusStrip1.Location = new System.Drawing.Point(0, 377);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(714, 22);
            this.statusStrip1.TabIndex = 3;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // tslbUser
            // 
            this.tslbUser.ForeColor = System.Drawing.Color.Red;
            this.tslbUser.Name = "tslbUser";
            this.tslbUser.Size = new System.Drawing.Size(16, 17);
            this.tslbUser.Text = "...";
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(10, 17);
            this.toolStripStatusLabel2.Text = "|";
            // 
            // tslbPointTime
            // 
            this.tslbPointTime.ForeColor = System.Drawing.Color.Blue;
            this.tslbPointTime.Name = "tslbPointTime";
            this.tslbPointTime.Size = new System.Drawing.Size(16, 17);
            this.tslbPointTime.Text = "...";
            // 
            // tabMain
            // 
            this.tabMain.CanCloseTabs = true;
            this.tabMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabMain.Location = new System.Drawing.Point(0, 24);
            this.tabMain.Name = "tabMain";
            this.tabMain.Size = new System.Drawing.Size(714, 353);
            this.tabMain.TabIndex = 4;
            this.tabMain.TabsSpacing = 5;
            this.tabMain.TabStyle = C1.Win.C1Command.TabStyleEnum.Office2007;
            this.tabMain.UIStrings.Content = new string[] {
        "DockingTabCloseTooltip:Đóng"};
            this.tabMain.VisualStyle = C1.Win.C1Command.VisualStyle.Office2007Blue;
            this.tabMain.VisualStyleBase = C1.Win.C1Command.VisualStyle.Office2007Blue;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(714, 399);
            this.Controls.Add(this.tabMain);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Phần mềm quản lý bán hàng v1.0.0";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tabMain)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem tsQTHT;
        private System.Windows.Forms.ToolStripMenuItem tsChucVu;
        private System.Windows.Forms.ToolStripMenuItem tsPhongBan;
        private System.Windows.Forms.ToolStripMenuItem tsGroup;
        private System.Windows.Forms.ToolStripMenuItem tsUserOfGroup;
        private System.Windows.Forms.ToolStripMenuItem tsRoleOfUse;
        private System.Windows.Forms.ToolStripMenuItem tsUsers;
        private System.Windows.Forms.ToolStripMenuItem tsDanhMuc;
        private System.Windows.Forms.ToolStripMenuItem tsHangHoa;
        private System.Windows.Forms.ToolStripMenuItem tsReport;
        private System.Windows.Forms.ToolStripMenuItem tsHelp;
        private System.Windows.Forms.ToolStripMenuItem tsHangSX;
        private System.Windows.Forms.ToolStripMenuItem tsKhachHang;
        private System.Windows.Forms.ToolStripMenuItem tsMatHang;
        private System.Windows.Forms.ToolStripMenuItem tsMenuGeneral;
        private System.Windows.Forms.ToolStripMenuItem tsChangePass;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem tsConfigure;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem tsPause;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem tsExit;
        private System.Windows.Forms.ToolStripMenuItem tsExport;
        private System.Windows.Forms.ToolStripMenuItem tsImport;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel tslbUser;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
        private System.Windows.Forms.ToolStripStatusLabel tslbPointTime;
        private C1.Win.C1Command.C1DockingTab tabMain;
        private System.Windows.Forms.ToolStripMenuItem tsLog;
        private System.Windows.Forms.ToolStripMenuItem tsLoaiMH;
        private System.Windows.Forms.ToolStripMenuItem tsTKDoanhThu;
        private System.Windows.Forms.ToolStripMenuItem tsTKCongNo;
        private System.Windows.Forms.ToolStripMenuItem tsMenu;
        private System.Windows.Forms.ToolStripMenuItem tsMatHangSapHet;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.ToolStripMenuItem tsNhapHang;
        private System.Windows.Forms.ToolStripMenuItem tsNhaCungCap;
        private System.Windows.Forms.ToolStripMenuItem tsTKCongNoNhap;

    }
}