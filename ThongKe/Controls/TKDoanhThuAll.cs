using System;
using System.Xml;
using CarlosAg.ExcelXmlWriter;
using System.Data;
using System.Globalization;
using System.Windows.Forms;

namespace ThongKe.Controls
{
    public class TKDoanhThuAll
    {

        public void Generate(string filename, DateTime dttungay, DateTime dtdengay, DataTable dt, ProgressBar progressBar)
        {
            Application.DoEvents();
            progressBar.PerformStep();
            Application.DoEvents();
            Workbook book = new Workbook();
            // -----------------------------------------------
            //  Properties
            // -----------------------------------------------
            book.Properties.Created = new System.DateTime(2006, 9, 16, 7, 0, 0, 0);
            book.Properties.LastSaved = new System.DateTime(2015, 10, 13, 23, 14, 58, 0);
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
            Application.DoEvents();
            progressBar.PerformStep();
            Application.DoEvents();
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
            this.GenerateWorksheet(book.Worksheets, dttungay, dtdengay, dt, progressBar);
            book.Save(filename);
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
            //  m92103616
            // -----------------------------------------------
            WorksheetStyle m92103616 = styles.Add("m92103616");
            m92103616.Font.Bold = true;
            m92103616.Font.FontName = "Times New Roman";
            m92103616.Font.Size = 11;
            m92103616.Font.Color = "#000000";
            m92103616.Interior.Color = "#8DB4E3";
            m92103616.Interior.Pattern = StyleInteriorPattern.Solid;
            m92103616.Alignment.Horizontal = StyleHorizontalAlignment.Right;
            m92103616.Alignment.Vertical = StyleVerticalAlignment.Center;
            m92103616.Alignment.WrapText = true;
            m92103616.Borders.Add(StylePosition.Bottom, LineStyleOption.Continuous, 1);
            m92103616.Borders.Add(StylePosition.Right, LineStyleOption.Continuous, 1);
            m92103616.Borders.Add(StylePosition.Top, LineStyleOption.Continuous, 1);
            // -----------------------------------------------
            //  m92103636
            // -----------------------------------------------
            WorksheetStyle m92103636 = styles.Add("m92103636");
            m92103636.Font.Bold = true;
            m92103636.Font.FontName = "Times New Roman";
            m92103636.Font.Size = 11;
            m92103636.Font.Color = "#000000";
            m92103636.Interior.Color = "#D8D8D8";
            m92103636.Interior.Pattern = StyleInteriorPattern.Solid;
            m92103636.Alignment.Horizontal = StyleHorizontalAlignment.Right;
            m92103636.Alignment.Vertical = StyleVerticalAlignment.Center;
            m92103636.Alignment.WrapText = true;
            m92103636.Borders.Add(StylePosition.Bottom, LineStyleOption.Continuous, 1);
            m92103636.Borders.Add(StylePosition.Right, LineStyleOption.Continuous, 1);
            m92103636.Borders.Add(StylePosition.Top, LineStyleOption.Continuous, 1);
            // -----------------------------------------------
            //  m92103656
            // -----------------------------------------------
            WorksheetStyle m92103656 = styles.Add("m92103656");
            m92103656.Font.Bold = true;
            m92103656.Font.FontName = "Times New Roman";
            m92103656.Font.Size = 11;
            m92103656.Font.Color = "#F2F2F2";
            m92103656.Interior.Color = "#E46D0A";
            m92103656.Interior.Pattern = StyleInteriorPattern.Solid;
            m92103656.Alignment.Horizontal = StyleHorizontalAlignment.Right;
            m92103656.Alignment.Vertical = StyleVerticalAlignment.Center;
            m92103656.Alignment.WrapText = true;
            m92103656.Borders.Add(StylePosition.Bottom, LineStyleOption.Continuous, 1);
            m92103656.Borders.Add(StylePosition.Left, LineStyleOption.Continuous, 1);
            m92103656.Borders.Add(StylePosition.Right, LineStyleOption.Continuous, 1);
            m92103656.Borders.Add(StylePosition.Top, LineStyleOption.Continuous, 1);
            // -----------------------------------------------
            //  m92103676
            // -----------------------------------------------
            WorksheetStyle m92103676 = styles.Add("m92103676");
            m92103676.Font.Bold = true;
            m92103676.Font.FontName = "Times New Roman";
            m92103676.Font.Size = 11;
            m92103676.Font.Color = "#FF0000";
            m92103676.Interior.Color = "#FFFF00";
            m92103676.Interior.Pattern = StyleInteriorPattern.Solid;
            m92103676.Alignment.Horizontal = StyleHorizontalAlignment.Right;
            m92103676.Alignment.Vertical = StyleVerticalAlignment.Center;
            m92103676.Alignment.WrapText = true;
            m92103676.Borders.Add(StylePosition.Bottom, LineStyleOption.Continuous, 1);
            m92103676.Borders.Add(StylePosition.Left, LineStyleOption.Continuous, 1);
            m92103676.Borders.Add(StylePosition.Right, LineStyleOption.Continuous, 1);
            m92103676.Borders.Add(StylePosition.Top, LineStyleOption.Continuous, 1);
            // -----------------------------------------------
            //  s16
            // -----------------------------------------------
            WorksheetStyle s16 = styles.Add("s16");
            s16.Alignment.Horizontal = StyleHorizontalAlignment.Center;
            s16.Alignment.Vertical = StyleVerticalAlignment.Bottom;
            // -----------------------------------------------
            //  s17
            // -----------------------------------------------
            WorksheetStyle s17 = styles.Add("s17");
            s17.Alignment.Vertical = StyleVerticalAlignment.Bottom;
            // -----------------------------------------------
            //  s18
            // -----------------------------------------------
            WorksheetStyle s18 = styles.Add("s18");
            s18.Font.Bold = true;
            s18.Font.FontName = "Calibri";
            s18.Font.Size = 18;
            s18.Font.Color = "#000000";
            // -----------------------------------------------
            //  s19
            // -----------------------------------------------
            WorksheetStyle s19 = styles.Add("s19");
            s19.Font.Bold = true;
            s19.Font.FontName = "Times New Roman";
            s19.Font.Size = 11;
            s19.Font.Color = "#000000";
            s19.Interior.Color = "#FAC090";
            s19.Interior.Pattern = StyleInteriorPattern.Solid;
            s19.Alignment.Horizontal = StyleHorizontalAlignment.Center;
            s19.Alignment.Vertical = StyleVerticalAlignment.Center;
            s19.Alignment.WrapText = true;
            s19.Borders.Add(StylePosition.Bottom, LineStyleOption.Continuous, 1);
            s19.Borders.Add(StylePosition.Left, LineStyleOption.Continuous, 1);
            s19.Borders.Add(StylePosition.Right, LineStyleOption.Continuous, 1);
            s19.Borders.Add(StylePosition.Top, LineStyleOption.Continuous, 1);
            // -----------------------------------------------
            //  s110
            // -----------------------------------------------
            WorksheetStyle s110 = styles.Add("s110");
            s110.Font.Bold = true;
            s110.Font.FontName = "Times New Roman";
            s110.Font.Size = 18;
            s110.Font.Color = "#000000";
            s110.Alignment.Horizontal = StyleHorizontalAlignment.Center;
            s110.Alignment.Vertical = StyleVerticalAlignment.Center;
            s110.Alignment.WrapText = true;
            // -----------------------------------------------
            //  s111
            // -----------------------------------------------
            WorksheetStyle s111 = styles.Add("s111");
            s111.Font.FontName = "Times New Roman";
            s111.Font.Size = 11;
            s111.Font.Color = "#000000";
            s111.Alignment.Horizontal = StyleHorizontalAlignment.Center;
            s111.Alignment.Vertical = StyleVerticalAlignment.Center;
            s111.Alignment.WrapText = true;
            // -----------------------------------------------
            //  s112
            // -----------------------------------------------
            WorksheetStyle s112 = styles.Add("s112");
            s112.Font.Italic = true;
            s112.Font.FontName = "Times New Roman";
            s112.Font.Color = "#000000";
            s112.Alignment.Horizontal = StyleHorizontalAlignment.Right;
            s112.Alignment.Vertical = StyleVerticalAlignment.Center;
            s112.Alignment.WrapText = true;
            s112.Borders.Add(StylePosition.Bottom, LineStyleOption.Continuous, 1);
            // -----------------------------------------------
            //  s113
            // -----------------------------------------------
            WorksheetStyle s113 = styles.Add("s113");
            s113.Font.FontName = "Times New Roman";
            s113.Font.Size = 11;
            s113.Font.Color = "#000000";
            s113.Interior.Color = "#FFFFFF";
            s113.Interior.Pattern = StyleInteriorPattern.Solid;
            s113.Alignment.Horizontal = StyleHorizontalAlignment.Center;
            s113.Alignment.Vertical = StyleVerticalAlignment.Center;
            s113.Alignment.WrapText = true;
            s113.Borders.Add(StylePosition.Bottom, LineStyleOption.Continuous, 1);
            s113.Borders.Add(StylePosition.Left, LineStyleOption.Continuous, 1);
            s113.Borders.Add(StylePosition.Right, LineStyleOption.Continuous, 1);
            s113.Borders.Add(StylePosition.Top, LineStyleOption.Continuous, 1);
            // -----------------------------------------------
            //  s114
            // -----------------------------------------------
            WorksheetStyle s114 = styles.Add("s114");
            s114.Font.FontName = "Times New Roman";
            s114.Font.Size = 11;
            s114.Font.Color = "#000000";
            s114.Interior.Color = "#FFFFFF";
            s114.Interior.Pattern = StyleInteriorPattern.Solid;
            s114.Alignment.Vertical = StyleVerticalAlignment.Center;
            s114.Alignment.WrapText = true;
            s114.Borders.Add(StylePosition.Bottom, LineStyleOption.Continuous, 1);
            s114.Borders.Add(StylePosition.Left, LineStyleOption.Continuous, 1);
            s114.Borders.Add(StylePosition.Right, LineStyleOption.Continuous, 1);
            s114.Borders.Add(StylePosition.Top, LineStyleOption.Continuous, 1);
            // -----------------------------------------------
            //  s115
            // -----------------------------------------------
            WorksheetStyle s115 = styles.Add("s115");
            s115.Font.FontName = "Times New Roman";
            s115.Font.Size = 11;
            s115.Font.Color = "#000000";
            s115.Interior.Color = "#FFFFFF";
            s115.Interior.Pattern = StyleInteriorPattern.Solid;
            s115.Alignment.Vertical = StyleVerticalAlignment.Center;
            s115.Alignment.WrapText = true;
            s115.Borders.Add(StylePosition.Bottom, LineStyleOption.Continuous, 1);
            s115.Borders.Add(StylePosition.Left, LineStyleOption.Continuous, 1);
            s115.Borders.Add(StylePosition.Right, LineStyleOption.Continuous, 1);
            s115.Borders.Add(StylePosition.Top, LineStyleOption.Continuous, 1);
            s115.NumberFormat = "Standard";
            // -----------------------------------------------
            //  s116
            // -----------------------------------------------
            WorksheetStyle s116 = styles.Add("s116");
            s116.Font.Bold = true;
            s116.Font.FontName = "Times New Roman";
            s116.Font.Size = 11;
            s116.Font.Color = "#000000";
            s116.Interior.Color = "#8DB4E3";
            s116.Interior.Pattern = StyleInteriorPattern.Solid;
            s116.Alignment.Vertical = StyleVerticalAlignment.Center;
            s116.Alignment.WrapText = true;
            s116.Borders.Add(StylePosition.Bottom, LineStyleOption.Continuous, 1);
            s116.Borders.Add(StylePosition.Left, LineStyleOption.Continuous, 1);
            s116.Borders.Add(StylePosition.Right, LineStyleOption.Continuous, 1);
            s116.Borders.Add(StylePosition.Top, LineStyleOption.Continuous, 1);
            s116.NumberFormat = "Standard";
            // -----------------------------------------------
            //  s117
            // -----------------------------------------------
            WorksheetStyle s117 = styles.Add("s117");
            s117.Font.Bold = true;
            s117.Font.FontName = "Times New Roman";
            s117.Font.Size = 11;
            s117.Font.Color = "#FF0000";
            s117.Interior.Color = "#FFFF00";
            s117.Interior.Pattern = StyleInteriorPattern.Solid;
            s117.Alignment.Vertical = StyleVerticalAlignment.Center;
            s117.Alignment.WrapText = true;
            s117.Borders.Add(StylePosition.Bottom, LineStyleOption.Continuous, 1);
            s117.Borders.Add(StylePosition.Left, LineStyleOption.Continuous, 1);
            s117.Borders.Add(StylePosition.Right, LineStyleOption.Continuous, 1);
            s117.Borders.Add(StylePosition.Top, LineStyleOption.Continuous, 1);
            s117.NumberFormat = "Standard";
            // -----------------------------------------------
            //  s118
            // -----------------------------------------------
            WorksheetStyle s118 = styles.Add("s118");
            s118.Font.Bold = true;
            s118.Font.FontName = "Times New Roman";
            s118.Font.Size = 11;
            s118.Font.Color = "#000000";
            s118.Interior.Color = "#D8D8D8";
            s118.Interior.Pattern = StyleInteriorPattern.Solid;
            s118.Alignment.Vertical = StyleVerticalAlignment.Center;
            s118.Alignment.WrapText = true;
            s118.Borders.Add(StylePosition.Bottom, LineStyleOption.Continuous, 1);
            s118.Borders.Add(StylePosition.Left, LineStyleOption.Continuous, 1);
            s118.Borders.Add(StylePosition.Right, LineStyleOption.Continuous, 1);
            s118.Borders.Add(StylePosition.Top, LineStyleOption.Continuous, 1);
            s118.NumberFormat = "Standard";
            // -----------------------------------------------
            //  s119
            // -----------------------------------------------
            WorksheetStyle s119 = styles.Add("s119");
            s119.Font.Bold = true;
            s119.Font.FontName = "Times New Roman";
            s119.Font.Size = 11;
            s119.Font.Color = "#F2F2F2";
            s119.Interior.Color = "#E46D0A";
            s119.Interior.Pattern = StyleInteriorPattern.Solid;
            s119.Alignment.Vertical = StyleVerticalAlignment.Center;
            s119.Alignment.WrapText = true;
            s119.Borders.Add(StylePosition.Bottom, LineStyleOption.Continuous, 1);
            s119.Borders.Add(StylePosition.Left, LineStyleOption.Continuous, 1);
            s119.Borders.Add(StylePosition.Right, LineStyleOption.Continuous, 1);
            s119.Borders.Add(StylePosition.Top, LineStyleOption.Continuous, 1);
            s119.NumberFormat = "Standard";
        }

        private void GenerateWorksheet(WorksheetCollection sheets, DateTime dttungay, DateTime dtdenngay, DataTable dt, ProgressBar progressBar)
        {
            Worksheet sheet = sheets.Add("TKDoanhThu");
            sheet.Table.DefaultRowHeight = 15F;
            sheet.Table.ExpandedColumnCount = 10;
            sheet.Table.ExpandedRowCount = 8 + dt.Rows.Count;
            sheet.Table.FullColumns = 1;
            sheet.Table.FullRows = 1;
            WorksheetColumn column0 = sheet.Table.Columns.Add();
            column0.Width = 24;
            column0.StyleID = "s16";
            WorksheetColumn column1 = sheet.Table.Columns.Add();
            column1.Width = 96;
            column1.StyleID = "s16";
            sheet.Table.Columns.Add(84);
            sheet.Table.Columns.Add(81);
            sheet.Table.Columns.Add(65);
            sheet.Table.Columns.Add(96);
            WorksheetColumn column6 = sheet.Table.Columns.Add();
            column6.Width = 97;
            column6.Span = 1;
            WorksheetColumn column7 = sheet.Table.Columns.Add();
            column7.Index = 9;
            column7.Width = 75;
            sheet.Table.Columns.Add(144);
            Application.DoEvents();
            progressBar.PerformStep();
            Application.DoEvents();
            // -----------------------------------------------
            #region Add header
            WorksheetRow Row0 = sheet.Table.Rows.Add();
            Row0.Height = 23;
            WorksheetCell cell;
            cell = Row0.Cells.Add();
            cell.StyleID = "s110";
            cell.Data.Type = DataType.String;
            cell.Data.Text = "TỔNG HỢP DOANH THU";
            cell.MergeAcross = 8;
            Application.DoEvents();
            progressBar.PerformStep();
            Application.DoEvents();
            // -----------------------------------------------
            WorksheetRow Row1 = sheet.Table.Rows.Add();
            cell = Row1.Cells.Add();
            cell.StyleID = "s111";
            cell.Data.Type = DataType.String;
            cell.Data.Text = "(Từ ngày " + dttungay.ToString("dd/MM/yyyy") + " đến ngày " + dtdenngay.ToString("dd/MM/yyyy") + ")";
            cell.MergeAcross = 8;
            Application.DoEvents();
            progressBar.PerformStep();
            Application.DoEvents();
            // -----------------------------------------------
            WorksheetRow Row2 = sheet.Table.Rows.Add();
            Row2.AutoFitHeight = false;
            cell = Row2.Cells.Add();
            cell.StyleID = "s112";
            cell.Data.Type = DataType.String;
            cell.Data.Text = "Đơn vị tính: VNĐ";
            cell.MergeAcross = 8;
            Application.DoEvents();
            progressBar.PerformStep();
            Application.DoEvents();
            // -----------------------------------------------
            WorksheetRow Row3 = sheet.Table.Rows.Add();
            Row3.Cells.Add("Stt", DataType.String, "s19");
            Row3.Cells.Add("Ngày xuất hóa đơn", DataType.String, "s19");
            Row3.Cells.Add("Tên khách hàng", DataType.String, "s19");
            Row3.Cells.Add("Tổng tiền nhập hàng/Hóa đơn", DataType.String, "s19");
            Row3.Cells.Add("Tổng tiền/Hóa đơn", DataType.String, "s19");
            Row3.Cells.Add("Lợi nhuận/Hóa đơn", DataType.String, "s19");
            Row3.Cells.Add("Tiền đã thanh toán", DataType.String, "s19");
            Row3.Cells.Add("Chiết khấu/Hóa đơn", DataType.String, "s19");
            Row3.Cells.Add("Còn nợ/Hóa đơn", DataType.String, "s19");
            Application.DoEvents();
            progressBar.PerformStep();
            Application.DoEvents();
            #endregion
            // -----------------------------------------------
            #region Add Content
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                Application.DoEvents();
                progressBar.PerformStep();
                Application.DoEvents();
                WorksheetRow row = sheet.Table.Rows.Add();
                row.Cells.Add((i + 1).ToString(), DataType.Number, "s113");
                DateTime dttemp = Convert.ToDateTime(dt.Rows[i]["ngaytao"].ToString().Trim());
                row.Cells.Add(dttemp.ToString("dd/MM/yyyy HH:mm:ss").Trim(), DataType.String, "s114");
                row.Cells.Add(dt.Rows[i]["tenkh"].ToString().Trim(), DataType.String, "s114");
                row.Cells.Add(dt.Rows[i]["gianhap"].ToString().Trim(), DataType.Number, "s115");
                row.Cells.Add(dt.Rows[i]["tongtien"].ToString().Trim(), DataType.Number, "s115");
                cell = row.Cells.Add();
                cell.StyleID = "s115";
                cell.Data.Type = DataType.Number;
                cell.Formula = "=RC[-1]-RC[-2]-RC[2]";
                row.Cells.Add(dt.Rows[i]["tiendathanhtoan"].ToString().Trim(), DataType.Number, "s115");
                row.Cells.Add(dt.Rows[i]["chietkhau"].ToString().Trim(), DataType.Number, "s115");
                cell = row.Cells.Add();
                cell.StyleID = "s115";
                cell.Data.Type = DataType.Number;
                cell.Formula = "=RC[-4]-RC[-2]-RC[-1]";
            }
            #endregion
            // -----------------------------------------------
            #region Add Tính toán (Sum)
            Application.DoEvents();
            progressBar.PerformStep();
            Application.DoEvents();
            WorksheetRow Row8 = sheet.Table.Rows.Add();
            Row8.AutoFitHeight = false;
            cell = Row8.Cells.Add();
            cell.StyleID = "m92103616";
            cell.Data.Type = DataType.String;
            cell.Data.Text = "Tổng doanh thu";
            cell.MergeAcross = 7;
            cell = Row8.Cells.Add();
            cell.StyleID = "s116";
            cell.Data.Type = DataType.Number;
            cell.Formula = "=SUM(R[-" + (dt.Rows.Count).ToString() + "]C[-4]:R[-1]C[-4])";
            // -----------------------------------------------
            Application.DoEvents();
            progressBar.PerformStep();
            Application.DoEvents();
            WorksheetRow Row9 = sheet.Table.Rows.Add();
            Row9.AutoFitHeight = false;
            cell = Row9.Cells.Add();
            cell.StyleID = "m92103676";
            cell.Data.Type = DataType.String;
            cell.Data.Text = "Tổng lợi nhuận";
            cell.MergeAcross = 7;
            cell = Row9.Cells.Add();
            cell.StyleID = "s117";
            cell.Data.Type = DataType.Number;
            cell.Formula = "=SUM(R[-" + (dt.Rows.Count + 1).ToString() + "]C[-3]:R[-2]C[-3])";
            // -----------------------------------------------
            Application.DoEvents();
            progressBar.PerformStep();
            Application.DoEvents();
            WorksheetRow Row10 = sheet.Table.Rows.Add();
            Row10.AutoFitHeight = false;
            cell = Row10.Cells.Add();
            cell.StyleID = "m92103636";
            cell.Data.Type = DataType.String;
            cell.Data.Text = "Tổng tiền đã thanh toán";
            cell.MergeAcross = 7;
            cell = Row10.Cells.Add();
            cell.StyleID = "s118";
            cell.Data.Type = DataType.Number;
            cell.Formula = "=SUM(R[-" + (dt.Rows.Count + 2).ToString() + "]C[-2]:R[-3]C[-2]) + SUM(R[-" + (dt.Rows.Count + 2).ToString() + "]C[-1]:R[-3]C[-1])";
            // -----------------------------------------------
            Application.DoEvents();
            progressBar.PerformStep();
            Application.DoEvents();
            WorksheetRow Row11 = sheet.Table.Rows.Add();
            Row11.AutoFitHeight = false;
            cell = Row11.Cells.Add();
            cell.StyleID = "m92103656";
            cell.Data.Type = DataType.String;
            cell.Data.Text = "Tổng tiền còn nợ";
            cell.MergeAcross = 7;
            cell = Row11.Cells.Add();
            cell.StyleID = "s119";
            cell.Data.Type = DataType.Number;
            cell.Formula = "=SUM(R[-" + (dt.Rows.Count + 3).ToString() + "]C:R[-4]C)";
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
            Application.DoEvents();
            progressBar.PerformStep();
            Application.DoEvents();
        }
    }
}
