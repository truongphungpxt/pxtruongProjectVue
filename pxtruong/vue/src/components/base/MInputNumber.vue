<template>
    <div class="input__container">
        <p class="popup__font__label--name">
            {{ inputContent }} <span v-if="isNotAllowNull" class="popup__color--red">*</span>
        </p>
        <div>
            <input v-if="isDisableAndPaddingRight == true" type="text" disabled
                class="input__field bgr__color--gray set_text--left " v-model="this.value" @blur="validate(this.value)"
                :class="{ 'input__boder--red': isNull }" ref="Minput">

            <input v-if="isPaddingRight == true" class="input__field set_text--left " v-model="this.value"
                @blur="validate(this.value)" :class="{ 'input__boder--red': isNull }" @keydown.up="btnUp"
                @keydown.down="btnDown" ref="Minput" type="text" :maxlength="setMaxLength">

            <div class="input__range" v-if="isInputNumber">
                <div class=" icon input__icon--dropdownup" @click="btnUp">

                </div>
                <div class="icon input__icon--dropdown" @click="btnDown">

                </div>
            </div>
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
        isDisableAndPaddingRight: {
            type: Boolean,
            default: false
        },
        isPaddingRight: {
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
        setMaxLength: null,
        isPercent: {
            type: Boolean,
            default: false
        },
        proptext: null,
        isSetDefault:false
    },
    created() {
        this.value = format.fomatmoney(this.modelValue, this.isPercent,this.isSetDefault);
        this.displayNumber = this.modelValue;


    },
    watch: {
        value: function (newValue) {
            var data;
            data = format.unformat(newValue, this.isPercent);
            if (!this.checkNull(newValue)) {
                this.validate(newValue);
            }
            this.$emit("update:modelValue", data);
            this.$emit("bindDate", data, this.proptext);
            this.value = format.fomatmoney(data, this.isPercent);
        },
        modelValue: function (newValue) {
            this.value = format.fomatmoney(newValue, this.isPercent);
        },
        isCheckValidate: function (newValue) {
            if (newValue && this.isNotAllowNull) {
                this.validate(this.value)

            }
        }

    },
    methods: {
        /**
        * Author:PXTRUONG(27/6/2023)
        * Thực hiện focus 
        */
        focus() {
            this.$nextTick(function () {
                this.$refs["Minput"].focus();
            })
        },
        /**
       * AuthorPXTRUONG(15/6/2023)
       * Check null
       */
        checkNull(data) {
            if (data == null || data == undefined || data == "") {
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
                data = format.unformat(data, this.isPercent);
                if (this.isNotAllowNull == true) {

                    if (data == null || data == undefined || data == "") {
                        this.isNull = true;
                        this.alertMsg = this.inputContent + " " + this.$_MResource.AlertContent.NotNull;
                        
                        return true;
                    }
                    else {
                        this.isNull = false;

                        return false;
                    }
                    // }

                }
            } catch (error) {

            }



        },
        /**
         * Author:PXTRUONG(30/5/2023)
         * Kiểm tra xem có value có phải dạng sô không
         */
        checkNumber(data) {
            return Number.isFinite(data);
        },
        /**
         * Author:PXTRUONG(30/5/2023)
         * thực hiện tăng thêm 1 đơn vị khi input dạng số 
         */
        btnUp() {
            try {
                if (this.isInputNumber) {
                    //lần đầu tiên chưa nhập số gì khi nhẫn nút tăng 

                    if (this.validate(this.value)) {
                        this.value = 0;
                    }
                    this.value = format.unformat(this.value, this.isPercent);
                    this.value += 1;
                    this.value = format.fomatmoney(this.value, this.isPercent);
                    this.validate(this.value);
                }
            } catch (error) {
                console.log(error);
            }



        },

        /**
        * Author:PXTRUONG(30/5/2023)
        * thực hiện giảm  thêm 1 đơn vị khi input dạng số 
        */
        btnDown() {
            try {
                if (this.isInputNumber) {

                    if (this.validate(this.value)) {
                        this.value = 0;
                    }
                    this.value = format.unformat(this.value, this.isPercent);

                    this.value -= 1;
                    if (this.value <= 0) {
                        this.value = 0;
                    }
                    else {

                        this.value = format.fomatmoney(this.value, this.isPercent);
                        this.validate(this.value);

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
            alertMsg: null,
            displayNumber: null

        }
    },
}
</script>
<style scoped>
@import url(../../style/base/textfield.css);
@import url(../../style/base/icon.css);
</style>