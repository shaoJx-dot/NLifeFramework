
function whenerror(errcode, file, msg) {

    switch (errcode) {

        case -10: // HTTP error
            alert("Error Code: HTTP Error, File name: " + file.name + ", Message: " + msg);
            break;

        case -20: // No upload script specified
            alert("Error Code: No upload script, File name: " + file.name + ", Message: " + msg);
            break;

        case -30: // IOError
            alert("Error Code: IO Error, File name: " + file.name + ", Message: " + msg);
            break;

        case -40: // Security error
            alert("Error Code: Security Error, File name: " + file.name + ", Message: " + msg);
            break;

        case -50: // Filesize too big
            alert(file.name + "文件大小受限制, 文件大小: " + file.size + "K,不要超过" + swfu.settings['allowed_filesize'] + 'K');
            break;
    }

};

var isCancelAll = false;

/****************
通用类代码      *
Author:LWD      *
Time:2009-12-15 *
*****************/
/*
FF和ie都可以这要调用：
var bgame_table = document.getElementById('game_table'); 
nowTR = bgame_table.insertRow(-1);
nowTD = nowTR.insertCell(-1); 
-1代表什么意思呢？
原来-1代表：插入(行)单元格到 cells(rows) 集合内的最后一个。
ie默认值了-1,但FF就没有默认值的。
所以为了兼容性好，我建议大家都是加上-1
*/


/*当有文件加入队列中是触发*/
var totalSize = 0;
function fileQueuedByCustomize(file) {
    totalSize += file.size;
    var listingfiles = document.getElementById("fileList");
    var tr = listingfiles.insertRow(-1);
    tr.id = file.id;

    var flag = tr.insertCell(-1); flag.className = 'flag2';

    var fileName = tr.insertCell(-1);
    fileName.innerHTML = file.name;

    var progressTD = tr.insertCell(-1); progressTD.className = 'progressTD';
    progressTD.innerHTML = '<span id="' + file.id + 'progress" class="progressBar"></span><span class="fileSize">' + getNiceFileSize(file.size) + '</span>';

    var del = tr.insertCell(-1);
    del.className = 'delectBtn';
    del.id = file.id + 'deleteGif';
    del.innerHTML = '<a href="javascript:uploadFileCancelled(\'' + file.id + '\',' + listingfiles.rows.length + ')"><img src="/Scripts/Plugin/UploadFile/images/del_ico.gif" alt="清除" width="13" height="13" border="0" /></a>';
    showInfo(file, listingfiles.rows.length);
}

/*显示信息*/
function showInfo(file, queuelength) {
    var fileCount = document.getElementById("fileCount");
    fileCount.innerHTML = queuelength;
    var fileTotleSize = document.getElementById("fileTotleSize");
    fileTotleSize.innerHTML = getNiceFileSize(totalSize);
}

/*单个上传文件被取消*/
function uploadFileCancelled(fileId, queuelength) {
    var listingfiles = document.getElementById("fileList");
    var rows = listingfiles.rows;
    for (var i = rows.length - 1; i >= 0; i--) {
        if (fileId == rows[i].id) {
            totalSize = totalSize - swfu.getFile(fileId).size;
            listingfiles.deleteRow(i);
            break;
        }
    }
    swfu.cancelUpload(fileId, false);
    showInfo(swfu.getFile(fileId), listingfiles.rows.length);
}


function uploadFileStart(file, position, queuelength) {
    window.status = '正在上传文件' + file.name + '....';
}

/*进度条*/
function uploadProgress(file, bytesLoaded, totalBytes) {

    var progress = document.getElementById(file.id + "progress");
    var percent = Math.ceil((bytesLoaded / file.size) * 100)
    progress.style.backgroundPosition = (percent - 100) + 'px'+ " 0px";
    window.status = '已上传' + percent + '%';
}
function uploadFileComplete(file) {
    var tR = document.getElementById(file.id);
    tR.className += " fileUploading";
    tR.cells[0].className = 'flag1';

    var progress = document.getElementById(file.id + "progress");
    progress.style.backgroundPosition = '0px 0px';
    //清除删除图标
    document.getElementById(file.id + 'deleteGif').innerHTML = "";
}


function uploadError(errno) {
    alert(errno)
}

/*清除所有上传图片*/
function cancelQueue() {
    isCancelAll = true;
    totalSize = 0;
    var queueCount = swfu.getStats().files_queued;
    for (var i = 0; i < queueCount; i++) {
        swfu.cancelUpload(null, false);
    }
    clearhQueue();
    showInfo(0, 0);
}
/*处理UI，刪除表格的所有行*/
function clearhQueue() {
    var listingfiles = document.getElementById("fileList");
    var rowLength = listingfiles.rows.length;
    while (rowLength > 0) {
        listingfiles.deleteRow(0);
        rowLength--;
    }
}

/*取消图片队列或者队列上传完成*/
function uploadQueueComplete(file) {
    //var div = document.getElementById("queueinfo");
    if (isCancelAll == true) {
        // "取消图片上传";
        showInfo(0, 0)
    } else {
        window.status = "所有图片已经上传";
        //发送ajax请求，获取session的值
        var options = { method: "post", asynchronous: true, onSuccess: whenUploadQueueComplete, onFailure: function() { alert('failure load') } };
    }
}
/*访问session后，关闭窗口并返回结果*/
function whenUploadQueueComplete(http) {
    ReturnValue(http.responseText)
}

/*所有图片上传完后弹出层*/
function showUploadComplete() {
    var num = $("#uploadType").val();
    switch (num) {
        case "1":
            window.location.href = "ProductList.aspx";
            break;
        case "2":
            break;
        case "3":
            break;
        default:
//            createUploadDialog("extjs");
            break;
    }
}

/*单位换算*/
var _K = 1024;
var _M = _K * 1024;
function getNiceFileSize(bitnum) {
    if (bitnum < _M) {
        if (bitnum < _K) {
            return bitnum + ' B';
        } else {
            return Math.ceil(bitnum / _K) + ' K';
        }
    } else {
        return Math.ceil(100 * bitnum / _M) / 100 + ' M';
    }
}
