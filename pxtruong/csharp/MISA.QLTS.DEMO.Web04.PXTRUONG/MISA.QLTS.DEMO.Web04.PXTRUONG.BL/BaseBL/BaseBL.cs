using MISA.QLTS.DEMO.Web04.PXTRUONG.Comon.Entities;
using MISA.QLTS.DEMO.Web04.PXTRUONG.Comon.Entities.DTO;
using MISA.QLTS.DEMO.Web04.PXTRUONG.Comon.MISAException;
using MISA.QLTS.DEMO.Web04.PXTRUONG.Comon.Resources;
using MISA.QLTS.DEMO.Web04.PXTRUONG.DL.BaseDL;
using System.Collections;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data;


namespace MISA.QLTS.DEMO.Web04.PXTRUONG.BL.BaseBL
{
    public class BaseBL<T> : IBaseBL<T>
    {
        #region feld
        private IBaseDL<T> _baseDL;
        #endregion
        #region contructor
        public BaseBL(IBaseDL<T> baseDL)
        {
            _baseDL = baseDL;
        }

        #endregion


        /// <summary>
        /// Author:PXTRUONG(20/6/2023)
        /// Thêm tài sản
        /// </summary>
        /// <param name="record"></param>
        /// <returns></returns>
        /// <exception cref="DuplicateException"></exception>
        public virtual int Insert(T record)
        {
            ValidateInsert(record);
            return _baseDL.Insert(record);
        }
        /// <summary>
        /// Author:PXTRUONG(20/6/2023)
        /// Sửa tài sản
        /// </summary>
        /// <param name="record"></param>
        /// <returns></returns>
        /// <exception cref="DuplicateException"></exception>
        public virtual int Update(T record)
        {
            ValidateUpdate(record);
            return _baseDL.Update(record);
        }
        public virtual void ValidateUpdate(T record)
        {

        }
        public virtual void ValidateInsert(T record)
        {

        }
        /// <summary>
        /// Author:PXTURONG(20/6/2023)
        /// Thực hiện xóa tài sản 
        /// </summary>
        /// <param name="recordCode"></param>
        /// <returns></returns>
        public int DeleteRecordCode(string recordCode)
        {
            return _baseDL.DeleteRecordCode(recordCode);
        }

        public IEnumerable<T> GetAll(string RecordCode)
        {

            return  _baseDL.GetAll(RecordCode);
            
        }


        public IDbConnection GetOpenConection()
        {
            return _baseDL.GetOpenConection();
        }
        

    }
}
