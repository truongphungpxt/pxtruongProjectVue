import axios from "axios";
import informStatus from '@/js/enum/informstatus';
import pelfApi from "@/config/pelf/pelfapi";
import toast from "@/plugins/toast";

const request=axios.create({
    baseURL:pelfApi.fixedAsset.api
}) 
request.interceptors.request.use(
    (config) => {
      // Xử lý yêu cầu trước khi gửi đi
      return config;
    },
    (error) => {
        
      // Xử lý lỗi yêu cầu
      return Promise.reject(error);
    }
  );
  /**
   * Author:PXTRUONG(6/7/2023)
   * Nhận phản hồi và trả về thông báo cho người dùng
   */
  request.interceptors.response.use(
    (response) => {
      // Xử lý phản hồi trước khi trả về cho các thành phần Vue khác
     
      if(response.data.Message){
        toast(response.data.Message,informStatus.IsSucess)
      }
      return response;
    },
    (error) => {
        console.log(error);
      // Xử lý lỗi phản hồi
      if (error.response) {
        handleexception(error)
        // Xử lý lỗi phản hồi
      } else {
       
        // Xử lý lỗi không có phản hồi
      }
      return Promise.reject(error);
    }
  );

 const get =async(path,Options)=>{
    try {
        const res= await request.get(path,Options);
     return res.data;  
    } catch (error) {
        // handleexception(error);
    }
  
}
const getByCode =async(path,value)=>{
    const res= await request.get(path+"?recodeCode=" + value);
    return res.data;
}
 const deleteRecord = async(path,value)=>{
    const res= await request.delete(path+"?RecordCode="+value);
    return res.data;
} 
 const post  =async(path,data)=>{
   
        const res= await request.post(path,data);
    return res.data;
    
    
}
 const put  =async(path,Options)=>{
    const res= await request.put(path,Options);
    return res.data;
}
 const getpaging  =async(path,pageSizeInput,pageNumber,keyWord,departmentName,categoryName)=>{
    const res= await request.get(path+'?PageSize='+pageSizeInput+ '&PageNumber=' + pageNumber + 
    "&KeyWord=" + keyWord + "&DepartmentName=" + departmentName + "&FixedCategoryName=" + categoryName);
    return res.data;
}
/**
 * Authorl/PXTRUONG(6/7/2023)
 * Nhận lỗi và đưa ra thông báo 
 * @param {*} error 
 */
function handleexception(error){
    
    if(error.response){
        var response=error.response;
        toast(response.data.UserMessage,informStatus.IsFailed)
    }
    else{
        toast("Lỗi hệ thống ",informStatus.IsFailed)
    }
    
}
export {get,post,put,getpaging,deleteRecord,getByCode,handleexception};