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
     /// Mô tả thông tin cho bảng tblhoadonban
     /// Cung cấp các hàm xử lý, thao tác với bảng tblhoadonban
     /// Người tạo (C): 
     /// Ngày khởi tạo: 16/08/2015
     /// </summary>
    public class tblhoadonban
    {
        #region Private Variables
        private string strid;
        private string strid_khachhang;
        private double dbltienthanhtoan;
        private string strghichu;
        private double dblchietkhau;
        private DateTime dtmngaytao;
        private string struserid;
        #endregion

        #region Public Constructor Functions
        public tblhoadonban()
        {
            strid = string.Empty;
            strid_khachhang = string.Empty;
            dbltienthanhtoan = 0;
            strghichu = string.Empty;
            dblchietkhau = 0;
            dtmngaytao = DateTime.Now;
            struserid = string.Empty;

        }

        public tblhoadonban(string strid, string strid_khachhang, double dbltienthanhtoan, string strghichu, double dblchietkhau, DateTime dtmngaytao, string struserid)
        {
            this.strid = strid;
            this.strid_khachhang = strid_khachhang;
            this.dbltienthanhtoan = dbltienthanhtoan;
            this.strghichu = strghichu;
            this.dblchietkhau = dblchietkhau;
            this.dtmngaytao = dtmngaytao;
            this.struserid = struserid;
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

        public string userid
        {
            get
            {
                return struserid;
            }
            set
            {
                struserid = value;
            }
        }
        #endregion

        #region Public Method
        private readonly DataAccessLayerBaseClass mDataAccess = new DataAccessLayerBaseClass(Data.ConnectionString);
        /// <summary>
        /// Lấy toàn bộ dữ liệu từ bảng tblhoadonban
        /// </summary>
        /// <returns>DataTable</returns>
        public DataTable GetAll()
        {
            string strFun = "fn_tblhoadonban_getall";
            try
            {
                DataSet dstblhoadonban = mDataAccess.ExecuteDataSet(strFun, CommandType.StoredProcedure);
                return dstblhoadonban.Tables[0];
            }
            catch
            {
                return null;
            }
        }
        /// <summary>
        /// Hàm lấy tblhoadonban theo mã
        /// </summary>
        /// <returns>Trả về objtblhoadonban </returns>
        public tblhoadonban GetByID(string strid)
        {
            tblhoadonban objtblhoadonban = new tblhoadonban();
            string strFun = "fn_tblhoadonban_getobjbyid";
            try
            {
                NpgsqlParameter[] prmArr = new NpgsqlParameter[1];

                prmArr[0] = new NpgsqlParameter("id", NpgsqlDbType.Varchar);
                prmArr[0].Value = strid;

                DataSet dstblhoadonban = mDataAccess.ExecuteDataSet(strFun, CommandType.StoredProcedure, prmArr);

                if ((dstblhoadonban != null) && (dstblhoadonban.Tables.Count > 0))
                {
                    if (dstblhoadonban.Tables[0].Rows.Count > 0)
                    {
                        DataRow dr = dstblhoadonban.Tables[0].Rows[0];
                        objtblhoadonban.id = dr["id"].ToString();

                        objtblhoadonban.id_khachhang = dr["id_khachhang"].ToString();

                        try { objtblhoadonban.tienthanhtoan = Convert.ToDouble("0" + dr["tienthanhtoan"].ToString());}
                        catch { objtblhoadonban.tienthanhtoan = 0; }

                        objtblhoadonban.ghichu = dr["ghichu"].ToString();

                        try { objtblhoadonban.chietkhau = Convert.ToDouble("0" + dr["chietkhau"].ToString());}
                        catch { objtblhoadonban.chietkhau = 0; }

                        try { objtblhoadonban.ngaytao = Convert.ToDateTime(dr["ngaytao"].ToString());}
                        catch { objtblhoadonban.ngaytao = new DateTime(1900, 1, 1); }

                        objtblhoadonban.userid = dr["userid"].ToString();


                        return objtblhoadonban;
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
        /// Hàm lấy hóa đơn mới nhất theo ngày tạo(chặn cuối) và mã khách hàng
        /// </summary>
        /// <param name="sngaytao">Ngày tạo kiểu string format: yyyy/MM/dd</param>
        /// <param name="sidkh">Mã khách hàng kiểu string</param>
        /// <returns>tblhoadonban</returns>
        public tblhoadonban GetNewFirstByNgayTaovsIDKH(string sngaytao,string sidkh)
        {
            tblhoadonban objtblhoadonban = new tblhoadonban();
            string strFun = "fn_tblhoadonban_getnewfirst";
            try
            {
                NpgsqlParameter[] prmArr = new NpgsqlParameter[2];
                prmArr[0] = new NpgsqlParameter("ngaytao", NpgsqlDbType.Varchar);
                prmArr[0].Value = sngaytao;
                prmArr[1] = new NpgsqlParameter("id_khachhang", NpgsqlDbType.Varchar);
                prmArr[1].Value = sidkh;
                DataSet dstblhoadonban = mDataAccess.ExecuteDataSet(strFun, CommandType.StoredProcedure, prmArr);
                if ((dstblhoadonban != null) && (dstblhoadonban.Tables.Count > 0))
                {
                    if (dstblhoadonban.Tables[0].Rows.Count > 0)
                    {
                        DataRow dr = dstblhoadonban.Tables[0].Rows[0];
                        objtblhoadonban.id = dr["id"].ToString();
                        objtblhoadonban.id_khachhang = dr["id_khachhang"].ToString();
                        try { objtblhoadonban.tienthanhtoan = Convert.ToDouble("0" + dr["tienthanhtoan"].ToString()); }
                        catch { objtblhoadonban.tienthanhtoan = 0; }
                        objtblhoadonban.ghichu = dr["ghichu"].ToString();
                        try { objtblhoadonban.chietkhau = Convert.ToDouble("0" + dr["chietkhau"].ToString()); }
                        catch { objtblhoadonban.chietkhau = 0; }
                        try { objtblhoadonban.ngaytao = Convert.ToDateTime(dr["ngaytao"].ToString()); }
                        catch { objtblhoadonban.ngaytao = new DateTime(1900, 1, 1); }
                        objtblhoadonban.userid = dr["userid"].ToString();
                        return objtblhoadonban;
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
        /// Hàm kiểm tra đã tồn tại hóa đơn theo mã và ngày tạo
        /// </summary>
        /// <param name="sid">Mã hóa đơn kiểu string (Guid)</param>
        /// <param name="dtngaytao">Ngày tạo kiểu DateTime</param>
        /// <returns>bool: False-Không tồn tại;True-Có tồn tại</returns>
        public bool CheckExit(string sid, DateTime dtngaytao)
        {
            string strProc = "fn_tblhoadonban_checkexit";
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
        /// <summary>
        /// Thêm mới dữ liệu vào bảng: tblhoadonban
        /// </summary>
        /// <param name="obj">objtblhoadonban</param>
        /// <returns>Trả về trắng: Thêm mới thành công; Trả về khác trắng: Thêm mới không thành công</returns>
        public string Insert(tblhoadonban objtblhoadonban)
        {
            string strProc = "fn_tblhoadonban_insert";
            try
            {
                NpgsqlParameter[] prmArr = new NpgsqlParameter[8];
                prmArr[0] = new NpgsqlParameter("id", NpgsqlDbType.Varchar);
                prmArr[0].Value = objtblhoadonban.strid;
                prmArr[1] = new NpgsqlParameter("id_khachhang", NpgsqlDbType.Varchar);
                prmArr[1].Value = objtblhoadonban.strid_khachhang;
                prmArr[2] = new NpgsqlParameter("tienthanhtoan", NpgsqlDbType.Double);
                prmArr[2].Value = objtblhoadonban.dbltienthanhtoan;
                prmArr[3] = new NpgsqlParameter("ghichu", NpgsqlDbType.Varchar);
                prmArr[3].Value = objtblhoadonban.strghichu;
                prmArr[4] = new NpgsqlParameter("chietkhau", NpgsqlDbType.Double);
                prmArr[4].Value = objtblhoadonban.dblchietkhau;
                prmArr[5] = new NpgsqlParameter("ngaytao", NpgsqlDbType.Varchar);
                prmArr[5].Value = objtblhoadonban.ngaytao.ToString("yyyy/MM/dd HH:mm:ss");
                prmArr[6] = new NpgsqlParameter("userid", NpgsqlDbType.Varchar);
                prmArr[6].Value = objtblhoadonban.struserid;
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
        /// Cập nhật dữ liệu vào bảng: tblhoadonban
        /// </summary>
        /// <param name="obj">objtblhoadonban</param>
        /// <returns>Trả về trắng: Cập nhật thành công; Trả về khác trắng: Cập nhật không thành công</returns>
        public string Update(tblhoadonban objtblhoadonban)
        {
            string strProc = "fn_tblhoadonban_Update";
            try
            {
                NpgsqlParameter[] prmArr = new NpgsqlParameter[7];
                prmArr[0] = new NpgsqlParameter("id", NpgsqlDbType.Varchar);
                prmArr[0].Value = objtblhoadonban.strid;
                prmArr[1] = new NpgsqlParameter("id_khachhang", NpgsqlDbType.Varchar);
                prmArr[1].Value = objtblhoadonban.strid_khachhang;
                prmArr[2] = new NpgsqlParameter("tienthanhtoan", NpgsqlDbType.Double);
                prmArr[2].Value = objtblhoadonban.dbltienthanhtoan;
                prmArr[3] = new NpgsqlParameter("ghichu", NpgsqlDbType.Varchar);
                prmArr[3].Value = objtblhoadonban.strghichu;
                prmArr[4] = new NpgsqlParameter("chietkhau", NpgsqlDbType.Double);
                prmArr[4].Value = objtblhoadonban.dblchietkhau;
                prmArr[5] = new NpgsqlParameter("userid", NpgsqlDbType.Varchar);
                prmArr[5].Value = objtblhoadonban.struserid;
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
        /// Xóa dữ liệu từ bảng tblhoadonban
        /// </summary>
        /// <returns></returns>
        public string Delete(string strid)
        {
            string strProc = "fn_tblhoadonban_delete";
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
        /// Hàm lấy tất cả dữ liệu trong bảng tblhoadonban
        /// </summary>
        /// <returns>Trả về List<<tblhoadonban>></returns>
        public List<tblhoadonban> GetList()
        {
          List<tblhoadonban> list = new List<tblhoadonban>();
          string strFun = "fn_tblhoadonban_getall";
          try
          {
              DataSet dstblhoadonban = mDataAccess.ExecuteDataSet(strFun, CommandType.StoredProcedure);
              if ((dstblhoadonban != null) && (dstblhoadonban.Tables.Count > 0))
              {
                  for (int i = 0; i < dstblhoadonban.Tables[0].Rows.Count; i++)
                  {
                        tblhoadonban objtblhoadonban = new tblhoadonban();
                        DataRow dr = dstblhoadonban.Tables[0].Rows[i];
                        objtblhoadonban.id = dr["id"].ToString();

                        objtblhoadonban.id_khachhang = dr["id_khachhang"].ToString();

                        try { objtblhoadonban.tienthanhtoan = Convert.ToDouble("0" + dr["tienthanhtoan"].ToString());}
                        catch { objtblhoadonban.tienthanhtoan = 0; }

                        objtblhoadonban.ghichu = dr["ghichu"].ToString();

                        try { objtblhoadonban.chietkhau = Convert.ToDouble("0" + dr["chietkhau"].ToString());}
                        catch { objtblhoadonban.chietkhau = 0; }

                        try { objtblhoadonban.ngaytao = Convert.ToDateTime(dr["ngaytao"].ToString());}
                        catch { objtblhoadonban.ngaytao = new DateTime(1900, 1, 1); }

                        objtblhoadonban.userid = dr["userid"].ToString();

                        list.Add(objtblhoadonban);
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
        /// Hàm lấy danh sách objtblhoadonban
        /// </summary>
        /// <param name="recperpage">Số lượng bản ghi kiểu integer</param>
        /// <param name="pageindex">Số trang kiểu integer</param>
        /// <returns>Trả về List<<tblhoadonban>></returns>
        public List<tblhoadonban> GetListPaged(int recperpage, int pageindex)
        {
          List<tblhoadonban> list = new List<tblhoadonban>();
          string strFun = "fn_tblhoadonban_getpaged";
          try
          {
              NpgsqlParameter[] prmArr = new NpgsqlParameter[2];
              prmArr[0] = new NpgsqlParameter("recperpage", NpgsqlDbType.Integer);
              prmArr[0].Value = recperpage;
              prmArr[1] = new NpgsqlParameter("pageindex", NpgsqlDbType.Integer);
              prmArr[1].Value = pageindex;
              DataSet dstblhoadonban = mDataAccess.ExecuteDataSet(strFun, CommandType.StoredProcedure,prmArr);
              if ((dstblhoadonban != null) && (dstblhoadonban.Tables.Count > 0))
              {
                  for (int i = 0; i < dstblhoadonban.Tables[0].Rows.Count; i++)
                  {
                        tblhoadonban objtblhoadonban = new tblhoadonban();
                        DataRow dr = dstblhoadonban.Tables[0].Rows[i];
                        objtblhoadonban.id = dr["id"].ToString();

                        objtblhoadonban.id_khachhang = dr["id_khachhang"].ToString();

                        try { objtblhoadonban.tienthanhtoan = Convert.ToDouble("0" + dr["tienthanhtoan"].ToString());}
                        catch { objtblhoadonban.tienthanhtoan = 0; }

                        objtblhoadonban.ghichu = dr["ghichu"].ToString();

                        try { objtblhoadonban.chietkhau = Convert.ToDouble("0" + dr["chietkhau"].ToString());}
                        catch { objtblhoadonban.chietkhau = 0; }

                        try { objtblhoadonban.ngaytao = Convert.ToDateTime(dr["ngaytao"].ToString());}
                        catch { objtblhoadonban.ngaytao = new DateTime(1900, 1, 1); }

                        objtblhoadonban.userid = dr["userid"].ToString();

                        list.Add(objtblhoadonban);
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
        /// Hàm lấy danh sách objtblhoadonban
        /// </summary>
        /// <param name="recperpage">Số lượng bản ghi kiểu integer</param>
        /// <param name="pageindex">Số trang kiểu integer</param>
        /// <returns>Trả về List<<tblhoadonban>></returns>
        public DataTable GetDataTablePaged(int recperpage, int pageindex)
        {
          string strFun = "fn_tblhoadonban_getpaged";
          try
          {
              NpgsqlParameter[] prmArr = new NpgsqlParameter[2];
              prmArr[0] = new NpgsqlParameter("recperpage", NpgsqlDbType.Integer);
              prmArr[0].Value = recperpage;
              prmArr[1] = new NpgsqlParameter("pageindex", NpgsqlDbType.Integer);
              prmArr[1].Value = pageindex;
              DataSet dstblhoadonban = mDataAccess.ExecuteDataSet(strFun, CommandType.StoredProcedure,prmArr);
              return dstblhoadonban.Tables[0];
          }
          catch
          {
              return null;
          }
        }
        /// <summary>
        /// Hàm tìm kiếm hóa đơn
        /// </summary>
        /// <param name="skeyword">Từ khóa (Tên khách hàng)</param>
        /// <param name="stungay">Từ ngày kiểu string format: yyyy/MM/dd</param>
        /// <param name="sdenngay">Đến ngày kiểu string format: yyyy/MM/dd</param>
        /// <returns>DataTable</returns>
        public DataTable Filter(string skeyword,string stungay,string sdenngay)
        {
            tblhoadonban objtblhoadonban = new tblhoadonban();
            string strFun = "fn_tblhoadonban_filter";
            try
            {
                NpgsqlParameter[] prmArr = new NpgsqlParameter[3];
                prmArr[0] = new NpgsqlParameter("keyword", NpgsqlDbType.Varchar);
                prmArr[0].Value = skeyword;
                prmArr[1] = new NpgsqlParameter("tungay", NpgsqlDbType.Varchar);
                prmArr[1].Value = stungay;
                prmArr[2] = new NpgsqlParameter("dengay", NpgsqlDbType.Varchar);
                prmArr[2].Value = sdenngay;
                DataSet dstblhoadonban = mDataAccess.ExecuteDataSet(strFun, CommandType.StoredProcedure, prmArr);
                return dstblhoadonban.Tables[0];
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
        public double GetTienConNo(string sidkh,DateTime dtngaytao)
        {
            string strProc = "fn_tblhoadonban_gettienconno";
            try
            {
                NpgsqlParameter[] prmArr = new NpgsqlParameter[3];
                prmArr[0] = new NpgsqlParameter("idkh", NpgsqlDbType.Varchar);
                prmArr[0].Value = sidkh;
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
        /// Hàm thống kê doanh thu theo thời gian
        /// </summary>
        /// <param name="stungay">Từ ngày kiểu string format: yyyy/MM/dd</param>
        /// <param name="sdengay">Đến ngày kiểu string format: yyyy/MM/dd</param>
        /// <returns>DataTable</returns>
        public DataTable TKDoanhThu(string stungay, string sdengay)
        {
            tblhoadonban objtblhoadonban = new tblhoadonban();
            string strFun = "fn_tblhoadonban_tkdoanhthu";
            try
            {
                NpgsqlParameter[] prmArr = new NpgsqlParameter[2];
                prmArr[0] = new NpgsqlParameter("tungay", NpgsqlDbType.Varchar);
                prmArr[0].Value = stungay;
                prmArr[1] = new NpgsqlParameter("dengay", NpgsqlDbType.Varchar);
                prmArr[1].Value = sdengay;
                DataSet dstblhoadonban = mDataAccess.ExecuteDataSet(strFun, CommandType.StoredProcedure, prmArr);
                return dstblhoadonban.Tables[0];
            }
            catch
            {
                return null;
            }
        }
        /// <summary>
        /// Hàm thống kê doanh thu theo thời gian
        /// </summary>
        /// <param name="stungay">Từ ngày kiểu string format: yyyy/MM/dd</param>
        /// <param name="sdengay">Đến ngày kiểu string format: yyyy/MM/dd</param>
        /// <param name="sidnv">Tài khoản nhân viên kinh doanh</param>
        /// <returns>DataTable</returns>
        public DataTable TKDoanhThubyIDNV(string stungay, string sdengay,string sidnv)
        {
            tblhoadonban objtblhoadonban = new tblhoadonban();
            string strFun = "fn_tblhoadonban_tkdoanhthubyidnv";
            try
            {
                NpgsqlParameter[] prmArr = new NpgsqlParameter[3];
                prmArr[0] = new NpgsqlParameter("tungay", NpgsqlDbType.Varchar);
                prmArr[0].Value = stungay;
                prmArr[1] = new NpgsqlParameter("dengay", NpgsqlDbType.Varchar);
                prmArr[1].Value = sdengay;
                prmArr[2] = new NpgsqlParameter("idnhanvien", NpgsqlDbType.Varchar);
                prmArr[2].Value = sidnv;
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
