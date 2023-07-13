using MISA.QLTS.DEMO.Web04.PXTRUONG.Comon.Attribute;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.QLTS.DEMO.Web04.PXTRUONG.Comon.Entities.DTO
{
    public class FixedAssetDTO
    {
        
        /// <summary>
        /// Tên tài sản
        /// </summary>
        [MRequired]
        [DisplayName("Tên tài sản ")]
        [MMaxLength(225)]
        public string FixedAssetName { get; set; }
        /// <summary>
        /// Mã tài sản
        /// </summary>
        [MRequired]
        [DisplayName("Mã tài sản ")]
        [MMaxLength(50)]
        public string FixedAssetCode { get; set; }
        /// <summary>
        /// Tên loại tài sản
        /// </summary>
        [DisplayName("Tên loại tài sản ")]
        public string FixedAssetCategoryName { get; set; }

        /// <summary>
        /// Tên Phòng ban
        /// </summary>
        [DisplayName("Tên Phòng ban ")]
        public string DepartmentName { get; set; }

        /// <summary>
        /// Nguyên giá
        /// </summary>
        [DisplayName("Nguyên giá ")]
        [MMaxLength(18)]
        public decimal Cost { get; set; }
      
        /// <summary>
        /// Số lượng
        /// </summary>
        [DisplayName("Số lượng")]
        [MMaxLength(18)]
        public int Quantity { get; set; }
        /// <summary>
        ///Hao mòn lũy kế
        /// </summary>
        public decimal Atrophy { get; set; }
        /// <summary>
        /// Giá trị còn lại 
        /// </summary>
        public decimal Residual { get; set; }
        
    }
}
