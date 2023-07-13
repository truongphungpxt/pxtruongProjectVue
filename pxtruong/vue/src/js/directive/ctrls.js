const ctrls={
    mounted:(el, binding) => {
       el._KeydownCallback=(event)=>{
                if(event.ctrlKey && event.key === 's'){
                    event.preventDefault();
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
export default ctrls;
