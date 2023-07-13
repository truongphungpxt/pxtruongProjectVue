<template>
    <div class="contextmenu">
        <button class="button" @click="sendstatus(this.$_MContextStatus.IsAdd)"> Thêm</button>
        <button class="button" @click="sendstatus(this.$_MContextStatus. IsFixed )"> Sửa </button>
        <button class="button" @click="sendstatus(this.$_MContextStatus.IsDelete)"> Xóa</button>
        <button class="button" @click="sendstatus(this.$_MContextStatus.IsDuplicate)"> Nhân bản</button>
    </div>
</template>
<script>
export default {
   props:{
    
   },
   methods: {
    sendstatus(status){
            this.$eventBus.emit("contextMenuStatus", status);
    }
    
   },
    data() {
        return {
            contextMenuStatus:null
        }
    },
}
</script>
<style scoped>
@import url(../../style/base/contextmenu.css);
@import url(../../style/base/button.css);
</style>