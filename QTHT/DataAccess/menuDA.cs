using System;
using System.Data;
using System.Collections.Generic;
using System.Text;
using Npgsql;
using NpgsqlTypes;
using CGCN.Framework;
using CGCN.DataAccess;

namespace QTHT.DataAccess
{
     /// <summary>
     /// Mô tả thông tin cho bảng menu
     /// Cung cấp các hàm xử lý, thao tác với bảng menu
     /// Người tạo (C): 
     /// Ngày khởi tạo: 17/10/2014
     /// </summary>
    public class menu
    {
        #region Private Variables
        private int intmenuid;
        private string strmenuname;
        private int intmenuorder;
        private int intparentmenuid;
        private string strmenulink;
        private string strghichu;
        private int intstatus;
        private int intcap;
        private string striconlink;
        #endregion

        #region Public Constructor Functions
        public menu()
        {
            intmenuid = 0;
            strmenuname = string.Empty;
            intmenuorder = 0;
            intparentmenuid = 0;
            strmenulink = string.Empty;
            strghichu = string.Empty;
            intstatus = 0;
            intcap = 0;
            striconlink = string.Empty;

        }

        public menu(int intmenuid, string strmenuname, int intmenuorder, int intparentmenuid, string strmenulink, string strghichu, int intstatus, int intcap, string striconlink)
        {
            this.intmenuid = intmenuid;
            this.strmenuname = strmenuname;
            this.intmenuorder = intmenuorder;
            this.intparentmenuid = intparentmenuid;
            this.strmenulink = strmenulink;
            this.strghichu = strghichu;
            this.intstatus = intstatus;
            this.intcap = intcap;
            this.striconlink = striconlink;
        }
        #endregion

        #region Properties
        public int menuid
        {
            get
            {
                return intmenuid;
            }
            set
            {
                intmenuid = value;
            }
        }

        public string menuname
        {
            get
            {
                return strmenuname;
            }
            set
            {
                strmenuname = value;
            }
        }

        public int menuorder
        {
            get
            {
                return intmenuorder;
            }
            set
            {
                intmenuorder = value;
            }
        }

        public int parentmenuid
        {
            get
            {
                return intparentmenuid;
            }
            set
            {
                intparentmenuid = value;
            }
        }

        public string menulink
        {
            get
            {
                return strmenulink;
            }
            set
            {
                strmenulink = value;
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

        public int status
        {
            get
            {
                return intstatus;
            }
            set
            {
                intstatus = value;
            }
        }

        public int cap
        {
            get
            {
                return intcap;
            }
            set
            {
                intcap = value;
            }
        }

        public string iconlink
        {
            get
            {
                return striconlink;
            }
            set
            {
                striconlink = value;
            }
        }
        #endregion

        #region Public Method
        private readonly DataAccessLayerBaseClass mDataAccess = new DataAccessLayerBaseClass(Data.ConnectionString);

        /// <summary>
        /// Lấy toàn bộ dữ liệu từ bảng menu
        /// </summary>
        /// <returns>DataTable</returns>
        public DataTable GetAll()
        {
            string strFun = "fn_menu_getall";
            try
            {
                DataSet dsmenu = mDataAccess.ExecuteDataSet(strFun, CommandType.StoredProcedure);
                return dsmenu.Tables[0];
            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        /// Hàm lấy menu theo mã
        /// </summary>
        /// <returns>Trả về objmenu </returns>
        public menu GetByID(int intmenuid)
        {
            menu objmenu = new menu();
            string strFun = "fn_menu_getobjbyid";
            try
            {
                NpgsqlParameter[] prmArr = new NpgsqlParameter[1];

                prmArr[0] = new NpgsqlParameter("menuid", NpgsqlDbType.Integer);
                prmArr[0].Value = intmenuid;

                DataSet dsmenu = mDataAccess.ExecuteDataSet(strFun, CommandType.StoredProcedure, prmArr);

                if ((dsmenu != null) && (dsmenu.Tables.Count > 0))
                {
                    if (dsmenu.Tables[0].Rows.Count > 0)
                    {
                        DataRow dr = dsmenu.Tables[0].Rows[0];
                        try{ objmenu.menuid = Convert.ToInt32("0" + dr["menuid"].ToString());}
                        catch{ objmenu.menuid = 0;}

                        objmenu.menuname = dr["menuname"].ToString();

                        try{ objmenu.menuorder = Convert.ToInt32("0" + dr["menuorder"].ToString());}
                        catch{ objmenu.menuorder = 0;}

                        try{ objmenu.parentmenuid = Convert.ToInt32("0" + dr["parentmenuid"].ToString());}
                        catch{ objmenu.parentmenuid = 0;}

                        objmenu.menulink = dr["menulink"].ToString();

                        objmenu.ghichu = dr["ghichu"].ToString();

                        try{ objmenu.status = Convert.ToInt32("0" + dr["status"].ToString());}
                        catch{ objmenu.status = 0;}

                        try{ objmenu.cap = Convert.ToInt32("0" + dr["cap"].ToString());}
                        catch{ objmenu.cap = 0;}

                        objmenu.iconlink = dr["iconlink"].ToString();


                        return objmenu;
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
        /// Thêm mới dữ liệu vào bảng: menu
        /// </summary>
        /// <param name="obj">objmenu</param>
        /// <returns>Trả về menuid kiểu int: 0-Không thành công;<>0:Thành công</returns>
        public int Insert(menu objmenu)
        {
            string strProc = "fn_menu_insert";
            try
            {
                NpgsqlParameter[] prmArr = new NpgsqlParameter[10];
                prmArr[0] = new NpgsqlParameter("menuid", NpgsqlDbType.Integer);
                prmArr[0].Value = objmenu.intmenuid;
                prmArr[1] = new NpgsqlParameter("menuname", NpgsqlDbType.Varchar);
                prmArr[1].Value = objmenu.strmenuname;
                prmArr[2] = new NpgsqlParameter("menuorder", NpgsqlDbType.Integer);
                prmArr[2].Value = objmenu.intmenuorder;
                prmArr[3] = new NpgsqlParameter("parentmenuid", NpgsqlDbType.Integer);
                prmArr[3].Value = objmenu.intparentmenuid;
                prmArr[4] = new NpgsqlParameter("menulink", NpgsqlDbType.Varchar);
                prmArr[4].Value = objmenu.strmenulink;
                prmArr[5] = new NpgsqlParameter("ghichu", NpgsqlDbType.Varchar);
                prmArr[5].Value = objmenu.strghichu;
                prmArr[6] = new NpgsqlParameter("status", NpgsqlDbType.Integer);
                prmArr[6].Value = objmenu.intstatus;
                prmArr[7] = new NpgsqlParameter("cap", NpgsqlDbType.Integer);
                prmArr[7].Value = objmenu.intcap;
                prmArr[8] = new NpgsqlParameter("iconlink", NpgsqlDbType.Varchar);
                prmArr[8].Value = objmenu.striconlink;
                prmArr[9] = new NpgsqlParameter("ireturn", NpgsqlDbType.Text);
                prmArr[9].Direction = ParameterDirection.Output;
                mDataAccess.ExecuteQuery(strProc, CommandType.StoredProcedure, prmArr);
                try { return Convert.ToInt32(prmArr[9].Value.ToString().Trim()); }
                catch { return 0; }
            }
            catch
            {
                return 0;
            }
        }

        /// <summary>
        /// Cập nhật dữ liệu vào bảng: menu
        /// </summary>
        /// <param name="obj">objmenu</param>
        /// <returns>Trả về trắng: Cập nhật thành công; Trả về khác trắng: Cập nhật không thành công</returns>
        public string Update(menu objmenu)
        {
            string strProc = "fn_menu_Update";
            try
            {
                NpgsqlParameter[] prmArr = new NpgsqlParameter[10];
                prmArr[0] = new NpgsqlParameter("menuid", NpgsqlDbType.Integer);
                prmArr[0].Value = objmenu.intmenuid;
                prmArr[1] = new NpgsqlParameter("menuname", NpgsqlDbType.Varchar);
                prmArr[1].Value = objmenu.strmenuname;
                prmArr[2] = new NpgsqlParameter("menuorder", NpgsqlDbType.Integer);
                prmArr[2].Value = objmenu.intmenuorder;
                prmArr[3] = new NpgsqlParameter("parentmenuid", NpgsqlDbType.Integer);
                prmArr[3].Value = objmenu.intparentmenuid;
                prmArr[4] = new NpgsqlParameter("menulink", NpgsqlDbType.Varchar);
                prmArr[4].Value = objmenu.strmenulink;
                prmArr[5] = new NpgsqlParameter("ghichu", NpgsqlDbType.Varchar);
                prmArr[5].Value = objmenu.strghichu;
                prmArr[6] = new NpgsqlParameter("status", NpgsqlDbType.Integer);
                prmArr[6].Value = objmenu.intstatus;
                prmArr[7] = new NpgsqlParameter("cap", NpgsqlDbType.Integer);
                prmArr[7].Value = objmenu.intcap;
                prmArr[8] = new NpgsqlParameter("iconlink", NpgsqlDbType.Varchar);
                prmArr[8].Value = objmenu.striconlink;
                prmArr[9] = new NpgsqlParameter("ireturn", NpgsqlDbType.Text);
                prmArr[9].Direction = ParameterDirection.Output;
                mDataAccess.ExecuteQuery(strProc, CommandType.StoredProcedure, prmArr);
                string sKQ = prmArr[9 ].Value.ToString().Trim();
                if (sKQ.ToUpper().Equals("Update".ToUpper()) == true) return "";
                return "Cập nhật dữ liệu không thành công";
            }
            catch(Exception ex)
            {
                return "Cập nhật dữ liệu không thành công. Chi Tiết: " + ex.Message;
            }
        }

        /// <summary>
        /// Xóa dữ liệu từ bảng menu
        /// </summary>
        /// <returns>Trả về trắng: xóa thành công; Trả về khác trắng: xóa không thành công</returns>
        public string Delete(int intmenuid)
        {
            string strProc = "fn_menu_delete";
            try
            {
                NpgsqlParameter[] prmArr = new NpgsqlParameter[2];

                prmArr[0] = new NpgsqlParameter("menuid", NpgsqlDbType.Integer);
                prmArr[0].Value = intmenuid;

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
        #endregion
    }
}
