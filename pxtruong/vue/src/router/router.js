
import { createRouter,createWebHistory} from 'vue-router'
import OverviewVue from '@/components/view/overview/Overview.vue';
import PelfBodyVue from '@/components/view/pelf/PelfBody.vue';
const routess = [
  {path: "/OverviewVue", component: OverviewVue}, 
  {path: "/PelfBody", component: PelfBodyVue}
  ]
  const router = createRouter({
    history:createWebHistory() ,
    routes: routess,
  })
  export default router;