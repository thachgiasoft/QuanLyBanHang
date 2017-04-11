using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using QTHT.BusinesLogic;
using C1.Win.C1FlexGrid;
using QTHT.DataAccess;
using CGCN.DataAccess;

namespace QTHT.Interface
{
    public partial class ucChucNang : UserControl
    {
        private logBL _ctrlog = new logBL();

        #region Method
        private void HienThiDuLieu()
        {
            try
            {
                menuBL ctr = new menuBL();
                DataTable dt = new DataTable();
                dt = ctr.GetAll();
                DataRow[] arrdr = dt.Select("parentmenuid=0", "menuorder asc,menuname asc");
                TreeNode nodecha = treeView1.Nodes.Add("0", "DANH MỤC CHỨC NĂNG");
                //nodecha.SelectedImageKey = "1";
                for (int i = 0; i < arrdr.Length; i++)
                {
                    TreeNode node = nodecha.Nodes.Add(arrdr[i]["menuid"].ToString().Trim(), arrdr[i]["menuname"].ToString().Trim());
                    //node.SelectedImageKey = "0";
                }
            }
            catch { }
        }
        private void HienThiDuLieuCapCon(TreeNode nodecha)
        {
            nodecha.Nodes.Clear();
            try
            {
                menuBL ctr = new menuBL();
                DataTable dt = new DataTable();
                dt = ctr.GetAll();
                DataRow[] arrdr = dt.Select("parentmenuid=" + nodecha.Name, "menuorder asc,menuname asc");
                for (int i = 0; i < arrdr.Length; i++)
                {
                    TreeNode node = nodecha.Nodes.Add(arrdr[i]["menuid"].ToString().Trim(), arrdr[i]["menuname"].ToString().Trim());
                    //node.SelectedImageKey = "0";
                }
            }
            catch { }
        }
        private void HienThiTT(int iid)
        {
            menu obj = new menu();
            menuBL ctr = new menuBL();
            obj = ctr.GetByID(iid);
            try
            {
                txtKyHieuCN.Enabled = true;
                txtSTT.Enabled = true;
                txtTenCN.Enabled = true;
                txtGhiChu.Text = obj.ghichu.Trim();
                txtID.Text = iid.ToString().Trim();
                txtKyHieuCN.Text = obj.menulink;
                txtSTT.Text = obj.menuorder.ToString();
                txtTenCN.Text = obj.menuname;
                if (obj.status == 1) { rdActive.Checked = true; rdNotActive.Checked = false; }
                else { rdActive.Checked = false; rdNotActive.Checked = true; }
            }
            catch { }
        }
        private menu GetData()
        {
            menu obj = new menu();
            int smacha = 0;
            if (txtID.Text.Trim().Equals("-1") == true)
            {
                try { smacha = Convert.ToInt32(treeView1.SelectedNode.Name.Trim()); }
                catch { smacha = -1; }
                obj.menuid = 0;
            }
            else
            {
                obj.menuid = Convert.ToInt32(txtID.Text.Trim());
                try { smacha = Convert.ToInt32(treeView1.SelectedNode.Parent.Name); }
                catch { smacha = -1; }
            }
            obj.cap = treeView1.SelectedNode.Level+1;
            obj.ghichu = txtGhiChu.Text.Trim();
            obj.iconlink = "";
            obj.menulink = txtKyHieuCN.Text.Trim();
            obj.menuname = txtTenCN.Text.Trim();
            obj.menuorder = Convert.ToInt32(txtSTT.Text.Trim());
            obj.parentmenuid = smacha;
            if (rdActive.Checked) { obj.status = 1; }
            else { obj.status = 0; }
            return obj;
        }
        #endregion
        #region Method Cập nhật
        private void Add()
        {
            txtID.Text = "-1";
            txtKyHieuCN.Text = "";
            txtSTT.Text = "0";
            txtTenCN.Text = "";
            txtKyHieuCN.Enabled = true;
            txtSTT.Enabled = true;
            txtTenCN.Enabled = true;
            rdActive.Checked = true;
            rdNotActive.Checked = false;
            txtTenCN.Focus();
        }
        private void Save()
        {
            int kq = 0;
            menu obj = new menu();
            menuBL ctr = new menuBL();
            obj = GetData();
            if (obj != null)
            {
                if (txtID.Text.Trim().Equals("-1") == true)
                {
                    kq = ctr.Insert(obj);
                    if (kq != 1)
                    {
                        treeView1.SelectedNode.Nodes.Add(kq.ToString(), obj.menuname.Trim());
                        //treeView1.SelectedNode = treeView1.Nodes.Find(kq.ToString(), true)[0];
                        MessageBox.Show("Thêm mới chức năng thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Add();
                    }
                }
                else
                {
                    if (ctr.Update(obj).Trim().Equals("") == true)
                    {
                        TreeNode node = new TreeNode();
                        node = treeView1.Nodes.Find(obj.menuid.ToString(), true)[0];
                        node.Text = obj.menuname.Trim();
                        treeView1.SelectedNode = node;
                        treeView1.SelectedNode.BackColor = Color.PaleTurquoise;
                        MessageBox.Show("Cập nhật chức năng thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
        }
        private void Del()
        {
            menuBL ctr = new menuBL();
            int iid = -1;
            try { iid = Convert.ToInt32(txtID.Text.Trim()); }
            catch { }
            if (iid != -1)
            {
                if (MessageBox.Show("Xác nhận xóa chức năng?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (ctr.Delete(iid).Trim().Equals("") == true)
                    {
                        TreeNode node = treeView1.Nodes.Find(txtID.Text,true)[0];
                        treeView1.Nodes.Remove(node);
                        MessageBox.Show("Xóa chức năng thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
        }
        #endregion

        public ucChucNang()
        {
            InitializeComponent();
        }

        private void ucChucNang_Load(object sender, EventArgs e)
        {
            HienThiDuLieu();
        }

        private void rdActive_CheckedChanged(object sender, EventArgs e)
        {
            if (rdActive.Checked == true)
            {
                rdNotActive.Checked = false;
            }
        }

        private void rdNotActive_CheckedChanged(object sender, EventArgs e)
        {
            if (rdNotActive.Checked == true)
            {
                rdActive.Checked = false;
            }
        }

        private void ultraToolbarsManager1_ToolClick(object sender, Infragistics.Win.UltraWinToolbars.ToolClickEventArgs e)
        {
            switch (e.Tool.Key)
            {
                case "btn_Add":    // ButtonTool
                    Add();
                    break;

                case "btn_Save":    // ButtonTool
                    Save();
                    break;

                case "btn_Abort":    // ButtonTool
                    HienThiDuLieu();
                    break;

                case "btn_Del":    // ButtonTool
                    Del();
                    break;
            }
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            int iid = 0;
            try { iid = Convert.ToInt32(treeView1.SelectedNode.Name.Trim()); }
            catch {  }
            if (iid != 0)
            {
                HienThiTT(iid);
                HienThiDuLieuCapCon(treeView1.SelectedNode);
            }
            else
            {
                txtID.Text = "-1";
                txtKyHieuCN.Text = "";
                txtKyHieuCN.Enabled = false;
                txtSTT.Text = "0";
                txtSTT.Enabled = false;
                txtTenCN.Text = "";
                txtTenCN.Enabled = false;
                rdActive.Checked = true;
                rdNotActive.Checked = false;
            }
        }
    }
}
