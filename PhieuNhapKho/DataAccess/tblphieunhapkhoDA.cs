using System;
using System.Data;
using System.Collections.Generic;
using System.Text;
using CGCN.Framework;
using Npgsql;
using NpgsqlTypes;
using CGCN.DataAccess;

namespace PhieuNhapKho.DataAccess
{
    /// <summary>
    /// Mô tả thông tin cho bảng tblphieunhapkho
    /// Cung cấp các hàm xử lý, thao tác với bảng tblphieunhapkho
    /// Người tạo (C): tuanva
    /// Ngày khởi tạo: 03/12/2015
    /// </summary>
    public class tblphieunhapkho
    {
        #region Private Variables
        private string strid;
        private string strid_nguoicap;
        private DateTime dtmngaytao;
        private double dbltienthanhtoan;
        private string strnoinhap;
        private string strghichu;
        private double dblchietkhau;
        #endregion
        #region Public Constructor Functions
        public tblphieunhapkho()
        {
            strid = string.Empty;
            strid_nguoicap = string.Empty;
            dtmngaytao = DateTime.Now;
            dbltienthanhtoan = 0;
            strnoinhap = string.Empty;
            strghichu = string.Empty;
            dblchietkhau = 0;
        }
        public tblphieunhapkho(string strid, string strid_nguoicap, DateTime dtmngaytao, double dbltienthanhtoan, string strnoinhap, string strghichu, double dblchietkhau)
        {
            this.strid = strid;
            this.strid_nguoicap = strid_nguoicap;
            this.dtmngaytao = dtmngaytao;
            this.dbltienthanhtoan = dbltienthanhtoan;
            this.strnoinhap = strnoinhap;
            this.strghichu = strghichu;
            this.dblchietkhau = dblchietkhau;
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
        public string id_nguoicap
        {
            get
            {
                return strid_nguoicap;
            }
            set
            {
                strid_nguoicap = value;
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
        public double tienthanhtoan
        {
            get
            {
                return dbltienthanhtoan;
            }
            set
            {
                dbltienthanhtoan = value;
            }
        }
        public string noinhap
        {
            get
            {
                return strnoinhap;
            }
            set
            {
                strnoinhap = value;
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
        public double chietkhau
        {
            get
            {
                return dblchietkhau;
            }
            set
            {
                dblchietkhau = value;
            }
        }
        #endregion

        #region Public Method
        private readonly CGCN.Framework.DataAccessLayerBaseClass mDataAccess = new DataAccessLayerBaseClass(Data.ConnectionString);
        /// <summary>
        /// Lấy toàn bộ dữ liệu từ bảng tblphieunhapkho
        /// </summary>
        /// <returns>DataTable</returns>
        public DataTable GetAll()
        {
            string strFun = "fn_tblphieunhapkho_getall";
            try
            {
                DataSet dstblphieunhapkho = mDataAccess.ExecuteDataSet(strFun, CommandType.StoredProcedure);
                return dstblphieunhapkho.Tables[0];
            }
            catch
            {
                return null;
            }
        }
        /// <summary>
        /// Hàm lấy tblphieunhapkho theo mã
        /// </summary>
        /// <returns>Trả về objtblphieunhapkho </returns>
        public tblphieunhapkho GetByID(string strid)
        {
            tblphieunhapkho objtblphieunhapkho = new tblphieunhapkho();
            string strFun = "fn_tblphieunhapkho_getobjbyid";
            try
            {
                NpgsqlParameter[] prmArr = new NpgsqlParameter[1];
                prmArr[0] = new NpgsqlParameter("id", NpgsqlDbType.Varchar);
                prmArr[0].Value = strid;
                DataSet dstblphieunhapkho = mDataAccess.ExecuteDataSet(strFun, CommandType.StoredProcedure, prmArr);
                if ((dstblphieunhapkho != null) && (dstblphieunhapkho.Tables.Count > 0))
                {
                    if (dstblphieunhapkho.Tables[0].Rows.Count > 0)
                    {
                        DataRow dr = dstblphieunhapkho.Tables[0].Rows[0];
                        objtblphieunhapkho.id = dr["id"].ToString();
                        objtblphieunhapkho.id_nguoicap = dr["id_nguoicap"].ToString();
                        try { objtblphieunhapkho.ngaytao = Convert.ToDateTime(dr["ngaytao"].ToString()); }
                        catch { objtblphieunhapkho.ngaytao = new DateTime(1900, 1, 1); }
                        try { objtblphieunhapkho.tienthanhtoan = Convert.ToDouble("0" + dr["tienthanhtoan"].ToString()); }
                        catch { objtblphieunhapkho.tienthanhtoan = 0; }
                        objtblphieunhapkho.noinhap = dr["noinhap"].ToString();
                        objtblphieunhapkho.ghichu = dr["ghichu"].ToString();
                        try { objtblphieunhapkho.chietkhau = Convert.ToDouble("0" + dr["chietkhau"].ToString()); }
                        catch { objtblphieunhapkho.chietkhau = 0; }
                        return objtblphieunhapkho;
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
        /// Hàm lấy hóa đơn nhập mới nhất theo ngày tạo(chặn cuối) và mã nhà cung cấp
        /// </summary>
        /// <param name="sngaytao">Ngày tạo kiểu string format: yyyy/MM/dd</param>
        /// <param name="sidnhacc">Mã nhà cung cấp kiểu string</param>
        /// <returns>tblphieunhapkho</returns>
        public tblphieunhapkho GetNewFirstByNgayTaovsIDKH(string sngaytao, string sidnhacc)
        {
            tblphieunhapkho objtblphieunhapkho = new tblphieunhapkho();
            string strFun = "fn_tblphieunhapkho_getnewfirst";
            try
            {
                NpgsqlParameter[] prmArr = new NpgsqlParameter[2];
                prmArr[0] = new NpgsqlParameter("ngaytao", NpgsqlDbType.Varchar);
                prmArr[0].Value = sngaytao;
                prmArr[1] = new NpgsqlParameter("iid_nhacc", NpgsqlDbType.Varchar);
                prmArr[1].Value = sidnhacc;
                DataSet dstblhoadonban = mDataAccess.ExecuteDataSet(strFun, CommandType.StoredProcedure, prmArr);
                if ((dstblhoadonban != null) && (dstblhoadonban.Tables.Count > 0))
                {
                    if (dstblhoadonban.Tables[0].Rows.Count > 0)
                    {
                        DataRow dr = dstblhoadonban.Tables[0].Rows[0];
                        objtblphieunhapkho.id = dr["id"].ToString();
                        objtblphieunhapkho.id_nguoicap = dr["id_nguoicap"].ToString();
                        try { objtblphieunhapkho.ngaytao = Convert.ToDateTime(dr["ngaytao"].ToString()); }
                        catch { objtblphieunhapkho.ngaytao = new DateTime(1900, 1, 1); }
                        try { objtblphieunhapkho.tienthanhtoan = Convert.ToDouble("0" + dr["tienthanhtoan"].ToString()); }
                        catch { objtblphieunhapkho.tienthanhtoan = 0; }
                        objtblphieunhapkho.noinhap = dr["noinhap"].ToString();
                        objtblphieunhapkho.ghichu = dr["ghichu"].ToString();
                        try { objtblphieunhapkho.chietkhau = Convert.ToDouble("0" + dr["chietkhau"].ToString()); }
                        catch { objtblphieunhapkho.chietkhau = 0; }
                        return objtblphieunhapkho;
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
        /// Thêm mới dữ liệu vào bảng: tblphieunhapkho
        /// </summary>
        /// <param name="obj">objtblphieunhapkho</param>
        /// <returns>Trả về trắng: Thêm mới thành công; Trả về khác trắng: Thêm mới không thành công</returns>
        public string Insert(tblphieunhapkho objtblphieunhapkho)
        {
            string strProc = "fn_tblphieunhapkho_insert";
            try
            {
                NpgsqlParameter[] prmArr = new NpgsqlParameter[8];
                prmArr[0] = new NpgsqlParameter("id", NpgsqlDbType.Varchar);
                prmArr[0].Value = objtblphieunhapkho.strid;
                prmArr[1] = new NpgsqlParameter("id_nguoicap", NpgsqlDbType.Varchar);
                prmArr[1].Value = objtblphieunhapkho.strid_nguoicap;
                prmArr[2] = new NpgsqlParameter("ngaytao", NpgsqlDbType.Varchar);
                prmArr[2].Value = objtblphieunhapkho.dtmngaytao.ToString("yyyy/MM/dd HH:mm:ss");
                prmArr[3] = new NpgsqlParameter("tienthanhtoan", NpgsqlDbType.Double);
                prmArr[3].Value = objtblphieunhapkho.dbltienthanhtoan;
                prmArr[4] = new NpgsqlParameter("noinhap", NpgsqlDbType.Varchar);
                prmArr[4].Value = objtblphieunhapkho.strnoinhap;
                prmArr[5] = new NpgsqlParameter("ghichu", NpgsqlDbType.Varchar);
                prmArr[5].Value = objtblphieunhapkho.strghichu;
                prmArr[6] = new NpgsqlParameter("chietkhau", NpgsqlDbType.Double);
                prmArr[6].Value = objtblphieunhapkho.chietkhau;
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
        /// Cập nhật dữ liệu vào bảng: tblphieunhapkho
        /// </summary>
        /// <param name="obj">objtblphieunhapkho</param>
        /// <returns>Trả về trắng: Cập nhật thành công; Trả về khác trắng: Cập nhật không thành công</returns>
        public string Update(tblphieunhapkho objtblphieunhapkho)
        {
            string strProc = "fn_tblphieunhapkho_Update";
            try
            {
                NpgsqlParameter[] prmArr = new NpgsqlParameter[8];
                prmArr[0] = new NpgsqlParameter("id", NpgsqlDbType.Varchar);
                prmArr[0].Value = objtblphieunhapkho.strid;
                prmArr[1] = new NpgsqlParameter("id_nguoicap", NpgsqlDbType.Varchar);
                prmArr[1].Value = objtblphieunhapkho.strid_nguoicap;
                prmArr[2] = new NpgsqlParameter("ngaytao", NpgsqlDbType.Varchar);
                prmArr[2].Value = objtblphieunhapkho.dtmngaytao.ToString("yyyy/MM/dd HH:mm:ss");
                prmArr[3] = new NpgsqlParameter("tienthanhtoan", NpgsqlDbType.Double);
                prmArr[3].Value = objtblphieunhapkho.dbltienthanhtoan;
                prmArr[4] = new NpgsqlParameter("noinhap", NpgsqlDbType.Varchar);
                prmArr[4].Value = objtblphieunhapkho.strnoinhap;
                prmArr[5] = new NpgsqlParameter("ghichu", NpgsqlDbType.Varchar);
                prmArr[5].Value = objtblphieunhapkho.strghichu;
                prmArr[6] = new NpgsqlParameter("chietkhau", NpgsqlDbType.Double);
                prmArr[6].Value = objtblphieunhapkho.chietkhau;
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
        /// Xóa dữ liệu từ bảng tblphieunhapkho
        /// </summary>
        /// <returns></returns>
        public string Delete(string strid)
        {
            string strProc = "fn_tblphieunhapkho_delete";
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
        /// Hàm lấy tất cả dữ liệu trong bảng tblphieunhapkho
        /// </summary>
        /// <returns>Trả về List<<tblphieunhapkho>></returns>
        public List<tblphieunhapkho> GetList()
        {
            List<tblphieunhapkho> list = new List<tblphieunhapkho>();
            string strFun = "fn_tblphieunhapkho_getall";
            try
            {
                DataSet dstblphieunhapkho = mDataAccess.ExecuteDataSet(strFun, CommandType.StoredProcedure);
                if ((dstblphieunhapkho != null) && (dstblphieunhapkho.Tables.Count > 0))
                {
                    for (int i = 0; i < dstblphieunhapkho.Tables[0].Rows.Count; i++)
                    {
                        tblphieunhapkho objtblphieunhapkho = new tblphieunhapkho();
                        DataRow dr = dstblphieunhapkho.Tables[0].Rows[i];
                        objtblphieunhapkho.id = dr["id"].ToString();
                        objtblphieunhapkho.id_nguoicap = dr["id_nguoicap"].ToString();
                        try { objtblphieunhapkho.ngaytao = Convert.ToDateTime(dr["ngaytao"].ToString()); }
                        catch { objtblphieunhapkho.ngaytao = new DateTime(1900, 1, 1); }
                        try { objtblphieunhapkho.tienthanhtoan = Convert.ToDouble("0" + dr["tienthanhtoan"].ToString()); }
                        catch { objtblphieunhapkho.tienthanhtoan = 0; }
                        objtblphieunhapkho.noinhap = dr["noinhap"].ToString();
                        objtblphieunhapkho.ghichu = dr["ghichu"].ToString();
                        try { objtblphieunhapkho.chietkhau = Convert.ToDouble("0" + dr["chietkhau"].ToString()); }
                        catch { objtblphieunhapkho.chietkhau = 0; }
                        list.Add(objtblphieunhapkho);
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
        /// Hàm lấy danh sách objtblphieunhapkho
        /// </summary>
        /// <param name="recperpage">Số lượng bản ghi kiểu integer</param>
        /// <param name="pageindex">Số trang kiểu integer</param>
        /// <returns>Trả về List<<tblphieunhapkho>></returns>
        public List<tblphieunhapkho> GetListPaged(int recperpage, int pageindex)
        {
            List<tblphieunhapkho> list = new List<tblphieunhapkho>();
            string strFun = "fn_tblphieunhapkho_getpaged";
            try
            {
                NpgsqlParameter[] prmArr = new NpgsqlParameter[2];
                prmArr[0] = new NpgsqlParameter("recperpage", NpgsqlDbType.Integer);
                prmArr[0].Value = recperpage;
                prmArr[1] = new NpgsqlParameter("pageindex", NpgsqlDbType.Integer);
                prmArr[1].Value = pageindex;
                DataSet dstblphieunhapkho = mDataAccess.ExecuteDataSet(strFun, CommandType.StoredProcedure, prmArr);
                if ((dstblphieunhapkho != null) && (dstblphieunhapkho.Tables.Count > 0))
                {
                    for (int i = 0; i < dstblphieunhapkho.Tables[0].Rows.Count; i++)
                    {
                        tblphieunhapkho objtblphieunhapkho = new tblphieunhapkho();
                        DataRow dr = dstblphieunhapkho.Tables[0].Rows[i];
                        objtblphieunhapkho.id = dr["id"].ToString();
                        objtblphieunhapkho.id_nguoicap = dr["id_nguoicap"].ToString();
                        try { objtblphieunhapkho.ngaytao = Convert.ToDateTime(dr["ngaytao"].ToString()); }
                        catch { objtblphieunhapkho.ngaytao = new DateTime(1900, 1, 1); }
                        try { objtblphieunhapkho.tienthanhtoan = Convert.ToDouble("0" + dr["tienthanhtoan"].ToString()); }
                        catch { objtblphieunhapkho.tienthanhtoan = 0; }
                        objtblphieunhapkho.noinhap = dr["noinhap"].ToString();
                        objtblphieunhapkho.ghichu = dr["ghichu"].ToString();
                        try { objtblphieunhapkho.chietkhau = Convert.ToDouble("0" + dr["chietkhau"].ToString()); }
                        catch { objtblphieunhapkho.chietkhau = 0; }
                        list.Add(objtblphieunhapkho);
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
        /// Hàm lấy danh sách objtblphieunhapkho
        /// </summary>
        /// <param name="recperpage">Số lượng bản ghi kiểu integer</param>
        /// <param name="pageindex">Số trang kiểu integer</param>
        /// <returns>Trả về List<<tblphieunhapkho>></returns>
        public DataTable GetDataTablePaged(int recperpage, int pageindex)
        {
            string strFun = "fn_tblphieunhapkho_getpaged";
            try
            {
                NpgsqlParameter[] prmArr = new NpgsqlParameter[2];
                prmArr[0] = new NpgsqlParameter("recperpage", NpgsqlDbType.Integer);
                prmArr[0].Value = recperpage;
                prmArr[1] = new NpgsqlParameter("pageindex", NpgsqlDbType.Integer);
                prmArr[1].Value = pageindex;
                DataSet dstblphieunhapkho = mDataAccess.ExecuteDataSet(strFun, CommandType.StoredProcedure, prmArr);
                return dstblphieunhapkho.Tables[0];
            }
            catch
            {
                return null;
            }
        }
        /// <summary>
        /// Hàm tìm kiếm phiếu nhập
        /// </summary>
        /// <param name="stungay">Từ ngày kiểu string format: yyyy/MM/dd</param>
        /// <param name="sdenngay">Đến ngày kiểu string format: yyyy/MM/dd</param>
        /// <returns>DataTable</returns>
        public DataTable Filter(string stungay, string sdenngay)
        {
            string strFun = "fn_tblphieunhapkho_fillter";
            try
            {
                NpgsqlParameter[] prmArr = new NpgsqlParameter[2];
                prmArr[0] = new NpgsqlParameter("tungay", NpgsqlDbType.Varchar);
                prmArr[0].Value = stungay;
                prmArr[1] = new NpgsqlParameter("dengay", NpgsqlDbType.Varchar);
                prmArr[1].Value = sdenngay;
                DataSet ds = mDataAccess.ExecuteDataSet(strFun, CommandType.StoredProcedure, prmArr);
                return ds.Tables[0];
            }
            catch
            {
                return null;
            }
        }
        /// <summary>
        /// Hàm tìm kiếu phiếu nhập kho
        /// </summary>
        /// <param name="skeyword">Từ khóa kiểu string</param>
        /// <param name="stungay">Từ ngày kiểu string format: yyyy/MM/dd</param>
        /// <param name="sdenngay">Đến ngày kiểu string format: yyyy/MM/dd</param>
        /// <returns>DataTable</returns>
        public DataTable Filter(string skeyword,string stungay, string sdenngay)
        {
            string strFun = "fn_tblphieunhapkho_fillter";
            try
            {
                NpgsqlParameter[] prmArr = new NpgsqlParameter[3];
                prmArr[0] = new NpgsqlParameter("keyword", NpgsqlDbType.Varchar);
                prmArr[0].Value = skeyword;
                prmArr[1] = new NpgsqlParameter("tungay", NpgsqlDbType.Varchar);
                prmArr[1].Value = stungay;
                prmArr[2] = new NpgsqlParameter("dengay", NpgsqlDbType.Varchar);
                prmArr[2].Value = sdenngay;
                DataSet ds = mDataAccess.ExecuteDataSet(strFun, CommandType.StoredProcedure, prmArr);
                return ds.Tables[0];
            }
            catch
            {
                return null;
            }
        }
        /// <summary>
        /// Hàm lấy tiền còn nợ của các toa trước
        /// </summary>
        /// <param name="dtngaytao">Ngày tạo hóa đơn kiểu DateTime</param>
        /// <returns>double: Số tiền còn nợ của các toa trước</returns>
        public double GetTienConNo(string sidnhacc, DateTime dtngaytao)
        {
            string strProc = "fn_tblphieunhapkho_gettienconno";
            try
            {
                NpgsqlParameter[] prmArr = new NpgsqlParameter[3];
                prmArr[0] = new NpgsqlParameter("idnhacc", NpgsqlDbType.Varchar);
                prmArr[0].Value = sidnhacc;
                prmArr[1] = new NpgsqlParameter("ngaytao", NpgsqlDbType.Varchar);
                prmArr[1].Value = dtngaytao.ToString("yyyy/MM/dd HH:mm:ss");
                prmArr[2] = new NpgsqlParameter("ireturn", NpgsqlDbType.Text);
                prmArr[2].Direction = ParameterDirection.Output;
                mDataAccess.ExecuteQuery(strProc, CommandType.StoredProcedure, prmArr);
                string sKQ = prmArr[2].Value.ToString().Trim();
                return Convert.ToDouble(sKQ);
            }
            catch
            {
                return 0;
            }
        }
        /// <summary>
        /// Hàm kiểm tra đã tồn tại phiếu nhập theo mã và ngày tạo
        /// </summary>
        /// <param name="sid">Mã phiếu nhập kiểu string (Guid)</param>
        /// <param name="dtngaytao">Ngày tạo kiểu DateTime</param>
        /// <returns>bool: False-Không tồn tại;True-Có tồn tại</returns>
        public bool CheckExit(string sid, DateTime dtngaytao)
        {
            string strProc = "fn_tblphieunhapkho_checkexit";
            try
            {
                NpgsqlParameter[] prmArr = new NpgsqlParameter[3];
                prmArr[0] = new NpgsqlParameter("id", NpgsqlDbType.Varchar);
                prmArr[0].Value = sid;
                prmArr[1] = new NpgsqlParameter("ngaytao", NpgsqlDbType.Varchar);
                prmArr[1].Value = dtngaytao.ToString("yyyy/MM/dd HH:mm:ss");
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
