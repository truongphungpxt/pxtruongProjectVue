using OfficeOpenXml.Style;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MISA.QLTS.DEMO.Web04.PXTRUONG.Comon.Entities;
using LinqToExcel.Attributes;

namespace MISA.QLTS.DEMO.Web04.PXTRUONG.BL.MExcel
{
    public abstract class ExcelExporter<T>
    {
        private readonly IExcelService _excelService;
       
        protected ExcelExporter(IExcelService excelService)
        {
            _excelService = excelService;
            
            
        }
        /// <summary>
        /// Author:PXTRUONG(2/7/2023)
        /// Đặt tên cho sheet
        /// </summary>
        /// <returns></returns>

        protected abstract string GetWorksheetName();

        protected abstract IEnumerable<ExcelColumn<T>> GetColumns(ExcelWorksheet worksheet);
        /// <summary>
        /// Author:PXTRUONG(2/7/2023)
        /// Thực hiện thay đổi style theo các trường của thuộc tính 
        /// </summary>
        /// <param name="worksheet"></param>
        /// <param name="column"></param>
        protected virtual void SetColumnStyle(ExcelWorksheet worksheet, ExcelColumn<T> column)
        {
            if (column.Type == typeof(decimal) || column.Type == typeof(double) || column.Type == typeof(int) || column.Type == typeof(float))
            {
                _excelService.SetColumnStyle(worksheet, column.Index, ExcelHorizontalAlignment.Right);
            }
            else if (column.Type == typeof(DateTime))
            {
                _excelService.SetColumnStyle(worksheet, column.Index, ExcelHorizontalAlignment.Center);
            }
            else
            {
                _excelService.SetColumnStyle(worksheet, column.Index, ExcelHorizontalAlignment.Left);
            }
           

        }
        /// <summary>
        /// Author:PXTURONG(2/7/2023)
        /// Thực hiện set giá trị vào các ô 
        /// </summary>
        /// <param name="worksheet"></param>
        /// <param name="row"></param>
        /// <param name="column"></param>
        /// <param name="value"></param>
        protected virtual void SetCellValue(ExcelWorksheet worksheet, int row, int column, object value)
        {
            if (value == null)
            {
                return;
            }

            if (value is DateTime dateTimeValue)
            {
                _excelService.SetCellValue(worksheet, row, column, dateTimeValue.ToString("dd/MM/yyyy"));
            }
            else
            {
                _excelService.SetCellValue(worksheet, row, column, value);
            }
        }
       /// <summary>
       /// Author:PXTRUONG(2/7/2023)
       /// Thực hiện xuất file excell
       /// </summary>
       /// <param name="data"></param>
       /// <returns></returns>
        public byte[] Export(IEnumerable<T> data)
        {
            using (var package = _excelService.CreateExcelPackage())
            {
                var worksheet = _excelService.CreateWorksheet(package, GetWorksheetName());
              
                // Đặt tên cho các cột
                var columns = GetColumns(worksheet).ToList();
                for (int i = 0; i < columns.Count; i++)
                {
                    var column = columns[i];
                    SetCellValue(worksheet, 1, i + 1, column.Header);
                    SetColumnStyle(worksheet, column);
                }

                        // Điền dữ liệu vào các ô
                for (int i = 0; i < data.Count(); i++)
                {
                    var item = data.ElementAt(i);
                    for (int j = 0; j < columns.Count; j++)
                    {
                        var column = columns[j];
                        if (column.Hidden)
                        {
                            var value = column.Property.GetValue(item);
                            SetCellValue(worksheet, i + 2, j + 1, value);
                        }
                        else
                        {
                            worksheet.Column(j+1).Hidden= true;
                        }
                     
                    }
                }

                // Thiết lập auto-fit cho các cột
                _excelService.AutoFitColumns(worksheet);

                // Xuất file Excel
                var bytes = _excelService.GetAsByteArray(package);
                return bytes;
            }
        }
      
    }
}
