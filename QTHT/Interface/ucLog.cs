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
    public partial class ucLog : UserControl
    {
        private logBL _ctrlog = new logBL();
        C1.Win.C1FlexGrid.CellRange cRange;

        #region Method
        private void CheckQuyenDL()
        {
            ultraToolbarsManager1.Tools["btn_Del"].SharedProps.Visible = false;
            ultraToolbarsManager1.Tools["btn_Del"].SharedProps.Enabled = false;
            try
            {
                quyennguoidung obj = new quyennguoidung();
                quyennguoidungBL ctr = new quyennguoidungBL();
                obj = ctr.GetByIDNhanVienvsMenuName(Data.iduse, "tsLog");
                string[] arrquyendl = obj.quyendl.Split(';');
                //Không check quyền cập nhật vì chỉ có thao tác xóa log
                //if (arrquyendl[0].Trim().Equals("EDIT") == true)
                //{
                //    ultraToolbarsManager1.Tools["btn_Add"].SharedProps.Visible = true;
                //    ultraToolbarsManager1.Tools["btn_Save"].SharedProps.Visible = true;
                //}
                if (arrquyendl[1].Trim().Equals("DEL") == true)
                {
                    ultraToolbarsManager1.Tools["btn_Del"].SharedProps.Visible = true;
                    ultraToolbarsManager1.Tools["btn_Del"].SharedProps.Enabled = true;
                }
            }
            catch
            {
                ultraToolbarsManager1.Tools["btn_Del"].SharedProps.Visible = false;
                ultraToolbarsManager1.Tools["btn_Del"].SharedProps.Enabled = false;
            }
        }
        private void HienThiDuLieu()
        {
            logBL ctrlog = new logBL();
            DataTable dt = new DataTable();
            DateTime dttungay = DateTime.Now;
            try { dttungay = dpkTuNgay.Value; }
            catch { }
            DateTime dtdenngay = DateTime.Now;
            try { dtdenngay = dpkDenNgay.Value; }
            catch { }
            dt = ctrlog.FindLogUseQueryNotHilight(txtKeyword.Text.Trim(), dttungay, dtdenngay);
            c1FlexGrid1.DataSource = dt;
            FormatGrid();
        }
        private void FormatGrid()
        {
            for (int i = 0; i < c1FlexGrid1.Cols.Count; i++)
            {
                if (i == 0)
                { c1FlexGrid1[0, i] = "STT"; c1FlexGrid1.Cols[i].Visible = true; c1FlexGrid1.Cols[i].Width = 60; }
                else if (c1FlexGrid1.Cols[i].Caption.Equals("thoigian"))
                { 
                    c1FlexGrid1[0, i] = "Thời gian";
                    c1FlexGrid1.Cols[i].Visible = true;
                    c1FlexGrid1.Cols[i].Format = "dd/MM/yyyy HH:mm:ss";
                    c1FlexGrid1.Cols[i].AllowEditing = false;
                }
                else if (c1FlexGrid1.Cols[i].Caption.Equals("iduser"))
                { c1FlexGrid1[0, i] = "Người dùng"; c1FlexGrid1.Cols[i].Visible = true; c1FlexGrid1.Cols[i].AllowEditing = false; }
                else if (c1FlexGrid1.Cols[i].Caption.Equals("thaotac"))
                { c1FlexGrid1[0, i] = "Thao tác"; c1FlexGrid1.Cols[i].Visible = true; c1FlexGrid1.Cols[i].AllowEditing = true; }
                else if (c1FlexGrid1.Cols[i].Caption.Equals("chon"))
                {
                    var cs = c1FlexGrid1.Styles.Add("Boolean");
                    //set DataType
                    cs.DataType = typeof(Boolean);
                    //Set any alignment
                    cs.ImageAlign = C1.Win.C1FlexGrid.ImageAlignEnum.CenterCenter;
                    c1FlexGrid1.SetCellStyle(0, i, cs);
                    c1FlexGrid1.Cols[i].AllowEditing = true;
                }
                else { c1FlexGrid1.Cols[i].Visible = false; }
                c1FlexGrid1.Cols[i].TextAlignFixed = TextAlignEnum.CenterCenter;
            }
            for (int j = 1; j < c1FlexGrid1.Rows.Count; j++)
            {
                c1FlexGrid1[j, 0] = j;
            }
            c1FlexGrid1.Cols[0].TextAlign = TextAlignEnum.CenterCenter;
            c1FlexGrid1.AutoSizeCols();
            c1FlexGrid1.AutoSizeRows();
        }
        private List<Int32> GetData()
        {
            try
            {
                List<Int32> lst = new List<Int32>();
                for (int i = 1; i < c1FlexGrid1.Rows.Count; i++)
                {
                    if (c1FlexGrid1.GetCellCheck(i, c1FlexGrid1.Cols["chon"].Index) == CheckEnum.Checked)
                    {
                        Int32 iid = 0;
                        try { iid = Convert.ToInt32(c1FlexGrid1[i, c1FlexGrid1.Cols["id"].Index].ToString().Trim()); }
                        catch { }
                        if (iid > 0)
                        {
                            lst.Add(iid);
                        }
                    }
                }
                return lst;
            }
            catch { return null; }
        }
        private void Delete()
        {
            string kq = "";
            int sumrecord = 0;
            if (MessageBox.Show("Xác nhận xóa nhật ký.", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                List<Int32> lst = new List<Int32>();
                lst = GetData();
                for (int i = 0; i < lst.Count; i++)
                {
                    try
                    {
                        kq = _ctrlog.Delete(lst[i]);
                        if (kq.Trim().Equals("") == true)
                        {
                            sumrecord = sumrecord + 1;
                        }
                    }
                    catch { }
                }
            }
            if (sumrecord > 0)
            {
                _ctrlog.Append(Data.use, "Xóa: " + sumrecord.ToString() + " bản ghi nhật ký hệ thống.");
                MessageBox.Show("Xóa nhật ký thành công.","Thông báo",MessageBoxButtons.OK,MessageBoxIcon.Information);
                HienThiDuLieu();
            }
        }
        #endregion

        public ucLog()
        {
            InitializeComponent();
        }

        private void ucLog_Load(object sender, EventArgs e)
        {
            try
            {
                CheckQuyenDL();
            }
            catch { }
            dpkDenNgay.Value = DateTime.Now;
            dpkTuNgay.Value = DateTime.Now.AddDays(-7);
            HienThiDuLieu();
        }

        #region Xử lý sự kiện trên grid
        private void c1FlexGrid1_AfterSelChange(object sender, RangeEventArgs e)
        {
            cRange = e.NewRange;
        }
        private void c1FlexGrid1_BeforeMouseDown(object sender, BeforeMouseDownEventArgs e)
        {
            if (c1FlexGrid1.HitTest().Type == HitTestTypeEnum.Checkbox)
            {
                if (cRange.r1 != cRange.r2)
                {
                    int col, row;
                    col = c1FlexGrid1.HitTest(e.X, e.Y).Column;
                    row = c1FlexGrid1.HitTest(e.X, e.Y).Row;
                    //Cancel the default mouse down action
                    e.Cancel = true;
                    C1.Win.C1FlexGrid.CheckEnum chValue = c1FlexGrid1.GetCellCheck(row, col);
                    List<DataRowView> drList = new List<DataRowView>();
                    for (int i = cRange.r1; i <= cRange.r2; i++)
                        drList.Add(c1FlexGrid1.Rows[i].DataSource as DataRowView);

                    foreach (DataRowView dr in drList)
                    {
                        switch (chValue)
                        {
                            case C1.Win.C1FlexGrid.CheckEnum.Checked:
                            case C1.Win.C1FlexGrid.CheckEnum.TSChecked:
                                dr["chon"] = false;
                                break;
                            case C1.Win.C1FlexGrid.CheckEnum.Unchecked:
                            case C1.Win.C1FlexGrid.CheckEnum.TSUnchecked:
                                dr["chon"] = true;
                                break;
                        }
                    }
                }
            }
        }
        private void c1FlexGrid1_AfterEdit(object sender, RowColEventArgs e)
        {
            if (e.Col == 1 && e.Row == 0)
            {
                if (c1FlexGrid1.GetCellCheck(e.Row, e.Col) == CheckEnum.Checked)
                {
                    for (int i = 1; i < c1FlexGrid1.Rows.Count; i++)
                    {
                        c1FlexGrid1.SetCellCheck(i, 1, C1.Win.C1FlexGrid.CheckEnum.Checked);
                    }
                }
                else
                {
                    for (int i = 1; i < c1FlexGrid1.Rows.Count; i++)
                    {
                        c1FlexGrid1.SetCellCheck(i, 1, C1.Win.C1FlexGrid.CheckEnum.Unchecked);
                    }
                }
            }
        }
        #endregion

        private void ultraToolbarsManager1_ToolClick(object sender, Infragistics.Win.UltraWinToolbars.ToolClickEventArgs e)
        {
            switch (e.Tool.Key)
            {
                case "btn_Del":    // ButtonTool
                    Delete();
                    break;
            }
        }

        #region Xử lý sự kiện Enter tìm kiếm
        private void btnSearch_Click(object sender, EventArgs e)
        {
            HienThiDuLieu();
        }
        private void txtKeyword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) { btnSearch_Click(sender, e); }
        }
        private void dpkTuNgay_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) { btnSearch_Click(sender, e); }
        }
        private void dpkDenNgay_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) { btnSearch_Click(sender, e); }
        }
        #endregion
    }
}
