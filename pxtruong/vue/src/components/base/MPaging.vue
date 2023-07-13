<template>
    <div class="table__footer--container">
        <div class="table__footer--left">
            <div>
                <p class="table__footer__font--regular">
                    Tổng số : <span class="table__footer__font--bold"> {{ this.totalRecordInput }}</span> bản ghi
                </p>
            </div>

            <div class="table__footer--containerbutton">
                <m-dropdown :is-show-error="false" :is-up="true" :list-data-input="listPage" prop-text="PageNumber"
                    v-model="this.pageSizeInput" :isDisable="true"></m-dropdown>
            </div>
            <div class="   tfoot__paging">
                <div class="icon tfoot__paging--iconarrowleft" @click="prev"  :class="{'unset':this.selectPageNumber==1}">

                </div>
                <div class="tfoot__paging--content">

                    <div v-for="(item, index) in this.arraypagenumber" :key="index" class=" bunttonPage">
                        <button class="button_paging" :class="{ 'button__paging--selected': this.selectPageNumber == item }"
                            @click="paging(item,index)">{{ item
                            }}</button>
                    </div>



                </div>
                <div class=" icon tfoot__paging--iconarrowright" @click="after"  :class="{'unset':this.selectPageNumber==this.totalPageNumber}">

                </div>

            </div>

        </div>

    </div>
</template>
<script>
import MDropdown from '@/components/base/MDropdown.vue';
import pelfApi from '@/config/pelf/pelfapi';
import { debounce } from "lodash";
import value from '@/js/enum/value';
import { getpaging } from '@/js/services/sendrequest';
export default {
    components: {
        MDropdown
    },
    props: {
        totalRecordProp: null,
        defaultPageNumber: null,
        isCallApi: false
    },

    created() {
        this.totalRecordInput = this.totalRecordProp;
        this.pageSizeInput = value.pageSizeDefault;
        this.pageNumber();
        this.$eventBus.on("dataSearch", (data) => {
            this.keyWord = data
        });
        this.$eventBus.on("FixedAssetCategoryName", (data) => {
            this.categoryName = data
        });
        this.$eventBus.on("DepartmentName", (data) => {
            this.departmentName = data
        });
        this.$eventBus.on("isFixed", (data) => {
            this.isFixed = data;
        });
        this.$eventBus.on("isReload", (data) => {
            this.isReload = data;
        });
        this.$eventBus.on("isChange", (data) => {
            this.isChange = data;
        });
        this.debouncedWatch = debounce((newValue, oldValue) => {
            this.paging(value.pageNumberDefaultValue)
        }, 1000);

    }, 
    beforeUnmount() {
        this.debouncedWatch.cancel();
    },

    watch: {
        isReload: function (newValue) {
            if (newValue) {
                
                if(this.isChange){

                    this.paging(value.pageNumberDefaultValue)
                    this.$eventBus.emit("isChange", false);
                }
            }
            else {
                this.isReload=false
            }

        },
        isCallApi: function (newValue) {
            if (newValue) {
                this.paging(value.pageNumberDefaultValue);
            }
        },
        pageSizeInput: function (newValue) {

            this.pageNumber();
            this.arraypagenumber = []
            this.showlistpages();
            this.paging(value.pageNumberDefaultValue);
        },
        totalRecordProp: function (newValue) {
            this.totalRecordInput = this.totalRecordProp;
        },
        keyWord: function (newValue) {
            this.$eventBus.emit("isReload", true);
            this.debouncedWatch()
        },
        categoryName: function (newValue) {
            this.$eventBus.emit("isReload", true);
            this.debouncedWatch();
        },
        departmentName: function (newValue) {
            this.$eventBus.emit("isReload", true);
            this.debouncedWatch()
        },
        totalRecordInput: function () {

            this.pageNumber();
            this.arraypagenumber = []
            this.showlistpages();
        },
        selectPageNumber: function (newValue) {
            this.$eventBus.emit("selectPageNumber", newValue);
            this.arraypagenumber = []
            this.showlistpages();
        },
        isFixed:function(newValue){
                if(newValue){
                    this.paging(this.selectPageNumber)
                    this.$eventBus.emit("isFixed", false);
                }
        }
    },

    methods: {
        /**
         * Author:PXTRUONG(20/6/2023)
        * thực hiện chuyển trang sang trái 
        */
        prev() {
            if (this.selectPageNumber == 1) {
                return;

            }
            this.selectPageNumber = this.selectPageNumber - 1;
            this.paging(this.selectPageNumber);

        },
        /**
         * Author:PXTRUONG(20/6/2023)
         * thực hiện chuuyeenr trang sang phải 
         */
        after() {

            if (this.selectPageNumber == this.totalPageNumber) {
                return;

            }
            this.selectPageNumber = this.selectPageNumber + 1;
            this.paging(this.selectPageNumber);
        },

        /**
         * Author:PXTRUONG(20/6/2023)
         * Thực hiện tính số trang 
         */
        pageNumber() {
           
            if (this.totalRecordInput % this.pageSizeInput == 0) {
                this.totalPageNumber = this.totalRecordInput / this.pageSizeInput;
            }
            else {
                this.totalPageNumber = Math.floor(this.totalRecordInput / this.pageSizeInput) + 1;
            }
            
        },
        /**
         * Author:PXTRUONG(20/6/2023)
        * tính toán để hiển thị danh sách trang  trang 
        */
        showlistpages() {

            for (let i = 1; i <= this.totalPageNumber; i++) {
                if (i == 1 || i == this.totalPageNumber || (i <= this.selectPageNumber + 2 && i >= this.selectPageNumber - 2)) {
                    this.arraypagenumber.push(i);
                }
                else if (i == this.selectPageNumber + 3 || i == this.selectPageNumber - 3) {
                    this.arraypagenumber.push("...")
                }

            }


        },
        /**
         * Author:PXTRUONG(20/6/2023)
         * Thực hiện phân trang 
         */
        async paging(pageNumber,index) {

            
            this.selectPageNumber = pageNumber;
            try {
                if(pageNumber=="..."){
                    this.selectPageNumber=index;
                    pageNumber=index;
                    
                }
                var result = await getpaging(pelfApi.fixedAsset.getPaging, this.pageSizeInput, pageNumber, this.keyWord, this.departmentName, this.categoryName);
              
                if (result.IsSuccess) {
                             this.$eventBus.emit("isReload", false);
                            this.totalRecordInput = result.data[0].TotalRecord;
                            this.listData = result.data;
                }
                else {
                         this.listData = [];
                         this.totalRecordInput =value.rezoValue ;
                }
               
                this.$emit("sendData", this.listData)
            } catch (error) {
                    console.log(error);
            }

        }
    },
    data() {
        return {
            listPage: [
                {
                    "PageNumber": "10"
                },
                {
                    "PageNumber": "20"
                },
                {
                    "PageNumber": "30"
                },
                {
                    "PageNumber": "50"
                },
                {
                    "PageNumber": "100"
                }
            ],
            pageSizeInput: {
                type: Number,
                default: 5
            },
            listData: [],
            pageNumberInput: null,
            totalRecordInput: null,
            totalPageNumber: null,
            value: null,
            arraypagenumber: [],
            keyWord: "",
            categoryName: "",
            departmentName: " ",
            selectPageNumber: null,
            isLoading:Boolean,
            isFixed:false,
            isReload: Boolean,
            isChange: false


        }
    },
}
</script>
<style scoped>
@import url(../../style/view/paging.css);
</style>