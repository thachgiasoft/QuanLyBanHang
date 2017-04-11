using System;
using System.Data;
using System.Collections.Generic;
using System.Text;
using CGCN.Framework;
using Npgsql;
using NpgsqlTypes;
using CGCN.DataAccess;
using PhieuNhapKho.DataAccess;
using HoaDonDataAccess.BusinesLogic;

namespace PhieuNhapKho.BusinesLogic
{
    /// <summary>
    /// Mô tả thông tin cho bảng tblhangnhapkho
    /// Cung cấp các hàm xử lý, thao tác với bảng tblhangnhapkho
    /// Người tạo (C): tuanva
    /// Ngày khởi tạo: 03/12/2015
    /// </summary>
    public class tblhangnhapkhoBL
    {
        private tblhangnhapkho objtblhangnhapkhoDA = new tblhangnhapkho();
        public tblhangnhapkhoBL() { objtblhangnhapkhoDA = new tblhangnhapkho(); }
        #region Public Method
        /// <summary>
        /// Lấy toàn bộ dữ liệu từ bảng tblhangnhapkho
        /// </summary>
        /// <returns>DataTable</returns>
        public DataTable GetAll()
        {
            return objtblhangnhapkhoDA.GetAll();
        }
        /// <summary>
        /// Hàm lấy tblhangnhapkho theo mã
        /// </summary>
        /// <returns>Trả về objtblhangnhapkho </returns>
        public tblhangnhapkho GetByID(string strid)
        {
            return objtblhangnhapkhoDA.GetByID(strid);
        }
        /// <summary>
        /// Hàm lấy danh sách mặt hàng theo mã phiếu nhập kho
        /// </summary>
        /// <param name="stridpn">Mã phiếu nhập kho kiểu string</param>
        /// <returns>DataTable</returns>
        public DataTable GetByIDPN(string stridpn)
        { return objtblhangnhapkhoDA.GetByIDPN(stridpn); }
        /// <summary>
        /// Thêm mới dữ liệu vào bảng: tblhangnhapkho
        /// </summary>
        /// <param name="obj">objtblhangnhapkho</param>
        /// <returns>Trả về trắng: Thêm mới thành công; Trả về khác trắng: Thêm mới không thành công</returns>
        public string Insert(tblhangnhapkho objtblhangnhapkho)
        {
            return objtblhangnhapkhoDA.Insert(objtblhangnhapkho);
        }
        /// <summary>
        /// Cập nhật dữ liệu vào bảng: tblhangnhapkho
        /// </summary>
        /// <param name="obj">objtblhangnhapkho</param>
        /// <returns>Trả về trắng: Cập nhật thành công; Trả về khác trắng: Cập nhật không thành công</returns>
        public string Update(tblhangnhapkho objtblhangnhapkho)
        {
            return objtblhangnhapkhoDA.Update(objtblhangnhapkho);
        }
        /// <summary>
        /// Xóa dữ liệu từ bảng tblhangnhapkho
        /// </summary>
        /// <returns></returns>
        public string Delete(string strid)
        {
            return objtblhangnhapkhoDA.Delete(strid);
        }
        /// <summary>
        /// Hàm lấy tất cả dữ liệu trong bảng tblhangnhapkho
        /// </summary>
        /// <returns>Trả về List<<tblhangnhapkho>></returns>
        public List<tblhangnhapkho> GetList()
        {
            return objtblhangnhapkhoDA.GetList();
        }
        /// <summary>
        /// Hàm lấy danh sách objtblhangnhapkho
        /// </summary>
        /// <param name="recperpage">Số lượng bản ghi kiểu integer</param>
        /// <param name="pageindex">Số trang kiểu integer</param>
        /// <returns>Trả về List<<tblhangnhapkho>></returns>
        public List<tblhangnhapkho> GetListPaged(int recperpage, int pageindex)
        {
            return objtblhangnhapkhoDA.GetListPaged(recperpage, pageindex);
        }
        /// <summary>
        /// Hàm lấy danh sách objtblhangnhapkho
        /// </summary>
        /// <param name="recperpage">Số lượng bản ghi kiểu integer</param>
        /// <param name="pageindex">Số trang kiểu integer</param>
        /// <returns>Trả về List<<tblhangnhapkho>></returns>
        public DataTable GetDataTablePaged(int recperpage, int pageindex)
        {
            return objtblhangnhapkhoDA.GetDataTablePaged(recperpage, pageindex);
        }
        /// <summary>
        /// Hàm tính tổng tiền mua hàng theo hóa đơn nhập
        /// </summary>
        /// <param name="sidpn">Mã phiếu nhập kiểu string</param>
        /// <returns>Tổng tiền đã mua hàng kiểu double</returns>
        public double GetTongTienByIDPN(string sidpn)
        {
            double tongtien = 0;
            try
            {
                tienthanhtoanphieunhapBL ctr = new tienthanhtoanphieunhapBL();
                DataTable dt = new DataTable();
                dt = GetByIDPN(sidpn);
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    double tienofrow = 0;
                    try { tienofrow = Convert.ToDouble(dt.Rows[i]["soluong"].ToString().Trim()) * Convert.ToDouble(dt.Rows[i]["gianhap"].ToString().Trim()); }
                    catch { }
                    tongtien = tongtien + tienofrow;
                }
                return tongtien;
            }
            catch { return tongtien; }
        }
        #endregion
    }
}
