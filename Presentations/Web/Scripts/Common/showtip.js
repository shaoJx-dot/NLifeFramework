$(document).ready(function () {
    
    $(".show_tip").bind({
        mouseenter: function (e) {
            var isshow = $(this).attr('show');
            if (isshow == "") {
                $(this).contip({
                    align: 'bottom',
                    bg: '#1683c2',
                    color: '#fff', // ����������ɫ
                    v_size: 5, // ��ǵĴ�С������ 
                    radius: 4, // ����Բ�Ǵ�С px
                    padding_up_down: 2,
                    padding_left_right:8,
                    // attr: 'extitle'
                }).show();
                $(this).attr("show", "isshow");
            }
        }
        //mouseleave: function (e) {
        //    $(this).unbind("mouseenter");   //������¼�
        //    $(this).contip({
        //        //align: 'top',
        //        bg: '#1B7FA3',
        //        // html: '�Ϸ���ʾ��'
        //        // attr: 'extitle'
        //        // live: true
        //    }).revive();

        //    //$(this).contip({
        //    //}).hide();
        //}
    });
});

/*
//Ĭ��ѡ��  
{  
  align: 'top', // ���ݳ��ֵ�λ�ã� top right bottom left  
  padding: 7,  
  radius: 4, // ����Բ�Ǵ�С px  
  max_width: 222, // ��������� px  
  rise: 0, // ������Ը���λ�ã���Ϊ��ֵ  
  
  bg: '#000', // ������ɫ  
  fg: 'transparent', // �����ڲ���ɫ  
  color: '#fff', // ����������ɫ  
  font_size: '12px', // ��������  
  
  fade: 0, // ���뽥��  
  delay_in: 0, // �ӳ�  
  delay_out: 0, // �ӳ�  
  
  html: '',  
  live: false, // ������ʾ  
  opacity: 0.86, // ͸����  
  attr: 'title', // attr Ҫ���������  
  trigger: 'hover', // �󶨵��¼� hover click dblclick focus ..  
  show: false, // �Ƿ�Ĭ����ʾ  
  
  v_size: 6, // ��ǵĴ�С������  
  v_pos: 0.5, // ��ǳ��ֵ�λ��  
  v_px: 0, // ��ǳ��ֵ�λ�õ�ƫ�� px���� ��Ϊ��ֵ  
  
  elm_pos: 0.5, // ��������elm���ֵ�λ��  
  elm_px: 0 // ���ƫ�� ��Ϊ��ֵ  
};
*/