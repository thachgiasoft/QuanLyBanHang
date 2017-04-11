using System;
using System.Data.Common;
using System.Configuration;
using System.Data;
using System.IO;
using CGCN.Configure;

namespace CGCN.DataAccess
{
    public class Data
    {
        InitFile initFile = new InitFile();
        public static string ConnectionString = InitFile.GetCon().Trim();
        public static string use = "unknow";
        public static string iduse = "unknow";
        public Data()
        {
            ConnectionString = "Server=" + initFile.Server.Trim() + ";Port=" + initFile.Port.Trim() + ";User Id=" + initFile.Account.Trim()
                        + ";password=" + initFile.Password + ";Database=" + initFile.Database.Trim() + ";Encoding=UNICODE;";
        }
        #region Cac ham chung mo rong
        public static string GetConnectionString()
        {
            return ConnectionString;
        }
        public static string ChuyenTVKhongDau(string s)
        {
            string str = "aAeEoOuUiIdDyY";
            string[] strArray = new string[] { "\x00e1\x00e0ạả\x00e3\x00e2ấầậẩẫăắằặẳẵ", "\x00c1\x00c0ẠẢ\x00c3\x00c2ẤẦẬẨẪĂẮẰẶẲẴ", "\x00e9\x00e8ẹẻẽ\x00eaếềệểễeeeeee", "\x00c9\x00c8ẸẺẼ\x00caẾỀỆỂỄEEEEEE", "\x00f3\x00f2ọỏ\x00f5\x00f4ốồộổỗơớờợởỡ", "\x00d3\x00d2ỌỎ\x00d5\x00d4ỐỒỘỔỖƠỚỜỢỞỠ", "\x00fa\x00f9ụủũưứừựửữuuuuuu", "\x00da\x00d9ỤỦŨƯỨỪỰỬỮUUUUUU", "\x00ed\x00ecịỉĩiiiiiiiiiiii", "\x00cd\x00ccỊỈĨIIIIIIIIIIII", "đdddddddddddddddd", "ĐDDDDDDDDDDDDDDDD", "\x00fdỳỵỷỹyyyyyyyyyyyy", "\x00ddỲỴỶỸYYYYYYYYYYYY" };
            for (int i = 0; i < s.Length; i++)
            {
                for (int j = 0; j < strArray.Length; j++)
                {
                    if (strArray[j].Contains(s.Substring(i, 1)))
                    {
                        s = s.Replace(s.Substring(i, 1), str.Substring(j, 1));
                    }
                }
            }
            return s;
        }
        public static string ConvertNgaySangThu(DateTime dt)
        {
            string strDay = "";
            switch (dt.DayOfWeek)
            {
                case DayOfWeek.Sunday:
                    strDay = "Chủ nhật";
                    break;
                case DayOfWeek.Monday:
                    strDay = "Thứ hai";
                    break;
                case DayOfWeek.Tuesday:
                    strDay = "Thứ ba";
                    break;
                case DayOfWeek.Wednesday:
                    strDay = "Thứ tư";
                    break;
                case DayOfWeek.Thursday:
                    strDay = "Thứ năm";
                    break;
                case DayOfWeek.Friday:
                    strDay = "Thứ sáu";
                    break;
                case DayOfWeek.Saturday:
                    strDay = "Thứ bảy";
                    break;
            }
            return strDay;
        }
        public static int ConvertNgaySangThuInt(DateTime dt)
        {
            int strDay = 0;
            switch (dt.DayOfWeek)
            {
                case DayOfWeek.Sunday:
                    strDay = 1;
                    break;
                case DayOfWeek.Monday:
                    strDay = 2;
                    break;
                case DayOfWeek.Tuesday:
                    strDay = 3;
                    break;
                case DayOfWeek.Wednesday:
                    strDay = 4;
                    break;
                case DayOfWeek.Thursday:
                    strDay = 5;
                    break;
                case DayOfWeek.Friday:
                    strDay = 6;
                    break;
                case DayOfWeek.Saturday:
                    strDay = 7;
                    break;
            }
            return strDay;
        }
        #endregion
    }
}
