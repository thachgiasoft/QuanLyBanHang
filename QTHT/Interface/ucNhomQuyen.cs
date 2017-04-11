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
    public partial class ucNhomQuyen : UserControl
    {
        private logBL _ctrlog = new logBL();
        private List<quyen_nhom> lst = new List<quyen_nhom>();

        #region Method
        private void CheckQuyenDL()
        {
            ultraToolbarsManager1.Tools["btn_Add"].SharedProps.Visible = false;
            ultraToolbarsManager1.Tools["btn_Save"].SharedProps.Visible = false;
            ultraToolbarsManager1.Tools["btn_Del"].SharedProps.Visible = false;
            try
            {
                quyennguoidung obj = new quyennguoidung();
                quyennguoidungBL ctr = new quyennguoidungBL();
                obj = ctr.GetByIDNhanVienvsMenuName(Data.iduse, "tsGroup");
                string[] arrquyendl = obj.quyendl.Split(';');
                if (arrquyendl[0].Trim().Equals("EDIT") == true)
                {
                    ultraToolbarsManager1.Tools["btn_Add"].SharedProps.Visible = true;
                    ultraToolbarsManager1.Tools["btn_Save"].SharedProps.Visible = true;
                }
                if (arrquyendl[1].Trim().Equals("DEL") == true)
                {
                    ultraToolbarsManager1.Tools["btn_Del"].SharedProps.Visible = true;
                }
            }
            catch
            {
                ultraToolbarsManager1.Tools["btn_Add"].SharedProps.Visible = false;
                ultraToolbarsManager1.Tools["btn_Save"].SharedProps.Visible = false;
                ultraToolbarsManager1.Tools["btn_Del"].SharedProps.Visible = false;
            }
        }
        private void HienThiDSNhom()
        {
            treeNhom.Nodes.Clear();
            try
            {
                nhomBL ctr = new nhomBL();
                DataTable dt = new DataTable();
                dt = ctr.GetAll();
                TreeNode nodecha = treeNhom.Nodes.Add("-1", "DANH MỤC NHÓM NGƯỜI DÙNG");
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    TreeNode node = nodecha.Nodes.Add(dt.Rows[i]["idnhom"].ToString().Trim(), dt.Rows[i]["tennhom"].ToString().Trim());
                }
            }
            catch { }
            treeNhom.ExpandAll();
        }
        private void HienThiDuLieu()
        {
            try
            {
                menuBL ctr = new menuBL();
                DataTable dt = new DataTable();
                dt = ctr.GetAll();
                DataRow[] arrdr = dt.Select("parentmenuid=0", "menuorder asc,menuname asc");
                //TreeNode nodecha = treeQuyen.Nodes.Add("0", "DANH MỤC CHỨC NĂNG");
                //nodecha.SelectedImageKey = "1";
                for (int i = 0; i < arrdr.Length; i++)
                {
                    TreeNode node = treeQuyen.Nodes.Add(arrdr[i]["menuid"].ToString().Trim(), arrdr[i]["menuname"].ToString().Trim());
                    //node.SelectedImageKey = "0";
                    HienThiDuLieuCapCon(node);
                }
            }
            catch { }
            treeQuyen.ExpandAll();
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
                    HienThiDuLieuCapCon(node);
                }
            }
            catch { }
        }
        private nhom GetData()
        {
            nhom obj = new nhom();
            if (txtID.Text.Trim().Equals("-1") == true)
            {
                obj.idnhom = Guid.NewGuid().ToString().Trim();
            }
            else { obj.idnhom = txtID.Text.Trim(); }
            if (txtTenNhom.Text.Trim().Equals("") == true)
            {
                MessageBox.Show("Tên nhóm người dùng không được để trắng.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTenNhom.Focus();
                return null;
            }
            obj.tennhom = txtTenNhom.Text.Trim();
            obj.mota = txtGhiChu.Text.Trim();
            return obj;
        }
        private List<quyen_nhom> GetListQuyenOfNhom(TreeNodeCollection treenodecollect)
        {
            quyen_nhom obj = new quyen_nhom();
            foreach (TreeNode tn in treenodecollect)
            {
                if (tn.Checked == true)
                {
                    obj = new quyen_nhom();
                    obj.id = Guid.NewGuid().ToString().Trim();
                    try { obj.menuid = Convert.ToInt32(tn.Name.Trim()); }
                    catch { obj.menuid = 0; }
                    if (obj.menuid != 0 && obj.menuid != -1) { lst.Add(obj); }
                    GetListQuyenOfNhom(tn.Nodes);
                }
                else { GetListQuyenOfNhom(tn.Nodes); }
            }
            return lst;
        }
        private void HienThiTT(string sid)
        {
            nhom obj = new nhom();
            nhomBL ctr = new nhomBL();
            obj = ctr.GetByID(sid);
            try
            {
                treeQuyen.Enabled = false;
                txtGhiChu.Enabled = true;
                txtGhiChu.Text = obj.mota.Trim();
                txtID.Text = sid.ToString().Trim();
                txtTenNhom.Text = obj.tennhom;
                if (txtTenNhom.Text.Trim().Equals("Admin") == false)
                {
                    txtTenNhom.Enabled = true;
                }
                else
                {
                    txtTenNhom.Enabled = false;
                    txtGhiChu.Enabled = false;
                    treeQuyen.Enabled = false;
                }
                HienThiDSQuyen(sid);
                treeQuyen.Enabled = true;
            }
            catch { }
        }
        private void HienThiDSQuyen(string sidnhom)
        {
            quyen_nhomBL ctr = new quyen_nhomBL();
            DataTable dt = new DataTable();
            dt = ctr.GetByIDNhom(sidnhom);
            UncheckAllNodes(treeQuyen.Nodes);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                TreeNode[] arr = treeQuyen.Nodes.Find(dt.Rows[i]["menuid"].ToString().Trim(), true);
                if (arr.Length > 0) { arr[0].Checked = true; }
            }
        }
        public void CheckAllNodes(TreeNodeCollection nodes)
        {
            foreach (TreeNode node in nodes)
            {
                node.Checked = true;
                CheckChildren(node, true);
            }
        }
        public void UncheckAllNodes(TreeNodeCollection nodes)
        {
            foreach (TreeNode node in nodes)
            {
                node.Checked = false;
                CheckChildren(node, false);
            }
        }
        private void CheckChildren(TreeNode rootNode, bool isChecked)
        {
            foreach (TreeNode node in rootNode.Nodes)
            {
                CheckChildren(node, isChecked);
                node.Checked = isChecked;
            }
        }
        #endregion
        #region Method cập nhật
        private void Add()
        {
            txtGhiChu.Enabled = true;
            txtTenNhom.Enabled = true;
            txtGhiChu.Text = "";
            txtID.Text = "-1";
            txtTenNhom.Text = "";
            UncheckAllNodes(treeQuyen.Nodes);
            txtTenNhom.Focus();
        }
        private void Save()
        {
            //TreeNode nodequyencha = treeQuyen.Nodes.Find("0", true)[0];
            quyen_nhomBL ctrquyennhom = new quyen_nhomBL();
            lst = new List<quyen_nhom>();
            lst = GetListQuyenOfNhom(treeQuyen.Nodes);
            nhomBL ctr = new nhomBL();
            nhom obj = new nhom();
            obj = GetData();
            string kq = "";
            if (obj != null)
            {
                if (txtID.Text.Trim().Equals("-1") == true) //Thêm mới
                {
                    kq = ctr.Insert(obj);
                    if (kq.Trim().Equals("") == true)
                    {
                        ctrquyennhom.DeletebyIDNhom(obj.idnhom);
                        for (int i = 0; i < lst.Count; i++)
                        {
                            lst[i].idnhom = obj.idnhom;
                            ctrquyennhom.Insert(lst[i]);
                        }
                        TreeNode nodecha = treeNhom.Nodes.Find("-1", true)[0];
                        nodecha.Nodes.Add(obj.idnhom, obj.tennhom);
                        _ctrlog.Append(Data.use, "Thêm mới nhóm người dùng: " + obj.tennhom);
                        MessageBox.Show("Thêm mới nhóm người dùng thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        HienThiTT(treeNhom.SelectedNode.Name.Trim());
                    }
                }
                else //Sửa
                {
                    kq = ctr.Update(obj);
                    if (kq.Trim().Equals("") == true)
                    {
                        ctrquyennhom.DeletebyIDNhom(obj.idnhom);
                        for (int i = 0; i < lst.Count; i++)
                        {
                            lst[i].idnhom = obj.idnhom;
                            ctrquyennhom.Insert(lst[i]);
                        }
                        TreeNode node = new TreeNode();
                        node = treeNhom.Nodes.Find(obj.idnhom.Trim(), true)[0];
                        node.Text = obj.tennhom.Trim();
                        treeNhom.SelectedNode = node;
                        _ctrlog.Append(Data.use, "Cập nhật nhóm người dùng: " + obj.tennhom);
                        MessageBox.Show("Cập nhật nhóm người dùng thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        HienThiTT(treeNhom.SelectedNode.Name.Trim());
                    }
                }
            }
        }
        private void Del()
        {
            if (txtTenNhom.Text.Trim().Equals("Admin") == false)
            {
                nhomBL ctr = new nhomBL();
                string stennhom = "";
                stennhom = txtTenNhom.Text.Trim();
                string iid = "";
                try { iid = txtID.Text.Trim(); }
                catch { }
                if (iid.Equals("") == false && iid.Equals("-1") == false)
                {
                    if (MessageBox.Show("Xác nhận xóa nhóm người dùng?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        if (ctr.Delete(iid).Trim().Equals("") == true)
                        {
                            TreeNode node = treeNhom.Nodes.Find(txtID.Text, true)[0];
                            treeNhom.Nodes.Remove(node);
                            _ctrlog.Append(Data.use, "Xóa nhóm người dùng: " + stennhom);
                            MessageBox.Show("Xóa nhóm người dùng thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Bạn không thể xóa nhóm người dùng này.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
        }
        #endregion
        public ucNhomQuyen()
        {
            InitializeComponent();
        }
        private void ucNhomQuyen_Load(object sender, EventArgs e)
        {
            if (Data.use.Trim().Equals("admin") == false)
            {
                CheckQuyenDL();
            }
            else
            {
                ultraToolbarsManager1.Tools["btn_Add"].SharedProps.Visible = true;
                ultraToolbarsManager1.Tools["btn_Save"].SharedProps.Visible = true;
                ultraToolbarsManager1.Tools["btn_Del"].SharedProps.Visible = true;
            }
            HienThiDSNhom();
            HienThiDuLieu();
        }
        private void CheckAllChildNodes(TreeNode treeNode, bool nodeChecked)
        {
            foreach (TreeNode node in treeNode.Nodes)
            {
                node.Checked = nodeChecked;
                if (node.Nodes.Count > 0)
                {
                    // If the current node has child nodes, call the CheckAllChildsNodes method recursively. 
                    this.CheckAllChildNodes(node, nodeChecked);
                }
            }
        }
        private void treeQuyen_AfterCheck(object sender, TreeViewEventArgs e)
        {
            if (treeQuyen.Enabled)
            {
                treeQuyen.AfterCheck -= treeQuyen_AfterCheck;
                TreeNode node = e.Node;
                if (node.Nodes != null)
                    node.Nodes.Cast<TreeNode>().ToList().ForEach(v => v.Checked = node.Checked);
                node = e.Node.Parent;
                while (node != null)
                {
                    bool set = e.Node.Checked
                               ? node.Nodes.Cast<TreeNode>()
                                .Any(v => v.Checked == e.Node.Checked)
                               : node.Nodes.Cast<TreeNode>()
                                .All(v => v.Checked == e.Node.Checked);
                    if (set)
                    {
                        node.Checked = e.Node.Checked;
                        node = node.Parent;
                    }
                    else
                        node = null;
                }
                treeQuyen.AfterCheck += treeQuyen_AfterCheck;
            }
        }
        private void treeNhom_AfterSelect(object sender, TreeViewEventArgs e)
        {
            string sid = "";
            try { sid = treeNhom.SelectedNode.Name.Trim(); }
            catch { }
            if (sid.Equals("") == false && sid.Equals("-1") == false)
            {
                HienThiTT(sid);
            }
            else
            {
                treeQuyen.Enabled = false;
                txtID.Text = "-1";
                txtGhiChu.Text = "";
                txtGhiChu.Enabled = false;
                txtTenNhom.Text = "";
                txtTenNhom.Enabled = false;
                HienThiDSQuyen("-1");
                treeQuyen.Enabled = false;
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
                    HienThiDSNhom();
                    Add();
                    break;

                case "btn_Del":    // ButtonTool
                    Del();
                    break;
            }
        }
    }
}
