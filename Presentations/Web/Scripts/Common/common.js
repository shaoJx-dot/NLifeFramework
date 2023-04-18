$(document).ready(function () {


    //使用bind方法绑定click事件
    $("#ct .o img").bind("click", function (e) {

        var id = $(this).attr('method');

        if ($("#" + id).hasClass("hiden_bar") == false) {
            $(this).attr('src', '/Content/Images/Community/collapsed_yes.gif');
            $("#" + id).addClass("hiden_bar");
            $("#" + id + "_line").addClass("bottom_line");
        } else {
            $(this).attr('src', '/Content/Images/Community/collapsed_no.gif');
            $("#" + id).removeClass("hiden_bar");
            $("#" + id + "_line").removeClass("bottom_line");
        }

    });


});