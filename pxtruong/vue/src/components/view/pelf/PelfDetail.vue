<template>
    <div class="body__popup" id="detailEmployee" tabindex="0" v-ctrls="btnSave">
        <div class="popup" v-esc="btnClose">
            <div class="popup__body">
                <div class="popup__body__header">
                    <p class="popup__font--bold">{{ popupTitle }}
                    </p>
                    <div class="icon popup__icon--cancal" title="Đóng form" @click="btnClose"></div>
                </div>

                <div class="popup__body__container">
                    <div class="body__container">
                        <div class="popup__body__container--left">
                            <minput :input-content="this.$_MResource.assertLable.FixedAssetCode.value"
                                :is-input-number="false" :is-not-allow-null="true" :is-nomal-input="true"
                                v-model="pelfInput.FixedAssetCode" :is-check-validate="this.isCheckValidate"
                                ref="FixedAssetCode" :set-max-length="this.$_MMaxLengthInput.RecodeCode">

                            </minput>

                        </div>
                        <div class="popup__body__container--right">
                            <minput :input-content="this.$_MResource.assertLable.FixedAssetName.value"
                                :is-not-allow-null="true" v-model="pelfInput.FixedAssetName" :is-nomal-input="true"
                                :is-check-validate="this.isCheckValidate" ref="FixedAssetName"
                                :set-max-length="this.$_MMaxLengthInput.Nameother">

                            </minput>

                        </div>
                    </div>
                    <div class="body__container">
                        <div class="popup__body__container--left">

                            <m-dropdown :input-content="this.$_MResource.assertLable.DepartmentCode.value"
                                :prop-text=this.$_MResource.PropText.Department.DepartmentCode :is-not-allow-null="true"
                                :api=this.$_MApi.department.api v-model="pelfInput.DepartmentCode" @sendData="bindData"
                                :is-check-validate="this.isCheckValidate" ref="DepartmentCode"
                                :set-max-length="this.$_MMaxLengthInput.RecodeCode">

                            </m-dropdown>


                        </div>
                        <div class="popup__body__container--right">
                            <minput :input-content="this.$_MResource.assertLable.DepartmentName.value"
                                :is-input-number="false" :is-disable="true" v-model="pelfInput.DepartmentName"
                                :is-check-validate="this.isCheckValidate" ref="DepartmentName">

                            </minput>


                        </div>
                    </div>
                    <div class="body__container">
                        <div class="popup__body__container--left">

                            <m-dropdown :input-content="this.$_MResource.assertLable.FixedAssetCategoryCode.value"
                                :is-not-allow-null="true"
                                :prop-text=this.$_MResource.PropText.FixedAssetCategory.FixedAssetCategoryCode
                                :api=this.$_MApi.fixedAssetCategory.api v-model="pelfInput.FixedAssetCategoryCode"
                                @sendData="bindData" :is-check-validate="this.isCheckValidate" ref="FixedAssetCategoryCode"
                                :set-max-length="this.$_MMaxLengthInput.RecodeCode">

                            </m-dropdown>


                        </div>
                        <div class="popup__body__container--right">
                            <minput :input-content="this.$_MResource.assertLable.FixedAssetCategoryName.value"
                                :is-input-number="false" :is-disable="true" v-model="pelfInput.FixedAssetCategoryName"
                                :is-check-validate="this.isCheckValidate" ref="FixedAssetCategoryName">

                            </minput>


                        </div>
                    </div>
                    <div class="body__container">
                        <div class="popup__body__container--left">

                            <minput-number :input-content="this.$_MResource.assertLable.Quantity.value"
                                :is-input-number="true" :is-not-allow-null="true" :is-padding-right="true"
                                v-model="pelfInput.Quantity" :is-check-validate="this.isCheckValidate" ref="Quantity"
                                :set-max-length="this.$_MMaxLengthInput.number">

                            </minput-number>


                        </div>
                        <div class="popup__body__container--right">
                            <div class="input__container ">

                                <div class="input__content--flex">
                                    <minput-number :input-content="this.$_MResource.assertLable.Cost.value"
                                        :is-input-number="false" :is-not-allow-null="true" :is-padding-right="true"
                                        v-model="pelfInput.Cost" :is-check-validate="this.isCheckValidate" ref="Cost"
                                        :set-max-length="this.$_MMaxLengthInput.number"
                                        :proptext=this.$_MResource.PropText.FixedAsset.Cost @bindDate="binddatainput">

                                    </minput-number>

                                    <minput-number :input-content="this.$_MResource.assertLable.ProductionYear.value"
                                        :is-input-number="false" :is-not-allow-null="true" :is-padding-right="true"
                                        v-model="pelfInput.ProductionYear" :is-check-validate="this.isCheckValidate"
                                        ref="LifeTime" :set-max-length="this.$_MMaxLengthInput.number"
                                        @bindDate="binddatainput"
                                        :proptext=this.$_MResource.PropText.FixedAsset.ProductionYear>

                                    </minput-number>


                                </div>

                            </div>

                        </div>
                    </div>
                    <div class="body__container">
                        <div class="popup__body__container--left">

                            <minput-number :input-content="this.$_MResource.assertLable.DepreciationRate.value"
                                :is-input-number="true" :is-not-allow-null="true" :is-padding-right="true"
                                v-model="pelfInput.DepreciationRate" :is-check-validate="this.isCheckValidate"
                                ref="DepreciationRate" :set-max-length="this.$_MMaxLengthInput.number"
                                :proptext=this.$_MResource.PropText.FixedAsset.DepreciationRate @bindDate="binddatainput"
                                :is-percent="true">

                            </minput-number>



                        </div>
                        <div class="popup__body__container--right">
                            <div class="input__container ">

                                <div class="input__content--flex">
                                    <minput-number :input-content="this.$_MResource.assertLable.AtrophyYear.value"
                                        :is-input-number="false" :is-not-allow-null="true" :is-padding-right="true"
                                        :isSetDefault="true" v-model="this.pelfInput.AtrophyYear"
                                        :is-check-validate="this.isCheckValidate" ref="atrophyYear"
                                        :maxQuantyti="pelfInput.Cost" :set-max-length="this.$_MMaxLengthInput.number">

                                    </minput-number>

                                    <minput :input-content="this.$_MResource.assertLable.TrackedYear.value"
                                        :is-input-number="false" :is-disable-padding-right="true"
                                        v-model="pelfInput.TrackedYear" :is-check-validate="this.isCheckValidate"
                                        ref="TrackedYear">

                                    </minput>


                                </div>

                            </div>

                        </div>
                    </div>
                    <div class="body__container">
                        <div class="popup__body__container--left">

                            <m-datapicker :input-content="this.$_MResource.assertLable.PurchaseDate.value"
                                :is-not-allow-null="true" v-model="pelfInput.PurchaseDate"
                                :is-check-validate="this.isCheckValidate" ref="PurchaseDate"></m-datapicker>



                        </div>
                        <div class="popup__body__container--right">
                            <div class="input__container ">

                                <div class="input__content--flex">
                                    <m-datapicker :input-content="this.$_MResource.assertLable.DayUse.value"
                                        :is-not-allow-null="true" v-model="pelfInput.DayUse"
                                        :is-check-validate="this.isCheckValidate" ref="DayUse"></m-datapicker>

                                    <div class="input__container"></div>

                                </div>

                            </div>

                        </div>
                    </div>


                </div>


            </div>

            <div class="popup__pooter">
                <button class="button button--blue" @click="btnSave">{{ this.$_MResource.buttonTitle.Save }}</button>
                <button class="button button--white" @click="btnCloseUnSave" @keydown="focusTop($event)">
                    {{ this.$_MResource.buttonTitle.drop }}</button>

            </div>
        </div>
    </div>
    <m-alert v-if="isShowAlert" :status-alert="this.statusAlert" :list-delete="[]" @close="closeAlert"
        :alert-content-input="this.alertContent"></m-alert>
    <m-notification :informStatus="this.informStatus" :informContent="this.informContent"></m-notification>
</template>
<script>

import format from '@/js/format/format';
import MAlert from '@/components/base/MAlert.vue';
import pelfApi from '@/config/pelf/pelfapi';
import Minput from "@/components/base/Minput.vue";
import MinputNumber from "@/components/base/MInputNumber.vue";
import MDropdown from "@/components/base/MDropdown.vue";
import MDatapicker from "@/components/base/MDatapicker.vue";
import MNotification from '@/components/base/MNotification.vue';
import resource from "@/js/resource/resource";
import { get, post, put, getByCode, handleexception } from '@/js/services/sendrequest';
import { join } from 'lodash';

export default {
    components: { Minput, MDropdown, MDatapicker, MinputNumber, MAlert, MNotification },
    props: {
        pelf: null,
        formMode: null,


    },
    created() {

        var now = new Date();

        this.loadData(this.pelf.FixedAssetCode);
        if (this.formMode == this.$_MFormMode.FixAsset) {
            this.popupTitle = resource.FormModeTitle.FixAsset
            // this.pelfInput.AtrophyYear="10";
        }
        else if (this.formMode == this.$_MFormMode.AddAsset) {
            this.popupTitle = resource.FormModeTitle.AddAsset
            this.findMaxCode();
            this.pelfInput.TrackedYear = now.getFullYear();
        }

        // this.pelfInput.AtrophyYear = this.pelfInput.Cost * this.pelfInput.DepreciationRate / 100;



    },
    mounted() {
        //xét focus vào input mình muốn 
        this.$nextTick(function () {
            this.$refs.FixedAssetCode.focus()
        })
    },
    methods: {
        /**
         * Author:PXTRUONG(29/6/2023)
         * Load data từ api tìm tài sản 
         */
        async loadData(data) {
            try {
                var result = await getByCode(pelfApi.fixedAsset.api, data);
                if (this.formMode == this.$_MFormMode.AddAsset) {
                    if (data == null) {
                        return;
                    }
                    else {
                        this.pelfInput = result[0];
                        this.pelfInput.DepreciationRate = result[0].DepreciationRate * 100;
                        this.pelfInput.FixedAssetCode = await this.findMaxCode();
                    }
                }
                else if (this.formMode == this.$_MFormMode.FixAsset) {
                    var data = JSON.stringify(result[0])
                    this.pelfInput = JSON.parse(data);
                    this.pelftDefault = JSON.parse(data);
                    this.pelfInput.DepreciationRate = result[0].DepreciationRate * 100;
                }
            } catch (error) {

            }

        },
        /**
         * Author:PXTRUONG(24/6/2023)
         * Bind data vào ô input
         */
        binddatainput(data, prop) {

            if (prop == this.$_MResource.PropText.FixedAsset.ProductionYear) {
                this.pelfInput.DepreciationRate = (1 / data) * 100;
                this.pelfInput.AtrophyYear = this.pelfInput.Cost * this.pelfInput.DepreciationRate / 100;
            }
            else if (prop == this.$_MResource.PropText.FixedAsset.Cost) {
                this.pelfInput.AtrophyYear = data * this.pelfInput.DepreciationRate / 100;
            }
            else if (prop == this.$_MResource.PropText.FixedAsset.DepreciationRate) {
                this.pelfInput.AtrophyYear = this.pelfInput.Cost * data / 100;
            }


        },


        /**
         * Author:PXTRUONG(24/6/2023)
         * Chuyển tab lên trang đầu 
         */
        focusTop(event) {

            if (event.keyCode == 9) {
                event.preventDefault();

                this.$refs["FixedAssetCode"].focus();
                return;
            }





        },
        /**
         * Author:PXTRUONG(22/6/2023)
         * Tìm tìm FixedassetCode lớn nhất 
         */
        async findMaxCode() {

            try {
                var result = await get(pelfApi.fixedAsset.maxCode);
                this.pelfInput.FixedAssetCode = result;
                console.log(result);
                return result;

            } catch (error) {
                console.log(error);
            }


        },
        /**
         * Author:PXTRUONG(15/6/2023)
         * Đóng mở cảnh báo 
         */
        async closeAlert(isForm, status) {

            if (isForm) {
                if (status == this.$_MStatusAlert.IsFixAsset) {
                    await this.btnSave();
                }
                if (status == this.$_MStatusAlert.IsAddFixAsset) {
                    this.isShowAlert = false;
                    this.btnClose();
                    return;
                }

                this.isShowAlert = false;
                return;
            }
            else {
                this.isShowAlert = false;
                this.btnClose();
                return;
            }



        },
        /**
         * Author:PXTRUONG(15/6/2023)
         * Add list invalid vào 1 mảng 
         */
        addListInValues(data, isPush) {
            if (isPush) {
                this.listInValue.push(data);
            }
            else {
                this.listInValue = this.listInValue.filter(item => item !== data)
            }

        },
        /**
         * Author:PXTRUONG(15/6/2023)
         * Check null
         */
        checkNull(data) {
            data = format.whiteSpace(data)

            if (!data) {

                return true;
            }
            else {
                return false;
            }
        },
        /**
         * đóng form chi tiết tài sản 
         * Author: PXTRUONG, Create: 24/3/2023
         */
        btnClose() {
            this.$emit("hiddePolfDetail");
        },
        /**
         * Author:PXTRUONG(15/6/2023)
         * Thực hiện gọi api thêm tài sản 
         */
        async add() {
            try {
                console.log(this.pelfInput);
                this.pelfInput.DepreciationRate = this.pelfInput.DepreciationRate / 100;

                var result = await post(pelfApi.fixedAsset.api, this.pelfInput)
                if (result.IsSuccess) {
                    this.$emit("hiddePolfDetail", true, this.$_MInformStatus.IsSucess, this.$_MResource.InformContent.Add);
                }

            } catch (error) {
                // this.showInform(true, this.$_MInformStatus.IsFailed, error.response.data.UserMessage)


            }
        },
        /**
        * Author:PXTRUONG(15/6/2023)
        * Thực hiện gọi api sửa tài sản 
        */
        async fix() {
           
            this.pelfInput.DepreciationRate = this.pelfInput.DepreciationRate / 100;
            try {
                var result = await put(pelfApi.fixedAsset.api, this.pelfInput)
                if (result.IsSuccess) {
                    this.$emit("hiddePolfDetail", true, this.$_MInformStatus.IsSucess, this.$_MResource.InformContent.Fixed);
                }

            } catch (error) {
                this.showInform(true, this.$_MInformStatus.IsFailed, error.response.data.UserMessage)
                console.log(error);
            }

        },
        /**
        * Author:PXTRUONG(19/6/2023)
        * Thực hiện đóng mở thông báo chuyền nội dung thông báo 
        */
        showInform(isShow, informStatus, content) {
            this.isShowInform = isShow;
            this.informStatus = informStatus;
            this.informContent = content;
            setTimeout(() => this.isShowInform = false, 4000);
        },
        /**
         * Author:PXTRUONG(31/5/2023)
         * Thực hiện lưu và đóng form 
         */
        async btnSave() {
            // this.btnClose();
            try {
                this.isCheckValidate = true;
                for (const inputRef in this.$refs) {

                    //tìm các input invalid
                    if (this.checkNull(this.$refs[inputRef].value)) {
                        this.inValue = true;

                        this.$refs[inputRef].focus()

                        return;
                    }
                }

                // console.log(this.$refs["PurchaseDate"]);
                if (this.formMode == this.$_MFormMode.FixAsset) {
                    this.fix();
                }
                else if (this.formMode == this.$_MFormMode.AddAsset) {
                    this.add();
                }
            } catch (error) {
                console.log(error);
            }



        },
     
        /**
         * Author:PXTRUONG(31/5/2023)
         * Đống form và không lưu lại dữ liệu 
         */
        btnCloseUnSave() {
                if (this.formMode == this.$_MFormMode.FixAsset) {
                    this.statusAlert = this.$_MStatusAlert.IsFixAsset;
                    this.alertContent = null;
                    this.inValue = false;
                    this.isShowAlert = true;
                }
                else if (this.formMode == this.$_MFormMode.AddAsset) {
                    this.statusAlert = this.$_MStatusAlert.IsAddFixAsset;
                    this.alertContent = null;
                    this.inValue = false;
                    this.isShowAlert = true;
                }

            


            // this.$emit("update:pelf", this.pelftDefault);


        },
        /**
         * 
         * Author:PXTRUONG(31/5/2023)
         * thay đổi dữ liệu phụ thuộc khi thay đổi mã tài sản,loại tài sản 
         */
        async bindData(api, value, protext) {
            try {
                var result = await getByCode(api, value);
                result.forEach(element => {
                    if (protext == "DepartmentCode") {
                        this.pelfInput.DepartmentName = element.DepartmentName;
                        this.pelfInput.DepartmentID = element.DepartmentID;
                    }
                    else if (protext == "FixedAssetCategoryCode") {
                        this.pelfInput.FixedAssetCategoryName = element.FixedAssetCategoryName;
                        this.pelfInput.DepreciationRate = element.DepreciationRate;
                        this.pelfInput.ProductionYear = element.ProductionYear;
                        this.pelfInput.FixedAssetCategoryID = element.FixedAssetCategoryID;
                    }
                });
                console.log(result);
            } catch (error) {
                throw error
            }

        }

    },
    data() {
        return {
            pelfInput: {},
            pelftDefault: {},
            listDepartment: [],
            popupTitle: null,
            atrophyYear: null,
            department: [],
            fixedAssetCategory: [],
            data: {},
            IsAllow: false,
            isCheckValidate: false,
            listInValue: [],
            isShowAlert: false,
            statusAlert: null,
            alertContent: null,
            inValue: false,
            informStatus: null,
            isShowInform: false,
            informContent: null,
            isFirstFocus: false
        }
    },
}
</script>
<style>
@import url(../../../style/base/popup.css);
@import url(../../../style/base/textfield.css);
@import url(../../../style/base/icon.css);
</style>