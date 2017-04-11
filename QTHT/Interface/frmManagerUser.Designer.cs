namespace QTHT.Interface
{
    partial class frmManagerUser
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
            this.ucManagerUser1 = new QTHT.Interface.ucManagerUser();
            this.SuspendLayout();
            // 
            // ucManagerUser1
            // 
            this.ucManagerUser1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucManagerUser1.Location = new System.Drawing.Point(0, 0);
            this.ucManagerUser1.Name = "ucManagerUser1";
            this.ucManagerUser1.Size = new System.Drawing.Size(744, 421);
            this.ucManagerUser1.TabIndex = 0;
            // 
            // frmManagerUser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(744, 421);
            this.Controls.Add(this.ucManagerUser1);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(760, 459);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(760, 459);
            this.Name = "frmManagerUser";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Quản lý người dùng";
            this.ResumeLayout(false);

        }

        #endregion

        private ucManagerUser ucManagerUser1;
    }
}