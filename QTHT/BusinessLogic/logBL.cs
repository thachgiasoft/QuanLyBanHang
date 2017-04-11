using System;
using System.Data;
using System.Collections.Generic;
using System.Text;
using Npgsql;
using NpgsqlTypes;
using QTHT.DataAccess;

namespace QTHT.BusinesLogic
{
     /// <summary>
     /// Mô tả thông tin cho bảng tblLog
     /// Cung cấp các hàm xử lý, thao tác với bảng tblLog
     /// Người tạo (C): tuanva
     /// Ngày khởi tạo: 14/10/2014
     /// </summary>
    public class logBL
    {
        private log objlogDA = new log();
        public logBL() { objlogDA = new log(); }
        #region Public Method
        /// <summary>
        /// Lấy toàn bộ dữ liệu từ bảng tblLog
        /// </summary>
        /// <returns>DataTable</returns>
        public DataTable GetAll()
        {
            return objlogDA.GetAll();
        }
        /// <summary>
        /// Hàm lấy tblLog theo mã
        /// </summary>
        /// <returns>Trả về objtblLog </returns>
        public log GetByID(int intId)
        {
            return objlogDA.GetByID(intId);
        }
        /// <summary>
        /// Cập nhật dữ liệu vào bảng: tblLog
        /// </summary>
        /// <param name="obj">objtblLog</param>
        /// <returns>Trả về trắng: Cập nhật thành công; Trả về khác trắng: Cập nhật không thành công</returns>
        public string Update(log objLog)
        {
            return objlogDA.Update(objLog);
        }
        /// <summary>
        /// Xóa dữ liệu từ bảng tblLog
        /// </summary>
        /// <returns>Trả về trắng: xóa thành công; Trả về khác trắng: xóa không thành công</returns>
        public string Delete(int intId)
        {
            return objlogDA.Delete(intId);
        }
        /// <summary>
        /// Hàm thêm mới log
        /// </summary>
        /// <param name="sUserName">Tên tài khoản kiểu string</param>
        /// <param name="sTask">Thao tác kiểu string</param>
        /// <returns>String: Trả về trắng: Thêm mới thành công; Trả về khác trắng: Thêm mới không thành công</returns>
        public string Append(string sUserName, string sTask)
        {
            return objlogDA.Append(sUserName, sTask);
        }
        /// <summary>
        /// Hàm tìm kiếm log sử dụng chuối truy vấn trực tiếp có hilight
        /// </summary>
        /// <param name="skeyword">Từ khóa kiểu string</param>
        /// <param name="dttungay">Từ ngày kiểu datetime</param>
        /// <param name="dtdenngay">Đến ngày kiểu datetime</param>
        /// <returns>DataTable</returns>
        public DataTable FindLogUseQueryHilight(string skeyword, DateTime dttungay, DateTime dtdenngay)
        {
            string query = ""; 
            string sdieukien = "Where (1=1) ";
            if (dttungay.ToShortDateString().Equals(dtdenngay.ToShortDateString()) == false)
            {
                sdieukien = sdieukien + "AND (log.thoigian BETWEEN '" + dttungay.ToString("yyyy/MM/dd") + "' AND '" + dtdenngay.AddDays(1).ToString("yyyy/MM/dd") + "') ";
            }
            else
            {
                sdieukien = sdieukien + "AND (log.thoigian BETWEEN '" + dttungay.ToString("yyyy/MM/dd") + "' AND '" + dtdenngay.AddDays(7).ToString("yyyy/MM/dd") + "') ";
            }
            if (skeyword.Trim().Equals("") == false)
            {
                query = "select false::boolean as chon,id,thoigian "; 
                query = query + ",similarity(log.iduser, '" + skeyword + "') as rankuser, similarity(log.thaotac, '" + skeyword + "') as ranktask, "
                    + "ts_headline(iduser,plainto_tsquery('" + skeyword + "'),'StartSel = <b><em>,StopSel = </em></b>,HighlightAll=TRUE') AS iduser, "
                    + "ts_headline(thaotac,plainto_tsquery('" + skeyword + "'),'StartSel = <b><em>,StopSel = </em></b>,HighlightAll=TRUE') AS thaotac "
                    + "from log ";
                sdieukien = sdieukien + "AND ((similarity(log.iduser, '" + skeyword + "') > 0 ) ";
                sdieukien = sdieukien + "OR (similarity(log.thaotac, '" + skeyword + "') > 0 )) ";
                sdieukien = sdieukien + "Order by thoigian desc,rankuser desc,ranktask desc ";
            }
            else
            {
                query = "select false::boolean as chon,id,thoigian,iduser,thaotac from log ";
                sdieukien = sdieukien + "order by thoigian desc ";
            }
            query = query + sdieukien;
            return objlogDA.FindLogUseQuery(query);
        }
        /// <summary>
        /// Hàm tìm kiếm log sử dụng chuối truy vấn trực tiếp không hilight
        /// </summary>
        /// <param name="skeyword">Từ khóa kiểu string</param>
        /// <param name="dttungay">Từ ngày kiểu datetime</param>
        /// <param name="dtdenngay">Đến ngày kiểu datetime</param>
        /// <returns>DataTable</returns>
        public DataTable FindLogUseQueryNotHilight(string skeyword, DateTime dttungay, DateTime dtdenngay)
        {
            string query = "";
            string sdieukien = "Where (1=1) ";
            if (dttungay.ToShortDateString().Equals(dtdenngay.ToShortDateString()) == false)
            {
                sdieukien = sdieukien + "AND (log.thoigian BETWEEN '" + dttungay.ToString("yyyy/MM/dd") + "' AND '" + dtdenngay.AddDays(1).ToString("yyyy/MM/dd") + "') ";
            }
            else
            {
                sdieukien = sdieukien + "AND (log.thoigian BETWEEN '" + dttungay.ToString("yyyy/MM/dd") + "' AND '" + dtdenngay.AddDays(1).ToString("yyyy/MM/dd") + "') ";
            }
            if (skeyword.Trim().Equals("") == false)
            {
                query = "select false::boolean as chon,id,thoigian ";
                query = query + ",similarity(log.iduser, '" + skeyword + "') as rankuser, similarity(log.thaotac, '" + skeyword + "') as ranktask, "
                    + "iduser, thaotac from log ";
                sdieukien = sdieukien + "AND ((similarity(log.iduser, '" + skeyword + "') > 0 ) ";
                sdieukien = sdieukien + "OR (similarity(log.thaotac, '" + skeyword + "') > 0 )) ";
                sdieukien = sdieukien + "Order by rankuser desc,ranktask desc,thoigian desc ";
            }
            else
            {
                query = "select false::boolean as chon,id,thoigian,iduser,thaotac from log ";
                sdieukien = sdieukien + "order by thoigian desc ";
            }
            query = query + sdieukien;
            return objlogDA.FindLogUseQuery(query);
        }
        #endregion
    }
}
