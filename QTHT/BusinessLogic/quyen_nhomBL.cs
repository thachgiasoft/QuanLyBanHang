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
     /// Mô tả thông tin cho bảng quyen_nhom
     /// Cung cấp các hàm xử lý, thao tác với bảng quyen_nhom
     /// Người tạo (C): 
     /// Ngày khởi tạo: 17/10/2014
     /// </summary>
    public class quyen_nhomBL
    {
        private quyen_nhom objquyen_nhomDA = new quyen_nhom();
        public quyen_nhomBL() { objquyen_nhomDA = new quyen_nhom(); }
        #region Public Method
        /// <summary>
        /// Lấy toàn bộ dữ liệu từ bảng quyen_nhom
        /// </summary>
        /// <returns>DataTable</returns>
        public DataTable GetAll()
        {
            return objquyen_nhomDA.GetAll();
        }
        /// <summary>
        /// Hàm lấy quyen_nhom theo mã
        /// </summary>
        /// <returns>Trả về objquyen_nhom </returns>
        public quyen_nhom GetByID(string strid)
        {
            return objquyen_nhomDA.GetByID(strid);
        }
        /// <summary>
        /// Hàm lấy danh sách chức năng theo mã nhóm
        /// </summary>
        /// <param name="stridnhom">Mã nhóm kiểu string</param>
        /// <returns>DataTable</returns>
        public DataTable GetByIDNhom(string stridnhom)
        { return objquyen_nhomDA.GetByIDNhom(stridnhom); }
        /// <summary>
        /// Thêm mới dữ liệu vào bảng: quyen_nhom
        /// </summary>
        /// <param name="obj">objquyen_nhom</param>
        /// <returns>Trả về trắng: Thêm mới thành công; Trả về khác trắng: Thêm mới không thành công</returns>
        public string Insert(quyen_nhom objquyen_nhom)
        {
            return objquyen_nhomDA.Insert(objquyen_nhom);
        }
        /// <summary>
        /// Cập nhật dữ liệu vào bảng: quyen_nhom
        /// </summary>
        /// <param name="obj">objquyen_nhom</param>
        /// <returns>Trả về trắng: Cập nhật thành công; Trả về khác trắng: Cập nhật không thành công</returns>
        public string Update(quyen_nhom objquyen_nhom)
        {
            return objquyen_nhomDA.Update(objquyen_nhom);
        }
        /// <summary>
        /// Hàm xóa dữ liệu theo mã
        /// </summary>
        /// <param name="strid">Mã kiểu string</param>
        /// <returns>Trả về trắng: xóa thành công; Trả về khác trắng: xóa không thành công</returns>
        public string Delete(string strid)
        {
            return objquyen_nhomDA.Delete(strid);
        }
        /// <summary>
        /// Hàm xóa dữ liệu theo mã nhóm
        /// </summary>
        /// <param name="stridnhom">Mã nhóm kiểu string</param>
        /// <returns>Trả về trắng: xóa thành công; Trả về khác trắng: xóa không thành công</returns>
        public string DeletebyIDNhom(string stridnhom)
        { return objquyen_nhomDA.DeletebyIDNhom(stridnhom); }
        #endregion
    }
}
