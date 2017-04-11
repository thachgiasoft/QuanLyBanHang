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
     /// Mô tả thông tin cho bảng tbltienthanhtoan
     /// Cung cấp các hàm xử lý, thao tác với bảng tbltienthanhtoan
     /// Người tạo (C): tuanva
     /// Ngày khởi tạo: 03/09/2015
     /// </summary>
    public class tbltienthanhtoanBL
    {
        private tbltienthanhtoan objtbltienthanhtoanDA = new tbltienthanhtoan();
        public tbltienthanhtoanBL() { objtbltienthanhtoanDA = new tbltienthanhtoan(); }

        #region Public Method
        /// <summary>
        /// Lấy toàn bộ dữ liệu từ bảng tbltienthanhtoan
        /// </summary>
        /// <returns>DataTable</returns>
        public DataTable GetAll()
        {
            return objtbltienthanhtoanDA.GetAll();
        }
        /// <summary>
        /// Hàm lấy tbltienthanhtoan theo mã
        /// </summary>
        /// <returns>Trả về objtbltienthanhtoan </returns>
        public tbltienthanhtoan GetByID(string strid)
        {
            return objtbltienthanhtoanDA.GetByID(strid);
        }
        /// <summary>
        /// Hàm lấy objtienthanhtoan theo mã hóa đơn và ngày thanh toán
        /// </summary>
        /// <param name="sidhd">Mã hóa đơn kiểu string(Guid)</param>
        /// <param name="dtngaytt">Ngày thanh toán kiểu DateTime</param>
        /// <returns>tbltienthanhtoan</returns>
        public tbltienthanhtoan GetByIDHDvsNgayTT(string sidhd, DateTime dtngaytt)
        { return objtbltienthanhtoanDA.GetByIDHDvsNgayTT(sidhd, dtngaytt); }
        /// <summary>
        /// Hàm lấy danh sách tiền thanh toán theo mã hóa đơn
        /// </summary>
        /// <param name="sidhd">Mã hóa đơn kiểu string(Guid)</param>
        /// <returns>DataTable</returns>
        public DataTable GetByIDHD(string sidhd)
        {
            return objtbltienthanhtoanDA.GetByIDHD(sidhd);
        }
        /// <summary>
        /// Hàm tính tổng tiền đã thanh toán theo mã hóa đơn bán
        /// </summary>
        /// <param name="sidhd">Mã hóa đơn bán</param>
        /// <returns>Tổng tiền đã thanh toán kiểu double</returns>
        public double GetTienDaThanhToan(string sidhd)
        {
            double tongtien = 0;
            try
            {
                tbltienthanhtoanBL ctr = new tbltienthanhtoanBL();
                DataTable dt = new DataTable();
                dt = GetByIDHD(sidhd);
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    tongtien = tongtien + Convert.ToDouble(dt.Rows[i]["tientt"].ToString().Trim());
                }
                return tongtien;
            }
            catch { return tongtien; }
        }
        /// <summary>
        /// Hàm kiểm tra đã tồn tại bản ghi theo mã hóa đơn và ngày thanh toán chưa
        /// </summary>
        /// <param name="sidhd">Mã hóa đơn kiểu string (Guid)</param>
        /// <param name="dtngaytt">Ngày thanh toán kiểu DateTime</param>
        /// <returns>bool: False-Không tồn tại;True-Có tồn tại</returns>
        public bool CheckExit(string sidhd, DateTime dtngaytt)
        { return objtbltienthanhtoanDA.CheckExit(sidhd, dtngaytt); }
        /// <summary>
        /// Thêm mới dữ liệu vào bảng: tbltienthanhtoan
        /// </summary>
        /// <param name="obj">objtbltienthanhtoan</param>
        /// <returns>Trả về trắng: Thêm mới thành công; Trả về khác trắng: Thêm mới không thành công</returns>
        public string Insert(tbltienthanhtoan objtbltienthanhtoan)
        {
            return objtbltienthanhtoanDA.Insert(objtbltienthanhtoan);
        }
        /// <summary>
        /// Cập nhật dữ liệu vào bảng: tbltienthanhtoan
        /// </summary>
        /// <param name="obj">objtbltienthanhtoan</param>
        /// <returns>Trả về trắng: Cập nhật thành công; Trả về khác trắng: Cập nhật không thành công</returns>
        public string Update(tbltienthanhtoan objtbltienthanhtoan)
        {
            return objtbltienthanhtoanDA.Update(objtbltienthanhtoan);
        }
        /// <summary>
        /// Xóa dữ liệu từ bảng tbltienthanhtoan
        /// </summary>
        /// <returns></returns>
        public string Delete(string strid)
        {
            return objtbltienthanhtoanDA.Delete(strid);
        }
        /// <summary>
        /// Hàm lấy tất cả dữ liệu trong bảng tbltienthanhtoan
        /// </summary>
        /// <returns>Trả về List<<tbltienthanhtoan>></returns>
        public List<tbltienthanhtoan> GetList()
        {
            return objtbltienthanhtoanDA.GetList();
        }
        /// <summary>
        /// Hàm lấy danh sách objtbltienthanhtoan
        /// </summary>
        /// <param name="recperpage">Số lượng bản ghi kiểu integer</param>
        /// <param name="pageindex">Số trang kiểu integer</param>
        /// <returns>Trả về List<<tbltienthanhtoan>></returns>
        public List<tbltienthanhtoan> GetListPaged(int recperpage, int pageindex)
        {
            return objtbltienthanhtoanDA.GetListPaged(recperpage, pageindex);
        }
        /// <summary>
        /// Hàm lấy danh sách objtbltienthanhtoan
        /// </summary>
        /// <param name="recperpage">Số lượng bản ghi kiểu integer</param>
        /// <param name="pageindex">Số trang kiểu integer</param>
        /// <returns>Trả về List<<tbltienthanhtoan>></returns>
        public DataTable GetDataTablePaged(int recperpage, int pageindex)
        {
            return objtbltienthanhtoanDA.GetDataTablePaged(recperpage, pageindex);
        }
        #endregion
    }
}
