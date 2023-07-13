<template>
    <div class="body__content">

        <table class="table__content" >
            <thead class="table__header">

                <th class="  th__checkbox table__Maxwidth stay--left">

                    <input type="checkbox" class="input__checkbox input__checkbox--icon" v-model="ischeckall"
                        @click="checkAll">


                </th>
              
                <th v-for="(item) in this.$_MResource.tableTitle " :key="item" :title="item.title"
                    :class="{ 'text--right': item.type == 'number', 'text--center': item.value == this.$_MResource.tableTitle.STT.value, 
                    'stay--left': item.value == this.$_MResource.tableTitle.Action.value }">
                        {{ item.value }}
                </th>


            </thead>

            <tbody v-if="this.renderComponent" >
             
                <tr v-for="(item, index) in listData" :key="item.FixedAssetCode"
                    :class="{ 'table__bgr--sellect': this.chekedList(item.FixedAssetCode, index) }">

                    <td>
                        <input class=" input__checkbox input__checkbox--icon" type="checkbox" v-model="listChecked"
                            :value="item.FixedAssetCode">

                    </td>
                    <td @click="selectItem(index, item.FixedAssetCode, $event)" class="text--center"
                        :style="[`width:${this.thu}px`]">
                        {{ index + 1 }}
                    </td>
                    <td v-for="(itemindex) in this.$_MResource.assetTitle " :key="itemindex" @dblclick="showPeltDetail(item)"
                        @click="selectItem(index, item.FixedAssetCode, $event)" @mousedown.right="showContextMenu(item)"
                        :class="{ 'text--right': itemindex.type == 'number' }" :style="[`width:${this.setWidth[index]}`]" 
                       v-tooltip="item[itemindex.key]"
                        >
                        <template v-if="itemindex.type == 'number'"   >
                            {{

                                this.formatMoney(item[itemindex.key])
                            }}
                        </template>
                        <template v-if="itemindex.type != 'number'">
                            {{
                                item[itemindex.key]
                            }}
                        </template>
                    </td>
                    <td class="text--right" @click="selectItem(index, item.FixedAssetCode, $event)" @mousedown.right="showContextMenu(item)">
                        {{ this.formatMoney(accumulate(item.AtrophyYear, item.TrackedYear)) }}
                    </td>
                    <td class="text--right" @click="selectItem(index, item.FixedAssetCode, $event)" @mousedown.right="showContextMenu(item)">
                        {{ this.formatMoney(item.Cost * item.Quantity - accumulate(item.AtrophyYear, item.TrackedYear)) }}
                    </td>

                    <td class="stay--left" :class="{ 'table__sellected': this.chekedList(item.FixedAssetCode, index) }">
                        <div class=" table__body--display">
                            <div class="icon body__table__icon--pencal" @click="showPeltDetail(item)" title="Chỉnh sửa">
                            </div>
                            <div class="icon body__table__icon--duplicate" title="Nhân bản" @click="showDuplicate(item)"></div>
                        </div>
                    </td>

                </tr>
                <div>
                </div>
            </tbody>


            <td colspan="13" v-if="isNull" class="table__nulvalue"> </td>

            <td colspan="13" v-if="isReload && !isNull" class="table__loading--container">
                <div class="table__loading" :class="{ 'roate': this.isReload }">

                </div>
            </td>

          
            <tfoot class="table__footer ">
                <tr>
                    <td colspan="6">
                    </td>
                    <td class="text--right table__footer__font--bold">
                        {{ this.formatMoney(this.sumeryQuantity) }}
                    </td>
                    <td class="text--right table__footer__font--bold">
                        {{ this.formatMoney(this.sumeryCost) }}
                    </td>
                    <td class="text--right table__footer__font--bold">
                        {{ this.formatMoney(this.sumeryAccumulated) }}
                    </td>
                    <td class="text--right table__footer__font--bold">
                        {{ this.formatMoney(this.sumeryOtherValue) }}
                    </td>
                    <td>

                    </td>
                </tr>
            </tfoot>


        </table>
        <m-paging :totalRecordProp="this.totalRecord" :keyWord="this.keyWordInput" @sendData="bindDate"
            :isCallApi="this.isDeleteSucess"></m-paging>
    </div>

    <div :style="[`top:${this.pageY}px; left:${this.pageX}px;`]" class="contextmenu__container" v-if="isShowMenuContext">
        <m-context-menu> </m-context-menu>
    </div>
</template>
<script>
import pelfApi from '@/config/pelf/pelfapi';
import format from '@/js/format/format';
import resource from '@/js/resource/resource';
import MCheckBox from '@/components/base/MCheckBox.vue';
import MDropdown from '@/components/base/MDropdown.vue';
import MPaging from '@/components/base/MPaging.vue';
import MContextMenu from '@/components/base/MContextMenu.vue';
import { getpaging, get } from '@/js/services/sendrequest';
export default {
    components: {
        MCheckBox,
        MDropdown,
        MPaging,
        MContextMenu
    },

    created() {
        // this.loadData();
        this.$eventBus.on("contextMenuStatus", (data) => {
            this.contextMenuStatus = data;
        });
        this.$eventBus.on("isShowcontextMenuStatus", (data) => {
            this.isShowMenuContext = data;
        });
        this.$eventBus.on("isReload", (data) => {
            this.isReload = data;
        });
        this.sumeryFixedAsset();

    },
    watch: {
        isReload: function (newValue) {
            if (newValue) {
                this.renderComponent = false;
            }
            else {
                this.renderComponent = true;
                this.sumeryFixedAsset();
            }

        },
        contextMenuStatus: function (newValue) {
            this.actionContextMenu(newValue);
        },
        listChecked: function (newValue) {

            this.$eventBus.emit("listCodeDelete", newValue);
        },
        isDeleteSucess: function (newValue) {
            if (newValue == true) {
                this.listChecked.forEach(element => {
                    this.listData.forEach(elementData => {
                        if (element == elementData.FixedAssetCode) {
                            this.listData.splice(this.data.indexOf(elementData), 1)
                        }
                    });
                });

            }

            this.$emit("restartDeleteStatus");
        },
        listData: function (newValue) {

            if (newValue.length > 0) {
                this.isNull = false
            }
            else {
                this.isNull = true
            }
        }
    },
    props: {
        isDeleteSucess: Boolean,
    },

    methods: {
        resetwidth(event) {
            if (this.isResize) {
                var currentWidth = event.pageX;
                var width = currentWidth - this.firstWidth;
                this.thu = width;
                console.log(this.thu);
            }


        },
        /**
         * Author:PXTRUONG(7/1/2023)
         * Resize lại độ rộng cột table
         */
        resizewidth(index, event) {
            if (this.isResize) {
                this.isResize = false;
            }
            else {
                this.isResize = true;
                this.firstWidth = event.pageX;
                console.log(this.firstWidth);
            }

            // if(event.mousemove){

            // }
        },
        /**
        * Author:PXTRUONG(27/6/2023)
        * hàm tính hao mòn lũy kế 
        */
        accumulate(AtrophyYear, trackYear) {
            var result;
            var now = new Date();
            var nowYear = now.getFullYear();

            result = (AtrophyYear) * (nowYear - trackYear);
            return result;
        },
        /**
         * Author:PXTRUONG(27/6/2023)
         * Tính tổng nguyên giá, số lượng, lúy kế,giá tị còn lại 
         */
        async sumeryFixedAsset() {
            try {
                var result = await get(pelfApi.fixedAsset.sumery);
                this.sumeryQuantity = result.data.TotalQuantity;
                this.sumeryCost = result.data.TotalCost;
                this.sumeryAccumulated = result.data.TotalAccumulate;
                this.sumeryOtherValue = result.data.Total;

            } catch (error) {
                console.log(error);
            }

        },
        /**
         * Author:PXTRUONG(25/6/2023)
         * Thực hiện chức năng của context theo trạng thái action
         * @param {trạng thái muốn thực hiên:thêm,sửa.xóa} status 
         */
        actionContextMenu(status) {
            switch (status) {
                // case this.$_MContextStatus.IsAdd:
                //     console.log("thêm");
                //     break;
                case this.$_MContextStatus.IsDelete:
                    this.listChecked = [];
                    this.listChecked.push(this.peltSellected.FixedAssetCode);
                    this.$eventBus.emit("listCodeDelete", this.listChecked);

                    this.isShowMenuContext = false;
                    break;
                case this.$_MContextStatus.IsFixed:

                    this.$emit("showDetail", this.peltSellected, this.$_MFormMode.FixAsset);
                    this.$eventBus.emit("contextMenuStatus", null);
                    this.isShowMenuContext = false;
                    break;
                case this.$_MContextStatus.IsDuplicate:
                    this.$emit("showDetail", this.peltSellected, this.$_MFormMode.AddAsset);
                    this.$eventBus.emit("contextMenuStatus", null);
                    this.isShowMenuContext = false;
                    break;



            }
        },
        /**
         * Author:PXTRUONG(2/7/2023)
         * Thực hiện nhân bản 
         */
        showDuplicate(selectpelt){
            this.$emit("showDetail", selectpelt, this.$_MFormMode.AddAsset);
        },
        /**
         * Author:PXTRUONG(25/6/2023)
         * Đóng mở contextMenu
         */
        showContextMenu(item) {
            window.oncontextmenu = function (e) {
                // Cancel the event
                e.preventDefault();

            };


            if (!this.isShowMenuContext) {

                this.peltSellected = item;
                this.pageX = event.pageX;
                this.pageY = event.pageY + 15;

                this.isShowMenuContext = true;
            }
            else {
                this.isShowMenuContext = false;

            }

        },

        /**
         * Author:PXTRUONG(24/6/2023)
         * tìm các mã nhân viên có trong 1 trang 
         */
        findFixedAssetCode() {
            var data = [];
            this.listData.forEach(element => {
                data.push(element.FixedAssetCode);

            });

            return data;
        },
        /**
         * Author:PXTRUONG(22/6/2023
         * Thực hiện check tất cả 
         */
        checkAll() {
            if (this.ischeckall == true) {

                this.listChecked = this.listChecked.filter(item => !this.findFixedAssetCode().includes(item));


            }
            else {
                this.listChecked = this.findFixedAssetCode();

            }

            // return listChecked;
        },
        /**
         * Author:PXTRUONG(21/6/2023)
         * Chuyền dữ liệu sau khi phan trang 
         */
        bindDate(data) {
            this.listData = data;
        },
        /**
        * Load dữ liệu từ api cho vào bảng
        * Author:Phùng Xuân Trường
        * 24/2/2023
        */
        async loadData() {
            try {

                var result = await getpaging(pelfApi.fixedAsset.getPaging, 10, 1, "", "", "");
                this.listData = result.data;
                this.$eventBus.emit("isReload", false);
                this.totalRecord = result.data[0].TotalRecord;

            } catch (error) {
                console.log(error);
            }

        },
        /**
         * Author:PXTRUONG(15/6/2023)
         * Kiểm tra mã có trong list được tích hay không
         */
        chekedList(data, index) {
            if (this.listChecked.includes(data)) {
                return true
            }
            else if (index == this.indexSelected) {

                return true
            }
            else {
                return false
            }
        },
        /**
         * Author:PXTRUONG(15/6/2023)
         * Đổi màu khi click chọn
         */
        selectItem(index, data, event) {
            try {
                this.isShowMenuContext = false;
                let item = []
                item.push(data);
               
                //bắt sự kiện nút ctrl
                if (event.ctrlKey) {
                    if (!this.listChecked.includes(data)) {
                        this.listChecked.push(data);
                    }
                    else {
                        this.listChecked = this.listChecked.filter(item => item != data);
                    }

                }
                //bắt sự kiện nút shift
                else if (event.shiftKey) {
                    var lastSelect = index + 1;
                    var list = [];
                    if (lastSelect <= this.firstSellect) {
                        list = this.listData.slice(lastSelect - 1, this.firstSellect + 1);
                    }
                    else {
                        list = this.listData.slice(this.firstSellect, lastSelect);
                    }
                    let listDelete = []
                    list.forEach(element => {
                        listDelete.push(element.FixedAssetCode);
                    });
                    this.listChecked = listDelete;
                }
                //chọn khi chưa có đối tượng nào được chon
                else if (this.listChecked.length == 0) {
                    this.firstSellect = index;
                    this.listChecked.push(data);
                }
                //thực hiện uncheck khi nhấn lại đối tượng đó 1 lần nữa 
                else if (this.listChecked.length == 1 && this.listChecked.includes(data)) {
                    this.listChecked = []
                }
                //chọn đối tượng khác 
                else if (this.listChecked.length == 1 && !this.listChecked.includes(data)) {
                    this.firstSellect = index;
                    let item = []
                    item.push(data);
                    this.listChecked = item;
                }
                else {
                    this.firstSellect = index;
                    let item = []
                    item.push(data);
                    this.listChecked = item;
                }

                this.$eventBus.emit("listCodeDelete", this.listChecked);
            } catch (error) {
                throw error;
            }

        },
        /**
         * Author:PXTRUONG, Create: 27/5/2023
         * gọi hàm format tiền
         */
        formatMoney(money) {
            return format.fomatmoney(money)
        },
        /**
         * Author:PXTRUONG, Create: 27/5/2023
         * hiện sửa 
         */
        showPeltDetail(data) {

            this.$emit("showDetail", data, this.$_MFormMode.FixAsset);

        }
    },
    data() {
        return {
            peltSellected: null,
            data: [],
            tableLabel: resource.tableTitle,
            listChecked: [],
            listData: [],
            indexSelected: null,
            renderComponent: true,
            isNull: false,
            listPage: [
                {
                    "PageNumber": "20"
                },
                {
                    "PageNumber": "30"
                },
                {
                    "PageNumber": "40"
                },
                {
                    "PageNumber": "50"
                }
            ],
            setWidth: [],
            totalRecord: null,
            keyWordInput: null,
            startXMouse: null,
            ischeckall: false,
            firstSellect: null,
            pageX: null,
            pageY: null,
            isShowMenuContext: false,
            contextMenuStatus: null,
            sumeryQuantity: null,
            sumeryCost: null,
            sumeryAccumulated: null,
            sumeryOtherValue: null,
            isReload: Boolean,
            isChange: false,
            firstWidth: null,
            thu: 30,
            isResize: false
        }
    },
}
</script>
<style scoped>
@import url(../../../style/base/textfield.css);
@import url(../../../style/base/icon.css);
@import url(../../../style/base/button.css);
@import url(../../../style/base/table.css);

.contextmenu__container {
    position: fixed;
}
</style>