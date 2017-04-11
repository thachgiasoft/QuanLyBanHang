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
    public partial class ucPhanQuyenNguoiDung : UserControl
    {
        private logBL _ctrlog = new logBL();
        private List<quyennguoidung> lst = new List<quyennguoidung>();

        #region Method cho người dùng
        private void CheckQuyenDL()
        {
            try
            {
                quyennguoidung obj = new quyennguoidung();
                quyennguoidungBL ctr = new quyennguoidungBL();
                obj = ctr.GetByIDNhanVienvsMenuName(Data.iduse, "tsRoleOfUse");
                string[] arrquyendl = obj.quyendl.Split(';');
                if (arrquyendl[0].Trim().Equals("EDIT") == true) { ultraToolbarsManager1.Tools["btn_Save"].SharedProps.Enabled = true; return; }
                else { ultraToolbarsManager1.Tools["btn_Save"].SharedProps.Enabled = false; }
            }
            catch { ultraToolbarsManager1.Tools["btn_Save"].SharedProps.Enabled = false; }
        }
        private void LoadTKCBCV()
        {
            try
            {
                chucvuBL _ctr = new chucvuBL();
                DataTable dt = new DataTable();
                dt = _ctr.GetAll();
                cbTK_ChucVu.DataSource = dt;
                cbTK_ChucVu.DisplayMember = "tenchucvu";
                cbTK_ChucVu.ValueMember = "idchucvu";
            }
            catch { }
        }
        private void LoadTKCBPB()
        {
            try
            {
                phongbanBL _ctr = new phongbanBL();
                DataTable dt = new DataTable();
                dt = _ctr.GetAll();
                cbTK_PhongBan.DataSource = dt;
                cbTK_PhongBan.DisplayMember = "tenphongban";
                cbTK_PhongBan.ValueMember = "idphongban";
            }
            catch { }
        }
        private void FindUse()
        {
            nhanvienBL _ctr = new nhanvienBL();
            DataTable dt = new DataTable();
            string sidphongban = ""; try { sidphongban = cbTK_PhongBan.SelectedValue.ToString().Trim(); }
            catch { }
            int sidchucvu = 0; try { sidchucvu = Convert.ToInt32(cbTK_ChucVu.SelectedValue.ToString().Trim()); }
            catch { }
            dt = _ctr.TimKiem(txtTK_HoTen.Text.Trim(), sidphongban, sidchucvu);
            c1FlexGrid1.DataSource = dt;
            FormatGrid();
            if (c1FlexGrid1.Rows.Count - 1 > 0)
            {
                c1FlexGrid1.Select(1, c1FlexGrid1.Cols["hoten"].Index);
                string sidnhanvien = "";
                try { sidnhanvien = c1FlexGrid1[1, "idnhanvien"].ToString().Trim(); }
                catch { }
                HienThiDSQuyen(sidnhanvien);
            }
            else { UncheckAllNodes(treeQuyen.Nodes); }
        }
        private void FormatGrid()
        {
            for (int i = 0; i < c1FlexGrid1.Cols.Count; i++)
            {
                if (i == 0)
                { c1FlexGrid1[0, i] = "STT"; c1FlexGrid1.Cols[i].Visible = true; c1FlexGrid1.Cols[i].Width = 60; }
                else if (c1FlexGrid1.Cols[i].Caption.Equals("hoten"))
                { c1FlexGrid1[0, i] = "Họ tên"; c1FlexGrid1.Cols[i].Visible = true; }
                else if (c1FlexGrid1.Cols[i].Caption.Equals("taikhoan"))
                { c1FlexGrid1[0, i] = "Tài khoản"; c1FlexGrid1.Cols[i].Visible = true; }
                else if (c1FlexGrid1.Cols[i].Caption.Equals("dienthoai"))
                { c1FlexGrid1[0, i] = "Điện thoại"; c1FlexGrid1.Cols[i].Visible = true; }
                else if (c1FlexGrid1.Cols[i].Caption.Equals("email"))
                { c1FlexGrid1[0, i] = "E-mail"; c1FlexGrid1.Cols[i].Visible = true; }
                else { c1FlexGrid1.Cols[i].Visible = false; }
                c1FlexGrid1.Cols[i].TextAlignFixed = TextAlignEnum.CenterCenter;
            }
            //Font _font = new Font("Time new Roman", 14);
            //c1FlexGrid1.Font = _font;
            for (int j = 1; j < c1FlexGrid1.Rows.Count; j++)
            {
                c1FlexGrid1[j, 0] = j;
            }
            c1FlexGrid1.Cols[0].TextAlign = TextAlignEnum.CenterCenter;
            c1FlexGrid1.AutoSizeCols();
            c1FlexGrid1.AutoSizeRows();
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
        private void HienThiDSQuyen(string sidnhanvien)
        {
            treeQuyen.Enabled = false;
            quyennguoidungBL ctr = new quyennguoidungBL();
            DataTable dt = new DataTable();
            dt = ctr.GetByIDNhanVien(sidnhanvien);
            UncheckAllNodes(treeQuyen.Nodes);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                TreeNode[] arr = treeQuyen.Nodes.Find(dt.Rows[i]["idmenu"].ToString().Trim(), true);
                if (arr.Length > 0) { arr[0].Checked = true; }
            }
            treeQuyen.Enabled = true;
            string squyendl = "";
            try
            {
                squyendl = dt.Rows[0]["quyendl"].ToString().Trim();
                string[] arrquyendl = squyendl.Split(';');
                if (arrquyendl[0].Trim().Equals("EDIT") == true) { chbEdit.Checked = true; }
                else { chbEdit.Checked = false; }
                if (arrquyendl[1].Trim().Equals("DEL") == true) { chbDel.Checked = true; }
                else { chbDel.Checked = false; }
            }
            catch { }
        }
        #endregion
        #region Method Cập nhật
        private List<quyennguoidung> GetListQuyen(TreeNodeCollection treenodecollect)
        {
            string sidnhanvien = "";
            try { sidnhanvien = c1FlexGrid1[c1FlexGrid1.RowSel, "idnhanvien"].ToString().Trim(); }
            catch { }
            menuBL ctrmenu = new menuBL();
            quyennguoidung obj = new quyennguoidung();
            foreach (TreeNode tn in treenodecollect)
            {
                if (tn.Checked == true)
                {
                    obj = new quyennguoidung();
                    try { obj.idmenu = Convert.ToInt32(tn.Name.Trim()); }
                    catch { obj.idmenu = 0; }
                    if (sidnhanvien.Trim().Equals("") == true)
                    {
                        MessageBox.Show("Lỗi không lấy được thông tin người dùng.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        //c1FlexGrid1.Focus();
                        return null;
                    }
                    if (obj.idmenu == 0 && obj.idmenu == -1)
                    {
                        MessageBox.Show("Lỗi không lấy được thông tin quyền.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        treeQuyen.Focus();
                        return null;
                    }
                    obj.idnhanvien = sidnhanvien;
                    menu objmenu = new menu();
                    objmenu = ctrmenu.GetByID(obj.idmenu);
                    obj.kyhieucn = objmenu.menulink;
                    obj.mota = objmenu.ghichu;
                    string sEdit = "";
                    if (chbEdit.Checked == true) { sEdit = "EDIT"; }
                    string sDel = "";
                    if (chbDel.Checked == true) { sDel = "DEL"; }
                    obj.quyendl = sEdit + ";" + sDel;
                    obj.status = Convert.ToBoolean(objmenu.status);
                    obj.tenquyendl = objmenu.menuname;
                    lst.Add(obj);
                    GetListQuyen(tn.Nodes);
                }
                else { GetListQuyen(tn.Nodes); }
            }
            return lst;
        }
        private void Save()
        {
            string kq = "";
            quyennguoidungBL ctrquyennd = new quyennguoidungBL();
            lst = new List<quyennguoidung>();
            lst = GetListQuyen(treeQuyen.Nodes);
            string sidnhanvien = "";
            try { sidnhanvien = c1FlexGrid1[c1FlexGrid1.RowSel, "idnhanvien"].ToString().Trim(); }
            catch { }
            string stennhanvien = "";
            try { stennhanvien = c1FlexGrid1[c1FlexGrid1.RowSel, "hoten"].ToString().Trim(); }
            catch { }
            //Xóa quyền cũ của người dùng 
            ctrquyennd.DeleteByIDNhanVien(sidnhanvien);
            if (lst != null)
            {
                for (int j = 0; j < lst.Count; j++)
                {

                    kq = ctrquyennd.Insert(lst[j]);
                    _ctrlog.Append(Data.use, "Cập nhật quyền người dùng: " + stennhanvien);
                }
            }
            if (kq.Trim().Equals("") == true && sidnhanvien.Trim().Equals("") == false)
            {

                MessageBox.Show("Cập nhật thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        #endregion
        public ucPhanQuyenNguoiDung()
        {
            InitializeComponent();
        }
        private void ucPhanQuyenNguoiDung_Load(object sender, EventArgs e)
        {
            CheckQuyenDL();
            treeQuyen.Enabled = false;
            LoadTKCBPB();
            LoadTKCBCV();
            cbTK_ChucVu.SelectedIndex = -1;
            cbTK_PhongBan.SelectedIndex = -1;
            FindUse();
            HienThiDuLieu();
        }
        #region Xử lý treeview
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
        #endregion
        #region Xử lý sự kiện trên lưới người dùng
        private void c1FlexGrid1_Click(object sender, EventArgs e)
        {
            if (c1FlexGrid1.Rows.Count - 1 > 0)
            {
                string sidnhanvien = "";
                try { sidnhanvien = c1FlexGrid1[c1FlexGrid1.RowSel, "idnhanvien"].ToString().Trim(); }
                catch { }
                if (sidnhanvien.Equals("") == false)
                {
                    HienThiDSQuyen(sidnhanvien);
                }
                else
                {
                    HienThiDSQuyen("-1");
                }
                string staikhoan = "";
                try { staikhoan = c1FlexGrid1[c1FlexGrid1.RowSel, "taikhoan"].ToString().Trim(); }
                catch { }
                //if (staikhoan.Trim().Equals("admin") == true)
                //{
                //    ultraToolbarsManager1.Tools["btn_Save"].SharedProps.Visible = false;
                //}
                //else { ultraToolbarsManager1.Tools["btn_Save"].SharedProps.Visible = true; }
            }
        }
        private void c1FlexGrid1_KeyDown(object sender, KeyEventArgs e)
        {
            c1FlexGrid1_Click(sender, e);
        }
        private void c1FlexGrid1_KeyUp(object sender, KeyEventArgs e)
        {
            c1FlexGrid1_Click(sender, e);
        }
        #endregion
        private void ultraToolbarsManager1_ToolClick(object sender, Infragistics.Win.UltraWinToolbars.ToolClickEventArgs e)
        {
            switch (e.Tool.Key)
            {
                case "btn_Save":    // ButtonTool
                    Save();
                    break;
            }
        }
    }
}
