<template>
    <div class="input__container">
        <p class="popup__font__label--name">
            {{ inputContent }} <span v-if="isNotAllowNull" class="popup__color--red">*</span>
        </p>
        <div>
            <input v-if="isNomalInput == true" class="input__field  " v-model="this.value" @blur="validate(this.value)"
                :class="{ 'input__boder--red': isNull }" ref="Minput" :maxlength="setMaxLength" >

            <input v-if="isDisable == true" class="input__field bgr__color--gray " disabled v-model="this.value"
                @blur="validate(this.value)" :class="{ 'input__boder--red': isNull }">

                <input v-if="isDisablePaddingRight == true" class="input__field bgr__color--gray  set_text--left " disabled v-model="this.value"
                @blur="validate(this.value)" :class="{ 'input__boder--red': isNull }">

            <div class="popup__error">
                <div class="popup__color--red" v-if="isNull">
                    {{ alertMsg }}
                </div>
            </div>
        </div>

    </div>
</template>
<script>
import format from '@/js/format/format';
export default {
    props: {
        modelValue: null,
        inputContent: null,
        isNotAllowNull: Boolean,
        isInputNumber: {
            type: Boolean,
            default: false
        },
        isDisable: {
            type: Boolean,
            default: false
        },
        isFocus: {
            type: Boolean,
            default: false
        },
        isNomalInput: {
            type: Boolean,
            default: false
        },
        isCheckValidate: {
            type: Boolean,
            default: false
        },
        refText: null,
        isDisablePaddingRight:{
            type: Boolean,
            default: false
        },
        setMaxLength:null

        

    },
    created() {
        this.value = this.modelValue;
       
    },
    watch: {
        isFocus:function(newValue){
            
            if(newValue){
                
                this.$refs["Minput"].focus();
               
            }
           
        },
        value: function (newValue) {
            // if (!this.checkNull(newValue)) {
            //     this.validate(newValue);
               
            // }
            
         
            this.$emit("update:modelValue", newValue);
        },
        modelValue: function (newValue) {
            this.value = newValue;
        },
        isCheckValidate: function (newValue) {
            if (newValue && this.isNotAllowNull) {
               if(this.validate(this.value)){
                
               } 
                
            }
        }
    },
    // mounted() {
    //     //xét focus vào input mình muốn 
    //     if (this.isFocus) {
    //         this.$nextTick(function () {
    //             this.$refs["Minput"].focus();
    //         })
    //     }
        


    // },

    methods: {
        /**
         * Author:PXTRUONG(27/6/2023)
         * Thực hiện focus 
         */
        focus(){
            this.$nextTick(function () {
                this.$refs["Minput"].focus();
            })
        },
        
        /**
         * AuthorPXTRUONG(15/6/2023)
         * Check null
         */
        checkNull( data) {
            data=format.whiteSpace(data)
        
            if (!data) {
                return true;
            }
            else {
                return false;
            }
        },
        /**
         * Author:PXTRUONG, Create: 29/5/2023
         * validate dữ liệu 
         */
        validate(data) {
            try {
                if (this.isNotAllowNull == true) {
                    const t= this
                    const value= t.modelValue;
                    if ( this.checkNull(value)) {
                        this.isNull = true;
                        this.alertMsg = this.inputContent + " không được bỏ trống";
                        // this.$nextTick( ()=> {
                        //     this.$refs.Minput?.focus();
                        // });
                        // console.log( this.$refs.Minput);
                        return true;
                    }
                    else {
                        this.isNull = false;

                        return false;
                    }

                }

            } catch (error) {

            }


        },


    },
    data() {
        return {
            value: null,
            isRequid: Boolean,
            isNull: false,
            alertMsg: null

        }
    },
}
</script>
<style scoped>
@import url(../../style/base/textfield.css);
@import url(../../style/base/icon.css);
</style>