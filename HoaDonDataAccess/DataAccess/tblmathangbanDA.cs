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
     /// Mô tả thông tin cho bảng tblmathangban
     /// Cung cấp các hàm xử lý, thao tác với bảng tblmathangban
     /// Người tạo (C): tuanva
     /// Ngày khởi tạo: 19/08/2015
     /// </summary>
    public class tblmathangban
    {
        #region Private Variables
        private string strid;
        private string strid_hoadon;
        private string strid_mathang;
        private int intsoluong;
        private double dblgiaban;
        private DateTime dtmngaytao;
        #endregion

        #region Public Constructor Functions
        public tblmathangban()
        {
            strid = string.Empty;
            strid_hoadon = string.Empty;
            strid_mathang = string.Empty;
            intsoluong = 0;
            dblgiaban = 0;
            dtmngaytao = DateTime.Now;

        }

        public tblmathangban(string strid, string strid_hoadon, string strid_mathang, int intsoluong, double dblgiaban, DateTime dtmngaytao)
        {
            this.strid = strid;
            this.strid_hoadon = strid_hoadon;
            this.strid_mathang = strid_mathang;
            this.intsoluong = intsoluong;
            this.dblgiaban = dblgiaban;
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

        public double giaban
        {
            get
            {
                return dblgiaban;
            }
            set
            {
                dblgiaban = value;
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
        /// Lấy toàn bộ dữ liệu từ bảng tblmathangban
        /// </summary>
        /// <returns>DataTable</returns>
        public DataTable GetAll()
        {
            string strFun = "fn_tblmathangban_getall";
            try
            {
                DataSet dstblmathangban = mDataAccess.ExecuteDataSet(strFun, CommandType.StoredProcedure);
                return dstblmathangban.Tables[0];
            }
            catch
            {
                return null;
            }
        }
        /// <summary>
        /// Hàm lấy tblmathangban theo mã
        /// </summary>
        /// <returns>Trả về objtblmathangban </returns>
        public tblmathangban GetByID(string strid)
        {
            tblmathangban objtblmathangban = new tblmathangban();
            string strFun = "fn_tblmathangban_getobjbyid";
            try
            {
                NpgsqlParameter[] prmArr = new NpgsqlParameter[1];

                prmArr[0] = new NpgsqlParameter("id", NpgsqlDbType.Varchar);
                prmArr[0].Value = strid;

                DataSet dstblmathangban = mDataAccess.ExecuteDataSet(strFun, CommandType.StoredProcedure, prmArr);

                if ((dstblmathangban != null) && (dstblmathangban.Tables.Count > 0))
                {
                    if (dstblmathangban.Tables[0].Rows.Count > 0)
                    {
                        DataRow dr = dstblmathangban.Tables[0].Rows[0];
                        objtblmathangban.id = dr["id"].ToString();

                        objtblmathangban.id_hoadon = dr["id_hoadon"].ToString();

                        objtblmathangban.id_mathang = dr["id_mathang"].ToString();

                        try{ objtblmathangban.soluong = Convert.ToInt32("0" + dr["soluong"].ToString());}
                        catch{ objtblmathangban.soluong = 0;}

                        try { objtblmathangban.giaban = Convert.ToDouble("0" + dr["giaban"].ToString());}
                        catch { objtblmathangban.giaban = 0; }

                        try { objtblmathangban.ngaytao = Convert.ToDateTime(dr["ngaytao"].ToString());}
                        catch { objtblmathangban.ngaytao = new DateTime(1900, 1, 1); }


                        return objtblmathangban;
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
        /// Hàm lấy danh sách mặt hàng theo mã hóa đơn
        /// </summary>
        /// <param name="stridhd">Mã hóa đơn kiểu string</param>
        /// <returns>DataTable</returns>
        public DataTable GetByHDID(string stridhd)
        {
            string strFun = "fn_tblmathangban_getbyidhd";
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
        /// Thêm mới dữ liệu vào bảng: tblmathangban
        /// </summary>
        /// <param name="obj">objtblmathangban</param>
        /// <returns>Trả về trắng: Thêm mới thành công; Trả về khác trắng: Thêm mới không thành công</returns>
        public string Insert(tblmathangban objtblmathangban)
        {
            string strProc = "fn_tblmathangban_insert";
            try
            {
                NpgsqlParameter[] prmArr = new NpgsqlParameter[6];
                prmArr[0] = new NpgsqlParameter("id", NpgsqlDbType.Varchar);
                prmArr[0].Value = objtblmathangban.strid;
                prmArr[1] = new NpgsqlParameter("id_hoadon", NpgsqlDbType.Varchar);
                prmArr[1].Value = objtblmathangban.strid_hoadon;
                prmArr[2] = new NpgsqlParameter("id_mathang", NpgsqlDbType.Varchar);
                prmArr[2].Value = objtblmathangban.strid_mathang;
                prmArr[3] = new NpgsqlParameter("soluong", NpgsqlDbType.Integer);
                prmArr[3].Value = objtblmathangban.intsoluong;
                prmArr[4] = new NpgsqlParameter("giaban", NpgsqlDbType.Double);
                prmArr[4].Value = objtblmathangban.dblgiaban;
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
        /// Cập nhật dữ liệu vào bảng: tblmathangban
        /// </summary>
        /// <param name="obj">objtblmathangban</param>
        /// <returns>Trả về trắng: Cập nhật thành công; Trả về khác trắng: Cập nhật không thành công</returns>
        public string Update(tblmathangban objtblmathangban)
        {
            string strProc = "fn_tblmathangban_Update";
            try
            {
                NpgsqlParameter[] prmArr = new NpgsqlParameter[6];
                prmArr[0] = new NpgsqlParameter("id", NpgsqlDbType.Varchar);
                prmArr[0].Value = objtblmathangban.strid;
                prmArr[1] = new NpgsqlParameter("id_hoadon", NpgsqlDbType.Varchar);
                prmArr[1].Value = objtblmathangban.strid_hoadon;
                prmArr[2] = new NpgsqlParameter("id_mathang", NpgsqlDbType.Varchar);
                prmArr[2].Value = objtblmathangban.strid_mathang;
                prmArr[3] = new NpgsqlParameter("soluong", NpgsqlDbType.Integer);
                prmArr[3].Value = objtblmathangban.intsoluong;
                prmArr[4] = new NpgsqlParameter("giaban", NpgsqlDbType.Double);
                prmArr[4].Value = objtblmathangban.dblgiaban;
                prmArr[5] = new NpgsqlParameter("ireturn", NpgsqlDbType.Text);
                prmArr[5].Direction = ParameterDirection.Output;
                mDataAccess.ExecuteQuery(strProc, CommandType.StoredProcedure, prmArr);
                string sKQ = prmArr[5].Value.ToString().Trim();
                if (sKQ.ToUpper().Equals("Update".ToUpper()) == true) return "";
                return "Cập nhật dữ liệu không thành công";
            }
            catch(Exception ex)
            {
                return "Cập nhật dữ liệu không thành công. Chi Tiết: " + ex.Message;
            }
        }
        /// <summary>
        /// Xóa dữ liệu từ bảng tblmathangban
        /// </summary>
        /// <returns></returns>
        public string Delete(string strid)
        {
            string strProc = "fn_tblmathangban_delete";
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
        /// Hàm lấy tất cả dữ liệu trong bảng tblmathangban
        /// </summary>
        /// <returns>Trả về List<<tblmathangban>></returns>
        public List<tblmathangban> GetList()
        {
          List<tblmathangban> list = new List<tblmathangban>();
          string strFun = "fn_tblmathangban_getall";
          try
          {
              DataSet dstblmathangban = mDataAccess.ExecuteDataSet(strFun, CommandType.StoredProcedure);
              if ((dstblmathangban != null) && (dstblmathangban.Tables.Count > 0))
              {
                  for (int i = 0; i < dstblmathangban.Tables[0].Rows.Count; i++)
                  {
                        tblmathangban objtblmathangban = new tblmathangban();
                        DataRow dr = dstblmathangban.Tables[0].Rows[i];
                        objtblmathangban.id = dr["id"].ToString();

                        objtblmathangban.id_hoadon = dr["id_hoadon"].ToString();

                        objtblmathangban.id_mathang = dr["id_mathang"].ToString();

                        try{ objtblmathangban.soluong = Convert.ToInt32("0" + dr["soluong"].ToString());}
                        catch{ objtblmathangban.soluong = 0;}

                        try { objtblmathangban.giaban = Convert.ToDouble("0" + dr["giaban"].ToString());}
                        catch { objtblmathangban.giaban = 0; }

                        try { objtblmathangban.ngaytao = Convert.ToDateTime(dr["ngaytao"].ToString());}
                        catch { objtblmathangban.ngaytao = new DateTime(1900, 1, 1); }

                        list.Add(objtblmathangban);
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
        /// Hàm lấy danh sách objtblmathangban
        /// </summary>
        /// <param name="recperpage">Số lượng bản ghi kiểu integer</param>
        /// <param name="pageindex">Số trang kiểu integer</param>
        /// <returns>Trả về List<<tblmathangban>></returns>
        public List<tblmathangban> GetListPaged(int recperpage, int pageindex)
        {
          List<tblmathangban> list = new List<tblmathangban>();
          string strFun = "fn_tblmathangban_getpaged";
          try
          {
              NpgsqlParameter[] prmArr = new NpgsqlParameter[2];
              prmArr[0] = new NpgsqlParameter("recperpage", NpgsqlDbType.Integer);
              prmArr[0].Value = recperpage;
              prmArr[1] = new NpgsqlParameter("pageindex", NpgsqlDbType.Integer);
              prmArr[1].Value = pageindex;
              DataSet dstblmathangban = mDataAccess.ExecuteDataSet(strFun, CommandType.StoredProcedure,prmArr);
              if ((dstblmathangban != null) && (dstblmathangban.Tables.Count > 0))
              {
                  for (int i = 0; i < dstblmathangban.Tables[0].Rows.Count; i++)
                  {
                        tblmathangban objtblmathangban = new tblmathangban();
                        DataRow dr = dstblmathangban.Tables[0].Rows[i];
                        objtblmathangban.id = dr["id"].ToString();

                        objtblmathangban.id_hoadon = dr["id_hoadon"].ToString();

                        objtblmathangban.id_mathang = dr["id_mathang"].ToString();

                        try{ objtblmathangban.soluong = Convert.ToInt32("0" + dr["soluong"].ToString());}
                        catch{ objtblmathangban.soluong = 0;}

                        try { objtblmathangban.giaban = Convert.ToDouble("0" + dr["giaban"].ToString());}
                        catch { objtblmathangban.giaban = 0; }

                        try { objtblmathangban.ngaytao = Convert.ToDateTime(dr["ngaytao"].ToString());}
                        catch { objtblmathangban.ngaytao = new DateTime(1900, 1, 1); }

                        list.Add(objtblmathangban);
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
        /// Hàm lấy danh sách objtblmathangban
        /// </summary>
        /// <param name="recperpage">Số lượng bản ghi kiểu integer</param>
        /// <param name="pageindex">Số trang kiểu integer</param>
        /// <returns>Trả về List<<tblmathangban>></returns>
        public DataTable GetDataTablePaged(int recperpage, int pageindex)
        {
          string strFun = "fn_tblmathangban_getpaged";
          try
          {
              NpgsqlParameter[] prmArr = new NpgsqlParameter[2];
              prmArr[0] = new NpgsqlParameter("recperpage", NpgsqlDbType.Integer);
              prmArr[0].Value = recperpage;
              prmArr[1] = new NpgsqlParameter("pageindex", NpgsqlDbType.Integer);
              prmArr[1].Value = pageindex;
              DataSet dstblmathangban = mDataAccess.ExecuteDataSet(strFun, CommandType.StoredProcedure,prmArr);
              return dstblmathangban.Tables[0];
          }
          catch
          {
              return null;
          }
        }
        #endregion
    }
}
