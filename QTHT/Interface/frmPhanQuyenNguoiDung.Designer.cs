namespace QTHT.Interface
{
    partial class frmPhanQuyenNguoiDung
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
            this.ucPhanQuyenNguoiDung1 = new QTHT.Interface.ucPhanQuyenNguoiDung();
            this.SuspendLayout();
            // 
            // ucPhanQuyenNguoiDung1
            // 
            this.ucPhanQuyenNguoiDung1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucPhanQuyenNguoiDung1.Location = new System.Drawing.Point(0, 0);
            this.ucPhanQuyenNguoiDung1.Name = "ucPhanQuyenNguoiDung1";
            this.ucPhanQuyenNguoiDung1.Size = new System.Drawing.Size(646, 439);
            this.ucPhanQuyenNguoiDung1.TabIndex = 0;
            // 
            // frmPhanQuyenNguoiDung
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(646, 439);
            this.Controls.Add(this.ucPhanQuyenNguoiDung1);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(662, 477);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(662, 477);
            this.Name = "frmPhanQuyenNguoiDung";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Phân quyền người dùng";
            this.ResumeLayout(false);

        }

        #endregion

        private ucPhanQuyenNguoiDung ucPhanQuyenNguoiDung1;
    }
}