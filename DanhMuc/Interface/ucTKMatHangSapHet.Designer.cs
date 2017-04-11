namespace DanhMuc.Interface
{
    partial class ucTKMatHangSapHet
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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lbCount = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtSoLuong = new System.Windows.Forms.TextBox();
            this.txtKeyword = new System.Windows.Forms.TextBox();
            this.btnTim = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cbTKHangSX = new System.Windows.Forms.ComboBox();
            this.cbLoaiMH = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cbDonVi = new System.Windows.Forms.ComboBox();
            this.cbTKLoaiMH = new System.Windows.Forms.ComboBox();
            this.cbHangSX = new System.Windows.Forms.ComboBox();
            this.c1FlexGrid1 = new C1.Win.C1FlexGrid.C1FlexGrid();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.c1FlexGrid1)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.groupBox1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.cbLoaiMH);
            this.splitContainer1.Panel2.Controls.Add(this.label3);
            this.splitContainer1.Panel2.Controls.Add(this.cbDonVi);
            this.splitContainer1.Panel2.Controls.Add(this.cbTKLoaiMH);
            this.splitContainer1.Panel2.Controls.Add(this.cbHangSX);
            this.splitContainer1.Panel2.Controls.Add(this.c1FlexGrid1);
            this.splitContainer1.Size = new System.Drawing.Size(889, 426);
            this.splitContainer1.SplitterDistance = 69;
            this.splitContainer1.TabIndex = 12;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lbCount);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txtSoLuong);
            this.groupBox1.Controls.Add(this.txtKeyword);
            this.groupBox1.Controls.Add(this.btnTim);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.cbTKHangSX);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(889, 69);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Tìm kiếm";
            // 
            // lbCount
            // 
            this.lbCount.AutoSize = true;
            this.lbCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbCount.ForeColor = System.Drawing.Color.Red;
            this.lbCount.Location = new System.Drawing.Point(8, 50);
            this.lbCount.Name = "lbCount";
            this.lbCount.Size = new System.Drawing.Size(83, 16);
            this.lbCount.TabIndex = 7;
            this.lbCount.Text = "Tìm thấy:...";
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(664, 22);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(73, 16);
            this.label4.TabIndex = 2;
            this.label4.Text = "Số lượng:";
            // 
            // txtSoLuong
            // 
            this.txtSoLuong.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSoLuong.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSoLuong.Location = new System.Drawing.Point(737, 19);
            this.txtSoLuong.Name = "txtSoLuong";
            this.txtSoLuong.Size = new System.Drawing.Size(85, 22);
            this.txtSoLuong.TabIndex = 3;
            this.txtSoLuong.Text = "5";
            this.toolTip1.SetToolTip(this.txtSoLuong, "Số lượng còn trong kho");
            this.txtSoLuong.TextChanged += new System.EventHandler(this.txtSoLuong_TextChanged);
            // 
            // txtKeyword
            // 
            this.txtKeyword.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtKeyword.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtKeyword.Location = new System.Drawing.Point(302, 19);
            this.txtKeyword.Name = "txtKeyword";
            this.txtKeyword.Size = new System.Drawing.Size(356, 22);
            this.txtKeyword.TabIndex = 1;
            this.txtKeyword.TextChanged += new System.EventHandler(this.txtKeyword_TextChanged);
            this.txtKeyword.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtKeyword_KeyDown);
            // 
            // btnTim
            // 
            this.btnTim.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnTim.Image = global::DanhMuc.Properties.Resources.search;
            this.btnTim.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnTim.Location = new System.Drawing.Point(830, 18);
            this.btnTim.Name = "btnTim";
            this.btnTim.Size = new System.Drawing.Size(53, 23);
            this.btnTim.TabIndex = 6;
            this.btnTim.Text = "Tìm";
            this.btnTim.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnTim.UseVisualStyleBackColor = true;
            this.btnTim.Click += new System.EventHandler(this.btnTim_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(228, 21);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 16);
            this.label2.TabIndex = 0;
            this.label2.Text = "Từ khóa:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(8, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 16);
            this.label1.TabIndex = 4;
            this.label1.Text = "Hãng SX:";
            // 
            // cbTKHangSX
            // 
            this.cbTKHangSX.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cbTKHangSX.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbTKHangSX.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbTKHangSX.FormattingEnabled = true;
            this.cbTKHangSX.Items.AddRange(new object[] {
            "---Tất cả---",
            "Đại lý cấp 1",
            "Đại lý cấp 2",
            "Đại lý cấp 3",
            "Đại lý cấp 4",
            "Đại lý cấp 5"});
            this.cbTKHangSX.Location = new System.Drawing.Point(85, 17);
            this.cbTKHangSX.Name = "cbTKHangSX";
            this.cbTKHangSX.Size = new System.Drawing.Size(137, 24);
            this.cbTKHangSX.TabIndex = 5;
            this.cbTKHangSX.SelectedIndexChanged += new System.EventHandler(this.cbTKHangSX_SelectedIndexChanged);
            this.cbTKHangSX.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cbTKHangSX_KeyDown);
            // 
            // cbLoaiMH
            // 
            this.cbLoaiMH.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cbLoaiMH.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbLoaiMH.FormattingEnabled = true;
            this.cbLoaiMH.Location = new System.Drawing.Point(173, 110);
            this.cbLoaiMH.Name = "cbLoaiMH";
            this.cbLoaiMH.Size = new System.Drawing.Size(137, 21);
            this.cbLoaiMH.TabIndex = 4;
            this.cbLoaiMH.Visible = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(248, 38);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 13);
            this.label3.TabIndex = 1;
            this.label3.Text = "Loại mặt hàng:";
            this.label3.Visible = false;
            // 
            // cbDonVi
            // 
            this.cbDonVi.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cbDonVi.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbDonVi.FormattingEnabled = true;
            this.cbDonVi.Location = new System.Drawing.Point(313, 110);
            this.cbDonVi.Name = "cbDonVi";
            this.cbDonVi.Size = new System.Drawing.Size(121, 21);
            this.cbDonVi.TabIndex = 5;
            this.cbDonVi.Visible = false;
            // 
            // cbTKLoaiMH
            // 
            this.cbTKLoaiMH.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cbTKLoaiMH.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbTKLoaiMH.FormattingEnabled = true;
            this.cbTKLoaiMH.Items.AddRange(new object[] {
            "---Tất cả---",
            "Đại lý cấp 1",
            "Đại lý cấp 2",
            "Đại lý cấp 3",
            "Đại lý cấp 4",
            "Đại lý cấp 5"});
            this.cbTKLoaiMH.Location = new System.Drawing.Point(325, 35);
            this.cbTKLoaiMH.Name = "cbTKLoaiMH";
            this.cbTKLoaiMH.Size = new System.Drawing.Size(136, 21);
            this.cbTKLoaiMH.TabIndex = 2;
            this.cbTKLoaiMH.Visible = false;
            this.cbTKLoaiMH.SelectedIndexChanged += new System.EventHandler(this.cbTKLoaiMH_SelectedIndexChanged);
            this.cbTKLoaiMH.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cbTKLoaiMH_KeyDown);
            // 
            // cbHangSX
            // 
            this.cbHangSX.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cbHangSX.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbHangSX.FormattingEnabled = true;
            this.cbHangSX.Location = new System.Drawing.Point(30, 110);
            this.cbHangSX.Name = "cbHangSX";
            this.cbHangSX.Size = new System.Drawing.Size(137, 21);
            this.cbHangSX.TabIndex = 3;
            this.cbHangSX.Visible = false;
            // 
            // c1FlexGrid1
            // 
            this.c1FlexGrid1.AllowEditing = false;
            this.c1FlexGrid1.ColumnInfo = "10,0,0,0,0,85,Columns:";
            this.c1FlexGrid1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.c1FlexGrid1.Location = new System.Drawing.Point(0, 0);
            this.c1FlexGrid1.Name = "c1FlexGrid1";
            this.c1FlexGrid1.Rows.Count = 1;
            this.c1FlexGrid1.Rows.DefaultSize = 17;
            this.c1FlexGrid1.Size = new System.Drawing.Size(889, 353);
            this.c1FlexGrid1.TabIndex = 0;
            // 
            // ucTKMatHangSapHet
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainer1);
            this.Name = "ucTKMatHangSapHet";
            this.Size = new System.Drawing.Size(889, 426);
            this.Load += new System.EventHandler(this.ucTKMatHangSapHet_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            this.splitContainer1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.c1FlexGrid1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtKeyword;
        private System.Windows.Forms.Button btnTim;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbTKHangSX;
        private System.Windows.Forms.ComboBox cbLoaiMH;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbDonVi;
        private System.Windows.Forms.ComboBox cbTKLoaiMH;
        private System.Windows.Forms.ComboBox cbHangSX;
        private C1.Win.C1FlexGrid.C1FlexGrid c1FlexGrid1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtSoLuong;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Label lbCount;

    }
}
