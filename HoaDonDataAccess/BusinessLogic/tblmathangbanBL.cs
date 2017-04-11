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
     /// Mô tả thông tin cho bảng tblmathangban
     /// Cung cấp các hàm xử lý, thao tác với bảng tblmathangban
     /// Người tạo (C): tuanva
     /// Ngày khởi tạo: 19/08/2015
     /// </summary>
    public class tblmathangbanBL
    {
        private tblmathangban objtblmathangbanDA = new tblmathangban();
        public tblmathangbanBL() { objtblmathangbanDA = new tblmathangban(); }

        #region Public Method
        /// <summary>
        /// Lấy toàn bộ dữ liệu từ bảng tblmathangban
        /// </summary>
        /// <returns>DataTable</returns>
        public DataTable GetAll()
        {
            return objtblmathangbanDA.GetAll();
        }
        /// <summary>
        /// Hàm lấy tblmathangban theo mã
        /// </summary>
        /// <returns>Trả về objtblmathangban </returns>
        public tblmathangban GetByID(string strid)
        {
            return objtblmathangbanDA.GetByID(strid);
        }
        /// <summary>
        /// Hàm lấy danh sách mặt hàng theo mã hóa đơn
        /// </summary>
        /// <param name="stridhd">Mã hóa đơn kiểu string</param>
        /// <returns>DataTable</returns>
        public DataTable GetByHDID(string stridhd)
        {
            return objtblmathangbanDA.GetByHDID(stridhd);
        }
        /// <summary>
        /// Hàm tính tổng tiền mua hàng theo hóa đơn bán
        /// </summary>
        /// <param name="sidhd">Mã hóa đơn kiểu string</param>
        /// <returns>Tổng tiền đã mua hàng kiểu double</returns>
        public double GetTongTienByIDHD(string sidhd)
        {
            double tongtien = 0;
            try
            {
                tbltienthanhtoanBL ctr = new tbltienthanhtoanBL();
                DataTable dt = new DataTable();
                dt = GetByHDID(sidhd);
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    double tienofrow = 0;
                    try { tienofrow = Convert.ToDouble(dt.Rows[i]["soluong"].ToString().Trim()) * Convert.ToDouble(dt.Rows[i]["giaban"].ToString().Trim()); }
                    catch { }
                    tongtien = tongtien + tienofrow;
                }
                return tongtien;
            }
            catch { return tongtien; }
        }
        /// <summary>
        /// Thêm mới dữ liệu vào bảng: tblmathangban
        /// </summary>
        /// <param name="obj">objtblmathangban</param>
        /// <returns>Trả về trắng: Thêm mới thành công; Trả về khác trắng: Thêm mới không thành công</returns>
        public string Insert(tblmathangban objtblmathangban)
        {
            return objtblmathangbanDA.Insert(objtblmathangban);
        }
        /// <summary>
        /// Cập nhật dữ liệu vào bảng: tblmathangban
        /// </summary>
        /// <param name="obj">objtblmathangban</param>
        /// <returns>Trả về trắng: Cập nhật thành công; Trả về khác trắng: Cập nhật không thành công</returns>
        public string Update(tblmathangban objtblmathangban)
        {
            return objtblmathangbanDA.Update(objtblmathangban);
        }
        /// <summary>
        /// Xóa dữ liệu từ bảng tblmathangban
        /// </summary>
        /// <returns></returns>
        public string Delete(string strid)
        {
            return objtblmathangbanDA.Delete(strid);
        }
        /// <summary>
        /// Hàm lấy tất cả dữ liệu trong bảng tblmathangban
        /// </summary>
        /// <returns>Trả về List<<tblmathangban>></returns>
        public List<tblmathangban> GetList()
        {
            return objtblmathangbanDA.GetList();
        }
        /// <summary>
        /// Hàm lấy danh sách objtblmathangban
        /// </summary>
        /// <param name="recperpage">Số lượng bản ghi kiểu integer</param>
        /// <param name="pageindex">Số trang kiểu integer</param>
        /// <returns>Trả về List<<tblmathangban>></returns>
        public List<tblmathangban> GetListPaged(int recperpage, int pageindex)
        {
            return objtblmathangbanDA.GetListPaged(recperpage, pageindex);
        }
        /// <summary>
        /// Hàm lấy danh sách objtblmathangban
        /// </summary>
        /// <param name="recperpage">Số lượng bản ghi kiểu integer</param>
        /// <param name="pageindex">Số trang kiểu integer</param>
        /// <returns>Trả về List<<tblmathangban>></returns>
        public DataTable GetDataTablePaged(int recperpage, int pageindex)
        {
            return objtblmathangbanDA.GetDataTablePaged(recperpage, pageindex);
        }
        #endregion
    }
}
