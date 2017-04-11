using System;
using System.Data;
using System.Collections.Generic;
using System.Text;
using Npgsql;
using NpgsqlTypes;
using CGCN.Framework;
using CGCN.DataAccess;

namespace QTHT.DataAccess
{
     /// <summary>
     /// Mô tả thông tin cho bảng NhanVien
     /// Cung cấp các hàm xử lý, thao tác với bảng NhanVien
     /// Người tạo (C): 
     /// Ngày khởi tạo: 14/10/2014
     /// </summary>
    public class nhanvien
    {
        #region Private Variables
        private string stridnhanvien;
        private string stridphongban;
        private int intidchucvu;
        private string strtaikhoan;
        private string strmatkhau;
        private string strhoten;
        private DateTime dtmngaysinh;
        private string strdiachi;
        private string strdienthoai;
        private string stremail;
        private string strghichu;
        private bool blngioitinh;
        #endregion

        #region Public Constructor Functions
        public nhanvien()
        {
            stridnhanvien = string.Empty;
            stridphongban = string.Empty;
            intidchucvu = 0;
            strtaikhoan = string.Empty;
            strmatkhau = string.Empty;
            strhoten = string.Empty;
            dtmngaysinh = DateTime.Now;
            strdiachi = string.Empty;
            strdienthoai = string.Empty;
            stremail = string.Empty;
            strghichu = string.Empty;
            blngioitinh = false;

        }

        public nhanvien(string stridnhanvien, string stridphongban, int intidchucvu, string strtaikhoan, string strmatkhau, string strhoten, DateTime dtmngaysinh, string strdiachi, string strdienthoai, string stremail, string strghichu, bool blngioitinh)
        {
            this.stridnhanvien = stridnhanvien;
            this.stridphongban = stridphongban;
            this.intidchucvu = intidchucvu;
            this.strtaikhoan = strtaikhoan;
            this.strmatkhau = strmatkhau;
            this.strhoten = strhoten;
            this.dtmngaysinh = dtmngaysinh;
            this.strdiachi = strdiachi;
            this.strdienthoai = strdienthoai;
            this.stremail = stremail;
            this.strghichu = strghichu;
            this.blngioitinh = blngioitinh;
        }
        #endregion

        #region Properties
        public string idnhanvien
        {
            get
            {
                return stridnhanvien;
            }
            set
            {
                stridnhanvien = value;
            }
        }

        public string idphongban
        {
            get
            {
                return stridphongban;
            }
            set
            {
                stridphongban = value;
            }
        }

        public int idchucvu
        {
            get
            {
                return intidchucvu;
            }
            set
            {
                intidchucvu = value;
            }
        }

        public string taikhoan
        {
            get
            {
                return strtaikhoan;
            }
            set
            {
                strtaikhoan = value;
            }
        }

        public string matkhau
        {
            get
            {
                return strmatkhau;
            }
            set
            {
                strmatkhau = value;
            }
        }

        public string hoten
        {
            get
            {
                return strhoten;
            }
            set
            {
                strhoten = value;
            }
        }

        public DateTime ngaysinh
        {
            get
            {
                return dtmngaysinh;
            }
            set
            {
                dtmngaysinh = value;
            }
        }

        public string diachi
        {
            get
            {
                return strdiachi;
            }
            set
            {
                strdiachi = value;
            }
        }

        public string dienthoai
        {
            get
            {
                return strdienthoai;
            }
            set
            {
                strdienthoai = value;
            }
        }

        public string email
        {
            get
            {
                return stremail;
            }
            set
            {
                stremail = value;
            }
        }

        public string ghichu
        {
            get
            {
                return strghichu;
            }
            set
            {
                strghichu = value;
            }
        }

        public bool gioitinh
        {
            get
            {
                return blngioitinh;
            }
            set
            {
                blngioitinh = value;
            }
        }
        #endregion

        #region Public Method
        private readonly DataAccessLayerBaseClass mDataAccess = new DataAccessLayerBaseClass(Data.ConnectionString);
        /// <summary>
        /// Lấy toàn bộ dữ liệu từ bảng nhanvien
        /// </summary>
        /// <returns>DataTable</returns>
        public DataTable GetAll()
        {
            string strFun = "fn_nhanvien_getall";
            try
            {
                DataSet dsnhanvien = mDataAccess.ExecuteDataSet(strFun, CommandType.StoredProcedure);
                return dsnhanvien.Tables[0];
            }
            catch
            {
                return null;
            }
        }
        /// <summary>
        /// Lấy toàn bộ dữ liệu từ bảng nhanvien(Chỉ lấy id,taikhoan,hoten)
        /// </summary>
        /// <returns>DataTable</returns>
        public DataTable GetAllNotFullField()
        {
            string strFun = "fn_nhanvien_getallnotfullfield";
            try
            {
                DataSet dsnhanvien = mDataAccess.ExecuteDataSet(strFun, CommandType.StoredProcedure);
                return dsnhanvien.Tables[0];
            }
            catch
            {
                return null;
            }
        }
        /// <summary>
        /// Hàm lấy nhanvien theo mã
        /// </summary>
        /// <returns>Trả về objnhanvien </returns>
        public nhanvien GetByID(string stridnhanvien)
        {
            nhanvien objnhanvien = new nhanvien();
            string strFun = "fn_nhanvien_getobjbyid";
            try
            {
                NpgsqlParameter[] prmArr = new NpgsqlParameter[1];

                prmArr[0] = new NpgsqlParameter("idnhanvien", NpgsqlDbType.Varchar);
                prmArr[0].Value = stridnhanvien;

                DataSet dsnhanvien = mDataAccess.ExecuteDataSet(strFun, CommandType.StoredProcedure, prmArr);

                if ((dsnhanvien != null) && (dsnhanvien.Tables.Count > 0))
                {
                    if (dsnhanvien.Tables[0].Rows.Count > 0)
                    {
                        DataRow dr = dsnhanvien.Tables[0].Rows[0];
                        objnhanvien.idnhanvien = dr["idnhanvien"].ToString();

                        objnhanvien.idphongban = dr["idphongban"].ToString();

                        try { objnhanvien.idchucvu = Convert.ToInt32("0" + dr["idchucvu"].ToString()); }
                        catch { objnhanvien.idchucvu = 0; }

                        objnhanvien.taikhoan = dr["taikhoan"].ToString();

                        objnhanvien.matkhau = dr["matkhau"].ToString();

                        objnhanvien.hoten = dr["hoten"].ToString();

                        try { objnhanvien.ngaysinh = Convert.ToDateTime(dr["ngaysinh"].ToString()); }
                        catch { objnhanvien.ngaysinh = new DateTime(1900, 1, 1); }

                        objnhanvien.diachi = dr["diachi"].ToString();

                        objnhanvien.dienthoai = dr["dienthoai"].ToString();

                        objnhanvien.email = dr["email"].ToString();

                        objnhanvien.ghichu = dr["ghichu"].ToString();

                        objnhanvien.gioitinh = Convert.ToBoolean(dr["gioitinh"].ToString());


                        return objnhanvien;
                    }

                    return null;
                }

                return null;
            }
            catch
            {
                return null;
            }
        }
        /// <summary>
        /// Hàm lấy danh sách nhân viên theo mã phòng ban
        /// </summary>
        /// <param name="stridphongban">Mã phòng ban kiểu string</param>
        /// <returns>DataTable</returns>
        public DataTable GetByIDPhongBan(string stridphongban)
        {
            nhanvien objnhanvien = new nhanvien();
            string strFun = "fn_nhanvien_getbyidphongban";
            try
            {
                NpgsqlParameter[] prmArr = new NpgsqlParameter[1];
                prmArr[0] = new NpgsqlParameter("idphongban", NpgsqlDbType.Varchar);
                prmArr[0].Value = stridphongban;
                DataSet dsnhanvien = mDataAccess.ExecuteDataSet(strFun, CommandType.StoredProcedure, prmArr);
                return dsnhanvien.Tables[0];
            }
            catch
            {
                return null;
            }
        }
        /// <summary>
        /// Thêm mới dữ liệu vào bảng: nhanvien
        /// </summary>
        /// <param name="obj">objnhanvien</param>
        /// <returns>Trả về trắng: Thêm mới thành công; Trả về khác trắng: Thêm mới không thành công</returns>
        public string Insert(nhanvien objnhanvien)
        {
            string strProc = "fn_nhanvien_insert";
            try
            {
                NpgsqlParameter[] prmArr = new NpgsqlParameter[13];

                prmArr[0] = new NpgsqlParameter("idnhanvien", NpgsqlDbType.Varchar);
                prmArr[0].Value = objnhanvien.stridnhanvien;

                prmArr[1] = new NpgsqlParameter("idphongban", NpgsqlDbType.Varchar);
                prmArr[1].Value = objnhanvien.stridphongban;

                prmArr[2] = new NpgsqlParameter("idchucvu", NpgsqlDbType.Integer);
                prmArr[2].Value = objnhanvien.intidchucvu;

                prmArr[3] = new NpgsqlParameter("taikhoan", NpgsqlDbType.Varchar);
                prmArr[3].Value = objnhanvien.strtaikhoan;

                prmArr[4] = new NpgsqlParameter("matkhau", NpgsqlDbType.Varchar);
                prmArr[4].Value = objnhanvien.strmatkhau;

                prmArr[5] = new NpgsqlParameter("hoten", NpgsqlDbType.Varchar);
                prmArr[5].Value = objnhanvien.strhoten;

                prmArr[6] = new NpgsqlParameter("ngaysinh", NpgsqlDbType.Date);
                prmArr[6].Value = objnhanvien.dtmngaysinh;

                prmArr[7] = new NpgsqlParameter("diachi", NpgsqlDbType.Varchar);
                prmArr[7].Value = objnhanvien.strdiachi;

                prmArr[8] = new NpgsqlParameter("dienthoai", NpgsqlDbType.Varchar);
                prmArr[8].Value = objnhanvien.strdienthoai;

                prmArr[9] = new NpgsqlParameter("email", NpgsqlDbType.Varchar);
                prmArr[9].Value = objnhanvien.stremail;

                prmArr[10] = new NpgsqlParameter("ghichu", NpgsqlDbType.Varchar);
                prmArr[10].Value = objnhanvien.strghichu;

                prmArr[11] = new NpgsqlParameter("gioitinh", NpgsqlDbType.Boolean);
                prmArr[11].Value = objnhanvien.blngioitinh;

                prmArr[12] = new NpgsqlParameter("ireturn", NpgsqlDbType.Text);
                prmArr[12].Direction = ParameterDirection.Output;

                mDataAccess.ExecuteQuery(strProc, CommandType.StoredProcedure, prmArr);

                string sKQ = prmArr[12].Value.ToString().Trim();

                if (sKQ.ToUpper().Equals("Add".ToUpper()) == true) return "";
                return "Thêm mới dữ liệu không thành công";
            }
            catch (Exception ex)
            {
                return "Thêm mới dữ liệu không thành công. Chi Tiết: " + ex.Message;
            }
        }
        /// <summary>
        /// Cập nhật dữ liệu vào bảng: nhanvien
        /// </summary>
        /// <param name="obj">objnhanvien</param>
        /// <returns>Trả về trắng: Cập nhật thành công; Trả về khác trắng: Cập nhật không thành công</returns>
        public string Update(nhanvien objnhanvien)
        {
            string strProc = "fn_nhanvien_Update";
            try
            {
                NpgsqlParameter[] prmArr = new NpgsqlParameter[13];

                prmArr[0] = new NpgsqlParameter("idnhanvien", NpgsqlDbType.Varchar);
                prmArr[0].Value = objnhanvien.stridnhanvien;

                prmArr[1] = new NpgsqlParameter("idphongban", NpgsqlDbType.Varchar);
                prmArr[1].Value = objnhanvien.stridphongban;

                prmArr[2] = new NpgsqlParameter("idchucvu", NpgsqlDbType.Integer);
                prmArr[2].Value = objnhanvien.intidchucvu;

                prmArr[3] = new NpgsqlParameter("taikhoan", NpgsqlDbType.Varchar);
                prmArr[3].Value = objnhanvien.strtaikhoan;

                prmArr[4] = new NpgsqlParameter("matkhau", NpgsqlDbType.Varchar);
                prmArr[4].Value = objnhanvien.strmatkhau;

                prmArr[5] = new NpgsqlParameter("hoten", NpgsqlDbType.Varchar);
                prmArr[5].Value = objnhanvien.strhoten;

                prmArr[6] = new NpgsqlParameter("ngaysinh", NpgsqlDbType.Date);
                prmArr[6].Value = objnhanvien.dtmngaysinh;

                prmArr[7] = new NpgsqlParameter("diachi", NpgsqlDbType.Varchar);
                prmArr[7].Value = objnhanvien.strdiachi;

                prmArr[8] = new NpgsqlParameter("dienthoai", NpgsqlDbType.Varchar);
                prmArr[8].Value = objnhanvien.strdienthoai;

                prmArr[9] = new NpgsqlParameter("email", NpgsqlDbType.Varchar);
                prmArr[9].Value = objnhanvien.stremail;

                prmArr[10] = new NpgsqlParameter("ghichu", NpgsqlDbType.Varchar);
                prmArr[10].Value = objnhanvien.strghichu;

                prmArr[11] = new NpgsqlParameter("gioitinh", NpgsqlDbType.Boolean);
                prmArr[11].Value = objnhanvien.blngioitinh;

                prmArr[12] = new NpgsqlParameter("ireturn", NpgsqlDbType.Text);
                prmArr[12].Direction = ParameterDirection.Output;

                mDataAccess.ExecuteQuery(strProc, CommandType.StoredProcedure, prmArr);
                string sKQ = prmArr[12].Value.ToString().Trim();
                if (sKQ.ToUpper().Equals("Update".ToUpper()) == true) return "";
                return "Cập nhật dữ liệu không thành công";

            }
            catch (Exception ex)
            {
                return "Cập nhật dữ liệu không thành công. Chi Tiết: " + ex.Message;
            }
        }
        public string UpdateInfo(string sidnhanvien,string shoten,DateTime dtngaysinh,string sdiachi,string sdienthoai,string semail,string sghichu,bool bgioitinh )
        {
            string strProc = "fn_nhanvien_updateinfo";
            try
            {
                NpgsqlParameter[] prmArr = new NpgsqlParameter[9];

                prmArr[0] = new NpgsqlParameter("idnhanvien", NpgsqlDbType.Varchar);
                prmArr[0].Value = sidnhanvien;

                prmArr[1] = new NpgsqlParameter("hoten", NpgsqlDbType.Varchar);
                prmArr[1].Value = shoten;

                prmArr[2] = new NpgsqlParameter("ngaysinh", NpgsqlDbType.Date);
                prmArr[2].Value = dtngaysinh;

                prmArr[3] = new NpgsqlParameter("diachi", NpgsqlDbType.Varchar);
                prmArr[3].Value = sdiachi;

                prmArr[4] = new NpgsqlParameter("dienthoai", NpgsqlDbType.Varchar);
                prmArr[4].Value = sdienthoai;

                prmArr[5] = new NpgsqlParameter("email", NpgsqlDbType.Varchar);
                prmArr[5].Value = semail;

                prmArr[6] = new NpgsqlParameter("ghichu", NpgsqlDbType.Varchar);
                prmArr[6].Value = sghichu;

                prmArr[7] = new NpgsqlParameter("gioitinh", NpgsqlDbType.Boolean);
                prmArr[7].Value = bgioitinh;

                prmArr[8] = new NpgsqlParameter("ireturn", NpgsqlDbType.Text);
                prmArr[8].Direction = ParameterDirection.Output;

                mDataAccess.ExecuteQuery(strProc, CommandType.StoredProcedure, prmArr);
                string sKQ = prmArr[8].Value.ToString().Trim();
                if (sKQ.ToUpper().Equals("Update".ToUpper()) == true) return "";
                return "Cập nhật dữ liệu không thành công";

            }
            catch (Exception ex)
            {
                return "Cập nhật dữ liệu không thành công. Chi Tiết: " + ex.Message;
            }
        }
        public string ChangePass(string sidnhanvien, string smatkhau)
        {
            string strProc = "fn_nhanvien_changepass";
            try
            {
                NpgsqlParameter[] prmArr = new NpgsqlParameter[3];

                prmArr[0] = new NpgsqlParameter("idnhanvien", NpgsqlDbType.Varchar);
                prmArr[0].Value = sidnhanvien;
                prmArr[1] = new NpgsqlParameter("matkhau", NpgsqlDbType.Varchar);
                prmArr[1].Value = smatkhau;
                prmArr[2] = new NpgsqlParameter("ireturn", NpgsqlDbType.Text);
                prmArr[2].Direction = ParameterDirection.Output;

                mDataAccess.ExecuteQuery(strProc, CommandType.StoredProcedure, prmArr);
                string sKQ = prmArr[2].Value.ToString().Trim();
                if (sKQ.ToUpper().Equals("Update".ToUpper()) == true) return "";
                return "Đặt lại mật khẩu người dùng không thành công.";
            }
            catch (Exception ex)
            {
                return "Đặt lại mật khẩu người dùng không thành công. Chi Tiết: " + ex.Message;
            }
        }
        /// <summary>
        /// Xóa dữ liệu từ bảng nhanvien
        /// </summary>
        /// <returns>Trả về trắng: xóa thành công; Trả về khác trắng: xóa không thành công</returns>
        public string Delete(string stridnhanvien)
        {
            string strProc = "fn_nhanvien_delete";
            try
            {
                NpgsqlParameter[] prmArr = new NpgsqlParameter[2];

                prmArr[0] = new NpgsqlParameter("idnhanvien", NpgsqlDbType.Varchar);
                prmArr[0].Value = stridnhanvien;

                prmArr[1] = new NpgsqlParameter("ireturn", NpgsqlDbType.Text);
                prmArr[1].Direction = ParameterDirection.Output;
                mDataAccess.ExecuteQuery(strProc, CommandType.StoredProcedure, prmArr);
                string KQ = prmArr[1].Value.ToString().Trim();
                if (KQ.ToUpper().Equals("Del".ToUpper()) == true) return "";
                return "Xóa dữ liệu không thành công";
            }
            catch (Exception ex)
            {
                return "Xóa dữ liệu không thành công. Chi Tiết: " + ex.Message;
            }
        }
        /// <summary>
        /// Hàm kiểm tra đăng nhập
        /// </summary>
        /// <param name="sTaiKhoan">Tài khoản kiểu string</param>
        /// <param name="sMatKhau">Mật khẩu kiểu string</param>
        /// <returns>bool: true-là đúng; false-là sai</returns>
        public bool Authentication(string sTaiKhoan, string sMatKhau)
        {
            string strFun = "fn_user_authen";
            try
            {
                NpgsqlParameter[] prmArr = new NpgsqlParameter[2];
                prmArr[0] = new NpgsqlParameter("itaikhoan", NpgsqlDbType.Varchar);
                prmArr[0].Value = sTaiKhoan;
                prmArr[1] = new NpgsqlParameter("imatkhau", NpgsqlDbType.Varchar);
                prmArr[1].Value = sMatKhau;
                DataSet dsNhanVien = mDataAccess.ExecuteDataSet(strFun, CommandType.StoredProcedure, prmArr);
                if (dsNhanVien.Tables[0].Rows.Count > 0) { return true; }
                else { return false; }
            }
            catch { return false; }
        }
        /// <summary>
        /// Hàm kiểm tra tồn tại tài khoản
        /// </summary>
        /// <param name="sTaiKhoan">Tài khoản kiểu string</param>
        /// <param name="iTrangThai">Trạng thái: 1-Thêm mới; 2-Sửa</param>
        /// <returns>DataTable</returns>
        public DataTable CheckExitAccount(string sTaiKhoan,int iTrangThai)
        {
            string strFun = "fn_user_checkexit";
            try
            {
                NpgsqlParameter[] prmArr = new NpgsqlParameter[2];
                prmArr[0] = new NpgsqlParameter("itaikhoan", NpgsqlDbType.Varchar);
                prmArr[0].Value = sTaiKhoan;
                prmArr[1] = new NpgsqlParameter("itrangthai", NpgsqlDbType.Integer);
                prmArr[1].Value = iTrangThai;
                DataSet dsNhanVien = mDataAccess.ExecuteDataSet(strFun, CommandType.StoredProcedure, prmArr);
                return dsNhanVien.Tables[0];
            }
            catch
            {
                return null;
            }
        }
        /// <summary>
        /// Hàm kiểm tra tồn tại email
        /// </summary>
        /// <param name="semail">Email kiểu string</param>
        /// <returns>bool: true-tồn tại; false-không tồn tại</returns>
        public bool CheckEmail(string semail)
        {
            string strFun = "fn_user_checkemail";
            try
            {
                NpgsqlParameter[] prmArr = new NpgsqlParameter[1];
                prmArr[0] = new NpgsqlParameter("email", NpgsqlDbType.Varchar);
                prmArr[0].Value = semail;
                DataSet dsNhanVien = mDataAccess.ExecuteDataSet(strFun, CommandType.StoredProcedure, prmArr);
                if (dsNhanVien.Tables[0].Rows.Count > 0)
                { return true; }
                return false;
            }
            catch
            {
                return true;
            }
        }
        /// <summary>
        /// Hàm lấy thông tin người dùng theo email
        /// </summary>
        /// <param name="semail">Email kiểu string</param>
        /// <returns>DataTable</returns>
        public DataTable GetbyEmail(string semail)
        {
            string strFun = "fn_user_checkemail";
            try
            {
                NpgsqlParameter[] prmArr = new NpgsqlParameter[1];
                prmArr[0] = new NpgsqlParameter("email", NpgsqlDbType.Varchar);
                prmArr[0].Value = semail;
                DataSet dsNhanVien = mDataAccess.ExecuteDataSet(strFun, CommandType.StoredProcedure, prmArr);
                return dsNhanVien.Tables[0];
            }
            catch
            {
                return null;
            }
        }
        /// <summary>
        /// Hàm kiểm tra tồn tại người dùng theo mã
        /// </summary>
        /// <param name="stridnhanvien">Mã người dùng kiểu string</param>
        /// <returns>bool</returns>
        public bool CheckExitAccount(string stridnhanvien)
        {
            string strFun = "fn_user_checkexit";
            try
            {
                NpgsqlParameter[] prmArr = new NpgsqlParameter[1];
                prmArr[0] = new NpgsqlParameter("idnhanvien", NpgsqlDbType.Varchar);
                prmArr[0].Value = stridnhanvien;
                DataSet dsNhanVien = mDataAccess.ExecuteDataSet(strFun, CommandType.StoredProcedure, prmArr);
                if (dsNhanVien.Tables[0].Rows.Count > 0) { return true; }
                else { return false; }
            }
            catch
            {
                return false;
            }
        }
        /// <summary>
        /// Hàm lấy mã người dùng theo tài khoản đăng nhập
        /// </summary>
        /// <param name="stridnhanvien">Mã người dùng kiểu string</param>
        /// <returns>string</returns>
        public string GetIDNhanVienByAccount(string strtaikhoan)
        {
            string strFun = "fn_user_getidbyaccount";
            try
            {
                NpgsqlParameter[] prmArr = new NpgsqlParameter[1];
                prmArr[0] = new NpgsqlParameter("taikhoan", NpgsqlDbType.Varchar);
                prmArr[0].Value = strtaikhoan;
                DataSet dsNhanVien = mDataAccess.ExecuteDataSet(strFun, CommandType.StoredProcedure, prmArr);
                if (dsNhanVien.Tables[0].Rows.Count > 0) { return dsNhanVien.Tables[0].Rows[0]["fn_user_getidbyaccount"].ToString().Trim(); }
                else { return ""; }
            }
            catch
            {
                return "";
            }
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
            siduser = "";
            shoten = "";
            sloai = "";
            string strFun = "fn_user_getinfobyaccount";
            try
            {
                NpgsqlParameter[] prmArr = new NpgsqlParameter[1];
                prmArr[0] = new NpgsqlParameter("taikhoan", NpgsqlDbType.Varchar);
                prmArr[0].Value = strtaikhoan;
                DataSet dsNhanVien = mDataAccess.ExecuteDataSet(strFun, CommandType.StoredProcedure, prmArr);
                if (dsNhanVien.Tables[0].Rows.Count > 0)
                {
                    siduser = dsNhanVien.Tables[0].Rows[0]["iduser"].ToString().Trim();
                    shoten = dsNhanVien.Tables[0].Rows[0]["hoten"].ToString().Trim();
                    sloai = dsNhanVien.Tables[0].Rows[0]["loai"].ToString().Trim();
                    return sloai;
                }
                else { return ""; }
            }
            catch
            {
                return "";
            }
        }
        /// <summary>
        /// Hàm tìm kiếm nhân viên
        /// </summary>
        /// <param name="sDieuKien">Điều kiện tìm kiếm kiểu string</param>
        /// <returns>DataTable</returns>
        public DataTable TimKiem(string sDieuKien)
        {
            string query = "";
            query = "SELECT nhanvien.idnhanvien,nhanvien.idphongban,nhanvien.hoten,chucvu.tenchucvu, "
                + "phongban.tenphongban,nhanvien.taikhoan,nhanvien.matkhau,nhanvien.ngaysinh,nhanvien.diachi, "
                + "nhanvien.dienthoai,nhanvien.email,nhanvien.ghichu,nhanvien.gioitinh "
                + "FROM public.nhanvien,public.phongban,public.chucvu "
                + "WHERE  "
                + "nhanvien.idchucvu = chucvu.idchucvu AND "
                + "nhanvien.idphongban = phongban.idphongban AND "
                + sDieuKien;
            try 
            {
                DataSet ds = mDataAccess.ExecuteDataSet(query, CommandType.Text);
                return ds.Tables[0];
            }
            catch { return null; }
        }
        /// <summary>
        /// Hàm lấy danh sách nhân viên theo tên tài khoản
        /// </summary>
        /// <param name="sTaiKhoan">Tên tài khoản kiểu string</param>
        /// <returns>DataTable</returns>
        public DataTable GetByAccountName(string sTaiKhoan)
        {
            string strFun = "fn_nhanvien_getbyaccountname";
            try
            {
                NpgsqlParameter[] prmArr = new NpgsqlParameter[1];
                prmArr[0] = new NpgsqlParameter("itaikhoan", NpgsqlDbType.Varchar);
                prmArr[0].Value = sTaiKhoan;
                DataSet dsNhanVien = mDataAccess.ExecuteDataSet(strFun, CommandType.StoredProcedure, prmArr);
                return dsNhanVien.Tables[0];
            }
            catch
            {
                return null;
            }
        }
        /// <summary>
        /// Hàm kiểm tra quyền download tư liệu theo loại tư liệu và mã người dùng
        /// </summary>
        /// <param name="siduser">Mã người dùng kiểu string</param>
        /// <param name="sidloaitl">Mã loại tư liệu kiểu string</param>
        /// <returns>bool: True-Có;False:Không</returns>
        public bool CheckLoaiTLDownload(string siduser,string sidloaitl)
        {
            bool kq = false;
            string strFun = "fn_user_checkdownload";
            try
            {
                NpgsqlParameter[] prmArr = new NpgsqlParameter[2];
                prmArr[0] = new NpgsqlParameter("idnhanvien", NpgsqlDbType.Varchar);
                prmArr[0].Value = siduser;
                prmArr[1] = new NpgsqlParameter("idloaitulieu", NpgsqlDbType.Varchar);
                prmArr[1].Value = sidloaitl;
                DataSet ds = mDataAccess.ExecuteDataSet(strFun, CommandType.StoredProcedure, prmArr);
                if (ds.Tables[0].Rows.Count > 0) { kq = true; }
                return kq;
            }
            catch
            {
                return false;
            }
        }
        /// <summary>
        /// Đăng nhập
        /// </summary>
        /// <param name="staikhoan">Tài khoản kiểu string</param>
        /// <param name="smatkhau">Mật khẩu kiểu string đã được băm theo thuật toán MD5</param>
        /// <returns>bool: True-Thành công; False-Không thành công</returns>
        public bool DangNhap(string staikhoan, string smatkhau)
        {
            string strProc = "fn_nhanvien_dangnhap";
            try
            {
                NpgsqlParameter[] prmArr = new NpgsqlParameter[3];
                prmArr[0] = new NpgsqlParameter("taikhoan", NpgsqlDbType.Varchar);
                prmArr[0].Value = staikhoan;
                prmArr[1] = new NpgsqlParameter("matkhau", NpgsqlDbType.Varchar);
                prmArr[1].Value = smatkhau;
                prmArr[2] = new NpgsqlParameter("ireturn", NpgsqlDbType.Text);
                prmArr[2].Direction = ParameterDirection.Output;
                mDataAccess.ExecuteQuery(strProc, CommandType.StoredProcedure, prmArr);
                string sKQ = prmArr[2].Value.ToString().Trim();
                if (sKQ.ToUpper().Equals("1".ToUpper()) == true) return true;
                else if (sKQ.ToUpper().Equals("0".ToUpper()) == true) return false;
            }
            catch
            {
                return false;
            }
            return false;
        }
        /// <summary>
        /// Hàm load danh sách nhân viên với trường taikhoan + hoten
        /// </summary>
        /// <returns>DataTable</returns>
        public DataTable LoadDSCBNV()
        {
            string strFun = "fn_nhanvien_loadcbnv";
            try
            {
                DataSet dsnhanvien = mDataAccess.ExecuteDataSet(strFun, CommandType.StoredProcedure);
                return dsnhanvien.Tables[0];
            }
            catch
            {
                return null;
            }
        }
        #endregion
    }
}
