using System;
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
using HoaDon.Report;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using QTHT.DataAccess;

namespace HoaDon.Interface
{
    public partial class ucHoaDonTra : UserControl
    {
        private CellStyle cs1;
        private CellStyle cserror;
        private logBL _ctrlog = new logBL();

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
                obj = ctr.GetByIDNhanVienvsMenuName(Data.iduse, "tsImport");
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
        private void LoadCBTKKhachHang()
        {
            tblkhachhangBL ctr = new tblkhachhangBL();
            DataTable dt = new DataTable();
            dt = ctr.GetAll();
            cbTKKhachHang.DataSource = dt;
            cbTKKhachHang.DisplayMember = "tenkh";
            cbTKKhachHang.ValueMember = "id";
        }
        private void LoadCBKhachHang()
        {
            tblkhachhangBL ctr = new tblkhachhangBL();
            DataTable dt = new DataTable();
            dt = ctr.GetAll();
            cbKhachHang.DataSource = dt;
            cbKhachHang.DisplayMember = "tenkh";
            cbKhachHang.ValueMember = "id";
        }
        private void HienThiTTHoaDon(string sidhd)
        {
            try
            {
                tblhoadontra obj = new tblhoadontra();
                tblhoadontraBL ctr = new tblhoadontraBL();
                obj = ctr.GetByID(sidhd);
                txtID.Text = sidhd;
                cbKhachHang.SelectedValue = obj.id_khachhang;
                txtNgayXuat.Text = obj.ngaytao.ToString("dd/MM/yyyy HH:mm:ss");
                txtGhiChu.Text = obj.ghichu.Trim();
                tsStatus.Text = "Đang ở trạng thái cập nhật hóa đơn";
            }
            catch
            {
                HienThiDSMatHang("-1");
            }
        }
        private void HienThiDSHoaDon()
        {
            string skeyword = "";
            try { skeyword = cbTKKhachHang.Text.Trim(); }
            catch { }
            tblhoadontraBL ctr = new tblhoadontraBL();
            DataTable dt = new DataTable();
            dt = ctr.Filter(skeyword, dpkTKTuNgay.Value, dpkTKDenNgay.Value);
            flxHoaDon.DataSource = dt;
            FormatGridHoaDon();
            if (flxHoaDon.Rows.Count - 1 > 0)
            {
                flxHoaDon.Select(1, flxHoaDon.Cols["tenkh"].Index);
                HienThiTTHoaDon(flxHoaDon[1, "id"].ToString().Trim());
                HienThiDSMatHang(flxHoaDon[1, "id"].ToString().Trim());
            }
            groupBox2.Text = "Danh sách hóa đơn: " + dt.Rows.Count.ToString() + " bản ghi";
        }
        private void FormatGridHoaDon()
        {
            for (int i = 0; i < flxHoaDon.Cols.Count; i++)
            {
                if (i == 0)
                {
                    flxHoaDon[0, i] = "STT"; flxHoaDon.Cols[i].Visible = true;
                    flxHoaDon.Cols[i].Width = 60;
                }
                else if (flxHoaDon.Cols[i].Caption.Equals("tenkh"))
                {
                    flxHoaDon[0, i] = "Khách hàng";
                    flxHoaDon.Cols[i].Width = 160;
                    flxHoaDon.Cols[i].Visible = true;
                }
                else if (flxHoaDon.Cols[i].Caption.Equals("ngaytao"))
                {
                    flxHoaDon[0, i] = "Ngày xuất";
                    flxHoaDon.Cols[i].Width = 120;
                    flxHoaDon.Cols[i].Visible = true;
                    //flxHoaDon.Cols["ngaytao"].Format = "dd/MM/yyyy HH:mm:ss";
                    flxHoaDon.Cols["ngaytao"].Format = "dd/MM/yyyy";
                }
                else if (flxHoaDon.Cols[i].Caption.Equals("dt"))
                {
                    flxHoaDon[0, i] = "Điện thoại";
                    flxHoaDon.Cols[i].Width = 120;
                    flxHoaDon.Cols[i].Visible = true;
                }
                else { flxHoaDon.Cols[i].Visible = false; }
                flxHoaDon.Cols[i].TextAlignFixed = TextAlignEnum.CenterCenter;
            }
            Font _font = new Font("Time new Roman", 14);
            flxHoaDon.Font = _font;
            for (int j = 1; j < flxHoaDon.Rows.Count; j++)
            {
                flxHoaDon[j, 0] = j;
            }
            flxHoaDon.Cols[0].TextAlign = TextAlignEnum.CenterCenter;
            //flxHoaDon.AutoSizeCols();
            //flxHoaDon.AutoSizeRows();
        }
        private void HienThiDSMatHang(string sidhd)
        {
            try
            {
                DataTable dt = new DataTable();
                tblmathangtraBL ctr = new tblmathangtraBL();
                dt = ctr.GetByHDID(sidhd);
                dt.Columns.Add("tt", typeof(Int32));
                flxMatHang.DataSource = dt;
                FormatGridMatHang(sidhd);
            }
            catch { }
        }
        private void FormatGridMatHang(string sidhd)
        {
            for (int i = 0; i < flxMatHang.Cols.Count; i++)
            {
                if (i == 0)
                { flxMatHang[0, i] = "STT"; flxMatHang.Cols[i].Visible = true; flxMatHang.Cols[i].Width = 60; }
                else if (flxMatHang.Cols[i].Caption.Equals("mathang") == true)
                {
                    flxMatHang[0, i] = "Mặt hàng(*)";
                    flxMatHang.Cols[i].Visible = true;
                    flxMatHang.Cols[i].ComboList = "...";
                }
                else if (flxMatHang.Cols[i].Caption.Equals("soluong") == true)
                {
                    flxMatHang[0, i] = "Số lượng (*)";
                    flxMatHang.Cols[i].Visible = true;
                    flxMatHang.Cols["soluong"].Format = "N0";
                }
                else if (flxMatHang.Cols[i].Caption.Equals("donvi") == true)
                {
                    flxMatHang[0, i] = "Đơn vị";
                    flxMatHang.Cols[i].Visible = true;
                    flxMatHang.Cols["donvi"].AllowEditing = false;
                }
                else if (flxMatHang.Cols[i].Caption.Equals("gianhaplai") == true)
                {
                    flxMatHang[0, i] = "Giá nhập lại(*)";
                    flxMatHang.Cols[i].Visible = true;
                    flxMatHang.Cols["gianhaplai"].Format = "N0";
                }
                else if (flxMatHang.Cols[i].Caption.Equals("ghichu") == true)
                {
                    flxMatHang[0, i] = "Ghi chú";
                    flxMatHang.Cols[i].Visible = true;
                }
                else if (flxMatHang.Cols[i].Caption.Equals("thanhtien") == true)
                {
                    flxMatHang[0, i] = "Thành tiền";
                    flxMatHang.Cols[i].Visible = true;
                    flxMatHang.Cols["thanhtien"].AllowEditing = false;
                    flxMatHang.Cols["thanhtien"].Format = "N0";
                }
                else { flxMatHang.Cols[i].Visible = false; }
                flxMatHang.Cols[i].TextAlignFixed = TextAlignEnum.CenterCenter;
            }
            Font _font = new Font("Time new Roman", 14);
            flxMatHang.Font = _font;
            double tongtien = 0;
            for (int j = 1; j < flxMatHang.Rows.Count; j++)
            {
                flxMatHang[j, 0] = j;
                flxMatHang[j, "tt"] = 0;
                tongtien = tongtien + Convert.ToDouble(flxMatHang[j, "thanhtien"].ToString().Trim());
            }
            txtTongTien.Text = tongtien.ToString("N0", CultureInfo.InvariantCulture);
            flxMatHang.Cols[0].TextAlign = TextAlignEnum.CenterCenter;
            flxMatHang.AutoSizeCols();
            flxMatHang.AutoSizeRows();
        }
        private void XuatHoaDon()
        {
            string sidhd = "";
            try { sidhd = txtID.Text.Trim(); }
            catch { }
            if (sidhd.Trim().Equals("") == false && sidhd.Trim().Equals("-1") == false)
            {
                Application.DoEvents();
                tsProgressBar1.Visible = true;
                tsProgressBar1.PerformStep();
                DataTable dt = new DataTable();
                dt = (DataTable)flxMatHang.DataSource;
                Application.DoEvents();
                tsProgressBar1.PerformStep();
                frmHoaDonTra frm = new frmHoaDonTra();
                rptHoaDonTra _rptHoaDonBan = new rptHoaDonTra();
                ReportDocument reportDocument = new ReportDocument();
                ParameterFields pfields = new ParameterFields();
                #region Khai báo parametter tiêu đề ngày tháng
                ParameterField pTenKH = new ParameterField();
                ParameterDiscreteValue dispTenKH = new ParameterDiscreteValue();
                ParameterField pDienThoai = new ParameterField();
                ParameterDiscreteValue dispDienThoai = new ParameterDiscreteValue();
                ParameterField pNgayXuat = new ParameterField();
                ParameterDiscreteValue dispNgayXuat = new ParameterDiscreteValue();
                ParameterField pGhiChu = new ParameterField();
                ParameterDiscreteValue disGhiChu = new ParameterDiscreteValue();
                string tenKH = "";
                string DT = "";
                string ngayXuat = "";
                string ghiChu = "";
                tenKH = cbKhachHang.Text.Trim();
                DT = txtDienThoai.Text.Trim();
                ngayXuat = txtNgayXuat.Text.Trim();
                ghiChu = txtGhiChu.Text.Trim();
                Application.DoEvents();
                tsProgressBar1.PerformStep();
                dispTenKH.Value = tenKH;
                pTenKH.Name = "pTenKH";
                pTenKH.CurrentValues.Add(dispTenKH);
                pfields.Add(pTenKH);
                Application.DoEvents();
                tsProgressBar1.PerformStep();
                dispDienThoai.Value = DT;
                pDienThoai.Name = "pDienThoai";
                pDienThoai.CurrentValues.Add(dispDienThoai);
                pfields.Add(pDienThoai);
                Application.DoEvents();
                tsProgressBar1.PerformStep();
                dispNgayXuat.Value = ngayXuat;
                pNgayXuat.Name = "pNgayXuat";
                pNgayXuat.CurrentValues.Add(dispNgayXuat);
                pfields.Add(pNgayXuat);
                Application.DoEvents();
                tsProgressBar1.PerformStep();
                Application.DoEvents();
                tsProgressBar1.PerformStep();
                Application.DoEvents();
                tsProgressBar1.PerformStep();
                disGhiChu.Value = ghiChu;
                pGhiChu.Name = "pGhiChu";
                pGhiChu.CurrentValues.Add(disGhiChu);
                pfields.Add(pGhiChu);
                Application.DoEvents();
                tsProgressBar1.PerformStep();
                #endregion
                Application.DoEvents();
                tsProgressBar1.PerformStep();
                frm.crystalReportViewer1.ParameterFieldInfo = pfields;
                Application.DoEvents();
                tsProgressBar1.PerformStep();
                frm.crystalReportViewer1.ReportSource = _rptHoaDonBan;
                Application.DoEvents();
                tsProgressBar1.PerformStep();
                _rptHoaDonBan.SetDataSource(dt);
                Application.DoEvents();
                tsProgressBar1.Value = tsProgressBar1.Maximum;
                frm.ShowDialog();
                Application.DoEvents();
                tsProgressBar1.Value = 0;
                tsProgressBar1.Visible = false;
            }
        }
        #endregion
        #region Method Cập nhật
        private void Add()
        {
            tsStatus.Text = "Đang ở trạng thái thêm mới hóa đơn";
            txtNgayXuat.Text = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
            cbKhachHang.SelectedValue = "";
            txtID.Text = "-1";
            cbKhachHang.Text = "";
            txtDienThoai.Text = "";
            cbCapDL.Text = "";
            txtDiaChi.Text = "";
            HienThiDSMatHang("-1");
            txtTongTien.Text = "0";
            cbKhachHang.Focus();
        }
        private void AddMatHang()
        {
            try
            {
                flxMatHang.Rows.Add();
                flxMatHang[flxMatHang.Rows.Count - 1, "tt"] = 1;
                flxMatHang[flxMatHang.Rows.Count - 1, "id"] = "";
                flxMatHang[flxMatHang.Rows.Count - 1, 0] = (flxMatHang.Rows.Count - 1).ToString();
                flxMatHang.Select(flxMatHang.Rows.Count - 1, flxMatHang.Cols["mathang"].Index);
                //flxMatHang.Rows[flxMatHang.Rows.Count - 1].Selected = true;
            }
            catch { }
        }
        private void Save()
        {
            string kq = "";
            tbltienthanhtoanBL ctrtientt = new tbltienthanhtoanBL();
            tblmathangBL ctrmathang = new tblmathangBL();
            tblhoadontraBL ctrhoadon = new tblhoadontraBL();
            tblhoadontra objhoadon = new tblhoadontra();
            objhoadon = GetDataHoaDon();
            tblmathangtraBL ctrmathangban = new tblmathangtraBL();
            List<tblmathangtra> lstmathang = new List<tblmathangtra>();
            lstmathang = GetListMatHangTra();
            if (lstmathang != null)
            {
                if (objhoadon != null && lstmathang.Count > 0)
                {
                    if (txtID.Text.Trim().Equals("-1") == true)
                    {
                        kq = ctrhoadon.Insert(objhoadon);
                    }
                    else
                    {
                        kq = ctrhoadon.Update(objhoadon);
                    }
                    if (kq.Trim().Equals("") == true)
                    {
                        _ctrlog.Append(Data.use, "Sửa hóa đơn trả lại hàng của khách hàng: " + cbKhachHang.Text.Trim() + " ; id: " + objhoadon.id);
                        for (int i = 0; i < lstmathang.Count; i++)
                        {
                            tblmathangtra temp = new tblmathangtra();
                            temp = ctrmathangban.GetByID(lstmathang[i].id);
                            if (temp == null)
                            {
                                lstmathang[i].id_hoadon = objhoadon.id;
                                kq = ctrmathangban.Insert(lstmathang[i]);
                                if (kq.Trim().Equals("") == false)
                                {
                                    ctrhoadon.Delete(objhoadon.id);
                                    break;
                                }
                                else //Cập nhật lại số lượng còn trong kho
                                {
                                    tblmathang objmathang = new tblmathang();
                                    objmathang = ctrmathang.GetByID(lstmathang[i].id_mathang.Trim());
                                    objmathang.soluong = objmathang.soluong + lstmathang[i].soluong;
                                    ctrmathang.Update(objmathang);
                                }
                            }
                            else
                            {
                                lstmathang[i].id_hoadon = objhoadon.id;
                                kq = ctrmathangban.Update(lstmathang[i]);
                                if (kq.Trim().Equals("") == false)
                                {
                                    break;
                                }
                                else //Cập nhật lại số lượng còn trong kho
                                {
                                    tblmathang objmathang = new tblmathang();
                                    objmathang = ctrmathang.GetByID(lstmathang[i].id_mathang.Trim());
                                    objmathang.soluong = (objmathang.soluong - temp.soluong) + lstmathang[i].soluong;
                                    ctrmathang.Update(objmathang);
                                }
                            }
                        }
                        if (kq.Trim().Equals("") == false)
                        {
                            MessageBox.Show("Lỗi cập nhật hóa đơn trả lại hàng.\nChi tiết lỗi: " + kq, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                        else
                        {
                            if (txtID.Text.Trim().Equals("-1") == true)
                            {
                                txtID.Text = objhoadon.id.Trim();
                                _ctrlog.Append(Data.use, "Thêm mới hóa đơn trả lại hàng cho khách hàng: " + cbKhachHang.Text.Trim() + " ; id: " + objhoadon.id);
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Lỗi cập nhật hóa đơn trả lại hàng.\nChi tiết lỗi: " + kq, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
            }
            if (kq.Trim().Equals("") == true && lstmathang != null)
            {
                MessageBox.Show("Cập nhật hóa đơn trả lại hàng thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                HienThiDSHoaDon();
                int irowsfind = 0;
                irowsfind = flxHoaDon.FindRow(objhoadon.id, 1, flxHoaDon.Cols["id"].Index, true);
                flxHoaDon.Select(irowsfind, flxHoaDon.Cols["ngaytao"].Index, true);
                string sidhdtemp = ""; try { sidhdtemp = flxHoaDon[irowsfind, "id"].ToString().Trim(); }
                catch { }
                HienThiTTHoaDon(sidhdtemp);
                HienThiDSMatHang(sidhdtemp);
            }
        }
        private void DelMatHang()
        {
            tblmathangBL ctrmathang = new tblmathangBL();
            tblmathangtraBL ctr = new tblmathangtraBL();
            string kq = "";
            string sid = "";
            try { sid = flxMatHang[flxMatHang.RowSel, "id"].ToString().Trim(); }
            catch { }
            if (sid.Trim().Equals("") == true)
            {
                flxMatHang.Rows.Remove(flxMatHang.RowSel);
                for (int j = 1; j < flxMatHang.Rows.Count; j++)
                {
                    flxMatHang[j, 0] = j;
                }
            }
            else
            {
                if (MessageBox.Show("Xác nhận xóa dữ liệu?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    //Cập nhật lại số lượng
                    tblmathang objmathang = new tblmathang();
                    string sidmathang = flxMatHang[flxMatHang.RowSel, "id_mathang"].ToString().Trim();
                    objmathang = ctrmathang.GetByID(sidmathang);
                    tblmathangtra objmathangtra = new tblmathangtra();
                    objmathangtra = ctr.GetByID(sid);
                    objmathang.soluong = objmathangtra.soluong + objmathang.soluong;
                    kq = ctr.Delete(sid);
                    if (kq.Trim().Equals("") == true)
                    {
                        ctrmathang.Update(objmathang);
                        flxMatHang.Rows.Remove(flxMatHang.RowSel);
                        double tongtien = 0;
                        for (int j = 1; j < flxMatHang.Rows.Count; j++)
                        {
                            flxMatHang[j, 0] = j;
                            try { tongtien = tongtien + Convert.ToDouble(flxMatHang[j, "thanhtien"].ToString().Trim()); }
                            catch { }
                        }
                        txtTongTien.Text = tongtien.ToString("N0", CultureInfo.InvariantCulture);
                    }
                }
            }
        }
        private void UpdateSoLuongMatHang(string sidhd)
        {
            tblmathangtraBL ctrmathangban = new tblmathangtraBL();
            tblmathangBL ctrmathang = new tblmathangBL();
            DataTable dt = new DataTable();
            dt = ctrmathangban.GetByHDID(sidhd);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                string sidmathang = "";
                try { sidmathang = dt.Rows[i]["id_mathang"].ToString().Trim(); }
                catch { }
                string sidmathangban = "";
                try { sidmathangban = dt.Rows[i]["id"].ToString().Trim(); }
                catch { }
                if (sidmathang.Trim().Equals("") == false && sidmathangban.Trim().Equals("") == false)
                {
                    tblmathangtra objmathangban = new tblmathangtra();
                    objmathangban = ctrmathangban.GetByID(sidmathangban);
                    tblmathang objmathang = new tblmathang();
                    objmathang = ctrmathang.GetByID(sidmathang);
                    objmathang.soluong = objmathang.soluong - objmathangban.soluong;
                    try { ctrmathang.Update(objmathang); }
                    catch { }
                }
            }
        }
        private void Del()
        {
            tblhoadontraBL ctr = new tblhoadontraBL();
            string kq = "";
            string sidhd = "";
            try { sidhd = flxHoaDon[flxHoaDon.RowSel, "id"].ToString().Trim(); }
            catch { }
            string sidkh = "";
            try { sidkh = flxHoaDon[flxHoaDon.RowSel, "id_khachhang"].ToString().Trim(); }
            catch { }
            string stenkh = "";
            tblkhachhangBL ctrkh = new tblkhachhangBL();
            try { stenkh = ctrkh.GetByID(sidkh).tenkh.Trim(); }
            catch { stenkh = "-/-"; }

            if (MessageBox.Show("Xác nhận xóa dữ liệu?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                UpdateSoLuongMatHang(sidhd);
                kq = ctr.Delete(sidhd);
                if (kq.Trim().Equals("") == true)
                {
                    _ctrlog.Append(Data.use, "Xóa hóa đơn trả lại hàng của khách hàng: " + stenkh);
                    flxHoaDon.Rows.Remove(flxHoaDon.RowSel);
                    if (flxHoaDon.Rows.Count - 1 > 0)
                    {
                        try { sidhd = flxHoaDon[1, "id"].ToString().Trim(); }
                        catch { }
                        HienThiTTHoaDon(sidhd);
                        HienThiDSMatHang(sidhd);
                    }
                    else { Add(); HienThiDSMatHang("-1"); }
                }
                else
                {
                    MessageBox.Show("Xóa hóa đơn trả lại hàng không thành công.\nChi tiết lỗi: " + kq, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
        }
        #endregion
        #region GetData
        private void RemoveColor()
        {
            for (int i = 1; i < flxMatHang.Rows.Count; i++)
            {
                flxMatHang.Rows[i].Style = cs1;
            }
        }
        private bool CheckMatHang(string sidmathang, int irow)
        {
            bool kt = false;
            for (int i = 1; i < flxMatHang.Rows.Count; i++)
            {
                flxMatHang.Rows[i].Style = cs1;
                string sidmathangtemp = "";
                try { sidmathangtemp = flxMatHang[i, "id_mathang"].ToString().Trim(); }
                catch { }
                if (sidmathang.Trim().Equals("") == false && sidmathang.Trim().Equals(sidmathangtemp) == true && i != irow)
                {
                    flxMatHang.Rows[i].Style = cserror;
                    kt = true;
                }
            }
            return kt;
        }
        private bool CheckMatHangByMaVach(string sidmathang)
        {
            bool kt = false;
            for (int i = 1; i < flxMatHang.Rows.Count; i++)
            {
                flxMatHang.Rows[i].Style = cs1;
                string sidmathangtemp = "";
                try { sidmathangtemp = flxMatHang[i, "id_mathang"].ToString().Trim(); }
                catch { }
                if (sidmathang.Trim().Equals("") == false && sidmathang.Trim().Equals(sidmathangtemp) == true)
                {
                    flxMatHang.Rows[i].Style = cserror;
                    kt = true;
                }
            }
            return kt;
        }
        private tblhoadontra GetDataHoaDon()
        {
            tblhoadontra obj = new tblhoadontra();
            string sidkh = "";
            try { sidkh = cbKhachHang.SelectedValue.ToString().Trim(); }
            catch { }
            if (sidkh.Trim().Equals("") == true)
            {
                MessageBox.Show("Khách hàng chưa được chọn.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cbKhachHang.Focus();
                return null;
            }
            if (txtID.Text.Equals("-1") == true) { obj.id = Guid.NewGuid().ToString(); }
            else { obj.id = txtID.Text.Trim(); }
            obj.id_khachhang = sidkh;
            obj.ghichu = txtGhiChu.Text.Trim();
            obj.ngaytao = DateTime.ParseExact(
                txtNgayXuat.Text.Trim(),
                "dd/MM/yyyy HH:mm:ss",
                CultureInfo.InvariantCulture);
            return obj;
        }
        private List<tblmathangtra> GetListMatHangTra()
        {
            tblmathangBL ctrmathang = new tblmathangBL();
            tblmathangtraBL ctrmathangban = new tblmathangtraBL();
            try
            {
                List<tblmathangtra> lst = new List<tblmathangtra>();
                for (int i = 1; i < flxMatHang.Rows.Count; i++)
                {
                    if (flxMatHang[i, "tt"].ToString().Trim().Equals("1") == true || flxMatHang[i, "tt"].ToString().Trim().Equals("2") == true)
                    {
                        tblmathangtra obj = new tblmathangtra();
                        if (flxMatHang[i, "tt"].ToString().Trim().Equals("1") == true) { obj.id = Guid.NewGuid().ToString(); }
                        else { obj.id = flxMatHang[i, "id"].ToString().Trim(); }
                        try { obj.soluong = Convert.ToInt32(flxMatHang[i, "soluong"].ToString().Trim()); }
                        catch { obj.soluong = 0; }
                        try { obj.gianhaplai = Convert.ToDouble(flxMatHang[i, "gianhaplai"].ToString().Trim()); }
                        catch { obj.gianhaplai = 0; }
                        if (flxMatHang[i, "id_mathang"].ToString().Trim().Equals("") == false || obj.soluong > 0)
                        {
                            if (flxMatHang[i, "id_mathang"].ToString().Trim().Equals("") == true)
                            {
                                MessageBox.Show("Mặt hàng chưa được nhập", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                flxMatHang.Select(i, flxMatHang.Cols["mathang"].Index);
                                flxMatHang.SetUserData(i, 0, "Mặt hàng chưa được nhập");
                                flxMatHang.Rows[i].Style = cs1;
                                return null;
                            }
                            if (obj.gianhaplai == 0)
                            {
                                MessageBox.Show("Giá nhập lại chưa được nhập", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                flxMatHang.Select(i, flxMatHang.Cols["gianhaplai"].Index);
                                flxMatHang.SetUserData(i, 0, "Giá nhập lại chưa được nhập");
                                flxMatHang.Rows[i].Style = cs1;
                                return null;
                            }
                            if (obj.soluong == 0)
                            {
                                MessageBox.Show("Số lượng hàng nhập lại phải lớn hơn 0", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                flxMatHang.Select(i, flxMatHang.Cols["soluong"].Index);
                                flxMatHang.SetUserData(i, 0, "Số lượng hàng nhập lại phải lớn hơn 0");
                                flxMatHang.Rows[i].Style = cs1;
                                return null;
                            }
                            obj.id_mathang = flxMatHang[i, "id_mathang"].ToString().Trim();
                            //obj.gianhaplai = Convert.ToDouble(flxMatHang[i, "gianhaplai"].ToString().Trim());
                            try { obj.ghichu = flxMatHang[i, "ghichu"].ToString().Trim(); }
                            catch { obj.ghichu = ""; }
                            obj.ngaytao = DateTime.Now;
                            lst.Add(obj);
                        }
                    }
                }
                return lst;
            }
            catch { return null; }
        }
        #endregion
        public ucHoaDonTra()
        {
            InitializeComponent();
        }
        #region tsMenu mặt hàng trả
        private void tsThemMoiMatHangBan_Click(object sender, EventArgs e)
        {
            AddMatHang();
        }
        private void tsXoaMatHangBan_Click(object sender, EventArgs e)
        {
            DelMatHang();
        }
        private void tsHuyMatHangBan_Click(object sender, EventArgs e)
        {
            flxHoaDon_Click(sender, e);
        }
        #endregion
        #region Xử lý tìm kiếm
        private void dpkTKDenNgay_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnTim_Click(sender, e);
            }
        }
        private void dpkTKTuNgay_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnTim_Click(sender, e);
            }
        }
        private void cbTKKhachHang_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnTim_Click(sender, e);
            }
        }
        private void btnTim_Click(object sender, EventArgs e)
        {
            HienThiDSHoaDon();
            if (flxHoaDon.Rows.Count - 1 > 0)
            {
                flxHoaDon.Select(1, flxHoaDon.Cols["tenkh"].Index);
                HienThiTTHoaDon(flxHoaDon[1, "id"].ToString().Trim());
                HienThiDSMatHang(flxHoaDon[1, "id"].ToString().Trim());
            }
        }
        #endregion
        #region Xử lý sự kiện trên lưới danh sách hóa đơn
        private void flxHoaDon_Click(object sender, EventArgs e)
        {
            string sidhd = "";
            try { sidhd = flxHoaDon[flxHoaDon.RowSel, "id"].ToString().Trim(); }
            catch { }
            HienThiTTHoaDon(sidhd);
            HienThiDSMatHang(sidhd);
        }
        private void flxHoaDon_KeyDown(object sender, KeyEventArgs e)
        {
            flxHoaDon_Click(sender, e);
        }
        private void flxHoaDon_KeyUp(object sender, KeyEventArgs e)
        {
            flxHoaDon_Click(sender, e);
        }
        #endregion
        #region Xử lý sự kiện chọn khách hàng
        private void btnUpdateKH_Click(object sender, EventArgs e)
        {
            frmKhachHang frm = new frmKhachHang();
            frm.type = 1;
            frm.ShowDialog();
            LoadCBKhachHang();
            LoadCBTKKhachHang();
            string sidkh = "";
            try
            {
                sidkh = frm.sreturn;
                if (sidkh.Trim().Equals("") == true)
                {
                    sidkh = cbKhachHang.SelectedValue.ToString().Trim();
                }
                else
                {
                    cbKhachHang.SelectedValue = sidkh;
                }
            }
            catch { }
        }
        private void cbKhachHang_SelectedIndexChanged(object sender, EventArgs e)
        {
            tblmathangBL ctrmathang = new tblmathangBL();
            string sidkh = "";
            try { sidkh = cbKhachHang.SelectedValue.ToString().Trim(); }
            catch { }
            tblkhachhang obj = new tblkhachhang();
            tblkhachhangBL ctr = new tblkhachhangBL();
            obj = ctr.GetByID(sidkh);
            try
            {
                cbCapDL.Text = obj.id_capdl;
                txtDiaChi.Text = obj.diachi;
                txtDienThoai.Text = obj.dt.Trim();
                try
                {
                    double tongtien = 0;
                    for (int i = 1; i < flxMatHang.Rows.Count; i++)
                    {
                        try
                        {
                            string sidmathang = "";
                            try { sidmathang = flxMatHang[i, "id_mathang"].ToString(); }
                            catch { }
                            tblmathang objmathang = new tblmathang();
                            objmathang = ctrmathang.GetByID(sidmathang);
                            try
                            {
                                if (cbCapDL.Text.ToUpper().Trim().Equals("ĐẠI LÝ CẤP 1") == true)
                                {
                                    flxMatHang[i, "gianhaplai"] = objmathang.giadl1.ToString().Trim();
                                    try { flxMatHang[i, "thanhtien"] = Convert.ToInt32(flxMatHang[i, "soluong"]) * objmathang.giadl1; }
                                    catch { }
                                }
                                if (cbCapDL.Text.ToUpper().Trim().Equals("ĐẠI LÝ CẤP 2") == true)
                                {
                                    flxMatHang[i, "gianhaplai"] = objmathang.giadl2.ToString().Trim();
                                    try { flxMatHang[i, "thanhtien"] = Convert.ToInt32(flxMatHang[i, "soluong"]) * objmathang.giadl2; }
                                    catch { }
                                }
                                if (cbCapDL.Text.ToUpper().Trim().Equals("ĐẠI LÝ CẤP 3") == true)
                                {
                                    flxMatHang[i, "gianhaplai"] = objmathang.giadl3.ToString().Trim();
                                    try { flxMatHang[i, "thanhtien"] = Convert.ToInt32(flxMatHang[i, "soluong"]) * objmathang.giadl3; }
                                    catch { }
                                }
                                if (cbCapDL.Text.ToUpper().Trim().Equals("ĐẠI LÝ CẤP 4") == true)
                                {
                                    flxMatHang[i, "gianhaplai"] = objmathang.giadl4.ToString().Trim();
                                    try { flxMatHang[i, "thanhtien"] = Convert.ToInt32(flxMatHang[i, "soluong"]) * objmathang.giadl4; }
                                    catch { }
                                }
                                if (cbCapDL.Text.ToUpper().Trim().Equals("ĐẠI LÝ CẤP 5") == true)
                                {
                                    flxMatHang[i, "gianhaplai"] = objmathang.giadl5.ToString().Trim();
                                    try { flxMatHang[i, "thanhtien"] = Convert.ToInt32(flxMatHang[i, "soluong"]) * objmathang.giadl5; }
                                    catch { }
                                }
                                if (cbCapDL.Text.ToUpper().Trim().Equals("KHÁCH LẺ") == true)
                                {
                                    flxMatHang[i, "gianhaplai"] = objmathang.giadl5.ToString().Trim();
                                    try { flxMatHang[i, "thanhtien"] = Convert.ToInt32(flxMatHang[i, "soluong"]) * objmathang.giadl5; }
                                    catch { }
                                }
                            }
                            catch
                            {
                                flxMatHang[i, "gianhaplai"] = objmathang.giadl5.ToString().Trim();
                                try { flxMatHang[i, "thanhtien"] = Convert.ToInt32(flxMatHang[i, "soluong"]) * objmathang.giadl5; }
                                catch { }
                            }
                            tongtien = tongtien + Convert.ToDouble(flxMatHang[i, "thanhtien"].ToString().Trim());
                        }
                        catch { }
                    }
                    txtTongTien.Text = tongtien.ToString("N0", CultureInfo.InvariantCulture);
                }
                catch { }
            }
            catch
            {
                cbCapDL.Text = "";
                txtDiaChi.Text = "";
                txtDienThoai.Text = "";
                txtTongTien.Text = "0";
            }
        }
        private void cbKhachHang_TextChanged(object sender, EventArgs e)
        {
            cbKhachHang_SelectedIndexChanged(sender, e);
        }
        #endregion
        #region Xử lý sự kiện trên lưới danh sách mặt hàng
        private void flxMatHang_AfterEdit(object sender, C1.Win.C1FlexGrid.RowColEventArgs e)
        {
            try
            {
                int hang = flxMatHang.Row;
                if (Convert.ToInt32(flxMatHang[hang, "tt"]) == 0)
                {
                    flxMatHang[flxMatHang.RowSel, flxMatHang.Cols.Count - 1] = 2;
                }
                if (flxMatHang.Cols[flxMatHang.ColSel].Name.ToLower().Equals("gianhaplai") == true && flxMatHang.RowSel == flxMatHang.Rows.Count - 1)
                {
                    if (flxMatHang.RowSel == flxMatHang.Rows.Count - 1)
                    {
                        AddMatHang();
                        flxMatHang.StartEditing(flxMatHang.Rows.Count - 1, 3);
                    }
                    else
                    {
                        flxMatHang.StartEditing(flxMatHang.RowSel + 1, 3);
                    }
                    //AddMatHang(); flxMatHang.StartEditing(flxMatHang.Rows.Count - 1, 3);
                }
                flxMatHang[flxMatHang.RowSel, "thanhtien"] = (Convert.ToDouble(flxMatHang[flxMatHang.RowSel, "soluong"].ToString().Trim()) * Convert.ToDouble(flxMatHang[flxMatHang.RowSel, "gianhaplai"].ToString().Trim())).ToString();
                flxMatHang.AutoSizeCols();
                flxMatHang.AutoSizeRows();
                double tongtien = 0;
                for (int i = 1; i < flxMatHang.Rows.Count; i++)
                {
                    double thanhtienofrow = 0;
                    try { thanhtienofrow = Convert.ToDouble(flxMatHang[i, "thanhtien"].ToString()); }
                    catch { }
                    tongtien = tongtien + thanhtienofrow;
                }
                txtTongTien.Text = tongtien.ToString("N0", CultureInfo.InvariantCulture);
            }
            catch { }
        }
        private void flxMatHang_CellButtonClick(object sender, C1.Win.C1FlexGrid.RowColEventArgs e)
        {
            string sidkh = "";
            try { sidkh = cbKhachHang.SelectedValue.ToString().Trim(); }
            catch { }
            if (sidkh.Equals("") == true)
            {
                MessageBox.Show("Khách hàng chưa được chọn.\nVui lòng chọn một khách hàng trước khi cập nhật mặt hàng trả lại.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            try
            {
                frmMatHangTra frm = new frmMatHangTra(sidkh);
                frm.ShowDialog();
                string sidmathang = "";
                try
                {
                    sidmathang = frm.sreturn;
                    if (sidmathang.Trim().Equals("") == true)
                    {
                        sidmathang = flxMatHang[flxMatHang.RowSel, "id_mathang"].ToString().Trim();
                    }
                }
                catch { }
                if (CheckMatHang(sidmathang, flxMatHang.RowSel) == true)
                {
                    MessageBox.Show("Mặt hàng đã có trong đơn hàng này.\nVui lòng chọn một mặt hàng khác.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    if (flxMatHang.RowSel == flxMatHang.Rows.Count - 1)
                    {
                        flxMatHang.StartEditing(flxMatHang.Rows.Count - 1, 4);
                    }
                    else
                    {
                        flxMatHang.StartEditing(flxMatHang.RowSel, 4);
                    }
                    //flxMatHang.StartEditing(flxMatHang.Rows.Count - 1, 4);
                    return;
                }
                tblmathang obj = new tblmathang();
                tblmathangBL ctr = new tblmathangBL();
                obj = ctr.GetByID(sidmathang);
                //flxMatHang[flxMatHang.RowSel, "id"] = "";
                flxMatHang[flxMatHang.RowSel, "id_hoadon"] = "";
                flxMatHang[flxMatHang.RowSel, "id_mathang"] = sidmathang;
                flxMatHang[flxMatHang.RowSel, "mathang"] = obj.ten.Trim();
                //flxMatHang[flxMatHang.RowSel, "soluong"] = "";
                flxMatHang[flxMatHang.RowSel, "donvi"] = obj.donvi.Trim();
                try
                {
                    if (cbCapDL.Text.ToUpper().Trim().Equals("ĐẠI LÝ CẤP 1") == true)
                    {
                        flxMatHang[flxMatHang.RowSel, "gianhaplai"] = obj.giadl1.ToString().Trim();
                        try { flxMatHang[flxMatHang.RowSel, "thanhtien"] = Convert.ToInt32(flxMatHang[flxMatHang.RowSel, "soluong"]) * obj.giadl1; }
                        catch { }
                    }
                    if (cbCapDL.Text.ToUpper().Trim().Equals("ĐẠI LÝ CẤP 2") == true)
                    {
                        flxMatHang[flxMatHang.RowSel, "gianhaplai"] = obj.giadl2.ToString().Trim();
                        try { flxMatHang[flxMatHang.RowSel, "thanhtien"] = Convert.ToInt32(flxMatHang[flxMatHang.RowSel, "soluong"]) * obj.giadl2; }
                        catch { }
                    }
                    if (cbCapDL.Text.ToUpper().Trim().Equals("ĐẠI LÝ CẤP 3") == true)
                    {
                        flxMatHang[flxMatHang.RowSel, "gianhaplai"] = obj.giadl3.ToString().Trim();
                        try { flxMatHang[flxMatHang.RowSel, "thanhtien"] = Convert.ToInt32(flxMatHang[flxMatHang.RowSel, "soluong"]) * obj.giadl3; }
                        catch { }
                    }
                    if (cbCapDL.Text.ToUpper().Trim().Equals("ĐẠI LÝ CẤP 4") == true)
                    {
                        flxMatHang[flxMatHang.RowSel, "gianhaplai"] = obj.giadl4.ToString().Trim();
                        try { flxMatHang[flxMatHang.RowSel, "thanhtien"] = Convert.ToInt32(flxMatHang[flxMatHang.RowSel, "soluong"]) * obj.giadl4; }
                        catch { }
                    }
                    if (cbCapDL.Text.ToUpper().Trim().Equals("ĐẠI LÝ CẤP 5") == true)
                    {
                        flxMatHang[flxMatHang.RowSel, "gianhaplai"] = obj.giadl5.ToString().Trim();
                        try { flxMatHang[flxMatHang.RowSel, "thanhtien"] = Convert.ToInt32(flxMatHang[flxMatHang.RowSel, "soluong"]) * obj.giadl5; }
                        catch { }
                    }
                    if (cbCapDL.Text.ToUpper().Trim().Equals("KHÁCH LẺ") == true)
                    {
                        flxMatHang[flxMatHang.RowSel, "gianhaplai"] = obj.giadl5.ToString().Trim();
                        try { flxMatHang[flxMatHang.RowSel, "thanhtien"] = Convert.ToInt32(flxMatHang[flxMatHang.RowSel, "soluong"]) * obj.giadl5; }
                        catch { }
                    }
                }
                catch
                {
                    flxMatHang[flxMatHang.RowSel, "gianhaplai"] = obj.giadl5.ToString().Trim();
                    try { flxMatHang[flxMatHang.RowSel, "thanhtien"] = Convert.ToInt32(flxMatHang[flxMatHang.RowSel, "soluong"]) * obj.giadl5; }
                    catch { }
                }
            }
            catch { }
        }
        private void flxMatHang_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.Control && e.KeyCode == Keys.A) || e.KeyCode == Keys.Add)
            { AddMatHang(); }
            else if (e.KeyCode == Keys.Delete) { DelMatHang(); }
        }
        private void flxMatHang_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                menu_MatHangBan.Show(flxMatHang, e.X, e.Y);
            }
            else { return; }
        }
        #endregion
        private void ultraToolbarsManager1_ToolClick(object sender, Infragistics.Win.UltraWinToolbars.ToolClickEventArgs e)
        {
            switch (e.Tool.Key)
            {
                case "btn_Add":    // ButtonTool
                    //Add();
                    try
                    {
                        AddHoaDonTra frm = new AddHoaDonTra();
                        frm.ShowDialog();
                    }
                    catch { }
                    HienThiDSHoaDon();
                    break;

                case "btn_Save":    // ButtonTool
                    flxMatHang.Focus();
                    Save();
                    break;

                case "btn_Abort":    // ButtonTool
                    HienThiDSHoaDon();
                    flxHoaDon_Click(sender, e);
                    break;

                case "btn_Del":    // ButtonTool
                    Del();
                    break;

                case "btnExportHD":    // ButtonTool
                    XuatHoaDon();
                    break;
            }
        }
        private void ucHoaDonTra_Load(object sender, EventArgs e)
        {
            cserror = flxMatHang.Styles.Add("error");
            cserror.BackColor = Color.Red;
            cs1 = flxMatHang.Styles.Add("cs1");
            cs1.BackColor = Color.White;
            try
            {
                CheckQuyenDL();
            }
            catch { }
            LoadCBKhachHang();
            cbKhachHang.SelectedValue = ""; cbKhachHang.Text = "";
            LoadCBTKKhachHang();
            cbTKKhachHang.SelectedValue = ""; cbTKKhachHang.Text = "";
            dpkTKDenNgay.Value = DateTime.Now;
            dpkTKTuNgay.Value = DateTime.Now.AddDays(-7);
            HienThiDSHoaDon();
            if (flxHoaDon.Rows.Count - 1 > 0)
            {
                flxHoaDon.Select(1, flxHoaDon.Cols["tenkh"].Index);
                HienThiTTHoaDon(flxHoaDon[1, "id"].ToString().Trim());
                HienThiDSMatHang(flxHoaDon[1, "id"].ToString().Trim());
            }
            else
            {
                flxHoaDon.Focus();
                HienThiTTHoaDon("-1");
                HienThiDSMatHang("-1");
            }
            flxMatHang.KeyActionEnter = KeyActionEnum.MoveAcross;
        }
    }
}
