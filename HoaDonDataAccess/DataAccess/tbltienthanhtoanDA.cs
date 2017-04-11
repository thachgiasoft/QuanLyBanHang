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
     /// Mô tả thông tin cho bảng tbltienthanhtoan
     /// Cung cấp các hàm xử lý, thao tác với bảng tbltienthanhtoan
     /// Người tạo (C): tuanva
     /// Ngày khởi tạo: 03/09/2015
     /// </summary>
    public class tbltienthanhtoan
    {
        #region Private Variables
        private string strid;
        private string stridhd;
        private DateTime dtmngaytt;
        private double dbltientt;
        private string strghichu;
        #endregion

        #region Public Constructor Functions
        public tbltienthanhtoan()
        {
            strid = string.Empty;
            stridhd = string.Empty;
            dtmngaytt = DateTime.Now;
            dbltientt = 0;
            strghichu = string.Empty;

        }

        public tbltienthanhtoan(string strid, string stridhd, DateTime dtmngaytt, double dbltientt, string strghichu)
        {
            this.strid = strid;
            this.stridhd = stridhd;
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

        public string idhd
        {
            get
            {
                return stridhd;
            }
            set
            {
                stridhd = value;
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
        /// Lấy toàn bộ dữ liệu từ bảng tbltienthanhtoan
        /// </summary>
        /// <returns>DataTable</returns>
        public DataTable GetAll()
        {
            string strFun = "fn_tbltienthanhtoan_getall";
            try
            {
                DataSet dstbltienthanhtoan = mDataAccess.ExecuteDataSet(strFun, CommandType.StoredProcedure);
                return dstbltienthanhtoan.Tables[0];
            }
            catch
            {
                return null;
            }
        }
        /// <summary>
        /// Hàm lấy tbltienthanhtoan theo mã
        /// </summary>
        /// <returns>Trả về objtbltienthanhtoan </returns>
        public tbltienthanhtoan GetByID(string strid)
        {
            tbltienthanhtoan objtbltienthanhtoan = new tbltienthanhtoan();
            string strFun = "fn_tbltienthanhtoan_getobjbyid";
            try
            {
                NpgsqlParameter[] prmArr = new NpgsqlParameter[1];

                prmArr[0] = new NpgsqlParameter("id", NpgsqlDbType.Varchar);
                prmArr[0].Value = strid;

                DataSet dstbltienthanhtoan = mDataAccess.ExecuteDataSet(strFun, CommandType.StoredProcedure, prmArr);

                if ((dstbltienthanhtoan != null) && (dstbltienthanhtoan.Tables.Count > 0))
                {
                    if (dstbltienthanhtoan.Tables[0].Rows.Count > 0)
                    {
                        DataRow dr = dstbltienthanhtoan.Tables[0].Rows[0];
                        objtbltienthanhtoan.id = dr["id"].ToString();

                        objtbltienthanhtoan.idhd = dr["idhd"].ToString();

                        try { objtbltienthanhtoan.ngaytt = Convert.ToDateTime(dr["ngaytt"].ToString());}
                        catch { objtbltienthanhtoan.ngaytt = new DateTime(1900, 1, 1); }

                        try { objtbltienthanhtoan.tientt = Convert.ToDouble("0" + dr["tientt"].ToString());}
                        catch { objtbltienthanhtoan.tientt = 0; }

                        objtbltienthanhtoan.ghichu = dr["ghichu"].ToString();


                        return objtbltienthanhtoan;
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
        /// Hàm lấy objtienthanhtoan theo mã hóa đơn và ngày thanh toán
        /// </summary>
        /// <param name="sidhd">Mã hóa đơn kiểu string(Guid)</param>
        /// <param name="dtngaytt">Ngày thanh toán kiểu DateTime</param>
        /// <returns>tbltienthanhtoan</returns>
        public tbltienthanhtoan GetByIDHDvsNgayTT(string sidhd, DateTime dtngaytt)
        {
            tbltienthanhtoan objtbltienthanhtoan = new tbltienthanhtoan();
            string strFun = "fn_tbltienthanhtoan_getobjbyidhdvsngaytt";
            try
            {
                NpgsqlParameter[] prmArr = new NpgsqlParameter[2];
                prmArr[0] = new NpgsqlParameter("idhd", NpgsqlDbType.Varchar);
                prmArr[0].Value = sidhd;
                prmArr[1] = new NpgsqlParameter("ngaytt", NpgsqlDbType.Varchar);
                prmArr[1].Value = dtngaytt.ToString("yyyy/MM/dd HH:mm:ss");
                DataSet dstbltienthanhtoan = mDataAccess.ExecuteDataSet(strFun, CommandType.StoredProcedure, prmArr);
                if ((dstbltienthanhtoan != null) && (dstbltienthanhtoan.Tables.Count > 0))
                {
                    if (dstbltienthanhtoan.Tables[0].Rows.Count > 0)
                    {
                        DataRow dr = dstbltienthanhtoan.Tables[0].Rows[0];
                        objtbltienthanhtoan.id = dr["id"].ToString();
                        objtbltienthanhtoan.idhd = dr["idhd"].ToString();
                        try { objtbltienthanhtoan.ngaytt = Convert.ToDateTime(dr["ngaytt"].ToString()); }
                        catch { objtbltienthanhtoan.ngaytt = new DateTime(1900, 1, 1); }
                        try { objtbltienthanhtoan.tientt = Convert.ToDouble("0" + dr["tientt"].ToString()); }
                        catch { objtbltienthanhtoan.tientt = 0; }
                        objtbltienthanhtoan.ghichu = dr["ghichu"].ToString();
                        return objtbltienthanhtoan;
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
        /// <param name="sidhd">Mã hóa đơn kiểu string(Guid)</param>
        /// <returns>DataTable</returns>
        public DataTable GetByIDHD(string sidhd)
        {
            tbltienthanhtoan objtbltienthanhtoan = new tbltienthanhtoan();
            string strFun = "fn_tbltienthanhtoan_getbyidhd";
            try
            {
                NpgsqlParameter[] prmArr = new NpgsqlParameter[1];
                prmArr[0] = new NpgsqlParameter("idhd", NpgsqlDbType.Varchar);
                prmArr[0].Value = sidhd;
                DataSet dstbltienthanhtoan = mDataAccess.ExecuteDataSet(strFun, CommandType.StoredProcedure, prmArr);
                return dstbltienthanhtoan.Tables[0];
            }
            catch
            {
                return null;
            }
        }
        /// <summary>
        /// Hàm kiểm tra đã tồn tại bản ghi theo mã hóa đơn và ngày thanh toán chưa
        /// </summary>
        /// <param name="sidhd">Mã hóa đơn kiểu string (Guid)</param>
        /// <param name="dtngaytt">Ngày thanh toán kiểu DateTime</param>
        /// <returns>bool: False-Không tồn tại;True-Có tồn tại</returns>
        public bool CheckExit(string sidhd, DateTime dtngaytt)
        {
            string strProc = "fn_tbltienthanhtoan_checkexit";
            try
            {
                NpgsqlParameter[] prmArr = new NpgsqlParameter[3];
                prmArr[0] = new NpgsqlParameter("idhd", NpgsqlDbType.Varchar);
                prmArr[0].Value = sidhd;
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
        /// Thêm mới dữ liệu vào bảng: tbltienthanhtoan
        /// </summary>
        /// <param name="obj">objtbltienthanhtoan</param>
        /// <returns>Trả về trắng: Thêm mới thành công; Trả về khác trắng: Thêm mới không thành công</returns>
        public string Insert(tbltienthanhtoan objtbltienthanhtoan)
        {
            string strProc = "fn_tbltienthanhtoan_insert";
            try
            {
                NpgsqlParameter[] prmArr = new NpgsqlParameter[6];
                prmArr[0] = new NpgsqlParameter("id", NpgsqlDbType.Varchar);
                prmArr[0].Value = objtbltienthanhtoan.strid;
                prmArr[1] = new NpgsqlParameter("idhd", NpgsqlDbType.Varchar);
                prmArr[1].Value = objtbltienthanhtoan.stridhd;
                prmArr[2] = new NpgsqlParameter("ngaytt", NpgsqlDbType.Varchar);
                prmArr[2].Value = objtbltienthanhtoan.dtmngaytt.ToString("yyyy/MM/dd HH:mm:ss");
                prmArr[3] = new NpgsqlParameter("tientt", NpgsqlDbType.Double);
                prmArr[3].Value = objtbltienthanhtoan.dbltientt;
                prmArr[4] = new NpgsqlParameter("ghichu", NpgsqlDbType.Varchar);
                prmArr[4].Value = objtbltienthanhtoan.strghichu;
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
        /// Cập nhật dữ liệu vào bảng: tbltienthanhtoan
        /// </summary>
        /// <param name="obj">objtbltienthanhtoan</param>
        /// <returns>Trả về trắng: Cập nhật thành công; Trả về khác trắng: Cập nhật không thành công</returns>
        public string Update(tbltienthanhtoan objtbltienthanhtoan)
        {
            string strProc = "fn_tbltienthanhtoan_Update";
            try
            {
                NpgsqlParameter[] prmArr = new NpgsqlParameter[6];
                prmArr[0] = new NpgsqlParameter("id", NpgsqlDbType.Varchar);
                prmArr[0].Value = objtbltienthanhtoan.strid;
                prmArr[1] = new NpgsqlParameter("idhd", NpgsqlDbType.Varchar);
                prmArr[1].Value = objtbltienthanhtoan.stridhd;
                prmArr[2] = new NpgsqlParameter("ngaytt", NpgsqlDbType.Varchar);
                prmArr[2].Value = objtbltienthanhtoan.dtmngaytt.ToString("yyyy/MM/dd HH:mm:ss");
                prmArr[3] = new NpgsqlParameter("tientt", NpgsqlDbType.Double);
                prmArr[3].Value = objtbltienthanhtoan.dbltientt;
                prmArr[4] = new NpgsqlParameter("ghichu", NpgsqlDbType.Varchar);
                prmArr[4].Value = objtbltienthanhtoan.strghichu;
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
        /// Xóa dữ liệu từ bảng tbltienthanhtoan
        /// </summary>
        /// <returns></returns>
        public string Delete(string strid)
        {
            string strProc = "fn_tbltienthanhtoan_delete";
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
        /// Hàm lấy tất cả dữ liệu trong bảng tbltienthanhtoan
        /// </summary>
        /// <returns>Trả về List<<tbltienthanhtoan>></returns>
        public List<tbltienthanhtoan> GetList()
        {
          List<tbltienthanhtoan> list = new List<tbltienthanhtoan>();
          string strFun = "fn_tbltienthanhtoan_getall";
          try
          {
              DataSet dstbltienthanhtoan = mDataAccess.ExecuteDataSet(strFun, CommandType.StoredProcedure);
              if ((dstbltienthanhtoan != null) && (dstbltienthanhtoan.Tables.Count > 0))
              {
                  for (int i = 0; i < dstbltienthanhtoan.Tables[0].Rows.Count; i++)
                  {
                        tbltienthanhtoan objtbltienthanhtoan = new tbltienthanhtoan();
                        DataRow dr = dstbltienthanhtoan.Tables[0].Rows[i];
                        objtbltienthanhtoan.id = dr["id"].ToString();

                        objtbltienthanhtoan.idhd = dr["idhd"].ToString();

                        try { objtbltienthanhtoan.ngaytt = Convert.ToDateTime(dr["ngaytt"].ToString());}
                        catch { objtbltienthanhtoan.ngaytt = new DateTime(1900, 1, 1); }

                        try { objtbltienthanhtoan.tientt = Convert.ToDouble("0" + dr["tientt"].ToString());}
                        catch { objtbltienthanhtoan.tientt = 0; }

                        objtbltienthanhtoan.ghichu = dr["ghichu"].ToString();

                        list.Add(objtbltienthanhtoan);
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
        /// Hàm lấy danh sách objtbltienthanhtoan
        /// </summary>
        /// <param name="recperpage">Số lượng bản ghi kiểu integer</param>
        /// <param name="pageindex">Số trang kiểu integer</param>
        /// <returns>Trả về List<<tbltienthanhtoan>></returns>
        public List<tbltienthanhtoan> GetListPaged(int recperpage, int pageindex)
        {
          List<tbltienthanhtoan> list = new List<tbltienthanhtoan>();
          string strFun = "fn_tbltienthanhtoan_getpaged";
          try
          {
              NpgsqlParameter[] prmArr = new NpgsqlParameter[2];
              prmArr[0] = new NpgsqlParameter("recperpage", NpgsqlDbType.Integer);
              prmArr[0].Value = recperpage;
              prmArr[1] = new NpgsqlParameter("pageindex", NpgsqlDbType.Integer);
              prmArr[1].Value = pageindex;
              DataSet dstbltienthanhtoan = mDataAccess.ExecuteDataSet(strFun, CommandType.StoredProcedure,prmArr);
              if ((dstbltienthanhtoan != null) && (dstbltienthanhtoan.Tables.Count > 0))
              {
                  for (int i = 0; i < dstbltienthanhtoan.Tables[0].Rows.Count; i++)
                  {
                        tbltienthanhtoan objtbltienthanhtoan = new tbltienthanhtoan();
                        DataRow dr = dstbltienthanhtoan.Tables[0].Rows[i];
                        objtbltienthanhtoan.id = dr["id"].ToString();

                        objtbltienthanhtoan.idhd = dr["idhd"].ToString();

                        try { objtbltienthanhtoan.ngaytt = Convert.ToDateTime(dr["ngaytt"].ToString());}
                        catch { objtbltienthanhtoan.ngaytt = new DateTime(1900, 1, 1); }

                        try { objtbltienthanhtoan.tientt = Convert.ToDouble("0" + dr["tientt"].ToString());}
                        catch { objtbltienthanhtoan.tientt = 0; }

                        objtbltienthanhtoan.ghichu = dr["ghichu"].ToString();

                        list.Add(objtbltienthanhtoan);
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
        /// Hàm lấy danh sách objtbltienthanhtoan
        /// </summary>
        /// <param name="recperpage">Số lượng bản ghi kiểu integer</param>
        /// <param name="pageindex">Số trang kiểu integer</param>
        /// <returns>Trả về List<<tbltienthanhtoan>></returns>
        public DataTable GetDataTablePaged(int recperpage, int pageindex)
        {
          string strFun = "fn_tbltienthanhtoan_getpaged";
          try
          {
              NpgsqlParameter[] prmArr = new NpgsqlParameter[2];
              prmArr[0] = new NpgsqlParameter("recperpage", NpgsqlDbType.Integer);
              prmArr[0].Value = recperpage;
              prmArr[1] = new NpgsqlParameter("pageindex", NpgsqlDbType.Integer);
              prmArr[1].Value = pageindex;
              DataSet dstbltienthanhtoan = mDataAccess.ExecuteDataSet(strFun, CommandType.StoredProcedure,prmArr);
              return dstbltienthanhtoan.Tables[0];
          }
          catch
          {
              return null;
          }
        }
        #endregion
    }
}
