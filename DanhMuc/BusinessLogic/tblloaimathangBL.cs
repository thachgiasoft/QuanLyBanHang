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
     /// Mô tả thông tin cho bảng tblloaimathang
     /// Cung cấp các hàm xử lý, thao tác với bảng tblloaimathang
     /// Người tạo (C): 
     /// Ngày khởi tạo: 29/09/2015
     /// </summary>
    public class tblloaimathangBL
    {
        private tblloaimathang objtblloaimathangDA = new tblloaimathang();
        public tblloaimathangBL() { objtblloaimathangDA = new tblloaimathang(); }
        #region Public Method
        /// <summary>
        /// Lấy toàn bộ dữ liệu từ bảng tblloaimathang
        /// </summary>
        /// <returns>DataTable</returns>
        public DataTable GetAll()
        {
            return objtblloaimathangDA.GetAll();
        }
        /// <summary>
        /// Hàm lấy tblloaimathang theo mã
        /// </summary>
        /// <returns>Trả về objtblloaimathang </returns>
        public tblloaimathang GetByID(string strid)
        {
            return objtblloaimathangDA.GetByID(strid);
        }
        /// <summary>
        /// Thêm mới dữ liệu vào bảng: tblloaimathang
        /// </summary>
        /// <param name="obj">objtblloaimathang</param>
        /// <returns>Trả về trắng: Thêm mới thành công; Trả về khác trắng: Thêm mới không thành công</returns>
        public string Insert(tblloaimathang objtblloaimathang)
        {
            return objtblloaimathangDA.Insert(objtblloaimathang);
        }
        /// <summary>
        /// Cập nhật dữ liệu vào bảng: tblloaimathang
        /// </summary>
        /// <param name="obj">objtblloaimathang</param>
        /// <returns>Trả về trắng: Cập nhật thành công; Trả về khác trắng: Cập nhật không thành công</returns>
        public string Update(tblloaimathang objtblloaimathang)
        {
            return objtblloaimathangDA.Update(objtblloaimathang);
        }
        /// <summary>
        /// Xóa dữ liệu từ bảng tblloaimathang
        /// </summary>
        /// <returns></returns>
        public string Delete(string strid)
        {
            return objtblloaimathangDA.Delete(strid);
        }
        /// <summary>
        /// Hàm lấy tất cả dữ liệu trong bảng tblloaimathang
        /// </summary>
        /// <returns>Trả về List<<tblloaimathang>></returns>
        public List<tblloaimathang> GetList()
        {
            return objtblloaimathangDA.GetList();
        }
        /// <summary>
        /// Hàm lấy danh sách objtblloaimathang
        /// </summary>
        /// <param name="recperpage">Số lượng bản ghi kiểu integer</param>
        /// <param name="pageindex">Số trang kiểu integer</param>
        /// <returns>Trả về List<<tblloaimathang>></returns>
        public List<tblloaimathang> GetListPaged(int recperpage, int pageindex)
        {
            return objtblloaimathangDA.GetListPaged(recperpage, pageindex);
        }
        /// <summary>
        /// Hàm lấy danh sách objtblloaimathang
        /// </summary>
        /// <param name="recperpage">Số lượng bản ghi kiểu integer</param>
        /// <param name="pageindex">Số trang kiểu integer</param>
        /// <returns>Trả về List<<tblloaimathang>></returns>
        public DataTable GetDataTablePaged(int recperpage, int pageindex)
        {
            return objtblloaimathangDA.GetDataTablePaged(recperpage, pageindex);
        }
        /// <summary>
        /// Hàm kiểm tra trùng tên và ký hiệu
        /// </summary>
        /// <param name="sid">Mã loại mặt hàng</param>
        /// <param name="skyhieu">Ký hiệu loại mặt hàng</param>
        /// <param name="sten">Tên loại mặt hàng</param>
        /// <returns>bool: False-Không tồn tại;True-Có tồn tại</returns>
        public bool CheckExit(string sid, string skyhieu, string sten)
        {
            return objtblloaimathangDA.CheckExit(sid, skyhieu, sten);
        }
        #endregion
    }
}
