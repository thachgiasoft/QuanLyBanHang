using System;
using System.Data;
using System.Collections.Generic;
using System.Text;
using CGCN.Framework;
using Npgsql;
using NpgsqlTypes;
using CGCN.DataAccess;
using HoaDonDataAccess.DataAccess;

namespace HoaDonDataAccess.BusinesLogic
{
    /// <summary>
    /// Mô tả thông tin cho bảng tienthanhtoanphieunhap
    /// Cung cấp các hàm xử lý, thao tác với bảng tienthanhtoanphieunhap
    /// Người tạo (C): tuanva
    /// Ngày khởi tạo: 03/09/2015
    /// </summary>
    public class tienthanhtoanphieunhapBL
    {
        private tienthanhtoanphieunhap objtienthanhtoanphieunhapDA = new tienthanhtoanphieunhap();
        public tienthanhtoanphieunhapBL() { objtienthanhtoanphieunhapDA = new tienthanhtoanphieunhap(); }

        #region Public Method
        private readonly DataAccessLayerBaseClass mDataAccess = new DataAccessLayerBaseClass(Data.ConnectionString);
        /// <summary>
        /// Lấy toàn bộ dữ liệu từ bảng tienthanhtoanphieunhap
        /// </summary>
        /// <returns>DataTable</returns>
        public DataTable GetAll()
        {
            return objtienthanhtoanphieunhapDA.GetAll();
        }
        /// <summary>
        /// Hàm lấy object tienthanhtoanphieunhap theo mã
        /// </summary>
        /// <returns>Trả về objttienthanhtoanphieunhap </returns>
        public tienthanhtoanphieunhap GetByID(string strid)
        {
            return objtienthanhtoanphieunhapDA.GetByID(strid);
        }
        /// <summary>
        /// Hàm lấy objtienthanhtoanphieunhap theo mã phiếu nhập hàng và ngày thanh toán
        /// </summary>
        /// <param name="sidhd">Mã phiếu nhập hàng kiểu string(Guid)</param>
        /// <param name="dtngaytt">Ngày thanh toán kiểu DateTime</param>
        /// <returns>object: tienthanhtoanphieunhap</returns>
        public tienthanhtoanphieunhap GetByIDPNvsNgayTT(string sidpn, DateTime dtngaytt)
        {
            return objtienthanhtoanphieunhapDA.GetByIDPNvsNgayTT(sidpn, dtngaytt);
        }
        /// <summary>
        /// Hàm lấy danh sách tiền thanh toán theo mã hóa đơn
        /// </summary>
        /// <param name="sidpn">Mã phiếu nhập kiểu string(Guid)</param>
        /// <returns>DataTable</returns>
        public DataTable GetByIDPN(string sidpn)
        {
            return objtienthanhtoanphieunhapDA.GetByIDPN(sidpn);
        }
        /// <summary>
        /// Hàm tính tổng tiền đã thanh toán theo mã hóa đơn nhập
        /// </summary>
        /// <param name="sidhd">Mã hóa đơn nhập</param>
        /// <returns>Tổng tiền đã thanh toán kiểu double</returns>
        public double GetTienDaThanhToan(string sidpn)
        {
            double tongtien = 0;
            try
            {
                tbltienthanhtoanBL ctr = new tbltienthanhtoanBL();
                DataTable dt = new DataTable();
                dt = GetByIDPN(sidpn);
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    tongtien = tongtien + Convert.ToDouble(dt.Rows[i]["tientt"].ToString().Trim());
                }
                return tongtien;
            }
            catch { return tongtien; }
        }
        /// <summary>
        /// Hàm kiểm tra đã tồn tại bản ghi theo mã phiếu nhập và ngày thanh toán
        /// </summary>
        /// <param name="sidhd">Mã phiếu nhập kiểu string (Guid)</param>
        /// <param name="dtngaytt">Ngày thanh toán kiểu DateTime</param>
        /// <returns>bool: False-Không tồn tại;True-Có tồn tại</returns>
        public bool CheckExit(string sidpn, DateTime dtngaytt)
        {
            return objtienthanhtoanphieunhapDA.CheckExit(sidpn, dtngaytt);
        }
        /// <summary>
        /// Thêm mới dữ liệu vào bảng: tienthanhtoanphieunhap
        /// </summary>
        /// <param name="obj">objtienthanhtoanphieunhap</param>
        /// <returns>Trả về trắng: Thêm mới thành công; Trả về khác trắng: Thêm mới không thành công</returns>
        public string Insert(tienthanhtoanphieunhap objtienthanhtoanphieunhap)
        {
            return objtienthanhtoanphieunhapDA.Insert(objtienthanhtoanphieunhap);
        }
        /// <summary>
        /// Cập nhật dữ liệu vào bảng: tienthanhtoanphieunhap
        /// </summary>
        /// <param name="obj">objtienthanhtoanphieunhap</param>
        /// <returns>Trả về trắng: Cập nhật thành công; Trả về khác trắng: Cập nhật không thành công</returns>
        public string Update(tienthanhtoanphieunhap objtienthanhtoanphieunhap)
        {
            return objtienthanhtoanphieunhapDA.Update(objtienthanhtoanphieunhap);
        }
        /// <summary>
        /// Xóa dữ liệu từ bảng tienthanhtoanphieunhap
        /// </summary>
        /// <returns></returns>
        public string Delete(string strid)
        {
            return objtienthanhtoanphieunhapDA.Delete(strid);
        }
        /// <summary>
        /// Hàm lấy tất cả dữ liệu trong bảng tienthanhtoanphieunhap
        /// </summary>
        /// <returns>Trả về List<<tienthanhtoanphieunhap>></returns>
        public List<tienthanhtoanphieunhap> GetList()
        {
            return objtienthanhtoanphieunhapDA.GetList();
        }
        /// <summary>
        /// Hàm lấy danh sách objtienthanhtoanphieunhap
        /// </summary>
        /// <param name="recperpage">Số lượng bản ghi kiểu integer</param>
        /// <param name="pageindex">Số trang kiểu integer</param>
        /// <returns>Trả về List<<tienthanhtoanphieunhap>></returns>
        public List<tienthanhtoanphieunhap> GetListPaged(int recperpage, int pageindex)
        {
            return objtienthanhtoanphieunhapDA.GetListPaged(recperpage, pageindex);
        }
        /// <summary>
        /// Hàm lấy danh sách objtienthanhtoanphieunhap
        /// </summary>
        /// <param name="recperpage">Số lượng bản ghi kiểu integer</param>
        /// <param name="pageindex">Số trang kiểu integer</param>
        /// <returns>Trả về List<<tienthanhtoanphieunhap>></returns>
        public DataTable GetDataTablePaged(int recperpage, int pageindex)
        {
            return objtienthanhtoanphieunhapDA.GetDataTablePaged(recperpage, pageindex);
        }
        #endregion
    }
}
