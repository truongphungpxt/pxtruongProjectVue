

import { createApp, h  } from 'vue'
import MNotificationVue from '@/components/base/MNotification.vue';
const createToast = (informContent, informStatus) => {
    const app = createApp({
      render() {
        return h(MNotificationVue, {
            informStatus,
             informContent
        })
      }
    })
  
   
    const root = document.createElement('div')
    const instance = app.mount(root)
    document.body.appendChild(root)

        root.classList.add('show')
        setTimeout(() => {
            root.classList.remove('show')
        
            app.unmount(root)
         
        }, 2000)
      
  }
  
  export default createToast

