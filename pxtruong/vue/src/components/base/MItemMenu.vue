<template>
    <div class="manu__content__container">
        <div class="menu__icon " :class="icon">

        </div>
        <div class="manu__content--right" v-if="this.itemContent">
            {{ this.itemContent }}
            <div class="icon manu__icon--arrowdown" v-if="this.isArrowDown"></div>
        </div>
    </div>
</template>
<script>
export default {
    props: {
        icon: null,
        isArrowDown: Boolean,
        itemContent: null,
        to: null
    }
}
</script>
<style>
@import url(../../style/base/icon.css);
@import url(../../style/layout/menu.css);
</style>