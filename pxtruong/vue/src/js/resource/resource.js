const resource={
    tableTitle:{
        
       STT :{
            value: "STT",
            type:"string"

       },
       FixedAssetCode :
       {
        value: " Mã tài sản ",
        type:"string",
        Key:"FixedAssetCode"
       } ,
       FixedAssetName : 
       {
        value: " Tên tài sản ",
        type:"string",
        Key:"FixedAssetName"
       },
       FixedAssetCategoryName :{
        value: " Loại tài sản  ",
        type:"string",
        Key:"FixedAssetCategoryName"
       } ,
       DepartmentName : {
        value: "  Bộ phận sử dụng  ",
        type:"string",
        Key:"DepartmentName"
       },
       Quantity : {
        value: "Số lượng",
        type:"number",
        Key:"Quantity"
       },
       Cost:{
        value: "Nguyên giá ",
        type:"number",
        Key:"Cost"
       } ,
       Accumulated :{
        value: "HM/KH lũy kế",
        title:"Hao mòn lũy kế",
        type:"number",
        Key:"OriginalPrice"
       } ,
       ResidualValue :{
        value: "Giá trị còn lại ",
        type:"number",
        Key:"OriginalPrice"
       } ,
       Action:{
        value: "Chức năng ",
       
       }

    },
    assetTitle:{
        AssetCode:{
            key:"FixedAssetCode",
            type:"string"
        },
        AssetName :{ 
             key:"FixedAssetName",
             type:"string"
         },
        AssetType  :{ 
             key:"FixedAssetCategoryName",
             type:"string"
        },
        Department:{ 
             key:"DepartmentName",
             type:"string"
        } ,
        Amount :{
              key:"Quantity",
              type:"number"
         },
        OriginalPrice:{
              key:"Cost",
              type:"number"
        },
         
    },
    tooltip:{

    }
    ,
    buttonTitle:{
        Delete:"Xóa",
        UnSave:"Không lưu",
        No:"Không",
        Save:"Lưu",
        AddAsset:"Thêm tài sản ",
        Close:"Đóng",
        Cancal:"Hủy bỏ",
        drop:"Hủy"
        
    },
    AlertContent:{
        Delete:"Bạn có muốn xóa tài sản ",
        MuntipleDelete:"tài sản đã được chọn. Bạn có muốn xóa các tài sản này khỏi danh sách?",
        UnAllowDelete:"Không thể xóa tài sản này vì đã có chứng từ phát sinh ",
        UnAllowMuntipleDelete:"tài sản được chọn không thể xóa. Vui lòng kiểm tra lại tài sản trước khi thực hiện xóa.",
        Undefine:"Bạn chưa chọn tài sản để xóa",
        IsCancal:"Bạn có muốn hủy bỏ khai báo tài sản này ? ",
        UnSave:"Thông tin thay đổi sẽ không được cập nhập nếu bạn Không lưu. Bạn có muốn lưu các thay đổi này?",
        NotNull:"không được bỏ trống",
        NotUpto:"Không được vượt quá "
    },
    FormModeTitle:{
        AddAsset:"Thêm tài sản",
        FixAsset:"Sửa tài sản "
    },
    InformContent:{
        DeleteSucess:"xóa bản ghi",
        Add:"thêm bản ghi",
        Fixed:"sửa bản ghi "
    },
    PropText:{
        Department:{
            DepartmentCode:"DepartmentCode",
            DepartmentName:"DepartmentName"
        },
        FixedAssetCategory:{
            FixedAssetCategoryCode:"FixedAssetCategoryCode",
            FixedAssetCategoryName:"FixedAssetCategoryName"
        },
        FixedAsset:{
            Cost:"Cost",
            DepreciationRate:"DepreciationRate",
            ProductionYear:"ProductionYear"
        }
       
    },
    assertLable:{
        FixedAssetCode :
       {
        value: "Mã tài sản",
       } ,
       FixedAssetName : 
       {
        value: "Tên tài sản ",
       },
       FixedAssetCategoryName :{
        value: "Tên loại tài sản ",
       } ,
       FixedAssetCategoryCode :{
        value: " Mã loại tài sản ",
       } ,
       DepartmentName : {
        value: "Tên bộ phân sử dụng ",
       },
       DepartmentCode : {
        value: "Mã bộ phận sử dụng  ",
       },
       Quantity : {
        value: "Số lượng",
       },
       ProductionYear:{
        value: "Số năm sử dụng ",
       } ,
       DepreciationRate:{
        value: "Tỷ lệ hao mòn(%)",
       } ,
       Cost:{
        value: "Nguyên giá",
       } ,
       AtrophyYear:{
        value: "Giá trị hao mòn năm ",
       } ,
       TrackedYear:{
        value: "Năm theo dõi ",
       } ,
       PurchaseDate:{
        value: "Ngày mua ",
       } ,
       DayUse:{
        value: "Ngày bắt đầu sử dụng ",
       } ,
    },
    placeholder:{
        DepartmentName:"Bộ phận sử dụng",
        categoryName:"loại tài sản "
    }
}
export default resource