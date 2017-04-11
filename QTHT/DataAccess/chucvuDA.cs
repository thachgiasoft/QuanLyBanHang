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
     /// Mô tả thông tin cho bảng chucvu
     /// Cung cấp các hàm xử lý, thao tác với bảng chucvu
     /// Người tạo (C): 
     /// Ngày khởi tạo: 17/10/2014
     /// </summary>
    public class chucvu
    {
        #region Private Variables
        private int intidchucvu;
        private string strtenchucvu;
        private string strmota;
        #endregion

        #region Public Constructor Functions
        public chucvu()
        {
            intidchucvu = 0;
            strtenchucvu = string.Empty;
            strmota = string.Empty;

        }

        public chucvu(int intidchucvu, string strtenchucvu, string strmota)
        {
            this.intidchucvu = intidchucvu;
            this.strtenchucvu = strtenchucvu;
            this.strmota = strmota;
        }
        #endregion

        #region Properties
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

        public string tenchucvu
        {
            get
            {
                return strtenchucvu;
            }
            set
            {
                strtenchucvu = value;
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
        /// Lấy toàn bộ dữ liệu từ bảng chucvu
        /// </summary>
        /// <returns>DataTable</returns>
        public DataTable GetAll()
        {
            string strFun = "fn_chucvu_getall";
            try
            {
                DataSet dschucvu = mDataAccess.ExecuteDataSet(strFun, CommandType.StoredProcedure);
                return dschucvu.Tables[0];
            }
            catch
            {
                return null;
            }
        }
        /// <summary>
        /// Hàm lấy chucvu theo mã
        /// </summary>
        /// <returns>Trả về objchucvu </returns>
        public chucvu GetByID(int intidchucvu)
        {
            chucvu objchucvu = new chucvu();
            string strFun = "fn_chucvu_getobjbyid";
            try
            {
                NpgsqlParameter[] prmArr = new NpgsqlParameter[1];

                prmArr[0] = new NpgsqlParameter("idchucvu", NpgsqlDbType.Integer);
                prmArr[0].Value = intidchucvu;

                DataSet dschucvu = mDataAccess.ExecuteDataSet(strFun, CommandType.StoredProcedure, prmArr);

                if ((dschucvu != null) && (dschucvu.Tables.Count > 0))
                {
                    if (dschucvu.Tables[0].Rows.Count > 0)
                    {
                        DataRow dr = dschucvu.Tables[0].Rows[0];
                        try{ objchucvu.idchucvu = Convert.ToInt32("0" + dr["idchucvu"].ToString());}
                        catch{ objchucvu.idchucvu = 0;}

                        objchucvu.tenchucvu = dr["tenchucvu"].ToString();

                        objchucvu.mota = dr["mota"].ToString();


                        return objchucvu;
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
        /// Thêm mới dữ liệu vào bảng: chucvu
        /// </summary>
        /// <param name="obj">objchucvu</param>
        /// <returns>Trả về trắng: Thêm mới thành công; Trả về khác trắng: Thêm mới không thành công</returns>
        public string Insert(chucvu objchucvu)
        {
            string strProc = "fn_chucvu_insert";
            try
            {
                NpgsqlParameter[] prmArr = new NpgsqlParameter[4];

                prmArr[0] = new NpgsqlParameter("idchucvu", NpgsqlDbType.Integer);
                prmArr[0].Value = objchucvu.intidchucvu;

                prmArr[1] = new NpgsqlParameter("tenchucvu", NpgsqlDbType.Varchar);
                prmArr[1].Value = objchucvu.strtenchucvu;

                prmArr[2] = new NpgsqlParameter("mota", NpgsqlDbType.Varchar);
                prmArr[2].Value = objchucvu.strmota;

                prmArr[3] = new NpgsqlParameter("ireturn", NpgsqlDbType.Text);
                prmArr[3].Direction = ParameterDirection.Output;

                mDataAccess.ExecuteQuery(strProc, CommandType.StoredProcedure, prmArr);

                string sKQ =  prmArr[3].Value.ToString().Trim(); 

                if (sKQ.ToUpper().Equals("Add".ToUpper()) == true) return "";
                return "Thêm mới dữ liệu không thành công";            }
            catch(Exception ex)
            {
                return "Thêm mới dữ liệu không thành công. Chi Tiết: " + ex.Message;
            }
        }
        /// <summary>
        /// Cập nhật dữ liệu vào bảng: chucvu
        /// </summary>
        /// <param name="obj">objchucvu</param>
        /// <returns>Trả về trắng: Cập nhật thành công; Trả về khác trắng: Cập nhật không thành công</returns>
        public string Update(chucvu objchucvu)
        {
            string strProc = "fn_chucvu_Update";
            try
            {
                NpgsqlParameter[] prmArr = new NpgsqlParameter[4];

                prmArr[0] = new NpgsqlParameter("idchucvu", NpgsqlDbType.Integer);
                prmArr[0].Value = objchucvu.intidchucvu;

                prmArr[1] = new NpgsqlParameter("tenchucvu", NpgsqlDbType.Varchar);
                prmArr[1].Value = objchucvu.strtenchucvu;

                prmArr[2] = new NpgsqlParameter("mota", NpgsqlDbType.Varchar);
                prmArr[2].Value = objchucvu.strmota;

                prmArr[3] = new NpgsqlParameter("ireturn", NpgsqlDbType.Text);
                prmArr[3].Direction = ParameterDirection.Output;

                mDataAccess.ExecuteQuery(strProc, CommandType.StoredProcedure, prmArr);
                string sKQ = prmArr[3 ].Value.ToString().Trim();
                if (sKQ.ToUpper().Equals("Update".ToUpper()) == true) return "";
                return "Cập nhật dữ liệu không thành công";

            }
            catch(Exception ex)
            {
                return "Cập nhật dữ liệu không thành công. Chi Tiết: " + ex.Message;
            }
        }
        /// <summary>
        /// Xóa dữ liệu từ bảng chucvu
        /// </summary>
        /// <returns>Trả về trắng: xóa thành công; Trả về khác trắng: xóa không thành công</returns>
        public string Delete(int intidchucvu)
        {
            string strProc = "fn_chucvu_delete";
            try
            {
                NpgsqlParameter[] prmArr = new NpgsqlParameter[2];

                prmArr[0] = new NpgsqlParameter("idchucvu", NpgsqlDbType.Integer);
                prmArr[0].Value = intidchucvu;

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
        /// Hàm kiểm tra trùng tên chức vụ
        /// </summary>
        /// <param name="sid">Mã chức vụ</param>
        /// <param name="sten">Tên chức vụ</param>
        /// <returns>bool: False-Không tồn tại;True-Có tồn tại</returns>
        public bool CheckExit(int iidchucvu, string stenchucvu)
        {
            string strProc = "fn_chucvu_checkexit";
            try
            {
                NpgsqlParameter[] prmArr = new NpgsqlParameter[3];
                prmArr[0] = new NpgsqlParameter("idchucvu", NpgsqlDbType.Integer);
                prmArr[0].Value = iidchucvu;
                prmArr[1] = new NpgsqlParameter("tenchucvu", NpgsqlDbType.Varchar);
                prmArr[1].Value = stenchucvu;
                prmArr[2] = new NpgsqlParameter("ireturn", NpgsqlDbType.Text);
                prmArr[2].Direction = ParameterDirection.Output;
                mDataAccess.ExecuteQuery(strProc, CommandType.StoredProcedure, prmArr);
                string sKQ = prmArr[2].Value.ToString().Trim();
                if (sKQ.ToUpper().Equals("0".ToUpper()) == true) return false;
                else if (sKQ.ToUpper().Equals("1".ToUpper()) == true) return true;
            }
            catch
            {
                return false;
            }
            return true;
        }
        #endregion
    }
}
