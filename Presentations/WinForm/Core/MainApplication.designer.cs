namespace NLife.Core
{
    partial class MainApplication
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainApplication));
            this.MenuPicList = new System.Windows.Forms.ImageList(this.components);
            this.mainMenu = new System.Windows.Forms.MainMenu(this.components);
            this.menuItem1 = new System.Windows.Forms.MenuItem();
            this.PluginMenuItem = new System.Windows.Forms.MenuItem();
            this.menuItemPlugin = new System.Windows.Forms.MenuItem();
            this.listPlugMenu = new System.Windows.Forms.ListView();
            this.topPanel = new System.Windows.Forms.Panel();
            this.ContentPanel = new System.Windows.Forms.Panel();
            this.topPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // MenuPicList
            // 
            this.MenuPicList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("MenuPicList.ImageStream")));
            this.MenuPicList.TransparentColor = System.Drawing.Color.Transparent;
            this.MenuPicList.Images.SetKeyName(0, "DataServer.png");
            // 
            // mainMenu
            // 
            this.mainMenu.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItem1,
            this.PluginMenuItem,
            this.menuItemPlugin});
            // 
            // menuItem1
            // 
            this.menuItem1.Index = 0;
            this.menuItem1.Text = "File(&F)";
            // 
            // PluginMenuItem
            // 
            this.PluginMenuItem.Index = 1;
            this.PluginMenuItem.Text = "插件";
            // 
            // menuItemPlugin
            // 
            this.menuItemPlugin.Index = 2;
            this.menuItemPlugin.Text = "插件管理";
            this.menuItemPlugin.Click += new System.EventHandler(this.menuItemPlugin_Click);
            // 
            // listPlugMenu
            // 
            this.listPlugMenu.Alignment = System.Windows.Forms.ListViewAlignment.Default;
            this.listPlugMenu.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.listPlugMenu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listPlugMenu.LabelWrap = false;
            this.listPlugMenu.LargeImageList = this.MenuPicList;
            this.listPlugMenu.Location = new System.Drawing.Point(0, 0);
            this.listPlugMenu.Margin = new System.Windows.Forms.Padding(0);
            this.listPlugMenu.MultiSelect = false;
            this.listPlugMenu.Name = "listPlugMenu";
            this.listPlugMenu.Scrollable = false;
            this.listPlugMenu.ShowGroups = false;
            this.listPlugMenu.Size = new System.Drawing.Size(765, 50);
            this.listPlugMenu.TabIndex = 1;
            this.listPlugMenu.UseCompatibleStateImageBehavior = false;
            this.listPlugMenu.ItemSelectionChanged += new System.Windows.Forms.ListViewItemSelectionChangedEventHandler(this.listPlugMenu_ItemSelectionChanged);
            // 
            // topPanel
            // 
            this.topPanel.Controls.Add(this.listPlugMenu);
            this.topPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.topPanel.Location = new System.Drawing.Point(20, 60);
            this.topPanel.Name = "topPanel";
            this.topPanel.Size = new System.Drawing.Size(765, 50);
            this.topPanel.TabIndex = 0;
            // 
            // ContentPanel
            // 
            this.ContentPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.ContentPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.ContentPanel.Location = new System.Drawing.Point(0, 50);
            this.ContentPanel.Name = "ContentPanel";
            this.ContentPanel.Size = new System.Drawing.Size(805, 535);
            this.ContentPanel.TabIndex = 1;
            // 
            // MainApplication
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(805, 585);
            this.Controls.Add(this.ContentPanel);
            this.Controls.Add(this.topPanel);
            this.Name = "MainApplication";
            this.Text = "主工程窗体";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.MainApplication_Load);
            this.Resize += new System.EventHandler(this.MainApplication_Resize);
            this.topPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.ImageList MenuPicList;
        private System.Windows.Forms.MainMenu mainMenu;
        private System.Windows.Forms.MenuItem menuItem1;
        private System.Windows.Forms.MenuItem PluginMenuItem;
        private System.Windows.Forms.ListView listPlugMenu;
        private System.Windows.Forms.Panel topPanel;
        public System.Windows.Forms.Panel ContentPanel;
        private System.Windows.Forms.MenuItem menuItemPlugin;

    }
}

