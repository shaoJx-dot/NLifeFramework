using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using NLife.Core.Menu;
using NLife.Core.Plugins;
using System.Collections;
using NLife.Core.PluginEngine;
using NLife.Core.Settings;
using System.IO;
using System.Reflection;
using MetroFramework;
using MetroFramework.Forms;

namespace NLife.Core
{
    public partial class MainApplication : Form
    {
        //配置文件夹
        public static string CurrentSettingsDirectory = Application.StartupPath;
        public static MainSettings Settings = new MainSettings();
        //插件编译器
        private PluginCompiler compiler;


        //插件列表
        public ArrayList StartupPlugins = new ArrayList();
        public static string DirectoryPath = Application.StartupPath;
        public MenuBar _MenuBar;
        public MenuBar MenuBar
        {
            get
            {
                if (_MenuBar == null)
                {
                    _MenuBar = new MenuBar(this.listPlugMenu, this.MenuPicList);
                }
                return this._MenuBar;
            }
        }
        //插件菜单列表
        public MenuItem PluginMenu
        {
            get
            {
                return (MenuItem)PluginMenuItem;
            }
        }

        //插件按钮菜单列表
        public ListView PlugMenuBar
        {
            get
            {
                return listPlugMenu;
            }
        }

        public MainApplication()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 加载插件
        /// </summary>
        public void LoadPlugin()
        {
            //FormDataMapLoader dataMapLoader = new FormDataMapLoader();
            //StartupPlugins.Add(dataMapLoader);
            //KeyBoardFormLoader keyBoardLoader = new KeyBoardFormLoader();
            //StartupPlugins.Add(keyBoardLoader);
            //DemoFormLoader demFormLoader = new DemoFormLoader();
            //StartupPlugins.Add(demFormLoader);
            //for (int i = 0; i < StartupPlugins.Count; i++)
            //{
            //    Plugin plugin = StartupPlugins[i] as Plugin;
            //    plugin.PluginLoad(this, ""); ;

            //}

        }

        private void MainApplication_Load(object sender, EventArgs e)
        {
            this.Menu = mainMenu;

            if (CurrentSettingsDirectory == null)
            {
                // load program settings from default directory
                LoadSettings();
            }
            else
            {
                LoadSettings(CurrentSettingsDirectory);
            }

            InitializePluginCompiler();
            //  LoadPlugin();

            Settings.Save();
        }


        /// <summary>
        /// Deserializes and optionally decrypts settings, using specified location
        /// </summary>
        private static void LoadSettings(string directory)
        {
            try
            {
                Settings = (MainSettings)SettingsBase.LoadFromPath(Settings, directory);
            }
            catch (Exception caught)
            {
                //   Log.Write(caught);
            }
        }

        private void MainApplication_Resize(object sender, EventArgs e)
        {

            this.ContentPanel.Dock = DockStyle.Fill;
            for (int i = 0; i < this.ContentPanel.Controls.Count; i++)
            {
                Form tmp = this.ContentPanel.Controls[i] as Form;
                tmp.FormBorderStyle = FormBorderStyle.None;
                tmp.WindowState = FormWindowState.Minimized;
                tmp.WindowState = FormWindowState.Maximized;
            }

        }

        private void listPlugMenu_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            if (listPlugMenu.FocusedItem != null)
            {
                // MessageBox.Show(listPlugMenu.FocusedItem.Text);
                //插件菜单文字
                string strMenu = listPlugMenu.FocusedItem.Text;
                for (int i = 0; i < _MenuBar.PlugArrList.Count; i++)
                {
                    MenuButton menuBtn = _MenuBar.PlugArrList[i] as MenuButton;
                    if (menuBtn.MenuName == strMenu)
                    {
                        menuBtn.SetPushed(true);
                    }
                    else
                        menuBtn.SetPushed(false);
                }
            }
        }


        #region 加载配置相关
        private static void LoadSettings()
        {
            try
            {
                Settings = (MainSettings)SettingsBase.Load(Settings, SettingsBase.LocationType.User);

                if (!File.Exists(Settings.FileName))
                {
                    Settings.PluginsLoadedOnStartup.Add("FormDataMapLoader");
                    Settings.PluginsLoadedOnStartup.Add("KeyBoardFormLoader");
                    Settings.PluginsLoadedOnStartup.Add("DemoFormLoader");
                    //  Settings.PluginsLoadedOnStartup.Add("FormDataMapLoader");
                }
            }
            catch (Exception caught)
            {
                //  Log.Write(caught);
            }
        }

        private void InitializePluginCompiler()
        {
            ///  Log.Write(Log.Levels.Debug, "CONF", "initializing plugin compiler...");
            //this.splashScreen.SetText("Initializing plugins...");
            string pluginRoot = Path.Combine(DirectoryPath, "Plugins");
            compiler = new PluginCompiler(this, pluginRoot);

            //#if DEBUG
            // Search for plugins in worldwind.exe (plugin development/debugging aid)
            compiler.FindPlugins(Assembly.GetExecutingAssembly());
            //#endif

            compiler.FindPlugins();
            compiler.LoadStartupPlugins();
        }
        #endregion

        private void menuItemPlugin_Click(object sender, EventArgs e)
        {
            //插件管理对话框
            PluginDialog pluginDialog = new PluginDialog(this.compiler);
            pluginDialog.Show();
        }

    }
}