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
     /// Mô tả thông tin cho bảng PhongBan
     /// Cung cấp các hàm xử lý, thao tác với bảng PhongBan
     /// Người tạo (C): 
     /// Ngày khởi tạo: 14/10/2014
     /// </summary>
    public class phongban
    {
        #region Private Variables
        private string stridphongban;
        private string strtenphongban;
        private string strmota;
        #endregion

        #region Public Constructor Functions
        public phongban()
        {
            stridphongban = string.Empty;
            strtenphongban = string.Empty;
            strmota = string.Empty;

        }

        public phongban(string stridphongban, string strtenphongban, string strmota)
        {
            this.stridphongban = stridphongban;
            this.strtenphongban = strtenphongban;
            this.strmota = strmota;
        }
        #endregion

        #region Properties
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

        public string tenphongban
        {
            get
            {
                return strtenphongban;
            }
            set
            {
                strtenphongban = value;
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
        /// Lấy toàn bộ dữ liệu từ bảng PhongBan
        /// </summary>
        /// <returns>DataTable</returns>
        public DataTable GetAll()
        {
            string strFun = "fn_phongban_getall";
            try
            {
                DataSet dsPhongBan = mDataAccess.ExecuteDataSet(strFun, CommandType.StoredProcedure);
                return dsPhongBan.Tables[0];
            }
            catch
            {
                return null;
            }
        }
        /// <summary>
        /// Hàm lấy tất cả danh sách phòng ban và đơn vị(Cơ quan quản lý)
        /// </summary>
        /// <returns>DataTable</returns>
        public DataTable GetAllPhongBanvsDonVi()
        {
            string strFun = "fn_phongban_getalldonvi";
            try
            {
                DataSet dsPhongBan = mDataAccess.ExecuteDataSet(strFun, CommandType.StoredProcedure);
                return dsPhongBan.Tables[0];
            }
            catch
            {
                return null;
            }
        }
        /// <summary>
        /// Hàm lấy phongban theo mã
        /// </summary>
        /// <returns>Trả về objphongban </returns>
        public phongban GetByID(string stridphongban)
        {
            phongban objphongban = new phongban();
            string strFun = "fn_phongban_getobjbyid";
            try
            {
                NpgsqlParameter[] prmArr = new NpgsqlParameter[1];

                prmArr[0] = new NpgsqlParameter("idphongban", NpgsqlDbType.Varchar);
                prmArr[0].Value = stridphongban;

                DataSet dsphongban = mDataAccess.ExecuteDataSet(strFun, CommandType.StoredProcedure, prmArr);

                if ((dsphongban != null) && (dsphongban.Tables.Count > 0))
                {
                    if (dsphongban.Tables[0].Rows.Count > 0)
                    {
                        DataRow dr = dsphongban.Tables[0].Rows[0];
                        objphongban.idphongban = dr["idphongban"].ToString();

                        objphongban.tenphongban = dr["tenphongban"].ToString();

                        objphongban.mota = dr["mota"].ToString();


                        return objphongban;
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
        /// Thêm mới dữ liệu vào bảng: phongban
        /// </summary>
        /// <param name="obj">objphongban</param>
        /// <returns>Trả về trắng: Thêm mới thành công; Trả về khác trắng: Thêm mới không thành công</returns>
        public string Insert(phongban objphongban)
        {
            string strProc = "fn_phongban_insert";
            try
            {
                NpgsqlParameter[] prmArr = new NpgsqlParameter[4];

                prmArr[0] = new NpgsqlParameter("idphongban", NpgsqlDbType.Varchar);
                prmArr[0].Value = objphongban.stridphongban;

                prmArr[1] = new NpgsqlParameter("tenphongban", NpgsqlDbType.Varchar);
                prmArr[1].Value = objphongban.strtenphongban;

                prmArr[2] = new NpgsqlParameter("mota", NpgsqlDbType.Varchar);
                prmArr[2].Value = objphongban.strmota;

                prmArr[3] = new NpgsqlParameter("ireturn", NpgsqlDbType.Text);
                prmArr[3].Direction = ParameterDirection.Output;

                mDataAccess.ExecuteQuery(strProc, CommandType.StoredProcedure, prmArr);

                string sKQ = prmArr[3].Value.ToString().Trim();

                if (sKQ.ToUpper().Equals("Add".ToUpper()) == true) return "";
                return "Thêm mới dữ liệu không thành công";
            }
            catch (Exception ex)
            {
                return "Thêm mới dữ liệu không thành công. Chi Tiết: " + ex.Message;
            }
        }
        /// <summary>
        /// Cập nhật dữ liệu vào bảng: phongban
        /// </summary>
        /// <param name="obj">objphongban</param>
        /// <returns>Trả về trắng: Cập nhật thành công; Trả về khác trắng: Cập nhật không thành công</returns>
        public string Update(phongban objphongban)
        {
            string strProc = "fn_phongban_Update";
            try
            {
                NpgsqlParameter[] prmArr = new NpgsqlParameter[4];

                prmArr[0] = new NpgsqlParameter("idphongban", NpgsqlDbType.Varchar);
                prmArr[0].Value = objphongban.stridphongban;

                prmArr[1] = new NpgsqlParameter("tenphongban", NpgsqlDbType.Varchar);
                prmArr[1].Value = objphongban.strtenphongban;

                prmArr[2] = new NpgsqlParameter("mota", NpgsqlDbType.Varchar);
                prmArr[2].Value = objphongban.strmota;

                prmArr[3] = new NpgsqlParameter("ireturn", NpgsqlDbType.Text);
                prmArr[3].Direction = ParameterDirection.Output;

                mDataAccess.ExecuteQuery(strProc, CommandType.StoredProcedure, prmArr);
                string sKQ = prmArr[3].Value.ToString().Trim();
                if (sKQ.ToUpper().Equals("Update".ToUpper()) == true) return "";
                return "Cập nhật dữ liệu không thành công";

            }
            catch (Exception ex)
            {
                return "Cập nhật dữ liệu không thành công. Chi Tiết: " + ex.Message;
            }
        }
        /// <summary>
        /// Xóa dữ liệu từ bảng phongban
        /// </summary>
        /// <returns>Trả về trắng: xóa thành công; Trả về khác trắng: xóa không thành công</returns>
        public string Delete(string stridphongban)
        {
            string strProc = "fn_phongban_delete";
            try
            {
                NpgsqlParameter[] prmArr = new NpgsqlParameter[2];

                prmArr[0] = new NpgsqlParameter("idphongban", NpgsqlDbType.Varchar);
                prmArr[0].Value = stridphongban;

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
        /// Hàm kiểm tra trùng tên phòng ban
        /// </summary>
        /// <param name="sid">Mã phòng ban</param>
        /// <param name="sten">Tên phòng ban</param>
        /// <returns>bool: False-Không tồn tại;True-Có tồn tại</returns>
        public bool CheckExit(string sidphongban, string stenphongban)
        {
            string strProc = "fn_phongban_checkexit";
            try
            {
                NpgsqlParameter[] prmArr = new NpgsqlParameter[3];
                prmArr[0] = new NpgsqlParameter("idphongban", NpgsqlDbType.Varchar);
                prmArr[0].Value = sidphongban;
                prmArr[1] = new NpgsqlParameter("tenphongban", NpgsqlDbType.Varchar);
                prmArr[1].Value = stenphongban;
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
