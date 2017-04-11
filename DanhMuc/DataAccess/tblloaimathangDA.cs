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
     /// Mô tả thông tin cho bảng tblloaimathang
     /// Cung cấp các hàm xử lý, thao tác với bảng tblloaimathang
     /// Người tạo (C): tuanva
     /// Ngày khởi tạo: 29/09/2015
     /// </summary>
    public class tblloaimathang
    {
        #region Private Variables
        private string strid;
        private string strkyhieu;
        private string strten;
        private string strghichu;
        #endregion

        #region Public Constructor Functions
        public tblloaimathang()
        {
            strid = string.Empty;
            strkyhieu = string.Empty;
            strten = string.Empty;
            strghichu = string.Empty;

        }

        public tblloaimathang(string strid, string strkyhieu, string strten, string strghichu)
        {
            this.strid = strid;
            this.strkyhieu = strkyhieu;
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

        public string kyhieu
        {
            get
            {
                return strkyhieu;
            }
            set
            {
                strkyhieu = value;
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
        /// Lấy toàn bộ dữ liệu từ bảng tblloaimathang
        /// </summary>
        /// <returns>DataTable</returns>
        public DataTable GetAll()
        {
            string strFun = "fn_tblloaimathang_getall";
            try
            {
                DataSet dstblloaimathang = mDataAccess.ExecuteDataSet(strFun, CommandType.StoredProcedure);
                return dstblloaimathang.Tables[0];
            }
            catch
            {
                return null;
            }
        }
        /// <summary>
        /// Hàm lấy tblloaimathang theo mã
        /// </summary>
        /// <returns>Trả về objtblloaimathang </returns>
        public tblloaimathang GetByID(string strid)
        {
            tblloaimathang objtblloaimathang = new tblloaimathang();
            string strFun = "fn_tblloaimathang_getobjbyid";
            try
            {
                NpgsqlParameter[] prmArr = new NpgsqlParameter[1];

                prmArr[0] = new NpgsqlParameter("id", NpgsqlDbType.Varchar);
                prmArr[0].Value = strid;

                DataSet dstblloaimathang = mDataAccess.ExecuteDataSet(strFun, CommandType.StoredProcedure, prmArr);

                if ((dstblloaimathang != null) && (dstblloaimathang.Tables.Count > 0))
                {
                    if (dstblloaimathang.Tables[0].Rows.Count > 0)
                    {
                        DataRow dr = dstblloaimathang.Tables[0].Rows[0];
                        objtblloaimathang.id = dr["id"].ToString();

                        objtblloaimathang.kyhieu = dr["kyhieu"].ToString();

                        objtblloaimathang.ten = dr["ten"].ToString();

                        objtblloaimathang.ghichu = dr["ghichu"].ToString();


                        return objtblloaimathang;
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
        /// Thêm mới dữ liệu vào bảng: tblloaimathang
        /// </summary>
        /// <param name="obj">objtblloaimathang</param>
        /// <returns>Trả về trắng: Thêm mới thành công; Trả về khác trắng: Thêm mới không thành công</returns>
        public string Insert(tblloaimathang objtblloaimathang)
        {
            string strProc = "fn_tblloaimathang_insert";
            try
            {
                NpgsqlParameter[] prmArr = new NpgsqlParameter[5];

                prmArr[0] = new NpgsqlParameter("id", NpgsqlDbType.Varchar);
                prmArr[0].Value = objtblloaimathang.strid;

                prmArr[1] = new NpgsqlParameter("kyhieu", NpgsqlDbType.Varchar);
                prmArr[1].Value = objtblloaimathang.strkyhieu;

                prmArr[2] = new NpgsqlParameter("ten", NpgsqlDbType.Varchar);
                prmArr[2].Value = objtblloaimathang.strten;

                prmArr[3] = new NpgsqlParameter("ghichu", NpgsqlDbType.Varchar);
                prmArr[3].Value = objtblloaimathang.strghichu;

                prmArr[4] = new NpgsqlParameter("ireturn", NpgsqlDbType.Text);
                prmArr[4].Direction = ParameterDirection.Output;

                mDataAccess.ExecuteQuery(strProc, CommandType.StoredProcedure, prmArr);

                string sKQ =  prmArr[4].Value.ToString().Trim(); 

                if (sKQ.ToUpper().Equals("Add".ToUpper()) == true) return "";
                return "Thêm mới dữ liệu không thành công";            }
            catch(Exception ex)
            {
                return "Thêm mới dữ liệu không thành công. Chi Tiết: " + ex.Message;
            }
        }
        /// <summary>
        /// Cập nhật dữ liệu vào bảng: tblloaimathang
        /// </summary>
        /// <param name="obj">objtblloaimathang</param>
        /// <returns>Trả về trắng: Cập nhật thành công; Trả về khác trắng: Cập nhật không thành công</returns>
        public string Update(tblloaimathang objtblloaimathang)
        {
            string strProc = "fn_tblloaimathang_Update";
            try
            {
                NpgsqlParameter[] prmArr = new NpgsqlParameter[5];

                prmArr[0] = new NpgsqlParameter("id", NpgsqlDbType.Varchar);
                prmArr[0].Value = objtblloaimathang.strid;

                prmArr[1] = new NpgsqlParameter("kyhieu", NpgsqlDbType.Varchar);
                prmArr[1].Value = objtblloaimathang.strkyhieu;

                prmArr[2] = new NpgsqlParameter("ten", NpgsqlDbType.Varchar);
                prmArr[2].Value = objtblloaimathang.strten;

                prmArr[3] = new NpgsqlParameter("ghichu", NpgsqlDbType.Varchar);
                prmArr[3].Value = objtblloaimathang.strghichu;

                prmArr[4] = new NpgsqlParameter("ireturn", NpgsqlDbType.Text);
                prmArr[4].Direction = ParameterDirection.Output;

                mDataAccess.ExecuteQuery(strProc, CommandType.StoredProcedure, prmArr);
                string sKQ = prmArr[4 ].Value.ToString().Trim();
                if (sKQ.ToUpper().Equals("Update".ToUpper()) == true) return "";
                return "Cập nhật dữ liệu không thành công";

            }
            catch(Exception ex)
            {
                return "Cập nhật dữ liệu không thành công. Chi Tiết: " + ex.Message;
            }
        }
        /// <summary>
        /// Xóa dữ liệu từ bảng tblloaimathang
        /// </summary>
        /// <returns></returns>
        public string Delete(string strid)
        {
            string strProc = "fn_tblloaimathang_delete";
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
        /// Hàm lấy tất cả dữ liệu trong bảng tblloaimathang
        /// </summary>
        /// <returns>Trả về List<<tblloaimathang>></returns>
        public List<tblloaimathang> GetList()
        {
          List<tblloaimathang> list = new List<tblloaimathang>();
          string strFun = "fn_tblloaimathang_getall";
          try
          {
              DataSet dstblloaimathang = mDataAccess.ExecuteDataSet(strFun, CommandType.StoredProcedure);
              if ((dstblloaimathang != null) && (dstblloaimathang.Tables.Count > 0))
              {
                  for (int i = 0; i < dstblloaimathang.Tables[0].Rows.Count; i++)
                  {
                        tblloaimathang objtblloaimathang = new tblloaimathang();
                        DataRow dr = dstblloaimathang.Tables[0].Rows[i];
                        objtblloaimathang.id = dr["id"].ToString();

                        objtblloaimathang.kyhieu = dr["kyhieu"].ToString();

                        objtblloaimathang.ten = dr["ten"].ToString();

                        objtblloaimathang.ghichu = dr["ghichu"].ToString();

                        list.Add(objtblloaimathang);
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
        /// Hàm lấy danh sách objtblloaimathang
        /// </summary>
        /// <param name="recperpage">Số lượng bản ghi kiểu integer</param>
        /// <param name="pageindex">Số trang kiểu integer</param>
        /// <returns>Trả về List<<tblloaimathang>></returns>
        public List<tblloaimathang> GetListPaged(int recperpage, int pageindex)
        {
          List<tblloaimathang> list = new List<tblloaimathang>();
          string strFun = "fn_tblloaimathang_getpaged";
          try
          {
              NpgsqlParameter[] prmArr = new NpgsqlParameter[2];
              prmArr[0] = new NpgsqlParameter("recperpage", NpgsqlDbType.Integer);
              prmArr[0].Value = recperpage;
              prmArr[1] = new NpgsqlParameter("pageindex", NpgsqlDbType.Integer);
              prmArr[1].Value = pageindex;
              DataSet dstblloaimathang = mDataAccess.ExecuteDataSet(strFun, CommandType.StoredProcedure,prmArr);
              if ((dstblloaimathang != null) && (dstblloaimathang.Tables.Count > 0))
              {
                  for (int i = 0; i < dstblloaimathang.Tables[0].Rows.Count; i++)
                  {
                        tblloaimathang objtblloaimathang = new tblloaimathang();
                        DataRow dr = dstblloaimathang.Tables[0].Rows[i];
                        objtblloaimathang.id = dr["id"].ToString();

                        objtblloaimathang.kyhieu = dr["kyhieu"].ToString();

                        objtblloaimathang.ten = dr["ten"].ToString();

                        objtblloaimathang.ghichu = dr["ghichu"].ToString();

                        list.Add(objtblloaimathang);
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
        /// Hàm lấy danh sách objtblloaimathang
        /// </summary>
        /// <param name="recperpage">Số lượng bản ghi kiểu integer</param>
        /// <param name="pageindex">Số trang kiểu integer</param>
        /// <returns>Trả về List<<tblloaimathang>></returns>
        public DataTable GetDataTablePaged(int recperpage, int pageindex)
        {
          string strFun = "fn_tblloaimathang_getpaged";
          try
          {
              NpgsqlParameter[] prmArr = new NpgsqlParameter[2];
              prmArr[0] = new NpgsqlParameter("recperpage", NpgsqlDbType.Integer);
              prmArr[0].Value = recperpage;
              prmArr[1] = new NpgsqlParameter("pageindex", NpgsqlDbType.Integer);
              prmArr[1].Value = pageindex;
              DataSet dstblloaimathang = mDataAccess.ExecuteDataSet(strFun, CommandType.StoredProcedure,prmArr);
              return dstblloaimathang.Tables[0];
          }
          catch
          {
              return null;
          }
        }
        /// <summary>
        /// Hàm kiểm tra trùng tên và ký hiệu
        /// </summary>
        /// <param name="sid">Mã loại mặt hàng</param>
        /// <param name="skyhieu">Ký hiệu loại mặt hàng</param>
        /// <param name="sten">Tên loại mặt hàng</param>
        /// <returns>bool: False-Không tồn tại;True-Có tồn tại</returns>
        public bool CheckExit(string sid, string skyhieu, string sten)
        {
            string strProc = "fn_tblloaimathang_checkexit";
            try
            {
                NpgsqlParameter[] prmArr = new NpgsqlParameter[4];
                prmArr[0] = new NpgsqlParameter("id", NpgsqlDbType.Varchar);
                prmArr[0].Value = sid;
                prmArr[1] = new NpgsqlParameter("kyhieu", NpgsqlDbType.Varchar);
                prmArr[1].Value = skyhieu;
                prmArr[2] = new NpgsqlParameter("ten", NpgsqlDbType.Varchar);
                prmArr[2].Value = sten;
                prmArr[3] = new NpgsqlParameter("ireturn", NpgsqlDbType.Text);
                prmArr[3].Direction = ParameterDirection.Output;
                mDataAccess.ExecuteQuery(strProc, CommandType.StoredProcedure, prmArr);
                string sKQ = prmArr[3].Value.ToString().Trim();
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
