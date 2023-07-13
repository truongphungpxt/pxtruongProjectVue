const pelfApi={
        fixedAsset:{
                api:"https://localhost:44373/api/v1/FixedAsset",
                getPaging:"https://localhost:44373/api/v1/FixedAsset/GetPaging",
                maxCode:"https://localhost:44373/api/v1/FixedAsset/FindMaxFixedAssetCode",
                sumery:"https://localhost:44373/api/v1/FixedAsset/ListSum",
                exportExcel:"https://localhost:44373/api/v1/FixedAsset/export"
        },
        department:{
                api :"https://localhost:44373/api/v1/Departments"
        },
        fixedAssetCategory:{
                api:"https://localhost:44373/api/v1/FixedAssetCategorys"
        }

        
 
}
export default pelfApi