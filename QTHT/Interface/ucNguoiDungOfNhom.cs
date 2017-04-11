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
    public partial class ucNguoiDungOfNhom : UserControl
    {
        private logBL _ctrlog = new logBL();

        #region Method cho người dùng
        private void CheckQuyenDL()
        {
            try
            {
                quyennguoidung obj = new quyennguoidung();
                quyennguoidungBL ctr = new quyennguoidungBL();
                obj = ctr.GetByIDNhanVienvsMenuName(Data.iduse, "tsUserOfGroup");
                string[] arrquyendl = obj.quyendl.Split(';');
                if (arrquyendl[0].Trim().Equals("EDIT") == true) 
                { ultraToolbarsManager1.Tools["btn_Save"].SharedProps.Visible = true; return; }
                else { ultraToolbarsManager1.Tools["btn_Save"].SharedProps.Visible = false; }
            }
            catch { ultraToolbarsManager1.Tools["btn_Save"].SharedProps.Visible = false; }
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
                HienThiDSNhom(sidnhanvien);
            }
            else { UncheckAllNodes(treeNhom.Nodes); }
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
        private void HienThiDSNhom(string sidnhanvien)
        {
            nhom_nhanvienBL ctr = new nhom_nhanvienBL();
            DataTable dt = new DataTable();
            dt = ctr.GetByIDNhanVien(sidnhanvien);
            UncheckAllNodes(treeNhom.Nodes);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                TreeNode[] arr = treeNhom.Nodes.Find(dt.Rows[i]["idnhom"].ToString().Trim(), true);
                if (arr.Length > 0) { arr[0].Checked = true; }
            }
            try
            {
                string sidnhom = "";
                sidnhom = dt.Rows[0]["idnhom"].ToString().Trim();
                DataTable dtquyennhom = new DataTable();
                quyen_nhomBL ctrquyennhom = new quyen_nhomBL();
                dtquyennhom = ctrquyennhom.GetByIDNhom(sidnhom);
                int iidmenu = 0;
                iidmenu = Convert.ToInt32(dtquyennhom.Rows[0]["menuid"].ToString().Trim());
                DataTable dtquyennd = new DataTable();
                quyennguoidungBL ctrquyennguoidung = new quyennguoidungBL();
                dtquyennd = ctrquyennguoidung.GetByIDNhanVien(sidnhanvien);
                string squyendl = "";
                for (int j = 0; j < dtquyennd.Rows.Count; j++)
                {
                    if (dtquyennd.Rows[j]["idmenu"].ToString().Trim().Equals(iidmenu.ToString()) == true)
                    {
                        squyendl = dtquyennd.Rows[0]["quyendl"].ToString().Trim();
                        break;
                    }
                }
                string[] arrquyendl = squyendl.Split(';');
                if (arrquyendl[0].Trim().Equals("EDIT") == true) { chbEdit.Checked = true; }
                else { chbEdit.Checked = false; }
                if (arrquyendl[1].Trim().Equals("DEL") == true) { chbDel.Checked = true; }
                else { chbDel.Checked = false; }
            }
            catch { }
        }
        #endregion
        #region Method cho danh sách quyền
        private void HienThiDSNhom()
        {
            DataTable dt = new DataTable();
            try
            {
                nhomBL ctr = new nhomBL();
                dt = ctr.GetAll();
                //TreeNode nodecha = treeNhom.Nodes.Add("-1", "DANH MỤC NHÓM NGƯỜI DÙNG");
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    TreeNode node = treeNhom.Nodes.Add(dt.Rows[i]["idnhom"].ToString().Trim(), dt.Rows[i]["tennhom"].ToString().Trim());
                }
            }
            catch { }
            treeNhom.ExpandAll();
        }
        #endregion
        #region Method Cập nhật
        private List<nhom_nhanvien> GetListNhom_NhanVien()
        {
            try
            {
                List<nhom_nhanvien> lst = new List<nhom_nhanvien>();
                string sidnhanvien = "";
                if (c1FlexGrid1.Rows.Count - 1 <= 0) { return null; }
                try { sidnhanvien = c1FlexGrid1[c1FlexGrid1.RowSel, "idnhanvien"].ToString().Trim(); }
                catch { }
                foreach (TreeNode tn in treeNhom.Nodes)
                {
                    if (tn.Checked == true)
                    {
                        nhom_nhanvien obj = new nhom_nhanvien();
                        obj.idnhanvien = sidnhanvien;
                        obj.idnhom = tn.Name.Trim();
                        obj.idnhom_nhanvien = Guid.NewGuid().ToString().Trim();
                        lst.Add(obj);
                    }
                }
                return lst;
            }
            catch { return null; }
        }
        private List<quyennguoidung> GetListQuyen(string sidnhom)
        {
            quyen_nhomBL ctr = new quyen_nhomBL();
            menuBL ctrmenu = new menuBL();
            try
            {
                List<quyennguoidung> lst = new List<quyennguoidung>();
                string sidnhanvien = "";
                if (c1FlexGrid1.Rows.Count - 1 <= 0) { return null; }
                try { sidnhanvien = c1FlexGrid1[c1FlexGrid1.RowSel, "idnhanvien"].ToString().Trim(); }
                catch { }
                DataTable dt = new DataTable();
                dt = ctr.GetByIDNhom(sidnhom);
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    menu objmenu = new menu();
                    objmenu = ctrmenu.GetByID(Convert.ToInt32(dt.Rows[i]["menuid"].ToString().Trim()));
                    if (objmenu != null)
                    {
                        quyennguoidung objquyennd = new quyennguoidung();
                        objquyennd.idmenu = objmenu.menuid;
                        objquyennd.idnhanvien = sidnhanvien;
                        objquyennd.kyhieucn = objmenu.menulink;
                        objquyennd.mota = objmenu.ghichu;
                        string sEdit = "";
                        if (chbEdit.Checked == true) { sEdit = "EDIT"; }
                        string sDel = "";
                        if (chbDel.Checked == true) { sDel = "DEL"; }
                        objquyennd.quyendl = sEdit + ";" + sDel;
                        objquyennd.status = Convert.ToBoolean(objmenu.status);
                        objquyennd.tenquyendl = objmenu.menuname;
                        lst.Add(objquyennd);
                    }
                }
                return lst;
            }
            catch { return null; }
        }
        private void Save()
        {
            string kq = "";
            nhomBL ctrnhom = new nhomBL();
            quyennguoidungBL ctrquyennd = new quyennguoidungBL();
            nhom_nhanvienBL ctrNhom_NhanVien = new nhom_nhanvienBL();
            List<nhom_nhanvien> lstNhom_NhanVien = new List<nhom_nhanvien>();
            lstNhom_NhanVien = GetListNhom_NhanVien();
            string sidnhanvien = "";
            try { sidnhanvien = c1FlexGrid1[c1FlexGrid1.RowSel, "idnhanvien"].ToString().Trim(); }
            catch { }
            string staikhoan = "";
            try { staikhoan = c1FlexGrid1[c1FlexGrid1.RowSel, "taikhoan"].ToString().Trim(); }
            catch { }
            string stennhanvien = "";
            try { stennhanvien = c1FlexGrid1[c1FlexGrid1.RowSel, "hoten"].ToString().Trim(); }
            catch { }
            //Xóa quyền người dùng thuộc nhóm cũ
            DataTable dt = new DataTable();
            dt = ctrNhom_NhanVien.GetByIDNhanVien(sidnhanvien);
            for (int k = 0; k < dt.Rows.Count; k++)
            {
                ctrquyennd.DeleteByIDNhomUse(sidnhanvien, dt.Rows[k]["idnhom"].ToString().Trim());
            }
            ctrNhom_NhanVien.DeleteByIDNhanVien(sidnhanvien);
            if (lstNhom_NhanVien != null)
            {
                for (int i = 0; i < lstNhom_NhanVien.Count; i++)
                {
                    kq = ctrNhom_NhanVien.Insert(lstNhom_NhanVien[i]);
                    if (kq.Trim().Equals("") == true)
                    {
                        List<quyennguoidung> lstquyennd = new List<quyennguoidung>();
                        lstquyennd = GetListQuyen(lstNhom_NhanVien[i].idnhom);
                        if (lstquyennd != null)
                        {
                            for (int j = 0; j < lstquyennd.Count; j++)
                            {
                                //Xóa tất cả các quyền thuộc nhóm mới (nếu trùng quyền đã có với quyền thuộc nhóm)
                                ctrquyennd.DeleteByIDMenuvsUse(sidnhanvien, lstquyennd[j].idmenu);
                                kq = ctrquyennd.Insert(lstquyennd[j]);
                            }
                        }
                        nhom objnhom = new nhom();
                        objnhom = ctrnhom.GetByID(lstNhom_NhanVien[i].idnhom);
                        string stennhom = "";
                        try { stennhom = objnhom.tennhom.Trim(); }
                        catch { stennhom = "-/-"; }
                        _ctrlog.Append(Data.use, "Phân quyền người dùng: " + stennhanvien + "(" + staikhoan + ") thuộc nhóm: " + stennhom);
                    }
                }
            }
            if (kq.Trim().Equals("") == true && sidnhanvien.Trim().Equals("") == false)
            {
                
                MessageBox.Show("Cập nhật thành công.","Thông báo",MessageBoxButtons.OK,MessageBoxIcon.Information);
            }
        }
        #endregion
        public ucNguoiDungOfNhom()
        {
            InitializeComponent();
        }
        #region Xử lý sự kiện tìm kiếm
        private void btnSearch_Click(object sender, EventArgs e)
        {
            FindUse();
        }
        private void cbTK_PhongBan_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) { btnSearch_Click(sender, e); }
        }
        private void cbTK_ChucVu_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) { btnSearch_Click(sender, e); }
        }
        private void txtTK_HoTen_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) { btnSearch_Click(sender, e); }
        }
        #endregion
        private void ucNguoiDungOfNhom_Load(object sender, EventArgs e)
        {
            CheckQuyenDL();
            HienThiDSNhom();
            LoadTKCBPB();
            LoadTKCBCV();
            cbTK_ChucVu.SelectedIndex = -1;
            cbTK_PhongBan.SelectedIndex = -1;
            FindUse();
        }
        private void ultraToolbarsManager1_ToolClick(object sender, Infragistics.Win.UltraWinToolbars.ToolClickEventArgs e)
        {
            switch (e.Tool.Key)
            {
                case "btn_Save":    // ButtonTool
                    Save();
                    break;
            }
        }
        #region Xử lý sự kiện trên lưới người dùng
        private void c1FlexGrid1_Click(object sender, EventArgs e)
        {
            if (c1FlexGrid1.Rows.Count - 1 > 0)
            {
                string sidnhanvien = "";
                try { sidnhanvien = c1FlexGrid1[c1FlexGrid1.RowSel, "idnhanvien"].ToString().Trim(); }
                catch { }
                string staikhoan = "";
                try { staikhoan = c1FlexGrid1[c1FlexGrid1.RowSel, "taikhoan"].ToString().Trim(); }
                catch { }
                HienThiDSNhom(sidnhanvien);
                //if (staikhoan.Trim().Equals("admin") == true)
                //{
                //    ultraToolbarsManager1.Tools["btn_Save"].SharedProps.Visible = false;
                //}
                //else { ultraToolbarsManager1.Tools["btn_Save"].SharedProps.Visible = true; }
            }
            else { UncheckAllNodes(treeNhom.Nodes); }
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
    }
}
