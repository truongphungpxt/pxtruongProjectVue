<template>
    <div class="toast" v-if="informStatus == status.IsSucess">
        <div class="toast__left">
            <div class="toast__icon--tick"></div>
            <p class="toast__font--regular"><span class="toast__font--green">
                    Thành công!
                </span>
                {{ informContent }}
            </p>
        </div>
        <!-- <div class="toast__right">
            <div class="toast__icon--cancal"></div>
        </div> -->

    </div>
    <div class="toast " v-if="informStatus == status.IsFailed">

        <div class="toast__left">


            <div class="toast__content">
                <div class="toast__font">

                    <div class="toast__icon--cancalred"></div>
                    <span class="toast__font--red">
                        Lỗi!
                    </span>

                    {{ informContent }}

                </div>

            </div>

        </div>
        <!-- <div class="toast__right">

            <div class="toast__icon--cancal"  ></div>
        </div> -->

    </div>

    <!-- <div class="toast toast__inform">
        <div class="toast__left">
            <div class="toast__icon--inform"></div>
            <p class="toast__font--regular"><span class="toast__font--yellow">
                    Cảnh cáo! 
                </span>
                Dữ liệu của bạn đã bị thay đổi bởi người dùng khác.
            </p>
        </div>
        <div class="toast__right">
           
            <div class="toast__icon--cancal"></div>
        </div>

    </div>
    <div class="toast toast__inform">
        <div class="toast__left">
            <div class="toast__icon--informblue"></div>
            <p class="toast__font--regular"><span class="toast__font--blue">
                   Thông tin! 
                </span>
              Bạn nên đọc kỹ nội dung trước khi gửi phê duyệt.
            </p>
        </div>
        <div class="toast__right">
           
            <div class="toast__icon--cancal"></div>
        </div>

    </div> -->
</template>
<script>


import informStatus from '@/js/enum/informstatus';
export default {
    
    created() {
       
    },
    props: {
        informStatus: {
            type: Number,
            required: true
        },
        informContent: {
            type: String,
            required: true
        }
    },
    method: {
        closeImform() {
            // this.informStatus=status;
            // this.informContent=content;
            this.informStatus=false
        }
    },
    data() {
        return {
            status:informStatus
        }
    },
}
</script>
<style scoped>
@import url('../../style/base/icon.css');
@import url('../../style/base/toast.css');
</style>