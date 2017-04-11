using System;
using System.Data;
using System.Collections.Generic;
using System.Text;
using CGCN.Framework;
using Npgsql;
using NpgsqlTypes;
using CGCN.DataAccess;
using HoaDonDataAccess.DataAccess;

namespace HoaDonDataAccess.BusinesLogic
{
    /// <summary>
    /// Mô tả thông tin cho bảng tblhoadontra
    /// Cung cấp các hàm xử lý, thao tác với bảng tblhoadontra
    /// Người tạo (C): tuanva
    /// Ngày khởi tạo: 15/10/2015
    /// </summary>
    public class tblhoadontraBL
    {
        private tblhoadontra objtblhoadontraDA = new tblhoadontra();
        public tblhoadontraBL() { objtblhoadontraDA = new tblhoadontra(); }
        #region Public Method
        /// <summary>
        /// Lấy toàn bộ dữ liệu từ bảng tblhoadontra
        /// </summary>
        /// <returns>DataTable</returns>
        public DataTable GetAll()
        {
            return objtblhoadontraDA.GetAll();
        }
        /// <summary>
        /// Hàm lấy tblhoadontra theo mã
        /// </summary>
        /// <returns>Trả về objtblhoadontra </returns>
        public tblhoadontra GetByID(string strid)
        {
            return objtblhoadontraDA.GetByID(strid);
        }
        /// <summary>
        /// Thêm mới dữ liệu vào bảng: tblhoadontra
        /// </summary>
        /// <param name="obj">objtblhoadontra</param>
        /// <returns>Trả về trắng: Thêm mới thành công; Trả về khác trắng: Thêm mới không thành công</returns>
        public string Insert(tblhoadontra objtblhoadontra)
        {
            return objtblhoadontraDA.Insert(objtblhoadontra);
        }
        /// <summary>
        /// Cập nhật dữ liệu vào bảng: tblhoadontra
        /// </summary>
        /// <param name="obj">objtblhoadontra</param>
        /// <returns>Trả về trắng: Cập nhật thành công; Trả về khác trắng: Cập nhật không thành công</returns>
        public string Update(tblhoadontra objtblhoadontra)
        {
            return objtblhoadontraDA.Update(objtblhoadontra);
        }
        /// <summary>
        /// Xóa dữ liệu từ bảng tblhoadontra
        /// </summary>
        /// <returns></returns>
        public string Delete(string strid)
        {
            return objtblhoadontraDA.Delete(strid);
        }
        /// <summary>
        /// Hàm lấy tất cả dữ liệu trong bảng tblhoadontra
        /// </summary>
        /// <returns>Trả về List<<tblhoadontra>></returns>
        public List<tblhoadontra> GetList()
        {
            return objtblhoadontraDA.GetList();
        }
        /// <summary>
        /// Hàm lấy danh sách objtblhoadontra
        /// </summary>
        /// <param name="recperpage">Số lượng bản ghi kiểu integer</param>
        /// <param name="pageindex">Số trang kiểu integer</param>
        /// <returns>Trả về List<<tblhoadontra>></returns>
        public List<tblhoadontra> GetListPaged(int recperpage, int pageindex)
        {
            return objtblhoadontraDA.GetListPaged(recperpage, pageindex);
        }
        /// <summary>
        /// Hàm lấy danh sách objtblhoadontra
        /// </summary>
        /// <param name="recperpage">Số lượng bản ghi kiểu integer</param>
        /// <param name="pageindex">Số trang kiểu integer</param>
        /// <returns>Trả về List<<tblhoadontra>></returns>
        public DataTable GetDataTablePaged(int recperpage, int pageindex)
        {
            return objtblhoadontraDA.GetDataTablePaged(recperpage, pageindex);
        }
        /// <summary>
        /// Hàm tìm kiếm hóa đơn trả lại hàng
        /// </summary>
        /// <param name="skeyword">Từ khóa (Tên khách hàng, dt, ghichu, diachi)</param>
        /// <param name="stungay">Từ ngày kiểu string format: yyyy/MM/dd</param>
        /// <param name="sdengay">Đến ngày kiểu string format: yyyy/MM/dd</param>
        /// <returns>DataTable</returns>
        public DataTable Filter(string skeyword, DateTime dtungay, DateTime ddenngay)
        {
            string stungay = "";
            string sdengay = "";
            if (dtungay.ToString("dd/MM/yyyy").Equals(ddenngay.ToString("dd/MM/yyyy")) == true)
            {
                stungay = dtungay.ToString("yyyy/MM/dd").Trim();
                sdengay = dtungay.AddDays(7).ToString("yyyy/MM/dd").Trim();
            }
            else
            {
                stungay = dtungay.ToString("yyyy/MM/dd").Trim();
                sdengay = ddenngay.AddDays(1).ToString("yyyy/MM/dd").Trim();
            }
            return objtblhoadontraDA.Filter(skeyword, stungay, sdengay);
        }
        #endregion
    }
}
