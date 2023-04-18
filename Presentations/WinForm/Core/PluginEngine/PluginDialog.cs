using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace NLife.Core.PluginEngine
{
    public partial class PluginDialog : Form
    {
        //插件编译器
        private PluginCompiler compiler;
        public PluginDialog()
        {
            InitializeComponent();
        }
        public PluginDialog(PluginCompiler compiler)
        {
            InitializeComponent();
            this.compiler = compiler;
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            foreach (PluginListItem pi in listView.SelectedItems)
                PluginLoad(pi);
            listView.Invalidate();
            UpdateUIStates();
        }

        /// <summary>
        /// Load plugin and display message on failure.
        /// </summary>
        private void PluginLoad(PluginListItem pi)
        {
            try
            {
                compiler.Load(pi.PluginInfo);
                //更改状态
                pi.Checked = true;
                pi.SubItems[1].Text=pi.Checked.ToString();

            }
            catch (Exception caught)
            {
                MessageBox.Show("加载插件:\n\n" + caught.Message, pi.Name +
                    " 出错.",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void UpdateStartState(PluginInfo pi,bool bState)
        {

            foreach (PluginInfo tmpPI in compiler.Plugins)
            {
                if (tmpPI.ID == pi.ID||tmpPI.Name== pi.Name)
                {
                 //   tmpPI.IsCurrentlyLoaded = bState;
                    break;
                }
            }
        }

        void UpdateUIStates()
        {
            bool isItemSelected = listView.SelectedItems.Count > 0;
            btnUninstall.Enabled = isItemSelected;
            if (!isItemSelected)
            {
                btnLoad.Enabled = false;
                btnUnload.Enabled = false;
                return;
            }

            PluginListItem item = (PluginListItem)listView.SelectedItems[0];
            btnLoad.Enabled = !item.PluginInfo.IsCurrentlyLoaded;
            btnUnload.Enabled = item.PluginInfo.IsCurrentlyLoaded;
        }
        /// <summary>
        /// Fill the list view with currently installed plugins.
        /// </summary>
        void AddPluginList()
        {
            listView.Items.Clear();
            foreach (PluginInfo pi in compiler.Plugins)
            {
                PluginListItem li = new PluginListItem(pi);
                li.SubItems.Add(li.Checked.ToString());
                listView.Items.Add(li);
            }
        }


        private void PluginDialog_Load(object sender, EventArgs e)
        {
            AddPluginList();

            //Force UI state update
            listView_SelectedIndexChanged(this, EventArgs.Empty);
            UpdateUIStates();
        }

        private void listView_SelectedIndexChanged(object sender, EventArgs e)
        {
            description.Text = "";
            developer.Text = "";

            UpdateUIStates();

            if (listView.SelectedItems.Count != 1)
                return;

            PluginListItem item = (PluginListItem)listView.SelectedItems[0];

            description.Text = item.PluginInfo.Description;
            developer.Text = item.PluginInfo.Developer;
        }

        private void btnUnload_Click(object sender, EventArgs e)
        {
            foreach (PluginListItem pi in listView.SelectedItems)
            {
                string fullPath = pi.PluginInfo.FullPath;
                // Show uninstall warning
                string msg = string.Format("确认卸载插件：{0}?", pi.Name);
                if (MessageBox.Show(msg, "删除插件", MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                    MessageBoxDefaultButton.Button2) != DialogResult.Yes)
                    continue;

                try
                {
                    compiler.Unload(pi.PluginInfo);
                    pi.Checked =false;
                    pi.SubItems[1].Text = pi.Checked.ToString();
                }
                catch (Exception caught)
                {
                    MessageBox.Show("卸载失败.  \n\n" + caught.Message, pi.Name +
                        " 插件卸载失败！.",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
            }
            UpdateUIStates();

        }

        private void btnUninstall_Click(object sender, EventArgs e)
        {
            foreach (PluginListItem pi in listView.SelectedItems)
            {
                string fullPath = pi.PluginInfo.FullPath;
                if (!File.Exists(fullPath))
                {
                    MessageBox.Show("'" + pi.Name + "'插件是系统内部插件，禁止移除！",
                        "插件移除",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                    continue;
                }

                // Show uninstall warning
                string msg = string.Format("确认移除插件：{0}?", pi.Name);
                if (MessageBox.Show(msg, "移除插件", MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                    MessageBoxDefaultButton.Button2) != DialogResult.Yes)
                    continue;

                try
                {
                    compiler.Uninstall(pi.PluginInfo);

                    // Remove if from the plugin list
                    listView.Items.Remove(pi);
                }
                catch (Exception caught)
                {
                    MessageBox.Show("移除失败.  \n\n" + caught.Message, pi.Name +
                        " 插件移除失败！.",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
            }
            UpdateUIStates();

        }

        private void btnInstall_Click(object sender, EventArgs e)
        {
            Form installDialog = new PluginInstallDialog(compiler);
            installDialog.Icon = this.Icon;
            if (DialogResult.OK == installDialog.ShowDialog())
            {
                // Rescan for plugins
                compiler.FindPlugins();
                AddPluginList();
            }
        }
    }
}
