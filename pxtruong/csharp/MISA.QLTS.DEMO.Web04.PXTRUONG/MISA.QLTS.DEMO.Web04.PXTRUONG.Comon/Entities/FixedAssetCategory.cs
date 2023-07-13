using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.QLTS.DEMO.Web04.PXTRUONG.Comon.Entities
{
    public class FixedAssetCategory
    {
        /// <summary>
        /// ID loại tài sản 
        /// </summary>
        public Guid FixedAssetCategoryID { get; set; }
        /// <summary>
        /// Mã loại tài sản
        /// </summary>
        public string FixedAssetCategoryCode { get; set; }
        /// <summary>
        /// Tên loại tài sản
        /// </summary>
        public string FixedAssetCategoryName { get; set; }
        /// <summary>
        /// Tỷ lệ hao mòn (%)
        /// </summary>
        public float DepreciationRate { get; set; }
        /// <summary>
        /// Số năm sử dụng
        /// </summary>
        public int LifeTime { get; set; }
        /// <summary>
        /// Năm sử dụng
        /// </summary>
        public int ProductionYear { get; set; }
        /// <summary>
        /// Tạo bởi ai
        /// </summary>
        public string CreatedBy { get; set; }
        /// <summary>
        /// Ngày tạo
        /// </summary>
        public DateTime CreatedDate { get; set; }
        /// <summary>
        /// Sửa bởi ai
        /// </summary>
        public string ModifiedBy { get; set; }
        /// <summary>
        /// Ngày sửa
        /// </summary>
        public DateTime ModifiedDate { get; set; }


    }
}
