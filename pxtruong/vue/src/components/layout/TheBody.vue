<template>
   
       
   
        
        <router-view>
        </router-view>

   

  
</template>
<script>


export default {
    components:{
       
    },
    created() {
        this.$eventBus.on("isResize", (data) => {
          this.isResize = data
    });
       
    },
    

}

</script>
<style scoped>
@import url(../../style/layout/body.css);
@import url(../../style/base/textfield.css);
@import url(../../style/base/icon.css);
@import url(../../style/base/button.css);
@import url(../../style/base/table.css);

</style>