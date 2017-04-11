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
     /// Mô tả thông tin cho bảng nhom
     /// Cung cấp các hàm xử lý, thao tác với bảng nhom
     /// Người tạo (C): 
     /// Ngày khởi tạo: 17/10/2014
     /// </summary>
    public class nhomBL
    {
        private nhom objnhomDA = new nhom();
        public nhomBL() { objnhomDA = new nhom(); }
        #region Public Method
        /// <summary>
        /// Lấy toàn bộ dữ liệu từ bảng nhom
        /// </summary>
        /// <returns>DataTable</returns>
        public DataTable GetAll()
        {
            return objnhomDA.GetAll();
        }
        /// <summary>
        /// Hàm lấy nhom theo mã
        /// </summary>
        /// <returns>Trả về objnhom </returns>
        public nhom GetByID(string stridnhom)
        {
            return objnhomDA.GetByID(stridnhom);
        }
        /// <summary>
        /// Hàm kiểm tra trùng tên nhóm
        /// </summary>
        /// <param name="strtennhom">Tên nhóm kiểu string</param>
        /// <param name="stridnhom">Mã nhóm kiểu string</param>
        /// <param name="itrangthai">Trạng thái: 1-Thêm mới;2-Sửa</param>
        /// <returns>bool: True-Trùng;False-Không trùng</returns>
        public bool CheckExit(string strtennhom, string stridnhom)
        {
            if (stridnhom.Trim().Equals("") == true) { return objnhomDA.CheckExit(strtennhom, stridnhom, 1); }
            else { return objnhomDA.CheckExit(strtennhom, stridnhom, 2); }
        }
        /// <summary>
        /// Thêm mới dữ liệu vào bảng: nhom
        /// </summary>
        /// <param name="obj">objnhom</param>
        /// <returns>Trả về trắng: Thêm mới thành công; Trả về khác trắng: Thêm mới không thành công</returns>
        public string Insert(nhom objnhom)
        {
            return objnhomDA.Insert(objnhom);
        }
        /// <summary>
        /// Cập nhật dữ liệu vào bảng: nhom
        /// </summary>
        /// <param name="obj">objnhom</param>
        /// <returns>Trả về trắng: Cập nhật thành công; Trả về khác trắng: Cập nhật không thành công</returns>
        public string Update(nhom objnhom)
        {
            return objnhomDA.Update(objnhom);
        }
        /// <summary>
        /// Xóa dữ liệu từ bảng nhom
        /// </summary>
        /// <returns>Trả về trắng: xóa thành công; Trả về khác trắng: xóa không thành công</returns>
        public string Delete(string stridnhom)
        {
            return objnhomDA.Delete(stridnhom);
        }
        /// <summary>
        /// Hàm kiểm tra trùng tên nhóm người dùng
        /// </summary>
        /// <param name="sid">Mã nhóm người dùng</param>
        /// <param name="sten">Tên nhóm người dùng</param>
        /// <returns>bool: False-Không tồn tại;True-Có tồn tại</returns>
        public bool CheckExit1(string sidnhom, string stennhom)
        { return objnhomDA.CheckExit(sidnhom, stennhom); }
        #endregion
    }
}
