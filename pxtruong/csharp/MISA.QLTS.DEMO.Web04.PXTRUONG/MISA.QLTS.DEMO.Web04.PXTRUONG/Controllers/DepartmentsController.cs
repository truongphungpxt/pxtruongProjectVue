using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MISA.QLTS.DEMO.Web04.PXTRUONG.BL.BaseBL;
using MISA.QLTS.DEMO.Web04.PXTRUONG.Comon.Entities;

namespace MISA.QLTS.DEMO.Web04.PXTRUONG.Controllers
{

    [ApiController]
    public class DepartmentsController : BasesController<Department>
    {
        public DepartmentsController(IBaseBL<Department> baseBL) : base(baseBL)
        {
        }
    }
}
