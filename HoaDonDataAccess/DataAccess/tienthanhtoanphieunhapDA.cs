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
     /// Mô tả thông tin cho bảng tienthanhtoanphieunhap
     /// Cung cấp các hàm xử lý, thao tác với bảng tienthanhtoanphieunhap
     /// Người tạo (C): tuanva
     /// Ngày khởi tạo: 03/09/2015
     /// </summary>
    public class tienthanhtoanphieunhap
    {
        #region Private Variables
        private string strid;
        private string stridpn;
        private DateTime dtmngaytt;
        private double dbltientt;
        private string strghichu;
        #endregion

        #region Public Constructor Functions
        public tienthanhtoanphieunhap()
        {
            strid = string.Empty;
            stridpn = string.Empty;
            dtmngaytt = DateTime.Now;
            dbltientt = 0;
            strghichu = string.Empty;

        }

        public tienthanhtoanphieunhap(string strid, string stridpn, DateTime dtmngaytt, double dbltientt, string strghichu)
        {
            this.strid = strid;
            this.stridpn = stridpn;
            this.dtmngaytt = dtmngaytt;
            this.dbltientt = dbltientt;
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
        public string idpn
        {
            get
            {
                return stridpn;
            }
            set
            {
                stridpn = value;
            }
        }
        public DateTime ngaytt
        {
            get
            {
                return dtmngaytt;
            }
            set
            {
                dtmngaytt = value;
            }
        }
        public double tientt
        {
            get
            {
                return dbltientt;
            }
            set
            {
                dbltientt = value;
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
        /// Lấy toàn bộ dữ liệu từ bảng tienthanhtoanphieunhap
        /// </summary>
        /// <returns>DataTable</returns>
        public DataTable GetAll()
        {
            string strFun = "fn_tienthanhtoanphieunhap_getall";
            try
            {
                DataSet ds = mDataAccess.ExecuteDataSet(strFun, CommandType.StoredProcedure);
                return ds.Tables[0];
            }
            catch
            {
                return null;
            }
        }
        /// <summary>
        /// Hàm lấy object tienthanhtoanphieunhap theo mã
        /// </summary>
        /// <returns>Trả về objttienthanhtoanphieunhap </returns>
        public tienthanhtoanphieunhap GetByID(string strid)
        {
            tienthanhtoanphieunhap obj = new tienthanhtoanphieunhap();
            string strFun = "fn_tienthanhtoanphieunhap_getobjbyid";
            try
            {
                NpgsqlParameter[] prmArr = new NpgsqlParameter[1];
                prmArr[0] = new NpgsqlParameter("id", NpgsqlDbType.Varchar);
                prmArr[0].Value = strid;
                DataSet ds = mDataAccess.ExecuteDataSet(strFun, CommandType.StoredProcedure, prmArr);
                if ((ds != null) && (ds.Tables.Count > 0))
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        DataRow dr = ds.Tables[0].Rows[0];
                        obj.id = dr["id"].ToString();
                        obj.idpn = dr["idpn"].ToString();
                        try { obj.ngaytt = Convert.ToDateTime(dr["ngaytt"].ToString());}
                        catch { obj.ngaytt = new DateTime(1900, 1, 1); }
                        try { obj.tientt = Convert.ToDouble("0" + dr["tientt"].ToString());}
                        catch { obj.tientt = 0; }
                        obj.ghichu = dr["ghichu"].ToString();
                        return obj;
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
        /// Hàm lấy objtienthanhtoanphieunhap theo mã phiếu nhập hàng và ngày thanh toán
        /// </summary>
        /// <param name="sidhd">Mã phiếu nhập hàng kiểu string(Guid)</param>
        /// <param name="dtngaytt">Ngày thanh toán kiểu DateTime</param>
        /// <returns>object: tienthanhtoanphieunhap</returns>
        public tienthanhtoanphieunhap GetByIDPNvsNgayTT(string sidpn, DateTime dtngaytt)
        {
            tienthanhtoanphieunhap obj = new tienthanhtoanphieunhap();
            string strFun = "fn_tienthanhtoanphieunhap_getobjbyidpnvsngaytt";
            try
            {
                NpgsqlParameter[] prmArr = new NpgsqlParameter[2];
                prmArr[0] = new NpgsqlParameter("idpn", NpgsqlDbType.Varchar);
                prmArr[0].Value = sidpn;
                prmArr[1] = new NpgsqlParameter("ngaytt", NpgsqlDbType.Varchar);
                prmArr[1].Value = dtngaytt.ToString("yyyy/MM/dd HH:mm:ss");
                DataSet ds = mDataAccess.ExecuteDataSet(strFun, CommandType.StoredProcedure, prmArr);
                if ((ds != null) && (ds.Tables.Count > 0))
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        DataRow dr = ds.Tables[0].Rows[0];
                        obj.id = dr["id"].ToString();
                        obj.idpn = dr["idpn"].ToString();
                        try { obj.ngaytt = Convert.ToDateTime(dr["ngaytt"].ToString()); }
                        catch { obj.ngaytt = new DateTime(1900, 1, 1); }
                        try { obj.tientt = Convert.ToDouble("0" + dr["tientt"].ToString()); }
                        catch { obj.tientt = 0; }
                        obj.ghichu = dr["ghichu"].ToString();
                        return obj;
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
        /// Hàm lấy danh sách tiền thanh toán theo mã hóa đơn
        /// </summary>
        /// <param name="sidpn">Mã phiếu nhập kiểu string(Guid)</param>
        /// <returns>DataTable</returns>
        public DataTable GetByIDPN(string sidpn)
        {
            string strFun = "fn_tienthanhtoanphieunhap_getbyidpn";
            try
            {
                NpgsqlParameter[] prmArr = new NpgsqlParameter[1];
                prmArr[0] = new NpgsqlParameter("idpn", NpgsqlDbType.Varchar);
                prmArr[0].Value = sidpn;
                DataSet ds = mDataAccess.ExecuteDataSet(strFun, CommandType.StoredProcedure, prmArr);
                return ds.Tables[0];
            }
            catch
            {
                return null;
            }
        }
        /// <summary>
        /// Hàm kiểm tra đã tồn tại bản ghi theo mã phiếu nhập và ngày thanh toán
        /// </summary>
        /// <param name="sidhd">Mã phiếu nhập kiểu string (Guid)</param>
        /// <param name="dtngaytt">Ngày thanh toán kiểu DateTime</param>
        /// <returns>bool: False-Không tồn tại;True-Có tồn tại</returns>
        public bool CheckExit(string sidpn, DateTime dtngaytt)
        {
            string strProc = "fn_tienthanhtoanphieunhap_checkexit";
            try
            {
                NpgsqlParameter[] prmArr = new NpgsqlParameter[3];
                prmArr[0] = new NpgsqlParameter("idpn", NpgsqlDbType.Varchar);
                prmArr[0].Value = sidpn;
                prmArr[1] = new NpgsqlParameter("ngaytt", NpgsqlDbType.Varchar);
                prmArr[1].Value = dtngaytt.ToString("yyyy/MM/dd HH:mm:ss");
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
        /// Thêm mới dữ liệu vào bảng: tienthanhtoanphieunhap
        /// </summary>
        /// <param name="obj">objtienthanhtoanphieunhap</param>
        /// <returns>Trả về trắng: Thêm mới thành công; Trả về khác trắng: Thêm mới không thành công</returns>
        public string Insert(tienthanhtoanphieunhap objtienthanhtoanphieunhap)
        {
            string strProc = "fn_tienthanhtoanphieunhap_insert";
            try
            {
                NpgsqlParameter[] prmArr = new NpgsqlParameter[6];
                prmArr[0] = new NpgsqlParameter("id", NpgsqlDbType.Varchar);
                prmArr[0].Value = objtienthanhtoanphieunhap.strid;
                prmArr[1] = new NpgsqlParameter("idpn", NpgsqlDbType.Varchar);
                prmArr[1].Value = objtienthanhtoanphieunhap.stridpn;
                prmArr[2] = new NpgsqlParameter("ngaytt", NpgsqlDbType.Varchar);
                prmArr[2].Value = objtienthanhtoanphieunhap.dtmngaytt.ToString("yyyy/MM/dd HH:mm:ss");
                prmArr[3] = new NpgsqlParameter("tientt", NpgsqlDbType.Double);
                prmArr[3].Value = objtienthanhtoanphieunhap.dbltientt;
                prmArr[4] = new NpgsqlParameter("ghichu", NpgsqlDbType.Varchar);
                prmArr[4].Value = objtienthanhtoanphieunhap.strghichu;
                prmArr[5] = new NpgsqlParameter("ireturn", NpgsqlDbType.Text);
                prmArr[5].Direction = ParameterDirection.Output;
                mDataAccess.ExecuteQuery(strProc, CommandType.StoredProcedure, prmArr);
                string sKQ =  prmArr[5].Value.ToString().Trim(); 
                if (sKQ.ToUpper().Equals("Add".ToUpper()) == true) return "";
                return "Thêm mới dữ liệu không thành công";            }
            catch(Exception ex)
            {
                return "Thêm mới dữ liệu không thành công. Chi Tiết: " + ex.Message;
            }
        }
        /// <summary>
        /// Cập nhật dữ liệu vào bảng: tienthanhtoanphieunhap
        /// </summary>
        /// <param name="obj">objtienthanhtoanphieunhap</param>
        /// <returns>Trả về trắng: Cập nhật thành công; Trả về khác trắng: Cập nhật không thành công</returns>
        public string Update(tienthanhtoanphieunhap objtienthanhtoanphieunhap)
        {
            string strProc = "fn_tienthanhtoanphieunhap_update";
            try
            {
                NpgsqlParameter[] prmArr = new NpgsqlParameter[6];
                prmArr[0] = new NpgsqlParameter("id", NpgsqlDbType.Varchar);
                prmArr[0].Value = objtienthanhtoanphieunhap.strid;
                prmArr[1] = new NpgsqlParameter("idpn", NpgsqlDbType.Varchar);
                prmArr[1].Value = objtienthanhtoanphieunhap.stridpn;
                prmArr[2] = new NpgsqlParameter("ngaytt", NpgsqlDbType.Varchar);
                prmArr[2].Value = objtienthanhtoanphieunhap.dtmngaytt.ToString("yyyy/MM/dd HH:mm:ss");
                prmArr[3] = new NpgsqlParameter("tientt", NpgsqlDbType.Double);
                prmArr[3].Value = objtienthanhtoanphieunhap.dbltientt;
                prmArr[4] = new NpgsqlParameter("ghichu", NpgsqlDbType.Varchar);
                prmArr[4].Value = objtienthanhtoanphieunhap.strghichu;
                prmArr[5] = new NpgsqlParameter("ireturn", NpgsqlDbType.Text);
                prmArr[5].Direction = ParameterDirection.Output;
                mDataAccess.ExecuteQuery(strProc, CommandType.StoredProcedure, prmArr);
                string sKQ = prmArr[5 ].Value.ToString().Trim();
                if (sKQ.ToUpper().Equals("Update".ToUpper()) == true) return "";
                return "Cập nhật dữ liệu không thành công";

            }
            catch(Exception ex)
            {
                return "Cập nhật dữ liệu không thành công. Chi Tiết: " + ex.Message;
            }
        }
        /// <summary>
        /// Xóa dữ liệu từ bảng tienthanhtoanphieunhap
        /// </summary>
        /// <returns></returns>
        public string Delete(string strid)
        {
            string strProc = "fn_tienthanhtoanphieunhap_delete";
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
        /// Hàm lấy tất cả dữ liệu trong bảng tienthanhtoanphieunhap
        /// </summary>
        /// <returns>Trả về List<<tienthanhtoanphieunhap>></returns>
        public List<tienthanhtoanphieunhap> GetList()
        {
            List<tienthanhtoanphieunhap> list = new List<tienthanhtoanphieunhap>();
            string strFun = "fn_tienthanhtoanphieunhap_getall";
            try
            {
                DataSet dstienthanhtoanphieunhap = mDataAccess.ExecuteDataSet(strFun, CommandType.StoredProcedure);
                if ((dstienthanhtoanphieunhap != null) && (dstienthanhtoanphieunhap.Tables.Count > 0))
                {
                    for (int i = 0; i < dstienthanhtoanphieunhap.Tables[0].Rows.Count; i++)
                    {
                        tienthanhtoanphieunhap objtienthanhtoanphieunhap = new tienthanhtoanphieunhap();
                        DataRow dr = dstienthanhtoanphieunhap.Tables[0].Rows[i];
                        objtienthanhtoanphieunhap.id = dr["id"].ToString();
                        objtienthanhtoanphieunhap.idpn = dr["idpn"].ToString();
                        try { objtienthanhtoanphieunhap.ngaytt = Convert.ToDateTime(dr["ngaytt"].ToString()); }
                        catch { objtienthanhtoanphieunhap.ngaytt = new DateTime(1900, 1, 1); }
                        try { objtienthanhtoanphieunhap.tientt = Convert.ToDouble("0" + dr["tientt"].ToString()); }
                        catch { objtienthanhtoanphieunhap.tientt = 0; }
                        objtienthanhtoanphieunhap.ghichu = dr["ghichu"].ToString();
                        list.Add(objtienthanhtoanphieunhap);
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
        /// Hàm lấy danh sách objtienthanhtoanphieunhap
        /// </summary>
        /// <param name="recperpage">Số lượng bản ghi kiểu integer</param>
        /// <param name="pageindex">Số trang kiểu integer</param>
        /// <returns>Trả về List<<tienthanhtoanphieunhap>></returns>
        public List<tienthanhtoanphieunhap> GetListPaged(int recperpage, int pageindex)
        {
          List<tienthanhtoanphieunhap> list = new List<tienthanhtoanphieunhap>();
          string strFun = "fn_tienthanhtoanphieunhap_getpaged";
          try
          {
              NpgsqlParameter[] prmArr = new NpgsqlParameter[2];
              prmArr[0] = new NpgsqlParameter("recperpage", NpgsqlDbType.Integer);
              prmArr[0].Value = recperpage;
              prmArr[1] = new NpgsqlParameter("pageindex", NpgsqlDbType.Integer);
              prmArr[1].Value = pageindex;
              DataSet dstienthanhtoanphieunhap = mDataAccess.ExecuteDataSet(strFun, CommandType.StoredProcedure,prmArr);
              if ((dstienthanhtoanphieunhap != null) && (dstienthanhtoanphieunhap.Tables.Count > 0))
              {
                  for (int i = 0; i < dstienthanhtoanphieunhap.Tables[0].Rows.Count; i++)
                  {
                        tienthanhtoanphieunhap objtienthanhtoanphieunhap = new tienthanhtoanphieunhap();
                        DataRow dr = dstienthanhtoanphieunhap.Tables[0].Rows[i];
                        objtienthanhtoanphieunhap.id = dr["id"].ToString();
                        objtienthanhtoanphieunhap.idpn = dr["idpn"].ToString();
                        try { objtienthanhtoanphieunhap.ngaytt = Convert.ToDateTime(dr["ngaytt"].ToString());}
                        catch { objtienthanhtoanphieunhap.ngaytt = new DateTime(1900, 1, 1); }
                        try { objtienthanhtoanphieunhap.tientt = Convert.ToDouble("0" + dr["tientt"].ToString());}
                        catch { objtienthanhtoanphieunhap.tientt = 0; }
                        objtienthanhtoanphieunhap.ghichu = dr["ghichu"].ToString();
                        list.Add(objtienthanhtoanphieunhap);
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
        /// Hàm lấy danh sách objtienthanhtoanphieunhap
        /// </summary>
        /// <param name="recperpage">Số lượng bản ghi kiểu integer</param>
        /// <param name="pageindex">Số trang kiểu integer</param>
        /// <returns>Trả về List<<tienthanhtoanphieunhap>></returns>
        public DataTable GetDataTablePaged(int recperpage, int pageindex)
        {
          string strFun = "fn_tienthanhtoanphieunhap_getpaged";
          try
          {
              NpgsqlParameter[] prmArr = new NpgsqlParameter[2];
              prmArr[0] = new NpgsqlParameter("recperpage", NpgsqlDbType.Integer);
              prmArr[0].Value = recperpage;
              prmArr[1] = new NpgsqlParameter("pageindex", NpgsqlDbType.Integer);
              prmArr[1].Value = pageindex;
              DataSet dstienthanhtoanphieunhap = mDataAccess.ExecuteDataSet(strFun, CommandType.StoredProcedure,prmArr);
              return dstienthanhtoanphieunhap.Tables[0];
          }
          catch
          {
              return null;
          }
        }
        #endregion
    }
}
