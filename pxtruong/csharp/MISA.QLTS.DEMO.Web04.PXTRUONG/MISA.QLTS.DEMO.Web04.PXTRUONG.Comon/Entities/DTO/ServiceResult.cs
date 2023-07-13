using MISA.QLTS.DEMO.Web04.PXTRUONG.Comon.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.QLTS.DEMO.Web04.PXTRUONG.Comon.Entities.DTO
{
    public class ServiceResult
    {

        public ErrorCode errorCode { get; set; }
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
        
        public object data { get; set; }
    }
}
