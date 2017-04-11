namespace QTHT.Interface
{
    partial class frmNguoiDungOfNhom
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
            this.ucNguoiDungOfNhom1 = new QTHT.Interface.ucNguoiDungOfNhom();
            this.SuspendLayout();
            // 
            // ucNguoiDungOfNhom1
            // 
            this.ucNguoiDungOfNhom1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucNguoiDungOfNhom1.Location = new System.Drawing.Point(0, 0);
            this.ucNguoiDungOfNhom1.Name = "ucNguoiDungOfNhom1";
            this.ucNguoiDungOfNhom1.Size = new System.Drawing.Size(624, 367);
            this.ucNguoiDungOfNhom1.TabIndex = 0;
            // 
            // frmNguoiDungOfNhom
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(624, 367);
            this.Controls.Add(this.ucNguoiDungOfNhom1);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(640, 405);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(640, 405);
            this.Name = "frmNguoiDungOfNhom";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cập nhật người dùng thuộc nhóm";
            this.ResumeLayout(false);

        }

        #endregion

        private ucNguoiDungOfNhom ucNguoiDungOfNhom1;
    }
}