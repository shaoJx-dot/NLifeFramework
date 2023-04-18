
$(document).ready(function () {
    /**********首页使用**********/
    if (typeof (HTMLElement) != "undefined")    //给firefox定义contains()方法，ie下不起作用
    {
        HTMLElement.prototype.contains = function (obj) {
            while (obj != null && typeof (obj.tagName) != "undefind") { //通过循环对比来判断是不是obj的父元素
                if (obj == this) return true;
                obj = obj.parentNode;
            }
            return false;
        };
    }
    //名片hover事件
    Dom.addEvent(Dom.getObj("uCard"), "mouseover", function () {
        if (delayCloseTime) {
            clearTimeout(delayCloseTime);
        }
        showCard();
    });
    Dom.addEvent(Dom.getObj("uCard"), "mouseout", function (e) {
        hideMsgBox(e);
    });
});


var isExistCard = false;
var delayCloseTime;
var showCard = function () {
    if (isExistCard) {
        return;
    }
    isExistCard = true;
    var cardObj = document.createElement("div");
    cardObj.setAttribute("id", "cardInfo");
    cardObj.style.width = 345 + "px";
    cardObj.style.height = 275 + "px";
    cardObj.style.overflow = "hidden";
    //cardObj.style.visibility = 'visible';
    cardObj.style.position = "absolute";
    cardObj.style.zIndex = "800";

    var pObj = Dom.getObj("uCard");
    var box = pObj.getBoundingClientRect();
    cardObj.style.left = box.left + pObj.clientWidth + 10 + "px";
    var cardHeight = parseInt(cardObj.style.height) + 10;
    if (box.top > cardHeight) {
        cardObj.style.top = (pObj.offsetTop - parseInt(cardObj.style.height) - 3) + "px";
    } else {
        cardObj.style.top = pObj.offsetTop - box.top + 10 + "px";
    }


    var content = "";
    content += '<div class="cardcontainer"><div class="popbg"><a class="close" href="javascript:void(0)" onclick="delCard()"></a>';
    content += '<div class="cardarealoading">读取中…</div><div id="cardarea" class="cardarea"><div id="" class="cardface">';
    content += '<div class="cardfacein"><table class="cardhtml"cellpadding="0"><tr><td width="38"></td><td class="cxttp">';
    content += '<div id="cxttpid"class="cxttp1"><u>|</u>第<b>8</b>年</div></td></tr><tr><td colspan="2"><table class="intable">';
    content += '<tr><td width="111"><div class="thename"><a class="thename-a"target="_blank"href="/"title="">烟和雾</a></div>';
    content += '</td><td width="90"><div title=""class="thejob">网络部经理</div></td><td class="theww"width="90"><span id="">';
    content += '留个消息</span></td></tr></table></td></tr><tr><td colspan=2><div class="htc0 thecomp">';
    content += '<a class="thecomp-a"href="/"target="_blank"title="">多维网络技术有限公司</a></div></td></tr><tr>';
    content += '<td>地址：</td><td><div class="htc1"title="">广东 佛山市南海区 桂城天佑六路</div></td></tr><tr><td>手机：</td>';
    content += '<td><div class="htc1"title="">13535712076</div></td></tr><tr><td>电话：</td><td>';
    content += '<div class="htc1"title="">0757-88888888&nbsp;传真:0757-88888888</div></td></tr><tr><td>网址：</td><td>';
    content += '<div class="htc1"><a class="htc1-a"target="_blank"title=""href="/">http://www.dovisoft.com</a></td></tr><tr><td></td><td>';
    content += '<div class="htc1"><a class="htc1-a"title=""href="/"target="_blank">http://www.dovisoft.com</a></td></tr></table></div></div>';
    content += '<div id=""class="cardback"><div class="cardbackin"><div class="wds2"></div><div class="pl pl_wp">';
    content += '<table class="thecardtable"width="280"cellspacing="0"cellpadding="0"><tr><td width="70"height="57"valign="top">';
    content += '主营产品：</td><td class="thecardtable-td"valign="top"></td></tr><tr><td height="10"colspan="2"></td></tr><tr>';
    content += '<td valign="top">主营行业：</td><td class="thecardtable-td"></td></tr></table></div></div></div></div>';
    content += '<div class="trigdiv"><a id="upturn"href="javascript:void(0)"title="点击翻转"></a></div><div class="addbar">';
    content += '<a class="addfriend"href="javascript:void(0)"></a><a class="copyinfo"href="javascript:void(0)"></a>';
    content += '<a class="history"href="javascript:void(0)">最近看过的名片&gt;&gt;</a></div></div></div>';
    content += '';

    cardObj.innerHTML = content;
    document.body.appendChild(cardObj);

    var scrollPic = new ScrollPic();
    scrollPic.scrollContId = "cardarea"; //内容容器ID
    //scrollPic.arrLeftId = "upturn";   //左箭头ID
    scrollPic.arrRightId = "upturn";    //右箭头ID
    scrollPic.frameWidth = 320;         //显示框宽度
    scrollPic.pageWidth = 320;          //翻页宽度
    scrollPic.speed = 10;               //移动速度(单位毫秒，越小越快)
    scrollPic.space = 50;               //每次移动像素(单位px，越大越快)
    scrollPic.autoClick = false;        //鼠标按着连续滚动
    scrollPic.autoPlay = false;         //自动播放
    //scrollPic.autoPlayTime = 8;       //自动播放间隔时间(秒)
    scrollPic.initialize();             //初始化
    //IE6 子元素必须使用float，否则容器宽度不能自适应

    Dom.addEvent(Dom.getObj("cardInfo"), "mouseout", function (event) {
        hideMsgBox(event);
    });
};

function hideMsgBox(e) { //e用来传入事件，Firefox的方式
    clearTimeout(delayCloseTime);
    if (e) {
        var browser = navigator.userAgent;   //取得浏览器属性
        if (browser.indexOf("Firefox") > 0) { //如果是Firefox
            //如果是子元素
            if (document.getElementById("cardInfo").contains(e.relatedTarget)) {
                return;   //结束函式
            }
        }
        if (browser.indexOf("MSIE") > 0) { //如果是IE

            //如果是子元素
            if (document.getElementById("cardInfo").contains(event.toElement)) {
                return; //结束函式
            }
        }
    }

    /*要执行的操作*/
    delayCloseTime = setTimeout(delCard, 500);

}

function delCard() {
    var card = Dom.getObj("cardInfo");
    if (card) {
        document.body.removeChild(card);
    }
    isExistCard = false;
}


function ScrollPic(scrollContId, arrLeftId, arrRightId, dotListId) {
    this.scrollContId = scrollContId;
    this.arrLeftId = arrLeftId;
    this.arrRightId = arrRightId;
    this.dotListId = dotListId;
    this.dotClassName = "dotItem";
    this.dotOnClassName = "dotItemOn";
    this.dotObjArr = [];
    this.pageWidth = 0;
    this.frameWidth = 0;
    this.speed = 10;
    this.space = 10;
    this.pageIndex = 0;
    this.autoClick = true;  //鼠标按着一直滚动
    this.autoPlay = true;
    this.autoPlayTime = 5;
    var _autoTimeObj, _scrollTimeObj, _state = "ready";
    this.stripDiv = document.createElement("DIV");
    this.listDiv01 = document.createElement("DIV");
    this.listDiv02 = document.createElement("DIV");
    if (!ScrollPic.childs) {
        ScrollPic.childs = []
    };
    this.ID = ScrollPic.childs.length;
    ScrollPic.childs.push(this);
    this.initialize = function () {
        if (!this.scrollContId) {
            throw new Error("必须指定scrollContId.");
            return
        };
        this.scrollContDiv = Dom.getObj(this.scrollContId);
        if (!this.scrollContDiv) {
            throw new Error("scrollContId不是正确的对象.(scrollContId = \"" + this.scrollContId + "\")");
            return
        };
        this.scrollContDiv.style.width = this.frameWidth + "px";
        this.scrollContDiv.style.overflow = "hidden";
        this.listDiv01.innerHTML = this.listDiv02.innerHTML = this.scrollContDiv.innerHTML;
        this.scrollContDiv.innerHTML = "";
        this.scrollContDiv.appendChild(this.stripDiv);
        this.stripDiv.appendChild(this.listDiv01);
        this.stripDiv.appendChild(this.listDiv02);
        this.stripDiv.style.overflow = "hidden";
        this.stripDiv.style.zoom = "1";
        this.stripDiv.style.width = "32766px";
        this.listDiv01.style.cssFloat = "left";
        this.listDiv02.style.cssFloat = "left";
        Dom.addEvent(this.scrollContDiv, "mouseover", Function("ScrollPic.childs[" + this.ID + "].stop()"));
        Dom.addEvent(this.scrollContDiv, "mouseout", Function("ScrollPic.childs[" + this.ID + "].play()"));
        if (this.arrLeftId) {
            this.arrLeftObj = Dom.getObj(this.arrLeftId);
            if (this.arrLeftObj) {
                Dom.addEvent(this.arrLeftObj, "mousedown", Function("ScrollPic.childs[" + this.ID + "].rightMouseDown()"));
                Dom.addEvent(this.arrLeftObj, "mouseup", Function("ScrollPic.childs[" + this.ID + "].rightEnd()"));
                Dom.addEvent(this.arrLeftObj, "mouseout", Function("ScrollPic.childs[" + this.ID + "].rightEnd()"));
            }
        };
        if (this.arrRightId) {
            this.arrRightObj = Dom.getObj(this.arrRightId);
            if (this.arrRightObj) {
                Dom.addEvent(this.arrRightObj, "mousedown", Function("ScrollPic.childs[" + this.ID + "].leftMouseDown()"));
                Dom.addEvent(this.arrRightObj, "mouseup", Function("ScrollPic.childs[" + this.ID + "].leftEnd()"));
                Dom.addEvent(this.arrRightObj, "mouseout", Function("ScrollPic.childs[" + this.ID + "].leftEnd()"))
            }
        };
        if (this.dotListId) {
            this.dotListObj = Dom.getObj(this.dotListId);
            if (this.dotListObj) {
                var pages = Math.round(this.listDiv01.offsetWidth / this.frameWidth + 0.4),
                i,
                tempObj;
                for (i = 0; i < pages; i++) {
                    tempObj = document.createElement("span");
                    this.dotListObj.appendChild(tempObj);
                    this.dotObjArr.push(tempObj);
                    if (i == this.pageIndex) {
                        tempObj.className = this.dotClassName
                    } else {
                        tempObj.className = this.dotOnClassName
                    };
                    tempObj.title = "第" + (i + 1) + "页";
                    Dom.addEvent(tempObj, "click", Function("ScrollPic.childs[" + this.ID + "].pageTo(" + i + ")"))
                }
            }
        };
        if (this.autoPlay) {
            this.play()
        }
    };
    this.leftMouseDown = function () {
        if (_state != "ready") {
            return
        };
        _state = "floating";
        _scrollTimeObj = setInterval("ScrollPic.childs[" + this.ID + "].moveLeft()", this.speed);
    };
    this.rightMouseDown = function () {
        if (_state != "ready") {
            return
        };
        _state = "floating";
        _scrollTimeObj = setInterval("ScrollPic.childs[" + this.ID + "].moveRight()", this.speed);
    };
    this.moveLeft = function () {
        if (this.scrollContDiv.scrollLeft + this.space >= this.listDiv01.scrollWidth) {
            this.scrollContDiv.scrollLeft = this.scrollContDiv.scrollLeft + this.space - this.listDiv01.scrollWidth
        } else {
            this.scrollContDiv.scrollLeft += this.space
        };
        //鼠标按着停止
        if (!this.autoClick) {
            ScrollPic.childs[this.ID].leftEnd();
        }
        this.accountPageIndex()
    };
    this.moveRight = function () {
        if (this.scrollContDiv.scrollLeft - this.space <= 0) {
            this.scrollContDiv.scrollLeft = this.listDiv01.scrollWidth + this.scrollContDiv.scrollLeft - this.space
        } else {
            this.scrollContDiv.scrollLeft -= this.space
        };
        //鼠标按着停止
        if (!this.autoClick) {
            ScrollPic.childs[this.ID].rightEnd();
        }
        this.accountPageIndex()
    };
    this.leftEnd = function () {
        if (_state != "floating") {
            return
        };
        _state = "stoping";
        clearInterval(_scrollTimeObj);
        var fill = this.pageWidth - this.scrollContDiv.scrollLeft % this.pageWidth;
        this.move(fill)
    };
    this.rightEnd = function () {
        if (_state != "floating") {
            return
        };
        _state = "stoping";
        clearInterval(_scrollTimeObj);
        var fill = -this.scrollContDiv.scrollLeft % this.pageWidth;
        this.move(fill)
    };
    this.move = function (num, quick) {
        var thisMove = num / 5;
        if (!quick) {
            if (thisMove > this.space) {
                thisMove = this.space
            };
            if (thisMove < -this.space) {
                thisMove = -this.space
            }
        };
        if (Math.abs(thisMove) < 1 && thisMove != 0) {
            thisMove = thisMove >= 0 ? 1 : -1
        } else {
            thisMove = Math.round(thisMove)
        };
        var temp = this.scrollContDiv.scrollLeft + thisMove;
        if (thisMove > 0) {
            if (this.scrollContDiv.scrollLeft + thisMove >= this.listDiv01.scrollWidth) {
                this.scrollContDiv.scrollLeft = this.scrollContDiv.scrollLeft + thisMove - this.listDiv01.scrollWidth
            } else {
                this.scrollContDiv.scrollLeft += thisMove
            }
        } else {
            if (this.scrollContDiv.scrollLeft - thisMove <= 0) {
                this.scrollContDiv.scrollLeft = this.listDiv01.scrollWidth + this.scrollContDiv.scrollLeft - thisMove
            } else {
                this.scrollContDiv.scrollLeft += thisMove
            }
        };
        num -= thisMove;
        if (Math.abs(num) == 0) {
            _state = "ready";
            if (this.autoPlay) {
                this.play()
            };
            this.accountPageIndex();
            return
        } else {
            this.accountPageIndex();
            setTimeout("ScrollPic.childs[" + this.ID + "].move(" + num + "," + quick + ")", this.speed)
        }
    };
    this.next = function () {
        if (_state != "ready") {
            return
        };
        _state = "stoping";
        this.move(this.pageWidth, true)
    };
    this.play = function () {
        if (!this.autoPlay) {
            return
        };
        clearInterval(_autoTimeObj);
        _autoTimeObj = setInterval("ScrollPic.childs[" + this.ID + "].next()", this.autoPlayTime * 1000)
    };
    this.stop = function () {
        clearInterval(_autoTimeObj)
    };
    this.pageTo = function (num) {
        if (_state != "ready") {
            return
        };
        _state = "stoping";
        var fill = num * this.frameWidth - this.scrollContDiv.scrollLeft;
        this.move(fill, true)
    };
    this.accountPageIndex = function () {
        this.pageIndex = Math.round(this.scrollContDiv.scrollLeft / this.frameWidth);
        if (this.pageIndex > Math.round(this.listDiv01.offsetWidth / this.frameWidth + 0.4) - 1) {
            this.pageIndex = 0
        };
        var i;
        for (i = 0; i < this.dotObjArr.length; i++) {
            if (i == this.pageIndex) {
                this.dotObjArr[i].className = this.dotClassName
            } else {
                this.dotObjArr[i].className = this.dotOnClassName
            }
        }
    }
};