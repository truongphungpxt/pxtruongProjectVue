const tooltip={
    mounted: (el, binding) => {
        el.setAttribute('title', binding.value);
      },
      updated: (el, binding) => {
        el.setAttribute('title', binding.value);
      },
      unmounted: (el) => {
        el.removeAttribute('title');
      },
}
export default tooltip;