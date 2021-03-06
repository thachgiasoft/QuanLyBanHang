﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using C1.Win.C1FlexGrid;
using QTHT.BusinesLogic;
using HoaDonDataAccess.DataAccess;
using HoaDonDataAccess.BusinesLogic;
using DanhMuc.DataAccess;
using DanhMuc.BusinesLogic;
using CGCN.DataAccess;
using System.Globalization;
using DanhMuc.Interface;

namespace HoaDon.Interface
{
    public partial class ucTienThanhToan : UserControl
    {
        private logBL _ctrlog = new logBL();
        private string _sidhd = "";
        public string sidhd { get { return this._sidhd; } set { this._sidhd = value; } }

        #region Method
        private void HienThiTTHoaDon()
        {
            tblhoadonban objhd = new tblhoadonban();
            tblhoadonbanBL ctrhd = new tblhoadonbanBL();
            objhd = ctrhd.GetByID(sidhd);
            try{
                tblkhachhang objkh = new tblkhachhang();
                tblkhachhangBL ctrkh = new tblkhachhangBL();
                objkh = ctrkh.GetByID(objhd.id_khachhang.Trim());
                lbCapDL.Text = objkh.id_capdl;
                lbDiaChi.Text = objkh.diachi;
                lbDienThoai.Text = objkh.dt;
                lbNgayXuat.Text = objhd.ngaytao.ToString("dd/MM/yyyy HH:mm:ss");
                lbTenKH.Text = objkh.tenkh;
            }
            catch{
                lbCapDL.Text = "-/-";
                lbDiaChi.Text = "-/-";
                lbDienThoai.Text = "-/-";
                lbNgayXuat.Text = "-/-";
                lbTenKH.Text = "-/-";
            }
        }
        private void HienThiDS()
        {
            try
            {
                tbltienthanhtoanBL ctr = new tbltienthanhtoanBL();
                DataTable dt = new DataTable();
                dt = ctr.GetByIDHD(sidhd);
                dt.Columns.Add("tt", typeof(Int32));
                c1FlexGrid1.DataSource = dt;
                FormatGrid();
            }
            catch { }
        }
        private void FormatGrid()
        {
            tblhoadonbanBL ctr = new tblhoadonbanBL();
            for (int i = 0; i < c1FlexGrid1.Cols.Count; i++)
            {
                if (i == 0)
                { c1FlexGrid1[0, i] = "STT"; c1FlexGrid1.Cols[i].Visible = true; c1FlexGrid1.Cols[i].Width = 50; }
                else if (c1FlexGrid1.Cols[i].Caption.Equals("ngaytt"))
                {
                    c1FlexGrid1[0, i] = "Ngày thanh toán";
                    c1FlexGrid1.Cols[i].Visible = true;
                    c1FlexGrid1.Cols["ngaytt"].Format = "dd/MM/yyyy HH:mm:ss";
                    c1FlexGrid1.Cols[i].WidthDisplay = 210;
                }
                else if (c1FlexGrid1.Cols[i].Caption.Equals("tientt"))
                {
                    c1FlexGrid1[0, i] = "Tiền thanh toán";
                    c1FlexGrid1.Cols[i].Visible = true;
                    c1FlexGrid1.Cols["tientt"].Format = "N0";
                    c1FlexGrid1.Cols[i].WidthDisplay = 150;
                }
                else if (c1FlexGrid1.Cols[i].Caption.Equals("ghichu"))
                {
                    c1FlexGrid1[0, i] = "Ghi chú";
                    c1FlexGrid1.Cols[i].Visible = true;
                    c1FlexGrid1.Cols[i].WidthDisplay = 200;
                }
                else { c1FlexGrid1.Cols[i].Visible = false; }
                c1FlexGrid1.Cols[i].TextAlignFixed = TextAlignEnum.CenterCenter;
            }
            Font _font = new Font("Time new Roman", 14);
            c1FlexGrid1.Font = _font;
            for (int j = 1; j < c1FlexGrid1.Rows.Count; j++)
            {
                c1FlexGrid1[j, 0] = j;
                c1FlexGrid1[j, "tt"] = 0;
                //Kiểm tra có phải bản ghi từ hóa đơn không để ko cho sửa ngày thanh toán
                DateTime datetemp = Convert.ToDateTime(c1FlexGrid1[j, "ngaytt"].ToString().Trim());
                if (ctr.CheckExit(sidhd, datetemp) == true) { c1FlexGrid1.Rows[j].AllowEditing = false; }
                else { c1FlexGrid1.Rows[j].AllowEditing = true; }
            }
            c1FlexGrid1.Cols[0].TextAlign = TextAlignEnum.CenterCenter;
            c1FlexGrid1.AutoSizeCols();
            c1FlexGrid1.AutoSizeRows();
        }
        private List<tbltienthanhtoan> GetListTienThanhToan()
        {
            tblhoadonbanBL ctrhoadonban = new tblhoadonbanBL();
            tblhoadonban objhoadonban = new tblhoadonban();
            objhoadonban = ctrhoadonban.GetByID(sidhd);
            try
            {
                List<tbltienthanhtoan> lst = new List<tbltienthanhtoan>();
                for (int i = 1; i < c1FlexGrid1.Rows.Count; i++)
                {
                    tbltienthanhtoan obj = new tbltienthanhtoan();
                    if (c1FlexGrid1[i, "tt"].ToString().Trim().Equals("0") == false)
                    {
                        if (c1FlexGrid1[i, "tt"].ToString().Trim().Equals("1") == true) { obj.id = Guid.NewGuid().ToString(); }
                        else if (c1FlexGrid1[i, "tt"].ToString().Trim().Equals("2") == true) { obj.id = c1FlexGrid1[i, "id"].ToString().Trim(); }
                        if (sidhd.Trim().Equals("") == true)
                        {
                            MessageBox.Show("Không lấy được thông tin hóa đơn.\nVui lòng tắt chương trình và khởi động lại.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            c1FlexGrid1.Select(i, c1FlexGrid1.Cols["tientt"].Index);
                            return null;
                        }
                        try { obj.tientt = Convert.ToDouble(c1FlexGrid1[i, "tientt"].ToString().Trim()); }
                        catch
                        {
                            MessageBox.Show("Tiền thanh toán nhập không đúng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            c1FlexGrid1.Select(i, c1FlexGrid1.Cols["tientt"].Index);
                            return null;
                        }
                        if (obj.tientt == 0)
                        {
                            MessageBox.Show("Tiền thanh toán phải lớn hơn 0", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            c1FlexGrid1.Select(i, c1FlexGrid1.Cols["tientt"].Index);
                            return null;
                        }
                        obj.idhd = sidhd;
                        obj.ngaytt = Convert.ToDateTime(c1FlexGrid1[i, "ngaytt"].ToString().Trim());
                        if (objhoadonban.ngaytao == obj.ngaytt)
                        {
                            MessageBox.Show("Bản ghi này đã tồn tại.\nVui lòng nhập lại ngày thanh toán", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            c1FlexGrid1.Select(i, c1FlexGrid1.Cols["ngaytt"].Index);
                            return null;
                        }
                        obj.ghichu = c1FlexGrid1[i, "ghichu"].ToString().Trim();
                        lst.Add(obj);
                    }
                }
                return lst;
            }
            catch { return null; }
        }
        #endregion
        #region Method cập nhật
        private void Add()
        {
            c1FlexGrid1.Rows.Add();
            c1FlexGrid1[c1FlexGrid1.Rows.Count - 1, 0] = (c1FlexGrid1.Rows.Count - 1).ToString();
            c1FlexGrid1[c1FlexGrid1.Rows.Count - 1, "tt"] = 1;
            c1FlexGrid1[c1FlexGrid1.Rows.Count - 1, "ngaytt"] = DateTime.Now.ToString();
            c1FlexGrid1[c1FlexGrid1.Rows.Count - 1, 0] = (c1FlexGrid1.Rows.Count - 1).ToString();
            c1FlexGrid1.StartEditing(c1FlexGrid1.Rows.Count - 1, 3);
        }
        private void Save()
        {
            string kq = "";
            tbltienthanhtoanBL ctr = new tbltienthanhtoanBL();
            List<tbltienthanhtoan> lst = new List<tbltienthanhtoan>();
            lst = GetListTienThanhToan();
            for (int i = 0; i < lst.Count; i++)
            {
                tbltienthanhtoan temp = new tbltienthanhtoan();
                temp = ctr.GetByID(lst[i].id);
                if (temp == null)
                {
                    try
                    {
                        kq = ctr.Insert(lst[i]);
                    }
                    catch { break; }
                    _ctrlog.Append(Data.use, "Thêm mới tiền thanh toán ngày: " + lst[i].ngaytt.ToString("dd/MM/yyyy HH:mm:ss")
                        + " số tiền: " + lst[i].tientt.ToString("N0", CultureInfo.InvariantCulture)
                        + " cho hóa đơn của khách hàng: " + lbTenKH.Text
                        + " xuất ngày: " + lbNgayXuat.Text);
                }
                else
                {
                    try
                    {
                        kq = ctr.Update(lst[i]);
                    }
                    catch { break; }
                    _ctrlog.Append(Data.use, "Cập nhật tiền thanh toán ngày: " + lst[i].ngaytt.ToString("dd/MM/yyyy HH:mm:ss")
                         + " từ số tiền: " + temp.tientt.ToString("N0", CultureInfo.InvariantCulture)
                         + " thành số tiền: " + lst[i].tientt.ToString("N0", CultureInfo.InvariantCulture)
                         + " cho hóa đơn của khách hàng: " + lbTenKH.Text
                         + " xuất ngày: " + lbNgayXuat.Text);
                }
            }
            if (kq.Trim().Equals("") == true)
            {
                MessageBox.Show("Cập nhật tiền thanh toán cho hóa đơn thành công.","Thông báo",MessageBoxButtons.OK,MessageBoxIcon.Information);
                HienThiDS();
            }
        }
        private void Del()
        {
            tbltienthanhtoanBL ctr = new tbltienthanhtoanBL();
            if (c1FlexGrid1.Rows.Count - 1 > 0)
            {
                string sid = c1FlexGrid1[c1FlexGrid1.RowSel, "id"].ToString().Trim();
                if (sid.Trim().Equals("") == false)
                {
                    if (c1FlexGrid1.Rows[c1FlexGrid1.RowSel].AllowEditing == false)
                    {
                        MessageBox.Show("Bạn không thể xóa bản ghi này.\nĐể xóa được bạn vui lòng xóa hóa đơn bán.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return ;
                    }
                    tbltienthanhtoan temp = new tbltienthanhtoan();
                    temp = ctr.GetByID(sid);
                    string kq = "";
                    kq = ctr.Delete(sid);
                    if (kq.Trim().Equals("") == true)
                    {
                        try
                        {
                            _ctrlog.Append(Data.use, "Xóa tiền thanh toán ngày: " + temp.ngaytt.ToString("dd/MM/yyyy HH:mm:ss")
                                + " số tiền: " + temp.tientt.ToString("N0", CultureInfo.InvariantCulture)
                                + " cho hóa đơn của khách hàng: " + lbTenKH.Text
                                + " xuất ngày: " + lbNgayXuat.Text);
                        }
                        catch { }
                        MessageBox.Show("Xóa tiền thanh toán cho hóa đơn thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        HienThiDS();
                    }
                }
                else
                {
                    c1FlexGrid1.Rows.Remove(c1FlexGrid1.RowSel);
                }
            }
        }
        private void Cancel()
        {
            HienThiDS();
        }
        #endregion

        public ucTienThanhToan()
        {
            InitializeComponent();
        }

        private void ucTienThanhToan_Load(object sender, EventArgs e)
        {
            try
            {
                sidhd = ((frmTienThanhToan)this.FindForm()).sidhd;
                _sidhd = sidhd;
                HienThiTTHoaDon();
                HienThiDS();
                c1FlexGrid1.KeyActionEnter = KeyActionEnum.MoveAcross;
                c1FlexGrid1.Focus();
            }
            catch { }
        }

        private void ultraToolbarsManager1_ToolClick(object sender, Infragistics.Win.UltraWinToolbars.ToolClickEventArgs e)
        {
            switch (e.Tool.Key)
            {
                case "btn_Add":    // ButtonTool
                    c1FlexGrid1.Focus();
                    Add();
                    break;

                case "btn_Save":    // ButtonTool
                    c1FlexGrid1.Focus();
                    Save();
                    break;

                case "btn_Abort":    // ButtonTool
                    HienThiDS();
                    break;

                case "btn_Del":    // ButtonTool
                    Del();
                    break;
            }
        }

        #region Xử lý sự kiện trên grid
        private void c1FlexGrid1_AfterEdit(object sender, RowColEventArgs e)
        {
            try
            {
                c1FlexGrid1.AutoSizeRow(e.Row);
                int hang = c1FlexGrid1.Row;
                int cot = c1FlexGrid1.Cols.Count - 1;
                if (Convert.ToInt32(c1FlexGrid1[hang, cot]) == 0)
                {
                    c1FlexGrid1[c1FlexGrid1.RowSel, c1FlexGrid1.Cols.Count - 1] = 2;
                }
                if (c1FlexGrid1.Cols[c1FlexGrid1.ColSel].Name.ToUpper().Equals("GHICHU") == true && c1FlexGrid1.RowSel == c1FlexGrid1.Rows.Count - 1)
                {
                    Add(); c1FlexGrid1.StartEditing(c1FlexGrid1.Rows.Count - 1,2);
                }
            }
            catch { }
        }
        private void c1FlexGrid1_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.Control && e.KeyCode == Keys.A) || e.KeyCode == Keys.Add) { Add(); }
            if (e.Control && e.KeyCode == Keys.S) { Save(); }
            //if (e.KeyCode == Keys.Delete) { Del(); }
        }
        private void c1FlexGrid1_KeyUp(object sender, KeyEventArgs e)
        {
            c1FlexGrid1_KeyDown(sender, e);
        }
        #endregion
    }
}
