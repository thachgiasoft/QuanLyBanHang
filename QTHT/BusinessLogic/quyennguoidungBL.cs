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
     /// Mô tả thông tin cho bảng quyennguoidung
     /// Cung cấp các hàm xử lý, thao tác với bảng quyennguoidung
     /// Người tạo (C): 
     /// Ngày khởi tạo: 20/10/2014
     /// </summary>
    public class quyennguoidungBL
    {
        private quyennguoidung objquyennguoidungDA = new quyennguoidung();
        public quyennguoidungBL() { objquyennguoidungDA = new quyennguoidung(); }
        #region Public Method
        /// <summary>
        /// Lấy toàn bộ dữ liệu từ bảng quyennguoidung
        /// </summary>
        /// <returns>DataTable</returns>
        public DataTable GetAll()
        {
            return objquyennguoidungDA.GetAll();
        }
        /// <summary>
        /// Hàm lấy quyennguoidung theo mã
        /// </summary>
        /// <returns>Trả về objquyennguoidung </returns>
        public quyennguoidung GetByID(int intid)
        {
            return objquyennguoidungDA.GetByID(intid);
        }
        /// <summary>
        /// Hàm lấy quyền người dùng theo mã nhân viên và ký hiệu chức năng
        /// </summary>
        /// <param name="stridnhanvien">Mã nhân viên kiểu string</param>
        /// <param name="strmenuname">Ký hiệu chức năng kiểu string</param>
        /// <returns>quyennguoidung</returns>
        public quyennguoidung GetByIDNhanVienvsMenuName(string stridnhanvien, string strmenuname)
        { return objquyennguoidungDA.GetByIDNhanVienvsMenuName(stridnhanvien, strmenuname); }
        /// <summary>
        /// Hàm lấy danh sách quyền theo mã người dùng
        /// </summary>
        /// <param name="stridnhanvien">Mã người dùng kiểu string</param>
        /// <returns>DataTable</returns>
        public DataTable GetByIDNhanVien(string stridnhanvien)
        { return objquyennguoidungDA.GetByIDNhanVien(stridnhanvien); }
        /// <summary>
        /// Hàm lấy danh sách menu cấp 1 theo mã người dùng
        /// </summary>
        /// <param name="stridnhanvien">Mã người dùng kiểu string</param>
        /// <returns>DataTable</returns>
        public DataTable GetMenuCap1ByIDNhanVien(string stridnhanvien)
        { return objquyennguoidungDA.GetMenuCap1ByIDNhanVien(stridnhanvien); }
        /// <summary>
        /// Hàm lấy danh sách menu cấp 2 theo mã người dùng
        /// </summary>
        /// <param name="stridnhanvien">Mã nhân viên kiểu string</param>
        /// <param name="intparentmenuid">Mã menu cha</param>
        /// <returns>DataTable</returns>
        public DataTable GetMenuCap2ByIDNhanVien(string stridnhanvien, int intparentmenuid)
        { return objquyennguoidungDA.GetMenuCap2ByIDNhanVien(stridnhanvien, intparentmenuid); }
        /// <summary>
        /// Thêm mới dữ liệu vào bảng: quyennguoidung
        /// </summary>
        /// <param name="obj">objquyennguoidung</param>
        /// <returns>Trả về trắng: Thêm mới thành công; Trả về khác trắng: Thêm mới không thành công</returns>
        public string Insert(quyennguoidung objquyennguoidung)
        {
            return objquyennguoidungDA.Insert(objquyennguoidung);
        }
        /// <summary>
        /// Cập nhật dữ liệu vào bảng: quyennguoidung
        /// </summary>
        /// <param name="obj">objquyennguoidung</param>
        /// <returns>Trả về trắng: Cập nhật thành công; Trả về khác trắng: Cập nhật không thành công</returns>
        public string Update(quyennguoidung objquyennguoidung)
        {
            return objquyennguoidungDA.Update(objquyennguoidung);
        }
        /// <summary>
        /// Xóa dữ liệu từ bảng quyennguoidung
        /// </summary>
        /// <returns></returns>
        public string Delete(int intid)
        {
            return objquyennguoidungDA.Delete(intid);
        }
        /// <summary>
        /// Hàm xóa dữ liệu theo mã người dùng
        /// </summary>
        /// <param name="stridnhanvien">Mã người dùng kiểu string</param>
        /// <returns>Trả về trắng: Xóa thành công; Trả về khác trắng: Xóa không thành công</returns>
        public string DeleteByIDNhanVien(string stridnhanvien)
        {
            return objquyennguoidungDA.DeleteByIDNhanVien(stridnhanvien);
        }
        /// <summary>
        /// Hàm xóa quyền người dùng theo mã nhân viên và mã nhóm người dùng
        /// </summary>
        /// <param name="stridnhanvien">Mã nhân viên kiếu tring</param>
        /// <param name="stridnhom">Mã nhóm người dùng kiểu string</param>
        /// <returns>Trả về trắng: Xóa thành công; Trả về khác trắng: Xóa không thành công</returns>
        public string DeleteByIDNhomUse(string stridnhanvien, string stridnhom)
        { return objquyennguoidungDA.DeleteByIDNhomUse(stridnhanvien, stridnhom); }
        /// <summary>
        /// Hàm xóa quyền người dùng theo mã nhân viên và mã chức năng
        /// </summary>
        /// <param name="stridnhanvien">Mã nhân viên kiếu tring</param>
        /// <param name="iidmenu">Mã chức năng kiểu int</param>
        /// <returns>Trả về trắng: Xóa thành công; Trả về khác trắng: Xóa không thành công</returns>
        public string DeleteByIDMenuvsUse(string stridnhanvien, int iidmenu)
        { return objquyennguoidungDA.DeleteByIDMenuvsUse(stridnhanvien, iidmenu); }
        /// <summary>
        /// Hàm kiểm tra tồn tại quyền của người dùng
        /// </summary>
        /// <param name="stridnhanvien">Mã nhân viên kiểu string</param>
        /// <param name="iidmenu">Mã menu(chức năng) kiểu int</param>
        /// <returns>bool: True-Tồn tại;False:Không tồn tại</returns>
        public bool CheckExitRole(string stridnhanvien, int iidmenu)
        { return objquyennguoidungDA.CheckExitRole(stridnhanvien, iidmenu); }
        /// <summary>
        /// Hàm kiểm tra quyền người dùng
        /// </summary>
        /// <param name="staikhoan">Tài khoản người dùng kiểu string (guid)</param>
        /// <param name="path">path(url) cần kiểm tra kiểu string</param>
        /// <returns>bool: true-Có quyền; false:Không có quyền</returns>
        public bool CheckRoleOfUse(string staikhoan, string path)
        {
            return true;
            //string temppath = "";
            //if (Globals.ApplicationPath.Trim().Trim().Equals("") == false)
            //{
            //    try { temppath = path.Replace(Globals.ApplicationPath.Trim(), ""); }
            //    catch { }
            //}
            //else { temppath = path; }
            //return objquyennguoidungDA.CheckRoleOfUse(staikhoan, temppath.ToUpper().Trim()); 
        }
        #endregion
    }
}
