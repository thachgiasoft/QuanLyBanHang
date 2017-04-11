namespace DanhMuc.Interface
{
    partial class ucHangSX
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            Infragistics.Win.UltraWinToolbars.UltraToolbar ultraToolbar1 = new Infragistics.Win.UltraWinToolbars.UltraToolbar("UltraToolbar1");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool9 = new Infragistics.Win.UltraWinToolbars.ButtonTool("btn_Add");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool10 = new Infragistics.Win.UltraWinToolbars.ButtonTool("btn_Save");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool11 = new Infragistics.Win.UltraWinToolbars.ButtonTool("btn_Abort");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool12 = new Infragistics.Win.UltraWinToolbars.ButtonTool("btn_Del");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool13 = new Infragistics.Win.UltraWinToolbars.ButtonTool("btn_Add");
            Infragistics.Win.Appearance appearance25 = new Infragistics.Win.Appearance();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucHangSX));
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool14 = new Infragistics.Win.UltraWinToolbars.ButtonTool("btn_Save");
            Infragistics.Win.Appearance appearance26 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool15 = new Infragistics.Win.UltraWinToolbars.ButtonTool("btn_Abort");
            Infragistics.Win.Appearance appearance27 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool16 = new Infragistics.Win.UltraWinToolbars.ButtonTool("btn_Del");
            Infragistics.Win.Appearance appearance28 = new Infragistics.Win.Appearance();
            this.ucChucVu_Fill_Panel = new System.Windows.Forms.Panel();
            this.c1FlexGrid1 = new C1.Win.C1FlexGrid.C1FlexGrid();
            this.statusStrip3 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this._ucHangSX_Toolbars_Dock_Area_Left = new Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea();
            this.ultraToolbarsManager1 = new Infragistics.Win.UltraWinToolbars.UltraToolbarsManager(this.components);
            this._ucHangSX_Toolbars_Dock_Area_Right = new Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea();
            this._ucHangSX_Toolbars_Dock_Area_Top = new Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea();
            this._ucHangSX_Toolbars_Dock_Area_Bottom = new Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea();
            this.ucChucVu_Fill_Panel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.c1FlexGrid1)).BeginInit();
            this.statusStrip3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ultraToolbarsManager1)).BeginInit();
            this.SuspendLayout();
            // 
            // ucChucVu_Fill_Panel
            // 
            this.ucChucVu_Fill_Panel.Controls.Add(this.c1FlexGrid1);
            this.ucChucVu_Fill_Panel.Cursor = System.Windows.Forms.Cursors.Default;
            this.ucChucVu_Fill_Panel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucChucVu_Fill_Panel.Location = new System.Drawing.Point(0, 28);
            this.ucChucVu_Fill_Panel.Name = "ucChucVu_Fill_Panel";
            this.ucChucVu_Fill_Panel.Size = new System.Drawing.Size(567, 252);
            this.ucChucVu_Fill_Panel.TabIndex = 0;
            // 
            // c1FlexGrid1
            // 
            this.c1FlexGrid1.ColumnInfo = "10,1,0,0,0,85,Columns:";
            this.c1FlexGrid1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.c1FlexGrid1.Location = new System.Drawing.Point(0, 0);
            this.c1FlexGrid1.Name = "c1FlexGrid1";
            this.c1FlexGrid1.Rows.Count = 1;
            this.c1FlexGrid1.Rows.DefaultSize = 17;
            this.c1FlexGrid1.Size = new System.Drawing.Size(567, 252);
            this.c1FlexGrid1.TabIndex = 1;
            this.c1FlexGrid1.AfterEdit += new C1.Win.C1FlexGrid.RowColEventHandler(this.c1FlexGrid1_AfterEdit);
            this.c1FlexGrid1.Click += new System.EventHandler(this.c1FlexGrid1_Click);
            this.c1FlexGrid1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.c1FlexGrid1_KeyDown);
            this.c1FlexGrid1.KeyUp += new System.Windows.Forms.KeyEventHandler(this.c1FlexGrid1_KeyUp);
            // 
            // statusStrip3
            // 
            this.statusStrip3.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel2});
            this.statusStrip3.Location = new System.Drawing.Point(0, 280);
            this.statusStrip3.Name = "statusStrip3";
            this.statusStrip3.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.statusStrip3.Size = new System.Drawing.Size(567, 22);
            this.statusStrip3.TabIndex = 7;
            this.statusStrip3.Text = "statusStrip3";
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.ForeColor = System.Drawing.Color.Red;
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(229, 17);
            this.toolStripStatusLabel2.Text = "Chú ý : (*) là những trường bắt buộc nhập";
            // 
            // _ucHangSX_Toolbars_Dock_Area_Left
            // 
            this._ucHangSX_Toolbars_Dock_Area_Left.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this._ucHangSX_Toolbars_Dock_Area_Left.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(219)))), ((int)(((byte)(255)))));
            this._ucHangSX_Toolbars_Dock_Area_Left.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Left;
            this._ucHangSX_Toolbars_Dock_Area_Left.ForeColor = System.Drawing.SystemColors.ControlText;
            this._ucHangSX_Toolbars_Dock_Area_Left.Location = new System.Drawing.Point(0, 28);
            this._ucHangSX_Toolbars_Dock_Area_Left.Name = "_ucHangSX_Toolbars_Dock_Area_Left";
            this._ucHangSX_Toolbars_Dock_Area_Left.Size = new System.Drawing.Size(0, 252);
            this._ucHangSX_Toolbars_Dock_Area_Left.ToolbarsManager = this.ultraToolbarsManager1;
            // 
            // ultraToolbarsManager1
            // 
            this.ultraToolbarsManager1.DesignerFlags = 1;
            this.ultraToolbarsManager1.DockWithinContainer = this;
            this.ultraToolbarsManager1.MenuAnimationStyle = Infragistics.Win.UltraWinToolbars.MenuAnimationStyle.Slide;
            this.ultraToolbarsManager1.ShowFullMenusDelay = 500;
            this.ultraToolbarsManager1.Style = Infragistics.Win.UltraWinToolbars.ToolbarStyle.Office2007;
            ultraToolbar1.DockedColumn = 0;
            ultraToolbar1.DockedRow = 0;
            buttonTool9.InstanceProps.IsFirstInGroup = true;
            buttonTool10.InstanceProps.IsFirstInGroup = true;
            buttonTool11.InstanceProps.IsFirstInGroup = true;
            buttonTool12.InstanceProps.IsFirstInGroup = true;
            ultraToolbar1.NonInheritedTools.AddRange(new Infragistics.Win.UltraWinToolbars.ToolBase[] {
            buttonTool9,
            buttonTool10,
            buttonTool11,
            buttonTool12});
            ultraToolbar1.Text = "UltraToolbar1";
            this.ultraToolbarsManager1.Toolbars.AddRange(new Infragistics.Win.UltraWinToolbars.UltraToolbar[] {
            ultraToolbar1});
            appearance25.Image = ((object)(resources.GetObject("appearance25.Image")));
            buttonTool13.SharedProps.AppearancesSmall.Appearance = appearance25;
            buttonTool13.SharedProps.Caption = "Thêm mới";
            buttonTool13.SharedProps.DisplayStyle = Infragistics.Win.UltraWinToolbars.ToolDisplayStyle.ImageAndText;
            buttonTool13.SharedProps.Shortcut = System.Windows.Forms.Shortcut.CtrlN;
            appearance26.Image = ((object)(resources.GetObject("appearance26.Image")));
            buttonTool14.SharedProps.AppearancesSmall.Appearance = appearance26;
            buttonTool14.SharedProps.Caption = "Ghi";
            buttonTool14.SharedProps.DisplayStyle = Infragistics.Win.UltraWinToolbars.ToolDisplayStyle.ImageAndText;
            buttonTool14.SharedProps.Shortcut = System.Windows.Forms.Shortcut.CtrlS;
            appearance27.Image = ((object)(resources.GetObject("appearance27.Image")));
            buttonTool15.SharedProps.AppearancesSmall.Appearance = appearance27;
            buttonTool15.SharedProps.Caption = "Hủy";
            buttonTool15.SharedProps.DisplayStyle = Infragistics.Win.UltraWinToolbars.ToolDisplayStyle.ImageAndText;
            buttonTool15.SharedProps.Shortcut = System.Windows.Forms.Shortcut.CtrlX;
            appearance28.Image = ((object)(resources.GetObject("appearance28.Image")));
            buttonTool16.SharedProps.AppearancesSmall.Appearance = appearance28;
            buttonTool16.SharedProps.Caption = "Xóa";
            buttonTool16.SharedProps.DisplayStyle = Infragistics.Win.UltraWinToolbars.ToolDisplayStyle.ImageAndText;
            buttonTool16.SharedProps.Shortcut = System.Windows.Forms.Shortcut.CtrlX;
            this.ultraToolbarsManager1.Tools.AddRange(new Infragistics.Win.UltraWinToolbars.ToolBase[] {
            buttonTool13,
            buttonTool14,
            buttonTool15,
            buttonTool16});
            this.ultraToolbarsManager1.ToolClick += new Infragistics.Win.UltraWinToolbars.ToolClickEventHandler(this.ultraToolbarsManager1_ToolClick);
            // 
            // _ucHangSX_Toolbars_Dock_Area_Right
            // 
            this._ucHangSX_Toolbars_Dock_Area_Right.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this._ucHangSX_Toolbars_Dock_Area_Right.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(219)))), ((int)(((byte)(255)))));
            this._ucHangSX_Toolbars_Dock_Area_Right.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Right;
            this._ucHangSX_Toolbars_Dock_Area_Right.ForeColor = System.Drawing.SystemColors.ControlText;
            this._ucHangSX_Toolbars_Dock_Area_Right.Location = new System.Drawing.Point(567, 28);
            this._ucHangSX_Toolbars_Dock_Area_Right.Name = "_ucHangSX_Toolbars_Dock_Area_Right";
            this._ucHangSX_Toolbars_Dock_Area_Right.Size = new System.Drawing.Size(0, 252);
            this._ucHangSX_Toolbars_Dock_Area_Right.ToolbarsManager = this.ultraToolbarsManager1;
            // 
            // _ucHangSX_Toolbars_Dock_Area_Top
            // 
            this._ucHangSX_Toolbars_Dock_Area_Top.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this._ucHangSX_Toolbars_Dock_Area_Top.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(219)))), ((int)(((byte)(255)))));
            this._ucHangSX_Toolbars_Dock_Area_Top.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Top;
            this._ucHangSX_Toolbars_Dock_Area_Top.ForeColor = System.Drawing.SystemColors.ControlText;
            this._ucHangSX_Toolbars_Dock_Area_Top.Location = new System.Drawing.Point(0, 0);
            this._ucHangSX_Toolbars_Dock_Area_Top.Name = "_ucHangSX_Toolbars_Dock_Area_Top";
            this._ucHangSX_Toolbars_Dock_Area_Top.Size = new System.Drawing.Size(567, 28);
            this._ucHangSX_Toolbars_Dock_Area_Top.ToolbarsManager = this.ultraToolbarsManager1;
            // 
            // _ucHangSX_Toolbars_Dock_Area_Bottom
            // 
            this._ucHangSX_Toolbars_Dock_Area_Bottom.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this._ucHangSX_Toolbars_Dock_Area_Bottom.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(219)))), ((int)(((byte)(255)))));
            this._ucHangSX_Toolbars_Dock_Area_Bottom.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Bottom;
            this._ucHangSX_Toolbars_Dock_Area_Bottom.ForeColor = System.Drawing.SystemColors.ControlText;
            this._ucHangSX_Toolbars_Dock_Area_Bottom.Location = new System.Drawing.Point(0, 280);
            this._ucHangSX_Toolbars_Dock_Area_Bottom.Name = "_ucHangSX_Toolbars_Dock_Area_Bottom";
            this._ucHangSX_Toolbars_Dock_Area_Bottom.Size = new System.Drawing.Size(567, 0);
            this._ucHangSX_Toolbars_Dock_Area_Bottom.ToolbarsManager = this.ultraToolbarsManager1;
            // 
            // ucHangSX
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.ucChucVu_Fill_Panel);
            this.Controls.Add(this._ucHangSX_Toolbars_Dock_Area_Left);
            this.Controls.Add(this._ucHangSX_Toolbars_Dock_Area_Right);
            this.Controls.Add(this._ucHangSX_Toolbars_Dock_Area_Top);
            this.Controls.Add(this._ucHangSX_Toolbars_Dock_Area_Bottom);
            this.Controls.Add(this.statusStrip3);
            this.Name = "ucHangSX";
            this.Size = new System.Drawing.Size(567, 302);
            this.Load += new System.EventHandler(this.ucHangSX_Load);
            this.ucChucVu_Fill_Panel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.c1FlexGrid1)).EndInit();
            this.statusStrip3.ResumeLayout(false);
            this.statusStrip3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ultraToolbarsManager1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel ucChucVu_Fill_Panel;
        private System.Windows.Forms.StatusStrip statusStrip3;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
        private System.Windows.Forms.ToolTip toolTip1;
        private C1.Win.C1FlexGrid.C1FlexGrid c1FlexGrid1;
        private Infragistics.Win.UltraWinToolbars.UltraToolbarsManager ultraToolbarsManager1;
        private Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea _ucHangSX_Toolbars_Dock_Area_Left;
        private Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea _ucHangSX_Toolbars_Dock_Area_Right;
        private Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea _ucHangSX_Toolbars_Dock_Area_Top;
        private Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea _ucHangSX_Toolbars_Dock_Area_Bottom;
    }
}
