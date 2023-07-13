using MISA.QLTS.DEMO.Web04.PXTRUONG.Comon.Entities;
using MISA.QLTS.DEMO.Web04.PXTRUONG.Comon.Entities.DTO;
using MISA.QLTS.DEMO.Web04.PXTRUONG.DL.BaseDL;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.QLTS.DEMO.Web04.PXTRUONG.DL.FixedAssetDL
{
    public interface IFixedAssetDL : IBaseDL<FixedAsset>
    {
        /// <summary>
        /// Author:PXTRUONG(2/7/2023)
        /// Lấy bản ghi theo id
        /// </summary>
        /// <returns> </returns>
        public FixedAsset GetByID(Guid FixedAssetID);
       /// <summary>
       /// Author:PXTRUONG(1/7/2023)
       /// Tìm mã tài sản lớn nhất và thêm 1 đơn vị 
       /// </summary>
       /// <returns></returns>
        public string FindMaxAssetCode();
      /// <summary>
      /// Author:PXTRUONG(1/7/2023)
      /// Phân trang 
      /// </summary>
      /// <param name="keyWord">Từ khóa để tìm kiếm </param>
      /// <param name="departmentName"> tìm kiếm thoe tên phòng ban </param>
      /// <param name="fixedCategoryName"> tìm kiếm theo tên loại tài sản </param>
      /// <param name="pageSize"> số trang </param>
      /// <param name="pageNumber"> vị trí trang </param>
      /// <returns></returns>
        public ServiceResult GetPaging(
         string keyWord,
         string departmentName,
         string fixedCategoryName,
         int pageSize,
         int pageNumber
       );
      /// <summary>
      /// Author:PXTRUONG(1/7/2023)
      /// Tính tổng các trường cần thiết 
      /// </summary>
      /// <returns></returns>
        public ListTotalDTO Sum();

    }
}
