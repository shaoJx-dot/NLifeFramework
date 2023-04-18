var DLG = {
    show : function(options){
		options.SetTopWindow = window;//调用弹窗的页面window对象，本页为window，顶层为top，父页为parent
		options.rang = true;//弹窗是否限制在页面内
		
		var d = new J.ui.dialog(options);
		d.ShowDialog();
		return d;
	}
};

