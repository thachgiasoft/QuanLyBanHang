using System;
using System.Data;
using System.Collections.Generic;
using System.Text;
using Npgsql;
using NpgsqlTypes;
using CGCN.Framework;
using CGCN.DataAccess;

namespace DanhMuc.DataAccess
{
     /// <summary>
     /// Mô tả thông tin cho bảng tblmathang
     /// Cung cấp các hàm xử lý, thao tác với bảng tblmathang
     /// Người tạo (C): tuanva
     /// Ngày khởi tạo: 16/08/2015
     /// </summary>
    public class tblmathang
    {
        #region Private Variables
        private string strid;
        private string strid_hangsx;
        private string strid_loai;
        private string strten;
        private double dblgianhap;
        private int intsoluong;
        private string strdonvi;
        private string strghichu;
        private double dblgiabanbuon;
        private double dblgiabanle;
        private double dblgiadl1;
        private double dblgiadl2;
        private double dblgiadl3;
        private double dblgiadl4;
        private double dblgiadl5;
        private string strtenkhongdau;
        private DateTime dtmngaynhap;
        private string struserid;
        private string strmavach;
        private double dbgiamua;
        private double dbgiavanchuyen;
        #endregion

        #region Public Constructor Functions
        public tblmathang()
        {
            strid = string.Empty;
            strid_hangsx = string.Empty;
            strid_loai = string.Empty;
            strten = string.Empty;
            dblgianhap = 0;
            intsoluong = 0;
            strdonvi = string.Empty;
            strghichu = string.Empty;
            dblgiabanbuon = 0;
            dblgiabanle = 0;
            dblgiadl1 = 0;
            dblgiadl2 = 0;
            dblgiadl3 = 0;
            dblgiadl4 = 0;
            dblgiadl5 = 0;
            strtenkhongdau = string.Empty;
            dtmngaynhap = DateTime.Now;
            struserid = string.Empty;
            strmavach = string.Empty;
            dbgiamua = 0;
            dbgiavanchuyen = 0;
        }

        public tblmathang(string strid, string strid_hangsx, string strid_loai, string strten, double dblgianhap, int intsoluong, string strdonvi, string strghichu, double dblgiabanbuon, double dblgiabanle, double dblgiadl1, double dblgiadl2, double dblgiadl3, double dblgiadl4, double dblgiadl5, string strtenkhongdau, DateTime dtmngaynhap, string struserid,string strmavach,double giamua,double giavanchuyen)
        {
            this.strid = strid;
            this.strid_hangsx = strid_hangsx;
            this.strid_loai = strid_loai;
            this.strten = strten;
            this.dblgianhap = dblgianhap;
            this.intsoluong = intsoluong;
            this.strdonvi = strdonvi;
            this.strghichu = strghichu;
            this.dblgiabanbuon = dblgiabanbuon;
            this.dblgiabanle = dblgiabanle;
            this.dblgiadl1 = dblgiadl1;
            this.dblgiadl2 = dblgiadl2;
            this.dblgiadl3 = dblgiadl3;
            this.dblgiadl4 = dblgiadl4;
            this.dblgiadl5 = dblgiadl5;
            this.strtenkhongdau = strtenkhongdau;
            this.dtmngaynhap = dtmngaynhap;
            this.struserid = struserid;
            this.strmavach = strmavach;
            this.dbgiamua = giamua;
            this.dbgiavanchuyen = giavanchuyen;
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

        public string mavach
        {
            get
            {
                return strmavach;
            }
            set
            {
                strmavach = value;
            }
        }

        public string id_hangsx
        {
            get
            {
                return strid_hangsx;
            }
            set
            {
                strid_hangsx = value;
            }
        }

        public string id_loai
        {
            get
            {
                return strid_loai;
            }
            set
            {
                strid_loai = value;
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

        public double gianhap
        {
            get
            {
                return dblgianhap;
            }
            set
            {
                dblgianhap = value;
            }
        }

        public double giamua
        {
            get
            {
                return dbgiamua;
            }
            set
            {
                dbgiamua = value;
            }
        }

        public double giavanchuyen
        {
            get
            {
                return dbgiavanchuyen;
            }
            set
            {
                dbgiavanchuyen = value;
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

        public string donvi
        {
            get
            {
                return strdonvi;
            }
            set
            {
                strdonvi = value;
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

        public double giabanbuon
        {
            get
            {
                return dblgiabanbuon;
            }
            set
            {
                dblgiabanbuon = value;
            }
        }

        public double giabanle
        {
            get
            {
                return dblgiabanle;
            }
            set
            {
                dblgiabanle = value;
            }
        }

        public double giadl1
        {
            get
            {
                return dblgiadl1;
            }
            set
            {
                dblgiadl1 = value;
            }
        }

        public double giadl2
        {
            get
            {
                return dblgiadl2;
            }
            set
            {
                dblgiadl2 = value;
            }
        }

        public double giadl3
        {
            get
            {
                return dblgiadl3;
            }
            set
            {
                dblgiadl3 = value;
            }
        }

        public double giadl4
        {
            get
            {
                return dblgiadl4;
            }
            set
            {
                dblgiadl4 = value;
            }
        }

        public double giadl5
        {
            get
            {
                return dblgiadl5;
            }
            set
            {
                dblgiadl5 = value;
            }
        }

        public string tenkhongdau
        {
            get
            {
                return strtenkhongdau;
            }
            set
            {
                strtenkhongdau = value;
            }
        }

        public DateTime ngaynhap
        {
            get
            {
                return dtmngaynhap;
            }
            set
            {
                dtmngaynhap = value;
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
        /// Lấy toàn bộ dữ liệu từ bảng tblmathang
        /// </summary>
        /// <returns>DataTable</returns>
        public DataTable GetAll()
        {
            string strFun = "fn_tblmathang_getall";
            try
            {
                DataSet dstblmathang = mDataAccess.ExecuteDataSet(strFun, CommandType.StoredProcedure);
                return dstblmathang.Tables[0];
            }
            catch
            {
                return null;
            }
        }
        /// <summary>
        /// Hàm chỉ load tên mặt hàng lên combobox
        /// </summary>
        /// <returns>DataTable</returns>
        public DataTable LoadCB()
        {
            string strFun = "fn_tblmathang_getname";
            try
            {
                DataSet dstblmathang = mDataAccess.ExecuteDataSet(strFun, CommandType.StoredProcedure);
                return dstblmathang.Tables[0];
            }
            catch
            {
                return null;
            }
        }
        /// <summary>
        /// Hàm lấy tblmathang theo mã
        /// </summary>
        /// <returns>Trả về objtblmathang </returns>
        public tblmathang GetByID(string strid)
        {
            tblmathang objtblmathang = new tblmathang();
            string strFun = "fn_tblmathang_getobjbyid";
            try
            {
                NpgsqlParameter[] prmArr = new NpgsqlParameter[1];

                prmArr[0] = new NpgsqlParameter("id", NpgsqlDbType.Varchar);
                prmArr[0].Value = strid;

                DataSet dstblmathang = mDataAccess.ExecuteDataSet(strFun, CommandType.StoredProcedure, prmArr);

                if ((dstblmathang != null) && (dstblmathang.Tables.Count > 0))
                {
                    if (dstblmathang.Tables[0].Rows.Count > 0)
                    {
                        DataRow dr = dstblmathang.Tables[0].Rows[0];
                        objtblmathang.id = dr["id"].ToString();

                        objtblmathang.id_hangsx = dr["id_hangsx"].ToString();

                        objtblmathang.id_loai = dr["id_loai"].ToString();

                        objtblmathang.ten = dr["ten"].ToString();

                        try { objtblmathang.gianhap = Convert.ToDouble("0" + dr["gianhap"].ToString());}
                        catch { objtblmathang.gianhap = 0; }

                        try{ objtblmathang.soluong = Convert.ToInt32("0" + dr["soluong"].ToString());}
                        catch{ objtblmathang.soluong = 0;}

                        objtblmathang.donvi = dr["donvi"].ToString();

                        objtblmathang.ghichu = dr["ghichu"].ToString();

                        try { objtblmathang.giabanbuon = Convert.ToDouble("0" + dr["giabanbuon"].ToString());}
                        catch { objtblmathang.giabanbuon = 0; }

                        try { objtblmathang.giabanle = Convert.ToDouble("0" + dr["giabanle"].ToString());}
                        catch { objtblmathang.giabanle = 0; }

                        try { objtblmathang.giadl1 = Convert.ToDouble("0" + dr["giadl1"].ToString());}
                        catch { objtblmathang.giadl1 = 0; }

                        try { objtblmathang.giadl2 = Convert.ToDouble("0" + dr["giadl2"].ToString());}
                        catch { objtblmathang.giadl2 = 0; }

                        try { objtblmathang.giadl3 = Convert.ToDouble("0" + dr["giadl3"].ToString());}
                        catch { objtblmathang.giadl3 = 0; }

                        try { objtblmathang.giadl4 = Convert.ToDouble("0" + dr["giadl4"].ToString());}
                        catch { objtblmathang.giadl4 = 0; }

                        try { objtblmathang.giadl5 = Convert.ToDouble("0" + dr["giadl5"].ToString());}
                        catch { objtblmathang.giadl5 = 0; }

                        objtblmathang.tenkhongdau = dr["tenkhongdau"].ToString();

                        try { objtblmathang.ngaynhap = Convert.ToDateTime(dr["ngaynhap"].ToString());}
                        catch { objtblmathang.ngaynhap = new DateTime(1900, 1, 1); }

                        objtblmathang.userid = dr["userid"].ToString();


                        return objtblmathang;
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
        /// Thêm mới dữ liệu vào bảng: tblmathang
        /// </summary>
        /// <param name="obj">objtblmathang</param>
        /// <returns>Trả về trắng: Thêm mới thành công; Trả về khác trắng: Thêm mới không thành công</returns>
        public string Insert(tblmathang objtblmathang)
        {
            string strProc = "fn_tblmathang_insert";
            try
            {
                NpgsqlParameter[] prmArr = new NpgsqlParameter[21];

                prmArr[0] = new NpgsqlParameter("id", NpgsqlDbType.Varchar);
                prmArr[0].Value = objtblmathang.strid;

                prmArr[1] = new NpgsqlParameter("id_hangsx", NpgsqlDbType.Varchar);
                prmArr[1].Value = objtblmathang.strid_hangsx;

                prmArr[2] = new NpgsqlParameter("id_loai", NpgsqlDbType.Varchar);
                prmArr[2].Value = objtblmathang.strid_loai;

                prmArr[3] = new NpgsqlParameter("ten", NpgsqlDbType.Varchar);
                prmArr[3].Value = objtblmathang.strten;

                prmArr[4] = new NpgsqlParameter("gianhap", NpgsqlDbType.Double);
                prmArr[4].Value = objtblmathang.dblgianhap;

                prmArr[5] = new NpgsqlParameter("soluong", NpgsqlDbType.Integer);
                prmArr[5].Value = objtblmathang.intsoluong;

                prmArr[6] = new NpgsqlParameter("donvi", NpgsqlDbType.Varchar);
                prmArr[6].Value = objtblmathang.strdonvi;

                prmArr[7] = new NpgsqlParameter("ghichu", NpgsqlDbType.Varchar);
                prmArr[7].Value = objtblmathang.strghichu;

                prmArr[8] = new NpgsqlParameter("giabanbuon", NpgsqlDbType.Double);
                prmArr[8].Value = objtblmathang.dblgiabanbuon;

                prmArr[9] = new NpgsqlParameter("giabanle", NpgsqlDbType.Double);
                prmArr[9].Value = objtblmathang.dblgiabanle;

                prmArr[10] = new NpgsqlParameter("giadl1", NpgsqlDbType.Double);
                prmArr[10].Value = objtblmathang.dblgiadl1;

                prmArr[11] = new NpgsqlParameter("giadl2", NpgsqlDbType.Double);
                prmArr[11].Value = objtblmathang.dblgiadl2;

                prmArr[12] = new NpgsqlParameter("giadl3", NpgsqlDbType.Double);
                prmArr[12].Value = objtblmathang.dblgiadl3;

                prmArr[13] = new NpgsqlParameter("giadl4", NpgsqlDbType.Double);
                prmArr[13].Value = objtblmathang.dblgiadl4;

                prmArr[14] = new NpgsqlParameter("giadl5", NpgsqlDbType.Double);
                prmArr[14].Value = objtblmathang.dblgiadl5;

                prmArr[15] = new NpgsqlParameter("tenkhongdau", NpgsqlDbType.Text);
                prmArr[15].Value = objtblmathang.strtenkhongdau;

                prmArr[16] = new NpgsqlParameter("userid", NpgsqlDbType.Varchar);
                prmArr[16].Value = objtblmathang.struserid;

                prmArr[17] = new NpgsqlParameter("mavach", NpgsqlDbType.Text);
                prmArr[17].Value = objtblmathang.strmavach;

                prmArr[18] = new NpgsqlParameter("giamua", NpgsqlDbType.Double);
                prmArr[18].Value = objtblmathang.dbgiamua;

                prmArr[19] = new NpgsqlParameter("giavanchuyen", NpgsqlDbType.Double);
                prmArr[19].Value = objtblmathang.dblgiadl5;

                prmArr[20] = new NpgsqlParameter("ireturn", NpgsqlDbType.Text);
                prmArr[20].Direction = ParameterDirection.Output;

                mDataAccess.ExecuteQuery(strProc, CommandType.StoredProcedure, prmArr);

                string sKQ =  prmArr[20].Value.ToString().Trim(); 

                if (sKQ.ToUpper().Equals("Add".ToUpper()) == true) return "";
                return "Thêm mới dữ liệu không thành công";            }
            catch(Exception ex)
            {
                return "Thêm mới dữ liệu không thành công. Chi Tiết: " + ex.Message;
            }
        }
        /// <summary>
        /// Cập nhật dữ liệu vào bảng: tblmathang
        /// </summary>
        /// <param name="obj">objtblmathang</param>
        /// <returns>Trả về trắng: Cập nhật thành công; Trả về khác trắng: Cập nhật không thành công</returns>
        public string Update(tblmathang objtblmathang)
        {
            string strProc = "fn_tblmathang_Update";
            try
            {
                NpgsqlParameter[] prmArr = new NpgsqlParameter[21];

                prmArr[0] = new NpgsqlParameter("id", NpgsqlDbType.Varchar);
                prmArr[0].Value = objtblmathang.strid;

                prmArr[1] = new NpgsqlParameter("id_hangsx", NpgsqlDbType.Varchar);
                prmArr[1].Value = objtblmathang.strid_hangsx;

                prmArr[2] = new NpgsqlParameter("id_loai", NpgsqlDbType.Varchar);
                prmArr[2].Value = objtblmathang.strid_loai;

                prmArr[3] = new NpgsqlParameter("ten", NpgsqlDbType.Varchar);
                prmArr[3].Value = objtblmathang.strten;

                prmArr[4] = new NpgsqlParameter("gianhap", NpgsqlDbType.Double);
                prmArr[4].Value = objtblmathang.dblgianhap;

                prmArr[5] = new NpgsqlParameter("soluong", NpgsqlDbType.Integer);
                prmArr[5].Value = objtblmathang.intsoluong;

                prmArr[6] = new NpgsqlParameter("donvi", NpgsqlDbType.Varchar);
                prmArr[6].Value = objtblmathang.strdonvi;

                prmArr[7] = new NpgsqlParameter("ghichu", NpgsqlDbType.Varchar);
                prmArr[7].Value = objtblmathang.strghichu;

                prmArr[8] = new NpgsqlParameter("giabanbuon", NpgsqlDbType.Double);
                prmArr[8].Value = objtblmathang.dblgiabanbuon;

                prmArr[9] = new NpgsqlParameter("giabanle", NpgsqlDbType.Double);
                prmArr[9].Value = objtblmathang.dblgiabanle;

                prmArr[10] = new NpgsqlParameter("giadl1", NpgsqlDbType.Double);
                prmArr[10].Value = objtblmathang.dblgiadl1;

                prmArr[11] = new NpgsqlParameter("giadl2", NpgsqlDbType.Double);
                prmArr[11].Value = objtblmathang.dblgiadl2;

                prmArr[12] = new NpgsqlParameter("giadl3", NpgsqlDbType.Double);
                prmArr[12].Value = objtblmathang.dblgiadl3;

                prmArr[13] = new NpgsqlParameter("giadl4", NpgsqlDbType.Double);
                prmArr[13].Value = objtblmathang.dblgiadl4;

                prmArr[14] = new NpgsqlParameter("giadl5", NpgsqlDbType.Double);
                prmArr[14].Value = objtblmathang.dblgiadl5;

                prmArr[15] = new NpgsqlParameter("tenkhongdau", NpgsqlDbType.Text);
                prmArr[15].Value = objtblmathang.strtenkhongdau;

                prmArr[16] = new NpgsqlParameter("userid", NpgsqlDbType.Varchar);
                prmArr[16].Value = objtblmathang.struserid;

                prmArr[17] = new NpgsqlParameter("mavach", NpgsqlDbType.Varchar);
                prmArr[17].Value = objtblmathang.strmavach;

                prmArr[18] = new NpgsqlParameter("giamua", NpgsqlDbType.Double);
                prmArr[18].Value = objtblmathang.dbgiamua;

                prmArr[19] = new NpgsqlParameter("giavanchuyen", NpgsqlDbType.Double);
                prmArr[19].Value = objtblmathang.dbgiavanchuyen;

                prmArr[20] = new NpgsqlParameter("ireturn", NpgsqlDbType.Text);
                prmArr[20].Direction = ParameterDirection.Output;

                mDataAccess.ExecuteQuery(strProc, CommandType.StoredProcedure, prmArr);
                string sKQ = prmArr[20].Value.ToString().Trim();
                if (sKQ.ToUpper().Equals("Update".ToUpper()) == true) return "";
                return "Cập nhật dữ liệu không thành công";
            }
            catch (Exception ex)
            {
                return "Cập nhật dữ liệu không thành công. Chi Tiết: " + ex.Message;
            }
        }
        /// <summary>
        /// Xóa dữ liệu từ bảng tblmathang
        /// </summary>
        /// <returns></returns>
        public string Delete(string strid)
        {
            string strProc = "fn_tblmathang_delete";
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
        /// Hàm lấy tất cả dữ liệu trong bảng tblmathang
        /// </summary>
        /// <returns>Trả về List<<tblmathang>></returns>
        public List<tblmathang> GetList()
        {
          List<tblmathang> list = new List<tblmathang>();
          string strFun = "fn_tblmathang_getall";
          try
          {
              DataSet dstblmathang = mDataAccess.ExecuteDataSet(strFun, CommandType.StoredProcedure);
              if ((dstblmathang != null) && (dstblmathang.Tables.Count > 0))
              {
                  for (int i = 0; i < dstblmathang.Tables[0].Rows.Count; i++)
                  {
                        tblmathang objtblmathang = new tblmathang();
                        DataRow dr = dstblmathang.Tables[0].Rows[i];
                        objtblmathang.id = dr["id"].ToString();

                        objtblmathang.id_hangsx = dr["id_hangsx"].ToString();

                        objtblmathang.id_loai = dr["id_loai"].ToString();

                        objtblmathang.ten = dr["ten"].ToString();

                        try { objtblmathang.gianhap = Convert.ToDouble("0" + dr["gianhap"].ToString());}
                        catch { objtblmathang.gianhap = 0; }

                        try{ objtblmathang.soluong = Convert.ToInt32("0" + dr["soluong"].ToString());}
                        catch{ objtblmathang.soluong = 0;}

                        objtblmathang.donvi = dr["donvi"].ToString();

                        objtblmathang.ghichu = dr["ghichu"].ToString();

                        try { objtblmathang.giabanbuon = Convert.ToDouble("0" + dr["giabanbuon"].ToString());}
                        catch { objtblmathang.giabanbuon = 0; }

                        try { objtblmathang.giabanle = Convert.ToDouble("0" + dr["giabanle"].ToString());}
                        catch { objtblmathang.giabanle = 0; }

                        try { objtblmathang.giadl1 = Convert.ToDouble("0" + dr["giadl1"].ToString());}
                        catch { objtblmathang.giadl1 = 0; }

                        try { objtblmathang.giadl2 = Convert.ToDouble("0" + dr["giadl2"].ToString());}
                        catch { objtblmathang.giadl2 = 0; }

                        try { objtblmathang.giadl3 = Convert.ToDouble("0" + dr["giadl3"].ToString());}
                        catch { objtblmathang.giadl3 = 0; }

                        try { objtblmathang.giadl4 = Convert.ToDouble("0" + dr["giadl4"].ToString());}
                        catch { objtblmathang.giadl4 = 0; }

                        try { objtblmathang.giadl5 = Convert.ToDouble("0" + dr["giadl5"].ToString());}
                        catch { objtblmathang.giadl5 = 0; }

                        objtblmathang.tenkhongdau = dr["tenkhongdau"].ToString();

                        try { objtblmathang.ngaynhap = Convert.ToDateTime(dr["ngaynhap"].ToString());}
                        catch { objtblmathang.ngaynhap = new DateTime(1900, 1, 1); }

                        objtblmathang.userid = dr["userid"].ToString();

                        list.Add(objtblmathang);
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
        /// Hàm lấy danh sách objtblmathang
        /// </summary>
        /// <param name="recperpage">Số lượng bản ghi kiểu integer</param>
        /// <param name="pageindex">Số trang kiểu integer</param>
        /// <returns>Trả về List<<tblmathang>></returns>
        public List<tblmathang> GetListPaged(int recperpage, int pageindex)
        {
          List<tblmathang> list = new List<tblmathang>();
          string strFun = "fn_tblmathang_getpaged";
          try
          {
              NpgsqlParameter[] prmArr = new NpgsqlParameter[2];
              prmArr[0] = new NpgsqlParameter("recperpage", NpgsqlDbType.Integer);
              prmArr[0].Value = recperpage;
              prmArr[1] = new NpgsqlParameter("pageindex", NpgsqlDbType.Integer);
              prmArr[1].Value = pageindex;
              DataSet dstblmathang = mDataAccess.ExecuteDataSet(strFun, CommandType.StoredProcedure,prmArr);
              if ((dstblmathang != null) && (dstblmathang.Tables.Count > 0))
              {
                  for (int i = 0; i < dstblmathang.Tables[0].Rows.Count; i++)
                  {
                        tblmathang objtblmathang = new tblmathang();
                        DataRow dr = dstblmathang.Tables[0].Rows[i];
                        objtblmathang.id = dr["id"].ToString();

                        objtblmathang.id_hangsx = dr["id_hangsx"].ToString();

                        objtblmathang.id_loai = dr["id_loai"].ToString();

                        objtblmathang.ten = dr["ten"].ToString();

                        try { objtblmathang.gianhap = Convert.ToDouble("0" + dr["gianhap"].ToString());}
                        catch { objtblmathang.gianhap = 0; }

                        try{ objtblmathang.soluong = Convert.ToInt32("0" + dr["soluong"].ToString());}
                        catch{ objtblmathang.soluong = 0;}

                        objtblmathang.donvi = dr["donvi"].ToString();

                        objtblmathang.ghichu = dr["ghichu"].ToString();

                        try { objtblmathang.giabanbuon = Convert.ToDouble("0" + dr["giabanbuon"].ToString());}
                        catch { objtblmathang.giabanbuon = 0; }

                        try { objtblmathang.giabanle = Convert.ToDouble("0" + dr["giabanle"].ToString());}
                        catch { objtblmathang.giabanle = 0; }

                        try { objtblmathang.giadl1 = Convert.ToDouble("0" + dr["giadl1"].ToString());}
                        catch { objtblmathang.giadl1 = 0; }

                        try { objtblmathang.giadl2 = Convert.ToDouble("0" + dr["giadl2"].ToString());}
                        catch { objtblmathang.giadl2 = 0; }

                        try { objtblmathang.giadl3 = Convert.ToDouble("0" + dr["giadl3"].ToString());}
                        catch { objtblmathang.giadl3 = 0; }

                        try { objtblmathang.giadl4 = Convert.ToDouble("0" + dr["giadl4"].ToString());}
                        catch { objtblmathang.giadl4 = 0; }

                        try { objtblmathang.giadl5 = Convert.ToDouble("0" + dr["giadl5"].ToString());}
                        catch { objtblmathang.giadl5 = 0; }

                        objtblmathang.tenkhongdau = dr["tenkhongdau"].ToString();

                        try { objtblmathang.ngaynhap = Convert.ToDateTime(dr["ngaynhap"].ToString());}
                        catch { objtblmathang.ngaynhap = new DateTime(1900, 1, 1); }

                        objtblmathang.userid = dr["userid"].ToString();

                        list.Add(objtblmathang);
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
        /// Hàm lấy danh sách objtblmathang
        /// </summary>
        /// <param name="recperpage">Số lượng bản ghi kiểu integer</param>
        /// <param name="pageindex">Số trang kiểu integer</param>
        /// <returns>Trả về List<<tblmathang>></returns>
        public DataTable GetDataTablePaged(int recperpage, int pageindex)
        {
          string strFun = "fn_tblmathang_getpaged";
          try
          {
              NpgsqlParameter[] prmArr = new NpgsqlParameter[2];
              prmArr[0] = new NpgsqlParameter("recperpage", NpgsqlDbType.Integer);
              prmArr[0].Value = recperpage;
              prmArr[1] = new NpgsqlParameter("pageindex", NpgsqlDbType.Integer);
              prmArr[1].Value = pageindex;
              DataSet dstblmathang = mDataAccess.ExecuteDataSet(strFun, CommandType.StoredProcedure,prmArr);
              return dstblmathang.Tables[0];
          }
          catch
          {
              return null;
          }
        }
        /// <summary>
        /// Hàm tìm kiếm mặt hàng
        /// </summary>
        /// <param name="skeyword">Từ khóa kiểu string</param>
        /// <param name="sidhang">Mã hãng sản xuất kiểu string (tất cả thì set = "")</param>
        /// <param name="sidloai">Mã loại mặt hàng kiểu string (tất cả thì set = "")</param>
        /// <returns>DataTable</returns>
        public DataTable filter(string skeyword, string sidhang, string sidloai)
        {
            string strFun = "fn_tblmathang_filter";
            try
            {
                NpgsqlParameter[] prmArr = new NpgsqlParameter[3];
                prmArr[0] = new NpgsqlParameter("keyword", NpgsqlDbType.Varchar);
                prmArr[0].Value = skeyword;
                prmArr[1] = new NpgsqlParameter("hang", NpgsqlDbType.Varchar);
                prmArr[1].Value = sidhang;
                prmArr[2] = new NpgsqlParameter("loai", NpgsqlDbType.Varchar);
                prmArr[2].Value = sidloai;
                DataSet dstblmathang = mDataAccess.ExecuteDataSet(strFun, CommandType.StoredProcedure, prmArr);
                return dstblmathang.Tables[0];
            }
            catch { return null; }
        }
        /// <summary>
        /// Hàm tìm kiếm mặt hàng không giới hạn bản ghi
        /// </summary>
        /// <param name="skeyword">Từ khóa kiểu string</param>
        /// <param name="sidhang">Mã hãng sản xuất kiểu string (tất cả thì set = "")</param>
        /// <param name="sidloai">Mã loại mặt hàng kiểu string (tất cả thì set = "")</param>
        /// <returns>DataTable</returns>
        public DataTable filterall(string skeyword, string sidhang, string sidloai)
        {
            string strFun = "fn_tblmathang_filterall";
            try
            {
                NpgsqlParameter[] prmArr = new NpgsqlParameter[3];
                prmArr[0] = new NpgsqlParameter("keyword", NpgsqlDbType.Varchar);
                prmArr[0].Value = skeyword;
                prmArr[1] = new NpgsqlParameter("hang", NpgsqlDbType.Varchar);
                prmArr[1].Value = sidhang;
                prmArr[2] = new NpgsqlParameter("loai", NpgsqlDbType.Varchar);
                prmArr[2].Value = sidloai;
                DataSet dstblmathang = mDataAccess.ExecuteDataSet(strFun, CommandType.StoredProcedure, prmArr);
                return dstblmathang.Tables[0];
            }
            catch { return null; }
        }
        /// <summary>
        /// Hàm tìm kiếm mặt hàng không giới hạn bản ghi
        /// </summary>
        /// <param name="skeyword">Từ khóa kiểu string</param>
        /// <param name="sidhang">Mã hãng sản xuất kiểu string (tất cả thì set = "")</param>
        /// <param name="sidloai">Mã loại mặt hàng kiểu string (tất cả thì set = "")</param>
        /// <param name="isoluong">Số lượng mặt hàng còn lại trong kho</param>
        /// <returns>DataTable</returns>
        public DataTable filterallforthongke(string skeyword, string sidhang, string sidloai, int isoluong)
        {
            string strFun = "fn_tblmathang_filterallfortk";
            try
            {
                NpgsqlParameter[] prmArr = new NpgsqlParameter[4];
                prmArr[0] = new NpgsqlParameter("keyword", NpgsqlDbType.Varchar);
                prmArr[0].Value = skeyword;
                prmArr[1] = new NpgsqlParameter("hang", NpgsqlDbType.Varchar);
                prmArr[1].Value = sidhang;
                prmArr[2] = new NpgsqlParameter("loai", NpgsqlDbType.Varchar);
                prmArr[2].Value = sidloai;
                prmArr[3] = new NpgsqlParameter("soluong", NpgsqlDbType.Integer);
                prmArr[3].Value = isoluong;
                DataSet dstblmathang = mDataAccess.ExecuteDataSet(strFun, CommandType.StoredProcedure, prmArr);
                return dstblmathang.Tables[0];
            }
            catch { return null; }
        }
        /// <summary>
        /// Hàm lấy danh sách mặt hàng đã bán cho khách hàng
        /// </summary>
        /// <param name="skeyword">Từ khóa tìm kiếm kiểu string</param>
        /// <param name="sidhang">Mã hãng sản xuất kiểu string (tất cả thì set = "")</param>
        /// <param name="sidloai">Mã loại mặt hàng kiểu string (tất cả thì set = "")</param>
        /// <param name="sidkh"></param>
        /// <returns>DataTable</returns>
        public DataTable filtermathangtra(string skeyword, string sidhang, string sidloai,string sidkh)
        {
            string strFun = "fn_tblmathang_filter_mathangtra";
            try
            {
                NpgsqlParameter[] prmArr = new NpgsqlParameter[4];
                prmArr[0] = new NpgsqlParameter("keyword", NpgsqlDbType.Varchar);
                prmArr[0].Value = skeyword;
                prmArr[1] = new NpgsqlParameter("hang", NpgsqlDbType.Varchar);
                prmArr[1].Value = sidhang;
                prmArr[2] = new NpgsqlParameter("loai", NpgsqlDbType.Varchar);
                prmArr[2].Value = sidloai;
                prmArr[3] = new NpgsqlParameter("iidkh", NpgsqlDbType.Varchar);
                prmArr[3].Value = sidkh;
                DataSet dstblmathang = mDataAccess.ExecuteDataSet(strFun, CommandType.StoredProcedure, prmArr);
                return dstblmathang.Tables[0];
            }
            catch { return null; }
        }
        /// <summary>
        /// Hàm lấy danh sách mặt hàng đã bán cho khách hàng không giới hạn bản ghi
        /// </summary>
        /// <param name="skeyword">Từ khóa tìm kiếm kiểu string</param>
        /// <param name="sidhang">Mã hãng sản xuất kiểu string (tất cả thì set = "")</param>
        /// <param name="sidloai">Mã loại mặt hàng kiểu string (tất cả thì set = "")</param>
        /// <param name="sidkh"></param>
        /// <returns>DataTable</returns>
        public DataTable filtermathangtraall(string skeyword, string sidhang, string sidloai, string sidkh)
        {
            string strFun = "fn_tblmathang_filter_mathangtraall";
            try
            {
                NpgsqlParameter[] prmArr = new NpgsqlParameter[4];
                prmArr[0] = new NpgsqlParameter("keyword", NpgsqlDbType.Varchar);
                prmArr[0].Value = skeyword;
                prmArr[1] = new NpgsqlParameter("hang", NpgsqlDbType.Varchar);
                prmArr[1].Value = sidhang;
                prmArr[2] = new NpgsqlParameter("loai", NpgsqlDbType.Varchar);
                prmArr[2].Value = sidloai;
                prmArr[3] = new NpgsqlParameter("iidkh", NpgsqlDbType.Varchar);
                prmArr[3].Value = sidkh;
                DataSet dstblmathang = mDataAccess.ExecuteDataSet(strFun, CommandType.StoredProcedure, prmArr);
                return dstblmathang.Tables[0];
            }
            catch { return null; }
        }
        /// <summary>
        /// Hàm tìm kiếm theo câu truy vấn
        /// </summary>
        /// <param name="squery">câu truy vấn</param>
        /// <returns>DataTable</returns>
        public DataTable filterbyquery(string squery)
        {
            DataSet dstblmathang = new DataSet();
            try
            {
                dstblmathang = mDataAccess.ExecuteDataSet(squery, CommandType.Text);
                return dstblmathang.Tables[0];
            }
            catch { return null; }
        }
        /// <summary>
        /// Hàm lấy danh sách đơn vị tính mặt hàng
        /// </summary>
        /// <returns>DataTable</returns>
        public DataTable GetDonViTinh()
        {
            string strFun = "fn_tblmathang_getdonvi";
            try
            {
                DataSet dstblmathang = mDataAccess.ExecuteDataSet(strFun, CommandType.StoredProcedure);
                return dstblmathang.Tables[0];
            }
            catch
            {
                return null;
            }
        }


        public tblmathang GetByMaVach(string mavach)
        {
            tblmathang objtblmathang = new tblmathang();
            string strFun = "fn_tblmathang_getobjbymavach";
            try
            {
                NpgsqlParameter[] prmArr = new NpgsqlParameter[1];

                prmArr[0] = new NpgsqlParameter("mavach", NpgsqlDbType.Varchar);
                prmArr[0].Value = mavach;

                DataSet dstblmathang = mDataAccess.ExecuteDataSet(strFun, CommandType.StoredProcedure, prmArr);

                if ((dstblmathang != null) && (dstblmathang.Tables.Count > 0))
                {
                    if (dstblmathang.Tables[0].Rows.Count > 0)
                    {
                        DataRow dr = dstblmathang.Tables[0].Rows[0];
                        objtblmathang.id = dr["id"].ToString();

                        objtblmathang.id_hangsx = dr["id_hangsx"].ToString();

                        objtblmathang.id_loai = dr["id_loai"].ToString();

                        objtblmathang.ten = dr["ten"].ToString();

                        try { objtblmathang.gianhap = Convert.ToDouble("0" + dr["gianhap"].ToString()); }
                        catch { objtblmathang.gianhap = 0; }

                        try { objtblmathang.soluong = Convert.ToInt32("0" + dr["soluong"].ToString()); }
                        catch { objtblmathang.soluong = 0; }

                        objtblmathang.donvi = dr["donvi"].ToString();

                        objtblmathang.ghichu = dr["ghichu"].ToString();

                        try { objtblmathang.giabanbuon = Convert.ToDouble("0" + dr["giabanbuon"].ToString()); }
                        catch { objtblmathang.giabanbuon = 0; }

                        try { objtblmathang.giabanle = Convert.ToDouble("0" + dr["giabanle"].ToString()); }
                        catch { objtblmathang.giabanle = 0; }

                        try { objtblmathang.giadl1 = Convert.ToDouble("0" + dr["giadl1"].ToString()); }
                        catch { objtblmathang.giadl1 = 0; }

                        try { objtblmathang.giadl2 = Convert.ToDouble("0" + dr["giadl2"].ToString()); }
                        catch { objtblmathang.giadl2 = 0; }

                        try { objtblmathang.giadl3 = Convert.ToDouble("0" + dr["giadl3"].ToString()); }
                        catch { objtblmathang.giadl3 = 0; }

                        try { objtblmathang.giadl4 = Convert.ToDouble("0" + dr["giadl4"].ToString()); }
                        catch { objtblmathang.giadl4 = 0; }

                        try { objtblmathang.giadl5 = Convert.ToDouble("0" + dr["giadl5"].ToString()); }
                        catch { objtblmathang.giadl5 = 0; }

                        objtblmathang.tenkhongdau = dr["tenkhongdau"].ToString();

                        try { objtblmathang.ngaynhap = Convert.ToDateTime(dr["ngaynhap"].ToString()); }
                        catch { objtblmathang.ngaynhap = new DateTime(1900, 1, 1); }

                        objtblmathang.userid = dr["userid"].ToString();


                        return objtblmathang;
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
        #endregion
    }
}
