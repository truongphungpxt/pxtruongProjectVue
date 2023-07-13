<template>
    <div class="body" :class="{ 'resize__body': isResize }">
        <div class="body__header">
            <div class="body__header--left">


                <div class="body__header--leftcontainer">
                    <div class="icon body__icon--search"> </div>
                    <input class="input__field  input__padding--30px " v-model="dataSearch" placeholder="Tìm kiếm tài sản ">
                </div>
                <div class="body__header--leftcontainer">
                    <m-dropdown icon-dropdown="body__icon--filter" :is-show-error="false"
                        :api=this.$_MApi.fixedAssetCategory.api prop-text="FixedAssetCategoryName"
                        :set-max-length="this.$_MMaxLengthInput.Nameother" :title="this.$_MResource.placeholder.categoryName"
                        ></m-dropdown>
                </div>
                <div class="body__header--leftcontainer">
                    <m-dropdown icon-dropdown="body__icon--filter" :is-show-error="false" :api=this.$_MApi.department.api
                        prop-text="DepartmentName" :title="this.$_MResource.placeholder.DepartmentName"
                        :set-max-length="this.$_MMaxLengthInput.Nameother"></m-dropdown>
                </div>
            </div>
            <div class="body__header--right">
                <button class=" button button--blue button__icon button__icon--plus"
                    @click="showPelfDetail({}, this.$_MFormMode.AddAsset)">
                    Thêm tài sản
                </button>
                <a :href="pelfBodyApi.fixedAsset.exportExcel">
                    <div class="icon body__header--iconexcel icon__boxshadow" title="Xuất excel"> </div>
                </a>

                <div class="icon body__header--icondelete icon__boxshadow" title="Xóa hết " @click="showDeleteMuntiple">
                </div>
            </div>
        </div>

        <list-pelf @showDetail="showPelfDetail" :is-delete-sucess="this.isDeleteStatus"
            @restartDeleteStatus="this.isDeleteStatus = false"></list-pelf>
    </div>
    <m-alert v-if="isShowAlert" :is-delete="true" :list-delete="this.listDelete" @close="closeAlert">

    </m-alert>
    <pelf-detail v-if="this.isShow" @hiddePolfDetail="closePelfDetail" :pelf="this.pelfDetail" :formMode="this.fromMode" @showInform="thu">
    </pelf-detail>
    <m-notification :informStatus="this.informStatus" v-if="this.isShowInform"
        :informContent="this.informContent"></m-notification>
</template>
<script>
import PelfDetail from '../../view/pelf/PelfDetail.vue';
import pelfApi from '@/config/pelf/pelfapi';
import ListPelf from '../../view/pelf/ListPelf.vue';
import MDropdown from '@/components/base/MDropdown.vue';
import MAlert from '@/components/base/MAlert.vue';
import MNotification from '@/components/base/MNotification.vue';
import { deleteRecord } from '@/js/services/sendrequest';

export default {
   
    components: {
        PelfDetail,
        ListPelf,
        MDropdown,
        MAlert,
        MNotification

    },
    watch: {
        dataSearch: function (newValue) {
            this.$eventBus.emit("dataSearch", newValue);
        },
        contextMenuStatus: function (newValue) {
            this.actionContextMenu(newValue);
        },
        listDelete: function (newValue) {
            if (newValue.length == 1 && this.contextMenuStatus != null) {

                this.showDeleteMuntiple();
                this.$eventBus.emit("contextMenuStatus", null);
            }

        },
        isShowInform: function (newValue) {
            if (newValue) {
                var message;
                this.$eventBus.on("ToastMessage", (data) => {
                    message = data;
                });
                console.log(message);
                this.showInform(newValue, this.$_MInformStatus.IsFailed, message)
            }
        }
    },
    created() {
        this.$eventBus.on("isResize", (data) => {
            this.isResize = data
        });
        //lấy danh sách cần xóa 
        this.$eventBus.on("listCodeDelete", (data) => {
            this.listDelete = data;
        });

        this.$eventBus.on("contextMenuStatus", (data) => {
            this.contextMenuStatus = data;
        });
        // app.config.globalProperties.$bus.on("isShowToast", (data) => {
        //     console.log(data);
        //     this.isShowInform = data;
        // });

    },
    // computed: {
    //     toast() {
    //         console.log(store.state.toast);
    //         return store.state.toast
    //     }
    // },

    methods: {
        thu(){
            console.log("ok");
        },
        /**
        * Author:PXTRUONG(25/6/2023)
        * Thực hiện chức năng của context theo trạng thái action
        * @param {trạng thái muốn thực hiên:thêm,sửa.xóa} status 
        */
        actionContextMenu(status) {
            switch (status) {
                case this.$_MContextStatus.IsAdd:
                    this.showPelfDetail({}, this.$_MFormMode.AddAsset)
                    this.$eventBus.emit("contextMenuStatus", null);
                    this.$eventBus.emit("isShowcontextMenuStatus", false);
                    break;
            }
        },

        /**
         * đóng cảnh báo  
         * thực hiện xóa nhiều 
         * Author:PXTRUONG(24/05/2023)
         */
        async closeAlert(isAllowDelete) {
            try {
                var listData = [];

                if (isAllowDelete) {


                    this.listDelete.forEach(element => {
                        listData.push({ "recodecode": element })
                    });
                    listData = JSON.stringify(listData);
                    var result = await deleteRecord(pelfApi.fixedAsset.api, listData)
                    if (result.IsSuccess) {
                        this.isDeleteStatus = true
                        this.isShowAlert = false
                        this.showInform(result.IsSuccess, this.$_MInformStatus.IsSucess, this.$_MResource.InformContent.DeleteSucess)
                        this.$eventBus.emit("isReload", true);
                        this.$eventBus.emit("isChange", true);
                    }


                }
                this.isShowAlert = false
            } catch (error) {
            
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
            setTimeout(() => this.isShowInform = false, this.$eventBus.emit("isShowToast", false), 4000);
           
        },
        /**
          * hiện chi tiết tài sản 
          * Author:PXTRUONG(24/05/2023)
          */
        showPelfDetail(data, formMode) {
            this.fromMode = formMode
            this.pelfDetail = data;
            this.isShow = true;
        },
        /**
         * đóng chi tiết tài sản 
         * Author:PXTRUONG(24/05/2023)
         */
        closePelfDetail(showInform, result, content) {
            if (showInform) {
                if (content == this.$_MResource.InformContent.Add) {
                    this.$eventBus.emit("isReload", true);
                    this.$eventBus.emit("isChange", true);
                }
                else if (content == this.$_MResource.InformContent.Fixed) {
                    this.$eventBus.emit("isReload", true);
                    this.$eventBus.emit("isFixed", true);
                }
                this.showInform(showInform, result, content);
            }
            this.isShow = false;
        },
        /**
         * Author:PXTRUONG(6/6/2023)
         * thực hiện xóa nhiều 
         */
        showDeleteMuntiple() {
            this.isShowAlert = true
        }
    },
    data() {
        return {
            dataInput: [],
            isShow: false,
            pelfDetail: null,
            isResize: false,
            listDelete: [],
            isShowAlert: false,
            fromMode: null,
            informStatus: null,
            isShowInform: false,
            informContent: null,
            isDeleteStatus: Boolean,
            dataSearch: null,
            contextMenuStatus: null,
            pelfBodyApi: pelfApi,


        }
    },
}
</script>
<style scoped>
@import url(../../../style/base/textfield.css);
@import url(../../../style/base/icon.css);
@import url(../../../style/base/button.css);
@import url(../../../style/base/table.css);

.resize__body {
    width: calc(100% - 68px);
}
</style>