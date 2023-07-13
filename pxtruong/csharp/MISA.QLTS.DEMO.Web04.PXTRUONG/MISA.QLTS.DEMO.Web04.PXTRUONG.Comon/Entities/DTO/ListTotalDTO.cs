using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.QLTS.DEMO.Web04.PXTRUONG.Comon.Entities.DTO
{
    public  class ListTotalDTO
    {
        /// <summary>
        /// tổng nguyên giá
        /// </summary>
        public decimal TotalCost { get; set; }
        /// <summary>
        /// tổng  giá trị còn lại
        /// </summary>
        public decimal Total { get; set; }
        /// <summary>
        /// tổng hao mòn lũy kế
        /// </summary>
        public decimal TotalAccumulate { get; set; }
        /// <summary>
        /// tổng số lượng 
        /// </summary>
        public int TotalQuantity { get; set; }

    }
}
