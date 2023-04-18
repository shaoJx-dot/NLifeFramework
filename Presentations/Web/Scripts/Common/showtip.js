$(document).ready(function () {
    
    $(".show_tip").bind({
        mouseenter: function (e) {
            var isshow = $(this).attr('show');
            if (isshow == "") {
                $(this).contip({
                    align: 'bottom',
                    bg: '#1683c2',
                    color: '#fff', // 正文字体颜色
                    v_size: 5, // 尖角的大小，像素 
                    radius: 4, // 气泡圆角大小 px
                    padding_up_down: 2,
                    padding_left_right:8,
                    // attr: 'extitle'
                }).show();
                $(this).attr("show", "isshow");
            }
        }
        //mouseleave: function (e) {
        //    $(this).unbind("mouseenter");   //解绑点击事件
        //    $(this).contip({
        //        //align: 'top',
        //        bg: '#1B7FA3',
        //        // html: '上方提示框'
        //        // attr: 'extitle'
        //        // live: true
        //    }).revive();

        //    //$(this).contip({
        //    //}).hide();
        //}
    });
});

/*
//默认选项  
{  
  align: 'top', // 气泡出现的位置， top right bottom left  
  padding: 7,  
  radius: 4, // 气泡圆角大小 px  
  max_width: 222, // 气泡最大宽度 px  
  rise: 0, // 气泡相对浮动位置，可为负值  
  
  bg: '#000', // 背景颜色  
  fg: 'transparent', // 气泡内部颜色  
  color: '#fff', // 正文字体颜色  
  font_size: '12px', // 正文字体  
  
  fade: 0, // 渐入渐出  
  delay_in: 0, // 延迟  
  delay_out: 0, // 延迟  
  
  html: '',  
  live: false, // 总是显示  
  opacity: 0.86, // 透明度  
  attr: 'title', // attr 要处理的属性  
  trigger: 'hover', // 绑定的事件 hover click dblclick focus ..  
  show: false, // 是否默认显示  
  
  v_size: 6, // 尖角的大小，像素  
  v_pos: 0.5, // 尖角出现的位置  
  v_px: 0, // 尖角出现的位置的偏移 px像素 可为负值  
  
  elm_pos: 0.5, // 尖角相对于elm出现的位置  
  elm_px: 0 // 尖角偏移 可为负值  
};
*/