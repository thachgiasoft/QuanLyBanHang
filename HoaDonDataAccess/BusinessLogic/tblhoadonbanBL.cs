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
    /// Mô tả thông tin cho bảng tblhoadonban
    /// Cung cấp các hàm xử lý, thao tác với bảng tblhoadonban
    /// Người tạo (C): tuanva
    /// Ngày khởi tạo: 16/08/2015
    /// </summary>
    public class tblhoadonbanBL
    {
        private tblhoadonban objtblhoadonbanDA = new tblhoadonban();
        public tblhoadonbanBL() { objtblhoadonbanDA = new tblhoadonban(); }
        #region Public Method
        /// <summary>
        /// Lấy toàn bộ dữ liệu từ bảng tblhoadonban
        /// </summary>
        /// <returns>DataTable</returns>
        public DataTable GetAll()
        { return objtblhoadonbanDA.GetAll(); }
        /// <summary>
        /// Hàm lấy tblhoadonban theo mã
        /// </summary>
        /// <returns>Trả về objtblhoadonban </returns>
        public tblhoadonban GetByID(string strid)
        { return objtblhoadonbanDA.GetByID(strid); }
        /// <summary>
        /// Hàm lấy hóa đơn mới nhất theo ngày tạo(chặn cuối) và mã khách hàng
        /// </summary>
        /// <param name="sngaytao">Ngày tạo kiểu string format: yyyy/MM/dd</param>
        /// <param name="sidkh">Mã khách hàng kiểu string</param>
        /// <returns>tblhoadonban</returns>
        public tblhoadonban GetNewFirstByNgayTaovsIDKH(string sngaytao, string sidkh)
        { return objtblhoadonbanDA.GetNewFirstByNgayTaovsIDKH(sngaytao, sidkh); }
        /// <summary>
        /// Hàm kiểm tra đã tồn tại hóa đơn theo mã và ngày tạo
        /// </summary>
        /// <param name="sid">Mã hóa đơn kiểu string (Guid)</param>
        /// <param name="dtngaytao">Ngày tạo kiểu DateTime</param>
        /// <returns>bool: False-Không tồn tại;True-Có tồn tại</returns>
        public bool CheckExit(string sid, DateTime dtngaytao)
        { return objtblhoadonbanDA.CheckExit(sid, dtngaytao); }
        /// <summary>
        /// Thêm mới dữ liệu vào bảng: tblhoadonban
        /// </summary>
        /// <param name="obj">objtblhoadonban</param>
        /// <returns>Trả về trắng: Thêm mới thành công; Trả về khác trắng: Thêm mới không thành công</returns>
        public string Insert(tblhoadonban objtblhoadonban)
        { return objtblhoadonbanDA.Insert(objtblhoadonban); }
        /// <summary>
        /// Cập nhật dữ liệu vào bảng: tblhoadonban
        /// </summary>
        /// <param name="obj">objtblhoadonban</param>
        /// <returns>Trả về trắng: Cập nhật thành công; Trả về khác trắng: Cập nhật không thành công</returns>
        public string Update(tblhoadonban objtblhoadonban)
        { return objtblhoadonbanDA.Update(objtblhoadonban); }
        /// <summary>
        /// Xóa dữ liệu từ bảng tblhoadonban
        /// </summary>
        /// <returns></returns>
        public string Delete(string strid)
        { return objtblhoadonbanDA.Delete(strid); }
        /// <summary>
        /// Hàm lấy tất cả dữ liệu trong bảng tblhoadonban
        /// </summary>
        /// <returns>Trả về List<<tblhoadonban>></returns>
        public List<tblhoadonban> GetList()
        { return objtblhoadonbanDA.GetList(); }
        /// <summary>
        /// Hàm lấy danh sách objtblhoadonban
        /// </summary>
        /// <param name="recperpage">Số lượng bản ghi kiểu integer</param>
        /// <param name="pageindex">Số trang kiểu integer</param>
        /// <returns>Trả về List<<tblhoadonban>></returns>
        public List<tblhoadonban> GetListPaged(int recperpage, int pageindex)
        { return objtblhoadonbanDA.GetListPaged(recperpage, pageindex); }
        /// <summary>
        /// Hàm lấy danh sách objtblhoadonban
        /// </summary>
        /// <param name="recperpage">Số lượng bản ghi kiểu integer</param>
        /// <param name="pageindex">Số trang kiểu integer</param>
        /// <returns>Trả về List<<tblhoadonban>></returns>
        public DataTable GetDataTablePaged(int recperpage, int pageindex)
        { return objtblhoadonbanDA.GetDataTablePaged(recperpage, pageindex); }
        /// <summary>
        /// Hàm tìm kiếm hóa đơn
        /// </summary>
        /// <param name="stridkh">Từ khóa (Tên khách hàng)</param>
        /// <param name="dtungay">Từ ngày kiểu date</param>
        /// <param name="ddenngay">Đến ngày kiểu date</param>
        /// <returns>DataTable</returns>
        public DataTable Filter(string skeyword, DateTime dtungay, DateTime dtdenngay)
        {
            string stungay = "";
            string sdenngay = "";
            if (dtungay.ToString("dd/MM/yyyy").Equals(dtdenngay.ToString("dd/MM/yyyy")) == true)
            {
                stungay = dtungay.ToString("yyyy/MM/dd").Trim();
                sdenngay = dtungay.AddDays(7).ToString("yyyy/MM/dd").Trim();
            }
            else
            {
                stungay = dtungay.ToString("yyyy/MM/dd").Trim();
                sdenngay = dtdenngay.AddDays(1).ToString("yyyy/MM/dd").Trim();
            }
            return objtblhoadonbanDA.Filter(skeyword, stungay, sdenngay);
        }
        /// <summary>
        /// Hàm lấy tiền còn nợ của các toa trước
        /// </summary>
        /// <param name="dtngaytao">Ngày tạo hóa đơn kiểu DateTime</param>
        /// <returns>double: Số tiền còn nợ của các toa trước</returns>
        public double GetTienConNo(string sidkh, DateTime dtngaytao)
        { return objtblhoadonbanDA.GetTienConNo(sidkh, dtngaytao); }
        /// <summary>
        /// Hàm thống kê doanh thu theo thời gian
        /// </summary>
        /// <param name="stungay">Từ ngày kiểu string format: yyyy/MM/dd</param>
        /// <param name="sdengay">Đến ngày kiểu string format: yyyy/MM/dd</param>
        /// <returns>DataTable</returns>
        public DataTable TKDoanhThu(string stungay, string sdengay)
        { return objtblhoadonbanDA.TKDoanhThu(stungay, sdengay); }
        /// <summary>
        /// Hàm thống kê doanh thu theo thời gian
        /// </summary>
        /// <param name="stungay">Từ ngày kiểu string format: yyyy/MM/dd</param>
        /// <param name="sdengay">Đến ngày kiểu string format: yyyy/MM/dd</param>
        /// <param name="sidnv">Tài khoản nhân viên kinh doanh</param>
        /// <returns>DataTable</returns>
        public DataTable TKDoanhThubyIDNV(string stungay, string sdengay, string sidnv)
        { return objtblhoadonbanDA.TKDoanhThubyIDNV(stungay, sdengay, sidnv); }
        #endregion
    }
}
