using System;
using System.Data;
using System.Collections.Generic;
using System.Text;
using CGCN.Framework;
using Npgsql;
using NpgsqlTypes;
using CGCN.DataAccess;

namespace HoaDonDataAccess.DataAccess
{
    /// <summary>
    /// Mô tả thông tin cho bảng tblhoadontra
    /// Cung cấp các hàm xử lý, thao tác với bảng tblhoadontra
    /// Người tạo (C): 
    /// Ngày khởi tạo: 15/10/2015
    /// </summary>
    public class tblhoadontra
    {
        #region Private Variables
        private string strid;
        private string strid_khachhang;
        private DateTime dtmngaytao;
        private string strghichu;
        #endregion

        #region Public Constructor Functions
        public tblhoadontra()
        {
            strid = string.Empty;
            strid_khachhang = string.Empty;
            dtmngaytao = DateTime.Now;
            strghichu = string.Empty;

        }

        public tblhoadontra(string strid, string strid_khachhang, DateTime dtmngaytao, string strghichu)
        {
            this.strid = strid;
            this.strid_khachhang = strid_khachhang;
            this.dtmngaytao = dtmngaytao;
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

        public string id_khachhang
        {
            get
            {
                return strid_khachhang;
            }
            set
            {
                strid_khachhang = value;
            }
        }

        public DateTime ngaytao
        {
            get
            {
                return dtmngaytao;
            }
            set
            {
                dtmngaytao = value;
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
        private readonly DataAccessLayerBaseClass mDataAccess = new DataAccessLayerBaseClass(Data.ConnectionString);
        /// <summary>
        /// Lấy toàn bộ dữ liệu từ bảng tblhoadontra
        /// </summary>
        /// <returns>DataTable</returns>
        public DataTable GetAll()
        {
            string strFun = "fn_tblhoadontra_getall";
            try
            {
                DataSet dstblhoadontra = mDataAccess.ExecuteDataSet(strFun, CommandType.StoredProcedure);
                return dstblhoadontra.Tables[0];
            }
            catch
            {
                return null;
            }
        }
        /// <summary>
        /// Hàm lấy tblhoadontra theo mã
        /// </summary>
        /// <returns>Trả về objtblhoadontra </returns>
        public tblhoadontra GetByID(string strid)
        {
            tblhoadontra objtblhoadontra = new tblhoadontra();
            string strFun = "fn_tblhoadontra_getobjbyid";
            try
            {
                NpgsqlParameter[] prmArr = new NpgsqlParameter[1];

                prmArr[0] = new NpgsqlParameter("id", NpgsqlDbType.Varchar);
                prmArr[0].Value = strid;

                DataSet dstblhoadontra = mDataAccess.ExecuteDataSet(strFun, CommandType.StoredProcedure, prmArr);

                if ((dstblhoadontra != null) && (dstblhoadontra.Tables.Count > 0))
                {
                    if (dstblhoadontra.Tables[0].Rows.Count > 0)
                    {
                        DataRow dr = dstblhoadontra.Tables[0].Rows[0];
                        objtblhoadontra.id = dr["id"].ToString();

                        objtblhoadontra.id_khachhang = dr["id_khachhang"].ToString();

                        try { objtblhoadontra.ngaytao = Convert.ToDateTime(dr["ngaytao"].ToString()); }
                        catch { objtblhoadontra.ngaytao = new DateTime(1900, 1, 1); }

                        objtblhoadontra.ghichu = dr["ghichu"].ToString();


                        return objtblhoadontra;
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
        /// Thêm mới dữ liệu vào bảng: tblhoadontra
        /// </summary>
        /// <param name="obj">objtblhoadontra</param>
        /// <returns>Trả về trắng: Thêm mới thành công; Trả về khác trắng: Thêm mới không thành công</returns>
        public string Insert(tblhoadontra objtblhoadontra)
        {
            string strProc = "fn_tblhoadontra_insert";
            try
            {
                NpgsqlParameter[] prmArr = new NpgsqlParameter[5];
                prmArr[0] = new NpgsqlParameter("id", NpgsqlDbType.Varchar);
                prmArr[0].Value = objtblhoadontra.strid;
                prmArr[1] = new NpgsqlParameter("id_khachhang", NpgsqlDbType.Varchar);
                prmArr[1].Value = objtblhoadontra.strid_khachhang;
                prmArr[2] = new NpgsqlParameter("ngaytao", NpgsqlDbType.Varchar);
                prmArr[2].Value = objtblhoadontra.ngaytao.ToString("yyyy/MM/dd HH:mm:ss");
                prmArr[3] = new NpgsqlParameter("ghichu", NpgsqlDbType.Varchar);
                prmArr[3].Value = objtblhoadontra.strghichu;
                prmArr[4] = new NpgsqlParameter("ireturn", NpgsqlDbType.Text);
                prmArr[4].Direction = ParameterDirection.Output;
                mDataAccess.ExecuteQuery(strProc, CommandType.StoredProcedure, prmArr);
                string sKQ = prmArr[4].Value.ToString().Trim();
                if (sKQ.ToUpper().Equals("Add".ToUpper()) == true) return "";
                return "Thêm mới dữ liệu không thành công";
            }
            catch (Exception ex)
            {
                return "Thêm mới dữ liệu không thành công. Chi Tiết: " + ex.Message;
            }
        }
        /// <summary>
        /// Cập nhật dữ liệu vào bảng: tblhoadontra
        /// </summary>
        /// <param name="obj">objtblhoadontra</param>
        /// <returns>Trả về trắng: Cập nhật thành công; Trả về khác trắng: Cập nhật không thành công</returns>
        public string Update(tblhoadontra objtblhoadontra)
        {
            string strProc = "fn_tblhoadontra_Update";
            try
            {
                NpgsqlParameter[] prmArr = new NpgsqlParameter[4];
                prmArr[0] = new NpgsqlParameter("id", NpgsqlDbType.Varchar);
                prmArr[0].Value = objtblhoadontra.strid;
                prmArr[1] = new NpgsqlParameter("id_khachhang", NpgsqlDbType.Varchar);
                prmArr[1].Value = objtblhoadontra.strid_khachhang;
                prmArr[2] = new NpgsqlParameter("ghichu", NpgsqlDbType.Varchar);
                prmArr[2].Value = objtblhoadontra.strghichu;
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
        /// Xóa dữ liệu từ bảng tblhoadontra
        /// </summary>
        /// <returns></returns>
        public string Delete(string strid)
        {
            string strProc = "fn_tblhoadontra_delete";
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
        /// Hàm lấy tất cả dữ liệu trong bảng tblhoadontra
        /// </summary>
        /// <returns>Trả về List<<tblhoadontra>></returns>
        public List<tblhoadontra> GetList()
        {
            List<tblhoadontra> list = new List<tblhoadontra>();
            string strFun = "fn_tblhoadontra_getall";
            try
            {
                DataSet dstblhoadontra = mDataAccess.ExecuteDataSet(strFun, CommandType.StoredProcedure);
                if ((dstblhoadontra != null) && (dstblhoadontra.Tables.Count > 0))
                {
                    for (int i = 0; i < dstblhoadontra.Tables[0].Rows.Count; i++)
                    {
                        tblhoadontra objtblhoadontra = new tblhoadontra();
                        DataRow dr = dstblhoadontra.Tables[0].Rows[i];
                        objtblhoadontra.id = dr["id"].ToString();

                        objtblhoadontra.id_khachhang = dr["id_khachhang"].ToString();

                        try { objtblhoadontra.ngaytao = Convert.ToDateTime(dr["ngaytao"].ToString()); }
                        catch { objtblhoadontra.ngaytao = new DateTime(1900, 1, 1); }

                        objtblhoadontra.ghichu = dr["ghichu"].ToString();

                        list.Add(objtblhoadontra);
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
        /// Hàm lấy danh sách objtblhoadontra
        /// </summary>
        /// <param name="recperpage">Số lượng bản ghi kiểu integer</param>
        /// <param name="pageindex">Số trang kiểu integer</param>
        /// <returns>Trả về List<<tblhoadontra>></returns>
        public List<tblhoadontra> GetListPaged(int recperpage, int pageindex)
        {
            List<tblhoadontra> list = new List<tblhoadontra>();
            string strFun = "fn_tblhoadontra_getpaged";
            try
            {
                NpgsqlParameter[] prmArr = new NpgsqlParameter[2];
                prmArr[0] = new NpgsqlParameter("recperpage", NpgsqlDbType.Integer);
                prmArr[0].Value = recperpage;
                prmArr[1] = new NpgsqlParameter("pageindex", NpgsqlDbType.Integer);
                prmArr[1].Value = pageindex;
                DataSet dstblhoadontra = mDataAccess.ExecuteDataSet(strFun, CommandType.StoredProcedure, prmArr);
                if ((dstblhoadontra != null) && (dstblhoadontra.Tables.Count > 0))
                {
                    for (int i = 0; i < dstblhoadontra.Tables[0].Rows.Count; i++)
                    {
                        tblhoadontra objtblhoadontra = new tblhoadontra();
                        DataRow dr = dstblhoadontra.Tables[0].Rows[i];
                        objtblhoadontra.id = dr["id"].ToString();

                        objtblhoadontra.id_khachhang = dr["id_khachhang"].ToString();

                        try { objtblhoadontra.ngaytao = Convert.ToDateTime(dr["ngaytao"].ToString()); }
                        catch { objtblhoadontra.ngaytao = new DateTime(1900, 1, 1); }

                        objtblhoadontra.ghichu = dr["ghichu"].ToString();

                        list.Add(objtblhoadontra);
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
        /// Hàm lấy danh sách objtblhoadontra
        /// </summary>
        /// <param name="recperpage">Số lượng bản ghi kiểu integer</param>
        /// <param name="pageindex">Số trang kiểu integer</param>
        /// <returns>Trả về List<<tblhoadontra>></returns>
        public DataTable GetDataTablePaged(int recperpage, int pageindex)
        {
            string strFun = "fn_tblhoadontra_getpaged";
            try
            {
                NpgsqlParameter[] prmArr = new NpgsqlParameter[2];
                prmArr[0] = new NpgsqlParameter("recperpage", NpgsqlDbType.Integer);
                prmArr[0].Value = recperpage;
                prmArr[1] = new NpgsqlParameter("pageindex", NpgsqlDbType.Integer);
                prmArr[1].Value = pageindex;
                DataSet dstblhoadontra = mDataAccess.ExecuteDataSet(strFun, CommandType.StoredProcedure, prmArr);
                return dstblhoadontra.Tables[0];
            }
            catch
            {
                return null;
            }
        }
        /// <summary>
        /// Hàm tìm kiếm hóa đơn trả lại hàng
        /// </summary>
        /// <param name="skeyword">Từ khóa (Tên khách hàng, dt, ghichu, diachi)</param>
        /// <param name="stungay">Từ ngày kiểu string format: yyyy/MM/dd</param>
        /// <param name="sdengay">Đến ngày kiểu string format: yyyy/MM/dd</param>
        /// <returns>DataTable</returns>
        public DataTable Filter(string skeyword, string stungay, string sdengay)
        {
            tblhoadonban objtblhoadonban = new tblhoadonban();
            string strFun = "fn_tblhoadontra_filter";
            try
            {
                NpgsqlParameter[] prmArr = new NpgsqlParameter[3];
                prmArr[0] = new NpgsqlParameter("keyword", NpgsqlDbType.Varchar);
                prmArr[0].Value = skeyword;
                prmArr[1] = new NpgsqlParameter("tungay", NpgsqlDbType.Varchar);
                prmArr[1].Value = stungay;
                prmArr[2] = new NpgsqlParameter("dengay", NpgsqlDbType.Varchar);
                prmArr[2].Value = sdengay;
                DataSet dstblhoadonban = mDataAccess.ExecuteDataSet(strFun, CommandType.StoredProcedure, prmArr);
                return dstblhoadonban.Tables[0];
            }
            catch
            {
                return null;
            }
        }
        #endregion
    }
}
