/**
 * Author:PXTRUONG ,Create: 26/5/2023
 * để chặn bắt sự kiện của trình duyệt 
 */
const preventDefault={
     prevent(){
        window.oncontextmenu = function (e) {
            // Cancel the event
            e.preventDefault();
           
          };
           //Prevent Ctrl+S (and Ctrl+W for old browsers and Edge)
      document.onkeydown = function (e) {
        e = e || window.event;//Get event

        if (!e.ctrlKey) return;

        var code = e.which || e.keyCode;//Get key code

        switch (code) {
          case 83://Block Ctrl+S
          case 87://Block Ctrl+W -- Not work in Chrome and new Firefox
            e.preventDefault();
            e.stopPropagation();
            break;
        }
    }
}
    

};
export default preventDefault
