using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MISA.QLTS.DEMO.Web04.PXTRUONG.BL.BaseBL;
using MISA.QLTS.DEMO.Web04.PXTRUONG.Comon.Entities;
using MISA.QLTS.DEMO.Web04.PXTRUONG.Comon.Entities.DTO;
using MISA.QLTS.DEMO.Web04.PXTRUONG.Comon.Resources;

namespace MISA.QLTS.DEMO.Web04.PXTRUONG.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class BasesController<T> : ControllerBase
    {
        #region feld
        private IBaseBL<T> _baseBL;
        #endregion
        #region contructor
        public BasesController(IBaseBL<T> baseBL)
        {
            _baseBL = baseBL;
        }
        #endregion
        #region Method
        [HttpGet]
        public IActionResult GetAll(string recodeCode)
        {
                var record = _baseBL.GetAll(recodeCode);
                  return StatusCode(200, record);
        }
        [HttpPost]
        public IActionResult InsertRecord([FromBody] T record)
        {

            var Result = _baseBL.Insert(record);

            return StatusCode(201, new ServiceResult()
            {
                IsSuccess = true,
                Message = Resource1.addSuccess,
            });
        }

        [HttpDelete]
        public IActionResult DeleteRecordCode([FromQuery] string recordCode)
        {

            var record = _baseBL.DeleteRecordCode(recordCode);
            var result = new ServiceResult()
            {
                IsSuccess = true,
                data = record,
                Message = Resource1.delateSuccess,
            };

            return StatusCode(200, result);

        }
        [HttpPut]
        public IActionResult UpdateRecord([FromBody] T record)
        {

            var Result = _baseBL.Update(record);

            return StatusCode(200, new ServiceResult()
            {
                IsSuccess = true,
                Message = Resource1.FixSuccess,
            });


        }





        #endregion

    }
}
