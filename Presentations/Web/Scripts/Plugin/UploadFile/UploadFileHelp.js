
//初始化
var swfu = null;
function InitUploadFile() {
    swfu = new SWFUpload({
        // 提交设置
        upload_url: "/Manage/Case/UploadImg.aspx", // 处理上传请求的服务器端脚本URL
        file_post_name: "Filedata", // 是POST过去的$_FILES的数组名
        post_params: {
            "ASPSESSID": "<%=Session.SessionID %>"
        },

        // 文件上传设置
        file_size_limit: "2 MB",    // 限制文件大小
        file_types: "*.jpg;*.png;*.gif;*.jpeg",    // 对话框里的文件类型 
        file_types_description: "慕名上传工具",
        file_upload_limit: "300",    // 上传数量限制

        // 事件处理,可以自己在handlers.js里面扩充,极大的方便了开发者
        // 就是要在handlers里面定义如下的function,当然function里面可以什么也不干,或者用源代码自带的也行
        swfupload_loaded_handler: null,    // 当Flash控件成功加载后触发的事件处理函数
        file_queued_handler: fileQueuedByCustomize, // 当文件选择对话框关闭消失时，如果选择的文件成功加入上传队列，那么针对每个成功加入的文件都会触发一次该事件（N个文件成功加入队列，就触发N次此事件）。
        file_queue_error_handler: fileQueueError,
        file_dialog_start_handler: null,   // 当文件选取对话框弹出前触发的事件处理函数
        //            file_dialog_complete_handler: fileDialogComplete,   // 当文件选取对话框关闭后触发的事件处理函数(这个决定开始上传)
        upload_start_handler: null,    // 开始上传文件前触发的事件处理函数
        upload_progress_handler: uploadProgress,
        upload_error_handler: uploadError,
        upload_success_handler: uploadSuccess,  // 文件上传成功后触发的事件处理函数
        upload_complete_handler: uploadComplete,
        //            custom_settings: {                             //自定义设置
        //                file_queued_handler: "fileDialogComplete"
        //            },

        // 按钮设置
        button_image_url: "/Content/Images/Swfupload/upload_btn.gif",
        button_placeholder_id: "spanButtonPlaceholder",
        button_width: 86,
        button_height: 22,
        button_text: '<span class="button"></span>',
        button_text_style: '.button { font-family: Helvetica, Arial, sans-serif; font-size: 14pt; } .buttonSmall { font-size: 10pt; }',
        button_text_top_padding: 1,
        button_text_left_padding: 5,
        button_text_style: "font-size:12px;",
        button_cursor: SWFUpload.CURSOR.HAND, // 手形 默认值：SWFUpload.CURSOR.ARROW(箭头光标) 

        // Flash Settings
        flash_url: "/Scripts/UploadFile/swfupload.swf", // Relative to this file
        flash_color: "#eee",

        custom_settings: {
            upload_target: "divFileProgressContainer"
        },
        // 是否打开调试信息,默认false 
        debug: false
    });
}

//上传时设置参数（案例Id）
function startUploadFile() {
    swfu.addPostParam("caseId", $("#caseName option:selected").val());
    swfu.startUpload();
}

//上传时设置参数（广告分类Id）
function adStartUploadFile() {
    swfu.addPostParam("adSortId", $("#adSortId").val());
    swfu.setUploadURL("/Manage/Advert/UploadImg.aspx");
    swfu.startUpload();
}