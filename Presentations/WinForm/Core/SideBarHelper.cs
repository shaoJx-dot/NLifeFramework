using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevComponents.DotNetBar;
using System.Drawing;

namespace NLife.Core
{
    public class SideBarHelper
    {
        public static DevComponents.DotNetBar.SideBar CreateSideBar(DevComponents.DotNetBar.ItemPanel itemPanelLeft,string sideBarName)
        {
            DevComponents.DotNetBar.SideBar sideBar = new DevComponents.DotNetBar.SideBar();
            sideBar.Visible = false;
            sideBar.AccessibleRole = System.Windows.Forms.AccessibleRole.ToolBar;
            sideBar.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            sideBar.Appearance = DevComponents.DotNetBar.eSideBarAppearance.Flat;
            sideBar.BackColor = System.Drawing.Color.White;
            sideBar.ColorScheme.ItemCheckedBackground = System.Drawing.Color.Empty;
            sideBar.ColorScheme.ItemExpandedBackground = System.Drawing.Color.FromArgb(((int)(((byte)(144)))), ((int)(((byte)(156)))), ((int)(((byte)(187)))));
            sideBar.ColorScheme.ItemExpandedBackground2 = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(233)))), ((int)(((byte)(240)))));
            sideBar.ColorScheme.ItemExpandedShadow = System.Drawing.Color.Empty;
            sideBar.ColorScheme.ItemExpandedText = System.Drawing.SystemColors.ControlDarkDark;
            sideBar.ColorScheme.ItemHotBackground = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(233)))), ((int)(((byte)(240)))));
            sideBar.ColorScheme.ItemHotBackground2 = System.Drawing.Color.FromArgb(((int)(((byte)(144)))), ((int)(((byte)(156)))), ((int)(((byte)(187)))));
            sideBar.ColorScheme.ItemPressedBackground = System.Drawing.Color.FromArgb(((int)(((byte)(144)))), ((int)(((byte)(156)))), ((int)(((byte)(187)))));
            sideBar.ColorScheme.ItemPressedBackground2 = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(233)))), ((int)(((byte)(240)))));
            sideBar.ColorScheme.MenuSide = System.Drawing.Color.FromArgb(((int)(((byte)(246)))), ((int)(((byte)(245)))), ((int)(((byte)(244)))));
            sideBar.ColorScheme.MenuSide2 = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(217)))), ((int)(((byte)(211)))));
            sideBar.ExpandedPanel = null;
            sideBar.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            sideBar.ForeColor = System.Drawing.Color.Black;
            sideBar.Location = new System.Drawing.Point(1, 1);
            sideBar.Name = sideBarName;
            sideBar.Size = new System.Drawing.Size(195, 497);
            //sideBar.TabIndex = 10;
            sideBar.TabStop = false;
            sideBar.UsingSystemColors = true;

            itemPanelLeft.Controls.Add(sideBar);

            return sideBar;
        }

        /// <summary>
        /// 创建主窗体左边sideBarPanel(模块名)
        /// </summary>
        /// <param name="ctrl">ControlHelper实体类</param>
        /// <param name="sideBar">主窗体sideBar</param>
        /// <param name="moduleList">权限集合</param>
        public static void CreateSideBar(ControlHelper ctrl, DevComponents.DotNetBar.SideBar sideBar, List<SYS_Module> moduleList)
        {
            DevComponents.DotNetBar.BaseItem[] sideBarPanelItemArray = new DevComponents.DotNetBar.BaseItem[moduleList.Count];

            for (int i = 0; i < moduleList.Count; i++)
            {

                DevComponents.DotNetBar.SideBarPanelItem sideBarPanelItem = new DevComponents.DotNetBar.SideBarPanelItem();            

                sideBarPanelItem.BackgroundStyle.BackColor1.Color = System.Drawing.Color.FromArgb(((int)(((byte)(246)))), ((int)(((byte)(246)))), ((int)(((byte)(246)))));
                sideBarPanelItem.BackgroundStyle.BackColor2.Color = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
                sideBarPanelItem.BackgroundStyle.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
                sideBarPanelItem.BackgroundStyle.BorderColor.Color = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(45)))), ((int)(((byte)(150)))));
                sideBarPanelItem.BackgroundStyle.ForeColor.Color = System.Drawing.SystemColors.ControlText;
                sideBarPanelItem.HeaderHotStyle.BackColor1.Color = System.Drawing.Color.FromArgb(((int)(((byte)(135)))), ((int)(((byte)(173)))), ((int)(((byte)(228)))));
                sideBarPanelItem.HeaderHotStyle.BackColor2.Color = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(239)))), ((int)(((byte)(255)))));
                sideBarPanelItem.HeaderHotStyle.ForeColor.Color = System.Drawing.SystemColors.ControlText;
                sideBarPanelItem.HeaderHotStyle.GradientAngle = 90;
                sideBarPanelItem.HeaderSideHotStyle.BackColor1.Color = System.Drawing.Color.FromArgb(((int)(((byte)(135)))), ((int)(((byte)(173)))), ((int)(((byte)(228)))));
                sideBarPanelItem.HeaderSideHotStyle.BackColor2.Color = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(239)))), ((int)(((byte)(255)))));
                sideBarPanelItem.HeaderSideHotStyle.GradientAngle = 90;
                sideBarPanelItem.HeaderSideStyle.BackColor1.Color = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(237)))), ((int)(((byte)(254)))));
                sideBarPanelItem.HeaderSideStyle.BackColor2.Color = System.Drawing.Color.FromArgb(((int)(((byte)(142)))), ((int)(((byte)(179)))), ((int)(((byte)(231)))));
                sideBarPanelItem.HeaderSideStyle.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
                sideBarPanelItem.HeaderSideStyle.BorderColor.Color = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(45)))), ((int)(((byte)(150)))));
                sideBarPanelItem.HeaderSideStyle.BorderSide = ((DevComponents.DotNetBar.eBorderSide)(((DevComponents.DotNetBar.eBorderSide.Left | DevComponents.DotNetBar.eBorderSide.Top)
                            | DevComponents.DotNetBar.eBorderSide.Bottom)));
                sideBarPanelItem.HeaderSideStyle.GradientAngle = 90;
                sideBarPanelItem.HeaderStyle.BackColor1.Color = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(239)))), ((int)(((byte)(255)))));
                sideBarPanelItem.HeaderStyle.BackColor2.Color = System.Drawing.Color.FromArgb(((int)(((byte)(135)))), ((int)(((byte)(173)))), ((int)(((byte)(228)))));
                sideBarPanelItem.HeaderStyle.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
                sideBarPanelItem.HeaderStyle.BorderColor.Color = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(45)))), ((int)(((byte)(150)))));
                sideBarPanelItem.HeaderStyle.BorderSide = ((DevComponents.DotNetBar.eBorderSide)(((DevComponents.DotNetBar.eBorderSide.Right | DevComponents.DotNetBar.eBorderSide.Top)
                            | DevComponents.DotNetBar.eBorderSide.Bottom)));
                sideBarPanelItem.HeaderStyle.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
                sideBarPanelItem.HeaderStyle.ForeColor.Color = System.Drawing.SystemColors.ControlText;
                sideBarPanelItem.HeaderStyle.GradientAngle = 90;
                if (string.IsNullOrEmpty(moduleList[i].Icon))
                {
                    sideBarPanelItem.Icon = ((System.Drawing.Icon)HG.LibPic.Resources.ResourceManager.GetObject("iMac"));
                }
                else
                {
                    sideBarPanelItem.Icon = ((System.Drawing.Icon)HG.LibPic.Resources.ResourceManager.GetObject(moduleList[i].Icon));
                }
                
                sideBarPanelItem.LayoutType = DevComponents.DotNetBar.eSideBarLayoutType.MultiColumn;
                sideBarPanelItem.Name = moduleList[i].Code;
                sideBarPanelItem.Text = moduleList[i].Name;
                sideBarPanelItem.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near;
                /************************* PanelItem 结束 *************************/

                CreateMenu(ctrl, sideBarPanelItem, moduleList[i]);

                sideBarPanelItemArray[i] = sideBarPanelItem;

                
            }
            sideBar.Panels.AddRange(sideBarPanelItemArray);

            //sideBar.ResumeLayout(false);
            //ctrl.MainForm.ResumeLayout(false);
        }

        /// <summary>
        /// 创建主窗体sideBar的按钮
        /// </summary>
        /// <param name="ctrl">ControlHelper实体类</param>
        /// <param name="sideBarPanelItem">主窗体SideBarPanel</param>
        /// <param name="sys_Module">权限实例</param>
        public static void CreateMenu(ControlHelper ctrl, DevComponents.DotNetBar.SideBarPanelItem sideBarPanelItem, SYS_Module sys_Module)
        {
            if (sys_Module.MenuList == null)
            {
                return;
            }
            DevComponents.DotNetBar.BaseItem[] menuArray = new DevComponents.DotNetBar.BaseItem[sys_Module.MenuList.Count];

            for (int i = 0; i < sys_Module.MenuList.Count; i++)
            {
                DevComponents.DotNetBar.ButtonItem buttonItem = new DevComponents.DotNetBar.ButtonItem();
                buttonItem.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
                if (string.IsNullOrEmpty(sys_Module.MenuList[i].Icon))
                {
                    buttonItem.Image = global::HG.LibPic.Resources.Leopard_07;
                }
                else
                {
                    int index = sys_Module.MenuList[i].Icon.LastIndexOf('.');
                    string picName = string.Empty;
                    if (index != -1)
                    {
                        picName = sys_Module.MenuList[i].Icon.Substring(0, index);
                    }
                    else
                    {
                        picName = sys_Module.MenuList[i].Icon;
                    }
                    buttonItem.Image = ((System.Drawing.Image)HG.LibPic.Resources.ResourceManager.GetObject(picName));
                }
                //buttonItem.Image = global::HG.Core.Properties.Resources.Leopard_07; //图标资源(需修改)
                buttonItem.FixedSize = new System.Drawing.Size(70,70);
                buttonItem.ImageFixedSize = new System.Drawing.Size(48, 48);
                buttonItem.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
                buttonItem.Name = sys_Module.MenuList[i].Code;

                if (sys_Module.MenuList[i].Name.Length > 5)
                {
                    buttonItem.Text = sys_Module.MenuList[i].Name.Substring(0,5);
                    buttonItem.Tooltip = sys_Module.MenuList[i].Name;
                }
                else
                {
                    buttonItem.Text = sys_Module.MenuList[i].Name;
                }

                
                ControlHelper ctrlItem = new ControlHelper();
                //转接主窗口转过来的数据
                ctrlItem.AnyControl = ctrl.AnyControl;
                ctrlItem.ContextMenuBtn = ctrl.ContextMenuBtn;
                ctrlItem.UserInfo = ctrl.UserInfo;
                ctrlItem.RunPath = ctrl.RunPath;
                ctrlItem.MainForm = ctrl.MainForm;
                ctrlItem.CustomSetting = ctrl.CustomSetting;
                //读取数据库数据
                ctrlItem.MenuCode = sys_Module.MenuList[i].Code;
                ctrlItem.MenuName = sys_Module.MenuList[i].Name;
                ctrlItem.AssemblyName = sys_Module.MenuList[i].AssemblyName;
                ctrlItem.NameSpace = sys_Module.MenuList[i].NameSpace;
                ctrlItem.FromCode = sys_Module.MenuList[i].FormCode;
                ctrlItem.FromName = sys_Module.MenuList[i].FormName;
                buttonItem.Tag = ctrlItem;
                buttonItem.Click += new System.EventHandler(ClickHandler);
                //buttonItem.MouseDown += new MouseEventHandler(buttonItem_MouseDown); //鼠标按下事件
                //buttonItem.MouseUp += new MouseEventHandler(buttonItem_MouseUp);

                menuArray[i] = buttonItem;
            }

            sideBarPanelItem.SubItems.AddRange(menuArray);
        }

        #region 拖放(未使用)

        static void buttonItem_MouseUp(object sender, MouseEventArgs e)
        {
            DevComponents.DotNetBar.ButtonItem btn = sender as DevComponents.DotNetBar.ButtonItem;
            //把屏幕坐标转换成控件坐标
            Point pBtn = new Point(e.X, e.Y);
            //Point p = btn.PointToClient(new Point(e.X, e.Y));
            //Point point = PointToScreen(new Point(e.X, e.Y));
        }
        public static object dropData;
        //鼠标按下事件（拖放使用）
        static void buttonItem_MouseDown(object sender, MouseEventArgs e)
        {
            // 如果用户按下鼠标左键。
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                DevComponents.DotNetBar.ButtonItem btn = sender as DevComponents.DotNetBar.ButtonItem;
                // 初始化拖放操作。
                //btn.DoDragDrop(btn, DragDropEffects.Copy);
                dropData = btn;
            }
        }

        #endregion
        
        //按钮点击事件
        private static void ClickHandler(object sender, EventArgs e)
        {
            DevComponents.DotNetBar.ButtonItem btnItem = (DevComponents.DotNetBar.ButtonItem)(sender);
            ControlHelper ctrlItem = btnItem.Tag as ControlHelper;

            DevComponents.DotNetBar.TabControl tabControl = (DevComponents.DotNetBar.TabControl)ctrlItem.AnyControl;

            //long tick = DateTime.Now.Ticks;
            //Random rand = new Random((int)(tick & 0xffffffffL) | (int)(tick >> 32));
            //string tabName = "tab" + rand.Next(1, 100000).ToString();
            string tabName = "tab" + ctrlItem.MenuCode;
            ctrlItem.TabName = tabName;

            TabPageHelper.CreateTab(sender, e, ctrlItem, tabControl, tabName, ctrlItem.FromName);

        }

    }
}
