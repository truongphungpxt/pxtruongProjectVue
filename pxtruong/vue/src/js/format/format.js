const format={
         /**
      * Format lại về dạng tiền
      * Author:PXTRUONG(24/05/2023)
      */
         fomatmoney(money,isPercent,isSetDefault){
            try { 
               
                if(money){
                    if(isPercent){
                       if(money==Infinity){
                        return "";
                       }
                       else{
                        money = parseFloat(money).toFixed(2);
                      
                        money = money.toString();
                        
                        return money.replaceAll(".",","); 
                       }
                     
                    }
                    else{
                        money = parseFloat(money).toFixed(0);
                        money = money.toString();
                        return money.replace(/(\d)(?=(\d{3})+(?!\d))/g, "$1."); 
                    }
                
                }
                else{
                    if(isSetDefault){
                        return 0;
                    }
                    else{
                        return "";
                    }
                    
                }
                     
            } catch (error) {
                return error
            }
        },
         /**
      * unformat lại từ dạng tiền về số 
      * Author:PXTRUONG(8/6/2023)
      */
        unformat(money,isPercent){
            try {
                if(money){
                    if(isPercent){
                        var value= parseFloat(money.replaceAll(",","."));
                       
                        return value;
                    }
                    else{
                        var value= parseInt(money.replaceAll(".",""));
                        return value;
                    }
                   
                }
                else{
                    return 0;
                }
               
            } catch (error) {
                console.log(error);
            }
        },
        /**
         * Author:PXTRUONG(20/6/2023)
         * Xóa khoảng trắng 
         */
        whiteSpace(data){
            if(data){
                data=data.toString();
                var value= data.replace(/\s/g, "");
                return value;
                 
            }
        }
};
export default format