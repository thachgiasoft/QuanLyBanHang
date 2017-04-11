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
     /// Mô tả thông tin cho bảng menu
     /// Cung cấp các hàm xử lý, thao tác với bảng menu
     /// Người tạo (C): 
     /// Ngày khởi tạo: 17/10/2014
     /// </summary>
    public class menuBL
    {
        private menu objmenuDA = new menu();
        public menuBL() { objmenuDA = new menu(); }
        #region Public Method
        /// <summary>
        /// Lấy toàn bộ dữ liệu từ bảng menu
        /// </summary>
        /// <returns>DataTable</returns>
        public DataTable GetAll()
        {
            return objmenuDA.GetAll();
        }
        /// <summary>
        /// Hàm lấy menu theo mã
        /// </summary>
        /// <returns>Trả về objmenu </returns>
        public menu GetByID(int intmenuid)
        {
            return objmenuDA.GetByID(intmenuid);
        }
        /// <summary>
        /// Thêm mới dữ liệu vào bảng: menu
        /// </summary>
        /// <param name="obj">objmenu</param>
        /// <returns>Trả về menuid kiểu int: 0-Không thành công;<>0:Thành công</returns>
        public int Insert(menu objmenu)
        {
            return objmenuDA.Insert(objmenu);
        }
        /// <summary>
        /// Cập nhật dữ liệu vào bảng: menu
        /// </summary>
        /// <param name="obj">objmenu</param>
        /// <returns>Trả về trắng: Cập nhật thành công; Trả về khác trắng: Cập nhật không thành công</returns>
        public string Update(menu objmenu)
        {
            return objmenuDA.Update(objmenu);
        }
        /// <summary>
        /// Xóa dữ liệu từ bảng menu
        /// </summary>
        /// <returns>Trả về trắng: xóa thành công; Trả về khác trắng: xóa không thành công</returns>
        public string Delete(int intmenuid)
        {
            return objmenuDA.Delete(intmenuid);
        }
        #endregion
    }
}
