
import { createApp } from 'vue'
import App from './App.vue'
import eventbus  from './plugins/eventbus'
import router from './router/router.js';
import resource from './js/resource/resource';
import formmode from './js/enum/frommode';
import ElementPlus from 'element-plus';
import 'element-plus/dist/index.css';
import VueDatePicker from '@vuepic/vue-datepicker';
import pelfApi from '@/config/pelf/pelfapi';
import '@vuepic/vue-datepicker/dist/main.css';
import statusalert from './js/enum/statusalert';
import informStatus from './js/enum/informstatus';
import maxlengthinput from "@/js/enum/maxlengthinput.js";
import contextstatus from "@/js/enum/contextstatus";
import outside from "@/js/directive/outside"
import esc from "@/js/directive/esc"
import ctrls from "@/js/directive/ctrls";
import tooltip from "@/js/directive/tooltip";

const app= createApp(App);

app.use(eventbus);
app.component('VueDatePicker', VueDatePicker);
app.use(ElementPlus);


app.config.globalProperties.$_MResource=resource;
app.config.globalProperties.$_MFormMode=formmode;
app.config.globalProperties.$_MApi=pelfApi;
app.config.globalProperties.$_MStatusAlert=statusalert;
app.config.globalProperties.$_MInformStatus=informStatus;
app.config.globalProperties.$_MMaxLengthInput=maxlengthinput;
app.config.globalProperties.$_MContextStatus=contextstatus;
//khai báo directive 
app.directive('outside',outside);
app.directive('esc',esc);
app.directive('ctrls',ctrls);
app.directive('tooltip',tooltip);
app.use(router);
app.mount('#app')
export default app;