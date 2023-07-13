using AutoMapper;
using MISA.QLTS.DEMO.Web04.PXTRUONG.BL.BaseBL;
using MISA.QLTS.DEMO.Web04.PXTRUONG.BL.MExcel;
using MISA.QLTS.DEMO.Web04.PXTRUONG.BL.MExcel.DTO;
using MISA.QLTS.DEMO.Web04.PXTRUONG.Comon.Entities;
using MISA.QLTS.DEMO.Web04.PXTRUONG.Comon.Entities.DTO;
using MISA.QLTS.DEMO.Web04.PXTRUONG.Comon.Enums;
using MISA.QLTS.DEMO.Web04.PXTRUONG.Comon.MISAException;
using MISA.QLTS.DEMO.Web04.PXTRUONG.Comon.Resources;
using MISA.QLTS.DEMO.Web04.PXTRUONG.DL.BaseDL;
using MISA.QLTS.DEMO.Web04.PXTRUONG.DL.FixedAssetDL;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MISA.QLTS.DEMO.Web04.PXTRUONG.BL.FixedAssetBL
{
    public class FixedAssetBL : BaseBL<FixedAsset>, IFixedAssetBL
    {
        private readonly IFixedAssetDL _fixedAssetDL;
        private IExcelService _ExcelService;
        private readonly IMapper _mapper;
        public FixedAssetBL(IFixedAssetDL fixedAssetDL, IExcelService ExcelService, IMapper mapper) : base(fixedAssetDL)
        {
            _fixedAssetDL = fixedAssetDL;
            _ExcelService = ExcelService;
            _mapper = mapper;
        }
        /// <summary>
        /// Author:PXTRUONG(3/7/2023)
        /// Xuất excel
        /// </summary>
        /// <returns></returns>
        public byte[] ExportExcel()
        {
            var listFixedAsset = _fixedAssetDL.GetAll(null);
            var exporter = new FixedAssetExporter(_ExcelService);
            var bytes = exporter.Export(listFixedAsset);
            return bytes;
        }
        /// <summary>
        /// Author:PXTRUONG(23/6/2023)
        /// Tìm mã tài sản lớn nhất 
        /// </summary>
        /// <returns></returns>
        public string FindMaxAssetCode()
        {
            string newCode;
            var result = _fixedAssetDL.FindMaxAssetCode();
            if (string.IsNullOrEmpty(result))
            {
                newCode = Resource1.FirstCode;
            }
            else
            {
                // Trích xuất phần số của mã lớn nhất sử dụng biểu thức chính quy
                string numericPart = Regex.Match(result, @"\d+").Value;
                // Tăng phần số lên 1
                int numericValue = int.Parse(numericPart);
                if (char.IsDigit(result.Last()))
                {
                    numericValue++;
                }
                else
                {
                    numericValue = 1;
                }
                // Kết hợp phần số với tiền tố không phải số (nếu có) để tạo ra mã mới
                string prefix = result.Substring(0, result.IndexOf(numericPart));
                string newNumericPart = numericValue.ToString().PadLeft(numericPart.Length, '0');
                 newCode = prefix + newNumericPart;
            }
            return newCode;
        }
        /// <summary>
        /// Author:PXTRUONG(21/6/2023)
        /// Phân trang
        /// </summary>
        /// <param name="keyWord"></param>
        /// <param name="departmentName"></param>
        /// <param name="fixedCategoryName"></param>
        /// <param name="pageSize"></param>
        /// <param name="pageNumber"></param>
        /// <returns></returns>
        public ServiceResult GetPaging(string keyWord, string departmentName, string fixedCategoryName, int pageSize, int pageNumber)
        {
            return _fixedAssetDL.GetPaging(keyWord, departmentName, fixedCategoryName, pageSize, pageNumber);
        }
     
        /// <summary>
        /// Author:PXTRUONG(23/6/2023)
        /// Tính tổng các trường theo yêu cầu
        /// </summary>
        /// <returns></returns>
        public ListTotalDTO Sum()
        {
            return _fixedAssetDL.Sum();
        }
        /// <summary>
        /// Author:PXTRUONG(23/6/2023)
        /// Tìm tài sản theo id
        /// </summary>
        /// <param name="FixedAssetID"></param>
        /// <returns></returns>
        public FixedAsset GetByID(Guid FixedAssetID)
        {
            return _fixedAssetDL.GetByID(FixedAssetID);

        }
       
        #region validate
        /// <summary>
        /// Author:PXTRUONG(24/6/2023)
        /// Kiểm tra mã chùng
        /// </summary>
        /// <param name="record"></param>
        /// <returns></returns>
        public Boolean DupliCate(string record)
        {

            var checkDuplicate = GetAll(record);
            if (checkDuplicate.ToList().Count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }

        }
        /// <summary>
        /// Author:PXTRUONG(24/6/2023)
        /// Kiểm tra xem ngày mua ngày sử dụng đúng quy định không
        /// </summary>
        /// <param name="fixedAsset"></param>
        /// <returns></returns>
        public void InValidDate(FixedAsset fixedAsset)
        {
            var dataUnValidate = new List<string>();
            if (fixedAsset.PurchaseDate > DateTime.Now)
            {
                dataUnValidate.Add(Resource1.checkPurchaseDate);
               
            }
            if (fixedAsset.DayUse > DateTime.Now)
            {
                dataUnValidate.Add(Resource1.checkDayUse);
                
            }
            if (fixedAsset.PurchaseDate > fixedAsset.DayUse)
            {
                dataUnValidate.Add(Resource1.checkPurchaseDayUse);
                
            }
            var dataMesage = "";
            //validate ngày tháng 
          
            if (dataUnValidate.Count > 0)
            {
                dataMesage = string.Join(",", dataUnValidate);
                throw new ValidateException(404, dataMesage);
            }

        }
      
        /// <summary>
        /// Author:PXTURONG(25/6/2023)
        /// Kiểm tra mã khi được  sửa 
        /// </summary>
        /// <param name="fixedAsset"></param>
        /// <returns></returns>
        public Boolean CompareFixedCode(FixedAsset fixedAsset)
        {
            var fixedAssetFindByID = GetByID(fixedAsset.FixedAssetID);
            if (fixedAsset.FixedAssetCode == fixedAssetFindByID.FixedAssetCode)
            {
                return false;
            }
            else
            {
                if (DupliCate(fixedAsset.FixedAssetCode))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }




        }
        public override void ValidateInsert(FixedAsset record)
        {
            if (DupliCate(record.FixedAssetCode))
            {
                throw new DuplicateException(404, Resource1.Dupplicate);
            }
            InValidDate(record);
        }
        public override void ValidateUpdate(FixedAsset record)
        {
            if (CompareFixedCode(record))
            {
                throw new DuplicateException(404, Resource1.Dupplicate);
            }
            InValidDate(record);
        }
        #endregion
    }
}
