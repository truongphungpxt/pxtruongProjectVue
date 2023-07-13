
using DocumentFormat.OpenXml.Spreadsheet;
using LinqToExcel.Attributes;
using MISA.QLTS.DEMO.Web04.PXTRUONG.Comon.Entities;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.QLTS.DEMO.Web04.PXTRUONG.BL.MExcel.DTO
{
    public class FixedAssetExporter : ExcelExporter<FixedAsset>
    {

    public FixedAssetExporter(IExcelService excelService) : base(excelService)
        {
        }
        /// <summary>
        /// Author:PXTRUONG(2/7/2023)
        /// Chuyền lấy tên cột của class FixedAsset
        /// </summary>
        /// <param name="worksheet"></param>
        /// <returns></returns>
        protected override IEnumerable<ExcelColumn<FixedAsset>> GetColumns(ExcelWorksheet worksheet)
        {
            var columns = new List<ExcelColumn<FixedAsset>>();

            var properties = typeof(FixedAsset).GetProperties();

           
            for (int i = 0; i < properties.Length; i++)
            {

                var property = properties[i];
                var displayNameAttr = property.GetCustomAttributes(typeof(DisplayNameAttribute), false).FirstOrDefault() as DisplayNameAttribute;
                if (displayNameAttr != null)
                {
                    var column = new ExcelColumn<FixedAsset>()
                    {
                        Header = displayNameAttr.DisplayName,
                        Property = property,
                        Index = i+1,
                        Type = property.PropertyType,
                        Hidden=true
                    };
                    columns.Add(column);
                }
                else
                {
                    var column = new ExcelColumn<FixedAsset>()
                    {
                        Index = i+1,
                        Hidden = false
                    };
                    columns.Add(column);
                }

            }

            return columns;
        }

        protected override string GetWorksheetName()
        {
            return "FixedAsset";
        }
    }
}
