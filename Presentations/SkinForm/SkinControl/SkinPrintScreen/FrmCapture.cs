﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using CCWin.Win32;
using CCWin.Win32.Struct;
using System.Drawing.Drawing2D;

namespace CCWin.SkinControl
{
    public partial class FrmCapture : Form
    {
        public FrmCapture() {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.None;
            this.Location = new Point(0, 0);
            this.Size = new Size(Screen.PrimaryScreen.Bounds.Width,
                Screen.PrimaryScreen.Bounds.Height);
            this.TopMost = true;
            this.ShowInTaskbar = false;

            m_MHook = new MouseHook();
            this.FormClosing += (s, e) => { m_MHook.UnLoadHook(); this.DelResource(); };
            imgpb.MouseLeave += (s, e) => this.Cursor = Cursors.Default;
            //后期一些操作历史记录图层
            m_layer = new List<Bitmap>();
        }

        private RtfRichTextBox RcTxt = null;
        public FrmCapture(RtfRichTextBox rcTxt)
        {
            InitializeComponent();
            this.RcTxt = rcTxt;
            this.FormBorderStyle = FormBorderStyle.None;
            this.Location = new Point(0, 0);
            this.Size = new Size(Screen.PrimaryScreen.Bounds.Width,
                Screen.PrimaryScreen.Bounds.Height);
            this.TopMost = true;
            this.ShowInTaskbar = false;

            m_MHook = new MouseHook();
            this.FormClosing += (s, e) => { m_MHook.UnLoadHook(); this.DelResource(); };
            imgpb.MouseLeave += (s, e) => this.Cursor = Cursors.Default;
            //后期一些操作历史记录图层
            m_layer = new List<Bitmap>();
        }

        private void DelResource() {
            if (m_bmpLayerCurrent != null) m_bmpLayerCurrent.Dispose();
            if (m_bmpLayerShow != null) m_bmpLayerShow.Dispose();
            m_layer.Clear();
            imgpb.DeleResource();
            GC.Collect();
        }

        #region Properties

        private bool isCaptureCursor;
        /// <summary>
        /// 获取或设置是否捕获鼠标
        /// </summary>
        public bool IsCaptureCursor {
            get { return isCaptureCursor; }
            set { isCaptureCursor = value; }
        }
        /// <summary>
        /// 获取或设置是否显示图像信息
        /// </summary>
        public bool ImgProcessBoxIsShowInfo {
            get { return imgpb.IsShowInfo; }
            set { imgpb.IsShowInfo = value; }
        }
        /// <summary>
        /// 获取或设置操作框点的颜色
        /// </summary>
        public Color ImgProcessBoxDotColor {
            get { return imgpb.DotColor; }
            set { imgpb.DotColor = value; }
        }
        /// <summary>
        /// 获取或设置操作框边框颜色
        /// </summary>
        public Color ImgProcessBoxLineColor {
            get { return imgpb.LineColor; }
            set { imgpb.LineColor = value; }
        }
        /// <summary>
        /// 获取或设置放大图形的原始尺寸
        /// </summary>
        public Size ImgProcessBoxMagnifySize {
            get { return imgpb.MagnifySize; }
            set { imgpb.MagnifySize = value; }
        }
        /// <summary>
        /// 获取或设置放大图像的倍数
        /// </summary>
        public int ImgProcessBoxMagnifyTimes {
            get { return imgpb.MagnifyTimes; }
            set { imgpb.MagnifyTimes = value; }
        }

        #endregion

        //初始化参数
        private void InitMember() {
            panel1.Visible = false;
            panel2.Visible = false;
            panel1.BackColor = Color.White;
            panel2.BackColor = Color.White;
            panel1.Height = tBtn_Finish.Bottom + 3;
            panel1.Width = tBtn_Finish.Right + 3;
            panel2.Height = colorBox1.Height;
            panel1.Paint += (s, e) => e.Graphics.DrawRectangle(Pens.SteelBlue, 0, 0, panel1.Width - 1, panel1.Height - 1);
            panel2.Paint += (s, e) => e.Graphics.DrawRectangle(Pens.SteelBlue, 0, 0, panel2.Width - 1, panel2.Height - 1);

            tBtn_Rect.Click += new EventHandler(selectToolButton_Click);
            tBtn_Ellipse.Click += new EventHandler(selectToolButton_Click);
            tBtn_Arrow.Click += new EventHandler(selectToolButton_Click);
            tBtn_Brush.Click += new EventHandler(selectToolButton_Click);
            tBtn_Text.Click += new EventHandler(selectToolButton_Click);
            tBtn_Close.Click += (s, e) => this.Close();

            textBox1.BorderStyle = BorderStyle.None;
            textBox1.Visible = false;
            textBox1.ForeColor = Color.Red;
            colorBox1.ColorChanged += (s, e) => textBox1.ForeColor = e.Color;
        }

        private MouseHook m_MHook;
        private List<Bitmap> m_layer;       //记录历史图层

        private bool m_isStartDraw;
        private Point m_ptOriginal;
        private Point m_ptCurrent;
        private Bitmap m_bmpLayerCurrent;
        private Bitmap m_bmpLayerShow;

        private void FrmCapture_Load(object sender, EventArgs e) {
            this.InitMember();
            imgpb.BaseImage = this.GetScreen();
            m_MHook.SetHook();
            m_MHook.MHookEvent += new MouseHook.MHookEventHandler(m_MHook_MHookEvent);
            imgpb.IsDrawOperationDot = false;
            this.BeginInvoke(new MethodInvoker(() => this.Enabled = false));
            timer1.Interval = 500;
            timer1.Enabled = true;
        }

        private void m_MHook_MHookEvent(object sender, MHookEventArgs e) {
            //如果窗体禁用 调用控件的方法设置信息显示位置
            if (!this.Enabled)      //貌似Hook不能精确坐标(Hook最先执行执 执行完后的坐标可能与执行时传入的坐标发生了变化 猜测是这样) 所以放置了一个timer检测
                imgpb.SetInfoPoint(MousePosition.X, MousePosition.Y);
            //鼠标点下恢复窗体禁用
            if (e.MButton == ButtonStatus.LeftDown || e.MButton == ButtonStatus.RightDown) {
                this.Enabled = true;
                imgpb.IsDrawOperationDot = true;
            }

            #region 在imageProcessBox_MouseUp中完成了
            //if (e.MButton == ButtonStatus.LeftUp) {
            //    //if (imageProcessBox1.SelectedRectangle.Width < 5
            //    //    || imageProcessBox1.SelectedRectangle.Height < 5) {
            //    //    //如果选取区域不符要求 向控件模拟鼠标抬起 然后禁用窗体
            //    //    //(Hook事件先于控件事件 禁用控件时模拟一个鼠标抬起)
            //    //    Win32.SendMessage(imageProcessBox1.Handle, Win32.WM_LBUTTONUP,
            //    //        IntPtr.Zero, (IntPtr)(MousePosition.Y << 16 | MousePosition.X));
            //    //    this.Enabled = false;
            //    //    imageProcessBox1.IsDrawOperationDot = false;
            //    //} else
            //    //    this.SetToolBarLocation();  //重置工具条位置
            //}
            #endregion

            #region 右键抬起

            if (e.MButton == ButtonStatus.RightUp) {
                if (!imgpb.IsDrawed) //没有绘制那么退出(直接this.Close右键将传递到下面)
                    this.BeginInvoke(new MethodInvoker(() => this.Close()));
                //有绘制的情况 情况继续禁用窗体
                this.Enabled = false;
                imgpb.ClearDraw();
                imgpb.CanReset = true;
                imgpb.IsDrawOperationDot = false;
                m_layer.Clear();    //清空历史记录
                m_bmpLayerCurrent = null;
                m_bmpLayerShow = null;
                ClearToolBarBtnSelected();
                panel1.Visible = false;
                panel2.Visible = false;
            }

            #endregion

            #region 找寻窗体

            if (!this.Enabled) {
                this.FoundAndDrawWindowRect();
            }

            #endregion

        }
        //工具条前五个按钮绑定的公共事件
        private void selectToolButton_Click(object sender, EventArgs e) {
            panel2.Visible = ((ToolButton)sender).IsSelected;
            if (panel2.Visible) imgpb.CanReset = false;
            else { imgpb.CanReset = m_layer.Count == 0; }
            this.SetToolBarLocation();
        }

        #region 截图后的一些后期绘制

        private void imageProcessBox1_MouseDown(object sender, MouseEventArgs e) {
            if (imgpb.Cursor != Cursors.SizeAll &&
                imgpb.Cursor != Cursors.Default)
                panel1.Visible = false;         //表示改变选取大小 隐藏工具条
            //若果在选取类点击 并且有选择工具
            if (e.Button == MouseButtons.Left && imgpb.IsDrawed && HaveSelectedToolButton()) {
                if (imgpb.SelectedRectangle.Contains(e.Location)) {
                    if (tBtn_Text.IsSelected) {         //如果选择的是绘制文本 弹出文本框
                        textBox1.Location = e.Location;
                        textBox1.Visible = true;
                        textBox1.Focus();
                        return;
                    }
                    m_isStartDraw = true;
                    Cursor.Clip = imgpb.SelectedRectangle;
                }
            }
            m_ptOriginal = e.Location;
        }

        private void imageProcessBox1_MouseMove(object sender, MouseEventArgs e) {
            m_ptCurrent = e.Location;
            //根据是否选择有工具决定 鼠标指针样式
            if (imgpb.SelectedRectangle.Contains(e.Location) && HaveSelectedToolButton() && imgpb.IsDrawed)
                this.Cursor = Cursors.Cross;
            else if (!imgpb.SelectedRectangle.Contains(e.Location))
                this.Cursor = Cursors.Default;

            if (imgpb.IsStartDraw && panel1.Visible)   //在重置选取的时候 重置工具条位置(成立于移动选取的时候)
                this.SetToolBarLocation();
            if (m_isStartDraw && m_bmpLayerShow != null) {        //如果在区域内点下那么绘制相应图形
                using (Graphics g = Graphics.FromImage(m_bmpLayerShow)) {
                    int tempWidth = 1;
                    if (toolButton2.IsSelected) tempWidth = 3;
                    if (toolButton3.IsSelected) tempWidth = 5;
                    Pen p = new Pen(colorBox1.SelectedColor, tempWidth);
                    g.SmoothingMode = SmoothingMode.HighQuality;
                    #region   绘制矩形

                    if (tBtn_Rect.IsSelected) {
                        int tempX = e.X - m_ptOriginal.X > 0 ? m_ptOriginal.X : e.X;
                        int tempY = e.Y - m_ptOriginal.Y > 0 ? m_ptOriginal.Y : e.Y;
                        g.Clear(Color.Transparent);
                        g.DrawRectangle(p, tempX - imgpb.SelectedRectangle.Left, tempY - imgpb.SelectedRectangle.Top, Math.Abs(e.X - m_ptOriginal.X), Math.Abs(e.Y - m_ptOriginal.Y));
                        imgpb.Invalidate();
                    }

                    #endregion

                    #region    绘制圆形

                    if (tBtn_Ellipse.IsSelected) {
                        g.DrawLine(Pens.Red, 0, 0, 200, 200);
                        g.Clear(Color.Transparent);
                        g.DrawEllipse(p, m_ptOriginal.X - imgpb.SelectedRectangle.Left, m_ptOriginal.Y - imgpb.SelectedRectangle.Top, e.X - m_ptOriginal.X, e.Y - m_ptOriginal.Y);
                        imgpb.Invalidate();
                    }

                    #endregion

                    #region    绘制箭头

                    if (tBtn_Arrow.IsSelected) {
                        g.Clear(Color.Transparent);
                        System.Drawing.Drawing2D.AdjustableArrowCap lineArrow =
                            new System.Drawing.Drawing2D.AdjustableArrowCap(4, 4, true);
                        p.CustomEndCap = lineArrow;
                        g.DrawLine(p, (Point)((Size)m_ptOriginal - (Size)imgpb.SelectedRectangle.Location), (Point)((Size)m_ptCurrent - (Size)imgpb.SelectedRectangle.Location));
                        imgpb.Invalidate();
                    }

                    #endregion

                    #region    绘制线条

                    if (tBtn_Brush.IsSelected) {
                        Point ptTemp = (Point)((Size)m_ptOriginal - (Size)imgpb.SelectedRectangle.Location);
                        p.LineJoin = System.Drawing.Drawing2D.LineJoin.Round;
                        g.DrawLine(p, ptTemp, (Point)((Size)e.Location - (Size)imgpb.SelectedRectangle.Location));
                        m_ptOriginal = e.Location;
                        imgpb.Invalidate();
                    }

                    #endregion

                    p.Dispose();
                }
            }
        }

        private void imageProcessBox1_MouseUp(object sender, MouseEventArgs e) {
            if (!imgpb.IsDrawed) {       //如果没有成功绘制选取 继续禁用窗体
                this.Enabled = false;
                imgpb.IsDrawOperationDot = false;
            } else if (!panel1.Visible) {            //否则显示工具条
                this.SetToolBarLocation();  //重置工具条位置
                panel1.Visible = true;
                m_bmpLayerCurrent = imgpb.GetResultBmp();    //获取选取图形
                m_bmpLayerShow = new Bitmap(m_bmpLayerCurrent.Width, m_bmpLayerCurrent.Height);
            }
            //如果移动了选取位置 重新获取选取的图形
            if (imgpb.Cursor == Cursors.SizeAll && m_ptOriginal != e.Location)
                m_bmpLayerCurrent = imgpb.GetResultBmp();

            if (!m_isStartDraw) return;
            Cursor.Clip = Rectangle.Empty;
            m_isStartDraw = false;
            if (e.Location == m_ptOriginal && !tBtn_Brush.IsSelected) return;
            this.SetLayer();        //将绘制的图形绘制到历史图层中
        }
        //绘制后期操作
        private void imageProcessBox1_Paint(object sender, PaintEventArgs e) {
            Graphics g = e.Graphics;
            if (m_layer.Count > 0)  //绘制保存的历史记录的最后一张图
                g.DrawImage(m_layer[m_layer.Count - 1], imgpb.SelectedRectangle.Location);
            if (m_bmpLayerShow != null)     //绘制当前正在拖动绘制的图形(即鼠标点下还没有抬起确认的图形)
                g.DrawImage(m_bmpLayerShow, imgpb.SelectedRectangle.Location);
        }

        #endregion

        //文本改变时重置文本框大小
        private void textBox1_TextChanged(object sender, EventArgs e) {
            Size se = TextRenderer.MeasureText(textBox1.Text, textBox1.Font);
            textBox1.Size = se.IsEmpty ? new Size(50, textBox1.Font.Height) : se;
        }
        //文本框失去焦点时 绘制文本
        private void textBox1_Validating(object sender, CancelEventArgs e) {
            textBox1.Visible = false;
            if (string.IsNullOrEmpty(textBox1.Text.Trim())) { textBox1.Text = ""; return; }
            using (Graphics g = Graphics.FromImage(m_bmpLayerCurrent)) {
                SolidBrush sb = new SolidBrush(colorBox1.SelectedColor);
                g.DrawString(textBox1.Text, textBox1.Font, sb,
                    textBox1.Left - imgpb.SelectedRectangle.Left,
                    textBox1.Top - imgpb.SelectedRectangle.Top);
                sb.Dispose();
                textBox1.Text = "";
                this.SetLayer();        //将文本绘制到当前图层并存入历史记录
                imgpb.Invalidate();
            }
        }
        //窗体大小改变时重置字体 从控件中获取字体大小
        private void textBox1_Resize(object sender, EventArgs e) {
            //在三个大小选择的按钮点击中设置字体大小太麻烦 所以Resize中获取设置
            int se = 10;
            if (toolButton2.IsSelected) se = 12;
            if (toolButton3.IsSelected) se = 14;
            if (this.textBox1.Font.Height == se) return;
            textBox1.Font = new Font(this.Font.FontFamily, se);
        }
        //撤销
        private void tBtn_Cancel_Click(object sender, EventArgs e) {
            using (Graphics g = Graphics.FromImage(m_bmpLayerShow)) {
                g.Clear(Color.Transparent);     //情况当前临时显示的图像
            }
            if (m_layer.Count > 0) {            //删除最后一层
                m_layer.RemoveAt(m_layer.Count - 1);
                if (m_layer.Count > 0)
                    m_bmpLayerCurrent = m_layer[m_layer.Count - 1].Clone(new Rectangle(0, 0, m_bmpLayerCurrent.Width, m_bmpLayerCurrent.Height), m_bmpLayerCurrent.PixelFormat);
                else
                    m_bmpLayerCurrent = imgpb.GetResultBmp();
                imgpb.Invalidate();
                imgpb.CanReset = m_layer.Count == 0 && !HaveSelectedToolButton();
            } else {                            //如果没有历史记录则取消本次截图
                this.Enabled = false;
                imgpb.ClearDraw();
                imgpb.IsDrawOperationDot = false;
                panel1.Visible = false;
                panel2.Visible = false;
            }
        }

        private void tBtn_Save_Click(object sender, EventArgs e) {
            SaveFileDialog saveDlg = new SaveFileDialog();
            saveDlg.Filter = "位图(*.bmp)|*.bmp|JPEG(*.jpg)|*.jpg";
            saveDlg.FilterIndex = 1;
            saveDlg.FileName = "CAPTURE_" + GetTimeString();
            if (saveDlg.ShowDialog() == DialogResult.OK) {
                switch (saveDlg.FilterIndex) {
                    case 1:
                        m_bmpLayerCurrent.Clone(new Rectangle(0, 0, m_bmpLayerCurrent.Width, m_bmpLayerCurrent.Height),
                            System.Drawing.Imaging.PixelFormat.Format24bppRgb).Save(saveDlg.FileName,
                            System.Drawing.Imaging.ImageFormat.Bmp);
                        this.Close();
                        break;
                    case 2:
                        m_bmpLayerCurrent.Save(saveDlg.FileName,
                            System.Drawing.Imaging.ImageFormat.Jpeg);
                        this.Close();
                        break;
                }
            }
        }
        //将图像保存到剪贴板
        private void tBtn_Finish_Click(object sender, EventArgs e) {
            Clipboard.SetImage(m_bmpLayerCurrent);
            if (RcTxt != null)
            {
                RcTxt.Paste();
            }
            this.Close();
        }

        private void imageProcessBox1_DoubleClick(object sender, EventArgs e) {
            Clipboard.SetImage(m_bmpLayerCurrent);
            if (RcTxt != null)
            {
                RcTxt.Paste();
            }
            this.Close();
        }

        private void timer1_Tick(object sender, EventArgs e) {
            if (!this.Enabled)
                imgpb.SetInfoPoint(MousePosition.X, MousePosition.Y);
        }
        //根据鼠标位置找寻窗体平绘制边框
        private void FoundAndDrawWindowRect() {
            NativeMethods.Point pt = new NativeMethods.Point();
            pt.x = MousePosition.X; pt.y = MousePosition.Y;
            IntPtr hWnd = NativeMethods.ChildWindowFromPointEx(NativeMethods.GetDesktopWindow(), pt,
                NativeMethods.CWP_SKIPINVISIBL | NativeMethods.CWP_SKIPDISABLED);
            if (hWnd != IntPtr.Zero) {
                IntPtr hTemp = hWnd;
                while (true) {
                    NativeMethods.ScreenToClient(hTemp, ref pt);
                    hTemp = NativeMethods.ChildWindowFromPointEx(hTemp, pt, NativeMethods.CWP_All);
                    if (hTemp == IntPtr.Zero || hTemp == hWnd)
                        break;
                    hWnd = hTemp;
                    pt.x = MousePosition.X; pt.y = MousePosition.Y; //坐标还原为屏幕坐标
                }
                RECT rect = new RECT();
                NativeMethods.GetWindowRect(hWnd, ref rect);
                imgpb.SetSelectRect(new Rectangle(rect.Left, rect.Top, rect.Right - rect.Left, rect.Bottom - rect.Top));
            }
        }
        //获取桌面图像
        private Bitmap GetScreen() {
            Bitmap bmp = new Bitmap(Screen.PrimaryScreen.Bounds.Width,
                    Screen.PrimaryScreen.Bounds.Height);
            if (this.isCaptureCursor) {     //是否捕获鼠标
                //如果直接将捕获当的鼠标画在bmp上 光标不会反色 指针边框也很浓 也就是说
                //尽管bmp上绘制了图像 绘制鼠标的时候还是以黑色作为鼠标的背景 然后在将混合好的鼠标绘制到图像 会很别扭
                //所以 干脆直接在桌面把鼠标绘制出来再截取桌面
                using (Graphics g = Graphics.FromHwnd(IntPtr.Zero)) {   //传入0默认就是桌面 Win32.GetDesktopWindow()也可以
                    NativeMethods.PCURSORINFO pci;
                    pci.cbSize = System.Runtime.InteropServices.Marshal.SizeOf(typeof(NativeMethods.PCURSORINFO));
                    NativeMethods.GetCursorInfo(out pci);
                    if (pci.hCursor != IntPtr.Zero) {
                        Cursor cur = new Cursor(pci.hCursor);
                        g.CopyFromScreen(0, 0, 0, 0, bmp.Size); //在桌面绘制鼠标前 先在桌面绘制一下当前的桌面图像
                        //如果不绘制当前桌面 那么cur.Draw的时候会是用历史桌面的快照 进行鼠标的混合 那么到时候混出现底色(测试中就是这样的)
                        cur.Draw(g, new Rectangle((Point)((Size)MousePosition - (Size)cur.HotSpot), cur.Size));
                    }
                }
            }
            //做完以上操作 才开始捕获桌面图像
            using (Graphics g = Graphics.FromImage(bmp)) {
                g.CopyFromScreen(0, 0, 0, 0, bmp.Size);
            }
            return bmp;
        }
        //设置工具条位置
        private void SetToolBarLocation() {
            int tempX = imgpb.SelectedRectangle.Left;
            int tempY = imgpb.SelectedRectangle.Bottom + 5;
            int tempHeight = panel2.Visible ? panel2.Height + 2 : 0;
            if (tempY + panel1.Height + tempHeight >= this.Height)
                tempY = imgpb.SelectedRectangle.Top - panel1.Height - 10 - imgpb.Font.Height;

            if (tempY - tempHeight <= 0) {
                if (imgpb.SelectedRectangle.Top - 5 - imgpb.Font.Height >= 0)
                    tempY = imgpb.SelectedRectangle.Top + 5;
                else
                    tempY = imgpb.SelectedRectangle.Top + 10 + imgpb.Font.Height;
            }
            if (tempX + panel1.Width >= this.Width)
                tempX = this.Width - panel1.Width - 5;
            panel1.Left = tempX;
            panel2.Left = tempX;
            panel1.Top = tempY;
            panel2.Top = imgpb.SelectedRectangle.Top > tempY ? tempY - tempHeight : panel1.Bottom + 2;
        }
        //确定是否工具条上面有被选中的按钮
        private bool HaveSelectedToolButton() {
            return tBtn_Rect.IsSelected || tBtn_Ellipse.IsSelected
                || tBtn_Arrow.IsSelected || tBtn_Brush.IsSelected
                || tBtn_Text.IsSelected;
        }
        //清空选中的工具条上的工具
        private void ClearToolBarBtnSelected() {
            tBtn_Rect.IsSelected = tBtn_Ellipse.IsSelected = tBtn_Arrow.IsSelected =
                tBtn_Brush.IsSelected = tBtn_Text.IsSelected = false;
        }
        //设置历史图层
        private void SetLayer() {
            if (this.IsDisposed) return;
            using (Graphics g = Graphics.FromImage(m_bmpLayerCurrent)) {
                g.DrawImage(m_bmpLayerShow, 0, 0);
            }
            Bitmap bmpTemp = m_bmpLayerCurrent.Clone(new Rectangle(0, 0, m_bmpLayerCurrent.Width, m_bmpLayerCurrent.Height), m_bmpLayerCurrent.PixelFormat);
            m_layer.Add(bmpTemp);
        }
        //保存时获取当前时间字符串作文默认文件名
        private string GetTimeString() {
            DateTime time = DateTime.Now;
            return time.Date.ToShortDateString().Replace("/", "") + "_" +
                time.ToLongTimeString().Replace(":", "");
        }
    }
}
