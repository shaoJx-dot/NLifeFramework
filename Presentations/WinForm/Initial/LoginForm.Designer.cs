namespace Initial
{
    partial class LoginForm
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
            this.metroStyleManager = new MetroFramework.Components.MetroStyleManager(this.components);
            this.metroPanel1 = new MetroFramework.Controls.MetroPanel();
            this.probar = new MetroFramework.Controls.MetroProgressBar();
            this.btnLogin = new MetroFramework.Controls.MetroButton();
            this.chkAutoIn = new MetroFramework.Controls.MetroCheckBox();
            this.chkRemember = new MetroFramework.Controls.MetroCheckBox();
            this.cboChoice = new MetroFramework.Controls.MetroComboBox();
            this.txtPasswd = new MetroFramework.Controls.MetroTextBox();
            this.txtName = new MetroFramework.Controls.MetroTextBox();
            this.lblText = new MetroFramework.Controls.MetroLabel();
            this.metroLabel2 = new MetroFramework.Controls.MetroLabel();
            this.lblName = new MetroFramework.Controls.MetroLabel();
            this.lblAccount = new MetroFramework.Controls.MetroLabel();
            ((System.ComponentModel.ISupportInitialize)(this.metroStyleManager)).BeginInit();
            this.metroPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // metroStyleManager
            // 
            this.metroStyleManager.Owner = null;
            // 
            // metroPanel1
            // 
            this.metroPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.metroPanel1.Controls.Add(this.probar);
            this.metroPanel1.Controls.Add(this.btnLogin);
            this.metroPanel1.Controls.Add(this.chkAutoIn);
            this.metroPanel1.Controls.Add(this.chkRemember);
            this.metroPanel1.Controls.Add(this.cboChoice);
            this.metroPanel1.Controls.Add(this.txtPasswd);
            this.metroPanel1.Controls.Add(this.txtName);
            this.metroPanel1.Controls.Add(this.lblText);
            this.metroPanel1.Controls.Add(this.metroLabel2);
            this.metroPanel1.Controls.Add(this.lblName);
            this.metroPanel1.Controls.Add(this.lblAccount);
            this.metroPanel1.HorizontalScrollbarBarColor = true;
            this.metroPanel1.HorizontalScrollbarHighlightOnWheel = false;
            this.metroPanel1.HorizontalScrollbarSize = 10;
            this.metroPanel1.Location = new System.Drawing.Point(5, 26);
            this.metroPanel1.Name = "metroPanel1";
            this.metroPanel1.Size = new System.Drawing.Size(420, 299);
            this.metroPanel1.TabIndex = 0;
            this.metroPanel1.VerticalScrollbarBarColor = true;
            this.metroPanel1.VerticalScrollbarHighlightOnWheel = false;
            this.metroPanel1.VerticalScrollbarSize = 10;
            // 
            // probar
            // 
            this.probar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.probar.Location = new System.Drawing.Point(7, 274);
            this.probar.Name = "probar";
            this.probar.Size = new System.Drawing.Size(406, 20);
            this.probar.TabIndex = 16;
            this.probar.Value = 25;
            // 
            // btnLogin
            // 
            this.btnLogin.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnLogin.Highlight = true;
            this.btnLogin.Location = new System.Drawing.Point(101, 195);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(225, 27);
            this.btnLogin.TabIndex = 3;
            this.btnLogin.Text = "登录";
            this.btnLogin.UseSelectable = true;
            // 
            // chkAutoIn
            // 
            this.chkAutoIn.AutoSize = true;
            this.chkAutoIn.Location = new System.Drawing.Point(252, 167);
            this.chkAutoIn.Name = "chkAutoIn";
            this.chkAutoIn.Size = new System.Drawing.Size(72, 17);
            this.chkAutoIn.TabIndex = 14;
            this.chkAutoIn.Text = "自动登录";
            this.chkAutoIn.UseSelectable = true;
            // 
            // chkRemember
            // 
            this.chkRemember.AutoSize = true;
            this.chkRemember.Location = new System.Drawing.Point(102, 167);
            this.chkRemember.Name = "chkRemember";
            this.chkRemember.Size = new System.Drawing.Size(72, 17);
            this.chkRemember.TabIndex = 14;
            this.chkRemember.Text = "记住密码";
            this.chkRemember.UseSelectable = true;
            // 
            // cboChoice
            // 
            this.cboChoice.FontSize = MetroFramework.MetroComboBoxSize.Small;
            this.cboChoice.FormattingEnabled = true;
            this.cboChoice.IntegralHeight = false;
            this.cboChoice.ItemHeight = 21;
            this.cboChoice.Items.AddRange(new object[] {
            "Normal Combobox 1",
            "Normal Combobox 2",
            "Normal Combobox 3",
            "Normal Combobox 4"});
            this.cboChoice.Location = new System.Drawing.Point(101, 46);
            this.cboChoice.Name = "cboChoice";
            this.cboChoice.PromptText = "选择帐套名……";
            this.cboChoice.Size = new System.Drawing.Size(225, 27);
            this.cboChoice.TabIndex = 0;
            this.cboChoice.UseSelectable = true;
            // 
            // txtPasswd
            // 
            this.txtPasswd.IconRight = true;
            this.txtPasswd.Lines = new string[0];
            this.txtPasswd.Location = new System.Drawing.Point(101, 129);
            this.txtPasswd.MaxLength = 32767;
            this.txtPasswd.Name = "txtPasswd";
            this.txtPasswd.PasswordChar = '\0';
            this.txtPasswd.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtPasswd.SelectedText = "";
            this.txtPasswd.Size = new System.Drawing.Size(225, 26);
            this.txtPasswd.TabIndex = 2;
            this.txtPasswd.UseSelectable = true;
            this.txtPasswd.UseStyleColors = true;
            // 
            // txtName
            // 
            this.txtName.IconRight = true;
            this.txtName.Lines = new string[0];
            this.txtName.Location = new System.Drawing.Point(101, 88);
            this.txtName.MaxLength = 32767;
            this.txtName.Name = "txtName";
            this.txtName.PasswordChar = '\0';
            this.txtName.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtName.SelectedText = "";
            this.txtName.Size = new System.Drawing.Size(225, 26);
            this.txtName.TabIndex = 1;
            this.txtName.UseSelectable = true;
            this.txtName.UseStyleColors = true;
            // 
            // lblText
            // 
            this.lblText.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblText.AutoSize = true;
            this.lblText.FontSize = MetroFramework.MetroLabelSize.Small;
            this.lblText.Location = new System.Drawing.Point(8, 252);
            this.lblText.Margin = new System.Windows.Forms.Padding(3);
            this.lblText.Name = "lblText";
            this.lblText.Size = new System.Drawing.Size(89, 17);
            this.lblText.TabIndex = 3;
            this.lblText.Text = "正在检测版本...";
            this.lblText.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // metroLabel2
            // 
            this.metroLabel2.AutoSize = true;
            this.metroLabel2.Location = new System.Drawing.Point(47, 129);
            this.metroLabel2.Margin = new System.Windows.Forms.Padding(3);
            this.metroLabel2.Name = "metroLabel2";
            this.metroLabel2.Size = new System.Drawing.Size(51, 20);
            this.metroLabel2.TabIndex = 3;
            this.metroLabel2.Text = "密码：";
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(47, 89);
            this.lblName.Margin = new System.Windows.Forms.Padding(3);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(51, 20);
            this.lblName.TabIndex = 3;
            this.lblName.Text = "帐号：";
            // 
            // lblAccount
            // 
            this.lblAccount.AutoSize = true;
            this.lblAccount.Location = new System.Drawing.Point(47, 50);
            this.lblAccount.Margin = new System.Windows.Forms.Padding(3);
            this.lblAccount.Name = "lblAccount";
            this.lblAccount.Size = new System.Drawing.Size(51, 20);
            this.lblAccount.TabIndex = 3;
            this.lblAccount.Text = "帐套：";
            // 
            // LoginForm
            // 
            this.ApplyImageInvert = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(192)))), ((int)(((byte)(235)))));
            this.BorderStyle = MetroFramework.Forms.MetroFormBorderStyle.FixedSingle;
            this.ClientSize = new System.Drawing.Size(430, 330);
            this.Controls.Add(this.metroPanel1);
            this.DisplayHeader = false;
            this.MaximizeBox = false;
            this.Name = "LoginForm";
            this.Padding = new System.Windows.Forms.Padding(20, 30, 30, 20);
            this.Resizable = false;
            this.ShadowType = MetroFramework.Forms.MetroFormShadowType.AeroShadow;
            this.Text = "登陆";
            this.Theme = MetroFramework.MetroThemeStyle.Blue;
            ((System.ComponentModel.ISupportInitialize)(this.metroStyleManager)).EndInit();
            this.metroPanel1.ResumeLayout(false);
            this.metroPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private MetroFramework.Components.MetroStyleManager metroStyleManager;
        private MetroFramework.Controls.MetroPanel metroPanel1;
        private MetroFramework.Controls.MetroLabel metroLabel2;
        private MetroFramework.Controls.MetroLabel lblName;
        private MetroFramework.Controls.MetroLabel lblAccount;
        private MetroFramework.Controls.MetroComboBox cboChoice;
        private MetroFramework.Controls.MetroTextBox txtPasswd;
        private MetroFramework.Controls.MetroTextBox txtName;
        private MetroFramework.Controls.MetroCheckBox chkAutoIn;
        private MetroFramework.Controls.MetroCheckBox chkRemember;
        private MetroFramework.Controls.MetroButton btnLogin;
        private MetroFramework.Controls.MetroProgressBar probar;
        private MetroFramework.Controls.MetroLabel lblText;
    }
}

