using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using DevComponents.DotNetBar.SuperGrid.Style;
using DevComponents.Instrumentation;

namespace DevComponents.DotNetBar.SuperGrid
{
    ///<summary>
    /// GridGaugeEditControl
    ///</summary>
    [ToolboxItem(false)]
    public class GridGaugeEditControl : GaugeControl, IGridCellEditControl
    {
        #region Private variables

        private GridCell _Cell;
        private EditorPanel _EditorPanel;
        private Bitmap _EditorCellBitmap;

        private bool _ValueChanged;
        private bool _SuspendUpdate;

        private string _PointerName = "Pointer1";

        private StretchBehavior _StretchBehavior = StretchBehavior.Both;

        #endregion

        ///<summary>
        /// GridGaugeEditControl
        ///</summary>
        public GridGaugeEditControl()
        {
            PointerValueChanged += OnValueChanged;
#if !TRIAL
            LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F";
#endif
        }

        #region Public properties

        ///<summary>
        /// PointerName
        ///</summary>
        public string PointerName
        {
            get { return (_PointerName); }
            set { _PointerName = value; }
        }

        #endregion

        #region OnValueChanged

        /// <summary>
        /// Pointer Value changed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected virtual void OnValueChanged(object sender, PointerChangedEventArgs e)
        {
            if (_Cell != null && _SuspendUpdate == false)
            {
                _Cell.Value = e.NewValue;
                _Cell.EditorValueChanged(this);
            }
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

        #region OnPaintBackground

        protected override void OnPaintBackground(PaintEventArgs e)
        {
            _Cell.PaintEditorBackground(e, this);
        }

        #endregion

        #region GetValue

        ///<summary>
        /// GetValue
        ///</summary>
        ///<param name="value"></param>
        ///<returns></returns>
        public virtual double GetValue(object value)
        {
            GridPanel panel = _Cell.GridPanel;

            if (value == null ||
                (panel.NullValue == NullValue.DBNull && value == DBNull.Value))
            {
                return (0);
            }

            if (_Cell.IsValueExpression == true)
                value = _Cell.GetExpValue((string)value);

            return (Convert.ToDouble(value));
        }

        #endregion

        #region IGridCellEditControl Members

        #region Public properties

        #region CanInterrupt

        public bool CanInterrupt
        {
            get { return (true); }
        }

        #endregion

        #region CellEditMode

        public CellEditMode CellEditMode
        {
            get { return (CellEditMode.InPlace); }
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
            get { return (GetPointerValue(_PointerName)); }
            set { SetPointerValue(_PointerName, GetValue(value), false); }
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

        public bool SuspendUpdate
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
                Enabled = (_Cell.ReadOnly == false);
                Font = style.Font;
                ForeColor = style.TextColor;
            }

            SetPointerValue(_PointerName, GetValue(_Cell.Value), false);

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
            Size size = constraintSize;
            size.Height = size.Width;

            if (size.Width == 0)
                size.Width = cell.Size.Width - 2;

            size.Height = 50;

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
            return (false);
        }

        #endregion

        #region CancelEdit

        public virtual bool CancelEdit()
        {
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
            switch (e.KeyData)
            {
                case Keys.T:
                    break;

                case Keys.F:
                    break;

                default:
                    OnKeyDown(e);
                    break;
            }
        }

        #endregion

        #region WantsInputKey

        public virtual bool WantsInputKey(Keys key, bool gridWantsKey)
        {
            switch (key & Keys.KeyCode)
            {
                case Keys.T:
                case Keys.F:
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

            _Cell.SuperGrid.GridCursor = Cursor;
        }

        #endregion

        #region OnCellMouseEnter

        ///<summary>
        /// OnCellMouseEnter
        ///</summary>
        ///<param name="e"></param>
        public virtual void OnCellMouseEnter(EventArgs e)
        {
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
            OnMouseLeave(e);
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
            PointerValueChanged -= OnValueChanged;

            base.Dispose(disposing);
        }

        #endregion
    }
}
