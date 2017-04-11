using System;
using System.Data;
using System.Collections.Generic;
using System.Text;
using Npgsql;
using NpgsqlTypes;
using QTHT.DataAccess;

namespace QTHT.BusinesLogic
{
     /// <summary>
     /// Mô tả thông tin cho bảng nhom_nhanvien
     /// Cung cấp các hàm xử lý, thao tác với bảng nhom_nhanvien
     /// Người tạo (C): 
     /// Ngày khởi tạo: 20/10/2014
     /// </summary>
    public class nhom_nhanvienBL
    {
        private nhom_nhanvien objnhom_nhanvienDA = new nhom_nhanvien();
        public nhom_nhanvienBL() { objnhom_nhanvienDA = new nhom_nhanvien(); }
        #region Public Method
        /// <summary>
        /// Lấy toàn bộ dữ liệu từ bảng nhom_nhanvien
        /// </summary>
        /// <returns>DataTable</returns>
        public DataTable GetAll()
        {
            return objnhom_nhanvienDA.GetAll();
        }
        /// <summary>
        /// Hàm lấy nhom_nhanvien theo mã
        /// </summary>
        /// <returns>Trả về objnhom_nhanvien </returns>
        public nhom_nhanvien GetByID(string stridnhom_nhanvien)
        {
            return objnhom_nhanvienDA.GetByID(stridnhom_nhanvien);
        }
        /// <summary>
        /// Hàm lấy danh sách người dùng theo mã nhóm
        /// </summary>
        /// <param name="stridnhom">Mã nhóm kiểu string</param>
        /// <returns>DataTable</returns>
        public DataTable GetByIDNhom(string stridnhom)
        { return objnhom_nhanvienDA.GetByIDNhom(stridnhom); }
        /// <summary>
        /// Hàm lấy danh sách nhóm theo mã người dùng
        /// </summary>
        /// <param name="stridnhanvien">Mã người dùng kiểu string</param>
        /// <returns>DataTable</returns>
        public DataTable GetByIDNhanVien(string stridnhanvien)
        { return objnhom_nhanvienDA.GetByIDNhanVien(stridnhanvien); }
        /// <summary>
        /// Thêm mới dữ liệu vào bảng: nhom_nhanvien
        /// </summary>
        /// <param name="obj">objnhom_nhanvien</param>
        /// <returns>Trả về trắng: Thêm mới thành công; Trả về khác trắng: Thêm mới không thành công</returns>
        public string Insert(nhom_nhanvien objnhom_nhanvien)
        {
            return objnhom_nhanvienDA.Insert(objnhom_nhanvien);
        }
        /// <summary>
        /// Cập nhật dữ liệu vào bảng: nhom_nhanvien
        /// </summary>
        /// <param name="obj">objnhom_nhanvien</param>
        /// <returns>Trả về trắng: Cập nhật thành công; Trả về khác trắng: Cập nhật không thành công</returns>
        public string Update(nhom_nhanvien objnhom_nhanvien)
        {
            return objnhom_nhanvienDA.Update(objnhom_nhanvien);
        }
        /// <summary>
        /// Xóa dữ liệu từ bảng nhom_nhanvien
        /// </summary>
        /// <returns></returns>
        public string Delete(string stridnhom_nhanvien)
        {
            return objnhom_nhanvienDA.Delete(stridnhom_nhanvien);
        }
        /// <summary>
        /// Xóa dữ liệu theo mã nhóm người dùng
        /// </summary>
        /// <param name="stridnhom">Mã nhóm người dùng kiểu string</param>
        /// <returns>Trả về trắng: Xóa thành công; Trả về khác trắng: Xóa không thành công</returns>
        public string DeleteByIDNhom(string stridnhom)
        { return objnhom_nhanvienDA.DeleteByIDNhom(stridnhom); }
        public string DeleteByIDNhanVien(string stridnhanvien)
        { return objnhom_nhanvienDA.DeleteByIDNhanVien(stridnhanvien); }
        #endregion
    }
}
