<template>
    <div class="manu" :class="{ 'menu__smaleSize': isSmaleSize }">
        <div class="manu__header">
            <div class="  manu__header--icon" :class="{'header__icon--samleSize':isSmaleSize}"></div>
            <div class="manu__header--content" v-if="isBigSize">MISA QLTS</div>
        </div>
        <div class="manu__content" v-if="isBigSize">
            <router-link to="/OverviewVue" >
                <m-item-menu icon="manu__content__icon--overview" :isArrowDown="false" itemContent="Tổng quan">
                </m-item-menu>
            </router-link>
            <router-link to="/PelfBody">
                <m-item-menu icon="manu__content__icon--asset" :isArrowDown="true" itemContent="Tài sản ">
                </m-item-menu>
            </router-link>
            <m-item-menu icon="manu__content__icon--assetHHĐB" :isArrowDown="true" itemContent="Tài sản HT-ĐB ">
            </m-item-menu>
            <m-item-menu icon="manu__content__icon--tool" :isArrowDown="true" itemContent="Công cụ dụng cụ ">
            </m-item-menu>
            <m-item-menu icon="manu__content__icon--category" :isArrowDown="false" itemContent="Danh mục">
            </m-item-menu>
            <m-item-menu icon="manu__content__icon--search" :isArrowDown="true" itemContent="Tra cứu ">
            </m-item-menu>
            <m-item-menu icon="manu__content__icon--iform" :isArrowDown="true" itemContent="Báo cáo ">
            </m-item-menu>
        </div>
        <div class="manu__content" v-if="isSmaleSize">
            <m-item-menu icon="manu__content__icon--overview">
            </m-item-menu>
            <m-item-menu icon="manu__content__icon--asset">
            </m-item-menu>
            <m-item-menu icon="manu__content__icon--assetHHĐB">
            </m-item-menu>
            <m-item-menu icon="manu__content__icon--tool">
            </m-item-menu>
            <m-item-menu icon="manu__content__icon--category">
            </m-item-menu>
            <m-item-menu icon="manu__content__icon--search">
            </m-item-menu>
            <m-item-menu icon="manu__content__icon--iform">
            </m-item-menu>
        </div>
        <div class="manu__footer">
            <div :class="{ 'icon manu__footer--icon': isBigSize }" @click="reSize">
            </div>
            <div :class="{ 'icon manu__footer--iconArrow': isSmaleSize }" @click="reSize">
            </div>
        </div>


    </div>
</template>
<script>
import MItemMenu from '../base/MItemMenu.vue';
export default {
    components: {
        MItemMenu
    },
    methods: {
        /**
         * Author:PXTRUONG, Created: 28/05/2023
         * Phóng to thu nhỏ menu
         */
        reSize() {
            if (this.isSmaleSize == true) {
                this.isSmaleSize = false;
                this.isBigSize = true;
                this.$eventBus.emit("isResize", this.isSmaleSize);
            }
            else {
                this.isSmaleSize = true;
                this.isBigSize = false;
                this.$eventBus.emit("isResize", this.isSmaleSize);
            }

        }
    },
    data() {
        return {
            isSmaleSize: false,
            isBigSize: true

        }
    },

}
</script>
<style>
@import url(../../style/base/icon.css);
@import url(../../style/layout/menu.css);

.menu__smaleSize {
    width: unset;
    align-items: center;
}

.menu__smaleSize div div {
    display: flex;
    justify-content: center;
}
</style>