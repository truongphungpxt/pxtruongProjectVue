using MISA.QLTS.DEMO.Web04.PXTRUONG.BL.BaseBL;
using MISA.QLTS.DEMO.Web04.PXTRUONG.Comon.Entities;
using MISA.QLTS.DEMO.Web04.PXTRUONG.DL.BaseDL;
using MISA.QLTS.DEMO.Web04.PXTRUONG.DL.FixedAssetDL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.QLTS.DEMO.Web04.PXTRUONG.BL.FixedAssetBL
{
    public interface IFixedAssetBL:IBaseBL<FixedAsset>, IFixedAssetDL
    {
        public byte[] ExportExcel();
    }
}
