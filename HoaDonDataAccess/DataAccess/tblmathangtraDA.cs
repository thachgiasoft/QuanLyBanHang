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
    /// Mô tả thông tin cho bảng tblmathangtra
    /// Cung cấp các hàm xử lý, thao tác với bảng tblmathangtra
    /// Người tạo (C): tuanva
    /// Ngày khởi tạo: 16/10/2015
    /// </summary>
    public class tblmathangtra
    {
        #region Private Variables
        private string strid;
        private string strid_hoadon;
        private string strid_mathang;
        private int intsoluong;
        private double dblgianhaplai;
        private string strghichu;
        private DateTime dtmngaytao;
        #endregion

        #region Public Constructor Functions
        public tblmathangtra()
        {
            strid = string.Empty;
            strid_hoadon = string.Empty;
            strid_mathang = string.Empty;
            intsoluong = 0;
            dblgianhaplai = 0;
            strghichu = string.Empty;
            dtmngaytao = DateTime.Now;

        }

        public tblmathangtra(string strid, string strid_hoadon, string strid_mathang, int intsoluong, double dblgianhaplai, string strghichu, DateTime dtmngaytao)
        {
            this.strid = strid;
            this.strid_hoadon = strid_hoadon;
            this.strid_mathang = strid_mathang;
            this.intsoluong = intsoluong;
            this.dblgianhaplai = dblgianhaplai;
            this.strghichu = strghichu;
            this.dtmngaytao = dtmngaytao;
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

        public string id_hoadon
        {
            get
            {
                return strid_hoadon;
            }
            set
            {
                strid_hoadon = value;
            }
        }

        public string id_mathang
        {
            get
            {
                return strid_mathang;
            }
            set
            {
                strid_mathang = value;
            }
        }

        public int soluong
        {
            get
            {
                return intsoluong;
            }
            set
            {
                intsoluong = value;
            }
        }

        public double gianhaplai
        {
            get
            {
                return dblgianhaplai;
            }
            set
            {
                dblgianhaplai = value;
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
        #endregion

        #region Public Method
        private readonly DataAccessLayerBaseClass mDataAccess = new DataAccessLayerBaseClass(Data.ConnectionString);
        /// <summary>
        /// Lấy toàn bộ dữ liệu từ bảng tblmathangtra
        /// </summary>
        /// <returns>DataTable</returns>
        public DataTable GetAll()
        {
            string strFun = "fn_tblmathangtra_getall";
            try
            {
                DataSet dstblmathangtra = mDataAccess.ExecuteDataSet(strFun, CommandType.StoredProcedure);
                return dstblmathangtra.Tables[0];
            }
            catch
            {
                return null;
            }
        }
        /// <summary>
        /// Hàm lấy tblmathangtra theo mã
        /// </summary>
        /// <returns>Trả về objtblmathangtra </returns>
        public tblmathangtra GetByID(string strid)
        {
            tblmathangtra objtblmathangtra = new tblmathangtra();
            string strFun = "fn_tblmathangtra_getobjbyid";
            try
            {
                NpgsqlParameter[] prmArr = new NpgsqlParameter[1];

                prmArr[0] = new NpgsqlParameter("id", NpgsqlDbType.Varchar);
                prmArr[0].Value = strid;

                DataSet dstblmathangtra = mDataAccess.ExecuteDataSet(strFun, CommandType.StoredProcedure, prmArr);

                if ((dstblmathangtra != null) && (dstblmathangtra.Tables.Count > 0))
                {
                    if (dstblmathangtra.Tables[0].Rows.Count > 0)
                    {
                        DataRow dr = dstblmathangtra.Tables[0].Rows[0];
                        objtblmathangtra.id = dr["id"].ToString();

                        objtblmathangtra.id_hoadon = dr["id_hoadon"].ToString();

                        objtblmathangtra.id_mathang = dr["id_mathang"].ToString();

                        try { objtblmathangtra.soluong = Convert.ToInt32("0" + dr["soluong"].ToString()); }
                        catch { objtblmathangtra.soluong = 0; }

                        try { objtblmathangtra.gianhaplai = Convert.ToDouble("0" + dr["gianhaplai"].ToString()); }
                        catch { objtblmathangtra.gianhaplai = 0; }

                        objtblmathangtra.ghichu = dr["ghichu"].ToString();

                        try { objtblmathangtra.ngaytao = Convert.ToDateTime(dr["ngaytao"].ToString()); }
                        catch { objtblmathangtra.ngaytao = new DateTime(1900, 1, 1); }


                        return objtblmathangtra;
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
        /// Hàm lấy danh sách mặt hàng trả theo mã hóa đơn
        /// </summary>
        /// <param name="stridhd">Mã hóa đơn trả kiểu string</param>
        /// <returns>DataTable</returns>
        public DataTable GetByHDID(string stridhd)
        {
            string strFun = "fn_tblmathangtra_getbyidhd";
            try
            {
                NpgsqlParameter[] prmArr = new NpgsqlParameter[1];
                prmArr[0] = new NpgsqlParameter("idhd", NpgsqlDbType.Varchar);
                prmArr[0].Value = stridhd;
                DataSet dstblmathangban = mDataAccess.ExecuteDataSet(strFun, CommandType.StoredProcedure, prmArr);
                return dstblmathangban.Tables[0];
            }
            catch
            {
                return null;
            }
        }
        /// <summary>
        /// Thêm mới dữ liệu vào bảng: tblmathangtra
        /// </summary>
        /// <param name="obj">objtblmathangtra</param>
        /// <returns>Trả về trắng: Thêm mới thành công; Trả về khác trắng: Thêm mới không thành công</returns>
        public string Insert(tblmathangtra objtblmathangtra)
        {
            string strProc = "fn_tblmathangtra_insert";
            try
            {
                NpgsqlParameter[] prmArr = new NpgsqlParameter[7];
                prmArr[0] = new NpgsqlParameter("id", NpgsqlDbType.Varchar);
                prmArr[0].Value = objtblmathangtra.strid;
                prmArr[1] = new NpgsqlParameter("id_hoadon", NpgsqlDbType.Varchar);
                prmArr[1].Value = objtblmathangtra.strid_hoadon;
                prmArr[2] = new NpgsqlParameter("id_mathang", NpgsqlDbType.Varchar);
                prmArr[2].Value = objtblmathangtra.strid_mathang;
                prmArr[3] = new NpgsqlParameter("soluong", NpgsqlDbType.Integer);
                prmArr[3].Value = objtblmathangtra.intsoluong;
                prmArr[4] = new NpgsqlParameter("gianhaplai", NpgsqlDbType.Double);
                prmArr[4].Value = objtblmathangtra.dblgianhaplai;
                prmArr[5] = new NpgsqlParameter("ghichu", NpgsqlDbType.Varchar);
                prmArr[5].Value = objtblmathangtra.strghichu;
                prmArr[6] = new NpgsqlParameter("ireturn", NpgsqlDbType.Text);
                prmArr[6].Direction = ParameterDirection.Output;
                mDataAccess.ExecuteQuery(strProc, CommandType.StoredProcedure, prmArr);
                string sKQ = prmArr[6].Value.ToString().Trim();
                if (sKQ.ToUpper().Equals("Add".ToUpper()) == true) return "";
                return "Thêm mới dữ liệu không thành công";
            }
            catch (Exception ex)
            {
                return "Thêm mới dữ liệu không thành công. Chi Tiết: " + ex.Message;
            }
        }
        /// <summary>
        /// Cập nhật dữ liệu vào bảng: tblmathangtra
        /// </summary>
        /// <param name="obj">objtblmathangtra</param>
        /// <returns>Trả về trắng: Cập nhật thành công; Trả về khác trắng: Cập nhật không thành công</returns>
        public string Update(tblmathangtra objtblmathangtra)
        {
            string strProc = "fn_tblmathangtra_Update";
            try
            {
                NpgsqlParameter[] prmArr = new NpgsqlParameter[7];
                prmArr[0] = new NpgsqlParameter("id", NpgsqlDbType.Varchar);
                prmArr[0].Value = objtblmathangtra.strid;
                prmArr[1] = new NpgsqlParameter("id_hoadon", NpgsqlDbType.Varchar);
                prmArr[1].Value = objtblmathangtra.strid_hoadon;
                prmArr[2] = new NpgsqlParameter("id_mathang", NpgsqlDbType.Varchar);
                prmArr[2].Value = objtblmathangtra.strid_mathang;
                prmArr[3] = new NpgsqlParameter("soluong", NpgsqlDbType.Integer);
                prmArr[3].Value = objtblmathangtra.intsoluong;
                prmArr[4] = new NpgsqlParameter("gianhaplai", NpgsqlDbType.Double);
                prmArr[4].Value = objtblmathangtra.dblgianhaplai;
                prmArr[5] = new NpgsqlParameter("ghichu", NpgsqlDbType.Varchar);
                prmArr[5].Value = objtblmathangtra.strghichu;
                prmArr[6] = new NpgsqlParameter("ireturn", NpgsqlDbType.Text);
                prmArr[6].Direction = ParameterDirection.Output;
                mDataAccess.ExecuteQuery(strProc, CommandType.StoredProcedure, prmArr);
                string sKQ = prmArr[6].Value.ToString().Trim();
                if (sKQ.ToUpper().Equals("Update".ToUpper()) == true) return "";
                return "Cập nhật dữ liệu không thành công";

            }
            catch (Exception ex)
            {
                return "Cập nhật dữ liệu không thành công. Chi Tiết: " + ex.Message;
            }
        }
        /// <summary>
        /// Xóa dữ liệu từ bảng tblmathangtra
        /// </summary>
        /// <returns></returns>
        public string Delete(string strid)
        {
            string strProc = "fn_tblmathangtra_delete";
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
        /// Hàm lấy tất cả dữ liệu trong bảng tblmathangtra
        /// </summary>
        /// <returns>Trả về List<<tblmathangtra>></returns>
        public List<tblmathangtra> GetList()
        {
            List<tblmathangtra> list = new List<tblmathangtra>();
            string strFun = "fn_tblmathangtra_getall";
            try
            {
                DataSet dstblmathangtra = mDataAccess.ExecuteDataSet(strFun, CommandType.StoredProcedure);
                if ((dstblmathangtra != null) && (dstblmathangtra.Tables.Count > 0))
                {
                    for (int i = 0; i < dstblmathangtra.Tables[0].Rows.Count; i++)
                    {
                        tblmathangtra objtblmathangtra = new tblmathangtra();
                        DataRow dr = dstblmathangtra.Tables[0].Rows[i];
                        objtblmathangtra.id = dr["id"].ToString();

                        objtblmathangtra.id_hoadon = dr["id_hoadon"].ToString();

                        objtblmathangtra.id_mathang = dr["id_mathang"].ToString();

                        try { objtblmathangtra.soluong = Convert.ToInt32("0" + dr["soluong"].ToString()); }
                        catch { objtblmathangtra.soluong = 0; }

                        try { objtblmathangtra.gianhaplai = Convert.ToDouble("0" + dr["gianhaplai"].ToString()); }
                        catch { objtblmathangtra.gianhaplai = 0; }

                        objtblmathangtra.ghichu = dr["ghichu"].ToString();

                        try { objtblmathangtra.ngaytao = Convert.ToDateTime(dr["ngaytao"].ToString()); }
                        catch { objtblmathangtra.ngaytao = new DateTime(1900, 1, 1); }

                        list.Add(objtblmathangtra);
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
        /// Hàm lấy danh sách objtblmathangtra
        /// </summary>
        /// <param name="recperpage">Số lượng bản ghi kiểu integer</param>
        /// <param name="pageindex">Số trang kiểu integer</param>
        /// <returns>Trả về List<<tblmathangtra>></returns>
        public List<tblmathangtra> GetListPaged(int recperpage, int pageindex)
        {
            List<tblmathangtra> list = new List<tblmathangtra>();
            string strFun = "fn_tblmathangtra_getpaged";
            try
            {
                NpgsqlParameter[] prmArr = new NpgsqlParameter[2];
                prmArr[0] = new NpgsqlParameter("recperpage", NpgsqlDbType.Integer);
                prmArr[0].Value = recperpage;
                prmArr[1] = new NpgsqlParameter("pageindex", NpgsqlDbType.Integer);
                prmArr[1].Value = pageindex;
                DataSet dstblmathangtra = mDataAccess.ExecuteDataSet(strFun, CommandType.StoredProcedure, prmArr);
                if ((dstblmathangtra != null) && (dstblmathangtra.Tables.Count > 0))
                {
                    for (int i = 0; i < dstblmathangtra.Tables[0].Rows.Count; i++)
                    {
                        tblmathangtra objtblmathangtra = new tblmathangtra();
                        DataRow dr = dstblmathangtra.Tables[0].Rows[i];
                        objtblmathangtra.id = dr["id"].ToString();

                        objtblmathangtra.id_hoadon = dr["id_hoadon"].ToString();

                        objtblmathangtra.id_mathang = dr["id_mathang"].ToString();

                        try { objtblmathangtra.soluong = Convert.ToInt32("0" + dr["soluong"].ToString()); }
                        catch { objtblmathangtra.soluong = 0; }

                        try { objtblmathangtra.gianhaplai = Convert.ToDouble("0" + dr["gianhaplai"].ToString()); }
                        catch { objtblmathangtra.gianhaplai = 0; }

                        objtblmathangtra.ghichu = dr["ghichu"].ToString();

                        try { objtblmathangtra.ngaytao = Convert.ToDateTime(dr["ngaytao"].ToString()); }
                        catch { objtblmathangtra.ngaytao = new DateTime(1900, 1, 1); }

                        list.Add(objtblmathangtra);
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
        /// Hàm lấy danh sách objtblmathangtra
        /// </summary>
        /// <param name="recperpage">Số lượng bản ghi kiểu integer</param>
        /// <param name="pageindex">Số trang kiểu integer</param>
        /// <returns>Trả về List<<tblmathangtra>></returns>
        public DataTable GetDataTablePaged(int recperpage, int pageindex)
        {
            string strFun = "fn_tblmathangtra_getpaged";
            try
            {
                NpgsqlParameter[] prmArr = new NpgsqlParameter[2];
                prmArr[0] = new NpgsqlParameter("recperpage", NpgsqlDbType.Integer);
                prmArr[0].Value = recperpage;
                prmArr[1] = new NpgsqlParameter("pageindex", NpgsqlDbType.Integer);
                prmArr[1].Value = pageindex;
                DataSet dstblmathangtra = mDataAccess.ExecuteDataSet(strFun, CommandType.StoredProcedure, prmArr);
                return dstblmathangtra.Tables[0];
            }
            catch
            {
                return null;
            }
        }
        #endregion
    }
}