﻿namespace PhieuNhapKho.Interface
{
    partial class frmTienThanhToan
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
            this.ucTienThanhToan1 = new PhieuNhapKho.Interface.ucTienThanhToan();
            this.SuspendLayout();
            // 
            // ucTienThanhToan1
            // 
            this.ucTienThanhToan1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucTienThanhToan1.Location = new System.Drawing.Point(0, 0);
            this.ucTienThanhToan1.Name = "ucTienThanhToan1";
            this.ucTienThanhToan1.sidpn = "";
            this.ucTienThanhToan1.Size = new System.Drawing.Size(623, 479);
            this.ucTienThanhToan1.TabIndex = 0;
            // 
            // frmTienThanhToan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(623, 479);
            this.Controls.Add(this.ucTienThanhToan1);
            this.MinimumSize = new System.Drawing.Size(639, 517);
            this.Name = "frmTienThanhToan";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cập nhật tiền thanh toán cho phiếu nhập hàng";
            this.Load += new System.EventHandler(this.frmTienThanhToan_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private ucTienThanhToan ucTienThanhToan1;
    }
}