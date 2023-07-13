using OfficeOpenXml.Style;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace MISA.QLTS.DEMO.Web04.PXTRUONG.BL.MExcel
{
    public class ExcelColumn<T>
    {
        /// <summary>
        /// tên tiêu đề
        /// </summary>
        public string Header { get; set; }
        /// <summary>
        /// thông tin prop
        /// </summary>
        public PropertyInfo Property { get; set; }
        /// <summary>
        /// vị trí cột
        /// </summary>
        public int Index { get; set; }
        /// <summary>
        /// kiểu dữ liệu
        /// </summary>
        public Type Type { get; set; }
        /// <summary>
        /// ẩn hay hiện cột
        /// </summary>
        public bool Hidden { get; set; }
       

        public ExcelColumn()
        {
            Type = typeof(T);
        }

        public ExcelColumn(string header, PropertyInfo property)
            : this()
        {
            Header = header;
            Property = property;
        }
    }
}
