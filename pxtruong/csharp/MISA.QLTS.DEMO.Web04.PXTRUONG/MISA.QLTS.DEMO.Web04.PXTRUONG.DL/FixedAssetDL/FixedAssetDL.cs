using Dapper;
using MISA.QLTS.DEMO.Web04.PXTRUONG.Comon.Entities;
using MISA.QLTS.DEMO.Web04.PXTRUONG.Comon.Entities.DTO;
using MISA.QLTS.DEMO.Web04.PXTRUONG.Comon.Resources;
using MISA.QLTS.DEMO.Web04.PXTRUONG.DL.BaseDL;
using MySqlConnector;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.QLTS.DEMO.Web04.PXTRUONG.DL.FixedAssetDL
{

    public class FixedAssetDL : BaseDL<FixedAsset>, IFixedAssetDL
    {
        /// <summary>
        /// Author:PXTRUONG(23/6/2023)
        /// Thực hiện tìm mã tài sản lớn nhất 
        /// </summary>
        /// <returns></returns>
        public string FindMaxAssetCode()
        {
            //chuẩn bị tên store
            string storedProcedureName = "Pro_FindMaxAssetCode";

    

            //khởi tạo kết nối với db 

            var mySqlConnection = GetOpenConection();


            try
            {

                //thực hiện câu lệnh sql 
                var result = mySqlConnection.QueryFirstOrDefault<string>(storedProcedureName, commandType: System.Data.CommandType.StoredProcedure);

                return result;
            }
            finally
            {
                mySqlConnection.Close();
            }
        }
        /// <summary>
        /// Author:PXTRUONG(25/6/2023)
        /// Thực hiện phân trang 
        /// </summary>
        /// <param name="keyWord"></param>
        /// <param name="departmentName"></param>
        /// <param name="fixedCategoryName"></param>
        /// <param name="pageSize"></param>
        /// <param name="pageNumber"></param>
        /// <returns></returns>
        public ServiceResult GetPaging(string keyWord, string departmentName, string fixedCategoryName, int pageSize, int pageNumber)
        {
            //chuẩn bị tên store
            string storedProcedureName = $"Pro_GetPagingFixedAsset";

            // chuẩn bị tham số đầu vào 
            var parameters = new DynamicParameters();
            parameters.Add("PageNum", pageNumber);
            parameters.Add("PageSize", pageSize);
            parameters.Add("M_DepartmentName", departmentName);
            parameters.Add("M_FixedCategoryName", fixedCategoryName);
            parameters.Add("keyword", keyWord);


            //khởi tạo kết nối với db 

            var mySqlConnection = GetOpenConection();



            //thực hiện câu lệnh sql 
            try
            {
                var Record = mySqlConnection.Query( storedProcedureName, parameters, commandType: System.Data.CommandType.StoredProcedure);
                var cout=0;
                foreach(var item in Record)
                {
                    cout++;
                }
                if(cout > 0)
                {
                    return new ServiceResult()
                    {
                        IsSuccess = true,
                        data = Record
                       
                        
                    };
                }
                else
                {
                    return new ServiceResult()
                    {
                        IsSuccess = false,
                        data = Record
                    };
                }
                
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                mySqlConnection.Close();
            };
        }
       
        /// <summary>
        /// Author:PXTRUONG(29/6/203)
        /// Thực hiện gọi đến db tính tổng các trường yêu cầu 
        /// </summary>
        /// <returns></returns>
        public ListTotalDTO Sum()
        {
            //chuẩn bị tên store
            string storedProcedureName = "Pro_SumListFixedAsset";



            //khởi tạo kết nối với db 

            var mySqlConnection = GetOpenConection();


            try
            {

                //thực hiện câu lệnh sql 
                var result = mySqlConnection.QueryFirstOrDefault<ListTotalDTO>(storedProcedureName, commandType: System.Data.CommandType.StoredProcedure);

                return result;
            }
            finally
            {
                mySqlConnection.Close();
            }
        }
        /// <summary>
        /// Author:PXTRONG(28/6/2023)
        /// Tìm FixedAsset theo id 
        /// </summary>
        /// <param name="FixedAssetID"></param>
        /// <returns></returns>
        public FixedAsset GetByID(Guid FixedAssetID)
        {
            //chuẩn bị tên store
            string storedProcedureName = "Pro_GetFixedAssetByID";

            // chuẩn bị tham số đầu vào 
            var parameters = new DynamicParameters();

            parameters.Add($"M_FixedAssetByID", FixedAssetID);

            //khởi tạo kết nối với db 

            var mySqlConnection = GetOpenConection();


            try
            {
                //thực hiện câu lệnh sql 
                var result = mySqlConnection.QueryFirstOrDefault<FixedAsset>(storedProcedureName,parameters, commandType: System.Data.CommandType.StoredProcedure);
                return result;
            }
            finally
            {
                mySqlConnection.Close();
            }
        }
    }

}
