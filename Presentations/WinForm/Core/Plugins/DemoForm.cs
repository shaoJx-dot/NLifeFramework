using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using NLife.Core.Menu;

namespace NLife.Core.Plugins
{
    //插件DEMO实例
    public partial class DemoForm : Form
    {
        public DemoForm()
        {
            InitializeComponent();
        }

    }

    //
    public class DemoFormLoader : PluginEngine.Plugin
    {
        DemoForm m_demoForm = null;
        //菜单项
        MenuItem m_MenuItem;
        MenuButton m_ToolbarItem;
        

        public override void Load()
        {
                
                m_MenuItem = new MenuItem("插件示例程序");
                m_MenuItem.Click += new EventHandler(menuItemClicked);
                ParentApplication.PluginMenu.MenuItems.Add(m_MenuItem);

                m_demoForm = new DemoForm();//ParentApplication, m_MenuItem
                m_demoForm.TopLevel = false;
                m_demoForm.Parent = ParentApplication.ContentPanel;
                m_demoForm.WindowState = FormWindowState.Maximized;
                m_demoForm.FormBorderStyle = FormBorderStyle.None;

                m_ToolbarItem = new MenuButton(
                    "测试插件",
                    System.Windows.Forms.Application.StartupPath + "\\国信司南.JPG",
                    m_demoForm);
                
                ParentApplication.MenuBar.AddMenuButton(m_ToolbarItem);

                base.Load();
        }

        public override void Unload()
        {
            if (m_demoForm != null)
            {
                m_demoForm.Dispose();
                m_demoForm = null;
                ParentApplication.PluginMenu.MenuItems.Remove(m_MenuItem);
                ParentApplication.MenuBar.RemoveMenuButton(m_ToolbarItem);
            }

            base.Unload();
        }

        private void menuItemClicked(object sender, System.EventArgs e)
        {
            if (m_demoForm.Visible)
            {
                m_demoForm.Visible = false;
                m_MenuItem.Checked = false;
            }
            else
            {
                m_demoForm.Visible = true;
                m_MenuItem.Checked = true;
            }
        }
 
    }
}
