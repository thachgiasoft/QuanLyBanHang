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
     /// Mô tả thông tin cho bảng ChucVu
     /// Cung cấp các hàm xử lý, thao tác với bảng ChucVu
     /// Người tạo (C): 
     /// Ngày khởi tạo: 14/10/2014
     /// </summary>
    public class chucvuBL
    {
        private chucvu objchucvuDA = new chucvu();
        public chucvuBL() { objchucvuDA = new chucvu(); }
        #region Public Method
        /// <summary>
        /// Lấy toàn bộ dữ liệu từ bảng ChucVu
        /// </summary>
        /// <returns>DataTable</returns>
        public DataTable GetAll()
        {
            return objchucvuDA.GetAll();
        }
        /// <summary>
        /// Hàm lấy ChucVu theo mã
        /// </summary>
        /// <returns>Trả về objChucVu </returns>
        public chucvu GetByID(int intIDChucVu)
        {
            return objchucvuDA.GetByID(intIDChucVu);
        }
        /// <summary>
        /// Thêm mới dữ liệu vào bảng: ChucVu
        /// </summary>
        /// <param name="obj">objChucVu</param>
        /// <returns>Trả về trắng: Thêm mới thành công; Trả về khác trắng: Thêm mới không thành công</returns>
        public string Insert(chucvu objchucvu)
        {
            return objchucvuDA.Insert(objchucvu);
        }
        /// <summary>
        /// Cập nhật dữ liệu vào bảng: ChucVu
        /// </summary>
        /// <param name="obj">objChucVu</param>
        /// <returns>Trả về trắng: Cập nhật thành công; Trả về khác trắng: Cập nhật không thành công</returns>
        public string Update(chucvu objchucvu)
        {
            return objchucvuDA.Update(objchucvu);
        }
        /// <summary>
        /// Xóa dữ liệu từ bảng ChucVu
        /// </summary>
        /// <returns>Trả về trắng: xóa thành công; Trả về khác trắng: xóa không thành công</returns>
        public string Delete(int intIDChucVu)
        {
            return objchucvuDA.Delete(intIDChucVu);
        }
        /// <summary>
        /// Hàm kiểm tra trùng tên chức vụ
        /// </summary>
        /// <param name="sid">Mã chức vụ</param>
        /// <param name="sten">Tên chức vụ</param>
        /// <returns>bool: False-Không tồn tại;True-Có tồn tại</returns>
        public bool CheckExit(int iidchucvu, string stenchucvu)
        { return objchucvuDA.CheckExit(iidchucvu, stenchucvu); }
        #endregion
    }
}
