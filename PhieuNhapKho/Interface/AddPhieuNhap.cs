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
using PhieuNhapKho.DataAccess;
using PhieuNhapKho.BusinesLogic;
using DanhMuc.DataAccess;
using DanhMuc.BusinesLogic;
using CGCN.DataAccess;
using System.Globalization;
using DanhMuc.Interface;
using HoaDonDataAccess.DataAccess;
using HoaDonDataAccess.BusinesLogic;

namespace PhieuNhapKho.Interface
{
    public partial class AddPhieuNhap : Form
    {
        private CellStyle cs1;
        private logBL _ctrlog = new logBL();

        #region Method
        private void LoadCBNhaCC()
        {
            nhacungcapBL ctr = new nhacungcapBL();
            DataTable dt = new DataTable();
            dt = ctr.GetAll();
            cbNhaCC.DataSource = dt;
            cbNhaCC.DisplayMember = "ten";
            cbNhaCC.ValueMember = "id";
        }
        private void HienThiTT()
        {
            try
            {
                tblphieunhapkho obj = new tblphieunhapkho();
                tblphieunhapkhoBL ctr = new tblphieunhapkhoBL();
                obj = ctr.GetByID(txtID.Text.Trim());
                dpkNgayNhap.Value = obj.ngaytao;
                cbNhaCC.SelectedValue = obj.id_nguoicap;
                txtChietKhau.Text = obj.chietkhau.ToString("N0", CultureInfo.InvariantCulture);
                txtTienThanhToan.Text = obj.tienthanhtoan.ToString("N0", CultureInfo.InvariantCulture);
                dpkNgayNhap.Value = obj.ngaytao;
                txtNoToaTruoc.Text = ctr.GetTienConNo(obj.id_nguoicap, obj.ngaytao).ToString("N0", CultureInfo.InvariantCulture);
                txtGhiChu.Text = obj.ghichu.Trim();
                txtNoiNhap.Text = obj.noinhap.Trim();
            }
            catch
            {
                HienThiDSMatHang();
            }
        }
        private void HienThiDSMatHang()
        {
            try
            {
                DataTable dt = new DataTable();
                tblhangnhapkhoBL ctr = new tblhangnhapkhoBL();
                dt = ctr.GetByIDPN(txtID.Text.Trim());
                dt.Columns.Add("tt", typeof(Int32));
                flxMatHang.DataSource = dt;
                FormatGridMatHang();
            }
            catch { }
        }
        private void FormatGridMatHang()
        {
            for (int i = 0; i < flxMatHang.Cols.Count; i++)
            {
                if (i == 0)
                { flxMatHang[0, i] = "STT"; flxMatHang.Cols[i].Visible = true; flxMatHang.Cols[i].Width = 60; }
                else if (flxMatHang.Cols[i].Caption.Equals("mathang"))
                {
                    flxMatHang[0, i] = "Mặt hàng(*)";
                    flxMatHang.Cols[i].Visible = true;
                    flxMatHang.Cols[i].ComboList = "...";
                }
                else if (flxMatHang.Cols[i].Caption.Equals("soluong"))
                {
                    flxMatHang[0, i] = "Số lượng (*)";
                    flxMatHang.Cols[i].Visible = true;
                    flxMatHang.Cols["soluong"].Format = "N0";
                }
                else if (flxMatHang.Cols[i].Caption.Equals("donvi"))
                {
                    flxMatHang[0, i] = "Đơn vị";
                    flxMatHang.Cols[i].Visible = true;
                    flxMatHang.Cols["donvi"].AllowEditing = false;
                }
                else if (flxMatHang.Cols[i].Caption.Equals("gianhap"))
                {
                    flxMatHang[0, i] = "Giá nhập(*)";
                    flxMatHang.Cols[i].Visible = true;
                    flxMatHang.Cols["gianhap"].Format = "N0";
                }
                else if (flxMatHang.Cols[i].Caption.Equals("thanhtien"))
                {
                    flxMatHang[0, i] = "Thành tiền";
                    flxMatHang.Cols[i].Visible = true;
                    flxMatHang.Cols["thanhtien"].AllowEditing = false;
                    flxMatHang.Cols["thanhtien"].Format = "N0";
                }
                else if (flxMatHang.Cols[i].Caption.Equals("ghichu"))
                {
                    flxMatHang[0, i] = "Ghi chú";
                    flxMatHang.Cols[i].Visible = true;
                    flxMatHang.Cols["thanhtien"].AllowEditing = true;
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
                double thanhtienforrow = 0;
                try { thanhtienforrow = Convert.ToDouble(flxMatHang[j, "thanhtien"].ToString().Trim()); }
                catch { }
                tongtien = tongtien + thanhtienforrow;
            }
            txtTongTien.Text = tongtien.ToString("N0", CultureInfo.InvariantCulture);
            double tienthanhtoan = 0;
            try { tienthanhtoan = Convert.ToDouble(txtTienThanhToan.Text.Trim()); }
            catch { }
            double chietkhau = 0;
            try { chietkhau = Convert.ToDouble(txtChietKhau.Text.Trim()); }
            catch { }
            double tienconnotoatruoc = 0;
            try { tienconnotoatruoc = Convert.ToDouble(txtNoToaTruoc.Text.Trim()); }
            catch { }
            txtConNo.Text = ((tongtien - tienthanhtoan - chietkhau) + tienconnotoatruoc).ToString("N0", CultureInfo.InvariantCulture);
            flxMatHang.Cols[0].TextAlign = TextAlignEnum.CenterCenter;
            flxMatHang.AutoSizeCols();
            flxMatHang.AutoSizeRows();
        }
        private void TinhToan()
        {
            double tongtien = 0;
            try { tongtien = Convert.ToDouble(txtTongTien.Text.Trim()); }
            catch { }
            double chietkhau = 0;
            try { chietkhau = Convert.ToDouble(txtChietKhau.Text.Trim()); }
            catch { }
            double tienthanhtoan = 0;
            try { tienthanhtoan = Convert.ToDouble(txtTienThanhToan.Text.Trim()); }
            catch { }
            double tienconnotoatruoc = 0;
            try { tienconnotoatruoc = Convert.ToDouble(txtNoToaTruoc.Text.Trim()); }
            catch { }
            txtConNo.Text = ((tongtien - tienthanhtoan - chietkhau) + tienconnotoatruoc).ToString("N0", CultureInfo.InvariantCulture);
        }
        #endregion
        #region GetData
        private bool CheckMatHang(string sidmathang, int irow)
        {
            for (int i = 1; i < flxMatHang.Rows.Count; i++)
            {
                string sidmathangtemp = "";
                try { sidmathangtemp = flxMatHang[i, "id_mathang"].ToString().Trim(); }
                catch { }
                if (sidmathang.Trim().Equals("") == false && sidmathang.Trim().Equals(sidmathangtemp) == true && i != irow) { return true; }
            }
            return false;
        }
        private tblphieunhapkho GetDataPhieuNhap()
        {
            tblphieunhapkho obj = new tblphieunhapkho();
            string sidnhacc = "";
            try { sidnhacc = cbNhaCC.SelectedValue.ToString().Trim(); }
            catch { }
            if (sidnhacc.Trim().Equals("") == true)
            {
                MessageBox.Show("Nhà cung cấp chưa được chọn.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cbNhaCC.Focus();
                return null;
            }
            if (txtID.Text.Equals("-1") == true) { obj.id = Guid.NewGuid().ToString(); }
            else { obj.id = txtID.Text.Trim(); }
            try { obj.tienthanhtoan = Convert.ToDouble(txtTienThanhToan.Text.Trim()); }
            catch { }
            try { obj.chietkhau = Convert.ToDouble(txtChietKhau.Text.Trim()); }
            catch { }
            obj.ngaytao = dpkNgayNhap.Value;
            obj.ghichu = txtGhiChu.Text.Trim();
            obj.noinhap = txtNoiNhap.Text.Trim();
            obj.id_nguoicap = sidnhacc;
            obj.noinhap = "";
            return obj;
        }
        private List<tblhangnhapkho> GetListMatHang()
        {
            tblmathangBL ctrmathang = new tblmathangBL();
            tblhangnhapkhoBL ctrmathangban = new tblhangnhapkhoBL();
            try
            {
                List<tblhangnhapkho> lst = new List<tblhangnhapkho>();
                for (int i = 1; i < flxMatHang.Rows.Count; i++)
                {
                    if (flxMatHang[i, "tt"].ToString().Trim().Equals("1") == true || flxMatHang[i, "tt"].ToString().Trim().Equals("2") == true)
                    {
                        tblhangnhapkho obj = new tblhangnhapkho();
                        if (flxMatHang[i, "tt"].ToString().Trim().Equals("1") == true) { obj.id = Guid.NewGuid().ToString(); }
                        else { obj.id = flxMatHang[i, "id"].ToString().Trim(); }
                        if (flxMatHang[i, "id_mathang"].ToString().Trim().Equals("") == false)
                        {
                            try { obj.soluong = Convert.ToInt32(flxMatHang[i, "soluong"].ToString().Trim()); }
                            catch { obj.soluong = 0; }
                            try { obj.gianhap = Convert.ToDouble(flxMatHang[i, "gianhap"].ToString().Trim()); }
                            catch { obj.gianhap = 0; }
                            if (obj.soluong == 0)
                            {
                                MessageBox.Show("Số lượng phải lớn hơn 0 và là số", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                flxMatHang.Select(i, flxMatHang.Cols["soluong"].Index);
                                flxMatHang.SetUserData(i, 0, "Số lượng phải lớn hơn 0 và là số");
                                flxMatHang.Rows[i].Style = cs1;
                                return null;
                            }
                        }
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
                            if (obj.gianhap == 0)
                            {
                                MessageBox.Show("Giá nhập chưa được nhập", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                flxMatHang.Select(i, flxMatHang.Cols["gianhap"].Index);
                                flxMatHang.SetUserData(i, 0, "Giá nhập chưa được nhập");
                                flxMatHang.Rows[i].Style = cs1;
                                return null;
                            }
                            obj.id_mathang = flxMatHang[i, "id_mathang"].ToString().Trim();
                            obj.gianhap = Convert.ToDouble(flxMatHang[i, "gianhap"].ToString().Trim());
                            try { obj.ghichu = flxMatHang[i, "ghichu"].ToString().Trim(); }
                            catch { obj.ghichu = ""; }
                            tblmathang objmathang = new tblmathang();
                            objmathang = ctrmathang.GetByID(obj.id_mathang);
                            lst.Add(obj);
                        }
                    }
                }
                return lst;
            }
            catch { return null; }
        }
        #endregion
        #region Method Cập nhật
        private void Add()
        {
            dpkNgayNhap.Value = DateTime.Now;
            txtID.Text = "-1";
            cbNhaCC.SelectedValue = "";
            cbNhaCC.Text = "";
            txtDienThoai.Text = "";
            txtDiaChi.Text = "";
            HienThiDSMatHang();
            txtTongTien.Text = "0";
            txtNoToaTruoc.Text = "0";
            txtTienThanhToan.Text = "0";
            txtConNo.Text = "0";
            txtChietKhau.Text = "0";
            cbNhaCC.Focus();
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
            }
            catch { }
        }
        private void Save()
        {
            string kq = "";
            tienthanhtoanphieunhapBL ctrtientt = new tienthanhtoanphieunhapBL();
            tblmathangBL ctrmathang = new tblmathangBL();
            tblphieunhapkhoBL ctrphieu = new tblphieunhapkhoBL();
            tblphieunhapkho objphieu = new tblphieunhapkho();
            objphieu = GetDataPhieuNhap();
            tblhangnhapkhoBL ctrmathangnhap = new tblhangnhapkhoBL();
            List<tblhangnhapkho> lstmathang = new List<tblhangnhapkho>();
            lstmathang = GetListMatHang();
            if (objphieu != null && lstmathang != null)
            {
                if (txtID.Text.Trim().Equals("-1") == true)
                {
                    kq = ctrphieu.Insert(objphieu);
                    if (kq.Trim().Equals("") == true)
                    {
                        tienthanhtoanphieunhap objtientt = new tienthanhtoanphieunhap();
                        objtientt.id = Guid.NewGuid().ToString().Trim();
                        objtientt.idpn = objphieu.id;
                        objtientt.ngaytt = objphieu.ngaytao;
                        objtientt.tientt = objphieu.tienthanhtoan;
                        ctrtientt.Insert(objtientt);
                    }
                }
                else
                {
                    kq = ctrphieu.Update(objphieu);
                    tienthanhtoanphieunhap objtientt = new tienthanhtoanphieunhap();
                    objtientt = ctrtientt.GetByIDPNvsNgayTT(objphieu.id, objphieu.ngaytao);
                    if (objtientt != null)
                    {
                        objtientt.tientt = objphieu.tienthanhtoan;
                        ctrtientt.Update(objtientt);
                    }
                    else
                    {
                        objtientt = new tienthanhtoanphieunhap();
                        objtientt.id = Guid.NewGuid().ToString().Trim();
                        objtientt.idpn = objphieu.id;
                        objtientt.ngaytt = objphieu.ngaytao;
                        objtientt.tientt = objphieu.tienthanhtoan;
                        ctrtientt.Insert(objtientt);
                    }
                    _ctrlog.Append(Data.use, "Sửa phiếu nhập kho của nhà cung cấp: " + cbNhaCC.Text.Trim()
                                       + " xuất ngày: " + dpkNgayNhap.Value.ToString("dd/MM/yyyy").Trim()
                                       + "; id: " + objphieu.id
                                       + ";\nChi tiết: Tổng tiền hàng: " + txtTongTien.Text + " - Nợ cũ: " + txtNoToaTruoc.Text
                                       + " - Tiền thanh toán: " + txtTienThanhToan.Text + " - Tổng nợ mới: " + txtConNo.Text);
                }
                if (kq.Trim().Equals("") == true)
                {
                    if (lstmathang != null)
                    {
                        if (objphieu != null && lstmathang.Count > 0)
                        {
                            for (int i = 0; i < lstmathang.Count; i++)
                            {
                                tblhangnhapkho temp = new tblhangnhapkho();
                                temp = ctrmathangnhap.GetByID(lstmathang[i].id);
                                if (temp == null)
                                {
                                    lstmathang[i].id_phieunhapkho = objphieu.id;
                                    kq = ctrmathangnhap.Insert(lstmathang[i]);
                                    if (kq.Trim().Equals("") == false)
                                    {
                                        ctrphieu.Delete(objphieu.id);
                                        break;
                                    }
                                    else //Thêm số lượng vào trong kho
                                    {
                                        tblmathang objmathang = new tblmathang();
                                        objmathang = ctrmathang.GetByID(lstmathang[i].id_mathang.Trim());
                                        objmathang.soluong = objmathang.soluong + lstmathang[i].soluong;
                                        objmathang.gianhap = lstmathang[i].gianhap;
                                        ctrmathang.Update(objmathang);
                                    }
                                }
                                else
                                {
                                    lstmathang[i].id_phieunhapkho = objphieu.id;
                                    kq = ctrmathangnhap.Update(lstmathang[i]);
                                    if (kq.Trim().Equals("") == false)
                                    {
                                        break;
                                    }
                                    else //Cập nhật lại số lượng còn trong kho
                                    {
                                        tblmathang objmathang = new tblmathang();
                                        objmathang = ctrmathang.GetByID(lstmathang[i].id_mathang.Trim());
                                        objmathang.soluong = (objmathang.soluong - temp.soluong) + lstmathang[i].soluong;
                                        objmathang.gianhap = lstmathang[i].gianhap;
                                        ctrmathang.Update(objmathang);
                                    }
                                }
                            }
                            if (kq.Trim().Equals("") == false)
                            {
                                MessageBox.Show("Lỗi cập nhật phiếu nhập hàng.\nChi tiết lỗi: " + kq, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }
                            else
                            {
                                if (txtID.Text.Trim().Equals("-1") == true)
                                {
                                    txtID.Text = objphieu.id.Trim();
                                    _ctrlog.Append(Data.use, "Thêm mới phiếu nhập hàng của nhà cung cấp: " + cbNhaCC.Text.Trim()
                                        + " xuất ngày: " + dpkNgayNhap.Value.ToString("dd/MM/yyyy").Trim()
                                        + "; id: " + objphieu.id
                                        + ";\nChi tiết: Tổng tiền hàng: " + txtTongTien.Text + " - Nợ cũ: " + txtNoToaTruoc.Text
                                        + " - Tiền thanh toán: " + txtTienThanhToan.Text + " - Tổng nợ mới: " + txtConNo.Text);
                                }
                            }
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Lỗi cập nhật phiếu nhập hàng.\nChi tiết lỗi: " + kq, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            if (kq.Trim().Equals("") == true && lstmathang != null)
            {
                MessageBox.Show("Cập nhật phiếu nhập hàng thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                HienThiTT();
                HienThiDSMatHang();
                ultraToolbarsManager1.Tools["btn_Del"].SharedProps.Visible = true;
            }
        }
        private void DelMatHang()
        {
            tblmathangBL ctrmathang = new tblmathangBL();
            tblhangnhapkhoBL ctr = new tblhangnhapkhoBL();
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
                    tblhangnhapkho objmathangnhap = new tblhangnhapkho();
                    objmathangnhap = ctr.GetByID(sid);
                    objmathang.soluong = objmathang.soluong - objmathangnhap.soluong;
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
                        TinhToan();
                        _ctrlog.Append(Data.use, "Xóa mặt hàng:" + objmathang.ten + " của phiếu nhập hàng của nhà cung cấp: " + cbNhaCC.Text.Trim()
                                       + " xuất ngày: " + dpkNgayNhap.Value.ToString("dd/MM/yyyy").Trim()
                                       + "; id: " + txtID.Text.Trim()
                                       + ";\nChi tiết: Tổng tiền hàng: " + txtTongTien.Text + " - Nợ cũ: " + txtNoToaTruoc.Text
                                       + " - Tiền thanh toán: " + txtTienThanhToan.Text + " - Tổng nợ mới: " + txtConNo.Text);
                    }
                }
            }
        }
        private void UpdateSoLuongMatHang(string sidhd)
        {
            tblhangnhapkhoBL ctrmathangnhap = new tblhangnhapkhoBL();
            tblmathangBL ctrmathang = new tblmathangBL();
            DataTable dt = new DataTable();
            dt = ctrmathangnhap.GetByIDPN(sidhd);
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
                    tblhangnhapkho objmathangnhap = new tblhangnhapkho();
                    objmathangnhap = ctrmathangnhap.GetByID(sidmathangban);
                    tblmathang objmathang = new tblmathang();
                    objmathang = ctrmathang.GetByID(sidmathang);
                    objmathang.soluong = objmathang.soluong - objmathangnhap.soluong;
                    try { ctrmathang.Update(objmathang); }
                    catch { }
                }
            }
        }
        private void Del()
        {
            tblphieunhapkhoBL ctr = new tblphieunhapkhoBL();
            string kq = "";
            string sidhd = "";
            try { sidhd = txtID.Text.Trim(); }
            catch { }
            string stientttemp = "N/A";
            try { stientttemp = ctr.GetByID(sidhd).tienthanhtoan.ToString(); }
            catch { }
            if (MessageBox.Show("Xác nhận xóa dữ liệu?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                UpdateSoLuongMatHang(sidhd);
                kq = ctr.Delete(sidhd);
                if (kq.Trim().Equals("") == true)
                {
                    _ctrlog.Append(Data.use, "Xóa phiếu nhập hàng của nhà cung cấp: " + cbNhaCC.Text.Trim()
                                       + " xuất ngày: " + dpkNgayNhap.Value.ToString("dd/MM/yyyy").Trim()
                                       + "; id: " + txtID.Text.Trim()
                                       + ";\nChi tiết: Tổng tiền hàng: " + txtTongTien.Text + " - Nợ cũ: " + txtNoToaTruoc.Text
                                       + " - Tiền thanh toán: " + stientttemp + " - Tổng nợ mới: " + txtConNo.Text);
                     Add(); HienThiDSMatHang();
                }
                else
                {
                    MessageBox.Show("Xóa phiếu nhập hàng không thành công.\nChi tiết lỗi: " + kq, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
        }
        #endregion

        public AddPhieuNhap()
        {
            InitializeComponent();
        }

        private void AddPhieuNhap_Load(object sender, EventArgs e)
        {
            LoadCBNhaCC();
            cs1 = flxMatHang.Styles.Add("error");
            cs1.BackColor = Color.Aquamarine;
            Add();
            flxMatHang.KeyActionEnter = KeyActionEnum.MoveAcross;
        }

        #region Xử lý sự kiện combobox chọn nhà cung cấp
        private void cbNhaCC_SelectedIndexChanged(object sender, EventArgs e)
        {
            tblphieunhapkhoBL ctrpn = new tblphieunhapkhoBL();
            string sidnhacc = "";
            try { sidnhacc = cbNhaCC.SelectedValue.ToString().Trim(); }
            catch { }
            nhacungcap obj = new nhacungcap();
            nhacungcapBL ctr = new nhacungcapBL();
            obj = ctr.GetByID(sidnhacc);
            try
            {
                try
                {
                    txtNoToaTruoc.Text = ctrpn.GetTienConNo(sidnhacc, dpkNgayNhap.Value).ToString("N0", CultureInfo.InvariantCulture);
                }
                catch { txtNoToaTruoc.Text = "0"; }
                txtDiaChi.Text = obj.diachi;
                txtDienThoai.Text = obj.dienthoai.Trim();
                double tongtien = 0;
                try { tongtien = Convert.ToDouble(txtTongTien.Text); }
                catch { }
                double tienconno = 0;
                try { tienconno = Convert.ToDouble(txtNoToaTruoc.Text); }
                catch { }
                double tientt = 0;
                try { tientt = Convert.ToDouble(txtTienThanhToan.Text); }
                catch { }
                double chietkhau = 0;
                try { chietkhau = Convert.ToDouble(txtChietKhau.Text); }
                catch { }
                txtConNo.Text = ((tienconno + tongtien) - (tientt + chietkhau)).ToString("N0", CultureInfo.InvariantCulture);
            }
            catch
            {
                txtDiaChi.Text = "";
                txtDienThoai.Text = "";
                txtTongTien.Text = "0";
            }
        }
        private void cbNhaCC_TextChanged(object sender, EventArgs e)
        {
            cbNhaCC_SelectedIndexChanged(sender, e);
        }
        #endregion
        #region Xử lý sự kiện lưới mặt hàng
        private void flxMatHang_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.Control && e.KeyCode == Keys.A) || e.KeyCode == Keys.Add)
            { AddMatHang(); }
            else if (e.KeyCode == Keys.Delete) { DelMatHang(); }
        }
        private void flxMatHang_AfterEdit(object sender, RowColEventArgs e)
        {
            try
            {
                int hang = flxMatHang.Row;
                if (Convert.ToInt32(flxMatHang[hang, "tt"]) == 0)
                {
                    flxMatHang[flxMatHang.RowSel, flxMatHang.Cols.Count - 1] = 2;
                }
                if (flxMatHang.Cols[flxMatHang.ColSel].Name.ToUpper().Equals("GHICHU") == true && flxMatHang.RowSel == flxMatHang.Rows.Count - 1)
                {
                    AddMatHang(); flxMatHang.StartEditing(flxMatHang.Rows.Count - 1, 3);
                }
                flxMatHang[flxMatHang.RowSel, "thanhtien"] = (Convert.ToDouble(flxMatHang[flxMatHang.RowSel, "soluong"].ToString().Trim()) * Convert.ToDouble(flxMatHang[flxMatHang.RowSel, "gianhap"].ToString().Trim())).ToString();
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
                TinhToan();
            }
            catch { }
        }
        private void flxMatHang_CellButtonClick(object sender, RowColEventArgs e)
        {
            try
            {
                frmChonMatHang frm = new frmChonMatHang();
                frm.type = 1;
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
                    flxMatHang.StartEditing(flxMatHang.Rows.Count - 1, 4);
                    return;
                }
                tblmathang obj = new tblmathang();
                tblmathangBL ctr = new tblmathangBL();
                obj = ctr.GetByID(sidmathang);
                //flxMatHang[flxMatHang.RowSel, "id"] = "";
                flxMatHang[flxMatHang.RowSel, "id_phieunhapkho"] = "";
                flxMatHang[flxMatHang.RowSel, "id_mathang"] = sidmathang;
                flxMatHang[flxMatHang.RowSel, "mathang"] = obj.ten.Trim();
                //flxMatHang[flxMatHang.RowSel, "soluong"] = "";
                flxMatHang[flxMatHang.RowSel, "donvi"] = obj.donvi.Trim();
                try
                {
                    if (Convert.ToInt32(flxMatHang[flxMatHang.RowSel, "tt"]) == 0)
                    {
                        flxMatHang[flxMatHang.RowSel, flxMatHang.Cols.Count - 1] = 2;
                    }
                    flxMatHang_AfterEdit(sender, e);
                }
                catch
                {
                    flxMatHang[flxMatHang.RowSel, "gianhap"] = obj.gianhap.ToString().Trim();
                    try { flxMatHang[flxMatHang.RowSel, "thanhtien"] = Convert.ToInt32(flxMatHang[flxMatHang.RowSel, "soluong"]) * obj.gianhap; }
                    catch { }
                    if (Convert.ToInt32(flxMatHang[flxMatHang.RowSel, "tt"]) == 0)
                    {
                        flxMatHang[flxMatHang.RowSel, flxMatHang.Cols.Count - 1] = 2;
                    }
                    flxMatHang_AfterEdit(sender, e);
                }
            }
            catch
            {
                if (Convert.ToInt32(flxMatHang[flxMatHang.RowSel, "tt"]) == 0)
                {
                    flxMatHang[flxMatHang.RowSel, flxMatHang.Cols.Count - 1] = 2;
                }
                flxMatHang_AfterEdit(sender, e);
            }
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
        #region Xử lý tsmenu
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
            HienThiDSMatHang();
        }
        #endregion

        private void ultraToolbarsManager1_ToolClick(object sender, Infragistics.Win.UltraWinToolbars.ToolClickEventArgs e)
        {
            switch (e.Tool.Key)
            {
                case "btn_Save":    // ButtonTool
                    flxMatHang.Focus();
                    Save();
                    break;

                case "btn_Abort":    // ButtonTool
                    if (txtID.Text.Trim().Equals("-1") == true)
                    {
                        Add();
                    }
                    else { HienThiTT(); HienThiDSMatHang(); }
                    break;

                case "btn_Del":    // ButtonTool
                    Del();
                    break;
            }
        }
        private void txtTienThanhToan_TextChanged(object sender, EventArgs e)
        {
            double thanhtien = 0;
            try { thanhtien = Convert.ToDouble(txtTongTien.Text.Trim()); }
            catch { }
            double notoatruoc = 0;
            try { notoatruoc = Convert.ToDouble(txtNoToaTruoc.Text.Trim()); }
            catch { }
            double chietkhau = 0;
            try { chietkhau = Convert.ToDouble(txtChietKhau.Text.Trim()); }
            catch { }
            double tienthanhtoan = 0;
            try
            {
                txtTienThanhToan.Text = Convert.ToDouble(txtTienThanhToan.Text.Trim()).ToString("N0", CultureInfo.InvariantCulture);
                try { tienthanhtoan = Convert.ToDouble(txtTienThanhToan.Text.Trim()); }
                catch { txtTienThanhToan.Text = "0"; txtTienThanhToan.SelectionStart = txtTienThanhToan.Text.Length; }
                txtConNo.Text = ((thanhtien + notoatruoc) - (tienthanhtoan + chietkhau)).ToString("N0", CultureInfo.InvariantCulture);
                txtTienThanhToan.SelectionStart = txtTienThanhToan.Text.Length;
            }
            catch { txtTienThanhToan.Text = "0"; txtTienThanhToan.SelectionStart = txtTienThanhToan.Text.Length; }
        }
        private void txtChietKhau_TextChanged(object sender, EventArgs e)
        {
            double thanhtien = 0;
            try { thanhtien = Convert.ToDouble(txtTongTien.Text.Trim()); }
            catch { }
            double notoatruoc = 0;
            try { notoatruoc = Convert.ToDouble(txtNoToaTruoc.Text.Trim()); }
            catch { }
            double tienthanhtoan = 0;
            try { tienthanhtoan = Convert.ToDouble(txtTienThanhToan.Text.Trim()); }
            catch { }
            double chietkhau = 0;
            try
            {
                txtChietKhau.Text = Convert.ToDouble(txtChietKhau.Text.Trim()).ToString("N0", CultureInfo.InvariantCulture);
                try { chietkhau = Convert.ToDouble(txtChietKhau.Text.Trim()); }
                catch { txtChietKhau.Text = "0"; txtChietKhau.SelectionStart = txtChietKhau.Text.Length; }
                txtConNo.Text = ((thanhtien + notoatruoc) - (tienthanhtoan + chietkhau)).ToString("N0", CultureInfo.InvariantCulture);
                txtChietKhau.SelectionStart = txtChietKhau.Text.Length;
            }
            catch { txtChietKhau.Text = "0"; txtChietKhau.SelectionStart = txtChietKhau.Text.Length; }
        }
        private void btnUpdateNhaCC_Click(object sender, EventArgs e)
        {
            frmChonNhaCungCap frm = new frmChonNhaCungCap();
            frm.type = 2;
            frm.ShowDialog();
            LoadCBNhaCC();
            string sidnhacc = "";
            try
            {
                sidnhacc = frm.sreturn;
                if (sidnhacc.Trim().Equals("") == true)
                {
                    sidnhacc = cbNhaCC.SelectedValue.ToString().Trim();
                }
                else
                {
                    cbNhaCC.SelectedValue = sidnhacc;
                }
            }
            catch { }
        } 
    }
}
