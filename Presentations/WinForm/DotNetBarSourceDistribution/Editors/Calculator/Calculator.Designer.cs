namespace DevComponents.Editors
{
    partial class Calculator
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Calculator));
            this.pnlCalc = new DevComponents.DotNetBar.PanelEx();
            this.pnlPad = new DevComponents.DotNetBar.PanelEx();
            this.BtnBack = new DevComponents.DotNetBar.ButtonX();
            this.BtnDigit8 = new DevComponents.DotNetBar.ButtonX();
            this.BtnReciprocal = new DevComponents.DotNetBar.ButtonX();
            this.BtnDigit5 = new DevComponents.DotNetBar.ButtonX();
            this.BtnSqrt = new DevComponents.DotNetBar.ButtonX();
            this.BtnDivide = new DevComponents.DotNetBar.ButtonX();
            this.BtnDigit9 = new DevComponents.DotNetBar.ButtonX();
            this.BtnClearEntry = new DevComponents.DotNetBar.ButtonX();
            this.BtnDecimal = new DevComponents.DotNetBar.ButtonX();
            this.BtnAdd = new DevComponents.DotNetBar.ButtonX();
            this.BtnEquals = new DevComponents.DotNetBar.ButtonX();
            this.BtnDigit4 = new DevComponents.DotNetBar.ButtonX();
            this.BtnSubtract = new DevComponents.DotNetBar.ButtonX();
            this.BtnMultiply = new DevComponents.DotNetBar.ButtonX();
            this.BtnDigit6 = new DevComponents.DotNetBar.ButtonX();
            this.BtnClear = new DevComponents.DotNetBar.ButtonX();
            this.BtnDigit1 = new DevComponents.DotNetBar.ButtonX();
            this.BtnDigit2 = new DevComponents.DotNetBar.ButtonX();
            this.BtnNegate = new DevComponents.DotNetBar.ButtonX();
            this.BtnDigit0 = new DevComponents.DotNetBar.ButtonX();
            this.BtnDigit3 = new DevComponents.DotNetBar.ButtonX();
            this.BtnPercent = new DevComponents.DotNetBar.ButtonX();
            this.BtnDigit7 = new DevComponents.DotNetBar.ButtonX();
            this.pnlMem = new DevComponents.DotNetBar.PanelEx();
            this.BtnMemStore = new DevComponents.DotNetBar.ButtonX();
            this.lbxOperator = new DevComponents.DotNetBar.LabelX();
            this.BtnMemRestore = new DevComponents.DotNetBar.ButtonX();
            this.BtnMemAdd = new DevComponents.DotNetBar.ButtonX();
            this.BtnMemClear = new DevComponents.DotNetBar.ButtonX();
            this.BtnMemSubtract = new DevComponents.DotNetBar.ButtonX();
            this.lbxMemory = new DevComponents.DotNetBar.LabelX();
            this.labelValue = new DevComponents.DotNetBar.LabelX();
            this.pnlCalc.SuspendLayout();
            this.pnlPad.SuspendLayout();
            this.pnlMem.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlCalc
            // 
            this.pnlCalc.CanvasColor = System.Drawing.SystemColors.Control;
            this.pnlCalc.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.pnlCalc.Controls.Add(this.pnlPad);
            this.pnlCalc.Controls.Add(this.pnlMem);
            this.pnlCalc.Controls.Add(this.labelValue);
            this.pnlCalc.Location = new System.Drawing.Point(0, 0);
            this.pnlCalc.Name = "pnlCalc";
            this.pnlCalc.Padding = new System.Windows.Forms.Padding(1);
            this.pnlCalc.Size = new System.Drawing.Size(190, 211);
            this.pnlCalc.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.pnlCalc.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground;
            this.pnlCalc.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.pnlCalc.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder;
            this.pnlCalc.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText;
            this.pnlCalc.Style.GradientAngle = 90;
            this.pnlCalc.TabIndex = 0;
            // 
            // pnlPad
            // 
            this.pnlPad.CanvasColor = System.Drawing.SystemColors.Control;
            this.pnlPad.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.pnlPad.Controls.Add(this.BtnBack);
            this.pnlPad.Controls.Add(this.BtnDigit8);
            this.pnlPad.Controls.Add(this.BtnReciprocal);
            this.pnlPad.Controls.Add(this.BtnDigit5);
            this.pnlPad.Controls.Add(this.BtnSqrt);
            this.pnlPad.Controls.Add(this.BtnDivide);
            this.pnlPad.Controls.Add(this.BtnDigit9);
            this.pnlPad.Controls.Add(this.BtnClearEntry);
            this.pnlPad.Controls.Add(this.BtnDecimal);
            this.pnlPad.Controls.Add(this.BtnAdd);
            this.pnlPad.Controls.Add(this.BtnEquals);
            this.pnlPad.Controls.Add(this.BtnDigit4);
            this.pnlPad.Controls.Add(this.BtnSubtract);
            this.pnlPad.Controls.Add(this.BtnMultiply);
            this.pnlPad.Controls.Add(this.BtnDigit6);
            this.pnlPad.Controls.Add(this.BtnClear);
            this.pnlPad.Controls.Add(this.BtnDigit1);
            this.pnlPad.Controls.Add(this.BtnDigit2);
            this.pnlPad.Controls.Add(this.BtnNegate);
            this.pnlPad.Controls.Add(this.BtnDigit0);
            this.pnlPad.Controls.Add(this.BtnDigit3);
            this.pnlPad.Controls.Add(this.BtnPercent);
            this.pnlPad.Controls.Add(this.BtnDigit7);
            this.pnlPad.Location = new System.Drawing.Point(1, 58);
            this.pnlPad.Name = "pnlPad";
            this.pnlPad.Size = new System.Drawing.Size(187, 151);
            this.pnlPad.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.pnlPad.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground;
            this.pnlPad.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder;
            this.pnlPad.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText;
            this.pnlPad.Style.GradientAngle = 90;
            this.pnlPad.TabIndex = 35;
            // 
            // BtnBack
            // 
            this.BtnBack.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.BtnBack.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.BtnBack.Image = ((System.Drawing.Image)(resources.GetObject("BtnBack.Image")));
            this.BtnBack.Location = new System.Drawing.Point(8, 6);
            this.BtnBack.Name = "BtnBack";
            this.BtnBack.Size = new System.Drawing.Size(30, 23);
            this.BtnBack.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.BtnBack.TabIndex = 0;
            this.BtnBack.Click += new System.EventHandler(this.BtnBackClick);
            // 
            // BtnDigit8
            // 
            this.BtnDigit8.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.BtnDigit8.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.BtnDigit8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnDigit8.Location = new System.Drawing.Point(43, 36);
            this.BtnDigit8.Name = "BtnDigit8";
            this.BtnDigit8.Size = new System.Drawing.Size(30, 23);
            this.BtnDigit8.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.BtnDigit8.TabIndex = 6;
            this.BtnDigit8.Text = "8";
            this.BtnDigit8.Click += new System.EventHandler(this.BtnDigitClick);
            // 
            // BtnReciprocal
            // 
            this.BtnReciprocal.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.BtnReciprocal.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.BtnReciprocal.Location = new System.Drawing.Point(150, 65);
            this.BtnReciprocal.Name = "BtnReciprocal";
            this.BtnReciprocal.Size = new System.Drawing.Size(30, 23);
            this.BtnReciprocal.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.BtnReciprocal.TabIndex = 14;
            this.BtnReciprocal.Text = "1 / x";
            this.BtnReciprocal.Click += new System.EventHandler(this.BtnReciprocalClick);
            // 
            // BtnDigit5
            // 
            this.BtnDigit5.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.BtnDigit5.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.BtnDigit5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnDigit5.Location = new System.Drawing.Point(43, 65);
            this.BtnDigit5.Name = "BtnDigit5";
            this.BtnDigit5.Size = new System.Drawing.Size(30, 23);
            this.BtnDigit5.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.BtnDigit5.TabIndex = 11;
            this.BtnDigit5.Text = "5";
            this.BtnDigit5.Click += new System.EventHandler(this.BtnDigitClick);
            // 
            // BtnSqrt
            // 
            this.BtnSqrt.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.BtnSqrt.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.BtnSqrt.Location = new System.Drawing.Point(150, 6);
            this.BtnSqrt.Name = "BtnSqrt";
            this.BtnSqrt.Size = new System.Drawing.Size(30, 23);
            this.BtnSqrt.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.BtnSqrt.TabIndex = 4;
            this.BtnSqrt.Text = "√";
            this.BtnSqrt.Click += new System.EventHandler(this.BtnSqrtClick);
            // 
            // BtnDivide
            // 
            this.BtnDivide.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.BtnDivide.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.BtnDivide.Location = new System.Drawing.Point(114, 36);
            this.BtnDivide.Name = "BtnDivide";
            this.BtnDivide.Size = new System.Drawing.Size(30, 23);
            this.BtnDivide.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.BtnDivide.TabIndex = 8;
            this.BtnDivide.Text = "/";
            this.BtnDivide.Click += new System.EventHandler(this.BtnDivideClick);
            // 
            // BtnDigit9
            // 
            this.BtnDigit9.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.BtnDigit9.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.BtnDigit9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnDigit9.Location = new System.Drawing.Point(78, 36);
            this.BtnDigit9.Name = "BtnDigit9";
            this.BtnDigit9.Size = new System.Drawing.Size(30, 23);
            this.BtnDigit9.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.BtnDigit9.TabIndex = 7;
            this.BtnDigit9.Text = "9";
            this.BtnDigit9.Click += new System.EventHandler(this.BtnDigitClick);
            // 
            // BtnClearEntry
            // 
            this.BtnClearEntry.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.BtnClearEntry.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.BtnClearEntry.Location = new System.Drawing.Point(43, 6);
            this.BtnClearEntry.Name = "BtnClearEntry";
            this.BtnClearEntry.Size = new System.Drawing.Size(30, 23);
            this.BtnClearEntry.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.BtnClearEntry.TabIndex = 1;
            this.BtnClearEntry.Text = "CE";
            this.BtnClearEntry.Click += new System.EventHandler(this.BtnClearEntryClick);
            // 
            // BtnDecimal
            // 
            this.BtnDecimal.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.BtnDecimal.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.BtnDecimal.Font = new System.Drawing.Font("Modern No. 20", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnDecimal.Location = new System.Drawing.Point(78, 123);
            this.BtnDecimal.Name = "BtnDecimal";
            this.BtnDecimal.Size = new System.Drawing.Size(30, 23);
            this.BtnDecimal.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.BtnDecimal.TabIndex = 21;
            this.BtnDecimal.Text = ".";
            this.BtnDecimal.Click += new System.EventHandler(this.BtnDecimalClick);
            // 
            // BtnAdd
            // 
            this.BtnAdd.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.BtnAdd.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.BtnAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnAdd.Location = new System.Drawing.Point(114, 123);
            this.BtnAdd.Name = "BtnAdd";
            this.BtnAdd.Size = new System.Drawing.Size(30, 23);
            this.BtnAdd.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.BtnAdd.TabIndex = 22;
            this.BtnAdd.Text = "+";
            this.BtnAdd.Click += new System.EventHandler(this.BtnAddClick);
            // 
            // BtnEquals
            // 
            this.BtnEquals.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.BtnEquals.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.BtnEquals.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnEquals.Location = new System.Drawing.Point(150, 94);
            this.BtnEquals.Name = "BtnEquals";
            this.BtnEquals.Size = new System.Drawing.Size(30, 52);
            this.BtnEquals.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.BtnEquals.TabIndex = 19;
            this.BtnEquals.Text = "=";
            this.BtnEquals.Click += new System.EventHandler(this.BtnEqualsClick);
            // 
            // BtnDigit4
            // 
            this.BtnDigit4.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.BtnDigit4.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.BtnDigit4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnDigit4.Location = new System.Drawing.Point(8, 65);
            this.BtnDigit4.Name = "BtnDigit4";
            this.BtnDigit4.Size = new System.Drawing.Size(30, 23);
            this.BtnDigit4.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.BtnDigit4.TabIndex = 10;
            this.BtnDigit4.Text = "4";
            this.BtnDigit4.Click += new System.EventHandler(this.BtnDigitClick);
            // 
            // BtnSubtract
            // 
            this.BtnSubtract.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.BtnSubtract.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.BtnSubtract.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnSubtract.Location = new System.Drawing.Point(114, 94);
            this.BtnSubtract.Name = "BtnSubtract";
            this.BtnSubtract.Size = new System.Drawing.Size(30, 23);
            this.BtnSubtract.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.BtnSubtract.TabIndex = 18;
            this.BtnSubtract.Text = "-";
            this.BtnSubtract.Click += new System.EventHandler(this.BtnSubtractClick);
            // 
            // BtnMultiply
            // 
            this.BtnMultiply.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.BtnMultiply.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.BtnMultiply.Font = new System.Drawing.Font("Symbol", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(2)));
            this.BtnMultiply.Location = new System.Drawing.Point(114, 65);
            this.BtnMultiply.Name = "BtnMultiply";
            this.BtnMultiply.Size = new System.Drawing.Size(30, 23);
            this.BtnMultiply.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.BtnMultiply.TabIndex = 13;
            this.BtnMultiply.Text = "*";
            this.BtnMultiply.Click += new System.EventHandler(this.BtnMultiplyClick);
            // 
            // BtnDigit6
            // 
            this.BtnDigit6.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.BtnDigit6.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.BtnDigit6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnDigit6.Location = new System.Drawing.Point(78, 65);
            this.BtnDigit6.Name = "BtnDigit6";
            this.BtnDigit6.Size = new System.Drawing.Size(30, 23);
            this.BtnDigit6.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.BtnDigit6.TabIndex = 12;
            this.BtnDigit6.Text = "6";
            this.BtnDigit6.Click += new System.EventHandler(this.BtnDigitClick);
            // 
            // BtnClear
            // 
            this.BtnClear.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.BtnClear.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.BtnClear.Location = new System.Drawing.Point(79, 6);
            this.BtnClear.Name = "BtnClear";
            this.BtnClear.Size = new System.Drawing.Size(30, 23);
            this.BtnClear.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.BtnClear.TabIndex = 2;
            this.BtnClear.Text = "C";
            this.BtnClear.Click += new System.EventHandler(this.BtnClearClick);
            // 
            // BtnDigit1
            // 
            this.BtnDigit1.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.BtnDigit1.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.BtnDigit1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnDigit1.Location = new System.Drawing.Point(8, 94);
            this.BtnDigit1.Name = "BtnDigit1";
            this.BtnDigit1.Size = new System.Drawing.Size(30, 23);
            this.BtnDigit1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.BtnDigit1.TabIndex = 15;
            this.BtnDigit1.Text = "1";
            this.BtnDigit1.Click += new System.EventHandler(this.BtnDigitClick);
            // 
            // BtnDigit2
            // 
            this.BtnDigit2.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.BtnDigit2.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.BtnDigit2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnDigit2.Location = new System.Drawing.Point(43, 94);
            this.BtnDigit2.Name = "BtnDigit2";
            this.BtnDigit2.Size = new System.Drawing.Size(30, 23);
            this.BtnDigit2.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.BtnDigit2.TabIndex = 16;
            this.BtnDigit2.Text = "2";
            this.BtnDigit2.Click += new System.EventHandler(this.BtnDigitClick);
            // 
            // BtnNegate
            // 
            this.BtnNegate.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.BtnNegate.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.BtnNegate.Location = new System.Drawing.Point(114, 6);
            this.BtnNegate.Name = "BtnNegate";
            this.BtnNegate.Size = new System.Drawing.Size(30, 23);
            this.BtnNegate.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.BtnNegate.TabIndex = 3;
            this.BtnNegate.Text = "±";
            this.BtnNegate.Click += new System.EventHandler(this.BtnNegateClick);
            // 
            // BtnDigit0
            // 
            this.BtnDigit0.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.BtnDigit0.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.BtnDigit0.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnDigit0.Location = new System.Drawing.Point(8, 123);
            this.BtnDigit0.Name = "BtnDigit0";
            this.BtnDigit0.Size = new System.Drawing.Size(65, 23);
            this.BtnDigit0.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.BtnDigit0.TabIndex = 20;
            this.BtnDigit0.Text = "0";
            this.BtnDigit0.Click += new System.EventHandler(this.BtnDigitClick);
            // 
            // BtnDigit3
            // 
            this.BtnDigit3.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.BtnDigit3.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.BtnDigit3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnDigit3.Location = new System.Drawing.Point(78, 94);
            this.BtnDigit3.Name = "BtnDigit3";
            this.BtnDigit3.Size = new System.Drawing.Size(30, 23);
            this.BtnDigit3.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.BtnDigit3.TabIndex = 17;
            this.BtnDigit3.Text = "3";
            this.BtnDigit3.Click += new System.EventHandler(this.BtnDigitClick);
            // 
            // BtnPercent
            // 
            this.BtnPercent.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.BtnPercent.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.BtnPercent.Location = new System.Drawing.Point(150, 36);
            this.BtnPercent.Name = "BtnPercent";
            this.BtnPercent.Size = new System.Drawing.Size(30, 23);
            this.BtnPercent.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.BtnPercent.TabIndex = 9;
            this.BtnPercent.Text = "%";
            this.BtnPercent.Click += new System.EventHandler(this.BtnPercentClick);
            // 
            // BtnDigit7
            // 
            this.BtnDigit7.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.BtnDigit7.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.BtnDigit7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnDigit7.Location = new System.Drawing.Point(8, 36);
            this.BtnDigit7.Name = "BtnDigit7";
            this.BtnDigit7.Size = new System.Drawing.Size(30, 23);
            this.BtnDigit7.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.BtnDigit7.TabIndex = 5;
            this.BtnDigit7.Text = "7";
            this.BtnDigit7.Click += new System.EventHandler(this.BtnDigitClick);
            // 
            // pnlMem
            // 
            this.pnlMem.CanvasColor = System.Drawing.SystemColors.Control;
            this.pnlMem.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.pnlMem.Controls.Add(this.BtnMemStore);
            this.pnlMem.Controls.Add(this.lbxOperator);
            this.pnlMem.Controls.Add(this.BtnMemRestore);
            this.pnlMem.Controls.Add(this.BtnMemAdd);
            this.pnlMem.Controls.Add(this.BtnMemClear);
            this.pnlMem.Controls.Add(this.BtnMemSubtract);
            this.pnlMem.Controls.Add(this.lbxMemory);
            this.pnlMem.Location = new System.Drawing.Point(1, 33);
            this.pnlMem.Name = "pnlMem";
            this.pnlMem.Size = new System.Drawing.Size(187, 26);
            this.pnlMem.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.pnlMem.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground;
            this.pnlMem.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder;
            this.pnlMem.Style.BorderWidth = 0;
            this.pnlMem.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText;
            this.pnlMem.Style.GradientAngle = 90;
            this.pnlMem.TabIndex = 34;
            // 
            // BtnMemStore
            // 
            this.BtnMemStore.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.BtnMemStore.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.BtnMemStore.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnMemStore.Location = new System.Drawing.Point(80, 6);
            this.BtnMemStore.Name = "BtnMemStore";
            this.BtnMemStore.Size = new System.Drawing.Size(27, 18);
            this.BtnMemStore.TabIndex = 0;
            this.BtnMemStore.Text = "MS";
            this.BtnMemStore.Click += new System.EventHandler(this.BtnMemStoreClick);
            // 
            // lbxOperator
            // 
            // 
            // 
            // 
            this.lbxOperator.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lbxOperator.Font = new System.Drawing.Font("Symbol", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(2)));
            this.lbxOperator.Location = new System.Drawing.Point(174, 6);
            this.lbxOperator.Name = "lbxOperator";
            this.lbxOperator.Size = new System.Drawing.Size(12, 18);
            this.lbxOperator.TabIndex = 33;
            this.lbxOperator.TextAlignment = System.Drawing.StringAlignment.Center;
            // 
            // BtnMemRestore
            // 
            this.BtnMemRestore.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.BtnMemRestore.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.BtnMemRestore.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnMemRestore.Location = new System.Drawing.Point(48, 6);
            this.BtnMemRestore.Name = "BtnMemRestore";
            this.BtnMemRestore.Size = new System.Drawing.Size(27, 18);
            this.BtnMemRestore.TabIndex = 6;
            this.BtnMemRestore.Text = "MR";
            this.BtnMemRestore.Click += new System.EventHandler(this.BtnMemRestoreClick);
            // 
            // BtnMemAdd
            // 
            this.BtnMemAdd.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.BtnMemAdd.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.BtnMemAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnMemAdd.Location = new System.Drawing.Point(112, 6);
            this.BtnMemAdd.Name = "BtnMemAdd";
            this.BtnMemAdd.Size = new System.Drawing.Size(27, 18);
            this.BtnMemAdd.TabIndex = 1;
            this.BtnMemAdd.Text = "M+";
            this.BtnMemAdd.Click += new System.EventHandler(this.BtnMemAddClick);
            // 
            // BtnMemClear
            // 
            this.BtnMemClear.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.BtnMemClear.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.BtnMemClear.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnMemClear.Location = new System.Drawing.Point(16, 6);
            this.BtnMemClear.Name = "BtnMemClear";
            this.BtnMemClear.Size = new System.Drawing.Size(27, 18);
            this.BtnMemClear.TabIndex = 5;
            this.BtnMemClear.Text = "MC";
            this.BtnMemClear.Click += new System.EventHandler(this.BtnMemClearClick);
            // 
            // BtnMemSubtract
            // 
            this.BtnMemSubtract.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.BtnMemSubtract.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.BtnMemSubtract.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnMemSubtract.Location = new System.Drawing.Point(144, 6);
            this.BtnMemSubtract.Name = "BtnMemSubtract";
            this.BtnMemSubtract.Size = new System.Drawing.Size(27, 18);
            this.BtnMemSubtract.TabIndex = 2;
            this.BtnMemSubtract.Text = "M-";
            this.BtnMemSubtract.Click += new System.EventHandler(this.BtnMemSubtractClick);
            // 
            // lbxMemory
            // 
            // 
            // 
            // 
            this.lbxMemory.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lbxMemory.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbxMemory.Location = new System.Drawing.Point(4, 5);
            this.lbxMemory.Name = "lbxMemory";
            this.lbxMemory.Size = new System.Drawing.Size(12, 18);
            this.lbxMemory.TabIndex = 31;
            this.lbxMemory.TextAlignment = System.Drawing.StringAlignment.Center;
            // 
            // labelValue
            // 
            // 
            // 
            // 
            this.labelValue.BackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.MenuBackground;
            //this.labelValue.BackgroundStyle.BackColorGradientAngle = 90;
            //this.labelValue.BackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.DockSiteBackColor2;
            this.labelValue.BackgroundStyle.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.labelValue.BackgroundStyle.BorderBottomColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.labelValue.BackgroundStyle.BorderBottomWidth = 1;
            this.labelValue.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelValue.BackgroundStyle.PaddingRight = 6;
            this.labelValue.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelValue.Font = new System.Drawing.Font("Consolas", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelValue.Location = new System.Drawing.Point(1, 1);
            this.labelValue.Name = "labelValue";
            this.labelValue.Size = new System.Drawing.Size(188, 30);
            this.labelValue.TabIndex = 1;
            this.labelValue.Text = "0";
            this.labelValue.TextAlignment = System.Drawing.StringAlignment.Far;
            this.labelValue.BackgroundStyle.TextTrimming = DevComponents.DotNetBar.eStyleTextTrimming.Character;
            // 
            // Calculator
            // 
            this.Controls.Add(this.pnlCalc);
            this.Name = "Calculator";
            this.Size = new System.Drawing.Size(190, 212);
            this.pnlCalc.ResumeLayout(false);
            this.pnlPad.ResumeLayout(false);
            this.pnlMem.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.PanelEx pnlCalc;
        private DevComponents.DotNetBar.LabelX lbxMemory;
        private DevComponents.DotNetBar.LabelX lbxOperator;
        private DevComponents.DotNetBar.PanelEx pnlMem;
        private DevComponents.DotNetBar.PanelEx pnlPad;
        public DevComponents.DotNetBar.ButtonX BtnNegate;
        public DevComponents.DotNetBar.ButtonX BtnDecimal;
        public DevComponents.DotNetBar.ButtonX BtnDigit7;
        public DevComponents.DotNetBar.ButtonX BtnBack;
        public DevComponents.DotNetBar.ButtonX BtnMemClear;
        public DevComponents.DotNetBar.ButtonX BtnMemRestore;
        public DevComponents.DotNetBar.ButtonX BtnMemStore;
        public DevComponents.DotNetBar.ButtonX BtnMemSubtract;
        public DevComponents.DotNetBar.ButtonX BtnSqrt;
        public DevComponents.DotNetBar.ButtonX BtnPercent;
        public DevComponents.DotNetBar.ButtonX BtnReciprocal;
        public DevComponents.DotNetBar.ButtonX BtnDivide;
        public DevComponents.DotNetBar.ButtonX BtnMultiply;
        public DevComponents.DotNetBar.ButtonX BtnSubtract;
        public DevComponents.DotNetBar.ButtonX BtnAdd;
        public DevComponents.DotNetBar.ButtonX BtnClear;
        public DevComponents.DotNetBar.ButtonX BtnDigit4;
        public DevComponents.DotNetBar.ButtonX BtnDigit2;
        public DevComponents.DotNetBar.ButtonX BtnClearEntry;
        public DevComponents.DotNetBar.ButtonX BtnDigit9;
        public DevComponents.DotNetBar.ButtonX BtnDigit6;
        public DevComponents.DotNetBar.ButtonX BtnDigit3;
        public DevComponents.DotNetBar.ButtonX BtnDigit1;
        public DevComponents.DotNetBar.ButtonX BtnDigit8;
        public DevComponents.DotNetBar.ButtonX BtnDigit5;
        public DevComponents.DotNetBar.ButtonX BtnDigit0;
        public DevComponents.DotNetBar.ButtonX BtnMemAdd;
        public DevComponents.DotNetBar.ButtonX BtnEquals;
        private DevComponents.DotNetBar.LabelX labelValue;


    }
}
