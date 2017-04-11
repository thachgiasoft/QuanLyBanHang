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
     /// Mô tả thông tin cho bảng quyennguoidung
     /// Cung cấp các hàm xử lý, thao tác với bảng quyennguoidung
     /// Người tạo (C): 
     /// Ngày khởi tạo: 20/10/2014
     /// </summary>
    public class quyennguoidung
    {
        #region Private Variables
        private int intid;
        private string stridnhanvien;
        private int intidmenu;
        private string strkyhieucn;
        private string strtenquyendl;
        private string strquyendl;
        private bool blnstatus;
        private string strmota;
        #endregion

        #region Public Constructor Functions
        public quyennguoidung()
        {
            intid = 0;
            stridnhanvien = string.Empty;
            intidmenu = 0;
            strkyhieucn = string.Empty;
            strtenquyendl = string.Empty;
            strquyendl = string.Empty;
            blnstatus = false;
            strmota = string.Empty;

        }

        public quyennguoidung(int intid, string stridnhanvien, int intidmenu, string strkyhieucn, string strtenquyendl, string strquyendl, bool blnstatus, string strmota)
        {
            this.intid = intid;
            this.stridnhanvien = stridnhanvien;
            this.intidmenu = intidmenu;
            this.strkyhieucn = strkyhieucn;
            this.strtenquyendl = strtenquyendl;
            this.strquyendl = strquyendl;
            this.blnstatus = blnstatus;
            this.strmota = strmota;
        }
        #endregion

        #region Properties
        public int id
        {
            get
            {
                return intid;
            }
            set
            {
                intid = value;
            }
        }

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

        public int idmenu
        {
            get
            {
                return intidmenu;
            }
            set
            {
                intidmenu = value;
            }
        }

        public string kyhieucn
        {
            get
            {
                return strkyhieucn;
            }
            set
            {
                strkyhieucn = value;
            }
        }

        public string tenquyendl
        {
            get
            {
                return strtenquyendl;
            }
            set
            {
                strtenquyendl = value;
            }
        }

        public string quyendl
        {
            get
            {
                return strquyendl;
            }
            set
            {
                strquyendl = value;
            }
        }

        public bool status
        {
            get
            {
                return blnstatus;
            }
            set
            {
                blnstatus = value;
            }
        }

        public string mota
        {
            get
            {
                return strmota;
            }
            set
            {
                strmota = value;
            }
        }
        #endregion

        #region Public Method
        private readonly DataAccessLayerBaseClass mDataAccess = new DataAccessLayerBaseClass(Data.ConnectionString);
        /// <summary>
        /// Lấy toàn bộ dữ liệu từ bảng quyennguoidung
        /// </summary>
        /// <returns>DataTable</returns>
        public DataTable GetAll()
        {
            string strFun = "fn_quyennguoidung_getall";
            try
            {
                DataSet dsquyennguoidung = mDataAccess.ExecuteDataSet(strFun, CommandType.StoredProcedure);
                return dsquyennguoidung.Tables[0];
            }
            catch
            {
                return null;
            }
        }
        /// <summary>
        /// Hàm lấy quyennguoidung theo mã
        /// </summary>
        /// <returns>Trả về objquyennguoidung </returns>
        public quyennguoidung GetByID(int intid)
        {
            quyennguoidung objquyennguoidung = new quyennguoidung();
            string strFun = "fn_quyennguoidung_getobjbyid";
            try
            {
                NpgsqlParameter[] prmArr = new NpgsqlParameter[1];

                prmArr[0] = new NpgsqlParameter("id", NpgsqlDbType.Bigint);
                prmArr[0].Value = intid;

                DataSet dsquyennguoidung = mDataAccess.ExecuteDataSet(strFun, CommandType.StoredProcedure, prmArr);

                if ((dsquyennguoidung != null) && (dsquyennguoidung.Tables.Count > 0))
                {
                    if (dsquyennguoidung.Tables[0].Rows.Count > 0)
                    {
                        DataRow dr = dsquyennguoidung.Tables[0].Rows[0];
                        try{ objquyennguoidung.id = Convert.ToInt32("0" + dr["id"].ToString());}
                        catch{ objquyennguoidung.id = 0;}

                        objquyennguoidung.idnhanvien = dr["idnhanvien"].ToString();

                        try{ objquyennguoidung.idmenu = Convert.ToInt32("0" + dr["idmenu"].ToString());}
                        catch{ objquyennguoidung.idmenu = 0;}

                        objquyennguoidung.kyhieucn = dr["kyhieucn"].ToString();

                        objquyennguoidung.tenquyendl = dr["tenquyendl"].ToString();

                        objquyennguoidung.quyendl = dr["quyendl"].ToString();

                        objquyennguoidung.status = Convert.ToBoolean(dr["status"].ToString());

                        objquyennguoidung.mota = dr["mota"].ToString();


                        return objquyennguoidung;
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
        /// Hàm lấy quyền người dùng theo mã nhân viên và ký hiệu chức năng
        /// </summary>
        /// <param name="stridnhanvien">Mã nhân viên kiểu string</param>
        /// <param name="strmenuname">Ký hiệu chức năng kiểu string</param>
        /// <returns>quyennguoidung</returns>
        public quyennguoidung GetByIDNhanVienvsMenuName(string stridnhanvien, string strmenuname)
        {
            quyennguoidung objquyennguoidung = new quyennguoidung();
            string strFun = "fn_quyennguoidung_checkexitrolebymenuname";
            try
            {
                NpgsqlParameter[] prmArr = new NpgsqlParameter[2];
                prmArr[0] = new NpgsqlParameter("idnhanvien", NpgsqlDbType.Varchar);
                prmArr[0].Value = stridnhanvien;
                prmArr[1] = new NpgsqlParameter("kyhieucn", NpgsqlDbType.Varchar);
                prmArr[1].Value = strmenuname;
                DataSet dsquyennguoidung = mDataAccess.ExecuteDataSet(strFun, CommandType.StoredProcedure, prmArr);
                if ((dsquyennguoidung != null) && (dsquyennguoidung.Tables.Count > 0))
                {
                    if (dsquyennguoidung.Tables[0].Rows.Count > 0)
                    {
                        DataRow dr = dsquyennguoidung.Tables[0].Rows[0];
                        try { objquyennguoidung.id = Convert.ToInt32("0" + dr["id"].ToString()); }
                        catch { objquyennguoidung.id = 0; }
                        objquyennguoidung.idnhanvien = dr["idnhanvien"].ToString();
                        try { objquyennguoidung.idmenu = Convert.ToInt32("0" + dr["idmenu"].ToString()); }
                        catch { objquyennguoidung.idmenu = 0; }
                        objquyennguoidung.kyhieucn = dr["kyhieucn"].ToString();
                        objquyennguoidung.tenquyendl = dr["tenquyendl"].ToString();
                        objquyennguoidung.quyendl = dr["quyendl"].ToString();
                        objquyennguoidung.status = Convert.ToBoolean(dr["status"].ToString());
                        objquyennguoidung.mota = dr["mota"].ToString();
                        return objquyennguoidung;
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
        /// Hàm lấy danh sách quyền theo mã người dùng
        /// </summary>
        /// <param name="stridnhanvien">Mã người dùng kiểu string</param>
        /// <returns>DataTable</returns>
        public DataTable GetByIDNhanVien(string stridnhanvien)
        {
            string strFun = "fn_quyennguoidung_getbyidnhanvien";
            try
            {
                NpgsqlParameter[] prmArr = new NpgsqlParameter[1];
                prmArr[0] = new NpgsqlParameter("idnhanvien", NpgsqlDbType.Varchar);
                prmArr[0].Value = stridnhanvien; 
                DataSet dsquyennguoidung = mDataAccess.ExecuteDataSet(strFun, CommandType.StoredProcedure, prmArr);
                return dsquyennguoidung.Tables[0];
            }
            catch
            {
                return null;
            }
        }
        /// <summary>
        /// Hàm lấy danh sách menu cấp 1 theo mã người dùng
        /// </summary>
        /// <param name="stridnhanvien">Mã người dùng kiểu string</param>
        /// <returns>DataTable</returns>
        public DataTable GetMenuCap1ByIDNhanVien(string stridnhanvien)
        {
            string strFun = "fn_quyennguoidung_getmenucap1byidnhanvien";
            try
            {
                NpgsqlParameter[] prmArr = new NpgsqlParameter[1];
                prmArr[0] = new NpgsqlParameter("idnhanvien", NpgsqlDbType.Varchar);
                prmArr[0].Value = stridnhanvien;
                DataSet dsquyennguoidung = mDataAccess.ExecuteDataSet(strFun, CommandType.StoredProcedure, prmArr);
                return dsquyennguoidung.Tables[0];
            }
            catch
            {
                return null;
            }
        }
        /// <summary>
        /// Hàm lấy danh sách menu cấp 2 theo mã người dùng
        /// </summary>
        /// <param name="stridnhanvien">Mã nhân viên kiểu string</param>
        /// <param name="intparentmenuid">Mã menu cha</param>
        /// <returns>DataTable</returns>
        public DataTable GetMenuCap2ByIDNhanVien(string stridnhanvien, int intparentmenuid)
        {
            string strFun = "fn_quyennguoidung_getmenucap2byidnhanvien";
            try
            {
                NpgsqlParameter[] prmArr = new NpgsqlParameter[2];
                prmArr[0] = new NpgsqlParameter("idnhanvien", NpgsqlDbType.Varchar);
                prmArr[0].Value = stridnhanvien;
                prmArr[1] = new NpgsqlParameter("parentmenuid", NpgsqlDbType.Integer);
                prmArr[1].Value = intparentmenuid;
                DataSet dsquyennguoidung = mDataAccess.ExecuteDataSet(strFun, CommandType.StoredProcedure, prmArr);
                return dsquyennguoidung.Tables[0];
            }
            catch
            {
                return null;
            }
        }
        /// <summary>
        /// Thêm mới dữ liệu vào bảng: quyennguoidung
        /// </summary>
        /// <param name="obj">objquyennguoidung</param>
        /// <returns>Trả về trắng: Thêm mới thành công; Trả về khác trắng: Thêm mới không thành công</returns>
        public string Insert(quyennguoidung objquyennguoidung)
        {
            string strProc = "fn_quyennguoidung_insert";
            try
            {
                NpgsqlParameter[] prmArr = new NpgsqlParameter[9];

                prmArr[0] = new NpgsqlParameter("id", NpgsqlDbType.Bigint);
                prmArr[0].Value = objquyennguoidung.intid;

                prmArr[1] = new NpgsqlParameter("idnhanvien", NpgsqlDbType.Varchar);
                prmArr[1].Value = objquyennguoidung.stridnhanvien;

                prmArr[2] = new NpgsqlParameter("idmenu", NpgsqlDbType.Integer);
                prmArr[2].Value = objquyennguoidung.intidmenu;

                prmArr[3] = new NpgsqlParameter("kyhieucn", NpgsqlDbType.Varchar);
                prmArr[3].Value = objquyennguoidung.strkyhieucn;

                prmArr[4] = new NpgsqlParameter("tenquyendl", NpgsqlDbType.Varchar);
                prmArr[4].Value = objquyennguoidung.strtenquyendl;

                prmArr[5] = new NpgsqlParameter("quyendl", NpgsqlDbType.Varchar);
                prmArr[5].Value = objquyennguoidung.strquyendl;

                prmArr[6] = new NpgsqlParameter("status", NpgsqlDbType.Boolean);
                prmArr[6].Value = objquyennguoidung.blnstatus;

                prmArr[7] = new NpgsqlParameter("mota", NpgsqlDbType.Varchar);
                prmArr[7].Value = objquyennguoidung.strmota;

                prmArr[8] = new NpgsqlParameter("ireturn", NpgsqlDbType.Text);
                prmArr[8].Direction = ParameterDirection.Output;

                mDataAccess.ExecuteQuery(strProc, CommandType.StoredProcedure, prmArr);

                string sKQ =  prmArr[8].Value.ToString().Trim(); 

                if (sKQ.ToUpper().Equals("Add".ToUpper()) == true) return "";
                return "Thêm mới dữ liệu không thành công";            }
            catch(Exception ex)
            {
                return "Thêm mới dữ liệu không thành công. Chi Tiết: " + ex.Message;
            }
        }
        /// <summary>
        /// Cập nhật dữ liệu vào bảng: quyennguoidung
        /// </summary>
        /// <param name="obj">objquyennguoidung</param>
        /// <returns>Trả về trắng: Cập nhật thành công; Trả về khác trắng: Cập nhật không thành công</returns>
        public string Update(quyennguoidung objquyennguoidung)
        {
            string strProc = "fn_quyennguoidung_Update";
            try
            {
                NpgsqlParameter[] prmArr = new NpgsqlParameter[9];

                prmArr[0] = new NpgsqlParameter("id", NpgsqlDbType.Bigint);
                prmArr[0].Value = objquyennguoidung.intid;

                prmArr[1] = new NpgsqlParameter("idnhanvien", NpgsqlDbType.Varchar);
                prmArr[1].Value = objquyennguoidung.stridnhanvien;

                prmArr[2] = new NpgsqlParameter("idmenu", NpgsqlDbType.Integer);
                prmArr[2].Value = objquyennguoidung.intidmenu;

                prmArr[3] = new NpgsqlParameter("kyhieucn", NpgsqlDbType.Varchar);
                prmArr[3].Value = objquyennguoidung.strkyhieucn;

                prmArr[4] = new NpgsqlParameter("tenquyendl", NpgsqlDbType.Varchar);
                prmArr[4].Value = objquyennguoidung.strtenquyendl;

                prmArr[5] = new NpgsqlParameter("quyendl", NpgsqlDbType.Varchar);
                prmArr[5].Value = objquyennguoidung.strquyendl;

                prmArr[6] = new NpgsqlParameter("status", NpgsqlDbType.Boolean);
                prmArr[6].Value = objquyennguoidung.blnstatus;

                prmArr[7] = new NpgsqlParameter("mota", NpgsqlDbType.Varchar);
                prmArr[7].Value = objquyennguoidung.strmota;

                prmArr[8] = new NpgsqlParameter("ireturn", NpgsqlDbType.Text);
                prmArr[8].Direction = ParameterDirection.Output;

                mDataAccess.ExecuteQuery(strProc, CommandType.StoredProcedure, prmArr);
                string sKQ = prmArr[8 ].Value.ToString().Trim();
                if (sKQ.ToUpper().Equals("Update".ToUpper()) == true) return "";
                return "Cập nhật dữ liệu không thành công";

            }
            catch(Exception ex)
            {
                return "Cập nhật dữ liệu không thành công. Chi Tiết: " + ex.Message;
            }
        }
        /// <summary>
        /// Xóa dữ liệu từ bảng quyennguoidung
        /// </summary>
        /// <returns></returns>
        public string Delete(int intid)
        {
            string strProc = "fn_quyennguoidung_delete";
            try
            {
                NpgsqlParameter[] prmArr = new NpgsqlParameter[2];

                prmArr[0] = new NpgsqlParameter("id", NpgsqlDbType.Bigint);
                prmArr[0].Value = intid;

                prmArr[1] = new NpgsqlParameter("ireturn", NpgsqlDbType.Text);
                prmArr[1].Direction = ParameterDirection.Output;
                mDataAccess.ExecuteQuery(strProc, CommandType.StoredProcedure, prmArr);
                string KQ = prmArr[1].Value.ToString().Trim(); 
                if (KQ.ToUpper().Equals("Del".ToUpper()) == true) return "";
                return "Xóa dữ liệu không thành công";
            }
            catch(Exception ex)
            {
                return "Xóa dữ liệu không thành công. Chi Tiết: " + ex.Message;
            }
        }
        /// <summary>
        /// Hàm xóa dữ liệu theo mã người dùng
        /// </summary>
        /// <param name="stridnhanvien">Mã nhân viên kiểu string</param>
        /// <returns>Trả về trắng: Xóa thành công; Trả về khác trắng: Xóa không thành công</returns>
        public string DeleteByIDNhanVien(string stridnhanvien)
        {
            string strProc = "fn_quyennguoidung_deletebyidnhanvien";
            try
            {
                NpgsqlParameter[] prmArr = new NpgsqlParameter[2];
                prmArr[0] = new NpgsqlParameter("iidnhanvien", NpgsqlDbType.Varchar);
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
        /// Hàm xóa quyền người dùng theo mã nhân viên và mã nhóm người dùng
        /// </summary>
        /// <param name="stridnhanvien">Mã nhân viên kiếu tring</param>
        /// <param name="stridnhom">Mã nhóm người dùng kiểu string</param>
        /// <returns>Trả về trắng: Xóa thành công; Trả về khác trắng: Xóa không thành công</returns>
        public string DeleteByIDNhomUse(string stridnhanvien, string stridnhom)
        {
            string strProc = "fn_quyennguoidung_deletebyidnhomuse";
            try
            {
                NpgsqlParameter[] prmArr = new NpgsqlParameter[3];
                prmArr[0] = new NpgsqlParameter("iidnhanvien", NpgsqlDbType.Varchar);
                prmArr[0].Value = stridnhanvien;
                prmArr[1] = new NpgsqlParameter("idnhom", NpgsqlDbType.Varchar);
                prmArr[1].Value = stridnhom;
                prmArr[2] = new NpgsqlParameter("ireturn", NpgsqlDbType.Text);
                prmArr[2].Direction = ParameterDirection.Output;
                mDataAccess.ExecuteQuery(strProc, CommandType.StoredProcedure, prmArr);
                string KQ = prmArr[2].Value.ToString().Trim();
                if (KQ.ToUpper().Equals("Del".ToUpper()) == true) return "";
                return "Xóa dữ liệu không thành công";
            }
            catch (Exception ex)
            {
                return "Xóa dữ liệu không thành công. Chi Tiết: " + ex.Message;
            }
        }
        /// <summary>
        /// Hàm xóa quyền người dùng theo mã nhân viên và mã chức năng
        /// </summary>
        /// <param name="stridnhanvien">Mã nhân viên kiếu tring</param>
        /// <param name="iidmenu">Mã chức năng kiểu int</param>
        /// <returns>Trả về trắng: Xóa thành công; Trả về khác trắng: Xóa không thành công</returns>
        public string DeleteByIDMenuvsUse(string stridnhanvien, int iidmenu)
        {
            string strProc = "fn_quyennguoidung_deletebyidmenuvsiduse";
            try
            {
                NpgsqlParameter[] prmArr = new NpgsqlParameter[3];
                prmArr[0] = new NpgsqlParameter("iidnhanvien", NpgsqlDbType.Varchar);
                prmArr[0].Value = stridnhanvien;
                prmArr[1] = new NpgsqlParameter("idmenu", NpgsqlDbType.Integer);
                prmArr[1].Value = iidmenu;
                prmArr[2] = new NpgsqlParameter("ireturn", NpgsqlDbType.Text);
                prmArr[2].Direction = ParameterDirection.Output;
                mDataAccess.ExecuteQuery(strProc, CommandType.StoredProcedure, prmArr);
                string KQ = prmArr[2].Value.ToString().Trim();
                if (KQ.ToUpper().Equals("Del".ToUpper()) == true) return "";
                return "Xóa dữ liệu không thành công";
            }
            catch (Exception ex)
            {
                return "Xóa dữ liệu không thành công. Chi Tiết: " + ex.Message;
            }
        }
        /// <summary>
        /// Hàm kiểm tra tồn tại quyền của người dùng
        /// </summary>
        /// <param name="stridnhanvien">Mã nhân viên kiểu string</param>
        /// <param name="iidmenu">Mã menu(chức năng) kiểu int</param>
        /// <returns>bool: True-Tồn tại;False:Không tồn tại</returns>
        public bool CheckExitRole(string stridnhanvien, int iidmenu)
        {
            string strFun = "fn_quyennguoidung_checkexitrole";
            try
            {
                NpgsqlParameter[] prmArr = new NpgsqlParameter[2];
                prmArr[0] = new NpgsqlParameter("iidnhanvien", NpgsqlDbType.Varchar);
                prmArr[0].Value = stridnhanvien;
                prmArr[1] = new NpgsqlParameter("idmenu", NpgsqlDbType.Integer);
                prmArr[1].Value = iidmenu;
                DataSet ds = mDataAccess.ExecuteDataSet(strFun, CommandType.StoredProcedure, prmArr);
                if (ds.Tables[0].Rows.Count > 0) { return true; }
                return false;
            }
            catch
            {
                return false;
            }
        }
        /// <summary>
        /// Hàm kiểm tra quyền người dùng
        /// </summary>
        /// <param name="staikhoan">Tài khoản người dùng kiểu string (guid)</param>
        /// <param name="path">path(url) cần kiểm tra kiểu string</param>
        /// <returns>bool: true-Có quyền; false:Không có quyền</returns>
        public bool CheckRoleOfUse(string staikhoan, string path)
        {
            string strFun = "fn_user_checkrole";
            try
            {
                NpgsqlParameter[] prmArr = new NpgsqlParameter[2];
                prmArr[0] = new NpgsqlParameter("itaikhoan", NpgsqlDbType.Varchar);
                prmArr[0].Value = staikhoan;
                prmArr[1] = new NpgsqlParameter("idmenu", NpgsqlDbType.Varchar);
                prmArr[1].Value = path;
                DataSet ds = mDataAccess.ExecuteDataSet(strFun, CommandType.StoredProcedure, prmArr);
                if (ds.Tables[0].Rows.Count > 0) { return true; }
                return false;
            }
            catch
            {
                return false;
            }
        }
        #endregion
    }
}
