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
    public partial class PluginInstallDialog : Form
    {
        //插件编译对象
        private PluginCompiler m_compiler;

        public PluginInstallDialog(PluginCompiler compiler)
        {
            InitializeComponent();
            m_compiler = compiler;
        }

        private void btnBrowser_Click(object sender, EventArgs e)
        {
            OpenFileDialog of = new OpenFileDialog();
            if (of.ShowDialog() != DialogResult.OK)
                return;
            txtPluginPath.Text = of.FileName;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            string pluginPath = txtPluginPath.Text;
            InstallFromFile(pluginPath);
            this.DialogResult = DialogResult.OK;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();

        }

        /// <summary>
        /// Install plugin from local file.
        /// </summary>
        /// <param name="pluginPath">Plugin path/filename.</param>
        void InstallFromFile(string pluginPath)
        {
            string fileName = Path.GetFileName(pluginPath);
            string destPath = GetDestinationPath(fileName);
            if (destPath == null)
                return;

            File.Copy(pluginPath, destPath);

            ShowSuccessMessage(fileName);
        }

        /// <summary>
        /// Calculates plugin destination directory based on name, and prepares it.
        /// </summary>
        /// <param name="fileName">Plugin filename only (no path).</param>
        string GetDestinationPath(string fileName)
        {
            string directory = Path.Combine(m_compiler.PluginRootDirectory, Path.GetFileNameWithoutExtension(fileName));
            Directory.CreateDirectory(directory);

            string fullPath = Path.Combine(directory, fileName);
            if (File.Exists(fullPath))
            {
                // Show overwrite warning
                string msg = string.Format("已经安装过插件 {0} ，确认要覆盖 ？",
                    Path.GetFileNameWithoutExtension(fileName));
                if (MessageBox.Show(msg, "覆盖", MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                    MessageBoxDefaultButton.Button2) != DialogResult.Yes)
                    throw new ApplicationException("取消安装插件.");
            }

            return fullPath;
        }

        /// <summary>
        /// Display a message box with successful installation message.
        /// </summary>
        static void ShowSuccessMessage(string fileName)
        {
            string msg = string.Format("{0} 插件被成功安装.",
                Path.GetFileNameWithoutExtension(fileName));
            MessageBox.Show(msg, "插件安装", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void PluginInstallDialog_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.DialogResult!=DialogResult.OK)
            this.DialogResult = DialogResult.Cancel;
        }

    }
}
