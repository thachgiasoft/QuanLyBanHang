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
    /// Mô tả thông tin cho bảng tblhangnhapkho
    /// Cung cấp các hàm xử lý, thao tác với bảng tblhangnhapkho
    /// Người tạo (C): tuanva
    /// Ngày khởi tạo: 03/12/2015
    /// </summary>
    public class tblhangnhapkho
    {
        #region Private Variables
        private string strid;
        private string strid_phieunhapkho;
        private string strid_mathang;
        private int intsoluong;
        private double dblgianhap;
        private string strghichu;
        #endregion

        #region Public Constructor Functions
        public tblhangnhapkho()
        {
            strid = string.Empty;
            strid_phieunhapkho = string.Empty;
            strid_mathang = string.Empty;
            intsoluong = 0;
            dblgianhap = 0;
            strghichu = string.Empty;

        }

        public tblhangnhapkho(string strid, string strid_phieunhapkho, string strid_mathang, int intsoluong, double dblgianhap, string strghichu)
        {
            this.strid = strid;
            this.strid_phieunhapkho = strid_phieunhapkho;
            this.strid_mathang = strid_mathang;
            this.intsoluong = intsoluong;
            this.dblgianhap = dblgianhap;
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

        public string id_phieunhapkho
        {
            get
            {
                return strid_phieunhapkho;
            }
            set
            {
                strid_phieunhapkho = value;
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
        /// Lấy toàn bộ dữ liệu từ bảng tblhangnhapkho
        /// </summary>
        /// <returns>DataTable</returns>
        public DataTable GetAll()
        {
            string strFun = "fn_tblhangnhapkho_getall";
            try
            {
                DataSet dstblhangnhapkho = mDataAccess.ExecuteDataSet(strFun, CommandType.StoredProcedure);
                return dstblhangnhapkho.Tables[0];
            }
            catch
            {
                return null;
            }
        }
        /// <summary>
        /// Hàm lấy tblhangnhapkho theo mã
        /// </summary>
        /// <returns>Trả về objtblhangnhapkho </returns>
        public tblhangnhapkho GetByID(string strid)
        {
            tblhangnhapkho objtblhangnhapkho = new tblhangnhapkho();
            string strFun = "fn_tblhangnhapkho_getobjbyid";
            try
            {
                NpgsqlParameter[] prmArr = new NpgsqlParameter[1];

                prmArr[0] = new NpgsqlParameter("id", NpgsqlDbType.Varchar);
                prmArr[0].Value = strid;

                DataSet dstblhangnhapkho = mDataAccess.ExecuteDataSet(strFun, CommandType.StoredProcedure, prmArr);

                if ((dstblhangnhapkho != null) && (dstblhangnhapkho.Tables.Count > 0))
                {
                    if (dstblhangnhapkho.Tables[0].Rows.Count > 0)
                    {
                        DataRow dr = dstblhangnhapkho.Tables[0].Rows[0];
                        objtblhangnhapkho.id = dr["id"].ToString();

                        objtblhangnhapkho.id_phieunhapkho = dr["id_phieunhapkho"].ToString();

                        objtblhangnhapkho.id_mathang = dr["id_mathang"].ToString();

                        try { objtblhangnhapkho.soluong = Convert.ToInt32("0" + dr["soluong"].ToString()); }
                        catch { objtblhangnhapkho.soluong = 0; }

                        try { objtblhangnhapkho.gianhap = Convert.ToDouble("0" + dr["gianhap"].ToString()); }
                        catch { objtblhangnhapkho.gianhap = 0; }

                        objtblhangnhapkho.ghichu = dr["ghichu"].ToString();


                        return objtblhangnhapkho;
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
        /// Hàm lấy danh sách mặt hàng theo mã phiếu nhập kho
        /// </summary>
        /// <param name="stridpn">Mã phiếu nhập kho kiểu string</param>
        /// <returns>DataTable</returns>
        public DataTable GetByIDPN(string stridpn)
        {
            tblhangnhapkho objtblhangnhapkho = new tblhangnhapkho();
            string strFun = "fn_tblhangnhapkho_getbyidpn";
            try
            {
                NpgsqlParameter[] prmArr = new NpgsqlParameter[1];
                prmArr[0] = new NpgsqlParameter("id_phieunhapkho", NpgsqlDbType.Varchar);
                prmArr[0].Value = stridpn;
                DataSet dstblhangnhapkho = mDataAccess.ExecuteDataSet(strFun, CommandType.StoredProcedure, prmArr);
                return dstblhangnhapkho.Tables[0];
            }
            catch
            {
                return null;
            }
        }
        /// <summary>
        /// Thêm mới dữ liệu vào bảng: tblhangnhapkho
        /// </summary>
        /// <param name="obj">objtblhangnhapkho</param>
        /// <returns>Trả về trắng: Thêm mới thành công; Trả về khác trắng: Thêm mới không thành công</returns>
        public string Insert(tblhangnhapkho objtblhangnhapkho)
        {
            string strProc = "fn_tblhangnhapkho_insert";
            try
            {
                NpgsqlParameter[] prmArr = new NpgsqlParameter[7];

                prmArr[0] = new NpgsqlParameter("id", NpgsqlDbType.Varchar);
                prmArr[0].Value = objtblhangnhapkho.strid;

                prmArr[1] = new NpgsqlParameter("id_phieunhapkho", NpgsqlDbType.Varchar);
                prmArr[1].Value = objtblhangnhapkho.strid_phieunhapkho;

                prmArr[2] = new NpgsqlParameter("id_mathang", NpgsqlDbType.Varchar);
                prmArr[2].Value = objtblhangnhapkho.strid_mathang;

                prmArr[3] = new NpgsqlParameter("soluong", NpgsqlDbType.Integer);
                prmArr[3].Value = objtblhangnhapkho.intsoluong;

                prmArr[4] = new NpgsqlParameter("gianhap", NpgsqlDbType.Double);
                prmArr[4].Value = objtblhangnhapkho.dblgianhap;

                prmArr[5] = new NpgsqlParameter("ghichu", NpgsqlDbType.Varchar);
                prmArr[5].Value = objtblhangnhapkho.strghichu;

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
        /// Cập nhật dữ liệu vào bảng: tblhangnhapkho
        /// </summary>
        /// <param name="obj">objtblhangnhapkho</param>
        /// <returns>Trả về trắng: Cập nhật thành công; Trả về khác trắng: Cập nhật không thành công</returns>
        public string Update(tblhangnhapkho objtblhangnhapkho)
        {
            string strProc = "fn_tblhangnhapkho_Update";
            try
            {
                NpgsqlParameter[] prmArr = new NpgsqlParameter[7];

                prmArr[0] = new NpgsqlParameter("id", NpgsqlDbType.Varchar);
                prmArr[0].Value = objtblhangnhapkho.strid;

                prmArr[1] = new NpgsqlParameter("id_phieunhapkho", NpgsqlDbType.Varchar);
                prmArr[1].Value = objtblhangnhapkho.strid_phieunhapkho;

                prmArr[2] = new NpgsqlParameter("id_mathang", NpgsqlDbType.Varchar);
                prmArr[2].Value = objtblhangnhapkho.strid_mathang;

                prmArr[3] = new NpgsqlParameter("soluong", NpgsqlDbType.Integer);
                prmArr[3].Value = objtblhangnhapkho.intsoluong;

                prmArr[4] = new NpgsqlParameter("gianhap", NpgsqlDbType.Double);
                prmArr[4].Value = objtblhangnhapkho.dblgianhap;

                prmArr[5] = new NpgsqlParameter("ghichu", NpgsqlDbType.Varchar);
                prmArr[5].Value = objtblhangnhapkho.strghichu;

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
        /// Xóa dữ liệu từ bảng tblhangnhapkho
        /// </summary>
        /// <returns></returns>
        public string Delete(string strid)
        {
            string strProc = "fn_tblhangnhapkho_delete";
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
        /// Hàm lấy tất cả dữ liệu trong bảng tblhangnhapkho
        /// </summary>
        /// <returns>Trả về List<<tblhangnhapkho>></returns>
        public List<tblhangnhapkho> GetList()
        {
            List<tblhangnhapkho> list = new List<tblhangnhapkho>();
            string strFun = "fn_tblhangnhapkho_getall";
            try
            {
                DataSet dstblhangnhapkho = mDataAccess.ExecuteDataSet(strFun, CommandType.StoredProcedure);
                if ((dstblhangnhapkho != null) && (dstblhangnhapkho.Tables.Count > 0))
                {
                    for (int i = 0; i < dstblhangnhapkho.Tables[0].Rows.Count; i++)
                    {
                        tblhangnhapkho objtblhangnhapkho = new tblhangnhapkho();
                        DataRow dr = dstblhangnhapkho.Tables[0].Rows[i];
                        objtblhangnhapkho.id = dr["id"].ToString();

                        objtblhangnhapkho.id_phieunhapkho = dr["id_phieunhapkho"].ToString();

                        objtblhangnhapkho.id_mathang = dr["id_mathang"].ToString();

                        try { objtblhangnhapkho.soluong = Convert.ToInt32("0" + dr["soluong"].ToString()); }
                        catch { objtblhangnhapkho.soluong = 0; }

                        try { objtblhangnhapkho.gianhap = Convert.ToDouble("0" + dr["gianhap"].ToString()); }
                        catch { objtblhangnhapkho.gianhap = 0; }

                        objtblhangnhapkho.ghichu = dr["ghichu"].ToString();

                        list.Add(objtblhangnhapkho);
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
        /// Hàm lấy danh sách objtblhangnhapkho
        /// </summary>
        /// <param name="recperpage">Số lượng bản ghi kiểu integer</param>
        /// <param name="pageindex">Số trang kiểu integer</param>
        /// <returns>Trả về List<<tblhangnhapkho>></returns>
        public List<tblhangnhapkho> GetListPaged(int recperpage, int pageindex)
        {
            List<tblhangnhapkho> list = new List<tblhangnhapkho>();
            string strFun = "fn_tblhangnhapkho_getpaged";
            try
            {
                NpgsqlParameter[] prmArr = new NpgsqlParameter[2];
                prmArr[0] = new NpgsqlParameter("recperpage", NpgsqlDbType.Integer);
                prmArr[0].Value = recperpage;
                prmArr[1] = new NpgsqlParameter("pageindex", NpgsqlDbType.Integer);
                prmArr[1].Value = pageindex;
                DataSet dstblhangnhapkho = mDataAccess.ExecuteDataSet(strFun, CommandType.StoredProcedure, prmArr);
                if ((dstblhangnhapkho != null) && (dstblhangnhapkho.Tables.Count > 0))
                {
                    for (int i = 0; i < dstblhangnhapkho.Tables[0].Rows.Count; i++)
                    {
                        tblhangnhapkho objtblhangnhapkho = new tblhangnhapkho();
                        DataRow dr = dstblhangnhapkho.Tables[0].Rows[i];
                        objtblhangnhapkho.id = dr["id"].ToString();

                        objtblhangnhapkho.id_phieunhapkho = dr["id_phieunhapkho"].ToString();

                        objtblhangnhapkho.id_mathang = dr["id_mathang"].ToString();

                        try { objtblhangnhapkho.soluong = Convert.ToInt32("0" + dr["soluong"].ToString()); }
                        catch { objtblhangnhapkho.soluong = 0; }

                        try { objtblhangnhapkho.gianhap = Convert.ToDouble("0" + dr["gianhap"].ToString()); }
                        catch { objtblhangnhapkho.gianhap = 0; }

                        objtblhangnhapkho.ghichu = dr["ghichu"].ToString();

                        list.Add(objtblhangnhapkho);
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
        /// Hàm lấy danh sách objtblhangnhapkho
        /// </summary>
        /// <param name="recperpage">Số lượng bản ghi kiểu integer</param>
        /// <param name="pageindex">Số trang kiểu integer</param>
        /// <returns>Trả về List<<tblhangnhapkho>></returns>
        public DataTable GetDataTablePaged(int recperpage, int pageindex)
        {
            string strFun = "fn_tblhangnhapkho_getpaged";
            try
            {
                NpgsqlParameter[] prmArr = new NpgsqlParameter[2];
                prmArr[0] = new NpgsqlParameter("recperpage", NpgsqlDbType.Integer);
                prmArr[0].Value = recperpage;
                prmArr[1] = new NpgsqlParameter("pageindex", NpgsqlDbType.Integer);
                prmArr[1].Value = pageindex;
                DataSet dstblhangnhapkho = mDataAccess.ExecuteDataSet(strFun, CommandType.StoredProcedure, prmArr);
                return dstblhangnhapkho.Tables[0];
            }
            catch
            {
                return null;
            }
        }
        #endregion
    }
}
