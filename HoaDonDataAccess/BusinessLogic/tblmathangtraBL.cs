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
    /// Mô tả thông tin cho bảng tblmathangtra
    /// Cung cấp các hàm xử lý, thao tác với bảng tblmathangtra
    /// Người tạo (C): tuanva
    /// Ngày khởi tạo: 15/10/2015
    /// </summary>
    public class tblmathangtraBL
    {
        private tblmathangtra objtblmathangtraDA = new tblmathangtra();
        public tblmathangtraBL() { objtblmathangtraDA = new tblmathangtra(); }
        #region Public Method
        /// <summary>
        /// Lấy toàn bộ dữ liệu từ bảng tblmathangtra
        /// </summary>
        /// <returns>DataTable</returns>
        public DataTable GetAll()
        {
            return objtblmathangtraDA.GetAll();
        }
        /// <summary>
        /// Hàm lấy tblmathangtra theo mã
        /// </summary>
        /// <returns>Trả về objtblmathangtra </returns>
        public tblmathangtra GetByID(string strid)
        {
            return objtblmathangtraDA.GetByID(strid);
        }
        /// <summary>
        /// Hàm lấy danh sách mặt hàng trả theo mã hóa đơn
        /// </summary>
        /// <param name="stridhd">Mã hóa đơn trả kiểu string</param>
        /// <returns>DataTable</returns>
        public DataTable GetByHDID(string stridhd)
        { return objtblmathangtraDA.GetByHDID(stridhd); }
        /// <summary>
        /// Thêm mới dữ liệu vào bảng: tblmathangtra
        /// </summary>
        /// <param name="obj">objtblmathangtra</param>
        /// <returns>Trả về trắng: Thêm mới thành công; Trả về khác trắng: Thêm mới không thành công</returns>
        public string Insert(tblmathangtra objtblmathangtra)
        {
            return objtblmathangtraDA.Insert(objtblmathangtra);
        }
        /// <summary>
        /// Cập nhật dữ liệu vào bảng: tblmathangtra
        /// </summary>
        /// <param name="obj">objtblmathangtra</param>
        /// <returns>Trả về trắng: Cập nhật thành công; Trả về khác trắng: Cập nhật không thành công</returns>
        public string Update(tblmathangtra objtblmathangtra)
        {
            return objtblmathangtraDA.Update(objtblmathangtra);
        }
        /// <summary>
        /// Xóa dữ liệu từ bảng tblmathangtra
        /// </summary>
        /// <returns></returns>
        public string Delete(string strid)
        {
            return objtblmathangtraDA.Delete(strid);
        }
        /// <summary>
        /// Hàm lấy tất cả dữ liệu trong bảng tblmathangtra
        /// </summary>
        /// <returns>Trả về List<<tblmathangtra>></returns>
        public List<tblmathangtra> GetList()
        {
            return objtblmathangtraDA.GetList();
        }
        /// <summary>
        /// Hàm lấy danh sách objtblmathangtra
        /// </summary>
        /// <param name="recperpage">Số lượng bản ghi kiểu integer</param>
        /// <param name="pageindex">Số trang kiểu integer</param>
        /// <returns>Trả về List<<tblmathangtra>></returns>
        public List<tblmathangtra> GetListPaged(int recperpage, int pageindex)
        {
            return objtblmathangtraDA.GetListPaged(recperpage, pageindex);
        }
        /// <summary>
        /// Hàm lấy danh sách objtblmathangtra
        /// </summary>
        /// <param name="recperpage">Số lượng bản ghi kiểu integer</param>
        /// <param name="pageindex">Số trang kiểu integer</param>
        /// <returns>Trả về List<<tblmathangtra>></returns>
        public DataTable GetDataTablePaged(int recperpage, int pageindex)
        {
            return objtblmathangtraDA.GetDataTablePaged(recperpage, pageindex);
        }
        #endregion
    }
}
