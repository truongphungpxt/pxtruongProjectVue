using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MISA.QLTS.DEMO.Web04.PXTRUONG.BL.BaseBL;
using MISA.QLTS.DEMO.Web04.PXTRUONG.Comon.Entities;

namespace MISA.QLTS.DEMO.Web04.PXTRUONG.Controllers
{

    [ApiController]
    public class FixedAssetCategorysController : BasesController<FixedAssetCategory>
    {
        public FixedAssetCategorysController(IBaseBL<FixedAssetCategory> baseBL) : base(baseBL)
        {
        }
    }
}
