using System;
using System.Data;
using System.Collections.Generic;
using System.Text;
using CGCN.DataAccess;
using Npgsql;
using NpgsqlTypes;
using CGCN.Framework;
using DanhMuc.DataAccess;

namespace DanhMuc.BusinesLogic
{
     /// <summary>
     /// Mô tả thông tin cho bảng tblmathang
     /// Cung cấp các hàm xử lý, thao tác với bảng tblmathang
     /// Người tạo (C): tuanva
     /// Ngày khởi tạo: 16/08/2015
     /// </summary>
    public class tblmathangBL
    {
        private tblmathang objtblmathangDA = new tblmathang();
        public tblmathangBL() { objtblmathangDA = new tblmathang(); }

        #region Public Method
        /// <summary>
        /// Lấy toàn bộ dữ liệu từ bảng tblmathang
        /// </summary>
        /// <returns>DataTable</returns>
        public DataTable GetAll()
        {
            return objtblmathangDA.GetAll();
        }
        /// <summary>
        /// Hàm chỉ load tên mặt hàng lên combobox
        /// </summary>
        /// <returns>DataTable</returns>
        public DataTable LoadCB()
        { return objtblmathangDA.LoadCB(); }
        /// <summary>
        /// Hàm lấy tblmathang theo mã
        /// </summary>
        /// <returns>Trả về objtblmathang </returns>
        public tblmathang GetByID(string strid)
        {
            return objtblmathangDA.GetByID(strid);
        }

        public tblmathang GetByMaVach(string mavach)
        {
            return objtblmathangDA.GetByMaVach(mavach);
        }
        /// <summary>
        /// Thêm mới dữ liệu vào bảng: tblmathang
        /// </summary>
        /// <param name="obj">objtblmathang</param>
        /// <returns>Trả về trắng: Thêm mới thành công; Trả về khác trắng: Thêm mới không thành công</returns>
        public string Insert(tblmathang objtblmathang)
        {
            return objtblmathangDA.Insert(objtblmathang);
        }
        /// <summary>
        /// Cập nhật dữ liệu vào bảng: tblmathang
        /// </summary>
        /// <param name="obj">objtblmathang</param>
        /// <returns>Trả về trắng: Cập nhật thành công; Trả về khác trắng: Cập nhật không thành công</returns>
        public string Update(tblmathang objtblmathang)
        {
            return objtblmathangDA.Update(objtblmathang);
        }
        /// <summary>
        /// Xóa dữ liệu từ bảng tblmathang
        /// </summary>
        /// <returns></returns>
        public string Delete(string strid)
        {
            return objtblmathangDA.Delete(strid);
        }
        /// <summary>
        /// Hàm lấy tất cả dữ liệu trong bảng tblmathang
        /// </summary>
        /// <returns>Trả về List<<tblmathang>></returns>
        public List<tblmathang> GetList()
        {
            return objtblmathangDA.GetList();
        }
        /// <summary>
        /// Hàm lấy danh sách objtblmathang
        /// </summary>
        /// <param name="recperpage">Số lượng bản ghi kiểu integer</param>
        /// <param name="pageindex">Số trang kiểu integer</param>
        /// <returns>Trả về List<<tblmathang>></returns>
        public List<tblmathang> GetListPaged(int recperpage, int pageindex)
        {
            return objtblmathangDA.GetListPaged(recperpage, pageindex);
        }
        /// <summary>
        /// Hàm lấy danh sách objtblmathang
        /// </summary>
        /// <param name="recperpage">Số lượng bản ghi kiểu integer</param>
        /// <param name="pageindex">Số trang kiểu integer</param>
        /// <returns>Trả về List<<tblmathang>></returns>
        public DataTable GetDataTablePaged(int recperpage, int pageindex)
        {
            return objtblmathangDA.GetDataTablePaged(recperpage, pageindex);
        }
        /// <summary>
        /// Hàm tìm kiếm mặt hàng
        /// </summary>
        /// <param name="skeyword">Từ khóa kiểu string</param>
        /// <param name="sidhang">Mã hãng sản xuất kiểu string (tất cả thì set = "")</param>
        /// <param name="sidloai">Mã loại mặt hàng kiểu string (tất cả thì set = "")</param>
        /// <returns>DataTable</returns>
        public DataTable filter(string skeyword, string sidhang, string sidloai)
        { return objtblmathangDA.filter(skeyword, sidhang, sidloai); }
        /// <summary>
        /// Hàm tìm kiếm mặt hàng không giới hạn bản ghi
        /// </summary>
        /// <param name="skeyword">Từ khóa kiểu string</param>
        /// <param name="sidhang">Mã hãng sản xuất kiểu string (tất cả thì set = "")</param>
        /// <param name="sidloai">Mã loại mặt hàng kiểu string (tất cả thì set = "")</param>
        /// <returns>DataTable</returns>
        public DataTable filterall(string skeyword, string sidhang, string sidloai)
        { return objtblmathangDA.filterall(skeyword, sidhang, sidloai); }
        /// <summary>
        /// Hàm tìm kiếm mặt hàng không giới hạn bản ghi
        /// </summary>
        /// <param name="skeyword">Từ khóa kiểu string</param>
        /// <param name="sidhang">Mã hãng sản xuất kiểu string (tất cả thì set = "")</param>
        /// <param name="sidloai">Mã loại mặt hàng kiểu string (tất cả thì set = "")</param>
        /// <param name="isoluong">Số lượng mặt hàng còn lại trong kho</param>
        /// <returns>DataTable</returns>
        public DataTable filterallforthongke(string skeyword, string sidhang, string sidloai, int isoluong)
        { return objtblmathangDA.filterallforthongke(skeyword,sidhang,sidloai,isoluong); }
        /// <summary>
        /// Hàm lấy danh sách mặt hàng đã bán cho khách hàng
        /// </summary>
        /// <param name="skeyword">Từ khóa tìm kiếm kiểu string</param>
        /// <param name="sidhang">Mã hãng sản xuất kiểu string (tất cả thì set = "")</param>
        /// <param name="sidloai">Mã loại mặt hàng kiểu string (tất cả thì set = "")</param>
        /// <param name="sidkh"></param>
        /// <returns>DataTable</returns>
        public DataTable filtermathangtra(string skeyword, string sidhang, string sidloai, string sidkh)
        { return objtblmathangDA.filtermathangtra(skeyword, sidhang, sidloai, sidkh); }
        /// <summary>
        /// Hàm lấy danh sách mặt hàng đã bán cho khách hàng không giới hạn bản ghi
        /// </summary>
        /// <param name="skeyword">Từ khóa tìm kiếm kiểu string</param>
        /// <param name="sidhang">Mã hãng sản xuất kiểu string (tất cả thì set = "")</param>
        /// <param name="sidloai">Mã loại mặt hàng kiểu string (tất cả thì set = "")</param>
        /// <param name="sidkh"></param>
        /// <returns>DataTable</returns>
        public DataTable filtermathangtraall(string skeyword, string sidhang, string sidloai, string sidkh)
        { return objtblmathangDA.filtermathangtraall(skeyword, sidhang, sidloai, sidkh); }
        /// <summary>
        /// Hàm tìm kiếm theo câu truy vấn
        /// </summary>
        /// <param name="squery">câu truy vấn</param>
        /// <returns>DataTable</returns>
        public DataTable filterbyquery(string skeyword, string sidhang, string sidloai)
        {
            string query = "";
            string sdieukien = " where (1=1) ";
            if (sidhang.Trim().Equals("") == false)
            {
                sdieukien = sdieukien + "and (id_hangsx = '" + sidhang + "')";
            }
            if (sidloai.Trim().Equals("") == false)
            {
                sdieukien = sdieukien + "and (id_loai = '" + sidloai + "')";
            }
            if (skeyword.Trim().Equals("") == false)
            {
                sdieukien = sdieukien + "and (ts_rank(to_tsvector((ten || ' ' || tenkhongdau)), plainto_tsquery('" + skeyword + "')) > 0) "
                    + "and (similarity((ten || ' ' || tenkhongdau),'" + skeyword + "') > 0)";
                query = "select id,id_hangsx,id_loai,ten, gianhap,soluong,donvi,ghichu,giabanbuon,giabanle,giadl1,giadl2,giadl3,giadl4,giadl5, "
                + "ts_rank(to_tsvector((ten || ' ' || tenkhongdau)), plainto_tsquery('" + skeyword + "')) as rank, "
                + "similarity((ten || ' ' || tenkhongdau),'" + skeyword + "') as simila from tblmathang "
                + sdieukien
                + " order by simila desc,rank desc,ten asc limit 15";
                return objtblmathangDA.filterbyquery(query);
            }
            else
            {
                query = "select id,id_hangsx,id_loai,ten, gianhap,soluong,donvi,ghichu,giabanbuon,giabanle,giadl1,giadl2,giadl3,giadl4,giadl5 "
                + "from view_mathang "
                + sdieukien
                + " order by ten asc limit 20";
            }
            return objtblmathangDA.filterbyquery(query);
        }
        /// <summary>
        /// Hàm lấy danh sách đơn vị tính mặt hàng
        /// </summary>
        /// <returns>DataTable</returns>
        public DataTable GetDonViTinh()
        { return objtblmathangDA.GetDonViTinh(); }
        #endregion
    }
}
