using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.ComponentModel;

namespace DevComponents.DotNetBar.Controls
{
    [ToolboxItem(false)]
    [Designer("DevComponents.DotNetBar.Design.PageSliderPageDesigner, DevComponents.DotNetBar.Design, Version=11.4.0.0, Culture=neutral,  PublicKeyToken=90f470f34c89ccaf")]
    public class PageSliderPage : Panel
    {
        #region Constructor

        #endregion

        #region Implementation
        private int _PageNumber = 1;
        /// <summary>
        /// Gets or sets page number. Page number determines the order in which pages are displayed inside of the PageSlider control.
        /// </summary>
        [DefaultValue(1), Category("Behavior"), Description("Indicates page number. Page number determines the order in which pages are displayed inside of the PageSlider control.")]
        public int PageNumber
        {
            get { return _PageNumber; }
            set
            {
                if (value != _PageNumber)
                {
                    int oldValue = _PageNumber;
                    _PageNumber = value;
                    OnPageNumberChanged(oldValue, value);
                }
            }
        }
        /// <summary>
        /// Called when PageNumber property has changed.
        /// </summary>
        /// <param name="oldValue">Old property value</param>
        /// <param name="newValue">New property value</param>
        protected virtual void OnPageNumberChanged(int oldValue, int newValue)
        {
            //OnPropertyChanged(new PropertyChangedEventArgs("PageNumber"));
            
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                PageSlider parent = this.Parent as PageSlider;
                if (parent != null) parent.StartPageDrag();
            }

            base.OnMouseDown(e);
        }
        #endregion
    }
}
