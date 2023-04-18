
//通过样式取元素
var getObjCls = function (className, tagName) {
    var ele = [], all = document.getElementsByTagName(tagName || "*");
    for (var i = 0; i < all.length; i++) {
        if (all[i].className.match(new RegExp('(\\s|^)' + className + '(\\s|$)'))) {
            
            ele[ele.length] = all[i];
        }
    }
    return ele;
};


/******************************以下工具包******************************/

String.prototype.trim = function () {
    return this.replace(/(^\s*)|(\s*$)/g, "");
}
String.prototype.lTrim = function () {
    return this.replace(/(^\s*)/g, "");
}
String.prototype.rTrim = function () {
    return this.replace(/(\s*$)/g, "");
}

// 说明：检测、添加、移除、切换、改变 className
// 作者：lovton
var Dom = {
    returnObj: function (param) {
        var objSelect;
        if (typeof (param) === "string") {
            objSelect = document.getElementById(param);
        } else if (typeof (param) === "object") {
            objSelect = param;
        } else {
            objSelect = null;
        }
        return objSelect;
    },
    // 获取对象
    getObj: function (objName) {
        if (document.getElementById) {
            return eval('document.getElementById("' + objName + '")')
        } else {
            return eval('document.all.' + objName)
        }
    },
    isIE: navigator.appVersion.indexOf("MSIE") != -1 ? true : false,
    addEvent: function (l, i, I) {
        if (l.attachEvent) {
            l.attachEvent("on" + i, I);
        } else {
            l.addEventListener(i, I, false);
        }
    },
    delEvent: function (l, i, I) {
        if (l.detachEvent) {
            l.detachEvent("on" + i, I);
        } else {
            l.removeEventListener(i, I, false);
        }
    },
    // 遍历
    each: function (a, b) {
        for (var i = 0, len = a.length; i < len; i++) b(a[i], i);
    },
    // 事件绑定
    bind: function (obj, type, fn) {
        if (obj.attachEvent) {
            obj['e' + type + fn] = fn;
            obj[type + fn] = function () { obj['e' + type + fn](window.event); }
            obj.attachEvent('on' + type, obj[type + fn]);
        } else {
            obj.addEventListener(type, fn, false);
        };
    },
    // 移除事件
    unbind: function (obj, type, fn) {
        if (obj.detachEvent) {
            try {
                obj.detachEvent('on' + type, obj[type + fn]);
                obj[type + fn] = null;
            } catch (_) { };
        } else {
            obj.removeEventListener(type, fn, false);
        };
    },
    hasClass: function (ele, cls) {
        return ele.className.search(new RegExp("(\\s|^)" + cls + "(\\s|$)")) > -1;
    },
    addClass: function (ele, cls) {
        if (!this.hasClass(ele, cls)) {
            ele.className += " " + cls;
        }
    },
    removeClass: function (ele, cls) {
        if (this.hasClass(ele, cls)) {
            var reg = new RegExp("(\\s|^)" + cls + "(\\s|$)");
            ele.className = ele.className.replace(reg, " ");
        }
    },
    toggleClass: function (ele, cls) {
        if (this.hasClass(ele, cls)) {
            this.removeClass(ele, cls);
        }
        else {
            this.addClass(ele, cls);
        }
    },
    changeClass: function (ele, oldcls, newcls) {
        if (!this.hasClass(ele, newcls)) {
            if (this.hasClass(ele, oldcls)) {
                this.removeClass(ele, oldcls);
            }
            this.addClass(ele, newcls);
        }
    }
};

var Tool = {
    /* 
    * 功能：加入收藏
    * 使用示例： href="javascript:tool.addFavorite()"
    */
    addFavorite: function () {
        var fName = document.title;
        var url = location.href;
        if (fName == null) {
            var t_titles = document.getElementByTagName("title");
            if (t_titles && t_titles.length > 0) {
                fName = t_titles[0];
            } else {
                fName = "";
            }
        }
        if (document.all) {
            window.external.addFavorite(url, fName);
        } else if (window.sidebar) {
            window.sidebar.addPanel(fName, url, "");
        }
    },
    /* 
    * 功能：设为首页
    * 使用示例：href="javascript:tool.setHomepage('http://www.dovsoft.com')"
    */
    setHomepage: function (url) {
        if (document.all) {
            document.body.style.behavior = 'url(#default#homepage)';
            document.body.setHomePage(url);

        } else if (window.sidebar) {
            if (window.netscape) {
                try {
                    netscape.security.PrivilegeManager
						    .enablePrivilege("UniversalXPConnect");
                } catch (e) {
                    alert("该操作被浏览器拒绝，如果想启用该功能，请在地址栏内输入 about:config,然后将项 signed.applets.codebase_principal_support 值该为true");
                }
            }
            var prefs = Components.classes['@mozilla.org/preferences-service;1']
				    .getService(Components.interfaces.nsIPrefBranch);
            prefs.setCharPref('browser.startup.homepage', url);
        }
    },
    setCookie: function (name, value, days) {
        var Days = 365; //此 cookie 将被保存 365 天
        if (parseInt(days) > 0) {
            Days = parseInt(days);
        }

        var exp = new Date();    //new Date("December 31, 9998");
        exp.setTime(exp.getTime() + Days * 24 * 60 * 60 * 1000);
        document.cookie = name + "=" + escape(value) + ";expires=" + exp.toGMTString();
    },
    getCookie: function (name) {
        var arr = document.cookie.match(new RegExp("(^| )" + name + "=([^;]*)(;|$)"));
        if (arr != null) return unescape(arr[2]); return null;
    },
    delCookie: function (name) {
        var exp = new Date();
        exp.setTime(exp.getTime() - 1);
        var cval = getCookie(name);
        if (cval != null) document.cookie = name + "=" + cval + ";expires=" + exp.toGMTString();
    },
    rand: function rand(number) {
        var rnd = {};
        rnd.today = new Date();
        rnd.seed = rnd.today.getTime();
        var ronDom = function () {
            rnd.seed = (rnd.seed * 9301 + 49297) % 233280;
            return rnd.seed / (233280.0);
        };
        return Math.ceil(ronDom() * number);
    },
    isNumber: function (str) {
        var mynumber = "0123456789";
        for (var i = 0; i < str.length; i++) {
            var c = str.charAt(i);
            if (mynumber.indexOf(c) == -1) {
                return false;
            }
        }
        return true;
    }
};


/*表单元素方法 by lovton*/
var Form = {
    select: {

        //判断select是否选项中value="paraValue"的Item
        isExitItem: function (param, objItemValue) {
            var objSelect = Dom.returnObj(param);
            var isExit = false;
            for (var i = 0; i < objSelect.options.length; i++) {
                if (objSelect.options[i].value == objItemValue) {
                    isExit = true;
                    break;
                }
            }
            return isExit;
        },
        //设置select中value值为选中
        setItemByValue: function (param, objItemText) {
            var objSelect = Dom.returnObj(param);

            //判断是否存在 
            var isExit = false;
            for (var i = 0; i < objSelect.options.length; i++) {
                if (objSelect.options[i].value == objItemText) {
                    objSelect.options[i].selected = true;
                    isExit = true;
                    break;
                }
            }
        },
        //向select选项中 加入一个Item
        addItem: function (param, objItemText, objItemValue) {
            var objSelect = Dom.returnObj(param);

            //判断是否存在 
            if (this.isExitItem(objSelect, objItemValue)) {
                return false;
            } else {
                var varItem = new Option(objItemText, objItemValue);
                objSelect.options.add(varItem);
                return true;
            }
        },
        /*取选中的值*/
        getItemValue: function (param) {
            var objSelect = Dom.returnObj(param);
            for (var i = 0; i < objSelect.length; i++) {
                if (objSelect.options[i].selected == true) {
                    return objSelect.options[i].value;
                }
            }
            return null;
        }
        /**End**/
    },
    checkbox: {
        checkAll: function (unknown, cName, hideObj) {
            var obj = Dom.returnObj(unknown);
            var checkboxs = document.getElementsByName(cName);
            for (var i = 0; i < checkboxs.length; i++) {
                checkboxs[i].checked = obj.checked;
            }
            this.getIdsByName(cName, hideObj);
        },
        getIdsByName: function (itemName, hideObj) {
            var obj = Dom.returnObj(hideObj);
            if (!obj) {
                return;
            }
            var ids = "";
            var checkboxs = document.getElementsByName(itemName);
            for (var i = 0; i < checkboxs.length; i++) {
                var parObj = checkboxs[i].parentNode.parentNode;/*给父元素加样式（特殊）*/
                if (checkboxs[i].checked == true) {
                    ids = ids + checkboxs[i].value + ",";
                    Dom.addClass(parObj, "cotent_selected"); /*特殊*/
                } else {
                    Dom.removeClass(parObj, "cotent_selected"); /*特殊*/
                }
            }
            if (ids.length > 0) {
                obj.value = ids.substring(0, ids.length - 1);
            } else {
                obj.value = "";
            }
        }
        /**End**/
    }
};



var fillHTML = function (el, HTMLString) {
    if (!el) return;
    if (window.ActiveXObject) { //For IE
        el.innerHTML = "<img style='display:none'/>" + HTMLString.replace(/<script([^>]*)>/ig, '<script$1 defer>');
        el.removeChild(el.firstChild)
    } else { //For Mozilla,Opare
        var nSibling = el.nextSibling;
        var pNode = el.parentNode;
        pNode.removeChild(el);
        el.innerHTML = HTMLString;
        pNode.insertBefore(el, nSibling)
    }
}
/* 
* 描述：跨浏览器的设置 innerHTML 方法 
* 允许插入的 HTML 代码中包含 script 和 style 
* 参数： 
* el: 合法的 DOM 树中的节点 
* htmlCode: 合法的 HTML 代码 
* 经测试的浏览器：ie5+, firefox1.5+, opera8.5+ 
*/
var setInnerHTML = function (el, htmlCode) {
    var ua = navigator.userAgent.toLowerCase();
    if (ua.indexOf('msie') >= 0 && ua.indexOf('opera') < 0) {
        htmlCode = '<div style="display:none">for IE</div>' + htmlCode;
        htmlCode = htmlCode.replace(/<script([^>]*)>/gi, '<script$1 defer="true">');
        el.innerHTML = htmlCode;
        el.removeChild(el.firstChild);
    } else {
        var el_next = el.nextSibling;
        var el_parent = el.parentNode;
        el_parent.removeChild(el);
        el.innerHTML = htmlCode;
        if (el_next) {
            el_parent.insertBefore(el, el_next)
        } else {
            el_parent.appendChild(el);
        }
    }
}
/* 
* 描述：通过重定义 document.write 函数，避免在使用 setInnerHTML 时， 
* 插入的 HTML 代码中包含 document.write ，导致原页面受到破坏的情况。 
*/
document.write = function () {
    var body = document.getElementsByTagName('body')[0];
    for (var i = 0; i < arguments.length; i++) {
        argument = arguments[i];
        if (typeof argument == 'string') {
            var el = body.appendChild(document.createElement('div'));
            setInnerHTML(el, argument)
        }
    }
}

/* 
* 描述：原生 Ajax 方法 
* 作者：lovton <lovton@163.com> 
* 日期：2011-08-20  
* 经测试的浏览器：ie6+, firefox6.0
* IE下无法用原生innerHTML取返回的内容
*/
var Util = {};
Util.setXmlHttpObject = function () {
    try {
        Util.Ajax.destroy();
    } catch (e) { }
    if (window.XMLHttpRequest) {
        Util.xmlHttpRequest = new XMLHttpRequest;
    } else if (window.ActiveXObject) {
        var arrayV = new Array
        (
            "MSXML2.XMLHTTP.4.0",
            "MSXML2.XMLHTTP.3.0",
            "MSXML2.XMLHTTP.2.6",
            "Microsoft.XMLHTTP",
            "MSXML.XMLHTTP "
        );
        for (var i = 0; i < arrayV.length; i++) {
            try {
                Util.xmlHttpRequest = new ActiveXObject(arrayV[i]);
                return Util.xmlHttpRequest;
            } catch (e) { }
        }

    } else {
        Util.xmlHttpRequest = false;
    }
};
Util.Ajax = {
    requests: [],
    isIdlesse: true,
    open: function () {
        if (this.isIdlesse) {
            this.submit.apply(this, arguments);
        } else {
            this.requests.push(arguments);
        }
    },
    submit: function (strURL, transType, paramObj, callBackMethod, secondTime) {
        Util.Ajax.isIdlesse = false;
        Util.Ajax.time = null;
        Util.Ajax.callBack = null;
        var strs = [];
        strs.push(((strURL.indexOf("?") > -1) ? "&r=" : "?r=") + Math.random(1000));
        transType = String(transType).toUpperCase() == "GET" ? "GET" : "POST";
        if (paramObj) {
            if (typeof (paramObj) === "string") {
                strs.push(paramObj);
            } else {
                for (var n in paramObj) {
                    strs.push(n + "=" + encodeURIComponent(paramObj[n]));
                }
            }
        }
        var parameterStr = strs.join("&");
        Util.setXmlHttpObject();
        //alert(strURL + ":" + transType + ":" + paramObj + ":" + callBackMethod + ":" + secondTime );
        if (transType == "POST") {
            Util.xmlHttpRequest.open("POST", strURL, true);
            Util.xmlHttpRequest.setRequestHeader("Method", "POST " + strURL + " HTTP/1.1");
            Util.xmlHttpRequest.setRequestHeader("Content-Type", "application/x-www-form-urlencoded");
            parameterStr = parameterStr.replace(/[\\x00-\\x08\\x11-\\x12\\x14-\\x20]/g, "*");
        } else {
            Util.xmlHttpRequest.open("GET", strURL + parameterStr, true);
            parameterStr = null;
        }
        if (Util.xmlHttpRequest.overrideMimeType) {
            Util.xmlHttpRequest.overrideMimeType('text/xml');
        }
        Util.Ajax.callBack = callBackMethod;
        Util.xmlHttpRequest.onreadystatechange = Util.Ajax.onreadystatechange;
        Util.xmlHttpRequest.send(parameterStr);
        if (callBackMethod && secondTime) {
            Util.Ajax.time = setTimeout(Util.Ajax.abortNext, secondTime * 1000);
        }
    },
    onreadystatechange: function () {
        if (Util.xmlHttpRequest.readyState == 4) {
            try {
                var xml = false;
                var text = false;
                if (Util.Ajax.callBack) {
                    if (Util.Ajax.time) {
                        clearTimeout(Util.Ajax.time);
                    }
                    if (Util.xmlHttpRequest.status == 200) {
                        try {
                            text = eval("(" + Util.xmlHttpRequest.responseText + ")");
                        } catch (ex) {
                            text = Util.xmlHttpRequest.responseText;
                        }

                    } else {
                        if (Util.xmlHttpRequest.status == "402") {
                            try {
                                //__Global.noRights();出错
                            } catch (e) { }
                        }
                    }
                    Util.Ajax.callBack(text);
                }
                Util.Ajax.onReady();
            } catch (e) {
                Util.Ajax.onReady();
            }
        }
    },
    abortNext: function () {
        Util.xmlHttpRequest.abort();
        Util.Ajax.callBack(false);
        Util.Ajax.onReady();
    },
    onReady: function () {
        Util.Ajax.isIdlesse = true;
        if (Util.Ajax.requests.length > 0) {
            Util.Ajax.submit.apply(Util.Ajax, Util.Ajax.requests.shift());
        }
    },
    destroy: function () {
        Util.xmlHttpRequest = null;
        delete Util.xmlHttpRequest;
    }
};