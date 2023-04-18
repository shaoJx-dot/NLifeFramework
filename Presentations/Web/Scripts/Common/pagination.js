/*
后端输出的分页信息：
{
    "pageInfo": {
        "TotalRecord": 70,
        "TotalPage": "5",
        "PageIndex": 3
    }
}

调用分页方法即可以获得分页效果（假设分页容器是：page_box）：
var doSetPageInfo = function(jsonData){
    document.getElementById("page_box").innerHTML = '';
    if (typeof (jsonData.pageInfo) != "undefined"
        && jsonData.pageInfo != null
        && jsonData.pageInfo.TotalPage != 0
    ){
        var AjaxPageObj = new Util.func.AjaxPage({
            allRecords: jsonData.pageInfo.TotalRecord,
            allPageNum: jsonData.pageInfo.TotalPage,
            currentPage: jsonData.pageInfo.PageIndex
        });
        AjaxPageObj.onDraw(document.getElementById("page_box"), "pageCallback");
    }
}

至于后台，则只需根据传入的参数来实现分段取数据就可以了。
当用户点击一个页面的时候，传数的页数乃是通过变量page来传递，
这样就最大限度上的做到了运算和展示分离，同时也做到了客户端和服务器端数据传输量的最小化。
*/


//创建全局对象。
//var Util = {};
//Util = Util || {};
if (typeof (Util) == "undefined") {
    Util = {};
}
//设定命名空间。
Util.func = {};
(function () {
    /**
    * 这里传入的数据里必须包含三个Key键：
    * allRecords - 所有记录数。
    * allPageNum - 所有页面数。
    * currentPage - 当前页。
    **/
    Util.func.AjaxPage = function (my_page_data) {
        this.totalRecord = parseInt(my_page_data.allRecords);
        this.totalPage = parseInt(my_page_data.allPageNum);
        this.currentPage = parseInt(my_page_data.currentPage);

        //在多页的时候，一次显示多少页。
        this.showPage = 8;

        /**
        * 画分页内容的时候，要求传入两个参数：
        * container - 显示分页内容的容器。
        * callback - 回调函数。
        **/
        this.onDraw = function (container, callback) {
            var loop_num = this.totalPage > this.showPage ? this.showPage : this.totalPage;
            
            var pageInfo = "";
            //有记录时才显示分页
            if (this.totalPage > 0) {
                //第一页时
                if(this.totalPage == 1){
                    pageInfo += '<span class="link_disabled">首页</span>';
                    pageInfo += '<span class="link_disabled" >上页</span>';
                    pageInfo += '<span class="link_disabled" >下页</span>';
                    pageInfo += '<span class="link_disabled">末页</span>';
                    pageInfo += '<select id="' + container.id + '_select' + '" class="link_select" onchange="' + callback + '(' + 'Form.select.getItemValue(this)' + ')">';
                    pageInfo += '<option value="1" selected="selected">1/1</option>';
                    pageInfo += '</select>';
                }
                
                //
                if (this.currentPage == 1 && this.totalPage > 1 ) {
                    pageInfo += '<span class="link_disabled">首页</span>';
                    pageInfo += '<span class="link_disabled" >上页</span>';
                    pageInfo += '<a title="第' + (this.currentPage+1) + '页" href="javascript:' + callback + '(' + (this.currentPage+1) + ')" class="link_page" >下页</a>';
                    pageInfo += '<a title="第' + this.totalPage + '页" href="javascript:'+ callback +'(' + this.totalPage + ')" class="link_page " >末页</a>';
                    
                    pageInfo += '<select id="' + container.id + '_select' + '" class="link_select" onchange="' + callback + '(' + 'Form.select.getItemValue(this)' + ')">';
                    for (var i = 1; i <= this.totalPage; i++) {
                        if(this.currentPage == i){
                            pageInfo += '<option value="' + i + '" selected="selected">' + i + '/' + this.totalPage + '</option>';
                        }else{
                            pageInfo += '<option value="' + i + '">' + i + '/' + this.totalPage + '</option>';
                        }
                        
                    }
                    pageInfo += '</select>';
                }
                if (this.currentPage > 1 && this.currentPage < this.totalPage){
                    pageInfo += '<a title="第' + this.totalPage + '页" href="javascript:'+ callback +'(1)" class="link_page " >首页</a>';
                    pageInfo += '<a title="第' + (this.currentPage-1) + '页" href="javascript:' + callback + '(' + (this.currentPage-1) + ')" class="link_page" >上页</a>';
                    
                    pageInfo += '<a title="第' + (this.currentPage+1) + '页" href="javascript:' + callback + '(' + (this.currentPage+1) + ')" class="link_page" >下页</a>';
                    pageInfo += '<a title="第' + this.totalPage + '页" href="javascript:'+ callback +'(' + this.totalPage + ')" class="link_page " >末页</a>';
                    
                    pageInfo += '<select id="' + container.id + '_select' + '" class="link_select" onchange="' + callback + '(' + 'Form.select.getItemValue(this)' + ')">';
                    for (var i = 1; i <= this.totalPage; i++) {
                        if(this.currentPage == i){
                            pageInfo += '<option value="' + i + '" selected="selected">' + i + '/' + this.totalPage + '</option>';
                        }else{
                            pageInfo += '<option value="' + i + '">' + i + '/' + this.totalPage + '</option>';
                        }
                        
                    }
                    pageInfo += '</select>';
                 }
                 if (this.currentPage > 1 && this.currentPage >= this.totalPage){
                    pageInfo += '<a title="第' + this.totalPage + '页" href="javascript:'+ callback +'(1)" class="link_page " >首页</a>';
                    pageInfo += '<a title="第' + (this.currentPage-1) + '页" href="javascript:' + callback + '(' + (this.currentPage-1) + ')" class="link_page" >上页</a>';
                    
                    pageInfo += '<span class="link_disabled" >下页</span>';
                    pageInfo += '<span class="link_disabled">末页</span>';
                    
                    pageInfo += '<select id="' + container.id + '_select' + '" class="link_select" onchange="' + callback + '(' + 'Form.select.getItemValue(this)' + ')">';
                    for (var i = 1; i <= this.totalPage; i++) {
                        if(this.currentPage == i){
                            pageInfo += '<option value="' + i + '" selected="selected">' + i + '/' + this.totalPage + '</option>';
                        }else{
                            pageInfo += '<option value="' + i + '">' + i + '/' + this.totalPage + '</option>';
                        }
                        
                    }
                    pageInfo += '</select>';
                 }

            }
            
            //alert(pageInfo);
            //container.innerHTML = pageInfo;
            $(container).html(pageInfo);
        };
    }
})();

