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
     /// Mô tả thông tin cho bảng nhom
     /// Cung cấp các hàm xử lý, thao tác với bảng nhom
     /// Người tạo (C): tuanva
     /// Ngày khởi tạo: 17/10/2014
     /// </summary>
    public class nhom
    {
        #region Private Variables
        private string stridnhom;
        private string strtennhom;
        private string strmota;
        #endregion

        #region Public Constructor Functions
        public nhom()
        {
            stridnhom = string.Empty;
            strtennhom = string.Empty;
            strmota = string.Empty;

        }

        public nhom(string stridnhom, string strtennhom, string strmota)
        {
            this.stridnhom = stridnhom;
            this.strtennhom = strtennhom;
            this.strmota = strmota;
        }
        #endregion

        #region Properties
        public string idnhom
        {
            get
            {
                return stridnhom;
            }
            set
            {
                stridnhom = value;
            }
        }

        public string tennhom
        {
            get
            {
                return strtennhom;
            }
            set
            {
                strtennhom = value;
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
        /// Lấy toàn bộ dữ liệu từ bảng nhom
        /// </summary>
        /// <returns>DataTable</returns>
        public DataTable GetAll()
        {
            string strFun = "fn_nhom_getall";
            try
            {
                DataSet dsnhom = mDataAccess.ExecuteDataSet(strFun, CommandType.StoredProcedure);
                return dsnhom.Tables[0];
            }
            catch
            {
                return null;
            }
        }
        /// <summary>
        /// Hàm lấy nhom theo mã
        /// </summary>
        /// <returns>Trả về objnhom </returns>
        public nhom GetByID(string stridnhom)
        {
            nhom objnhom = new nhom();
            string strFun = "fn_nhom_getobjbyid";
            try
            {
                NpgsqlParameter[] prmArr = new NpgsqlParameter[1];

                prmArr[0] = new NpgsqlParameter("idnhom", NpgsqlDbType.Varchar);
                prmArr[0].Value = stridnhom;

                DataSet dsnhom = mDataAccess.ExecuteDataSet(strFun, CommandType.StoredProcedure, prmArr);

                if ((dsnhom != null) && (dsnhom.Tables.Count > 0))
                {
                    if (dsnhom.Tables[0].Rows.Count > 0)
                    {
                        DataRow dr = dsnhom.Tables[0].Rows[0];
                        objnhom.idnhom = dr["idnhom"].ToString();

                        objnhom.tennhom = dr["tennhom"].ToString();

                        objnhom.mota = dr["mota"].ToString();


                        return objnhom;
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
        /// Hàm kiểm tra trùng tên nhóm
        /// </summary>
        /// <param name="strtennhom">Tên nhóm kiểu string</param>
        /// <param name="stridnhom">Mã nhóm kiểu string</param>
        /// <param name="itrangthai">Trạng thái: 1-Thêm mới;2-Sửa</param>
        /// <returns>bool: True-Trùng;False-Không trùng</returns>
        public bool CheckExit(string strtennhom, string stridnhom, int itrangthai)
        {
            nhom objnhom = new nhom();
            string strFun = "fn_nhom_checkexit";
            try
            {
                NpgsqlParameter[] prmArr = new NpgsqlParameter[3];
                prmArr[0] = new NpgsqlParameter("itennhom", NpgsqlDbType.Varchar);
                prmArr[0].Value = strtennhom;
                prmArr[1] = new NpgsqlParameter("iidnhom", NpgsqlDbType.Varchar);
                prmArr[1].Value = stridnhom;
                prmArr[2] = new NpgsqlParameter("itrangthai", NpgsqlDbType.Integer);
                prmArr[2].Value = itrangthai;
                DataSet dsnhom = mDataAccess.ExecuteDataSet(strFun, CommandType.StoredProcedure, prmArr);
                if ((dsnhom != null) && (dsnhom.Tables.Count > 0))
                {
                    if (dsnhom.Tables[0].Rows.Count > 0)
                    {
                        return true;
                    }
                    return false;
                }
                return false;
            }
            catch
            {
                return true;
            }
        }
        /// <summary>
        /// Thêm mới dữ liệu vào bảng: nhom
        /// </summary>
        /// <param name="obj">objnhom</param>
        /// <returns>Trả về trắng: Thêm mới thành công; Trả về khác trắng: Thêm mới không thành công</returns>
        public string Insert(nhom objnhom)
        {
            string strProc = "fn_nhom_insert";
            try
            {
                NpgsqlParameter[] prmArr = new NpgsqlParameter[4];

                prmArr[0] = new NpgsqlParameter("idnhom", NpgsqlDbType.Varchar);
                prmArr[0].Value = objnhom.stridnhom;

                prmArr[1] = new NpgsqlParameter("tennhom", NpgsqlDbType.Varchar);
                prmArr[1].Value = objnhom.strtennhom;

                prmArr[2] = new NpgsqlParameter("mota", NpgsqlDbType.Varchar);
                prmArr[2].Value = objnhom.strmota;

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
        /// Cập nhật dữ liệu vào bảng: nhom
        /// </summary>
        /// <param name="obj">objnhom</param>
        /// <returns>Trả về trắng: Cập nhật thành công; Trả về khác trắng: Cập nhật không thành công</returns>
        public string Update(nhom objnhom)
        {
            string strProc = "fn_nhom_Update";
            try
            {
                NpgsqlParameter[] prmArr = new NpgsqlParameter[4];

                prmArr[0] = new NpgsqlParameter("idnhom", NpgsqlDbType.Varchar);
                prmArr[0].Value = objnhom.stridnhom;

                prmArr[1] = new NpgsqlParameter("tennhom", NpgsqlDbType.Varchar);
                prmArr[1].Value = objnhom.strtennhom;

                prmArr[2] = new NpgsqlParameter("mota", NpgsqlDbType.Varchar);
                prmArr[2].Value = objnhom.strmota;

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
        /// Xóa dữ liệu từ bảng nhom
        /// </summary>
        /// <returns>Trả về trắng: xóa thành công; Trả về khác trắng: xóa không thành công</returns>
        public string Delete(string stridnhom)
        {
            string strProc = "fn_nhom_delete";
            try
            {
                NpgsqlParameter[] prmArr = new NpgsqlParameter[2];

                prmArr[0] = new NpgsqlParameter("idnhom", NpgsqlDbType.Varchar);
                prmArr[0].Value = stridnhom;

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
        /// Hàm kiểm tra trùng tên nhóm người dùng
        /// </summary>
        /// <param name="sid">Mã nhóm người dùng</param>
        /// <param name="sten">Tên nhóm người dùng</param>
        /// <returns>bool: False-Không tồn tại;True-Có tồn tại</returns>
        public bool CheckExit(string sidnhom, string stennhom)
        {
            string strProc = "fn_nhom_checkexit";
            try
            {
                NpgsqlParameter[] prmArr = new NpgsqlParameter[3];
                prmArr[0] = new NpgsqlParameter("iidnhom", NpgsqlDbType.Varchar);
                prmArr[0].Value = sidnhom;
                prmArr[1] = new NpgsqlParameter("itennhom", NpgsqlDbType.Varchar);
                prmArr[1].Value = stennhom;
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
