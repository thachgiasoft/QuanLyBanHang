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
     /// Mô tả thông tin cho bảng PhongBan
     /// Cung cấp các hàm xử lý, thao tác với bảng PhongBan
     /// Người tạo (C): 
     /// Ngày khởi tạo: 14/10/2014
     /// </summary>
    public class phongbanBL
    {
        private phongban objphongbanDA = new phongban();
        public phongbanBL() { objphongbanDA = new phongban(); }
        #region Public Method
        /// <summary>
        /// Lấy toàn bộ dữ liệu từ bảng PhongBan
        /// </summary>
        /// <returns>DataTable</returns>
        public DataTable GetAll()
        {
            return objphongbanDA.GetAll();
        }
        public DataTable GetAllPhongBanvsDonVi()
        {
            return objphongbanDA.GetAllPhongBanvsDonVi();
        }
        /// <summary>
        /// Hàm lấy PhongBan theo mã
        /// </summary>
        /// <returns>Trả về objPhongBan </returns>
        public phongban GetByID(string strIDPhongBan)
        {
            return objphongbanDA.GetByID(strIDPhongBan);
        }
        /// <summary>
        /// Thêm mới dữ liệu vào bảng: PhongBan
        /// </summary>
        /// <param name="obj">objPhongBan</param>
        /// <returns>Trả về trắng: Thêm mới thành công; Trả về khác trắng: Thêm mới không thành công</returns>
        public string Insert(phongban objPhongBan)
        {
            return objphongbanDA.Insert(objPhongBan);
        }
        /// <summary>
        /// Cập nhật dữ liệu vào bảng: PhongBan
        /// </summary>
        /// <param name="obj">objPhongBan</param>
        /// <returns>Trả về trắng: Cập nhật thành công; Trả về khác trắng: Cập nhật không thành công</returns>
        public string Update(phongban objPhongBan)
        {
            return objphongbanDA.Update(objPhongBan);
        }
        /// <summary>
        /// Xóa dữ liệu từ bảng PhongBan
        /// </summary>
        /// <returns>Trả về trắng: xóa thành công; Trả về khác trắng: xóa không thành công</returns>
        public string Delete(string strIDPhongBan)
        {
            return objphongbanDA.Delete(strIDPhongBan);
        }
        /// <summary>
        /// Hàm kiểm tra trùng tên phòng ban
        /// </summary>
        /// <param name="sid">Mã phòng ban</param>
        /// <param name="sten">Tên phòng ban</param>
        /// <returns>bool: False-Không tồn tại;True-Có tồn tại</returns>
        public bool CheckExit(string sidphongban, string stenphongban)
        { return objphongbanDA.CheckExit(sidphongban, stenphongban); }
        #endregion
    }
}
