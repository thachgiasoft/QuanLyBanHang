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
     /// Mô tả thông tin cho bảng log
     /// Cung cấp các hàm xử lý, thao tác với bảng log
     /// Người tạo (C): 
     /// Ngày khởi tạo: 17/10/2014
     /// </summary>
    public class log
    {
        #region Private Variables
        private int intid;
        private DateTime dtmthoigian;
        private string striduser;
        private string strthaotac;
        #endregion

        #region Public Constructor Functions
        public log()
        {
            intid = 0;
            dtmthoigian = DateTime.Now;
            striduser = string.Empty;
            strthaotac = string.Empty;

        }

        public log(int intid, DateTime dtmthoigian, string striduser, string strthaotac)
        {
            this.intid = intid;
            this.dtmthoigian = dtmthoigian;
            this.striduser = striduser;
            this.strthaotac = strthaotac;
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

        public DateTime thoigian
        {
            get
            {
                return dtmthoigian;
            }
            set
            {
                dtmthoigian = value;
            }
        }

        public string iduser
        {
            get
            {
                return striduser;
            }
            set
            {
                striduser = value;
            }
        }

        public string thaotac
        {
            get
            {
                return strthaotac;
            }
            set
            {
                strthaotac = value;
            }
        }
        #endregion

        #region Public Method
        private readonly DataAccessLayerBaseClass mDataAccess = new DataAccessLayerBaseClass(Data.ConnectionString);

        /// <summary>
        /// Lấy toàn bộ dữ liệu từ bảng log
        /// </summary>
        /// <returns>DataTable</returns>
        public DataTable GetAll()
        {
            string strFun = "fn_log_getall";
            try
            {
                DataSet dslog = mDataAccess.ExecuteDataSet(strFun, CommandType.StoredProcedure);
                return dslog.Tables[0];
            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        /// Hàm lấy log theo mã
        /// </summary>
        /// <returns>Trả về objlog </returns>
        public log GetByID(int intid)
        {
            log objlog = new log();
            string strFun = "fn_log_getobjbyid";
            try
            {
                NpgsqlParameter[] prmArr = new NpgsqlParameter[1];

                prmArr[0] = new NpgsqlParameter("id", NpgsqlDbType.Integer);
                prmArr[0].Value = intid;

                DataSet dslog = mDataAccess.ExecuteDataSet(strFun, CommandType.StoredProcedure, prmArr);

                if ((dslog != null) && (dslog.Tables.Count > 0))
                {
                    if (dslog.Tables[0].Rows.Count > 0)
                    {
                        DataRow dr = dslog.Tables[0].Rows[0];
                        try{ objlog.id = Convert.ToInt32("0" + dr["id"].ToString());}
                        catch{ objlog.id = 0;}

                        try { objlog.thoigian = Convert.ToDateTime(dr["thoigian"].ToString());}
                        catch { objlog.thoigian = new DateTime(1900, 1, 1); }

                        objlog.iduser = dr["iduser"].ToString();

                        objlog.thaotac = dr["thaotac"].ToString();


                        return objlog;
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
        /// Hàm thêm mới log
        /// </summary>
        /// <param name="sUserName">Tên đăng nhập kiểu string</param>
        /// <param name="sTask">Thao tác kiểu string</param>
        /// <returns>Trả về trắng: Thêm mới thành công; Trả về khác trắng: Thêm mới không thành công</returns>
        public string Append(string sUserName, string sTask)
        {
            string strProc = "fn_log_appen";
            try
            {
                NpgsqlParameter[] prmArr = new NpgsqlParameter[3];
                prmArr[0] = new NpgsqlParameter("iduser", NpgsqlDbType.Varchar);
                prmArr[0].Value = sUserName;
                prmArr[1] = new NpgsqlParameter("thaotac", NpgsqlDbType.Varchar);
                prmArr[1].Value = sTask;
                prmArr[2] = new NpgsqlParameter("ireturn", NpgsqlDbType.Text);
                prmArr[2].Direction = ParameterDirection.Output;
                mDataAccess.ExecuteQuery(strProc, CommandType.StoredProcedure, prmArr);
                string sKQ = prmArr[2].Value.ToString().Trim();
                if (sKQ.ToUpper().Equals("Add".ToUpper()) == true) return "";
                return "Thêm mới dữ liệu không thành công";
            }
            catch (Exception ex)
            {
                return "Thêm mới dữ liệu không thành công. Chi Tiết: " + ex.Message;
            }
        }

        /// <summary>
        /// Cập nhật dữ liệu vào bảng: log
        /// </summary>
        /// <param name="obj">objlog</param>
        /// <returns>Trả về trắng: Cập nhật thành công; Trả về khác trắng: Cập nhật không thành công</returns>
        public string Update(log objlog)
        {
            string strProc = "fn_log_Update";
            try
            {
                NpgsqlParameter[] prmArr = new NpgsqlParameter[5];

                prmArr[0] = new NpgsqlParameter("id", NpgsqlDbType.Integer);
                prmArr[0].Value = objlog.intid;

                prmArr[1] = new NpgsqlParameter("thoigian", NpgsqlDbType.TimestampTZ);
                prmArr[1].Value = objlog.dtmthoigian;

                prmArr[2] = new NpgsqlParameter("iduser", NpgsqlDbType.Varchar);
                prmArr[2].Value = objlog.striduser;

                prmArr[3] = new NpgsqlParameter("thaotac", NpgsqlDbType.Varchar);
                prmArr[3].Value = objlog.strthaotac;

                prmArr[4] = new NpgsqlParameter("ireturn", NpgsqlDbType.Text);
                prmArr[4].Direction = ParameterDirection.Output;

                mDataAccess.ExecuteQuery(strProc, CommandType.StoredProcedure, prmArr);
                string sKQ = prmArr[4 ].Value.ToString().Trim();
                if (sKQ.ToUpper().Equals("Update".ToUpper()) == true) return "";
                return "Cập nhật dữ liệu không thành công";

            }
            catch(Exception ex)
            {
                return "Cập nhật dữ liệu không thành công. Chi Tiết: " + ex.Message;
            }
        }

        /// <summary>
        /// Xóa dữ liệu từ bảng log
        /// </summary>
        /// <returns>Trả về trắng: xóa thành công; Trả về khác trắng: xóa không thành công</returns>
        public string Delete(int intid)
        {
            string strProc = "fn_log_delete";
            try
            {
                NpgsqlParameter[] prmArr = new NpgsqlParameter[2];

                prmArr[0] = new NpgsqlParameter("id", NpgsqlDbType.Integer);
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
        /// Hàm tìm kiếm log sử dụng chuối truy vấn trực tiếp
        /// </summary>
        /// <param name="squery">Chuối truy vấn kiểu string</param>
        /// <returns>DataTable</returns>
        public DataTable FindLogUseQuery(string squery)
        {
            DataTable dt = new DataTable();
            try
            {
                dt = mDataAccess.ExecuteDataSet(squery, CommandType.Text).Tables[0];
                return dt;
            }
            catch
            {
                return null;
            }
        }
        #endregion
    }
}
