using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using System.Drawing;

namespace NLife.Core.Menu
{
     public  class MenuBar
    {
         //保存插件按钮菜单项
         public ArrayList PlugArrList;
        private ListView PluginMenuList;
        private  ImageList _imageList;
        ListViewItem listItem;
        MenuButton _menuBtn;
         public MenuBar( ListView pMenuList,ImageList imageList)
         {
             PluginMenuList = pMenuList;
             _imageList = imageList;
             PlugArrList = new ArrayList();
         }

         //添加插件按钮
         public void AddMenuButton(MenuButton pMenuBar)
         {
             //菜单图像
             Image image = Image.FromFile(pMenuBar.IconFilePath);
             _imageList.Images.Add(image);
             _menuBtn = pMenuBar;
             listItem = new ListViewItem(pMenuBar.MenuName);
             PluginMenuList.Items.Add(listItem);
             listItem.ImageIndex = listItem.Index;

             PlugArrList.Add(_menuBtn);
             //listItem2 = new ListViewItem(pMenuBar.MenuName);
             //PluginMenuList.Items.Add(listItem2);
             //listItem2.ImageIndex = listItem2.Index;            
         }

         //添加插件按钮
         public void RemoveMenuButton(MenuButton pMenuBar)
         {
             int intPosition = PlugArrList.IndexOf(pMenuBar);
             PlugArrList.Remove(pMenuBar);
             _imageList.Images.RemoveAt(intPosition);
             PluginMenuList.Items.RemoveAt(intPosition);
         }
    }
}
