using Dapper;

using MySqlConnector;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using MISA.QLTS.DEMO.Web04.PXTRUONG.Comon.Entities.DTO;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MISA.QLTS.DEMO.Web04.PXTRUONG.Comon.Resources;
using MISA.QLTS.DEMO.Web04.PXTRUONG.Comon.Entities;

namespace MISA.QLTS.DEMO.Web04.PXTRUONG.DL.BaseDL
{
    public  class BaseDL<T> : IBaseDL<T>
    {
        #region Method
       

        /// <summary>
        /// Author:PXTUONG(19/6/2023
        /// Lấy các bản ghi
        /// </summary>
        /// <param name="RecordCode"> mã bản ghi khi muốn tìm kiếm</param>
        /// <returns></returns>
        public IEnumerable<T> GetAll(string RecordCode)
        {
            //chuẩn bị tên store
            string storedProcedureName = $"Pro_GetAll{typeof(T).Name}";

            // chuẩn bị tham số đầu vào 
            var parameters = new DynamicParameters();

            parameters.Add($"M_{typeof(T).Name}Code", RecordCode);

            //khởi tạo kết nối với db 

            var mySqlConnection = GetOpenConection();

            
            try
            {

                //thực hiện câu lệnh sql 
               var  record = mySqlConnection.Query<T>( storedProcedureName, parameters, commandType: System.Data.CommandType.StoredProcedure);
               
                return record;
            }
            finally
            {
                mySqlConnection.Close();
            }
            // xử lý kết quả 
           
        }
        /// <summary>
        /// Author:PXTRUONG(19/6/2023)
        /// Kết nối db
        /// </summary>
        /// <returns></returns>
        public IDbConnection GetOpenConection()
        {
            var mySqlConnection = new MySqlConnection(DatabaseContext.ConnectionString);
            mySqlConnection.Open();
            return mySqlConnection;
        }
        /// <summary>
        /// Author:PXTRUONG(19/6/2023)
        /// Thêm 1 bản ghi
        /// </summary>
        /// <param name="record">đối tượng khi thêm</param>
        /// <returns></returns>
        public  int Insert(T record)
        {
            //chuẩn bị tên store
            
            string storedProcedureName = $"Pro_Add{typeof(T).Name}";
            // chuẩn bị tham số đầu vào 
            var properties = typeof(T).GetProperties();
            var parameters = new DynamicParameters();
            foreach (var Property in properties)
            {
                parameters.Add($"M_{Property.Name}", Property.GetValue(record));

            }
            //khởi tạo kết nối với db 

            var mySqlConnection = GetOpenConection();

            //thực hiện câu lệnh sql 


            var result = mySqlConnection.Execute(storedProcedureName, parameters, commandType: System.Data.CommandType.StoredProcedure);

            mySqlConnection.Close();

            // xử lý kết quả 
            return result;




        }
        /// <summary>
        /// Author:PXTRUONG(19/6/2023)
        /// Sửa bản ghi
        /// </summary>
        /// <param name="record">dữ liệu đối tượng khi muốn sửa</param>
        /// <returns></returns>
        public int Update(T record)
        {
            //chuẩn bị tên store
            string storedProcedureName = $"Pro_Update{typeof(T).Name}";

            // chuẩn bị tham số đầu vào 
            var properties = typeof(T).GetProperties();
            var parameters = new DynamicParameters();
            foreach (var Property in properties)
            {
                parameters.Add($"M_{Property.Name}", Property.GetValue(record));

            }
            //khởi tạo kết nối với db 
            var mySqlConnection = GetOpenConection();
            //thực hiện câu lệnh sql 
            try
            {
                var result = mySqlConnection.Execute(storedProcedureName, parameters, commandType: System.Data.CommandType.StoredProcedure);

                return result;
            }

            finally
            {
                mySqlConnection.Close();
            }
            // xử lý kết quả

        }

        /// <summary>
        /// Author:PXTRUONG(19/6/2023)
        /// Xoa bản ghi 
        /// </summary>
        /// <param name="RecordCode">xóa bản ghi khi chuyền chuỗi json list các bản ghi</param>
        /// <returns></returns>
        public int DeleteRecordCode(string recordCode)
        {
            //chuẩn bị tên store
            string storedProcedureName = $"Pro_Delete{typeof(T).Name}";

            // chuẩn bị tham số đầu vào 
            var parameters = new DynamicParameters();

            parameters.Add($"M_{typeof(T).Name}Code", recordCode);


            //khởi tạo kết nối với db 

            var mySqlConnection = GetOpenConection();
            using var transaction = mySqlConnection.BeginTransaction();

            //thực hiện câu lệnh sql 
            try
            {

                var result = mySqlConnection.Execute(storedProcedureName, parameters,transaction ,commandType: System.Data.CommandType.StoredProcedure);

                transaction.Commit();
                return result;
            }
            catch (Exception)
            {
                transaction.Rollback();
                throw;
            }
            finally
            {
                mySqlConnection.Close();
            }
            // xử lý kết quả 



        }
        #endregion





    }
}
