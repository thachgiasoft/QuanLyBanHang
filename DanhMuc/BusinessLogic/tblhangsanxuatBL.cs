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
     /// Mô tả thông tin cho bảng ChucVu
     /// Cung cấp các hàm xử lý, thao tác với bảng ChucVu
     /// Người tạo (C): 
     /// Ngày khởi tạo: 14/10/2014
     /// </summary>
    public class tblhangsanxuatBL
    {
        private tblhangsanxuat objtblhangsanxuatDA = new tblhangsanxuat();
        public tblhangsanxuatBL() { objtblhangsanxuatDA = new tblhangsanxuat(); }
        #region Public Method
        /// <summary>
        /// Lấy toàn bộ dữ liệu từ bảng tblhangsanxuat
        /// </summary>
        /// <returns>DataTable</returns>
        public DataTable GetAll()
        {
            return objtblhangsanxuatDA.GetAll();
        }
        /// <summary>
        /// Hàm lấy tblhangsanxuat theo mã
        /// </summary>
        /// <returns>Trả về objtblhangsanxuat </returns>
        public tblhangsanxuat GetByID(string strid)
        {
            return objtblhangsanxuatDA.GetByID(strid);
        }
        /// <summary>
        /// Thêm mới dữ liệu vào bảng: tblhangsanxuat
        /// </summary>
        /// <param name="obj">objtblhangsanxuat</param>
        /// <returns>Trả về trắng: Thêm mới thành công; Trả về khác trắng: Thêm mới không thành công</returns>
        public string Insert(tblhangsanxuat objtblhangsanxuat)
        {
            return objtblhangsanxuatDA.Insert(objtblhangsanxuat);
        }
        /// <summary>
        /// Cập nhật dữ liệu vào bảng: tblhangsanxuat
        /// </summary>
        /// <param name="obj">objtblhangsanxuat</param>
        /// <returns>Trả về trắng: Cập nhật thành công; Trả về khác trắng: Cập nhật không thành công</returns>
        public string Update(tblhangsanxuat objtblhangsanxuat)
        {
            return objtblhangsanxuatDA.Update(objtblhangsanxuat);
        }
        /// <summary>
        /// Xóa dữ liệu từ bảng tblhangsanxuat
        /// </summary>
        /// <returns></returns>
        public string Delete(string strid)
        {
            return objtblhangsanxuatDA.Delete(strid);
        }
        /// <summary>
        /// Hàm lấy tất cả dữ liệu trong bảng tblhangsanxuat
        /// </summary>
        /// <returns>Trả về List<<tblhangsanxuat>></returns>
        public List<tblhangsanxuat> GetList()
        {
            return objtblhangsanxuatDA.GetList();
        }
        /// <summary>
        /// Hàm lấy danh sách objtblhangsanxuat
        /// </summary>
        /// <param name="recperpage">Số lượng bản ghi kiểu integer</param>
        /// <param name="pageindex">Số trang kiểu integer</param>
        /// <returns>Trả về List<<tblhangsanxuat>></returns>
        public List<tblhangsanxuat> GetListPaged(int recperpage, int pageindex)
        {
            return objtblhangsanxuatDA.GetListPaged(recperpage, pageindex);
        }
        /// <summary>
        /// Hàm lấy danh sách objtblhangsanxuat
        /// </summary>
        /// <param name="recperpage">Số lượng bản ghi kiểu integer</param>
        /// <param name="pageindex">Số trang kiểu integer</param>
        /// <returns>Trả về List<<tblhangsanxuat>></returns>
        public DataTable GetDataTablePaged(int recperpage, int pageindex)
        {
            return objtblhangsanxuatDA.GetDataTablePaged(recperpage, pageindex);
        }
        /// <summary>
        /// Hàm kiểm tra trùng tên
        /// </summary>
        /// <param name="sid">Mã hãng sản xuất</param>
        /// <param name="sten">Tên hãng sản suất</param>
        /// <returns>bool: False-Không tồn tại;True-Có tồn tại</returns>
        public bool CheckExit(string sid, string sten)
        { return objtblhangsanxuatDA.CheckExit(sid, sten); }
        #endregion
    }
}
