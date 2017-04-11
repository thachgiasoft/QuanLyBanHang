namespace DanhMuc.Interface
{
    partial class frmChonMatHang
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
            this.ucMatHang1 = new DanhMuc.Interface.ucMatHang();
            this.SuspendLayout();
            // 
            // ucMatHang1
            // 
            this.ucMatHang1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucMatHang1.Location = new System.Drawing.Point(0, 0);
            this.ucMatHang1.Name = "ucMatHang1";
            this.ucMatHang1.Size = new System.Drawing.Size(765, 450);
            this.ucMatHang1.TabIndex = 0;
            this.ucMatHang1.type = 0;
            // 
            // frmChonMatHang
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(765, 450);
            this.Controls.Add(this.ucMatHang1);
            this.Name = "frmChonMatHang";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Chọn mặt hàng";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmChonMatHang_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private ucMatHang ucMatHang1;
    }
}