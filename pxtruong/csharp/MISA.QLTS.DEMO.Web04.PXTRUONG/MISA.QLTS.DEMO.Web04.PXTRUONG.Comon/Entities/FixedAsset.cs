using LinqToExcel.Attributes;
using MISA.QLTS.DEMO.Web04.PXTRUONG.Comon.Attribute;
using MISA.QLTS.DEMO.Web04.PXTRUONG.Comon.Resources;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.QLTS.DEMO.Web04.PXTRUONG.Comon.Entities
{
    public class FixedAsset
    {
        /// <summary>
        /// Id tài sản
        /// </summary>
        //[MaxLength(36)]
        public Guid FixedAssetID { get; set; }
        /// <summary>
        /// Tên tài sản
        /// </summary>
        [MRequired]
        [ResourceDisplayName("FixedAssetName")]
        [MMaxLength(225)]
        public string FixedAssetName { get; set; }
        /// <summary>
        /// Mã tài sản
        /// </summary>
        [MRequired]
        [ResourceDisplayName("FixedAssetCode")]
        [MMaxLength(50)]
        public string FixedAssetCode { get; set;}
        /// <summary>
        /// Id Phòng ban
        /// </summary>
        [MRequired]
        public Guid  DepartmentID { get; set; }
        /// <summary>
        /// Tên Phòng ban
        /// </summary>
        [ResourceDisplayName("DepartmentName")]
        public string DepartmentName { get; set; }
        /// <summary>
        /// Mã Phòng ban
        /// </summary>
    
        public string DepartmentCode { get; set; }

        /// <summary>
        /// Id loại tài sản
        /// </summary>

        [MRequired]
        public Guid  FixedAssetCategoryID { get; set; }
        /// <summary>
        /// Tên loại tài sản
        /// </summary>
        [ResourceDisplayName("FixedAssetCategoryName")]
        public string FixedAssetCategoryName { get; set; }
        /// <summary>
        /// Mã loại tài sản
        /// </summary>
      
        public string FixedAssetCategoryCode { get; set; }
        /// <summary>
        /// Ngày mua
        /// </summary>
       
        public DateTime PurchaseDate { get; set; }
        /// <summary>
        /// Ngày bắt đầu sử dụng
        /// </summary>
        public DateTime DayUse { get; set; }

        /// <summary>
        /// Nguyên giá
        /// </summary>
        [ResourceDisplayName("Cost")]
        [MMaxLength(18)]
        public decimal Cost { get; set; }
        /// <summary>
        /// giá trị hao mòn năm 
        /// </summary>
      
        [MMaxLength(18)]
        public decimal AtrophyYear { get; set; }
        /// <summary>
        /// Số lượng
        /// </summary>
        [ResourceDisplayName("Quantity")]
        [MMaxLength(18)]
        public int Quantity { get; set; }
        /// <summary>
        /// Số năm sử dụng
        /// </summary>
       
        [MMaxLength(18)]
        public int ProductionYear { get; set; }

        /// <summary>
        /// Năm bắt đầu theo dõi tài sản trên phần mềm
        /// </summary>

        [MMaxLength(18)]
        public int TrackedYear { get; set; }
        /// <summary>
        /// Tỷ lệ hao mòn (%)
        /// </summary>
       
        public float DepreciationRate { get; set; }
        /// <summary>
        /// Tạo bởi ai
        /// </summary>
       
        [MaxLength(50)]
        public string CreatedBy { get; set; }
        /// <summary>
        /// Ngày tạo
        /// </summary>
        public DateTime CreatedDate { get; set; }
        /// <summary>
        /// Sửa bởi ai
        /// </summary>
        [MaxLength(50)]
        public string ModifiedBy { get; set; }
        /// <summary>
        /// Ngày sửa
        /// </summary>
        public DateTime ModifiedDate { get; set; }
        /// <summary>
        ///Hao mòn lũy kế
        /// </summary>
        [ResourceDisplayName("Atrophy")]
        public decimal Atrophy { get; set; }
        /// <summary>
        /// Giá trị còn lại 
        /// </summary>
        [ResourceDisplayName("Residual")]
        public decimal Residual { get; set; }



    }
}
