<template>
    <div class="header" :class="{'resize__header':isResize}">
        <div class="header__left">

            <p class="header__font--bold"> Danh sách tài sản </p>

        </div>
        <div class="header__right">
            <p class="header__font--regular">
                Sở tài chính
            </p>
            <div class=" header__button--year header__bgrcollor--blue">
                <p>
                    Năm
                </p>
                <p class="header__font--littlebold">
                    2021
                </p>
                <div class="icon header__button__icon">

                </div>
            </div>
            <div class="icon header__icon--notification  ">

            </div>
            <div class="icon header__icon--app ">

            </div>
            <div class="icon header__icon--help">

            </div>
        </div>
    </div>
</template>
<script>
export default{
    created() {
        this.$eventBus.on("isResize", (data) => {
          this.isResize = data
    });
    },
    data() {
        return {
            isResize:false
        }
    },
}
</script>
<style scoped>
@import url(../../style/base/icon.css);
@import url(../../style/base/textfield.css);
@import url(../../style/layout/header.css);
.resize__header{
  width: calc(100% - 98px);
}
</style>