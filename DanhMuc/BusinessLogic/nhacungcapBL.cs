using System;
using System.Data;
using System.Collections.Generic;
using System.Text;
using Npgsql;
using NpgsqlTypes;
using DanhMuc.DataAccess;

namespace DanhMuc.BusinesLogic
{
     /// <summary>
     /// Mô tả thông tin cho bảng nhacungcap
     /// Cung cấp các hàm xử lý, thao tác với bảng nhacungcap
     /// Người tạo (C): tuanva
     /// Ngày khởi tạo: 16/03/2016
     /// </summary>
    public class nhacungcapBL
    {
        private nhacungcap objnhacungcapDA = new nhacungcap();
        public nhacungcapBL() { objnhacungcapDA = new nhacungcap(); }
        #region Public Method
        /// <summary>
        /// Lấy toàn bộ dữ liệu từ bảng nhacungcap
        /// </summary>
        /// <returns>DataTable</returns>
        public DataTable GetAll()
        {
            return objnhacungcapDA.GetAll();
        }
        /// <summary>
        /// Hàm lấy nhacungcap theo mã
        /// </summary>
        /// <returns>Trả về objnhacungcap </returns>
        public nhacungcap GetByID(string strid)
        {
            return objnhacungcapDA.GetByID(strid);
        }
        /// <summary>
        /// Thêm mới dữ liệu vào bảng: nhacungcap
        /// </summary>
        /// <param name="obj">objnhacungcap</param>
        /// <returns>Trả về trắng: Thêm mới thành công; Trả về khác trắng: Thêm mới không thành công</returns>
        public string Insert(nhacungcap objnhacungcap)
        {
            return objnhacungcapDA.Insert(objnhacungcap);
        }
        /// <summary>
        /// Cập nhật dữ liệu vào bảng: nhacungcap
        /// </summary>
        /// <param name="obj">objnhacungcap</param>
        /// <returns>Trả về trắng: Cập nhật thành công; Trả về khác trắng: Cập nhật không thành công</returns>
        public string Update(nhacungcap objnhacungcap)
        {
            return objnhacungcapDA.Update(objnhacungcap);
        }
        /// <summary>
        /// Xóa dữ liệu từ bảng nhacungcap
        /// </summary>
        /// <returns>Trả về trắng: Thêm mới thành công; Trả về khác trắng: Thêm mới không thành công</returns>
        public string Delete(string strid)
        {
            return objnhacungcapDA.Delete(strid);
        }
        /// <summary>
        /// Hàm lấy tất cả dữ liệu trong bảng nhacungcap
        /// </summary>
        /// <returns>Trả về List<<nhacungcap>></returns>
        public List<nhacungcap> GetList()
        {
            return objnhacungcapDA.GetList();
        }
        /// <summary>
        /// Hàm lấy danh sách objnhacungcap
        /// </summary>
        /// <param name="recperpage">Số lượng bản ghi kiểu integer</param>
        /// <param name="pageindex">Số trang kiểu integer</param>
        /// <returns>Trả về List<<nhacungcap>></returns>
        public List<nhacungcap> GetListPaged(int recperpage, int pageindex)
        {
            return objnhacungcapDA.GetListPaged(recperpage, pageindex);
        }
        /// <summary>
        /// Hàm lấy danh sách objnhacungcap
        /// </summary>
        /// <param name="recperpage">Số lượng bản ghi kiểu integer</param>
        /// <param name="pageindex">Số trang kiểu integer</param>
        /// <returns>Trả về List<<nhacungcap>></returns>
        public DataTable GetDataTablePaged(int recperpage, int pageindex)
        {
            return objnhacungcapDA.GetDataTablePaged(recperpage, pageindex);
        }
        /// <summary>
        /// Hàm tìm kiếm nhà cung cấp
        /// </summary>
        /// <param name="skeyword">Từ khóa type string</param>
        /// <returns>DataTable</returns>
        public DataTable Filter(string skeyword)
        { return objnhacungcapDA.Filter(skeyword); }
        /// <summary>
        /// Hàm lấy tất cả danh sách nhà cung cấp đã có hóa đơn nhập hàng
        /// </summary>
        /// <returns>DataTable</returns>
        public DataTable GetByPhieuNhap()
        { return objnhacungcapDA.GetByPhieuNhap(); }
        #endregion
    }
}
