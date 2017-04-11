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
    /// Mô tả thông tin cho bảng tblkhachhang
    /// Cung cấp các hàm xử lý, thao tác với bảng tblkhachhang
    /// Người tạo (C): tuanva
    /// Ngày khởi tạo: 30/07/2015
    /// </summary>
    public class tblkhachhang
    {
        #region Private Variables
        private string strid;
        private string strid_capdl;
        private string strtenkh;
        private string strdiachi;
        private string strdt;
        private string strghichu;
        private string strtenkhbodau;
        #endregion

        #region Public Constructor Functions
        public tblkhachhang()
        {
            strid = string.Empty;
            strid_capdl = string.Empty;
            strtenkh = string.Empty;
            strdiachi = string.Empty;
            strdt = string.Empty;
            strghichu = string.Empty;
            strtenkhbodau = string.Empty;

        }

        public tblkhachhang(string strid, string strid_capdl, string strtenkh, string strdiachi, string strdt, string strghichu, string strtenkhbodau)
        {
            this.strid = strid;
            this.strid_capdl = strid_capdl;
            this.strtenkh = strtenkh;
            this.strdiachi = strdiachi;
            this.strdt = strdt;
            this.strghichu = strghichu;
            this.strtenkhbodau = strtenkhbodau;
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

        public string id_capdl
        {
            get
            {
                return strid_capdl;
            }
            set
            {
                strid_capdl = value;
            }
        }

        public string tenkh
        {
            get
            {
                return strtenkh;
            }
            set
            {
                strtenkh = value;
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

        public string dt
        {
            get
            {
                return strdt;
            }
            set
            {
                strdt = value;
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

        public string tenkhbodau
        {
            get
            {
                return strtenkhbodau;
            }
            set
            {
                strtenkhbodau = value;
            }
        }
        #endregion

        #region Public Method
        private readonly CGCN.Framework.DataAccessLayerBaseClass mDataAccess = new DataAccessLayerBaseClass(Data.ConnectionString);
        /// <summary>
        /// Lấy toàn bộ dữ liệu từ bảng tblkhachhang
        /// </summary>
        /// <returns>DataTable</returns>
        public DataTable GetAll()
        {
            string strFun = "fn_tblkhachhang_getall";
            try
            {
                DataSet dstblkhachhang = mDataAccess.ExecuteDataSet(strFun, CommandType.StoredProcedure);
                return dstblkhachhang.Tables[0];
            }
            catch
            {
                return null;
            }
        }
        /// <summary>
        /// Hàm lấy tất cả danh sách khách hàng đã có hóa đơn bán
        /// </summary>
        /// <returns>DataTable</returns>
        public DataTable GetByHoaDonBan()
        {
            string strFun = "fn_tblkhachhang_getbyhoadonban";
            try
            {
                DataSet dstblkhachhang = mDataAccess.ExecuteDataSet(strFun, CommandType.StoredProcedure);
                return dstblkhachhang.Tables[0];
            }
            catch
            {
                return null;
            }
        }
        /// <summary>
        /// Hàm lấy tblkhachhang theo mã
        /// </summary>
        /// <returns>Trả về objtblkhachhang </returns>
        public tblkhachhang GetByID(string strid)
        {
            tblkhachhang objtblkhachhang = new tblkhachhang();
            string strFun = "fn_tblkhachhang_getobjbyid";
            try
            {
                NpgsqlParameter[] prmArr = new NpgsqlParameter[1];

                prmArr[0] = new NpgsqlParameter("id", NpgsqlDbType.Varchar);
                prmArr[0].Value = strid;

                DataSet dstblkhachhang = mDataAccess.ExecuteDataSet(strFun, CommandType.StoredProcedure, prmArr);

                if ((dstblkhachhang != null) && (dstblkhachhang.Tables.Count > 0))
                {
                    if (dstblkhachhang.Tables[0].Rows.Count > 0)
                    {
                        DataRow dr = dstblkhachhang.Tables[0].Rows[0];
                        objtblkhachhang.id = dr["id"].ToString();

                        objtblkhachhang.id_capdl = dr["id_capdl"].ToString();

                        objtblkhachhang.tenkh = dr["tenkh"].ToString();

                        objtblkhachhang.diachi = dr["diachi"].ToString();

                        objtblkhachhang.dt = dr["dt"].ToString();

                        objtblkhachhang.ghichu = dr["ghichu"].ToString();

                        objtblkhachhang.tenkhbodau = dr["tenkhbodau"].ToString();


                        return objtblkhachhang;
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
        /// Thêm mới dữ liệu vào bảng: tblkhachhang
        /// </summary>
        /// <param name="obj">objtblkhachhang</param>
        /// <returns>Trả về trắng: Thêm mới thành công; Trả về khác trắng: Thêm mới không thành công</returns>
        public string Insert(tblkhachhang objtblkhachhang)
        {
            string strProc = "fn_tblkhachhang_insert";
            try
            {
                NpgsqlParameter[] prmArr = new NpgsqlParameter[8];

                prmArr[0] = new NpgsqlParameter("id", NpgsqlDbType.Varchar);
                prmArr[0].Value = objtblkhachhang.strid;

                prmArr[1] = new NpgsqlParameter("id_capdl", NpgsqlDbType.Varchar);
                prmArr[1].Value = objtblkhachhang.strid_capdl;

                prmArr[2] = new NpgsqlParameter("tenkh", NpgsqlDbType.Varchar);
                prmArr[2].Value = objtblkhachhang.strtenkh;

                prmArr[3] = new NpgsqlParameter("diachi", NpgsqlDbType.Varchar);
                prmArr[3].Value = objtblkhachhang.strdiachi;

                prmArr[4] = new NpgsqlParameter("dt", NpgsqlDbType.Varchar);
                prmArr[4].Value = objtblkhachhang.strdt;

                prmArr[5] = new NpgsqlParameter("ghichu", NpgsqlDbType.Varchar);
                prmArr[5].Value = objtblkhachhang.strghichu;

                prmArr[6] = new NpgsqlParameter("tenkhbodau", NpgsqlDbType.Varchar);
                prmArr[6].Value = objtblkhachhang.strtenkhbodau;

                prmArr[7] = new NpgsqlParameter("ireturn", NpgsqlDbType.Text);
                prmArr[7].Direction = ParameterDirection.Output;

                mDataAccess.ExecuteQuery(strProc, CommandType.StoredProcedure, prmArr);

                string sKQ = prmArr[7].Value.ToString().Trim();

                if (sKQ.ToUpper().Equals("Add".ToUpper()) == true) return "";
                return "Thêm mới dữ liệu không thành công";
            }
            catch (Exception ex)
            {
                return "Thêm mới dữ liệu không thành công. Chi Tiết: " + ex.Message;
            }
        }
        /// <summary>
        /// Cập nhật dữ liệu vào bảng: tblkhachhang
        /// </summary>
        /// <param name="obj">objtblkhachhang</param>
        /// <returns>Trả về trắng: Cập nhật thành công; Trả về khác trắng: Cập nhật không thành công</returns>
        public string Update(tblkhachhang objtblkhachhang)
        {
            string strProc = "fn_tblkhachhang_Update";
            try
            {
                NpgsqlParameter[] prmArr = new NpgsqlParameter[8];

                prmArr[0] = new NpgsqlParameter("id", NpgsqlDbType.Varchar);
                prmArr[0].Value = objtblkhachhang.strid;

                prmArr[1] = new NpgsqlParameter("id_capdl", NpgsqlDbType.Varchar);
                prmArr[1].Value = objtblkhachhang.strid_capdl;

                prmArr[2] = new NpgsqlParameter("tenkh", NpgsqlDbType.Varchar);
                prmArr[2].Value = objtblkhachhang.strtenkh;

                prmArr[3] = new NpgsqlParameter("diachi", NpgsqlDbType.Varchar);
                prmArr[3].Value = objtblkhachhang.strdiachi;

                prmArr[4] = new NpgsqlParameter("dt", NpgsqlDbType.Varchar);
                prmArr[4].Value = objtblkhachhang.strdt;

                prmArr[5] = new NpgsqlParameter("ghichu", NpgsqlDbType.Varchar);
                prmArr[5].Value = objtblkhachhang.strghichu;

                prmArr[6] = new NpgsqlParameter("tenkhbodau", NpgsqlDbType.Varchar);
                prmArr[6].Value = objtblkhachhang.strtenkhbodau;

                prmArr[7] = new NpgsqlParameter("ireturn", NpgsqlDbType.Text);
                prmArr[7].Direction = ParameterDirection.Output;

                mDataAccess.ExecuteQuery(strProc, CommandType.StoredProcedure, prmArr);
                string sKQ = prmArr[7].Value.ToString().Trim();
                if (sKQ.ToUpper().Equals("Update".ToUpper()) == true) return "";
                return "Cập nhật dữ liệu không thành công";

            }
            catch (Exception ex)
            {
                return "Cập nhật dữ liệu không thành công. Chi Tiết: " + ex.Message;
            }
        }
        /// <summary>
        /// Xóa dữ liệu từ bảng tblkhachhang
        /// </summary>
        /// <returns></returns>
        public string Delete(string strid)
        {
            string strProc = "fn_tblkhachhang_delete";
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
        /// Hàm lấy tất cả dữ liệu trong bảng tblkhachhang
        /// </summary>
        /// <returns>Trả về List<<tblkhachhang>></returns>
        public List<tblkhachhang> GetList()
        {
            List<tblkhachhang> list = new List<tblkhachhang>();
            string strFun = "fn_tblkhachhang_getall";
            try
            {
                DataSet dstblkhachhang = mDataAccess.ExecuteDataSet(strFun, CommandType.StoredProcedure);
                if ((dstblkhachhang != null) && (dstblkhachhang.Tables.Count > 0))
                {
                    for (int i = 0; i < dstblkhachhang.Tables[0].Rows.Count; i++)
                    {
                        tblkhachhang objtblkhachhang = new tblkhachhang();
                        DataRow dr = dstblkhachhang.Tables[0].Rows[i];
                        objtblkhachhang.id = dr["id"].ToString();

                        objtblkhachhang.id_capdl = dr["id_capdl"].ToString();

                        objtblkhachhang.tenkh = dr["tenkh"].ToString();

                        objtblkhachhang.diachi = dr["diachi"].ToString();

                        objtblkhachhang.dt = dr["dt"].ToString();

                        objtblkhachhang.ghichu = dr["ghichu"].ToString();

                        objtblkhachhang.tenkhbodau = dr["tenkhbodau"].ToString();

                        list.Add(objtblkhachhang);
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
        /// Hàm lấy danh sách objtblkhachhang
        /// </summary>
        /// <param name="recperpage">Số lượng bản ghi kiểu integer</param>
        /// <param name="pageindex">Số trang kiểu integer</param>
        /// <returns>Trả về List<<tblkhachhang>></returns>
        public List<tblkhachhang> GetListPaged(int recperpage, int pageindex)
        {
            List<tblkhachhang> list = new List<tblkhachhang>();
            string strFun = "fn_tblkhachhang_getpaged";
            try
            {
                NpgsqlParameter[] prmArr = new NpgsqlParameter[2];
                prmArr[0] = new NpgsqlParameter("recperpage", NpgsqlDbType.Integer);
                prmArr[0].Value = recperpage;
                prmArr[1] = new NpgsqlParameter("pageindex", NpgsqlDbType.Integer);
                prmArr[1].Value = pageindex;
                DataSet dstblkhachhang = mDataAccess.ExecuteDataSet(strFun, CommandType.StoredProcedure, prmArr);
                if ((dstblkhachhang != null) && (dstblkhachhang.Tables.Count > 0))
                {
                    for (int i = 0; i < dstblkhachhang.Tables[0].Rows.Count; i++)
                    {
                        tblkhachhang objtblkhachhang = new tblkhachhang();
                        DataRow dr = dstblkhachhang.Tables[0].Rows[i];
                        objtblkhachhang.id = dr["id"].ToString();

                        objtblkhachhang.id_capdl = dr["id_capdl"].ToString();

                        objtblkhachhang.tenkh = dr["tenkh"].ToString();

                        objtblkhachhang.diachi = dr["diachi"].ToString();

                        objtblkhachhang.dt = dr["dt"].ToString();

                        objtblkhachhang.ghichu = dr["ghichu"].ToString();

                        objtblkhachhang.tenkhbodau = dr["tenkhbodau"].ToString();

                        list.Add(objtblkhachhang);
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
        /// Hàm lấy danh sách objtblkhachhang
        /// </summary>
        /// <param name="recperpage">Số lượng bản ghi kiểu integer</param>
        /// <param name="pageindex">Số trang kiểu integer</param>
        /// <returns>Trả về List<<tblkhachhang>></returns>
        public DataTable GetDataTablePaged(int recperpage, int pageindex)
        {
            string strFun = "fn_tblkhachhang_getpaged";
            try
            {
                NpgsqlParameter[] prmArr = new NpgsqlParameter[2];
                prmArr[0] = new NpgsqlParameter("recperpage", NpgsqlDbType.Integer);
                prmArr[0].Value = recperpage;
                prmArr[1] = new NpgsqlParameter("pageindex", NpgsqlDbType.Integer);
                prmArr[1].Value = pageindex;
                DataSet dstblkhachhang = mDataAccess.ExecuteDataSet(strFun, CommandType.StoredProcedure, prmArr);
                return dstblkhachhang.Tables[0];
            }
            catch
            {
                return null;
            }
        }
        /// <summary>
        /// Hàm tìm kiếm khách hàng
        /// </summary>
        /// <param name="skeyword">Từ khóa type string</param>
        /// <param name="scapdl">Cấp đại lý type string</param>
        /// <returns></returns>
        public DataTable Filter(string skeyword, string scapdl)
        {
            string strFun = "fn_tblkhachhang_filter";
            try
            {
                NpgsqlParameter[] prmArr = new NpgsqlParameter[2];
                prmArr[0] = new NpgsqlParameter("ikeyword", NpgsqlDbType.Text);
                prmArr[0].Value = skeyword;
                prmArr[1] = new NpgsqlParameter("icapdl", NpgsqlDbType.Text);
                prmArr[1].Value = scapdl;
                DataSet dstblkhachhang = mDataAccess.ExecuteDataSet(strFun, CommandType.StoredProcedure, prmArr);
                return dstblkhachhang.Tables[0];
            }
            catch
            {
                return null;
            }
        }
        #endregion
    }
}
