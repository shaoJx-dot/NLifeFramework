using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using DevComponents.DotNetBar.SuperGrid.Style;

namespace DevComponents.DotNetBar.SuperGrid
{
    ///<summary>
    /// GridButtonXEditControl
    ///</summary>
    [ToolboxItem(false)]
    public class GridButtonXEditControl : ButtonX, IGridCellEditControl
    {
        #region Private variables

        private GridCell _Cell;
        private EditorPanel _EditorPanel;
        private Bitmap _EditorCellBitmap;

        private bool _ValueChanged;
        private bool _SuspendUpdate;
        private bool _UseCellValueAsButtonText = true;

        private StretchBehavior _StretchBehavior = StretchBehavior.Both;

        #endregion

        ///<summary>
        /// GridButtXEditControl
        ///</summary>
        public GridButtonXEditControl()
        {
            AutoCheckOnClick = false;
            AutoExpandOnClick = false;
            AutoSizeMode = AutoSizeMode.GrowAndShrink;

            ColorTable = eButtonColor.OrangeWithBackground;
            Style = eDotNetBarStyle.StyleManagerControlled;

            Click += ButtonXClick;
            ButtonItem.ExpandChange += ButtonXExpandChanged;
        }

        #region Hidden properties

        ///<summary>
        /// AutoCheckOnClick
        ///</summary>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public new bool AutoCheckOnClick
        {
            get { return (base.AutoCheckOnClick); }
            set { base.AutoCheckOnClick = value; }
        }

        #endregion

        #region Public properties

        #region FocusCuesEnabled

        public override bool FocusCuesEnabled
        {
            get { return (false); }
            set { base.FocusCuesEnabled = value; }
        }

        #endregion

        #region UseCellValueAsButtonText

        ///<summary>
        /// UseCellValueAsButtonText
        ///</summary>
        public bool UseCellValueAsButtonText
        {
            get { return (_UseCellValueAsButtonText); }
            set { _UseCellValueAsButtonText = value; }
        }

        #endregion

        #endregion

        #region ButtonXExpandChanged

        private void ButtonXExpandChanged(object sender, EventArgs e)
        {
            if (Expanded == false)
            {
                _Cell.SuperGrid.PostInternalMouseMove();
                _Cell.SuperGrid.Focus();
            }
        }

        #endregion

        #region ButtonXClick

        private void ButtonXClick(object sender, EventArgs e)
        {
            EditorValueChanged = true;
        }

        #endregion

        #region OnInvalidated

        protected override void OnInvalidated(InvalidateEventArgs e)
        {
            base.OnInvalidated(e);

            if (_Cell != null && _SuspendUpdate == false)
                _Cell.InvalidateRender();
        }

        #endregion

        #region GetValue

        ///<summary>
        /// GetValue
        ///</summary>
        ///<param name="value"></param>
        ///<returns></returns>
        public virtual string GetValue(object value)
        {
            if (_UseCellValueAsButtonText == false)
                return (Text);

            GridPanel panel = _Cell.GridPanel;

            if (value == null ||
                (panel.NullValue == NullValue.DBNull && value == DBNull.Value))
            {
                return (_Cell.NullString);
            }

            if (_Cell.IsValueExpression == true)
                value = _Cell.GetExpValue((string)value);

            return (value.ToString());
        }

        #endregion

        #region IGridCellEditControl Members

        #region Public properties

        #region CanInterrupt

        public bool CanInterrupt
        {
            get { return (Expanded == false && IsMouseDown == false); }
        }

        #endregion

        #region CellEditMode

        public CellEditMode CellEditMode
        {
            get { return (CellEditMode.NonModal); }
        }

        #endregion

        #region EditorCell

        public GridCell EditorCell
        {
            get { return (_Cell); }
            set { _Cell = value; }
        }

        #endregion

        #region EditorCellBitmap

        ///<summary>
        /// EditorCellBitmap
        ///</summary>
        public Bitmap EditorCellBitmap
        {
            get { return (_EditorCellBitmap); }

            set
            {
                if (_EditorCellBitmap != null)
                    _EditorCellBitmap.Dispose();

                _EditorCellBitmap = value;
            }
        }

        #endregion

        #region EditorFormattedValue

        ///<summary>
        /// EditorFormattedValue
        ///</summary>
        public virtual string EditorFormattedValue
        {
            get { return (Text); }
        }

        #endregion

        #region EditorPanel

        public EditorPanel EditorPanel
        {
            get { return (_EditorPanel); }
            set { _EditorPanel = value; }
        }

        #endregion

        #region EditorValue

        public virtual object EditorValue
        {
            get { return (Text); }
            set { Text = GetValue(value); }
        }

        #endregion

        #region EditorValueChanged

        public virtual bool EditorValueChanged
        {
            get { return (_ValueChanged); }

            set
            {
                if (_ValueChanged != value)
                {
                    _ValueChanged = value;

                    if (value == true)
                        _Cell.SetEditorDirty(this);
                }
            }
        }

        #endregion

        #region EditorValueType

        ///<summary>
        /// EditorValueType
        ///</summary>
        public virtual Type EditorValueType
        {
            get { return (typeof(string)); }
        }

        #endregion

        #region StretchBehavior

        public virtual StretchBehavior StretchBehavior
        {
            get { return (_StretchBehavior); }
            set { _StretchBehavior = value; }
        }

        #endregion

        #region SuspendUpdate

        public virtual bool SuspendUpdate
        {
            get { return (_SuspendUpdate); }
            set { _SuspendUpdate = value; }
        }

        #endregion

        #region ValueChangeBehavior

        public virtual ValueChangeBehavior ValueChangeBehavior
        {
            get { return (ValueChangeBehavior.InvalidateRender); }
        }

        #endregion

        #endregion

        #region InitializeContext

        ///<summary>
        /// InitializeContext
        ///</summary>
        ///<param name="cell"></param>
        ///<param name="style"></param>
        public virtual void InitializeContext(GridCell cell, CellVisualStyle style)
        {
            _Cell = cell;

            if (style != null)
            {
                Enabled = (_Cell.IsReadOnly == false);

                Font = style.Font;
                ForeColor = style.TextColor;
            }

            Text = GetValue(_Cell.Value);

            _ValueChanged = false;
        }

        #endregion

        #region GetProposedSize

        ///<summary>
        /// GetProposedSize
        ///</summary>
        ///<param name="g"></param>
        ///<param name="cell"></param>
        ///<param name="style"></param>
        ///<param name="constraintSize"></param>
        ///<returns></returns>
        public virtual Size GetProposedSize(Graphics g,
            GridCell cell, CellVisualStyle style, Size constraintSize)
        {
            Size size = GetPreferredSize(constraintSize);

            if (constraintSize.Width > 0)
            {
                ButtonItem.RecalcSize();

                size = ButtonItem.TextDrawRect.Size;
                size.Height += 8;
            }
            else
            {
                size.Width++;
            }

            return (size);
        }

        #endregion

        #region Edit support

        #region BeginEdit

        public virtual bool BeginEdit(bool selectAll)
        {
            return (false);
        }

        #endregion

        #region EndEdit

        public virtual bool EndEdit()
        {
            Expanded = false;

            return (false);
        }

        #endregion

        #region CancelEdit

        public virtual bool CancelEdit()
        {
            Expanded = false;

            return (false);
        }

        #endregion

        #endregion

        #region CellRender

        public virtual void CellRender(Graphics g)
        {
            _Cell.CellRender(this, g);
        }

        #endregion

        #region Keyboard support

        #region CellKeyDown

        ///<summary>
        /// CellKeyDown
        ///</summary>
        public virtual void CellKeyDown(KeyEventArgs e)
        {
            OnKeyDown(e);
            OnKeyUp(e);

            Checked = false;
        }

        #endregion

        #region WantsInputKey

        public virtual bool WantsInputKey(Keys key, bool gridWantsKey)
        {
            switch (key & Keys.KeyCode)
            {
                case Keys.Space:
                    return (true);

                default:
                    return (gridWantsKey == false);
            }
        }

        #endregion

        #endregion

        #region Mouse support

        #region OnCellMouseMove

        ///<summary>
        /// OnCellMouseMove
        ///</summary>
        ///<param name="e"></param>
        public virtual void OnCellMouseMove(MouseEventArgs e)
        {
            OnMouseMove(e);
        }

        #endregion

        #region OnCellMouseEnter

        ///<summary>
        /// OnCellMouseEnter
        ///</summary>
        ///<param name="e"></param>
        public virtual void OnCellMouseEnter(EventArgs e)
        {
            Point pt = _Cell.SuperGrid.PointToClient(MousePosition);

            if (_Cell.Bounds.Contains(pt) == false)
                StopFade();

            OnMouseEnter(e);
        }

        #endregion

        #region OnCellMouseLeave

        ///<summary>
        /// OnCellMouseLeave
        ///</summary>
        ///<param name="e"></param>
        public virtual void OnCellMouseLeave(EventArgs e)
        {
            Point pt = _Cell.SuperGrid.PointToClient(MousePosition);

            if (_Cell.Bounds.Contains(pt) == false)
                StopFade();

            Refresh();
        }

        #endregion

        #region OnCellMouseUp

        ///<summary>
        /// OnCellMouseUp
        ///</summary>
        ///<param name="e"></param>
        public virtual void OnCellMouseUp(MouseEventArgs e)
        {
            OnMouseUp(e);
        }

        #endregion

        #region OnCellMouseDown

        ///<summary>
        /// OnCellMouseDown
        ///</summary>
        ///<param name="e"></param>
        public virtual void OnCellMouseDown(MouseEventArgs e)
        {
            OnMouseDown(e);
        }

        #endregion

        #endregion

        #endregion  

        #region Dispose

        protected override void Dispose(bool disposing)
        {
            Click -= ButtonXClick;
            ButtonItem.ExpandChange -= ButtonXExpandChanged;

            base.Dispose(disposing);
        }

        #endregion
    }
}
