using System;
using System.Data;
using System.Collections.Generic;
using System.Text;
using CGCN.Framework;
using Npgsql;
using NpgsqlTypes;
using CGCN.DataAccess;

namespace DanhMuc.DataAccess
{
     /// <summary>
     /// Mô tả thông tin cho bảng tblhangsanxuat
     /// Cung cấp các hàm xử lý, thao tác với bảng tblhangsanxuat
     /// Người tạo (C): tuanva
     /// Ngày khởi tạo: 19/07/2015
     /// </summary>
    public class tblhangsanxuat
    {
        #region Private Variables
        private string strid;
        private string strten;
        private string strghichu;
        #endregion

        #region Public Constructor Functions
        public tblhangsanxuat()
        {
            strid = string.Empty;
            strten = string.Empty;
            strghichu = string.Empty;

        }

        public tblhangsanxuat(string strid, string strten, string strghichu)
        {
            this.strid = strid;
            this.strten = strten;
            this.strghichu = strghichu;
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

        public string ten
        {
            get
            {
                return strten;
            }
            set
            {
                strten = value;
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
        #endregion

        #region Public Method
        private readonly CGCN.Framework.DataAccessLayerBaseClass mDataAccess = new DataAccessLayerBaseClass(Data.ConnectionString);
        /// <summary>
        /// Lấy toàn bộ dữ liệu từ bảng tblhangsanxuat
        /// </summary>
        /// <returns>DataTable</returns>
        public DataTable GetAll()
        {
            string strFun = "fn_tblhangsanxuat_getall";
            try
            {
                DataSet dstblhangsanxuat = mDataAccess.ExecuteDataSet(strFun, CommandType.StoredProcedure);
                return dstblhangsanxuat.Tables[0];
            }
            catch
            {
                return null;
            }
        }
        /// <summary>
        /// Hàm lấy tblhangsanxuat theo mã
        /// </summary>
        /// <returns>Trả về objtblhangsanxuat </returns>
        public tblhangsanxuat GetByID(string strid)
        {
            tblhangsanxuat objtblhangsanxuat = new tblhangsanxuat();
            string strFun = "fn_tblhangsanxuat_getobjbyid";
            try
            {
                NpgsqlParameter[] prmArr = new NpgsqlParameter[1];

                prmArr[0] = new NpgsqlParameter("id", NpgsqlDbType.Varchar);
                prmArr[0].Value = strid;

                DataSet dstblhangsanxuat = mDataAccess.ExecuteDataSet(strFun, CommandType.StoredProcedure, prmArr);

                if ((dstblhangsanxuat != null) && (dstblhangsanxuat.Tables.Count > 0))
                {
                    if (dstblhangsanxuat.Tables[0].Rows.Count > 0)
                    {
                        DataRow dr = dstblhangsanxuat.Tables[0].Rows[0];
                        objtblhangsanxuat.id = dr["id"].ToString();

                        objtblhangsanxuat.ten = dr["ten"].ToString();

                        objtblhangsanxuat.ghichu = dr["ghichu"].ToString();


                        return objtblhangsanxuat;
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
        /// Thêm mới dữ liệu vào bảng: tblhangsanxuat
        /// </summary>
        /// <param name="obj">objtblhangsanxuat</param>
        /// <returns>Trả về trắng: Thêm mới thành công; Trả về khác trắng: Thêm mới không thành công</returns>
        public string Insert(tblhangsanxuat objtblhangsanxuat)
        {
            string strProc = "fn_tblhangsanxuat_insert";
            try
            {
                NpgsqlParameter[] prmArr = new NpgsqlParameter[4];

                prmArr[0] = new NpgsqlParameter("id", NpgsqlDbType.Varchar);
                prmArr[0].Value = objtblhangsanxuat.strid;

                prmArr[1] = new NpgsqlParameter("ten", NpgsqlDbType.Varchar);
                prmArr[1].Value = objtblhangsanxuat.strten;

                prmArr[2] = new NpgsqlParameter("ghichu", NpgsqlDbType.Varchar);
                prmArr[2].Value = objtblhangsanxuat.strghichu;

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
        /// Cập nhật dữ liệu vào bảng: tblhangsanxuat
        /// </summary>
        /// <param name="obj">objtblhangsanxuat</param>
        /// <returns>Trả về trắng: Cập nhật thành công; Trả về khác trắng: Cập nhật không thành công</returns>
        public string Update(tblhangsanxuat objtblhangsanxuat)
        {
            string strProc = "fn_tblhangsanxuat_Update";
            try
            {
                NpgsqlParameter[] prmArr = new NpgsqlParameter[4];

                prmArr[0] = new NpgsqlParameter("id", NpgsqlDbType.Varchar);
                prmArr[0].Value = objtblhangsanxuat.strid;

                prmArr[1] = new NpgsqlParameter("ten", NpgsqlDbType.Varchar);
                prmArr[1].Value = objtblhangsanxuat.strten;

                prmArr[2] = new NpgsqlParameter("ghichu", NpgsqlDbType.Varchar);
                prmArr[2].Value = objtblhangsanxuat.strghichu;

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
        /// Xóa dữ liệu từ bảng tblhangsanxuat
        /// </summary>
        /// <returns></returns>
        public string Delete(string strid)
        {
            string strProc = "fn_tblhangsanxuat_delete";
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
            catch (Exception ex)
            {
                return "Xóa dữ liệu không thành công. Chi Tiết: " + ex.Message;
            }
        }
        /// <summary>
        /// Hàm lấy tất cả dữ liệu trong bảng tblhangsanxuat
        /// </summary>
        /// <returns>Trả về List<<tblhangsanxuat>></returns>
        public List<tblhangsanxuat> GetList()
        {
            List<tblhangsanxuat> list = new List<tblhangsanxuat>();
            string strFun = "fn_tblhangsanxuat_getall";
            try
            {
                DataSet dstblhangsanxuat = mDataAccess.ExecuteDataSet(strFun, CommandType.StoredProcedure);
                if ((dstblhangsanxuat != null) && (dstblhangsanxuat.Tables.Count > 0))
                {
                    for (int i = 0; i < dstblhangsanxuat.Tables[0].Rows.Count; i++)
                    {
                        tblhangsanxuat objtblhangsanxuat = new tblhangsanxuat();
                        DataRow dr = dstblhangsanxuat.Tables[0].Rows[i];
                        objtblhangsanxuat.id = dr["id"].ToString();

                        objtblhangsanxuat.ten = dr["ten"].ToString();

                        objtblhangsanxuat.ghichu = dr["ghichu"].ToString();

                        list.Add(objtblhangsanxuat);
                    }
                    return list;
                }
                return null;
            }
            catch
            {
                return null;
            }
        }
        /// <summary>
        /// Hàm lấy danh sách objtblhangsanxuat
        /// </summary>
        /// <param name="recperpage">Số lượng bản ghi kiểu integer</param>
        /// <param name="pageindex">Số trang kiểu integer</param>
        /// <returns>Trả về List<<tblhangsanxuat>></returns>
        public List<tblhangsanxuat> GetListPaged(int recperpage, int pageindex)
        {
            List<tblhangsanxuat> list = new List<tblhangsanxuat>();
            string strFun = "fn_tblhangsanxuat_getpaged";
            try
            {
                NpgsqlParameter[] prmArr = new NpgsqlParameter[2];
                prmArr[0] = new NpgsqlParameter("recperpage", NpgsqlDbType.Integer);
                prmArr[0].Value = recperpage;
                prmArr[1] = new NpgsqlParameter("pageindex", NpgsqlDbType.Integer);
                prmArr[1].Value = pageindex;
                DataSet dstblhangsanxuat = mDataAccess.ExecuteDataSet(strFun, CommandType.StoredProcedure, prmArr);
                if ((dstblhangsanxuat != null) && (dstblhangsanxuat.Tables.Count > 0))
                {
                    for (int i = 0; i < dstblhangsanxuat.Tables[0].Rows.Count; i++)
                    {
                        tblhangsanxuat objtblhangsanxuat = new tblhangsanxuat();
                        DataRow dr = dstblhangsanxuat.Tables[0].Rows[i];
                        objtblhangsanxuat.id = dr["id"].ToString();

                        objtblhangsanxuat.ten = dr["ten"].ToString();

                        objtblhangsanxuat.ghichu = dr["ghichu"].ToString();

                        list.Add(objtblhangsanxuat);
                    }
                    return list;
                }
                return null;
            }
            catch
            {
                return null;
            }
        }
        /// <summary>
        /// Hàm lấy danh sách objtblhangsanxuat
        /// </summary>
        /// <param name="recperpage">Số lượng bản ghi kiểu integer</param>
        /// <param name="pageindex">Số trang kiểu integer</param>
        /// <returns>Trả về List<<tblhangsanxuat>></returns>
        public DataTable GetDataTablePaged(int recperpage, int pageindex)
        {
            string strFun = "fn_tblhangsanxuat_getpaged";
            try
            {
                NpgsqlParameter[] prmArr = new NpgsqlParameter[2];
                prmArr[0] = new NpgsqlParameter("recperpage", NpgsqlDbType.Integer);
                prmArr[0].Value = recperpage;
                prmArr[1] = new NpgsqlParameter("pageindex", NpgsqlDbType.Integer);
                prmArr[1].Value = pageindex;
                DataSet dstblhangsanxuat = mDataAccess.ExecuteDataSet(strFun, CommandType.StoredProcedure, prmArr);
                return dstblhangsanxuat.Tables[0];
            }
            catch
            {
                return null;
            }
        }
        /// <summary>
        /// Hàm kiểm tra trùng tên
        /// </summary>
        /// <param name="sid">Mã hãng sản xuất</param>
        /// <param name="sten">Tên hãng sản suất</param>
        /// <returns>bool: False-Không tồn tại;True-Có tồn tại</returns>
        public bool CheckExit(string sid,string sten)
        {
            string strProc = "fn_tblhangsanxuat_checkexit";
            try
            {
                NpgsqlParameter[] prmArr = new NpgsqlParameter[3];
                prmArr[0] = new NpgsqlParameter("id", NpgsqlDbType.Varchar);
                prmArr[0].Value = sid;
                prmArr[1] = new NpgsqlParameter("ten", NpgsqlDbType.Varchar);
                prmArr[1].Value = sten;
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
