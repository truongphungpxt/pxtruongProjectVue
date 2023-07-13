const esc={
    mounted:(el, binding) => {
       el._KeydownCallback=(event)=>{
                if(event.key==='Escape'){
                    binding.value()
                }
       }
       document.addEventListener('keydown',el._KeydownCallback)
      },
    unmounted: el => {
        document.removeEventListener("keydown", el._KeydownCallback);
        delete el._KeydownCallback
      },
}
export default esc;
