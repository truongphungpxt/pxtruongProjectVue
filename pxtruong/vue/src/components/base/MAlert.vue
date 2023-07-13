<template>
    <div class="body__popup">
        <div class="alert">
            <div class="alert__content--container">
                <div class="icon  alert__icon"></div>
                <div class="alert__content">
                  <span class="font__bold" v-if="listDelete.length>1" >
                     <span v-if="listDelete.length>1 && listDelete.length<10">0</span> {{ listDelete.length }}</span>  {{   alertContent }} 
                  <span class="font__bold" v-if="listDelete.length==1">{{ ""+this.listDelete[0]  +" "+ this.assetName+" ?"}} </span>
                </div>

            </div>
            <div class="elert__button--container">
                <button class=" button button--white" v-if="btnWhite" @click="close">{{ btnWhite }}</button>
                <button v-if="btnBorderBlue" class=" button button__boder--blue" @click="btnBorder" > {{ btnBorderBlue }}</button>
                <button class=" button button--blue" @click="btnActive" v-if="btnBlue">{{ btnBlue }}</button>
            </div>
        </div>


    </div>
</template>
<script>
import pelfApi from '@/config/pelf/pelfapi';
import {getByCode } from '@/js/services/sendrequest';
export default {
    props: {
        isDelete:  {
            type: Boolean,
            default: false
        },
        alertContentInput:null,
        isFixedAsset: {
            type: Boolean,
            default: false
        },
        isCancalDeclare:{
            type: Boolean,
            default: false
        },
        statusAlert:null,
        listDelete:[],
        isInvalue:Boolean,
        
       
    },
  
    created() {
      
      
          //chuyền nội dung vào button và nội dung cảnh bảo 
          if (this.isDelete) {
            this.btnWhite = this.$_MResource.buttonTitle.No;
            this.btnBlue = this.$_MResource.buttonTitle.Delete;
            if (this.listDelete.length > 1) {
                this.alertContent =    this.$_MResource.AlertContent.MuntipleDelete;
            }
            else if(this.listDelete.length == 1) {
                this.findFixedName();
                this.alertContent = this.$_MResource.AlertContent.Delete  ;
                console.log(this.alertContent);
            }
            else{
                this.btnWhite = null;
                this.btnBlue = this.$_MResource.buttonTitle.Close;
                this.alertContent = this.$_MResource.AlertContent.Undefine ;
            }
        }
        if(this.statusAlert==this.$_MStatusAlert.IsAddFixAsset){
                this.btnWhite = this.$_MResource.buttonTitle.No;
                this.btnBlue = this.$_MResource.buttonTitle.Cancal;
                this.alertContent = this.$_MResource.AlertContent.IsCancal ;
        }
        if(this.statusAlert==this.$_MStatusAlert.IsFixAsset){
                this.btnWhite = this.$_MResource.buttonTitle.Cancal;
                this.btnBlue = this.$_MResource.buttonTitle.Save;
                this.btnBorderBlue=this.$_MResource.buttonTitle.UnSave;
                this.alertContent = this.$_MResource.AlertContent.UnSave ;
        }
        if(this.alertContentInput){
            this.alertContent=this.alertContentInput;
            this.btnWhite=false;
            this.btnBlue = this.$_MResource.buttonTitle.Close;
        }
      

    },
    methods: {
        btnBorder(){
            this.$emit("close",false);
        },
        /**
         * Author:PXTRUONG(21/6/2013)
         * Thực hiện tìm tên tài sản 
         */
     async   findFixedName(){
            try {
                var result= await getByCode(pelfApi.fixedAsset.api,this.listDelete[0]);
                this.assetName= result[0].FixedAssetName;
            } catch (error) {
                
            }
        },
        /**
         * Author:PXTRUONG(6/6/2023)
         * Thực hiện các lên và đóng form 
         */
        btnActive(){
            if(this.statusAlert==this.$_MStatusAlert.IsFixAsset){
                this.$emit("close",true,this.$_MStatusAlert.IsFixAsset);
            }
           else if(this.statusAlert==this.$_MStatusAlert.IsAddFixAsset){
                if( this.btnBlue == this.$_MResource.buttonTitle.Close){
                    this.$emit("close",true,false);
                }
                else{
                    this.$emit("close",true,this.$_MStatusAlert.IsAddFixAsset);
                }
              
            
               
            }
            else{
                this.closeAlert();
            }
           
        },
        /**
         * Author:PXTRUONG(6/6/2023)
         * Thực hiện  đóng form 
         */
        closeAlert(){
            if(this.listDelete.length>0){
                this.$emit("close",true);
            }
            else{
                this.$emit("close");
            }
           
        },
        /**
         * Author:PXTRUONG(19/6/2023)
         * Thực hiện đóng cảnh báo khi nhân nút hủy 
         */
        close(){
          
            if(this.statusAlert==this.$_MStatusAlert.IsAddFixAsset||this.statusAlert==this.$_MStatusAlert.IsFixAsset){
                this.$emit("close",true);
            }
            else{
                this.$emit("close");
            }

        }

    },
    data() {
        return {
            btnWhite: null,
            btnBlue: null,
            btnBorderBlue: null,
            alertContent: null,
            assetName:null
          
        }
    },
}
</script>
<style scoped>
@import url(../../style/base/popup.css);
@import url(../../style/base/icon.css);
@import url(../../style/base/button.css);
@import url(../../style/base/alert.css);
</style>