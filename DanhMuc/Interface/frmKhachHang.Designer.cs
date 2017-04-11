namespace DanhMuc.Interface
{
    partial class frmKhachHang
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
            this.ucKhachHang1 = new DanhMuc.Interface.ucKhachHang();
            this.SuspendLayout();
            // 
            // ucKhachHang1
            // 
            this.ucKhachHang1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucKhachHang1.Location = new System.Drawing.Point(0, 0);
            this.ucKhachHang1.Name = "ucKhachHang1";
            this.ucKhachHang1.Size = new System.Drawing.Size(704, 436);
            this.ucKhachHang1.TabIndex = 0;
            // 
            // frmKhachHang
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(704, 436);
            this.Controls.Add(this.ucKhachHang1);
            this.Name = "frmKhachHang";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cập nhật thông tin khách hàng";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmKhachHang_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private ucKhachHang ucKhachHang1;
    }
}