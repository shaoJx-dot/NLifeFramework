using System;
using System.Windows.Forms;
using DevComponents.DotNetBar;

namespace NLife.Core
{
    public class TabPageHelper
    {
        /// <summary>
        /// 创建新的选项卡
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">e</param>
        /// <param name="controlHelper">ControlHelper实体类</param>
        /// <param name="tabControl">主窗体tabControl控件</param>
        /// <param name="tabName">新选项卡属性Name</param>
        /// <param name="showName">新选项卡显示的中文名</param>
        public static void CreateTab(object sender, EventArgs e,
            ControlHelper controlHelper, DevComponents.DotNetBar.TabControl tabControl,
            string tabName,string showName)
        {
            //如果存在该选项卡
            if (tabControl.Tabs[tabName] != null)
            {
                //跳转到该选项卡
                if (!tabControl.Tabs[tabName].IsSelected)
                {
                    tabControl.SelectedTab = tabControl.Tabs[tabName];
                }
                return;
            }

            using (TabItem newTab = tabControl.CreateTab(showName))
            {
                newTab.Name = tabName;
                newTab.Tag = controlHelper;

                newTab.MouseUp += new System.Windows.Forms.MouseEventHandler(tabItem_MouseUp); //右键菜单
                //newTab.Click += new EventHandler(newTab_Click); //双击
                TabControlPanel panel = (TabControlPanel)newTab.AttachedControl;

                Type t = System.Reflection.Assembly.LoadFrom(controlHelper.RunPath + controlHelper.AssemblyName + ".dll")
                    .GetType(controlHelper.NameSpace + "." + controlHelper.FromCode);
                if (t == null)
                {
                    MessageBox.Show("模块不存在，请联系管理员！", "温馨提示：");
                    tabControl.Tabs.Remove(newTab);
                    tabControl.Controls.Remove(newTab.AttachedControl);
                    tabControl.RecalcLayout();
                    return;
                }
                Form obj = (Form)Activator.CreateInstance(t, new object[] { controlHelper });
                obj.TopLevel = false;
                obj.Text = controlHelper.FromName;
                obj.Dock = DockStyle.Fill;
                obj.FormBorderStyle = FormBorderStyle.None;
                //form.Opacity = 10;
                obj.Show();
                panel.Tag = obj;
                panel.Controls.Add(obj);
                tabControl.SelectedTab = newTab;
                tabControl.RecalcLayout();
            }
        }

        private static void newTab_Click(object sender, EventArgs e)
        {
            //if (e.Clicks < 2 && !this.CurrentCell.IsInEditMode)
            //{
            //    this.EndEdit();
            //}
        }

        private static void tabItem_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                // 视图右击
                if (sender is DevComponents.DotNetBar.TabItem)
                    TabPageMouseUp(sender, e);
            }
        }

        private static void TabPageMouseUp(object sender, MouseEventArgs e)
        {
            DevComponents.DotNetBar.TabItem tabPage = sender as DevComponents.DotNetBar.TabItem;
            if (tabPage.Tag != null)
            {
                ButtonItem btnItemCLose = (tabPage.Tag as ControlHelper).ContextMenuBtn;
                foreach (ButtonItem item in btnItemCLose.SubItems)
                {
                    item.Tag = tabPage.Name;
                }
                ShowContextMenu((tabPage.Tag as ControlHelper).ContextMenuBtn);
            }
        }

        /// <summary>
        /// 显示给定的上下文菜单
        /// </summary>
        /// <param name="cm">显示的ContextMenu</param>
        private static void ShowContextMenu(ButtonItem cm)
        {
            cm.Popup(System.Windows.Forms.Control.MousePosition);
        }


    }
}
