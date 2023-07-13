using OfficeOpenXml;
using OfficeOpenXml.Style;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.QLTS.DEMO.Web04.PXTRUONG.BL.MExcel
{
    public class ExcelService : IExcelService
    {
        /// <summary>
        /// Author:PXTRUONG(7/1/2023)
        /// Tạo một đối tượng ExcelPackage mới
        /// </summary>
        /// <returns></returns>
        public ExcelPackage CreateExcelPackage()
        {
            return new ExcelPackage();
        }
        /// <summary>
        /// Author:PXTRUONG(7/1/2023)
        /// Tạo một worksheet mới với tên được chỉ định và thêm vào ExcelPackage
        /// </summary>
        /// <returns></returns>
        public ExcelWorksheet CreateWorksheet(ExcelPackage package, string name)
        {
            return package.Workbook.Worksheets.Add(name);
        }
        /// <summary>
        /// Author:PXTRUONG(7/1/2023)
        ///  Đặt giá trị cho một ô trong worksheet
        /// </summary>
        /// <returns></returns>
        public void SetCellValue(ExcelWorksheet worksheet, int row, int column, object value)
        {
            worksheet.Cells[row, column].Value = value;
        }
        /// <summary>
        /// Author:PXTRUONG(7/1/2023)
        /// Thiết lập style cho một cột của worksheet.
        /// </summary>
        /// <returns></returns>
        public void SetColumnStyle(ExcelWorksheet worksheet, int column, ExcelHorizontalAlignment alignment)
        {
            //styleColumn
            var columnStyle = worksheet.Column(column).Style;
            columnStyle.HorizontalAlignment = alignment;
            columnStyle.Font.Name = "Times New Roman";
            columnStyle.Font.Size = 12;
            columnStyle.Border.Top.Style = ExcelBorderStyle.Thin;
            columnStyle.Border.Left.Style = ExcelBorderStyle.Thin;
            columnStyle.Border.Right.Style = ExcelBorderStyle.Thin;
            columnStyle.Border.Bottom.Style = ExcelBorderStyle.Thin;
            //styleColumn
            var columnRow = worksheet.Row(column).Style;
            columnRow.Border.Top.Style = ExcelBorderStyle.Thin;
            columnRow.Border.Left.Style = ExcelBorderStyle.Thin;
            columnRow.Border.Right.Style = ExcelBorderStyle.Thin;
            columnRow.Border.Bottom.Style = ExcelBorderStyle.Thin;
            //style header
            var headerStyle= worksheet.Row(1).Style;
            headerStyle.Font.Bold= true;
            headerStyle.Font.Size= 14;
            headerStyle.Font.Color.SetColor(Color.Black);
            headerStyle.Fill.PatternType=ExcelFillStyle.Solid;
            headerStyle.Fill.BackgroundColor.SetColor(Color.LightGray);
        }
        /// <summary>
        /// Author:PXTRUONG(7/1/2023)
        /// Thiết lập auto-fit cho các cột của worksheet.
        /// </summary>
        /// <returns></returns>
        public void AutoFitColumns(ExcelWorksheet worksheet)
        {
            worksheet.Cells.AutoFitColumns();
        }
        /// <summary>
        /// Author:PXTRUONG(7/1/2023)
        /// Trả về một mảng byte chứa nội dung của ExcelPackage.
        /// </summary>
        /// <returns></returns>
        public byte[] GetAsByteArray(ExcelPackage package)
        {
            return package.GetAsByteArray();
        }
    }
}
