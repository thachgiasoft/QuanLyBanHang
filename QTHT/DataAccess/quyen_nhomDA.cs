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
     /// Mô tả thông tin cho bảng quyen_nhom
     /// Cung cấp các hàm xử lý, thao tác với bảng quyen_nhom
     /// Người tạo (C): 
     /// Ngày khởi tạo: 17/10/2014
     /// </summary>
    public class quyen_nhom
    {
        #region Private Variables
        private string strid;
        private string stridnhom;
        private int intmenuid;
        #endregion

        #region Public Constructor Functions
        public quyen_nhom()
        {
            strid = string.Empty;
            stridnhom = string.Empty;
            intmenuid = 0;
        }
        public quyen_nhom(string strid, string stridnhom, int intmenuid)
        {
            this.strid = strid;
            this.stridnhom = stridnhom;
            this.intmenuid = intmenuid;
        }
        #endregion

        #region Properties
        public string id
        {
            get
            {
                return strid;
            }
            set
            {
                strid = value;
            }
        }

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

        public int menuid
        {
            get
            {
                return intmenuid;
            }
            set
            {
                intmenuid = value;
            }
        }
        #endregion

        #region Public Method
        private readonly DataAccessLayerBaseClass mDataAccess = new DataAccessLayerBaseClass(Data.ConnectionString);
        /// <summary>
        /// Lấy toàn bộ dữ liệu từ bảng quyen_nhom
        /// </summary>
        /// <returns>DataTable</returns>
        public DataTable GetAll()
        {
            string strFun = "fn_quyen_nhom_getall";
            try
            {
                DataSet dsquyen_nhom = mDataAccess.ExecuteDataSet(strFun, CommandType.StoredProcedure);
                return dsquyen_nhom.Tables[0];
            }
            catch
            {
                return null;
            }
        }
        /// <summary>
        /// Hàm lấy quyen_nhom theo mã
        /// </summary>
        /// <returns>Trả về objquyen_nhom </returns>
        public quyen_nhom GetByID(string strid)
        {
            quyen_nhom objquyen_nhom = new quyen_nhom();
            string strFun = "fn_quyen_nhom_getobjbyid";
            try
            {
                NpgsqlParameter[] prmArr = new NpgsqlParameter[1];
                prmArr[0] = new NpgsqlParameter("id", NpgsqlDbType.Varchar);
                prmArr[0].Value = strid;
                DataSet dsquyen_nhom = mDataAccess.ExecuteDataSet(strFun, CommandType.StoredProcedure, prmArr);
                if ((dsquyen_nhom != null) && (dsquyen_nhom.Tables.Count > 0))
                {
                    if (dsquyen_nhom.Tables[0].Rows.Count > 0)
                    {
                        DataRow dr = dsquyen_nhom.Tables[0].Rows[0];
                        objquyen_nhom.id = dr["id"].ToString();
                        objquyen_nhom.idnhom = dr["idnhom"].ToString();
                        try{ objquyen_nhom.menuid = Convert.ToInt32("0" + dr["menuid"].ToString());}
                        catch{ objquyen_nhom.menuid = 0;}
                        return objquyen_nhom;
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
        /// Hàm lấy danh sách chức năng theo mã nhóm
        /// </summary>
        /// <param name="stridnhom">Mã nhóm kiểu string</param>
        /// <returns>DataTable</returns>
        public DataTable GetByIDNhom(string stridnhom)
        {
            quyen_nhom objquyen_nhom = new quyen_nhom();
            string strFun = "fn_quyen_nhom_getbyidnhom";
            try
            {
                NpgsqlParameter[] prmArr = new NpgsqlParameter[1];
                prmArr[0] = new NpgsqlParameter("idnhom", NpgsqlDbType.Varchar);
                prmArr[0].Value = stridnhom;
                DataSet dsquyen_nhom = mDataAccess.ExecuteDataSet(strFun, CommandType.StoredProcedure, prmArr);
                return dsquyen_nhom.Tables[0];
            }
            catch
            {
                return null;
            }
        }
        /// <summary>
        /// Thêm mới dữ liệu vào bảng: quyen_nhom
        /// </summary>
        /// <param name="obj">objquyen_nhom</param>
        /// <returns>Trả về trắng: Thêm mới thành công; Trả về khác trắng: Thêm mới không thành công</returns>
        public string Insert(quyen_nhom objquyen_nhom)
        {
            string strProc = "fn_quyen_nhom_insert";
            try
            {
                NpgsqlParameter[] prmArr = new NpgsqlParameter[4];
                prmArr[0] = new NpgsqlParameter("id", NpgsqlDbType.Varchar);
                prmArr[0].Value = objquyen_nhom.strid;
                prmArr[1] = new NpgsqlParameter("idnhom", NpgsqlDbType.Varchar);
                prmArr[1].Value = objquyen_nhom.stridnhom;
                prmArr[2] = new NpgsqlParameter("menuid", NpgsqlDbType.Integer);
                prmArr[2].Value = objquyen_nhom.intmenuid;
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
        /// Cập nhật dữ liệu vào bảng: quyen_nhom
        /// </summary>
        /// <param name="obj">objquyen_nhom</param>
        /// <returns>Trả về trắng: Cập nhật thành công; Trả về khác trắng: Cập nhật không thành công</returns>
        public string Update(quyen_nhom objquyen_nhom)
        {
            string strProc = "fn_quyen_nhom_Update";
            try
            {
                NpgsqlParameter[] prmArr = new NpgsqlParameter[4];
                prmArr[0] = new NpgsqlParameter("id", NpgsqlDbType.Varchar);
                prmArr[0].Value = objquyen_nhom.strid;
                prmArr[1] = new NpgsqlParameter("idnhom", NpgsqlDbType.Varchar);
                prmArr[1].Value = objquyen_nhom.stridnhom;
                prmArr[2] = new NpgsqlParameter("menuid", NpgsqlDbType.Integer);
                prmArr[2].Value = objquyen_nhom.intmenuid;
                prmArr[3] = new NpgsqlParameter("ireturn", NpgsqlDbType.Text);
                prmArr[3].Direction = ParameterDirection.Output;
                mDataAccess.ExecuteQuery(strProc, CommandType.StoredProcedure, prmArr);
                string sKQ = prmArr[3].Value.ToString().Trim();
                if (sKQ.ToUpper().Equals("Update".ToUpper()) == true) return "";
                return "Cập nhật dữ liệu không thành công";

            }
            catch(Exception ex)
            {
                return "Cập nhật dữ liệu không thành công. Chi Tiết: " + ex.Message;
            }
        }
        /// <summary>
        /// Hàm xóa dữ liệu theo mã
        /// </summary>
        /// <param name="strid">Mã kiểu string</param>
        /// <returns>Trả về trắng: xóa thành công; Trả về khác trắng: xóa không thành công</returns>
        public string Delete(string strid)
        {
            string strProc = "fn_quyen_nhom_delete";
            try
            {
                NpgsqlParameter[] prmArr = new NpgsqlParameter[2];

                prmArr[0] = new NpgsqlParameter("id", NpgsqlDbType.Varchar);
                prmArr[0].Value = strid;

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
        /// Hàm xóa dữ liệu theo mã nhóm
        /// </summary>
        /// <param name="stridnhom">Mã nhóm kiểu string</param>
        /// <returns>Trả về trắng: xóa thành công; Trả về khác trắng: xóa không thành công</returns>
        public string DeletebyIDNhom(string stridnhom)
        {
            string strProc = "fn_quyen_nhom_deletebyidnhom";
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
            catch (Exception ex)
            {
                return "Xóa dữ liệu không thành công. Chi Tiết: " + ex.Message;
            }
        }
        #endregion
    }
}
