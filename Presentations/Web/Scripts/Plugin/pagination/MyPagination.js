//javascript 分页 开始
//本分页要配合jquery一起使用
	//pageNo:当前页码
	//paginationContainer:分页容器(DIV标签,必须为jquery对象)
	//achievePaginationFunction:实现分页的函数,参数为当前页码
	//pages:总页数
function MyPagination(pageNo, paginationContainer, achievePaginationFunction, getPagesUrl) {
    $.get(getPagesUrl, function(pages) {
        paginationContainer.html("");
        achievePaginationFunction(pageNo);
        if (pageNo > 1) {
            paginationContainer.append("<input type='button' value='上一页' id='PagePre' class='PaginationsStyle' />&nbsp;");
            $("#PagePre").mouseover(function() { $(this).addClass("CurrentPageNoStyle") });
            $("#PagePre").mouseout(function() { $(this).removeClass("CurrentPageNoStyle"); $(this).addClass("PaginationsStyle") });
            $("#PagePre").click(function() { pageNo--; MyPagination(pageNo, paginationContainer, achievePaginationFunction, getPagesUrl); });
        }
        if (pageNo - 4 > 1) {
            paginationContainer.append("<input type='button' value='1...' id='PageIndex' class='PaginationsStyle' />&nbsp;");
            $("#PageIndex").mouseover(function() { $(this).addClass("CurrentPageNoStyle") });
            $("#PageIndex").mouseout(function() { $(this).removeClass("CurrentPageNoStyle"); $(this).addClass("PaginationsStyle") });
            $("#PageIndex").click(function() { pageNo = 1; MyPagination(pageNo, paginationContainer, achievePaginationFunction, getPagesUrl); });
        }

        if (pageNo - 4 > 0) {
            for (var i = pageNo - 4; i < pageNo; i++) {
                CreatePageNo(pageNo, paginationContainer, i, achievePaginationFunction, getPagesUrl)
            }
        } else {
            for (var i = 1; i < pageNo; i++) {
                CreatePageNo(pageNo, paginationContainer, i, achievePaginationFunction, getPagesUrl)
            }
        }

        if (pageNo + 5 < pages) {
            for (var i = pageNo; i < pageNo + 5; i++) {
                CreatePageNo(pageNo, paginationContainer, i, achievePaginationFunction, getPagesUrl)
            }
            paginationContainer.append("<input type='button' value='..." + pages + "' id='PageLast' class='PaginationsStyle' />&nbsp;");
            $("#PageLast").mouseover(function() { $(this).addClass("CurrentPageNoStyle") });
            $("#PageLast").mouseout(function() { $(this).removeClass("CurrentPageNoStyle"); $(this).addClass("PaginationsStyle") });
            $("#PageLast").click(function() { pageNo = pages; MyPagination(pageNo, paginationContainer, achievePaginationFunction, getPagesUrl); });
        } else {
            for (var i = pageNo; i <= pages; i++) {
                CreatePageNo(pageNo, paginationContainer, i, achievePaginationFunction, getPagesUrl)
            }
        }

        if (pageNo < pages) {
            paginationContainer.append("<input type='button' value='下一页' id='PageNext' class='PaginationsStyle' />&nbsp;");
            $("#PageNext").mouseover(function() { $(this).addClass("CurrentPageNoStyle") });
            $("#PageNext").mouseout(function() { $(this).removeClass("CurrentPageNoStyle"); $(this).addClass("PaginationsStyle") });
            $("#PageNext").click(function() { pageNo++; MyPagination(pageNo, paginationContainer, achievePaginationFunction, getPagesUrl); });
        }
    });
	}

	function CreatePageNo(pageNo, paginationContainer, num, achievePaginationFunction, getPagesUrl) {
		if(pageNo == num){
		    paginationContainer.append("<input type='button' value='"+num+"' id='Page"+num+"' class='CurrentPageNoStyle' />&nbsp;");
		}else{
			paginationContainer.append("<input type='button' value='"+num+"' id='Page"+num+"' class='PaginationsStyle' />&nbsp;");
			$("#Page"+num).mouseover(function(){$(this).addClass("CurrentPageNoStyle")});
			$("#Page"+num).mouseout(function(){$(this).removeClass("CurrentPageNoStyle");$(this).addClass("PaginationsStyle")});
		}
		$("#Page" + num).click(function() { pageNo = parseInt($(this).val()); MyPagination(pageNo, paginationContainer, achievePaginationFunction, getPagesUrl); });
	}
//javascript 分页 结束