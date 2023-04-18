/*
 * 分页
 * @author ray_guan
 * version:1.0
 */
jQuery.fn.myPagination = function(options){
	var defaults = {
		pageNumber:0,
		totalPage:0,
		clickPage:function(pageNumber){}
	};

	var options = $.extend(defaults, options);

	var thisRef = $(this);

	initPagination(thisRef,defaults);
};

/*
 * 初始化分页
 */
function initPagination(thisRef,defaults){
	if(defaults.pageNumber > 1){
		constructPageNumber(thisRef,"上一页",defaults.pageNumber - 1,defaults.pageNumber);//构造页码
	}

	if(defaults.pageNumber - 4 > 1){
		constructPageNumber(thisRef,"1...",1,defaults.pageNumber);//构造页码
	}

	if(defaults.pageNumber - 4 > 0){
		for (var i = defaults.pageNumber - 4; i < defaults.pageNumber; i++){
			constructPageNumber(thisRef,i,i,defaults.pageNumber);//构造页码
		}
	}else{
		for (var i = 1; i < defaults.pageNumber; i++){
			constructPageNumber(thisRef,i,i,defaults.pageNumber);//构造页码
		}
	}

	if(defaults.pageNumber + 5 < defaults.totalPage){
		for (var i = defaults.pageNumber; i < defaults.pageNumber + 5; i++){
			constructPageNumber(thisRef,i,i,defaults.pageNumber);//构造页码
		}
		constructPageNumber(thisRef,"..."+defaults.totalPage,defaults.totalPage,defaults.pageNumber);//构造页码
	}else{
		for (var i = defaults.pageNumber; i <= defaults.totalPage; i++){
			constructPageNumber(thisRef,i,i,defaults.pageNumber);//构造页码
		}
	}

	if(defaults.pageNumber < defaults.totalPage){
		constructPageNumber(thisRef,"下一页",defaults.pageNumber + 1,defaults.pageNumber);//构造页码
	}

	thisRef.find('a').hover(
		function(){
			var a = $(this);
			if(a.data('num') != defaults.pageNumber){
				a.addClass('curr-page-number');
			}
		},
		function(){
			var a = $(this);
			if(a.data('num') != defaults.pageNumber){
				a.removeClass('curr-page-number');
				a.addClass('page-number');
			}
		}
	);

	thisRef.find('a').click(function(){
		var num = $(this).data('num');
		defaults.pageNumber = num;
		thisRef.html("");
		initPagination(thisRef,defaults);//初始化分页
		defaults.clickPage(num);
	});
};

/*
 * 构造页码
 */
function constructPageNumber(container,numText,num,currNum){
	var pageObj = "<a class='page-number'></a>";
	var po = $(pageObj);
	po.html(numText);
	po.data("num",num);
	if(num == currNum){
		po.addClass('curr-page-number');
	}
	container.append(po);
};