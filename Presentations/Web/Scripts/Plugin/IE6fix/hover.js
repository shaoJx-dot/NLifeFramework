
// 浏览器版本判断
var Client = {
	Engine: {'name': 'unknown', 'version': ''},
	Features: {}
};
Client.Features.xhr = !!(window.XMLHttpRequest);
Client.Features.xpath = !!(document.evaluate);
if (window.opera) Client.Engine.name = 'opera';
else if (window.ActiveXObject) Client.Engine = {'name': 'ie', 'version': (Client.Features.xhr) ? 7 : 6};
else if (!navigator.taintEnabled) Client.Engine = {'name': 'webkit', 'version': (Client.Features.xpath) ? 420 : 419};
else if (document.getBoxObjectFor != null) Client.Engine.name = 'gecko';
Client.Engine[Client.Engine.name] = Client.Engine[Client.Engine.name + Client.Engine.version] = true;

// 获取单个对象
function hoverEffectSingle(e){
	var pr=document.getElementById(e);
	pr.onmouseover = function () {
	    this.tmpClass = this.className;
	    this.className += " hover";
	}
	pr.onmouseout=function(){
		this.className=this.tmpClass;
	}
}

// 获取多个子对象
function hoverEffectMultiple(e){
	var pr=document.getElementById(e).getElementsByTagName("li");
	for(var i=0;i<pr.length;i++){
		pr[i].onmouseover=function(){
			this.tmpClass=this.className;
			this.className+=" hover";
		}
		pr[i].onmouseout=function(){
			this.className=this.tmpClass;
		}
	}
}

// 让所有标记支持hover
function hoverEffect(){
	var obj=document.all;
	for(var i=0;i<obj.length;i++){
		obj[i].onmouseover=function(){
			this.tmpClass=this.className;
			this.className+=" hover";
		}
		obj[i].onmouseout=function(){
			this.className=this.tmpClass;
		}
	}
}
