FD.widget.specSidePop = function (id,cfg){
this.init(id,cfg);
}
FD.widget.specSidePop.prototype = {
init : function (id,cfg){
XDragDropCtrl.sort("EListnew","EListnewfirst",paramArr);
this.config = FD.common.applyIf(cfg||{}, FD.widget.specSidePop.defConfig);
this.config.floatwindowObj = FYG(id);
FYD.setStyle(FYG('supplybox'),'display','block');
if(this.config.priorityStyle == 1)
{
FYD.setStyle(FYG('ecustomerboxFF'),'display','none');
FYD.setStyle(FYG('ecustomerbox'),'display','block');
this.config.browser = 1;
}
else if(YAHOO.env.ua.ie == 0)
{
/*��ie��FF����*/
if (!this.config.isUserWhiteList) {
this.config.browser = 0;
FYD.setStyle(FYG('ecustomerbox'),'display','none');
FYD.setStyle(FYG('ecustomerboxFF'),'display','block');
}
else {
this.config.browser = 1;
FYD.setStyle(FYG('ecustomerbox'),'display','block');
FYD.setStyle(FYG('ecustomerboxFF'),'display','none');
}
}
else
{
if(Alitalk.isInstallAltalk() || this.config.isUserWhiteList) {
this.config.browser = 1;
FYD.setStyle(FYG('ecustomerbox'),'display','block');
FYD.setStyle(FYG('ecustomerboxFF'),'display','none');
}
else {
/*û��װ������FF����*/
this.config.browser = 0;
FYD.setStyle(FYG('ecustomerbox'),'display','none');
FYD.setStyle(FYG('ecustomerboxFF'),'display','block');
}
}
this.config.topPos = this.setInitPos(this.config.floatwindowObj,this.config.posType,this.config.browser,this.config.needshowSupply);
/*supplyStyleΪ0����ʼ�رգ�Ϊ1��չ��*/
if(this.config.supplyStyle == 0)
{
this.config.supplyWidth = 23;
}
else
{
this.config.supplyWidth = 222;
FYD.removeClass(FYG('supplybutton'),'supplybuttonmin');
FYD.addClass(FYG('supplybutton'),'supplybuttonmax');
}
if(this.config.ecustomerStyle == 0)
{
this.config.ecustomerWidth = 23;
}
else
{
this.config.ecustomerWidth = 222;
if(this.config.browser == 0)
{
/*FF*/
FYD.removeClass(FYG('ecustomerbuttonFF'),'ecustomerbuttonminFF');
FYD.addClass(FYG('ecustomerbuttonFF'),'ecustomerbuttonmaxFF');
}
else
{
FYD.removeClass(FYG('ecustomerbutton'),'ecustomerbuttonmin');
FYD.addClass(FYG('ecustomerbutton'),'ecustomerbuttonmax');
}
}
this.config.supplyTempWidth = this.config.totalWidth-this.config.supplyWidth;
this.config.ecustomerTempWidth = this.config.totalWidth-this.config.ecustomerWidth;
FYD.setStyle(FYG('supplybox'),'width',this.config.supplyWidth+'px');
FYD.setStyle(FYG('ecustomerbox'),'width',this.config.supplyWidth+'px');
FYD.setStyle(FYG('ecustomerboxFF'),'width',this.config.supplyWidth+'px');
FYE.addListener(FYG('supplybutton'),'click',this.showSupply,this,true);
FYE.addListener(FYG('ecustomerbutton'),'click',this.showeCustomerbox,this,true);
FYE.addListener(FYG('ecustomerbuttonFF'),'click',this.showeCustomerbox,this,true);
FYE.addListener(FYG('leaveWord'),'click',this.showeOthersugestion);
var otherInputArr = FYD.getElementsByClassName('name','LI',FYG('ECScontent'));
for(var i = 0; i < otherInputArr.length;i++)
{
FYD.setStyle(otherInputArr[i],'display','none');
}
FYD.setStyle(FYD.getElementsByClassName('submit','LI',FYG('ECScontent'))[0],'display','none');
if(YAHOO.env.ua.ie == 6)
{
FYE.addListener(window,'scroll',this.scrollwindow,this,true);
}
FYE.addListener(window,'resize',this.windowresize,this,true);
if(this.config.needshowSupply == 0)
{
FYD.setStyle(FYG('supplybox'),'display','none');
FYD.setStyle(FYG('supplybutton'),'display','none');
}
},
setInitPos : function(floatwindowObj,posType,browserType,needshowSupply){
var topPos;
var screenHeight = FYD.getViewportHeight();
var ObjHeight = 0;
if(browserType == 0)
{
/*FF*/
if(needshowSupply == 1)
{
//ObjHeight = FYG('supplybox').offsetHeight+FYG('ecustomerautodivFF').offsetHeight+21;
//290ΪFYG('ecustomerautodivFF')��offsetHeight��������Щ���������ֵ��䣬���Բ��÷���ȥȡ������ֱ�Ӹ�ֵ
ObjHeight = FYG('supplybox').offsetHeight+290+21;
}
else
{
//ObjHeight = FYG('ecustomerautodivFF').offsetHeight+21;
//290ΪFYG('ecustomerautodivFF')��offsetHeight��������Щ���������ֵ��䣬���Բ��÷���ȥȡ������ֱ�Ӹ�ֵ
ObjHeight = 290+21;
}
}
else
{
/*IE*/
if(needshowSupply == 1)
{
ObjHeight = FYG('supplybox').offsetHeight+90+FYG('ecustomerautodiv').offsetHeight;
}
else
{
ObjHeight = 90+FYG('ecustomerautodiv').offsetHeight;
}
}
if(posType == 0)
{
topPos = (screenHeight-ObjHeight)/2;/*��ֱ������ʾ*/
}
else
{
topPos = screenHeight-ObjHeight;/*��ֱ�õ���ʾ*/
if(browserType == 0)
{
topPos -=2;
}
}
if(YAHOO.env.ua.ie == 6)
{
FYD.setStyle(floatwindowObj,'top',topPos+FYD.getDocumentScrollTop()+'px');
}
else
{
FYD.setStyle(floatwindowObj,'top',topPos+'px');
}
return topPos;
},
showSupply : function (){
var _this = this;
(function _showSupply(){
if(_this.config.supplyStyle == 0)
{
_this.config.supplyTempWidth -=20;
if(_this.config.supplyTempWidth < 0)
{
_this.config.supplyTempWidth = 0;
window.clearTimeout(_this.config.supplyTimer);
_this.config.supplyStyle = 1;
FYD.setStyle(FYG('supplybox'),'width',_this.config.totalWidth-_this.config.supplyTempWidth+'px');
FYD.removeClass(FYG('supplybutton'),'supplybuttonmin');
FYD.addClass(FYG('supplybutton'),'supplybuttonmax');
return;
}
FYD.setStyle(FYG('supplybox'),'width',_this.config.totalWidth-_this.config.supplyTempWidth+'px');
_this.config.supplyTimer = window.setTimeout(_showSupply,10);
}
else
{
_this.config.supplyTempWidth +=20;
if(_this.config.supplyTempWidth > _this.config.totalWidth-_this.config.supplyButtonWidth)
{
_this.config.supplyTempWidth = _this.config.totalWidth-_this.config.supplyButtonWidth;
window.clearTimeout(_this.config.supplyTimer);
_this.config.supplyStyle = 0;
FYD.setStyle(FYG('supplybox'),'width',_this.config.totalWidth-_this.config.supplyTempWidth+'px');
FYD.removeClass(FYG('supplybutton'),'supplybuttonmax');
FYD.addClass(FYG('supplybutton'),'supplybuttonmin');
return;
}
FYD.setStyle(FYG('supplybox'),'width',_this.config.totalWidth-_this.config.supplyTempWidth+'px');
_this.config.supplyTimer = window.setTimeout(_showSupply,10);
}
})();
},
showeCustomerbox : function(){
if (window.__itbu_WebIM_unReadMsg_status__) {
try {
return window.__itbu_removeUnReadMsgTips__();
} catch(e) {}
}
var _this = this;
(function _showeCustomerbox(){
var showObj;
var parentDiv = YAHOO.util.Dom.get('ecustomerbd');
FYD.setStyle('brmms-pop-e'+parentDiv.getAttribute('curidx'),'visibility','hidden');
if(_this.config.browser == 0)
{
showObj = FYG('ecustomerboxFF');
}
else
{
showObj = FYG('ecustomerbox');
}
if(_this.config.ecustomerStyle == 0)
{
_this.config.ecustomerTempWidth -=20;
if(_this.config.ecustomerTempWidth < 0)
{
_this.config.ecustomerTempWidth = 0;
window.clearTimeout(_this.config.ecustomerTimer);
_this.config.ecustomerStyle = 1;
FYD.setStyle(showObj,'width',_this.config.totalWidth-_this.config.ecustomerTempWidth+'px');
if(_this.config.browser == 0)
{
/*FF*/
FYD.removeClass(FYG('ecustomerbuttonFF'),'ecustomerbuttonminFF');
FYD.addClass(FYG('ecustomerbuttonFF'),'ecustomerbuttonmaxFF');
}
else
{
FYD.removeClass(FYG('ecustomerbutton'),'ecustomerbuttonmin');
FYD.addClass(FYG('ecustomerbutton'),'ecustomerbuttonmax');
}
return;
}
FYD.setStyle(showObj,'width',_this.config.totalWidth-_this.config.ecustomerTempWidth+'px');
_this.config.ecustomerTimer = window.setTimeout(_showeCustomerbox,10);
}
else
{
_this.config.ecustomerTempWidth +=20;
if(_this.config.ecustomerTempWidth > _this.config.totalWidth-_this.config.ecustomerButtonWidth)
{
_this.config.ecustomerTempWidth = _this.config.totalWidth-_this.config.ecustomerButtonWidth;
window.clearTimeout(_this.config.ecustomerTimer);
_this.config.ecustomerStyle = 0;
FYD.setStyle(showObj,'width',_this.config.totalWidth-_this.config.ecustomerTempWidth+'px');
if(_this.config.browser == 0)
{
/*FF*/
FYD.removeClass(FYG('ecustomerbuttonFF'),'ecustomerbuttonmaxFF');
FYD.addClass(FYG('ecustomerbuttonFF'),'ecustomerbuttonminFF');
}
else
{
FYD.removeClass(FYG('ecustomerbutton'),'ecustomerbuttonmax');
FYD.addClass(FYG('ecustomerbutton'),'ecustomerbuttonmin');
}
return;
}
FYD.setStyle(showObj,'width',_this.config.totalWidth-_this.config.ecustomerTempWidth+'px');
_this.config.ecustomerTimer = window.setTimeout(_showeCustomerbox,10);
}
})();
},
showeOthersugestion : function(){
var otherInputArr = FYD.getElementsByClassName('name','LI',FYG('ECScontent'));
for(var i = 0; i < otherInputArr.length;i++)
{
FYD.setStyle(otherInputArr[i],'display','block')
}
FYD.setStyle(FYD.getElementsByClassName('submit','LI',FYG('ECScontent'))[0],'display','block');
},
windowresize : function(){
var _this = this;
(function _windowresize(){
_this.config.topPos = _this.setInitPos(_this.config.floatwindowObj,_this.config.posType,_this.config.browser,_this.config.needshowSupply);
if (window.__itbu_WebIM_setPosition__) {
try { window.__itbu_WebIM_setPosition__(); } catch(e) {}
}
})();
},
scrollwindow : function(){
var _this = this;
(function _scrollwindow(){
FYD.setStyle(_this.config.floatwindowObj,'top',FYD.getDocumentScrollTop()+_this.config.topPos+'px');
FYD.setStyle(_this.config.floatwindowObj,'right',-1+'px');
if (window.__itbu_WebIM_setPosition__) {
try { window.__itbu_WebIM_setPosition__(); } catch(e) {}
}
})();
}
}
/* Ĭ�ϲ������� */
FD.widget.specSidePop.defConfig = {
priorityStyle : 0,    /*priorityStyle���Ϊ1����ʾ�ⲿ�������һ����ie�ķ�ʽ��ʾ��Ĭ��Ϊ0*/
browser : 1,          /*1��ʾ��ie��0��ʾ��ie*/
floatwindowObj : null,
topPos : 0 ,
totalWidth : 222,
needshowSupply : 1,     /*����Ҫչʾ������ģ�顣1��ʾչʾ��0��ʾ��չʾ��*/
supplyStyle : 0,					/*supplyĬ�Ϲر�*/
supplyWidth : 23,
supplyButtonWidth : 23,   /*supply��ť�Ŀ��*/
supplyTempWidth : 0,			/*�˶�������supply��ȵ��м���*/
supplyTimer : 0,
ecustomerStyle : 0,				/*ecustomerĬ�Ϲر�*/
ecustomerWidth : 23,
ecustomerButtonWidth : 23,  /*ecustomer��ť�Ŀ��*/
ecustomerTempWidth : 0,    /*�˶�������ecustomer��ȵ��м���*/
ecustomerTimer : 0,
posType : 0,            /*0��ʾ��ֱ���У�1��ʾ�õ�*/
showType : 1            /*1��ʾװ��������IE��0��ʾFF����ûװ������IE*/
};
/**
* specSidePoper �ķ�װ��������ͬ�� SidePop ����
*/
FD.widget.specSidePoper = new function() {
this.init = function(id,cfg) {
return new FD.widget.specSidePop(id, cfg);
};
};
