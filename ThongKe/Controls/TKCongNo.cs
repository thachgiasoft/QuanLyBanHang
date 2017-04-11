using System;
using System.Xml;
using CarlosAg.ExcelXmlWriter;
using System.Data;
using System.Globalization;
using System.Windows.Forms;
using HoaDonDataAccess.BusinesLogic;
using HoaDonDataAccess.DataAccess;

namespace ThongKe.Controls
{
    /// <summary>
    /// Mô tả thông tin cho class TKCongNo
    /// Cung cấp các hàm xử lý, thao tác về thống kê công nợ
    /// Người tạo (C): tuanva
    /// Ngày khởi tạo: 24/10/2015
    /// </summary>
    public class TKCongNo
    {
        public string Generate(string filename, DateTime dtdengay, DataTable dtkh, ProgressBar progressBar)
        {
            try
            {
                Application.DoEvents();
                progressBar.PerformStep();
                Application.DoEvents();
                Workbook book = new Workbook();
                // -----------------------------------------------
                //  Properties
                // -----------------------------------------------
                book.Properties.Created = DateTime.Now;
                book.Properties.Version = "12.00";
                book.Properties.Author = "QLBH v.1.0.1";
                book.Properties.Company = "GIABAO Ltd,.Co";
                book.Properties.Title = "vuanhtuanbk248@gmail.com";
                book.ExcelWorkbook.WindowHeight = 8010;
                book.ExcelWorkbook.WindowWidth = 14805;
                book.ExcelWorkbook.WindowTopX = 240;
                book.ExcelWorkbook.WindowTopY = 105;
                book.ExcelWorkbook.ProtectWindows = false;
                book.ExcelWorkbook.ProtectStructure = false;
                // -----------------------------------------------
                //  Generate Styles
                // -----------------------------------------------
                Application.DoEvents();
                progressBar.PerformStep();
                Application.DoEvents();
                this.GenerateStyles(book.Styles);
                // -----------------------------------------------
                //  Generate TKCongNo Worksheet
                // -----------------------------------------------
                Application.DoEvents();
                progressBar.PerformStep();
                Application.DoEvents();
                string kq = this.GenerateWorksheet(book.Worksheets, dtdengay, dtkh, progressBar);
                if (kq.Trim().Equals("") == true)
                {
                    book.Save(filename); return kq;
                }
                else { return kq; }
            }
            catch (Exception ex)
            { return ex.Message; }
        }

        private void GenerateStyles(WorksheetStyleCollection styles)
        {
            // -----------------------------------------------
            //  Default
            // -----------------------------------------------
            WorksheetStyle Default = styles.Add("Default");
            Default.Name = "Normal";
            Default.Font.FontName = "Calibri";
            Default.Font.Size = 11;
            Default.Font.Color = "#000000";
            Default.Alignment.Vertical = StyleVerticalAlignment.Bottom;
            // -----------------------------------------------
            //  s97
            // -----------------------------------------------
            WorksheetStyle s97 = styles.Add("s97");
            s97.Font.FontName = "Times New Roman";
            s97.Font.Size = 11;
            s97.Font.Color = "#000000";
            s97.Alignment.Horizontal = StyleHorizontalAlignment.Center;
            s97.Alignment.Vertical = StyleVerticalAlignment.Center;
            s97.Borders.Add(StylePosition.Bottom, LineStyleOption.Continuous, 1);
            s97.Borders.Add(StylePosition.Left, LineStyleOption.Continuous, 1);
            s97.Borders.Add(StylePosition.Right, LineStyleOption.Continuous, 1);
            s97.Borders.Add(StylePosition.Top, LineStyleOption.Continuous, 1);
            // -----------------------------------------------
            //  s102
            // -----------------------------------------------
            WorksheetStyle s102 = styles.Add("s102");
            s102.Font.Italic = true;
            s102.Font.FontName = "Times New Roman";
            s102.Font.Size = 11;
            s102.Font.Color = "#000000";
            s102.Alignment.Horizontal = StyleHorizontalAlignment.Right;
            s102.Alignment.Vertical = StyleVerticalAlignment.Center;
            s102.Alignment.WrapText = true;
            s102.Borders.Add(StylePosition.Bottom, LineStyleOption.Continuous, 1);
            s102.Borders.Add(StylePosition.Left, LineStyleOption.Continuous, 1);
            s102.Borders.Add(StylePosition.Right, LineStyleOption.Continuous, 1);
            // -----------------------------------------------
            //  s103
            // -----------------------------------------------
            WorksheetStyle s103 = styles.Add("s103");
            s103.Font.Bold = true;
            s103.Font.FontName = "Times New Roman";
            s103.Font.Size = 16;
            s103.Font.Color = "#000000";
            s103.Alignment.Horizontal = StyleHorizontalAlignment.Center;
            s103.Alignment.Vertical = StyleVerticalAlignment.Center;
            // -----------------------------------------------
            //  s104
            // -----------------------------------------------
            WorksheetStyle s104 = styles.Add("s104");
            s104.Font.Italic = true;
            s104.Font.FontName = "Times New Roman";
            s104.Font.Size = 11;
            s104.Font.Color = "#000000";
            s104.Alignment.Horizontal = StyleHorizontalAlignment.Center;
            s104.Alignment.Vertical = StyleVerticalAlignment.Center;
            // -----------------------------------------------
            //  s107
            // -----------------------------------------------
            WorksheetStyle s107 = styles.Add("s107");
            s107.Font.Bold = true;
            s107.Font.FontName = "Times New Roman";
            s107.Font.Size = 12;
            s107.Font.Color = "#FF0000";
            s107.Interior.Color = "#FFFF00";
            s107.Interior.Pattern = StyleInteriorPattern.Solid;
            s107.Alignment.Horizontal = StyleHorizontalAlignment.Right;
            s107.Alignment.Vertical = StyleVerticalAlignment.Center;
            s107.Borders.Add(StylePosition.Bottom, LineStyleOption.Continuous, 1);
            s107.Borders.Add(StylePosition.Left, LineStyleOption.Continuous, 1);
            s107.Borders.Add(StylePosition.Right, LineStyleOption.Continuous, 1);
            s107.Borders.Add(StylePosition.Top, LineStyleOption.Continuous, 1);
            // -----------------------------------------------
            //  s120
            // -----------------------------------------------
            WorksheetStyle s120 = styles.Add("s120");
            s120.Font.Bold = true;
            s120.Font.FontName = "Times New Roman";
            s120.Font.Size = 12;
            s120.Font.Color = "#376091";
            s120.Interior.Color = "#FCD5B4";
            s120.Interior.Pattern = StyleInteriorPattern.Solid;
            s120.Alignment.Horizontal = StyleHorizontalAlignment.Center;
            s120.Alignment.Vertical = StyleVerticalAlignment.Center;
            s120.Borders.Add(StylePosition.Bottom, LineStyleOption.Continuous, 1);
            s120.Borders.Add(StylePosition.Left, LineStyleOption.Continuous, 1);
            s120.Borders.Add(StylePosition.Right, LineStyleOption.Continuous, 1);
            s120.Borders.Add(StylePosition.Top, LineStyleOption.Continuous, 1);
            // -----------------------------------------------
            //  s126
            // -----------------------------------------------
            WorksheetStyle s126 = styles.Add("s126");
            s126.Font.Bold = true;
            s126.Font.Italic = true;
            s126.Font.FontName = "Times New Roman";
            s126.Font.Size = 11;
            s126.Font.Color = "#000000";
            s126.Interior.Color = "#DBE5F1";
            s126.Interior.Pattern = StyleInteriorPattern.Solid;
            s126.Alignment.Vertical = StyleVerticalAlignment.Center;
            s126.Borders.Add(StylePosition.Bottom, LineStyleOption.Continuous, 1);
            s126.Borders.Add(StylePosition.Left, LineStyleOption.Continuous, 1);
            s126.Borders.Add(StylePosition.Right, LineStyleOption.Continuous, 1);
            s126.Borders.Add(StylePosition.Top, LineStyleOption.Continuous, 1);
            s126.NumberFormat = "Standard";
            // -----------------------------------------------
            //  s132
            // -----------------------------------------------
            WorksheetStyle s132 = styles.Add("s132");
            s132.Font.FontName = "Times New Roman";
            s132.Font.Size = 11;
            s132.Font.Color = "#000000";
            s132.Alignment.Vertical = StyleVerticalAlignment.Center;
            s132.Borders.Add(StylePosition.Bottom, LineStyleOption.Continuous, 1);
            s132.Borders.Add(StylePosition.Left, LineStyleOption.Continuous, 1);
            s132.Borders.Add(StylePosition.Right, LineStyleOption.Continuous, 1);
            s132.Borders.Add(StylePosition.Top, LineStyleOption.Continuous, 1);
            // -----------------------------------------------
            //  s133
            // -----------------------------------------------
            WorksheetStyle s133 = styles.Add("s133");
            s133.Font.Bold = true;
            s133.Font.FontName = "Times New Roman";
            s133.Font.Size = 12;
            s133.Font.Color = "#FF0000";
            s133.Interior.Color = "#FFFF00";
            s133.Interior.Pattern = StyleInteriorPattern.Solid;
            s133.Alignment.Vertical = StyleVerticalAlignment.Center;
            s133.Borders.Add(StylePosition.Bottom, LineStyleOption.Continuous, 1);
            s133.Borders.Add(StylePosition.Left, LineStyleOption.Continuous, 1);
            s133.Borders.Add(StylePosition.Right, LineStyleOption.Continuous, 1);
            s133.Borders.Add(StylePosition.Top, LineStyleOption.Continuous, 1);
            s133.NumberFormat = "Standard";
        }

        private string GenerateWorksheet(WorksheetCollection sheets, DateTime dtdenngay, DataTable dtkh, ProgressBar progressBar)
        {
            try
            {
                tblhoadonbanBL ctrhdb = new tblhoadonbanBL();
                tblhoadonban objhdb = new tblhoadonban();
                tblmathangbanBL ctrmathangban = new tblmathangbanBL();
                tbltienthanhtoanBL ctrtiendatt = new tbltienthanhtoanBL();
                Worksheet sheet = sheets.Add("TKCongNo");
                sheet.Table.DefaultRowHeight = 15F;
                sheet.Table.ExpandedColumnCount = 6;
                sheet.Table.ExpandedRowCount = 5 + dtkh.Rows.Count;
                sheet.Table.FullColumns = 1;
                sheet.Table.FullRows = 1;
                sheet.Table.Columns.Add(36);
                sheet.Table.Columns.Add(75);
                sheet.Table.Columns.Add(138);
                sheet.Table.Columns.Add(99);
                sheet.Table.Columns.Add(191);
                sheet.Table.Columns.Add(131);
                // -----------------------------------------------
                #region Add Header
                Application.DoEvents();
                progressBar.PerformStep();
                Application.DoEvents();
                WorksheetRow Row0 = sheet.Table.Rows.Add();
                Row0.Height = 20;
                WorksheetCell cell;
                cell = Row0.Cells.Add();
                cell.StyleID = "s103";
                cell.Data.Type = DataType.String;
                cell.Data.Text = "TỔNG HỢP CÔNG NỢ BÁN HÀNG";
                cell.MergeAcross = 5;
                // -----------------------------------------------
                WorksheetRow Row1 = sheet.Table.Rows.Add();
                cell = Row1.Cells.Add();
                cell.StyleID = "s104";
                cell.Data.Type = DataType.String;
                cell.Data.Text = "(Số liệu tính đến ngày " + dtdenngay.ToString("dd/MM/yyyy") + ")";
                cell.MergeAcross = 5;
                // -----------------------------------------------
                WorksheetRow Row2 = sheet.Table.Rows.Add();
                cell = Row2.Cells.Add();
                cell.StyleID = "s102";
                cell.Data.Type = DataType.String;
                cell.Data.Text = "Đơn vị tính: VNĐ";
                cell.MergeAcross = 5;
                // -----------------------------------------------
                WorksheetRow Row3 = sheet.Table.Rows.Add();
                Row3.Height = 15;
                Row3.Cells.Add("Stt", DataType.String, "s120");
                Row3.Cells.Add("Cấp đại lý", DataType.String, "s120");
                Row3.Cells.Add("Tên khách hàng", DataType.String, "s120");
                Row3.Cells.Add("Điện thoại", DataType.String, "s120");
                Row3.Cells.Add("Địa chỉ", DataType.String, "s120");
                Row3.Cells.Add("Tổng tiền còn nợ", DataType.String, "s120");
                #endregion
                // -----------------------------------------------
                #region Add Content
                for (int i = 0; i < dtkh.Rows.Count; i++)
                {
                    Application.DoEvents();
                    progressBar.PerformStep();
                    Application.DoEvents();
                    string sidkh = "";
                    try { sidkh = dtkh.Rows[i]["id"].ToString().Trim(); }
                    catch { sidkh = "-/-"; }
                    string scapdl = "";
                    try { scapdl = dtkh.Rows[i]["id_capdl"].ToString().Trim(); }
                    catch { scapdl = "-/-"; }
                    string stenkh = "";
                    try { stenkh = dtkh.Rows[i]["tenkh"].ToString().Trim(); }
                    catch { stenkh = "-/-"; }
                    string sdt = "";
                    try { sdt = dtkh.Rows[i]["dt"].ToString().Trim(); }
                    catch { sdt = "-/-"; }
                    string sdiachi = "";
                    try { sdiachi = dtkh.Rows[i]["diachi"].ToString().Trim(); }
                    catch { sdiachi = "-/-"; }
                    if (sidkh.Trim().Equals("") == false)
                    {
                        // Lấy hóa đơn gần với ngày thống kê nhất
                        objhdb = new tblhoadonban();
                        Application.DoEvents();
                        progressBar.PerformStep();
                        Application.DoEvents();
                        objhdb = ctrhdb.GetNewFirstByNgayTaovsIDKH(dtdenngay.AddDays(1).ToString("yyyy/MM/dd").Trim(), sidkh);
                        if (objhdb != null)
                        {
                            double tienmuahang = 0;
                            try { tienmuahang = ctrmathangban.GetTongTienByIDHD(objhdb.id); }
                            catch { }
                            //double tientt = 0;
                            //tientt = objhdb.tienthanhtoan;
                            double chietkhau = 0;
                            chietkhau = objhdb.chietkhau;
                            double tiendatt = 0;
                            try { tiendatt = ctrtiendatt.GetTienDaThanhToan(objhdb.id); }
                            catch { }
                            double tienconnotoatruoc = 0;
                            try { tienconnotoatruoc = ctrhdb.GetTienConNo(objhdb.id_khachhang, objhdb.ngaytao); }
                            catch { }
                            double tienconno = 0;
                            tienconno = ((tienmuahang - tiendatt - chietkhau) + tienconnotoatruoc);
                            Application.DoEvents();
                            progressBar.PerformStep();
                            Application.DoEvents();
                            WorksheetRow Row = sheet.Table.Rows.Add();
                            Row.Cells.Add((i + 1).ToString(), DataType.Number, "s97");
                            Row.Cells.Add(scapdl, DataType.String, "s132");
                            Row.Cells.Add(stenkh, DataType.String, "s132");
                            Row.Cells.Add(sdt, DataType.String, "s132");
                            Row.Cells.Add(sdiachi, DataType.String, "s132");
                            Row.Cells.Add(tienconno.ToString().Trim(), DataType.Number, "s126");
                        }
                    }
                }
                #endregion
                // -----------------------------------------------
                #region Tính tổng các dòng
                Application.DoEvents();
                progressBar.PerformStep();
                Application.DoEvents();
                WorksheetRow Row7 = sheet.Table.Rows.Add();
                Row7.Height = 15;
                cell = Row7.Cells.Add();
                cell.StyleID = "s107";
                cell.Data.Type = DataType.String;
                cell.Data.Text = "TỔNG CỘNG";
                cell.MergeAcross = 4;
                cell = Row7.Cells.Add();
                cell.StyleID = "s133";
                cell.Data.Type = DataType.Number;
                cell.Formula = "=SUM(R[-" + dtkh.Rows.Count.ToString() + "]C:R[-1]C)";
                #endregion
                // -----------------------------------------------
                //  Options
                // -----------------------------------------------
                sheet.Options.Selected = true;
                sheet.Options.ProtectObjects = false;
                sheet.Options.ProtectScenarios = false;
                sheet.Options.PageSetup.Header.Margin = 0.3F;
                sheet.Options.PageSetup.Footer.Margin = 0.3F;
                sheet.Options.PageSetup.PageMargins.Bottom = 0.75F;
                sheet.Options.PageSetup.PageMargins.Left = 0.7F;
                sheet.Options.PageSetup.PageMargins.Right = 0.7F;
                sheet.Options.PageSetup.PageMargins.Top = 0.75F;
                sheet.Options.Print.HorizontalResolution = 300;
                sheet.Options.Print.VerticalResolution = 0;
                sheet.Options.Print.ValidPrinterInfo = true;
                return "";
            }
            catch (Exception ex) { return ex.Message; }
        }
    }
}
