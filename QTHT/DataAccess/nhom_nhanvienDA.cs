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
     /// Mô tả thông tin cho bảng nhom_nhanvien
     /// Cung cấp các hàm xử lý, thao tác với bảng nhom_nhanvien
     /// Người tạo (C): 
     /// Ngày khởi tạo: 20/10/2014
     /// </summary>
    public class nhom_nhanvien
    {
        #region Private Variables
        private string stridnhom_nhanvien;
        private string stridnhanvien;
        private string stridnhom;
        #endregion

        #region Public Constructor Functions
        public nhom_nhanvien()
        {
            stridnhom_nhanvien = string.Empty;
            stridnhanvien = string.Empty;
            stridnhom = string.Empty;

        }

        public nhom_nhanvien(string stridnhom_nhanvien, string stridnhanvien, string stridnhom)
        {
            this.stridnhom_nhanvien = stridnhom_nhanvien;
            this.stridnhanvien = stridnhanvien;
            this.stridnhom = stridnhom;
        }
        #endregion

        #region Properties
        public string idnhom_nhanvien
        {
            get
            {
                return stridnhom_nhanvien;
            }
            set
            {
                stridnhom_nhanvien = value;
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
        #endregion

        #region Public Method
        private readonly DataAccessLayerBaseClass mDataAccess = new DataAccessLayerBaseClass(Data.ConnectionString);
        /// <summary>
        /// Lấy toàn bộ dữ liệu từ bảng nhom_nhanvien
        /// </summary>
        /// <returns>DataTable</returns>
        public DataTable GetAll()
        {
            string strFun = "fn_nhom_nhanvien_getall";
            try
            {
                DataSet dsnhom_nhanvien = mDataAccess.ExecuteDataSet(strFun, CommandType.StoredProcedure);
                return dsnhom_nhanvien.Tables[0];
            }
            catch
            {
                return null;
            }
        }
        /// <summary>
        /// Hàm lấy nhom_nhanvien theo mã
        /// </summary>
        /// <returns>Trả về objnhom_nhanvien </returns>
        public nhom_nhanvien GetByID(string stridnhom_nhanvien)
        {
            nhom_nhanvien objnhom_nhanvien = new nhom_nhanvien();
            string strFun = "fn_nhom_nhanvien_getobjbyid";
            try
            {
                NpgsqlParameter[] prmArr = new NpgsqlParameter[1];

                prmArr[0] = new NpgsqlParameter("idnhom_nhanvien", NpgsqlDbType.Varchar);
                prmArr[0].Value = stridnhom_nhanvien;

                DataSet dsnhom_nhanvien = mDataAccess.ExecuteDataSet(strFun, CommandType.StoredProcedure, prmArr);

                if ((dsnhom_nhanvien != null) && (dsnhom_nhanvien.Tables.Count > 0))
                {
                    if (dsnhom_nhanvien.Tables[0].Rows.Count > 0)
                    {
                        DataRow dr = dsnhom_nhanvien.Tables[0].Rows[0];
                        objnhom_nhanvien.idnhom_nhanvien = dr["idnhom_nhanvien"].ToString();

                        objnhom_nhanvien.idnhanvien = dr["idnhanvien"].ToString();

                        objnhom_nhanvien.idnhom = dr["idnhom"].ToString();


                        return objnhom_nhanvien;
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
        /// Hàm lấy danh sách người dùng theo mã nhóm
        /// </summary>
        /// <param name="stridnhom">Mã nhóm kiểu string</param>
        /// <returns>DataTable</returns>
        public DataTable GetByIDNhom(string stridnhom)
        {
            string strFun = "fn_nhom_nhanvien_getbyidnhom";
            try
            {
                NpgsqlParameter[] prmArr = new NpgsqlParameter[1];
                prmArr[0] = new NpgsqlParameter("idnhom", NpgsqlDbType.Varchar);
                prmArr[0].Value = stridnhom;
                DataSet dsnhom_nhanvien = mDataAccess.ExecuteDataSet(strFun, CommandType.StoredProcedure, prmArr);
                return dsnhom_nhanvien.Tables[0];
            }
            catch
            {
                return null;
            }
        }
        /// <summary>
        /// Hàm lấy danh sách nhóm theo mã người dùng
        /// </summary>
        /// <param name="stridnhanvien">Mã người dùng kiểu string</param>
        /// <returns>DataTable</returns>
        public DataTable GetByIDNhanVien(string stridnhanvien)
        {
            string strFun = "fn_nhom_nhanvien_getbyidnhnhanvien";
            try
            {
                NpgsqlParameter[] prmArr = new NpgsqlParameter[1];
                prmArr[0] = new NpgsqlParameter("idnhanvien", NpgsqlDbType.Varchar);
                prmArr[0].Value = stridnhanvien;
                DataSet dsnhom_nhanvien = mDataAccess.ExecuteDataSet(strFun, CommandType.StoredProcedure, prmArr);
                return dsnhom_nhanvien.Tables[0];
            }
            catch
            {
                return null;
            }
        }
        /// <summary>
        /// Thêm mới dữ liệu vào bảng: nhom_nhanvien
        /// </summary>
        /// <param name="obj">objnhom_nhanvien</param>
        /// <returns>Trả về trắng: Thêm mới thành công; Trả về khác trắng: Thêm mới không thành công</returns>
        public string Insert(nhom_nhanvien objnhom_nhanvien)
        {
            string strProc = "fn_nhom_nhanvien_insert";
            try
            {
                NpgsqlParameter[] prmArr = new NpgsqlParameter[4];

                prmArr[0] = new NpgsqlParameter("idnhom_nhanvien", NpgsqlDbType.Varchar);
                prmArr[0].Value = objnhom_nhanvien.stridnhom_nhanvien;

                prmArr[1] = new NpgsqlParameter("idnhanvien", NpgsqlDbType.Varchar);
                prmArr[1].Value = objnhom_nhanvien.stridnhanvien;

                prmArr[2] = new NpgsqlParameter("idnhom", NpgsqlDbType.Varchar);
                prmArr[2].Value = objnhom_nhanvien.stridnhom;

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
        /// Cập nhật dữ liệu vào bảng: nhom_nhanvien
        /// </summary>
        /// <param name="obj">objnhom_nhanvien</param>
        /// <returns>Trả về trắng: Cập nhật thành công; Trả về khác trắng: Cập nhật không thành công</returns>
        public string Update(nhom_nhanvien objnhom_nhanvien)
        {
            string strProc = "fn_nhom_nhanvien_Update";
            try
            {
                NpgsqlParameter[] prmArr = new NpgsqlParameter[4];

                prmArr[0] = new NpgsqlParameter("idnhom_nhanvien", NpgsqlDbType.Varchar);
                prmArr[0].Value = objnhom_nhanvien.stridnhom_nhanvien;

                prmArr[1] = new NpgsqlParameter("idnhanvien", NpgsqlDbType.Varchar);
                prmArr[1].Value = objnhom_nhanvien.stridnhanvien;

                prmArr[2] = new NpgsqlParameter("idnhom", NpgsqlDbType.Varchar);
                prmArr[2].Value = objnhom_nhanvien.stridnhom;

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
        /// Xóa dữ liệu từ bảng nhom_nhanvien
        /// </summary>
        /// <returns></returns>
        public string Delete(string stridnhom_nhanvien)
        {
            string strProc = "fn_nhom_nhanvien_delete";
            try
            {
                NpgsqlParameter[] prmArr = new NpgsqlParameter[2];

                prmArr[0] = new NpgsqlParameter("idnhom_nhanvien", NpgsqlDbType.Varchar);
                prmArr[0].Value = stridnhom_nhanvien;

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
        /// Xóa dữ liệu theo mã nhóm người dùng
        /// </summary>
        /// <param name="stridnhom">Mã nhóm người dùng kiểu string</param>
        /// <returns>Trả về trắng: Xóa thành công; Trả về khác trắng: Xóa không thành công</returns>
        public string DeleteByIDNhom(string stridnhom)
        {
            string strProc = "fn_nhom_nhanvien_deletebyidnhom";
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
        /// <summary>
        /// Xóa dữ liệu theo mã người dùng
        /// </summary>
        /// <param name="stridnhom">Mã người dùng kiểu string</param>
        /// <returns>Trả về trắng: Xóa thành công; Trả về khác trắng: Xóa không thành công</returns>
        public string DeleteByIDNhanVien(string stridnhanvien)
        {
            string strProc = "fn_nhom_nhanvien_deletebyidnhanvien";
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
        #endregion
    }
}
