using OfficeOpenXml.Style;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.QLTS.DEMO.Web04.PXTRUONG.BL.MExcel
{
    public interface IExcelService 
    {
        /// <summary>
        /// Author:PXTRUONG(7/1/2023)
        /// Tạo một đối tượng ExcelPackage mới
        /// </summary>
        /// <returns></returns>
        ExcelPackage CreateExcelPackage();
        /// <summary>
        /// Author:PXTRUONG(7/1/2023)
        /// Tạo một worksheet mới với tên được chỉ định và thêm vào ExcelPackage
        /// </summary>
        /// <returns></returns>
        ExcelWorksheet CreateWorksheet(ExcelPackage package, string name);
        /// <summary>
        /// Author:PXTRUONG(7/1/2023)
        ///  Đặt giá trị cho một ô trong worksheet
        /// </summary>
        /// <returns></returns>
        void SetCellValue(ExcelWorksheet worksheet, int row, int column, object value);
        /// <summary>
        /// Author:PXTRUONG(7/1/2023)
        /// Thiết lập style cho một cột của worksheet.
        /// </summary>
        /// <returns></returns>
        void SetColumnStyle(ExcelWorksheet worksheet, int column, ExcelHorizontalAlignment alignment);
        /// <summary>
        /// Author:PXTRUONG(7/1/2023)
        /// Thiết lập auto-fit cho các cột của worksheet.
        /// </summary>
        /// <returns></returns>
        void AutoFitColumns(ExcelWorksheet worksheet);
        /// <summary>
        /// Author:PXTRUONG(7/1/2023)
        /// Trả về một mảng byte chứa nội dung của ExcelPackage.
        /// </summary>
        /// <returns></returns>
        byte[] GetAsByteArray(ExcelPackage package);
    }
}
