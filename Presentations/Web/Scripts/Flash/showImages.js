     var focus_width=896; 
     var focus_height=200;
     var text_height=0;
     var swf_height = focus_height+text_height;
     var pics;  
     var links; 
     var texts;
     function showImages()
     {
     document.write('<object classid="clsid:d27cdb6e-ae6d-11cf-96b8-444553540000" codebase="http://fpdownload.macromedia.com/pub/shockwave/cabs/flash/swflash.cab#version=6,0,0,0" width="'+ focus_width +'" height="'+ swf_height +'">');
     document.write('<param name="allowScriptAccess" value="sameDomain"><param name="movie" value="/Scripts/Flash/pixviewer.swf"><param name="quality" value="high"><param name="bgcolor" value="#FBE0C4">');
     document.write('<param name="menu" value="false"><param name=wmode value="opaque">');          
     document.write('<param name="FlashVars" value="pics='+pics+'&links='+links+'&texts='+texts+'&borderwidth='+this.focus_width+'&borderheight='+this.focus_height+'&textheight='+this.text_height+'">');
     document.write('<embed src="/Scripts/Flash/pixviewer.swf" wmode="opaque" FlashVars="pics=' + pics + '&links=' + links + '&texts=' + texts + '&borderwidth=' + this.focus_width + '&borderheight=' + this.focus_height + '&textheight=' + this.text_height + '" menu="false" bgcolor="#FFFFFF" quality="high" width="' + this.focus_width + '" height="' + this.focus_height + '" allowScriptAccess="sameDomain" type="application/x-shockwave-flash" pluginspage="http://www.macromedia.com/go/getflashplayer" />'); 
     document.write('</object>');
     }
