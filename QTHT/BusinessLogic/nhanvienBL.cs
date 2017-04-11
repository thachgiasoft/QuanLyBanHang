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
     /// Mô tả thông tin cho bảng NhanVien
     /// Cung cấp các hàm xử lý, thao tác với bảng NhanVien
     /// Người tạo (C): 
     /// Ngày khởi tạo: 14/10/2014
     /// </summary>
    public class nhanvienBL
    {
        private nhanvien objnhanvienDA = new nhanvien();
        public nhanvienBL() { objnhanvienDA = new nhanvien(); }
        #region Public Method
        /// <summary>
        /// Lấy toàn bộ dữ liệu từ bảng NhanVien
        /// </summary>
        /// <returns>DataTable</returns>
        public DataTable GetAll()
        {
            return objnhanvienDA.GetAll();
        }
        /// <summary>
        /// Lấy toàn bộ dữ liệu từ bảng nhanvien(Chỉ lấy id,taikhoan,hoten)
        /// </summary>
        /// <returns>DataTable</returns>
        public DataTable GetAllNotFullField()
        { return objnhanvienDA.GetAllNotFullField(); }
        /// <summary>
        /// Hàm lấy NhanVien theo mã
        /// </summary>
        /// <returns>Trả về objNhanVien </returns>
        public nhanvien GetByID(string stridNhanVien)
        {
            return objnhanvienDA.GetByID(stridNhanVien);
        }
        /// <summary>
        /// Hàm lấy danh sách nhân viên theo mã phòng ban
        /// </summary>
        /// <param name="stridphongban">Mã phòng ban kiểu string</param>
        /// <returns>DataTable</returns>
        public DataTable GetByIDPhongBan(string stridphongban)
        { return objnhanvienDA.GetByIDPhongBan(stridphongban); }
        /// <summary>
        /// Hàm lấy danh sách nhân viên theo tên tài khoản
        /// </summary>
        /// <param name="sTaiKhoan">Tên tài khoản kiểu string</param>
        /// <returns>DataTable</returns>
        public DataTable GetByAccountName(string sTaiKhoan)
        { return objnhanvienDA.GetByAccountName(sTaiKhoan); }
        /// <summary>
        /// Thêm mới dữ liệu vào bảng: NhanVien
        /// </summary>
        /// <param name="obj">objNhanVien</param>
        /// <returns>Trả về trắng: Thêm mới thành công; Trả về khác trắng: Thêm mới không thành công</returns>
        public string Insert(nhanvien objNhanVien)
        {
            return objnhanvienDA.Insert(objNhanVien);
        }
        /// <summary>
        /// Cập nhật dữ liệu vào bảng: NhanVien
        /// </summary>
        /// <param name="obj">objNhanVien</param>
        /// <returns>Trả về trắng: Cập nhật thành công; Trả về khác trắng: Cập nhật không thành công</returns>
        public string Update(nhanvien objNhanVien)
        {
            return objnhanvienDA.Update(objNhanVien);
        }
        public string UpdateInfo(string sidnhanvien, string shoten, DateTime dtngaysinh, string sdiachi, string sdienthoai, string semail, string sghichu, bool bgioitinh)
        {
            return objnhanvienDA.UpdateInfo(sidnhanvien, shoten, dtngaysinh, sdiachi, sdienthoai, semail, sghichu, bgioitinh);
        }
        public string ChangePass(string sidnhanvien, string smatkhau)
        { return objnhanvienDA.ChangePass(sidnhanvien, smatkhau); }
        /// <summary>
        /// Xóa dữ liệu từ bảng NhanVien
        /// </summary>
        /// <returns>Trả về trắng: xóa thành công; Trả về khác trắng: xóa không thành công</returns>
        public string Delete(string stridNhanVien)
        {
            return objnhanvienDA.Delete(stridNhanVien);
        }
        /// <summary>
        /// Hàm kiểm tra đăng nhập
        /// </summary>
        /// <param name="sTaiKhoan">Tài khoản kiểu string</param>
        /// <param name="sMatKhau">Mật khẩu kiểu string</param>
        /// <returns>bool: true-là đúng; false-là sai</returns>
        public bool Authentication(string sTaiKhoan, string sMatKhau)
        {
            return objnhanvienDA.Authentication(sTaiKhoan, sMatKhau);
        }
        /// <summary>
        /// Hàm kiểm tra tồn tại tài khoản
        /// </summary>
        /// <param name="sTaiKhoan">Tài khoản kiểu string</param>
        /// <param name="iTrangThai">Trạng thái: 1-Thêm mới; 2-Sửa</param>
        /// <returns>bool: True-Tồn tại;False-Không tồn tại</returns>
        public bool CheckExitAccount(string sTaiKhoan, int iTrangThai)
        {
            DataTable dt = new DataTable();
            dt = objnhanvienDA.CheckExitAccount(sTaiKhoan, iTrangThai);
            if (dt.Rows.Count > 0) { return true; }
            else { return false; }
        }
        /// <summary>
        /// Hàm kiểm tra tồn tại người dùng theo mã
        /// </summary>
        /// <param name="stridnhanvien">Mã người dùng kiểu string</param>
        /// <returns>bool</returns>
        public bool CheckExitAccount(string stridnhanvien)
        { return objnhanvienDA.CheckExitAccount(stridnhanvien); }
        /// <summary>
        /// Hàm kiểm tra tồn tại email
        /// </summary>
        /// <param name="semail">Email kiểu string</param>
        /// <returns>bool: true-tồn tại; false-không tồn tại</returns>
        public bool CheckEmail(string semail)
        { return objnhanvienDA.CheckEmail(semail); }
        /// <summary>
        /// Hàm lấy thông tin người dùng theo email
        /// </summary>
        /// <param name="semail">Email kiểu string</param>
        /// <returns>DataTable</returns>
        public DataTable GetbyEmail(string semail)
        { return objnhanvienDA.GetbyEmail(semail); }
        /// <summary>
        /// Hàm lấy mã người dùng theo tài khoản đăng nhập
        /// </summary>
        /// <param name="stridnhanvien">Mã người dùng kiểu string</param>
        /// <returns>string</returns>
        public string GetIDNhanVienByAccount(string strtaikhoan)
        { return objnhanvienDA.GetIDNhanVienByAccount(strtaikhoan); }
        /// <summary>
        /// Hàm tìm kiếm nhân viên
        /// </summary>
        /// <param name="sHoTen">Họ tên kiểu string</param>
        /// <param name="sMaPhongBan">Mã phòng ban kiểu string</param>
        /// <param name="iMaChucVu">Mã chức vụ kiểu int</param>
        /// <returns>DataTable</returns>
        public DataTable TimKiem(string sHoTen, string sMaPhongBan, int iMaChucVu)
        {
            string sDieuKien = "(1=1)";
            if (sHoTen.Trim().Equals("") == false)
            { sDieuKien = sDieuKien + "AND upper(\"nhanvien\".\"hoten\") LIKE upper('" + sHoTen + "') || '%' "; }
            if (sMaPhongBan.Trim().Equals("") == false)
            { sDieuKien = sDieuKien + "AND \"nhanvien\".\"idphongban\" = '" + sMaPhongBan + "' "; }
            if (iMaChucVu != 0)
            { sDieuKien = sDieuKien + "AND \"nhanvien\".\"idchucvu\" = '" + iMaChucVu + "' "; }
            return objnhanvienDA.TimKiem(sDieuKien);
        }
        /// <summary>
        /// Hàm lấy thông tin người dùng
        /// </summary>
        /// <param name="strtaikhoan">IN: tài khoản</param>
        /// <param name="siduser">OUT: mã người dùng</param>
        /// <param name="shoten">OUT: họ tên người dùng</param>
        /// <param name="iloai">OUT: kiểu người dùng: 0-Người dùng nội bộ;1-Người dùng đăng ký(khách hàng)</param>
        /// <returns>string:0-Người dùng nội bộ;1-Người dùng đăng ký(khách hàng)</returns>
        public string GetInfoUserByAccount(string strtaikhoan, out string siduser, out string shoten, out string sloai)
        {
            return objnhanvienDA.GetInfoUserByAccount(strtaikhoan, out siduser, out shoten, out sloai); 
        }
        /// <summary>
        /// Hàm kiểm tra quyền download tư liệu theo loại tư liệu và mã người dùng
        /// </summary>
        /// <param name="siduser">Mã người dùng kiểu string</param>
        /// <param name="sidloaitl">Mã loại tư liệu kiểu string</param>
        /// <returns>bool: True-Có;False:Không</returns>
        public bool CheckLoaiTLDownload(string siduser, string sidloaitl)
        { return objnhanvienDA.CheckLoaiTLDownload(siduser, sidloaitl); }
        /// <summary>
        /// Hàm kiểm tra quyền download file số
        /// </summary>
        /// <param name="siduser">Mã người dùng</param>
        /// <param name="sidloaitulieu">Mã loại tư liệu</param>
        /// <param name="snoibo">kiểu người dùng:0-Người dùng nội bộ;1-Người dùng là khách vãng lai</param>
        /// <param name="iCoPhi">Kiểu tư liệu có phí hay không: 0-Không có phí;1-Tư liệu có phí</param>
        /// <returns>bool: True-Có quyền;False-Không có quyền</returns>
        public bool CheckRoleDownLoad(string siduser, string sidloaitulieu,string snoibo,int iCoPhi)
        {
            if (iCoPhi == 0)
            { return true; }
            if (sidloaitulieu.Trim().Equals("") == true && snoibo.Trim().Equals("0") == true)
            {
                return true;
            }
            if (snoibo.Trim().Equals("0") == true)
            {
                if (CheckLoaiTLDownload(siduser, sidloaitulieu) == true)
                { return true; }
                else { return false; }
            }
            return false;
        }
        /// <summary>
        /// Đăng nhập
        /// </summary>
        /// <param name="staikhoan">Tài khoản kiểu string</param>
        /// <param name="smatkhau">Mật khẩu kiểu string đã được băm theo thuật toán MD5</param>
        /// <returns>bool: True-Thành công; False-Không thành công</returns>
        public bool DangNhap(string staikhoan, string smatkhau)
        { return objnhanvienDA.DangNhap(staikhoan, smatkhau); }
        /// <summary>
        /// Hàm load danh sách nhân viên với trường taikhoan + hoten
        /// </summary>
        /// <returns>DataTable</returns>
        public DataTable LoadDSCBNV()
        { return objnhanvienDA.LoadDSCBNV(); }
        #endregion
    }
}
