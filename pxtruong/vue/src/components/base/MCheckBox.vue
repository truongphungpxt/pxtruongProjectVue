<template>
    <input class=" input__checkbox--icon" type="checkbox" v-model="listCheckboxSellected" :value="this.checkboxValue" >
</template>
<script>
export default {
    props: {
        checkboxValue: null,
        modelValue: null,
        
    },
    created() {
        this.listCheckboxSellected= this.modelValue;
    },
    watch: {
        listCheckboxSellected: function (newValue) {
        
            this.$emit("update:modelValue",newValue);
        }
    },
    data() {
        return {
            listCheckboxSellected: [],
            checkboxValueInput: null
        }
    },
}
</script>
<style scoped></style>