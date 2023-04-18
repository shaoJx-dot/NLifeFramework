using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using DevComponents.DotNetBar.SuperGrid.Style;
using DevComponents.DotNetBar.Controls;
using System.Text;
using System.Runtime.InteropServices;

namespace DevComponents.DotNetBar.SuperGrid
{
    ///<summary>
    /// GridComboBoxExEditControl
    ///</summary>
    [ToolboxItem(false)]
    public class GridComboBoxExEditControl : ComboBoxEx, IGridCellEditControl
    {
        #region DllImports

        [DllImport("kernel32.dll")]
        private static extern int GetCurrentThreadId();

        [DllImport("user32.dll")]
        public static extern bool IsWindowVisible(IntPtr hWnd);

        [DllImport("user32.dll")]
        private static extern void GetClassName(IntPtr hWnd, StringBuilder lpClassName, int nMaxCount);

        [DllImport("user32.dll")]
        private static extern bool EnumThreadWindows(int dwThreadId, EnumThreadDelegate lpfn, IntPtr lParam);

        private delegate bool EnumThreadDelegate(IntPtr hWnd, IntPtr lParam);

        #endregion

        #region Static data

        static bool _StaticIsOpen;

        #endregion

        #region Private variables

        private GridCell _Cell;
        private EditorPanel _EditorPanel;
        private Bitmap _EditorCellBitmap;

        private bool _ValueChanged;
        private bool _SuspendUpdate;
        private bool _PanelShown;

        private string _ValueText;

        private StretchBehavior _StretchBehavior = StretchBehavior.None;

        #endregion

        ///<summary>
        /// GridComboBoxExEditControl
        ///</summary>
        public GridComboBoxExEditControl()
        {
            DrawMode = DrawMode.OwnerDrawFixed;
            DisconnectedPopupDataSource = true;
            BindingContext = new BindingContext();
        }

        #region Dispose

        protected override void Dispose(bool disposing)
        {
            BindingContext = null;

            base.Dispose(disposing);
        }

        #endregion

        #region OnTextChanged

        protected override void OnTextChanged(EventArgs e)
        {
            if (IsDisposed == false)
            {
                if (_Cell != null && _SuspendUpdate == false)
                    _Cell.EditorValueChanged(this);
            }

            base.OnTextChanged(e);
        }

        #endregion

        #region OnSelectedIndexChanged

        protected override void OnSelectedIndexChanged(EventArgs e)
        {
            if (IsDisposed == false)
            {
                if (_Cell != null && _SuspendUpdate == false)
                {
                    _Cell.EditorValueChanged(this);

                    EditorValueChanged = true;
                }
            }

            base.OnSelectedIndexChanged(e);
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

        /// <summary>
        /// GetValue
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public virtual object GetValue(object value)
        {
            GridPanel panel = _Cell.GridPanel;

            if (value == null ||
                (panel.NullValue == NullValue.DBNull && value == DBNull.Value))
            {
                return ("");
            }

            if (_Cell.IsValueExpression == true)
                value = _Cell.GetExpValue((string)value);

            return (value);
        }

        #endregion

        #region SetValue

        private void SetValue(object o)
        {
            _ValueText = "";

            SelectedIndex = -1;

            if (o != null)
            {
                _ValueText = o.ToString();

                if (string.IsNullOrEmpty(_ValueText) == false &&
                    string.IsNullOrEmpty(ValueMember) == false &&
                    string.IsNullOrEmpty(DisplayMember) == false)
                {
                    try
                    {
                        SelectedValue = o;

                        if (SelectedValue != null)
                            _ValueText = Text;
                    }
                    catch
                    {
                        Text = _ValueText;
                    }
                }
                else
                {
                    Text = _ValueText;
                }
            }
        }

        #endregion

        #region IGridCellEditControl Members

        #region Public properties

        #region CanInterrupt

        public virtual bool CanInterrupt
        {
            get { return (true); }
        }

        #endregion

        #region CellEditMode

        CellEditMode _CellEditMode = CellEditMode.Modal;

        public virtual CellEditMode CellEditMode
        {
            get { return (_CellEditMode); }
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
            get
            {
                if (_Cell != null && _Cell.IsValueNull == true)
                    return (_Cell.NullString);

                return (_ValueText);
            }
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
            get
            {
                if (string.IsNullOrEmpty(ValueMember) == false)
                    return (SelectedValue ?? Text);
               
                if (string.IsNullOrEmpty(DisplayMember) == false)
                    return (Text);

                return (SelectedValue ?? Text);
            }

            set { SetValue(GetValue(value)); }
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

            SetValue(GetValue(_Cell.Value));

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
            eTextFormat tf = eTextFormat.NoClipping |
                eTextFormat.WordEllipsis | eTextFormat.NoPrefix;

            if (style.AllowWrap == Tbool.True)
                tf |= eTextFormat.WordBreak;

            string s = EditorFormattedValue;

            if (String.IsNullOrEmpty(s) == true)
                s = " ";

            Size size = (constraintSize.IsEmpty == true)
                            ? TextHelper.MeasureText(g, s, style.Font)
                            : TextHelper.MeasureText(g, s, style.Font, constraintSize, tf);

            if (ItemHeight > size.Height)
                size.Height = ItemHeight + DefaultMargin.Vertical;

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
            if (IsPopupOpen == true)
                IsPopupOpen = false;

            return (false);
        }

        #endregion

        #region CancelEdit

        public virtual bool CancelEdit()
        {
            if (IsPopupOpen == true)
                IsPopupOpen = false;

            return (false);
        }

        #endregion

        #endregion

        #region CellRender

        public virtual void CellRender(Graphics g)
        {
            if (_PanelShown == false)
            {
                _EditorPanel.Show();
                _EditorPanel.Hide();

                _PanelShown = true;
            }

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
            Focus();

            switch (e.KeyData)
            {
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
                case Keys.Space:
                case Keys.Up:
                case Keys.Down:
                    return (true);

                case Keys.Enter:
                    if (DroppedDown == true || IsPopupOpen == true)
                        return (true);

                    if (AutoCompleteMode != AutoCompleteMode.None)
                    {
                        if (string.IsNullOrEmpty(DropDownColumns) == true)
                        {
                            if (IsAutoSuggestOpen() == true)
                                return (true);
                        }
                    }
                    break;
            }

            return (gridWantsKey == false);
        }

        #region IsAutoSuggestOpen

        private bool IsAutoSuggestOpen()
        {
            _StaticIsOpen = false;

            EnumThreadWindows(GetCurrentThreadId(), EnumThreadWindowCallback, IntPtr.Zero);

            return (_StaticIsOpen);
        }

        #region EnumThreadWindowCallback

        private static bool EnumThreadWindowCallback(IntPtr hWnd, IntPtr lParam)
        {
            if (IsWindowVisible(hWnd) == true)
            {
                if ((GetClassName(hWnd) == "Auto-Suggest Dropdown"))
                {
                    _StaticIsOpen = true;

                    return (false);
                }
            }

            return true;
        }

        #region GetClassName

        private static string GetClassName(IntPtr hRef)
        {
            StringBuilder lpClassName = new StringBuilder(256);

            GetClassName(hRef, lpClassName, 256);

            return (lpClassName.ToString());
        }

        #endregion

        #endregion

        #endregion

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
        }

        #endregion

        #region OnCellMouseEnter

        ///<summary>
        /// OnCellMouseEnter
        ///</summary>
        ///<param name="e"></param>
        public virtual void OnCellMouseEnter(EventArgs e)
        {
        }

        #endregion

        #region OnCellMouseLeave

        ///<summary>
        /// OnCellMouseLeave
        ///</summary>
        ///<param name="e"></param>
        public virtual void OnCellMouseLeave(EventArgs e)
        {
        }

        #endregion

        #region OnCellMouseUp

        ///<summary>
        /// OnCellMouseUp
        ///</summary>
        ///<param name="e"></param>
        public virtual void OnCellMouseUp(MouseEventArgs e)
        {
        }

        #endregion

        #region OnCellMouseDown

        ///<summary>
        /// OnCellMouseDown
        ///</summary>
        ///<param name="e"></param>
        public virtual void OnCellMouseDown(MouseEventArgs e)
        {
        }

        #endregion

        #endregion

        #endregion
    }
}
