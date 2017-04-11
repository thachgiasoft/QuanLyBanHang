namespace QTHT.Interface
{
    partial class frmNhomNguoiDung
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
            this.ucNhomQuyen1 = new QTHT.Interface.ucNhomQuyen();
            this.SuspendLayout();
            // 
            // ucNhomQuyen1
            // 
            this.ucNhomQuyen1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucNhomQuyen1.Location = new System.Drawing.Point(0, 0);
            this.ucNhomQuyen1.Name = "ucNhomQuyen1";
            this.ucNhomQuyen1.Size = new System.Drawing.Size(669, 405);
            this.ucNhomQuyen1.TabIndex = 0;
            // 
            // frmNhomNguoiDung
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(669, 405);
            this.Controls.Add(this.ucNhomQuyen1);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(685, 443);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(685, 443);
            this.Name = "frmNhomNguoiDung";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cập nhật nhóm người dùng";
            this.ResumeLayout(false);

        }

        #endregion

        private ucNhomQuyen ucNhomQuyen1;
    }
}