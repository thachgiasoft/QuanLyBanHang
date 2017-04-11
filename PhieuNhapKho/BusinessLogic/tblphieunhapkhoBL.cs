using System;
using System.Data;
using System.Collections.Generic;
using System.Text;
using CGCN.Framework;
using Npgsql;
using NpgsqlTypes;
using CGCN.DataAccess;
using PhieuNhapKho.DataAccess;

namespace PhieuNhapKho.BusinesLogic
{
    /// <summary>
    /// Mô tả thông tin cho bảng tblphieunhapkho
    /// Cung cấp các hàm xử lý, thao tác với bảng tblphieunhapkho
    /// Người tạo (C): tuanva
    /// Ngày khởi tạo: 03/12/2015
    /// </summary>
    public class tblphieunhapkhoBL
    {
        private tblphieunhapkho objtblphieunhapkhoDA = new tblphieunhapkho();
        public tblphieunhapkhoBL() { objtblphieunhapkhoDA = new tblphieunhapkho(); }
        #region Public Method
        /// <summary>
        /// Lấy toàn bộ dữ liệu từ bảng tblphieunhapkho
        /// </summary>
        /// <returns>DataTable</returns>
        public DataTable GetAll()
        {
            return objtblphieunhapkhoDA.GetAll();
        }
        /// <summary>
        /// Hàm lấy tblphieunhapkho theo mã
        /// </summary>
        /// <returns>Trả về objtblphieunhapkho </returns>
        public tblphieunhapkho GetByID(string strid)
        {
            return objtblphieunhapkhoDA.GetByID(strid);
        }
        /// <summary>
        /// Hàm lấy hóa đơn nhập mới nhất theo ngày tạo(chặn cuối) và mã nhà cung cấp
        /// </summary>
        /// <param name="sngaytao">Ngày tạo kiểu string format: yyyy/MM/dd</param>
        /// <param name="sidnhacc">Mã nhà cung cấp kiểu string</param>
        /// <returns>tblphieunhapkho</returns>
        public tblphieunhapkho GetNewFirstByNgayTaovsIDKH(string sngaytao, string sidnhacc)
        { return objtblphieunhapkhoDA.GetNewFirstByNgayTaovsIDKH(sngaytao,sidnhacc);}
        /// <summary>
        /// Thêm mới dữ liệu vào bảng: tblphieunhapkho
        /// </summary>
        /// <param name="obj">objtblphieunhapkho</param>
        /// <returns>Trả về trắng: Thêm mới thành công; Trả về khác trắng: Thêm mới không thành công</returns>
        public string Insert(tblphieunhapkho objtblphieunhapkho)
        {
            return objtblphieunhapkhoDA.Insert(objtblphieunhapkho);
        }
        /// <summary>
        /// Cập nhật dữ liệu vào bảng: tblphieunhapkho
        /// </summary>
        /// <param name="obj">objtblphieunhapkho</param>
        /// <returns>Trả về trắng: Cập nhật thành công; Trả về khác trắng: Cập nhật không thành công</returns>
        public string Update(tblphieunhapkho objtblphieunhapkho)
        {
            return objtblphieunhapkho.Update(objtblphieunhapkho);
        }
        /// <summary>
        /// Xóa dữ liệu từ bảng tblphieunhapkho
        /// </summary>
        /// <returns></returns>
        public string Delete(string strid)
        {
            return objtblphieunhapkhoDA.Delete(strid);
        }
        /// <summary>
        /// Hàm lấy tất cả dữ liệu trong bảng tblphieunhapkho
        /// </summary>
        /// <returns>Trả về List<<tblphieunhapkho>></returns>
        public List<tblphieunhapkho> GetList()
        {
            return objtblphieunhapkhoDA.GetList();
        }
        /// <summary>
        /// Hàm lấy danh sách objtblphieunhapkho
        /// </summary>
        /// <param name="recperpage">Số lượng bản ghi kiểu integer</param>
        /// <param name="pageindex">Số trang kiểu integer</param>
        /// <returns>Trả về List<<tblphieunhapkho>></returns>
        public List<tblphieunhapkho> GetListPaged(int recperpage, int pageindex)
        {
            return objtblphieunhapkhoDA.GetListPaged(recperpage, pageindex);
        }
        /// <summary>
        /// Hàm lấy danh sách objtblphieunhapkho
        /// </summary>
        /// <param name="recperpage">Số lượng bản ghi kiểu integer</param>
        /// <param name="pageindex">Số trang kiểu integer</param>
        /// <returns>Trả về List<<tblphieunhapkho>></returns>
        public DataTable GetDataTablePaged(int recperpage, int pageindex)
        {
            return objtblphieunhapkhoDA.GetDataTablePaged(recperpage, pageindex);
        }
        /// <summary>
        /// Hàm tìm kiếm phiếu nhập
        /// </summary>
        /// <param name="stungay">Từ ngày kiểu string format: yyyy/MM/dd</param>
        /// <param name="sdenngay">Đến ngày kiểu string format: yyyy/MM/dd</param>
        /// <returns>DataTable</returns>
        public DataTable Filter(DateTime dtungay, DateTime dtdenngay)
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
            return objtblphieunhapkhoDA.Filter(stungay, sdenngay);
        }
        /// <summary>
        /// Hàm tìm kiếu phiếu nhập kho
        /// </summary>
        /// <param name="skeyword">Từ khóa kiểu string</param>
        /// <param name="tungay">Từ ngày kiểu DateTime</param>
        /// <param name="denngay">Đến ngày kiểu DateTime</param>
        /// <returns>DataTable</returns>
        public DataTable Filter(string skeyword, DateTime tungay, DateTime denngay)
        {
            DateTime dttungay = DateTime.Now.AddMonths(-2);
            try { dttungay = tungay; }
            catch { }
            DateTime dtdenngay = DateTime.Now.AddDays(1);
            try { dtdenngay = denngay; }
            catch { }
            if (dttungay.ToString("dd/MM/yyyy").Trim().Equals(dtdenngay.ToString("dd/MM/yyyy").Trim()) == true)
            {
                dttungay = dtdenngay.AddMonths(-2);
            }
            return objtblphieunhapkhoDA.Filter(skeyword, dttungay.ToString("yyyy/MM/dd").Trim(), dtdenngay.AddDays(1).ToString("yyyy/MM/dd").Trim()); ;
        }
        /// <summary>
        /// Hàm lấy tiền còn nợ của các toa trước
        /// </summary>
        /// <param name="dtngaytao">Ngày tạo hóa đơn kiểu DateTime</param>
        /// <returns>double: Số tiền còn nợ của các toa trước</returns>
        public double GetTienConNo(string sidnhacc, DateTime dtngaytao)
        { return objtblphieunhapkhoDA.GetTienConNo(sidnhacc, dtngaytao); }
        /// <summary>
        /// Hàm kiểm tra đã tồn tại phiếu nhập theo mã và ngày tạo
        /// </summary>
        /// <param name="sid">Mã phiếu nhập kiểu string (Guid)</param>
        /// <param name="dtngaytao">Ngày tạo kiểu DateTime</param>
        /// <returns>bool: False-Không tồn tại;True-Có tồn tại</returns>
        public bool CheckExit(string sid, DateTime dtngaytao)
        { return objtblphieunhapkhoDA.CheckExit(sid, dtngaytao); }
        #endregion
    }
}
