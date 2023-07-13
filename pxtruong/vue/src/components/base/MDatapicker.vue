<template>
    <div class="input__container">
        <p class="popup__font__label--name">
            {{ inputContent }} <span v-if="isNotAllowNull" class="popup__color--red">*</span>
        </p>
        <div>
            <VueDatePicker v-model="this.value" auto-apply :format="format" text-input  locale="vi" :day-names="['T2','T3','T4', 'T5', 'T6', 'T7', 'CN']" 
                >
                <template #input-icon>

                    <div class="icon dp__input--icon"></div>
                </template>
                <template #dp-input="{ value,onInput,onEnter}">
                    <input type="text"  :value="value"     ref="Minput" class="input__field" :class="{ 'input__boder--red': this.isNull }" @blur="validate(value)"  @input="onInput"  @keydown.enter="onEnter" />
                </template>

                <template #clear-icon>
                    <img style="display: none;" />
                </template>
                <template #action-extra="{ selectCurrentDate }">
                    <span @click="selectCurrentDate()" title="Select current date">
                        Hôm nay
                    </span>
                </template>
            </VueDatePicker>
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
        inputContent: null,
        isNotAllowNull: Boolean,
        modelValue: null,
        isCheckValidate: {
            type: Boolean,
            default: false
        }
    },
    data() {
        return {
            value: Date,
            format: "dd/MM/yyyy",
            isNull: false,
            alertMsg: null,
        }
    },
    watch: {
        value: function (newValue) {
            if (!this.checkNull(this.value)) {
                this.isNull=false;
            }
            this.$emit("update:modelValue", newValue);

        },
        modelValue:function(newValue){
            this.value = newValue;
        },
        isCheckValidate: function (newValue) {
            if (newValue && this.isNotAllowNull) {
                this.validate(this.value)

            }
        }
    },
    created() {

        this.value = this.modelValue;
        
    },
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
        // onBlur(){

        // },
        // getValue(event) {
        //     if (event.keyCode) {
        //         this.validate(this.value);
        //     }
        //     console.log(event.keyCode);
        // },
        /**
        * AuthorPXTRUONG(15/6/2023)
        * Check null
        */
        checkNull(data) {


            data=format.whiteSpace(data)
        
            if (!data) {
                
                return true;
            }
            else {
                return false;
            }
        },
        /**
         * Author:PXTRUONG(6/5/2023)
         * kiểm tra dữ liệu 
         */
        validate(data) {
            try {
                // data = new Date(data)
          
                if (this.isNotAllowNull) {
                    if (this.checkNull(data)) {
                        this.isNull = true;
                        this.alertMsg = this.inputContent + " không được bỏ trống";

                    }
                    else {
                        this.isNull = false;
                    }
                }

            } catch (error) {

            }

        }
    }
}
</script>
<style >
@import url('../../style/base/textfield.css');

.dp__input_icon {
    left: unset !important;
    right: 0;
    border: unset !important;

}

img {
    border: unset;
}

/* .dp__icon path{
   display: none !important;
} */
.dp__input_icon_pad {
    padding-left: 12px !important;
}

.dp__button_bottom {
    display: none !important;
}

.dp__action_extra {
    border-top: 1px solid #afafaf;
    height: 45px;
    display: flex;
    align-items: center;
    justify-content: center;
    color: #50B83C;

}
</style>