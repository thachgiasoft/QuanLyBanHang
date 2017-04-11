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
     /// Mô tả thông tin cho bảng nhacungcap
     /// Cung cấp các hàm xử lý, thao tác với bảng nhacungcap
     /// Người tạo (C): 
     /// Ngày khởi tạo: 16/03/2016
     /// </summary>
    public class nhacungcap
    {
        #region Private Variables
        private string strid;
        private string strten;
        private string strdiachi;
        private string strdienthoai;
        private string strghichu;
        private int intdaxoa;
        #endregion

        #region Public Constructor Functions
        public nhacungcap()
        {
            strid = string.Empty;
            strten = string.Empty;
            strdiachi = string.Empty;
            strdienthoai = string.Empty;
            strghichu = string.Empty;
            intdaxoa = 0;

        }

        public nhacungcap(string strid, string strten, string strdiachi, string strdienthoai, string strghichu, int intdaxoa)
        {
            this.strid = strid;
            this.strten = strten;
            this.strdiachi = strdiachi;
            this.strdienthoai = strdienthoai;
            this.strghichu = strghichu;
            this.intdaxoa = intdaxoa;
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

        public string dienthoai
        {
            get
            {
                return strdienthoai;
            }
            set
            {
                strdienthoai = value;
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

        public int daxoa
        {
            get
            {
                return intdaxoa;
            }
            set
            {
                intdaxoa = value;
            }
        }
        #endregion

        #region Public Method
        private readonly CGCN.Framework.DataAccessLayerBaseClass mDataAccess = new DataAccessLayerBaseClass(Data.ConnectionString);
        /// <summary>
        /// Lấy toàn bộ dữ liệu từ bảng nhacungcap
        /// </summary>
        /// <returns>DataTable</returns>
        public DataTable GetAll()
        {
            string strFun = "fn_nhacungcap_getall";
            try
            {
                DataSet dsnhacungcap = mDataAccess.ExecuteDataSet(strFun, CommandType.StoredProcedure);
                return dsnhacungcap.Tables[0];
            }
            catch
            {
                return null;
            }
        }
        /// <summary>
        /// Hàm lấy nhacungcap theo mã
        /// </summary>
        /// <returns>Trả về objnhacungcap </returns>
        public nhacungcap GetByID(string strid)
        {
            nhacungcap objnhacungcap = new nhacungcap();
            string strFun = "fn_nhacungcap_getobjbyid";
            try
            {
                NpgsqlParameter[] prmArr = new NpgsqlParameter[1];

                prmArr[0] = new NpgsqlParameter("id", NpgsqlDbType.Varchar);
                prmArr[0].Value = strid;

                DataSet dsnhacungcap = mDataAccess.ExecuteDataSet(strFun, CommandType.StoredProcedure, prmArr);

                if ((dsnhacungcap != null) && (dsnhacungcap.Tables.Count > 0))
                {
                    if (dsnhacungcap.Tables[0].Rows.Count > 0)
                    {
                        DataRow dr = dsnhacungcap.Tables[0].Rows[0];
                        objnhacungcap.id = dr["id"].ToString();

                        objnhacungcap.ten = dr["ten"].ToString();

                        objnhacungcap.diachi = dr["diachi"].ToString();

                        objnhacungcap.dienthoai = dr["dienthoai"].ToString();

                        objnhacungcap.ghichu = dr["ghichu"].ToString();

                        try{ objnhacungcap.daxoa = Convert.ToInt32("0" + dr["daxoa"].ToString());}
                        catch{ objnhacungcap.daxoa = 0;}


                        return objnhacungcap;
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
        /// Thêm mới dữ liệu vào bảng: nhacungcap
        /// </summary>
        /// <param name="obj">objnhacungcap</param>
        /// <returns>Trả về trắng: Thêm mới thành công; Trả về khác trắng: Thêm mới không thành công</returns>
        public string Insert(nhacungcap objnhacungcap)
        {
            string strProc = "fn_nhacungcap_insert";
            try
            {
                NpgsqlParameter[] prmArr = new NpgsqlParameter[7];

                prmArr[0] = new NpgsqlParameter("id", NpgsqlDbType.Varchar);
                prmArr[0].Value = objnhacungcap.strid;

                prmArr[1] = new NpgsqlParameter("ten", NpgsqlDbType.Varchar);
                prmArr[1].Value = objnhacungcap.strten;

                prmArr[2] = new NpgsqlParameter("diachi", NpgsqlDbType.Varchar);
                prmArr[2].Value = objnhacungcap.strdiachi;

                prmArr[3] = new NpgsqlParameter("dienthoai", NpgsqlDbType.Varchar);
                prmArr[3].Value = objnhacungcap.strdienthoai;

                prmArr[4] = new NpgsqlParameter("ghichu", NpgsqlDbType.Varchar);
                prmArr[4].Value = objnhacungcap.strghichu;

                prmArr[5] = new NpgsqlParameter("daxoa", NpgsqlDbType.Integer);
                prmArr[5].Value = objnhacungcap.intdaxoa;

                prmArr[6] = new NpgsqlParameter("ireturn", NpgsqlDbType.Text);
                prmArr[6].Direction = ParameterDirection.Output;

                mDataAccess.ExecuteQuery(strProc, CommandType.StoredProcedure, prmArr);

                string sKQ =  prmArr[6].Value.ToString().Trim(); 

                if (sKQ.ToUpper().Equals("Add".ToUpper()) == true) return "";
                return "Thêm mới dữ liệu không thành công";            }
            catch(Exception ex)
            {
                return "Thêm mới dữ liệu không thành công. Chi Tiết: " + ex.Message;
            }
        }
        /// <summary>
        /// Cập nhật dữ liệu vào bảng: nhacungcap
        /// </summary>
        /// <param name="obj">objnhacungcap</param>
        /// <returns>Trả về trắng: Cập nhật thành công; Trả về khác trắng: Cập nhật không thành công</returns>
        public string Update(nhacungcap objnhacungcap)
        {
            string strProc = "fn_nhacungcap_Update";
            try
            {
                NpgsqlParameter[] prmArr = new NpgsqlParameter[7];

                prmArr[0] = new NpgsqlParameter("id", NpgsqlDbType.Varchar);
                prmArr[0].Value = objnhacungcap.strid;

                prmArr[1] = new NpgsqlParameter("ten", NpgsqlDbType.Varchar);
                prmArr[1].Value = objnhacungcap.strten;

                prmArr[2] = new NpgsqlParameter("diachi", NpgsqlDbType.Varchar);
                prmArr[2].Value = objnhacungcap.strdiachi;

                prmArr[3] = new NpgsqlParameter("dienthoai", NpgsqlDbType.Varchar);
                prmArr[3].Value = objnhacungcap.strdienthoai;

                prmArr[4] = new NpgsqlParameter("ghichu", NpgsqlDbType.Varchar);
                prmArr[4].Value = objnhacungcap.strghichu;

                prmArr[5] = new NpgsqlParameter("daxoa", NpgsqlDbType.Integer);
                prmArr[5].Value = objnhacungcap.intdaxoa;

                prmArr[6] = new NpgsqlParameter("ireturn", NpgsqlDbType.Text);
                prmArr[6].Direction = ParameterDirection.Output;

                mDataAccess.ExecuteQuery(strProc, CommandType.StoredProcedure, prmArr);
                string sKQ = prmArr[6 ].Value.ToString().Trim();
                if (sKQ.ToUpper().Equals("Update".ToUpper()) == true) return "";
                return "Cập nhật dữ liệu không thành công";

            }
            catch(Exception ex)
            {
                return "Cập nhật dữ liệu không thành công. Chi Tiết: " + ex.Message;
            }
        }
        /// <summary>
        /// Xóa dữ liệu từ bảng nhacungcap
        /// </summary>
        /// <returns>Trả về trắng: Cập nhật thành công; Trả về khác trắng: Cập nhật không thành công</returns>
        public string Delete(string strid)
        {
            string strProc = "fn_nhacungcap_delete";
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
        /// Hàm lấy tất cả dữ liệu trong bảng nhacungcap
        /// </summary>
        /// <returns>Trả về List<<nhacungcap>></returns>
        public List<nhacungcap> GetList()
        {
          List<nhacungcap> list = new List<nhacungcap>();
          string strFun = "fn_nhacungcap_getall";
          try
          {
              DataSet dsnhacungcap = mDataAccess.ExecuteDataSet(strFun, CommandType.StoredProcedure);
              if ((dsnhacungcap != null) && (dsnhacungcap.Tables.Count > 0))
              {
                  for (int i = 0; i < dsnhacungcap.Tables[0].Rows.Count; i++)
                  {
                        nhacungcap objnhacungcap = new nhacungcap();
                        DataRow dr = dsnhacungcap.Tables[0].Rows[i];
                        objnhacungcap.id = dr["id"].ToString();

                        objnhacungcap.ten = dr["ten"].ToString();

                        objnhacungcap.diachi = dr["diachi"].ToString();

                        objnhacungcap.dienthoai = dr["dienthoai"].ToString();

                        objnhacungcap.ghichu = dr["ghichu"].ToString();

                        try{ objnhacungcap.daxoa = Convert.ToInt32("0" + dr["daxoa"].ToString());}
                        catch{ objnhacungcap.daxoa = 0;}

                        list.Add(objnhacungcap);
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
        /// Hàm lấy danh sách objnhacungcap
        /// </summary>
        /// <param name="recperpage">Số lượng bản ghi kiểu integer</param>
        /// <param name="pageindex">Số trang kiểu integer</param>
        /// <returns>Trả về List<<nhacungcap>></returns>
        public List<nhacungcap> GetListPaged(int recperpage, int pageindex)
        {
          List<nhacungcap> list = new List<nhacungcap>();
          string strFun = "fn_nhacungcap_getpaged";
          try
          {
              NpgsqlParameter[] prmArr = new NpgsqlParameter[2];
              prmArr[0] = new NpgsqlParameter("recperpage", NpgsqlDbType.Integer);
              prmArr[0].Value = recperpage;
              prmArr[1] = new NpgsqlParameter("pageindex", NpgsqlDbType.Integer);
              prmArr[1].Value = pageindex;
              DataSet dsnhacungcap = mDataAccess.ExecuteDataSet(strFun, CommandType.StoredProcedure,prmArr);
              if ((dsnhacungcap != null) && (dsnhacungcap.Tables.Count > 0))
              {
                  for (int i = 0; i < dsnhacungcap.Tables[0].Rows.Count; i++)
                  {
                        nhacungcap objnhacungcap = new nhacungcap();
                        DataRow dr = dsnhacungcap.Tables[0].Rows[i];
                        objnhacungcap.id = dr["id"].ToString();

                        objnhacungcap.ten = dr["ten"].ToString();

                        objnhacungcap.diachi = dr["diachi"].ToString();

                        objnhacungcap.dienthoai = dr["dienthoai"].ToString();

                        objnhacungcap.ghichu = dr["ghichu"].ToString();

                        try{ objnhacungcap.daxoa = Convert.ToInt32("0" + dr["daxoa"].ToString());}
                        catch{ objnhacungcap.daxoa = 0;}

                        list.Add(objnhacungcap);
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
        /// Hàm lấy danh sách objnhacungcap
        /// </summary>
        /// <param name="recperpage">Số lượng bản ghi kiểu integer</param>
        /// <param name="pageindex">Số trang kiểu integer</param>
        /// <returns>Trả về List<<nhacungcap>></returns>
        public DataTable GetDataTablePaged(int recperpage, int pageindex)
        {
          string strFun = "fn_nhacungcap_getpaged";
          try
          {
              NpgsqlParameter[] prmArr = new NpgsqlParameter[2];
              prmArr[0] = new NpgsqlParameter("recperpage", NpgsqlDbType.Integer);
              prmArr[0].Value = recperpage;
              prmArr[1] = new NpgsqlParameter("pageindex", NpgsqlDbType.Integer);
              prmArr[1].Value = pageindex;
              DataSet dsnhacungcap = mDataAccess.ExecuteDataSet(strFun, CommandType.StoredProcedure,prmArr);
              return dsnhacungcap.Tables[0];
          }
          catch
          {
              return null;
          }
        }
        /// <summary>
        /// Hàm tìm kiếm nhà cung cấp
        /// </summary>
        /// <param name="skeyword">Từ khóa type string</param>
        /// <returns>DataTable</returns>
        public DataTable Filter(string skeyword)
        {
            string strFun = "fn_nhacungcap_filter";
            try
            {
                NpgsqlParameter[] prmArr = new NpgsqlParameter[1];
                prmArr[0] = new NpgsqlParameter("ikeyword", NpgsqlDbType.Text);
                prmArr[0].Value = skeyword;
                DataSet dstblkhachhang = mDataAccess.ExecuteDataSet(strFun, CommandType.StoredProcedure, prmArr);
                return dstblkhachhang.Tables[0];
            }
            catch
            {
                return null;
            }
        }
        /// <summary>
        /// Hàm lấy tất cả danh sách nhà cung cấp đã có hóa đơn nhập hàng
        /// </summary>
        /// <returns>DataTable</returns>
        public DataTable GetByPhieuNhap()
        {
            string strFun = "fn_nhacungcap_getbyphieunhap";
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
        #endregion
    }
}
