using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using System.Windows.Forms.Design;

namespace DevComponents.Instrumentation.Design
{
    [ToolboxItem(false)]
    public partial class SizeDropDown : UserControl
    {
        #region Constants

        private const int DotRadius = 4;

        #endregion

        #region Private variables

        private SizeF _Size;
        private Rectangle _DotBounds;
        private Rectangle _FrameBounds;
        private Rectangle _DotRect;

        private bool _InFrame;
        private bool _InSizeDot;
        private bool _PivotMoving;

        private bool _EscapePressed;

        private IWindowsFormsEditorService _EditorService;
        private ITypeDescriptorContext _Context;

        #endregion

        public SizeDropDown(SizeF value,
            IWindowsFormsEditorService editorService, ITypeDescriptorContext context)
        {
            Initialize();

            _EditorService = editorService;
            _Context = context;

            _Size = value;
        }

        public SizeDropDown()
        {
            Initialize();
        }

        #region Initialize

        private void Initialize()
        {
            InitializeComponent();

            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
        }

        #endregion

        #region Public properties

        #region EditorService

        public IWindowsFormsEditorService EditorService
        {
            get { return (_EditorService); }
            set { _EditorService = value; }
        }

        #endregion

        #region EscapePressed

        public bool EscapePressed
        {
            get { return (_EscapePressed); }
            set { _EscapePressed = value; }
        }

        #endregion

        #region PivotPoint

        public SizeF Syze
        {
            get { return (_Size); }

            set
            {
                _Size = value;

                RecalcLayout();
                Invalidate();

                _Context.OnComponentChanging();
                _Context.PropertyDescriptor.SetValue(_Context.Instance, value);
                _Context.OnComponentChanged();
            }
        }

        #endregion

        #endregion

        #region RecalcLayout

        private void RecalcLayout()
        {
            int n = Math.Min(Bounds.Width - 4, Bounds.Height - 4);

            _FrameBounds = new Rectangle(2, 2, n, n);
            _FrameBounds.X = (Bounds.Width - n) / 2;
            _FrameBounds.Y = (Bounds.Height - n) / 2;

            int x = _FrameBounds.X + (int)(_Size.Width * _FrameBounds.Width);
            int y = _FrameBounds.Y + (int)(_Size.Height * _FrameBounds.Height);

            _DotBounds = new Rectangle(x - DotRadius, y - DotRadius,
                DotRadius * 2, DotRadius * 2);

            _DotRect = new Rectangle(0, 0, x, y);
        }

        #endregion

        #region Paint support

        #region OnPaint

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            Graphics g = e.Graphics;

            g.SmoothingMode = SmoothingMode.AntiAlias;

            RecalcLayout();

            g.DrawRectangle(Pens.Red, _DotRect);

            DrawPivotDot(g);
        }

        #endregion

        #region DrawPivotDot

        private void DrawPivotDot(Graphics g)
        {
            g.FillEllipse(Brushes.SkyBlue, _DotBounds);
            g.DrawEllipse(Pens.DimGray, _DotBounds);
        }

        #endregion

        #endregion

        #region Mouse support

        #region OnMouseMove

        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);

            _InFrame = (_FrameBounds.Contains(e.Location) == true);

            if (_PivotMoving == true && _InFrame == true)
            {
                Syze = new SizeF(
                    (float)(e.X - _FrameBounds.X) / _FrameBounds.Width,
                    (float)(e.Y - _FrameBounds.Y) / _FrameBounds.Height);
            }

            _InSizeDot = (_DotBounds.Contains(e.Location) == true);

            Cursor = (_InSizeDot == true) ? Cursors.Hand : Cursors.Default;
        }

        #endregion

        #region OnMouseLeave

        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);

            _InFrame = false;
            _InSizeDot = false;
        }

        #endregion

        #region OnMouseDown

        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);

            if (e.Button == MouseButtons.Left)
            {
                if (_InSizeDot == true)
                    _PivotMoving = true;
            }
        }

        #endregion

        #region OnMouseUp

        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);

            _PivotMoving = false;

            _InFrame = (_FrameBounds.Contains(e.Location) == true);
            _InSizeDot = (_DotBounds.Contains(e.Location) == true);
        }

        #endregion

        #endregion

        #region PivotPointDropDown_PreviewKeyDown

        private void PivotPointDropDown_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                _EscapePressed = true;
        }

        #endregion
    }
}
