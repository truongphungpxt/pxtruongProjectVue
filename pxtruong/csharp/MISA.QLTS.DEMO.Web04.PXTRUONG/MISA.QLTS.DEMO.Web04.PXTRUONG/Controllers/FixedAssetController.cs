using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MISA.QLTS.DEMO.Web04.PXTRUONG.BL.BaseBL;
using MISA.QLTS.DEMO.Web04.PXTRUONG.BL.FixedAssetBL;
using MISA.QLTS.DEMO.Web04.PXTRUONG.BL.MExcel;
using MISA.QLTS.DEMO.Web04.PXTRUONG.Comon.Entities;
using MISA.QLTS.DEMO.Web04.PXTRUONG.Comon.Entities.DTO;
using MISA.QLTS.DEMO.Web04.PXTRUONG.Comon.Resources;

namespace MISA.QLTS.DEMO.Web04.PXTRUONG.Controllers
{

    [ApiController]
    public class FixedAssetController : BasesController<FixedAsset>
    {
        private IFixedAssetBL _FixedAssetBL;


        public FixedAssetController(IFixedAssetBL fixedAsset) : base(fixedAsset)
        {
            _FixedAssetBL = fixedAsset;

        }

        [HttpGet("GetPaging")]
        public IActionResult GetPaging(string? keyWord, string? departmentName, string? fixedCategoryName, int pageSize, int pageNumber)
        {

            var record = _FixedAssetBL.GetPaging(keyWord, departmentName, fixedCategoryName, pageSize, pageNumber);
            return StatusCode(200, record);

        }
       

        [HttpGet("FindMaxFixedAssetCode")]
        public string FindMaxFixedAssetCode()
        {
            var result = _FixedAssetBL.FindMaxAssetCode();
            return result;
        }
        [HttpGet("ListSum")]
        public IActionResult ListSum()
        {
            var result = _FixedAssetBL.Sum();
            return StatusCode(200, new ServiceResult()
            {
                data = result

            });

        }

        [HttpGet("export")]
        public IActionResult Export()
        {
            
                var bytes = _FixedAssetBL.ExportExcel();
                return File(bytes, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet","Users.xlsx");
            
        }

    }
}
