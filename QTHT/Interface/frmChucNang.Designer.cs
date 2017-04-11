namespace QTHT.Interface
{
    partial class frmChucNang
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
            this.ucChucNang1 = new QTHT.Interface.ucChucNang();
            this.SuspendLayout();
            // 
            // ucChucNang1
            // 
            this.ucChucNang1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucChucNang1.Location = new System.Drawing.Point(0, 0);
            this.ucChucNang1.Name = "ucChucNang1";
            this.ucChucNang1.Size = new System.Drawing.Size(593, 401);
            this.ucChucNang1.TabIndex = 0;
            // 
            // frmChucNang
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(593, 401);
            this.Controls.Add(this.ucChucNang1);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(609, 439);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(609, 439);
            this.Name = "frmChucNang";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Quản lý danh mục chức năng";
            this.ResumeLayout(false);

        }

        #endregion

        private ucChucNang ucChucNang1;
    }
}