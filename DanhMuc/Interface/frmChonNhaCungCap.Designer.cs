namespace DanhMuc.Interface
{
    partial class frmChonNhaCungCap
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
            this.ucNhaCungCap1 = new DanhMuc.Interface.ucNhaCungCap();
            this.SuspendLayout();
            // 
            // ucNhaCungCap1
            // 
            this.ucNhaCungCap1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucNhaCungCap1.Location = new System.Drawing.Point(0, 0);
            this.ucNhaCungCap1.Name = "ucNhaCungCap1";
            this.ucNhaCungCap1.Size = new System.Drawing.Size(624, 452);
            this.ucNhaCungCap1.TabIndex = 0;
            this.ucNhaCungCap1.type = 1;
            // 
            // frmChonNhaCungCap
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(624, 452);
            this.Controls.Add(this.ucNhaCungCap1);
            this.Name = "frmChonNhaCungCap";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cập nhật nhà cung cấp";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmChonNhaCungCap_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private ucNhaCungCap ucNhaCungCap1;
    }
}