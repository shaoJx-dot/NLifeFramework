using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using DevComponents.DotNetBar.Controls;
using System.Windows.Forms.Design;

namespace DevComponents.DotNetBar.Design
{
    /// <summary>
    /// Represents WinForms designer for RangeSlider control.
    /// </summary>
    public class RangeSliderDesigner : ControlDesigner
    {
        public override void InitializeNewComponent(IDictionary defaultValues)
        {
            base.InitializeNewComponent(defaultValues);
            SetDesignTimeDefaults();
        }

        private void SetDesignTimeDefaults()
        {
            RangeSlider slider = this.Control as RangeSlider;
            if (slider != null)
            {
                slider.Style = eDotNetBarStyle.StyleManagerControlled;
                slider.Width = 140;
                slider.Height = 24;
                slider.FocusCuesEnabled = false;
            }
        }
    }
}
