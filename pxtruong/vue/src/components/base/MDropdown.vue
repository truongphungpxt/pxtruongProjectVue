<template>
  <div class="input__container ">

    <p class="popup__font__label--name " v-if="inputContent">
      {{ inputContent }}<span v-if="isNotAllowNull" class="popup__color--red">*</span>
    </p>
    <!-- hiện input không có  icon -->
    <div class="mcombobox__container" v-if="!iconDropdown" @click="showClick" v-outside="clostab">

      <input class="input__field" type="text" v-model="this.value" :class="{ 'input__boder--red': isNull }"
        @blur="validate(this.value)" @input="filterIterms(this.value)" @keydown="kewdown" ref="Minput"
        :maxlength="setMaxLength" :disabled="isDisable" />

      <div class="mcombobox__icon--arrowdown  icon" @keydown.down="kewdown"></div>


      <div class="popup__error" v-if="isShowError">
        <div class="popup__color--red" v-if="isNull">
          {{ alertMsg }}
        </div>
      </div>

    </div>
    <!-- hiện input có icon -->
    <div class="mcombobox__container  " v-if="iconDropdown" v-outside="clostab">
      <div class="icon dropdown__icon--position " :class="iconDropdown" v-if="iconDropdown" @click="sortData"></div>
      <input class="input__field input__padding--30px" type="text" :class="{ 'input__boder--red': isNull }"
        v-model="this.value" @blur="validate(this.value)" @input="filterIterms(this.value)" @keydown="kewdown"
        @click="showClick" ref="Minput" :maxlength="setMaxLength"  :placeholder="title" />

      <div @click="showClick" class="mcombobox__icon--arrowdown  icon" @keydown.down="kewdown"></div>
      <div class="popup__error" v-if="isShowError">
        <div class="popup__color--red" v-if="isNull">
          {{ alertMsg }}
        </div>
      </div>

    </div>
    <!-- hiện list khi chọn khi nhập được nội dung  -->
    <div class="mcombobox__listd" v-show="isshow" :class="{ 'mcombobox__listed--up': isUp }" v-if="isDisable"
      ref="listDropdown">
      <div class="mcombobox__item" v-for="(item, index) in itermsFilter" :key="index" @click="onSelectItem(item)"
        :class="{ 'is--focus': item[propText] == this.value,  'is--sellected': item[propText] == this.valueSelected }">
        {{
          item[propText]
        }}
      </div>

      <div v-if="itermsFilter.length <= 0" class="mcombobox__item">
        không tìm thấy dữ liệu
      </div>


    </div>
    <!-- hiện list khi chọn theo diable -->
    <div class="mcombobox__listd" v-show="isshow" :class="{ 'mcombobox__listed--up': isUp }" v-if="!isDisable"
      ref="listDropdown">
      <div class="mcombobox__item" v-for="(item, index) in itermsFilter" :key="index" @click="onSelectItem(item)"
        :class="{ 'is--focus': item[propText] == this.value, 'is--sellected': item[propText] == this.valueSelected }">
        {{
          item[propText]
        }}
      </div>

      <div v-if="itermsFilter != null && itermsFilter.length <= 0" class="mcombobox__item">
        không tìm thấy dữ liệu
      </div>


    </div>


  </div>
</template>
<script>
import format from "@/js/format/format";
import { ElDropdown, timelineItemProps } from "element-plus";
import { ArrowDown } from "@element-plus/icons-vue";
import { get } from '@/js/services/sendrequest';
export default {
  components: {
    ElDropdown,
    ArrowDown,
  },
  props: {
    title:null,
    isDisable: false,
    inputContent: null,
    iconDropdown: null,
    isRequire: Boolean,
    isNotAllowNull: Boolean,
    propText: null,
    modelValue: null,
    api: null,
    isCheckValidate: {
      type: Boolean,
      default: false
    },
    isShowError: {
      type: Boolean,
      default: true
    },
    isUp: {
      type: Boolean,
      default: false
    },
    listDataInput: [],
    setMaxLength: null

  },
  watch: {
    modelValue: function (newValue) {
      this.value = newValue;
      
    },
    value: function (newValue) {
      if (this.checknull(newValue)) {
        this.valueSelected = newValue;
        
      }
      this.$emit("update:modelValue", newValue);
    },
    isCheckValidate: function (newValue) {
      if (newValue && this.isNotAllowNull) {
        this.validate(this.value)
      }
    }
  },
  created() {

    this.value = this.modelValue;
    this.valueSelected = this.modelValue;
   this.scrollToSelected();
    if (this.api) {
      this.loaddata(this.api);
    }
    if (this.listDataInput) {
      this.itermsFilter = this.listDataInput;
      this.origilData = this.listDataInput;

    }



  },
  data() {
    return {
      isshow: false,
      nowindex: 0,
      value: null,
      valueSelected: null,
      isNull: false,
      alertMsg: null,
      itermsFilter: [],
      origilData: [],
      listData: [],
      indexSelected: 0,
      isNotFound: false,
      maxLength: null,
      maxLengthDefault: null,

    }
  },
  methods: {
    /**
     * Author:PXTRUONG(11/7/2023)
     * Thực hiện thanh scroll ăn theo value được chọn 
     */
    scrollToSelected() {
      var list = this.$refs["listDropdown"];
      var selectedEl;
      let index = this.itermsFilter.findIndex((item) => item[this.propText] == this.valueSelected);
      if (list && index > 0) {
         selectedEl = list.children[index];

        if (selectedEl) {
          const listRect = list.getBoundingClientRect();
          const selectedRect = selectedEl.getBoundingClientRect();
          // Tính trung tâm của phần tử được chọn
          const selectedCenter = selectedRect.top + selectedRect.height / 2;

          // Tính trung tâm của danh sách
          const listCenter = listRect.top + listRect.height / 2;

          // Tính khoảng cách giữa trung tâm của phần tử được chọn và trung tâm của danh sách
          const offset = selectedCenter - listCenter;

          // Cập nhật giá trị scrollTop của danh sách
          list.scrollTop += offset;
        }
      }
    },
    /**
     * Author:PXTRUONG(28/6/2023)
     * Load dữ liệu 
     */
    async loaddata(api) {
      try {
        var data = await get(api);
        this.listData = data;
        this.origilData = data;
        this.itermsFilter = data;
        this.maxLength = data.length;
        this.maxLengthDefault=data.length;
       
      } catch (error) {
        console.log(error.code);
      }

    },
    /**
       * Author:PXTRUONG(27/6/2023)
       * Thực hiện focus 
       */
    focus() {
      this.$nextTick(function () {
        this.$refs["Minput"].focus();
      })
    },
    /**
     * Author:PXTRUONG(25/6/2023)
     * gửi dữ liệu để lọc theo dữ liệu truyền vào cho list
     */
    sortData() {
      
      if (this.propText == this.$_MResource.PropText.FixedAssetCategory.FixedAssetCategoryName) {
        this.$eventBus.emit("FixedAssetCategoryName", this.value);
      }
      else if (this.propText == this.$_MResource.PropText.Department.DepartmentName) {

        this.$eventBus.emit("DepartmentName", this.value);
      }
    },
    /**
     * Author: PXTRUONG(5/6/2023)
     * đóng mở danh list dropdown
     */
    showClick() {

      if (this.isshow == false) {
        this.scrollToSelected();
        this.isshow = true;

      }
      else {
        this.isshow = false;
      }


    },
    /**
     * Author:PXTURONG(5/6/2023)
     * Autocomplite 
     */
    filterIterms(data) {
      try {

        if (this.checknull(format.whiteSpace(data))) {
          this.itermsFilter = this.origilData;
          this.isshow = true;
        }
        else {
          this.itermsFilter = this.origilData.filter(item => item[this.propText].toLowerCase().includes(format.whiteSpace(data).toLowerCase()));
          
          this.isshow = true;
        }
      } catch (error) {
        console.log(error);
      }

    },
    /**
     * Author:PXTRUONG(5/6/2023)
     * Đóng form
     */
    clostab() {
    
      this.isshow = false;
    },
    /**
     * Author:PXTRUONG(5/5/2023)
     * thực hiện phím tắt để chọn item 
     */
    kewdown(event) {
      try {
        let index
        if (this.itermsFilter) {
          index = this.itermsFilter.findIndex((item) => item[this.propText] == this.valueSelected);
        }

        this.maxLength=this.itermsFilter.length;
        if (this.maxLength == 0) {
          return;
        }
        else {
          if (event.keyCode == 40) {
            event.preventDefault();
         
            this.isshow = true;
            this.scrollToSelected();
            index = index + 1;
            if (index >= this.maxLength) {
              this.valueSelected = this.itermsFilter[0][this.propText];
              this.scrollToSelected();
            }
            else {
              this.valueSelected = this.itermsFilter[index][this.propText];
              this.scrollToSelected();

            }

          }
          else if (event.keyCode == 38) {
            event.preventDefault();
            index = index - 1;
            if (index < 0) {
              this.valueSelected = this.itermsFilter[this.maxLength - 1][this.propText];
              this.scrollToSelected();

            }
            else {
              this.valueSelected = this.itermsFilter[index][this.propText];
              this.scrollToSelected();
            }

          }
          else if (event.keyCode == 13) {
            event.preventDefault();
            if (this.validate(this.valueSelected)) {
              this.clostab();
            }
            else {
              this.value = this.valueSelected;
              this.sortData();
              this.scrollToSelected();
              this.$emit("sendData", this.api, this.value, this.propText);
              this.itermsFilter = this.origilData;
              this.clostab();
            }

          }

        }

      } catch (error) {
        console.log(error);
      }

    },




    /**
     * Author:PXTRUONG(5/6/2023)
     * nhận giá trị khi click vào item mk chọn 
     */
    async onSelectItem(item) {
      try {

        this.value = item[this.propText];
        this.valueSelected = this.value;
        this.validate(this.value);
        this.sortData();
        this.$emit("sendData", this.api, this.value, this.propText);
        this.clostab();

      } catch (error) {
        console.log(error);
      }

    },
    checknull(data) {
      data = format.whiteSpace(data)

      if (!data) {

        return true;
      }
      else {
        return false;
      }
    },
    /**
     * Author:PXTRUONG(5/6/2023)
     * validate dữ liệu 
     */
    validate(data) {
      try {
        if (this.isNotAllowNull) {
          if (this.checknull(data)) {
            this.isNull = true;
            this.alertMsg = this.inputContent + " không được bỏ trống"
            // console.log( this.$refs.Minput);
            this.clostab();
            return true;
          }
          else {
            this.isNull = false;
            this.clostab();
            return false;
          }
        }
      } catch (error) {
        console.log(error);
      }


    }
  },
}
</script>
<style>
@import url('../../style/base/combobox.css');
@import url('../../style/base/icon.css');
@import url('../../style/base/textfield.css');
</style>