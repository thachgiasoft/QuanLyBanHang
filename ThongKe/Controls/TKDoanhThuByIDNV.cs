using System;
using System.Xml;
using CarlosAg.ExcelXmlWriter;
using System.Data;
using System.Globalization;
using System.Windows.Forms;
using HoaDonDataAccess.BusinesLogic;

namespace ThongKe.Controls
{
    public class TKDoanhThuByIDNV
    {
        public string Generate(string filename, DateTime dttungay, DateTime dtdengay, DataTable dtnv, ProgressBar progressBar)
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
                //  Generate Sheet1 Worksheet
                // -----------------------------------------------
                Application.DoEvents();
                progressBar.PerformStep();
                Application.DoEvents();
                string kq = this.GenerateWorksheet(book.Worksheets, dttungay, dtdengay, dtnv, progressBar);
                if (kq.Trim().Equals("") == true)
                {
                    book.Save(filename); return kq;
                }
                else { return kq; }
            }
            catch (Exception ex) { return ex.Message; }
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
            //  m66637088
            // -----------------------------------------------
            WorksheetStyle m66637088 = styles.Add("m66637088");
            m66637088.Font.Bold = true;
            m66637088.Font.FontName = "Times New Roman";
            m66637088.Font.Size = 11;
            m66637088.Font.Color = "#000000";
            m66637088.Interior.Color = "#8DB4E3";
            m66637088.Interior.Pattern = StyleInteriorPattern.Solid;
            m66637088.Alignment.Horizontal = StyleHorizontalAlignment.Right;
            m66637088.Alignment.Vertical = StyleVerticalAlignment.Center;
            m66637088.Alignment.WrapText = true;
            m66637088.Borders.Add(StylePosition.Bottom, LineStyleOption.Continuous, 1, "#000000");
            m66637088.Borders.Add(StylePosition.Right, LineStyleOption.Continuous, 1, "#000000");
            m66637088.Borders.Add(StylePosition.Top, LineStyleOption.Continuous, 1, "#000000");
            // -----------------------------------------------
            //  m66637108
            // -----------------------------------------------
            WorksheetStyle m66637108 = styles.Add("m66637108");
            m66637108.Font.Bold = true;
            m66637108.Font.FontName = "Times New Roman";
            m66637108.Font.Size = 11;
            m66637108.Font.Color = "#FF0000";
            m66637108.Interior.Color = "#FFFF00";
            m66637108.Interior.Pattern = StyleInteriorPattern.Solid;
            m66637108.Alignment.Horizontal = StyleHorizontalAlignment.Right;
            m66637108.Alignment.Vertical = StyleVerticalAlignment.Center;
            m66637108.Alignment.WrapText = true;
            m66637108.Borders.Add(StylePosition.Bottom, LineStyleOption.Continuous, 1, "#000000");
            m66637108.Borders.Add(StylePosition.Left, LineStyleOption.Continuous, 1, "#000000");
            m66637108.Borders.Add(StylePosition.Right, LineStyleOption.Continuous, 1, "#000000");
            m66637108.Borders.Add(StylePosition.Top, LineStyleOption.Continuous, 1, "#000000");
            // -----------------------------------------------
            //  m66637128
            // -----------------------------------------------
            WorksheetStyle m66637128 = styles.Add("m66637128");
            m66637128.Font.FontName = "Times New Roman";
            m66637128.Font.Size = 11;
            m66637128.Font.Color = "#000000";
            m66637128.Interior.Color = "#FFFFFF";
            m66637128.Interior.Pattern = StyleInteriorPattern.Solid;
            m66637128.Alignment.Horizontal = StyleHorizontalAlignment.Center;
            m66637128.Alignment.Vertical = StyleVerticalAlignment.Center;
            m66637128.Alignment.WrapText = true;
            m66637128.Borders.Add(StylePosition.Bottom, LineStyleOption.Continuous, 1, "#000000");
            m66637128.Borders.Add(StylePosition.Left, LineStyleOption.Continuous, 1, "#000000");
            m66637128.Borders.Add(StylePosition.Right, LineStyleOption.Continuous, 1, "#000000");
            m66637128.Borders.Add(StylePosition.Top, LineStyleOption.Continuous, 1, "#000000");
            m66637128.NumberFormat = "Standard";
            // -----------------------------------------------
            //  s62
            // -----------------------------------------------
            WorksheetStyle s62 = styles.Add("s62");
            s62.Alignment.Horizontal = StyleHorizontalAlignment.Center;
            s62.Alignment.Vertical = StyleVerticalAlignment.Bottom;
            // -----------------------------------------------
            //  s64
            // -----------------------------------------------
            WorksheetStyle s64 = styles.Add("s64");
            s64.Font.Bold = true;
            s64.Font.FontName = "Times New Roman";
            s64.Font.Size = 11;
            s64.Font.Color = "#000000";
            s64.Interior.Color = "#FAC090";
            s64.Interior.Pattern = StyleInteriorPattern.Solid;
            s64.Alignment.Horizontal = StyleHorizontalAlignment.Center;
            s64.Alignment.Vertical = StyleVerticalAlignment.Center;
            s64.Alignment.WrapText = true;
            s64.Borders.Add(StylePosition.Bottom, LineStyleOption.Continuous, 1, "#000000");
            s64.Borders.Add(StylePosition.Left, LineStyleOption.Continuous, 1, "#000000");
            s64.Borders.Add(StylePosition.Right, LineStyleOption.Continuous, 1, "#000000");
            s64.Borders.Add(StylePosition.Top, LineStyleOption.Continuous, 1, "#000000");
            // -----------------------------------------------
            //  s65
            // -----------------------------------------------
            WorksheetStyle s65 = styles.Add("s65");
            s65.Font.FontName = "Times New Roman";
            s65.Font.Size = 11;
            s65.Font.Color = "#000000";
            s65.Interior.Color = "#FFFFFF";
            s65.Interior.Pattern = StyleInteriorPattern.Solid;
            s65.Alignment.Horizontal = StyleHorizontalAlignment.Center;
            s65.Alignment.Vertical = StyleVerticalAlignment.Center;
            s65.Alignment.WrapText = true;
            s65.Borders.Add(StylePosition.Bottom, LineStyleOption.Continuous, 1, "#000000");
            s65.Borders.Add(StylePosition.Left, LineStyleOption.Continuous, 1, "#000000");
            s65.Borders.Add(StylePosition.Right, LineStyleOption.Continuous, 1, "#000000");
            s65.Borders.Add(StylePosition.Top, LineStyleOption.Continuous, 1, "#000000");
            // -----------------------------------------------
            //  s66
            // -----------------------------------------------
            WorksheetStyle s66 = styles.Add("s66");
            s66.Font.FontName = "Times New Roman";
            s66.Font.Size = 11;
            s66.Font.Color = "#000000";
            s66.Interior.Color = "#FFFFFF";
            s66.Interior.Pattern = StyleInteriorPattern.Solid;
            s66.Alignment.Vertical = StyleVerticalAlignment.Center;
            s66.Alignment.WrapText = true;
            s66.Borders.Add(StylePosition.Bottom, LineStyleOption.Continuous, 1, "#000000");
            s66.Borders.Add(StylePosition.Left, LineStyleOption.Continuous, 1, "#000000");
            s66.Borders.Add(StylePosition.Right, LineStyleOption.Continuous, 1, "#000000");
            s66.Borders.Add(StylePosition.Top, LineStyleOption.Continuous, 1, "#000000");
            s66.NumberFormat = "Standard";
            // -----------------------------------------------
            //  s67
            // -----------------------------------------------
            WorksheetStyle s67 = styles.Add("s67");
            s67.Font.FontName = "Times New Roman";
            s67.Font.Size = 11;
            s67.Font.Color = "#000000";
            s67.Interior.Color = "#FFFFFF";
            s67.Interior.Pattern = StyleInteriorPattern.Solid;
            s67.Alignment.Vertical = StyleVerticalAlignment.Center;
            s67.Alignment.WrapText = true;
            s67.Borders.Add(StylePosition.Bottom, LineStyleOption.Continuous, 1, "#000000");
            s67.Borders.Add(StylePosition.Left, LineStyleOption.Continuous, 1, "#000000");
            s67.Borders.Add(StylePosition.Right, LineStyleOption.Continuous, 1, "#000000");
            s67.Borders.Add(StylePosition.Top, LineStyleOption.Continuous, 1, "#000000");
            // -----------------------------------------------
            //  s68
            // -----------------------------------------------
            WorksheetStyle s68 = styles.Add("s68");
            s68.Font.Bold = true;
            s68.Font.FontName = "Times New Roman";
            s68.Font.Size = 11;
            s68.Font.Color = "#000000";
            s68.Interior.Color = "#8DB4E3";
            s68.Interior.Pattern = StyleInteriorPattern.Solid;
            s68.Alignment.Vertical = StyleVerticalAlignment.Center;
            s68.Alignment.WrapText = true;
            s68.Borders.Add(StylePosition.Bottom, LineStyleOption.Continuous, 1, "#000000");
            s68.Borders.Add(StylePosition.Left, LineStyleOption.Continuous, 1, "#000000");
            s68.Borders.Add(StylePosition.Right, LineStyleOption.Continuous, 1, "#000000");
            s68.Borders.Add(StylePosition.Top, LineStyleOption.Continuous, 1, "#000000");
            s68.NumberFormat = "Standard";
            // -----------------------------------------------
            //  s69
            // -----------------------------------------------
            WorksheetStyle s69 = styles.Add("s69");
            s69.Font.Bold = true;
            s69.Font.FontName = "Times New Roman";
            s69.Font.Size = 11;
            s69.Font.Color = "#FF0000";
            s69.Interior.Color = "#FFFF00";
            s69.Interior.Pattern = StyleInteriorPattern.Solid;
            s69.Alignment.Vertical = StyleVerticalAlignment.Center;
            s69.Alignment.WrapText = true;
            s69.Borders.Add(StylePosition.Bottom, LineStyleOption.Continuous, 1, "#000000");
            s69.Borders.Add(StylePosition.Left, LineStyleOption.Continuous, 1, "#000000");
            s69.Borders.Add(StylePosition.Right, LineStyleOption.Continuous, 1, "#000000");
            s69.Borders.Add(StylePosition.Top, LineStyleOption.Continuous, 1, "#000000");
            s69.NumberFormat = "Standard";
            // -----------------------------------------------
            //  s90
            // -----------------------------------------------
            WorksheetStyle s90 = styles.Add("s90");
            s90.Font.Bold = true;
            s90.Font.FontName = "Times New Roman";
            s90.Font.Size = 18;
            s90.Font.Color = "#000000";
            s90.Alignment.Horizontal = StyleHorizontalAlignment.Center;
            s90.Alignment.Vertical = StyleVerticalAlignment.Center;
            s90.Alignment.WrapText = true;
            // -----------------------------------------------
            //  s91
            // -----------------------------------------------
            WorksheetStyle s91 = styles.Add("s91");
            s91.Font.Italic = true;
            s91.Font.FontName = "Times New Roman";
            s91.Font.Color = "#000000";
            s91.Alignment.Horizontal = StyleHorizontalAlignment.Center;
            s91.Alignment.Vertical = StyleVerticalAlignment.Center;
            s91.Alignment.WrapText = true;
            // -----------------------------------------------
            //  s92
            // -----------------------------------------------
            WorksheetStyle s92 = styles.Add("s92");
            s92.Font.FontName = "Times New Roman";
            s92.Font.Size = 11;
            s92.Font.Color = "#000000";
            s92.Interior.Color = "#FFFFFF";
            s92.Interior.Pattern = StyleInteriorPattern.Solid;
            s92.Alignment.Horizontal = StyleHorizontalAlignment.Center;
            s92.Alignment.Vertical = StyleVerticalAlignment.Center;
            s92.Alignment.WrapText = true;
            s92.Borders.Add(StylePosition.Left, LineStyleOption.Continuous, 1, "#000000");
            s92.Borders.Add(StylePosition.Right, LineStyleOption.Continuous, 1, "#000000");
            s92.Borders.Add(StylePosition.Top, LineStyleOption.Continuous, 1, "#000000");
            // -----------------------------------------------
            //  s96
            // -----------------------------------------------
            WorksheetStyle s96 = styles.Add("s96");
            s96.Font.Italic = true;
            s96.Font.FontName = "Times New Roman";
            s96.Font.Color = "#000000";
            s96.Alignment.Horizontal = StyleHorizontalAlignment.Right;
            s96.Alignment.Vertical = StyleVerticalAlignment.Center;
            s96.Alignment.WrapText = true;
            s96.Borders.Add(StylePosition.Bottom, LineStyleOption.Continuous, 1, "#000000");
        }

        private string GenerateWorksheet(WorksheetCollection sheets, DateTime dttungay, DateTime dtdenngay, DataTable dtnv, ProgressBar progressBar)
        {
            Application.DoEvents();
            progressBar.PerformStep();
            Application.DoEvents();
            tblhoadonbanBL ctrhd = new tblhoadonbanBL();
            Worksheet sheet = sheets.Add("TKDoanhThu");
            sheet.Table.DefaultRowHeight = 15F;
            sheet.Table.ExpandedColumnCount = 10;
            if (dtnv.Rows.Count > 1)
            {
                try
                {
                    DataTable dttemp = ctrhd.TKDoanhThu(dttungay.ToString(), dtdenngay.AddDays(1).ToString());
                    sheet.Table.ExpandedRowCount = 8 + dttemp.Rows.Count;
                }
                catch (Exception ex)
                {
                    return ex.Message;
                }
            }
            if (dtnv.Rows.Count == 1)
            {
                try
                {
                    DataTable dttemp = ctrhd.TKDoanhThubyIDNV(dttungay.ToString(), dtdenngay.AddDays(1).ToString(), dtnv.Rows[0]["taikhoan"].ToString().Trim());
                    sheet.Table.ExpandedRowCount = 8 + dttemp.Rows.Count;
                }
                catch (Exception ex)
                {
                    return ex.Message;
                }
            }
            sheet.Table.FullColumns = 1;
            sheet.Table.FullRows = 1;
            WorksheetColumn column0 = sheet.Table.Columns.Add();
            column0.Width = 24;
            column0.StyleID = "s62";
            WorksheetColumn column1 = sheet.Table.Columns.Add();
            column1.Width = 65;
            column1.StyleID = "s62";
            WorksheetColumn column2 = sheet.Table.Columns.Add();
            column2.Width = 78;
            column2.StyleID = "s62";
            WorksheetColumn column3 = sheet.Table.Columns.Add();
            column3.Width = 93;
            column3.StyleID = "s62";
            sheet.Table.Columns.Add(132);
            sheet.Table.Columns.Add(95);
            sheet.Table.Columns.Add(76);
            sheet.Table.Columns.Add(75);
            sheet.Table.Columns.Add(80);
            sheet.Table.Columns.Add(144);
            // -----------------------------------------------
            #region Add header
            Application.DoEvents();
            progressBar.PerformStep();
            Application.DoEvents();
            WorksheetRow Row0 = sheet.Table.Rows.Add();
            Row0.Height = 23;
            Row0.AutoFitHeight = false;
            WorksheetCell cell;
            cell = Row0.Cells.Add();
            cell.StyleID = "s90";
            cell.Data.Type = DataType.String;
            cell.Data.Text = "THỐNG KÊ DOANH THU";
            cell.MergeAcross = 8;
            // -----------------------------------------------
            WorksheetRow Row1 = sheet.Table.Rows.Add();
            Row1.AutoFitHeight = false;
            cell = Row1.Cells.Add();
            cell.StyleID = "s91";
            cell.Data.Type = DataType.String;
            cell.Data.Text = "(Từ ngày " + dttungay.ToString("dd/MM/yyyy") + " đến ngày " + dtdenngay.ToString("dd/MM/yyyy") + ")";
            cell.MergeAcross = 8;
            // -----------------------------------------------
            WorksheetRow Row2 = sheet.Table.Rows.Add();
            Row2.AutoFitHeight = false;
            cell = Row2.Cells.Add();
            cell.StyleID = "s96";
            cell.Data.Type = DataType.String;
            cell.Data.Text = "Đơn vị tính: VNÐ";
            cell.MergeAcross = 8;
            // -----------------------------------------------
            WorksheetRow Row3 = sheet.Table.Rows.Add();
            Row3.AutoFitHeight = false;
            Row3.Cells.Add("Stt", DataType.String, "s64");
            Row3.Cells.Add("Nhân viên", DataType.String, "s64");
            Row3.Cells.Add("Doanh thu", DataType.String, "s64");
            Row3.Cells.Add("Ngày xuất HĐ", DataType.String, "s64");
            Row3.Cells.Add("Tên khách hàng", DataType.String, "s64");
            Row3.Cells.Add("Tiền vốn/HĐ", DataType.String, "s64");
            Row3.Cells.Add("Doanh thu/HĐ", DataType.String, "s64");
            Row3.Cells.Add("Lợi nhuận/HĐ", DataType.String, "s64");
            Row3.Cells.Add("Chiết khấu/HĐ", DataType.String, "s64");

            #endregion
            // -----------------------------------------------
            #region Add Content
            int rowcount = 0;
            for (int i = 0; i < dtnv.Rows.Count; i++)
            {
                Application.DoEvents();
                progressBar.PerformStep();
                Application.DoEvents();
                string sidnv = "";
                try { sidnv = dtnv.Rows[i]["taikhoan"].ToString().Trim(); }
                catch { }
                string shoten = "";
                try { shoten = dtnv.Rows[i]["hoten"].ToString().Trim(); }
                catch { shoten = "-/-"; }
                DataTable dt = new DataTable();
                Application.DoEvents();
                progressBar.PerformStep();
                Application.DoEvents();
                dt = ctrhd.TKDoanhThubyIDNV(dttungay.ToString(), dtdenngay.AddDays(1).ToString(), sidnv);
                if (i == 0) { rowcount = dt.Rows.Count; }
                if (i > 0)
                {
                    if (rowcount > 0) { rowcount = rowcount + dt.Rows.Count; }
                    if (rowcount == 0) { rowcount = dt.Rows.Count; }
               }
                for (int j = 0; j < dt.Rows.Count; j++)
                {
                    WorksheetRow row = sheet.Table.Rows.Add();
                    if (j == 0)
                    {
                        row.Cells.Add((j + 1).ToString().Trim(), DataType.Number, "s65");
                        cell = row.Cells.Add();
                        cell.StyleID = "s92";
                        cell.Data.Type = DataType.String;
                        cell.Data.Text = shoten;
                        cell.MergeDown = dt.Rows.Count - 1;
                        cell = row.Cells.Add();
                        cell.StyleID = "m66637128";
                        cell.Data.Type = DataType.Number;
                        cell.MergeDown = dt.Rows.Count - 1;
                        if (i == 0)
                        {
                            cell.Formula = "=SUM(RC[4]:R[" + (dt.Rows.Count - 1).ToString().Trim() + "]C[4])";
                        }
                        if (i == 1)
                        {
                            if (dt.Rows.Count > 1)
                            {
                                cell.Formula = "=SUM(RC[4]:R[" + (rowcount - 1 - i).ToString().Trim() + "]C[4])";
                            }
                            else { cell.Formula = "=SUM(RC[4]:R[0]C[4])"; }
                        }
                        if (i > 1)
                        {
                            if (dt.Rows.Count > 1)
                            {
                                cell.Formula = "=SUM(RC[4]:R[" + (rowcount - 1 - i).ToString().Trim() + "]C[4])";
                            }
                            else { cell.Formula = "=SUM(RC[4]:R[0]C[4])"; }
                        }
                        DateTime dttemp = Convert.ToDateTime(dt.Rows[j]["ngaytao"].ToString().Trim());
                        row.Cells.Add(dttemp.ToString("dd/MM/yyyy HH:mm:ss").Trim(), DataType.String, "s67");
                        row.Cells.Add(dt.Rows[j]["tenkh"].ToString().Trim(), DataType.String, "s67");
                        row.Cells.Add(dt.Rows[j]["gianhap"].ToString().Trim(), DataType.Number, "s66");
                        row.Cells.Add(dt.Rows[j]["tongtien"].ToString().Trim(), DataType.Number, "s66");
                        cell = row.Cells.Add();
                        cell.StyleID = "s66";
                        cell.Data.Type = DataType.Number;
                        cell.Formula = "=RC[-1]-RC[-2]-RC[1]";
                        row.Cells.Add(dt.Rows[j]["chietkhau"].ToString().Trim(), DataType.Number, "s66");
                    }
                    else
                    {
                        row.Cells.Add((j + 1).ToString().Trim(), DataType.Number, "s65");
                        cell = row.Cells.Add();
                        cell.StyleID = "s67";
                        cell.Data.Type = DataType.String;
                        DateTime dttemp = Convert.ToDateTime(dt.Rows[j]["ngaytao"].ToString().Trim());
                        cell.Data.Text = dttemp.ToString("dd/MM/yyyy HH:mm:ss").Trim();
                        cell.Index = 4;
                        row.Cells.Add(dt.Rows[j]["tenkh"].ToString().Trim(), DataType.String, "s67");
                        row.Cells.Add(dt.Rows[j]["gianhap"].ToString().Trim(), DataType.Number, "s66");
                        row.Cells.Add(dt.Rows[j]["tongtien"].ToString().Trim(), DataType.Number, "s66");
                        cell = row.Cells.Add();
                        cell.StyleID = "s66";
                        cell.Data.Type = DataType.Number;
                        cell.Formula = "=RC[-1]-RC[-2]-RC[1]";
                        row.Cells.Add(dt.Rows[j]["chietkhau"].ToString().Trim(), DataType.Number, "s66");
                    }
                }
            }
            #endregion
            // -----------------------------------------------
            #region Add Tính toán Sum
            Application.DoEvents();
            progressBar.PerformStep();
            Application.DoEvents();
            WorksheetRow Row7 = sheet.Table.Rows.Add();
            Row7.AutoFitHeight = false;
            cell = Row7.Cells.Add();
            cell.StyleID = "m66637088";
            cell.Data.Type = DataType.String;
            cell.Data.Text = "Tổng doanh thu";
            cell.MergeAcross = 7;
            cell = Row7.Cells.Add();
            cell.StyleID = "s68";
            cell.Data.Type = DataType.Number;
            cell.Formula = "=SUM(R[-" + rowcount.ToString().Trim() + "]C[-2]:R[-1]C[-2])";
            // -----------------------------------------------
            WorksheetRow Row8 = sheet.Table.Rows.Add();
            Row8.AutoFitHeight = false;
            cell = Row8.Cells.Add();
            cell.StyleID = "m66637108";
            cell.Data.Type = DataType.String;
            cell.Data.Text = "Tổng lợi nhuận";
            cell.MergeAcross = 7;
            cell = Row8.Cells.Add();
            cell.StyleID = "s69";
            cell.Data.Type = DataType.Number;
            cell.Formula = "=SUM(R[-" + (rowcount + 1).ToString().Trim() + "]C[-1]:R[-2]C[-1])";
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
    }
}
