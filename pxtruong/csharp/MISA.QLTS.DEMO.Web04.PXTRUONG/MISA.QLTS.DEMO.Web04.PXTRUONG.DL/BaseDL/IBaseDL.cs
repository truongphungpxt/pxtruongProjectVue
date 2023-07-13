using MISA.QLTS.DEMO.Web04.PXTRUONG.Comon.Entities;
using MISA.QLTS.DEMO.Web04.PXTRUONG.Comon.Entities.DTO;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.QLTS.DEMO.Web04.PXTRUONG.DL.BaseDL
{
    public interface IBaseDL<T>
    {
        
        /// <summary>
        /// 
        /// </summary>
        /// <returns>lấy tất cả bản ghi </returns>
        public  IEnumerable<T> GetAll(string RecordCode);
        
        /// <summary>
        /// kết nối serve
        /// </summary>
        /// <returns></returns>
        public IDbConnection GetOpenConection();

        /// <summary>
        /// thực hiện câu lệnh tìm kiếm 
        /// </summary>
        /// <summary>
        /// chỉnh sửa bản ghi 
        /// </summary>
        /// <param name="record"></param>
        /// <returns></returns>
        public int Update(T record);
        /// <summary>
        /// xóa theo mã bản ghi
        /// </summary>
        /// <returns></returns>
        public int DeleteRecordCode(string RecordCode);
        /// <summary>
        /// thêm mới bản ghi
        /// </summary>
        /// <param name="record"></param>
        /// <returns></returns>
        public int Insert(T record);

    }
}
