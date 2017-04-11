using System;
using System.Data;
using System.Collections.Generic;
using System.Text;
using CGCN.Framework;
using Npgsql;
using NpgsqlTypes;
using CGCN.DataAccess;
using DanhMuc.DataAccess;
namespace DanhMuc.BusinesLogic
{
     /// <summary>
     /// Mô tả thông tin cho bảng tblkhachhang
     /// Cung cấp các hàm xử lý, thao tác với bảng tblkhachhang
     /// Người tạo (C): tuanva
     /// Ngày khởi tạo: 30/07/2015
     /// </summary>
    public class tblkhachhangBL
    {
        private tblkhachhang objtblkhachhangDA = new tblkhachhang();
        public tblkhachhangBL() { objtblkhachhangDA = new tblkhachhang(); }

        #region Public Method
        /// <summary>
        /// Lấy toàn bộ dữ liệu từ bảng tblkhachhang
        /// </summary>
        /// <returns>DataTable</returns>
        public DataTable GetAll()
        {
            return objtblkhachhangDA.GetAll();
        }
        /// <summary>
        /// Hàm lấy tất cả danh sách khách hàng đã có hóa đơn bán
        /// </summary>
        /// <returns>DataTable</returns>
        public DataTable GetByHoaDonBan()
        { return objtblkhachhangDA.GetByHoaDonBan(); }
        /// <summary>
        /// Hàm lấy tblkhachhang theo mã
        /// </summary>
        /// <returns>Trả về objtblkhachhang </returns>
        public tblkhachhang GetByID(string strid)
        {
            return objtblkhachhangDA.GetByID(strid);
        }
        /// <summary>
        /// Thêm mới dữ liệu vào bảng: tblkhachhang
        /// </summary>
        /// <param name="obj">objtblkhachhang</param>
        /// <returns>Trả về trắng: Thêm mới thành công; Trả về khác trắng: Thêm mới không thành công</returns>
        public string Insert(tblkhachhang objtblkhachhang)
        {
            return objtblkhachhangDA.Insert(objtblkhachhang);
        }
        /// <summary>
        /// Cập nhật dữ liệu vào bảng: tblkhachhang
        /// </summary>
        /// <param name="obj">objtblkhachhang</param>
        /// <returns>Trả về trắng: Cập nhật thành công; Trả về khác trắng: Cập nhật không thành công</returns>
        public string Update(tblkhachhang objtblkhachhang)
        {
            return objtblkhachhangDA.Update(objtblkhachhang);
        }
        /// <summary>
        /// Xóa dữ liệu từ bảng tblkhachhang
        /// </summary>
        /// <returns></returns>
        public string Delete(string strid)
        {
            return objtblkhachhangDA.Delete(strid);
        }
        /// <summary>
        /// Hàm lấy tất cả dữ liệu trong bảng tblkhachhang
        /// </summary>
        /// <returns>Trả về List<<tblkhachhang>></returns>
        public List<tblkhachhang> GetList()
        {
            return objtblkhachhangDA.GetList();
        }
        /// <summary>
        /// Hàm lấy danh sách objtblkhachhang
        /// </summary>
        /// <param name="recperpage">Số lượng bản ghi kiểu integer</param>
        /// <param name="pageindex">Số trang kiểu integer</param>
        /// <returns>Trả về List<<tblkhachhang>></returns>
        public List<tblkhachhang> GetListPaged(int recperpage, int pageindex)
        {
            return objtblkhachhangDA.GetListPaged(recperpage, pageindex);
        }
        /// <summary>
        /// Hàm lấy danh sách objtblkhachhang
        /// </summary>
        /// <param name="recperpage">Số lượng bản ghi kiểu integer</param>
        /// <param name="pageindex">Số trang kiểu integer</param>
        /// <returns>Trả về List<<tblkhachhang>></returns>
        public DataTable GetDataTablePaged(int recperpage, int pageindex)
        {
            return objtblkhachhangDA.GetDataTablePaged(recperpage, pageindex);
        }
        /// <summary>
        /// Hàm tìm kiếm khách hàng
        /// </summary>
        /// <param name="skeyword">Từ khóa type string</param>
        /// <param name="scapdl">Cấp đại lý type string</param>
        /// <returns></returns>
        public DataTable Filter(string skeyword, string scapdl)
        {
            return objtblkhachhangDA.Filter(skeyword, scapdl);
        }
        #endregion
    }
}
