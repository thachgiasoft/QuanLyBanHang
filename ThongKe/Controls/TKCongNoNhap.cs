using System;
using System.Xml;
using CarlosAg.ExcelXmlWriter;
using System.Data;
using System.Globalization;
using System.Windows.Forms;
using PhieuNhapKho.BusinesLogic;
using PhieuNhapKho.DataAccess;
using HoaDonDataAccess.BusinesLogic;

namespace ThongKe.Controls
{
    /// <summary>
    /// Mô tả thông tin cho class TKCongNo
    /// Cung cấp các hàm xử lý, thao tác về thống kê công nợ
    /// Người tạo (C): tuanva
    /// Ngày khởi tạo: 10/04/2016
    /// </summary>
    public class TKCongNoNhap
    {
        public string Generate(string filename, DateTime dtdengay, DataTable dtnhacc, ProgressBar progressBar)
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
                book.Properties.Title = "vuanhtuanbk248@gmail.com";
                book.Properties.Author = "QLBH v.1.0.1";
                book.Properties.LastAuthor = "QLBH v.1.0.1";
                book.Properties.Company = "GIABAO Ltd,.Co";
                book.Properties.Version = "12.00";
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
                string kq = this.GenerateWorksheetTKCongNo(book.Worksheets, dtdengay, dtnhacc, progressBar);
                if (kq.Trim().Equals("") == true)
                {
                    book.Save(filename); return kq;
                }
                else { return kq; }
            }
            catch (Exception ex)
            { return ex.Message; }
        }
        private void GenerateStyles(WorksheetStyleCollection styles) {
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
            //  m83608040
            // -----------------------------------------------
            WorksheetStyle m83608040 = styles.Add("m83608040");
            m83608040.Font.Italic = true;
            m83608040.Font.FontName = "Times New Roman";
            m83608040.Font.Size = 11;
            m83608040.Font.Color = "#000000";
            m83608040.Alignment.Horizontal = StyleHorizontalAlignment.Right;
            m83608040.Alignment.Vertical = StyleVerticalAlignment.Center;
            m83608040.Alignment.WrapText = true;
            m83608040.Borders.Add(StylePosition.Bottom, LineStyleOption.Continuous, 1, "#000000");
            m83608040.Borders.Add(StylePosition.Left, LineStyleOption.Continuous, 1, "#000000");
            m83608040.Borders.Add(StylePosition.Right, LineStyleOption.Continuous, 1, "#000000");
            // -----------------------------------------------
            //  m83608060
            // -----------------------------------------------
            WorksheetStyle m83608060 = styles.Add("m83608060");
            m83608060.Font.Bold = true;
            m83608060.Font.FontName = "Times New Roman";
            m83608060.Font.Size = 12;
            m83608060.Font.Color = "#FF0000";
            m83608060.Interior.Color = "#FFFF00";
            m83608060.Interior.Pattern = StyleInteriorPattern.Solid;
            m83608060.Alignment.Horizontal = StyleHorizontalAlignment.Right;
            m83608060.Alignment.Vertical = StyleVerticalAlignment.Center;
            m83608060.Borders.Add(StylePosition.Bottom, LineStyleOption.Continuous, 1, "#000000");
            m83608060.Borders.Add(StylePosition.Left, LineStyleOption.Continuous, 1, "#000000");
            m83608060.Borders.Add(StylePosition.Right, LineStyleOption.Continuous, 1, "#000000");
            m83608060.Borders.Add(StylePosition.Top, LineStyleOption.Continuous, 1, "#000000");
            // -----------------------------------------------
            //  s67
            // -----------------------------------------------
            WorksheetStyle s67 = styles.Add("s67");
            s67.Font.Bold = true;
            s67.Font.FontName = "Times New Roman";
            s67.Font.Size = 12;
            s67.Font.Color = "#333399";
            s67.Interior.Color = "#FCD5B4";
            s67.Interior.Pattern = StyleInteriorPattern.Solid;
            s67.Alignment.Horizontal = StyleHorizontalAlignment.Center;
            s67.Alignment.Vertical = StyleVerticalAlignment.Center;
            s67.Borders.Add(StylePosition.Bottom, LineStyleOption.Continuous, 1, "#000000");
            s67.Borders.Add(StylePosition.Left, LineStyleOption.Continuous, 1, "#000000");
            s67.Borders.Add(StylePosition.Right, LineStyleOption.Continuous, 1, "#000000");
            s67.Borders.Add(StylePosition.Top, LineStyleOption.Continuous, 1, "#000000");
            // -----------------------------------------------
            //  s68
            // -----------------------------------------------
            WorksheetStyle s68 = styles.Add("s68");
            s68.Font.FontName = "Times New Roman";
            s68.Font.Size = 11;
            s68.Font.Color = "#000000";
            s68.Alignment.Horizontal = StyleHorizontalAlignment.Center;
            s68.Alignment.Vertical = StyleVerticalAlignment.Center;
            s68.Borders.Add(StylePosition.Bottom, LineStyleOption.Continuous, 1, "#000000");
            s68.Borders.Add(StylePosition.Left, LineStyleOption.Continuous, 1, "#000000");
            s68.Borders.Add(StylePosition.Right, LineStyleOption.Continuous, 1, "#000000");
            s68.Borders.Add(StylePosition.Top, LineStyleOption.Continuous, 1, "#000000");
            // -----------------------------------------------
            //  s69
            // -----------------------------------------------
            WorksheetStyle s69 = styles.Add("s69");
            s69.Font.FontName = "Times New Roman";
            s69.Font.Size = 11;
            s69.Font.Color = "#000000";
            s69.Alignment.Vertical = StyleVerticalAlignment.Center;
            s69.Borders.Add(StylePosition.Bottom, LineStyleOption.Continuous, 1, "#000000");
            s69.Borders.Add(StylePosition.Left, LineStyleOption.Continuous, 1, "#000000");
            s69.Borders.Add(StylePosition.Right, LineStyleOption.Continuous, 1, "#000000");
            s69.Borders.Add(StylePosition.Top, LineStyleOption.Continuous, 1, "#000000");
            // -----------------------------------------------
            //  s70
            // -----------------------------------------------
            WorksheetStyle s70 = styles.Add("s70");
            s70.Font.Bold = true;
            s70.Font.Italic = true;
            s70.Font.FontName = "Times New Roman";
            s70.Font.Size = 11;
            s70.Font.Color = "#000000";
            s70.Interior.Color = "#DBE5F1";
            s70.Interior.Pattern = StyleInteriorPattern.Solid;
            s70.Alignment.Vertical = StyleVerticalAlignment.Center;
            s70.Borders.Add(StylePosition.Bottom, LineStyleOption.Continuous, 1, "#000000");
            s70.Borders.Add(StylePosition.Left, LineStyleOption.Continuous, 1, "#000000");
            s70.Borders.Add(StylePosition.Right, LineStyleOption.Continuous, 1, "#000000");
            s70.Borders.Add(StylePosition.Top, LineStyleOption.Continuous, 1, "#000000");
            s70.NumberFormat = "Standard";
            // -----------------------------------------------
            //  s74
            // -----------------------------------------------
            WorksheetStyle s74 = styles.Add("s74");
            s74.Font.Bold = true;
            s74.Font.FontName = "Times New Roman";
            s74.Font.Size = 12;
            s74.Font.Color = "#FF0000";
            s74.Interior.Color = "#FFFF00";
            s74.Interior.Pattern = StyleInteriorPattern.Solid;
            s74.Alignment.Vertical = StyleVerticalAlignment.Center;
            s74.Borders.Add(StylePosition.Bottom, LineStyleOption.Continuous, 1, "#000000");
            s74.Borders.Add(StylePosition.Left, LineStyleOption.Continuous, 1, "#000000");
            s74.Borders.Add(StylePosition.Right, LineStyleOption.Continuous, 1, "#000000");
            s74.Borders.Add(StylePosition.Top, LineStyleOption.Continuous, 1, "#000000");
            s74.NumberFormat = "Standard";
            // -----------------------------------------------
            //  s75
            // -----------------------------------------------
            WorksheetStyle s75 = styles.Add("s75");
            s75.Font.Bold = true;
            s75.Font.FontName = "Times New Roman";
            s75.Font.Size = 16;
            s75.Font.Color = "#000000";
            s75.Alignment.Horizontal = StyleHorizontalAlignment.Center;
            s75.Alignment.Vertical = StyleVerticalAlignment.Center;
            // -----------------------------------------------
            //  s76
            // -----------------------------------------------
            WorksheetStyle s76 = styles.Add("s76");
            s76.Font.Italic = true;
            s76.Font.FontName = "Times New Roman";
            s76.Font.Size = 11;
            s76.Font.Color = "#000000";
            s76.Alignment.Horizontal = StyleHorizontalAlignment.Center;
            s76.Alignment.Vertical = StyleVerticalAlignment.Center;
        }
        private string GenerateWorksheetTKCongNo(WorksheetCollection sheets, DateTime dtdenngay, DataTable dtnhacc, ProgressBar progressBar)
        {
            try
            {
                tblphieunhapkhoBL ctrpn = new tblphieunhapkhoBL();
                tblphieunhapkho objpn = new tblphieunhapkho();
                tblhangnhapkhoBL ctrhangnhapkho = new tblhangnhapkhoBL();
                tienthanhtoanphieunhapBL ctrtiendatt = new tienthanhtoanphieunhapBL();
                Worksheet sheet = sheets.Add("TKCongNoNhapHang");
                sheet.Table.DefaultRowHeight = 15F;
                sheet.Table.ExpandedColumnCount = 5;
                sheet.Table.ExpandedRowCount = 5 + dtnhacc.Rows.Count;
                sheet.Table.FullColumns = 1;
                sheet.Table.FullRows = 1;
                sheet.Table.Columns.Add(36);
                sheet.Table.Columns.Add(193);
                sheet.Table.Columns.Add(149);
                sheet.Table.Columns.Add(191);
                sheet.Table.Columns.Add(159);
                // -----------------------------------------------
                #region Add Header
                WorksheetRow Row0 = sheet.Table.Rows.Add();
                Row0.Height = 20;
                Row0.AutoFitHeight = false;
                WorksheetCell cell;
                cell = Row0.Cells.Add();
                cell.StyleID = "s75";
                cell.Data.Type = DataType.String;
                cell.Data.Text = "TỔNG HỢP CÔNG NỢ NHẬP HÀNG";
                cell.MergeAcross = 4;
                // -----------------------------------------------
                WorksheetRow Row1 = sheet.Table.Rows.Add();
                Row1.AutoFitHeight = false;
                cell = Row1.Cells.Add();
                cell.StyleID = "s76";
                cell.Data.Type = DataType.String;
                cell.Data.Text = "(Số liệu tính đến ngày " + dtdenngay.ToString("dd/MM/yyyy") + ")";
                cell.MergeAcross = 4;
                // -----------------------------------------------
                WorksheetRow Row2 = sheet.Table.Rows.Add();
                Row2.AutoFitHeight = false;
                cell = Row2.Cells.Add();
                cell.StyleID = "m83608040";
                cell.Data.Type = DataType.String;
                cell.Data.Text = "Đơn vị tính: VNĐ";
                cell.MergeAcross = 4;
                // -----------------------------------------------
                WorksheetRow Row3 = sheet.Table.Rows.Add();
                Row3.AutoFitHeight = false;
                Row3.Cells.Add("Stt", DataType.String, "s67");
                Row3.Cells.Add("Nhà cung cấp", DataType.String, "s67");
                Row3.Cells.Add("Điện thoại", DataType.String, "s67");
                Row3.Cells.Add("Địa chỉ", DataType.String, "s67");
                Row3.Cells.Add("Tổng tiền còn nợ", DataType.String, "s67");
                #endregion
                // -----------------------------------------------
                #region Add Content
                for (int i = 0; i < dtnhacc.Rows.Count; i++)
                {
                    Application.DoEvents();
                    progressBar.PerformStep();
                    Application.DoEvents();
                    string sidnhacc = "";
                    try { sidnhacc = dtnhacc.Rows[i]["id"].ToString().Trim(); }
                    catch { sidnhacc = "-/-"; }
                    string stennhacc = "";
                    try { stennhacc = dtnhacc.Rows[i]["ten"].ToString().Trim(); }
                    catch { stennhacc = "-/-"; }
                    string sdt = "";
                    try { sdt = dtnhacc.Rows[i]["dienthoai"].ToString().Trim(); }
                    catch { sdt = "-/-"; }
                    string sdiachi = "";
                    try { sdiachi = dtnhacc.Rows[i]["diachi"].ToString().Trim(); }
                    catch { sdiachi = "-/-"; }
                    if (sidnhacc.Trim().Equals("") == false)
                    {
                        // Lấy hóa đơn gần với ngày thống kê nhất
                        objpn = new tblphieunhapkho();
                        Application.DoEvents();
                        progressBar.PerformStep();
                        Application.DoEvents();
                        objpn = ctrpn.GetNewFirstByNgayTaovsIDKH(dtdenngay.AddDays(1).ToString("yyyy/MM/dd").Trim(), sidnhacc);
                        if (objpn != null)
                        {
                            double tienmuahang = 0;
                            try { tienmuahang = ctrhangnhapkho.GetTongTienByIDPN(objpn.id); }
                            catch { }
                            //double tientt = 0;
                            //tientt = objpn.tienthanhtoan;
                            double chietkhau = 0;
                            chietkhau = objpn.chietkhau;
                            double tiendatt = 0;
                            try { tiendatt = ctrtiendatt.GetTienDaThanhToan(objpn.id); }
                            catch { }
                            double tienconnotoatruoc = 0;
                            try { tienconnotoatruoc = ctrpn.GetTienConNo(objpn.id_nguoicap, objpn.ngaytao); }
                            catch { }
                            double tienconno = 0;
                            tienconno = ((tienmuahang - tiendatt - chietkhau) + tienconnotoatruoc);
                            Application.DoEvents();
                            progressBar.PerformStep();
                            Application.DoEvents();
                            WorksheetRow Row = sheet.Table.Rows.Add();
                            Row.Cells.Add((i + 1).ToString(), DataType.Number, "s68");
                            Row.Cells.Add(stennhacc, DataType.String, "s69");
                            Row.Cells.Add(sdt, DataType.String, "s69");
                            Row.Cells.Add(sdiachi, DataType.String, "s69");
                            Row.Cells.Add(tienconno.ToString().Trim(), DataType.Number, "s70");
                        }
                    }
                }
                #endregion
                // -----------------------------------------------
                #region Tính tổng các dòng
                WorksheetRow Row7 = sheet.Table.Rows.Add();
                Row7.AutoFitHeight = false;
                cell = Row7.Cells.Add();
                cell.StyleID = "m83608060";
                cell.Data.Type = DataType.String;
                cell.Data.Text = "TỔNG CỘNG";
                cell.MergeAcross = 3;
                cell = Row7.Cells.Add();
                cell.StyleID = "s74";
                cell.Data.Type = DataType.Number;
                cell.Formula = "=SUM(R[-" + dtnhacc.Rows.Count.ToString() + "]C:R[-1]C)";
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
