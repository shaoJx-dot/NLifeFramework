using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NLife.Core.Menu
{
   public class MenuButton
    {
       System.Windows.Forms.Control _control;
       //图片地址
		public  string IconFilePath;
        public string MenuName;
		/// <summary>
		/// Initializes a new instance of the <see cref= "T:WorldWind.WindowsControlMenuButton"/> class.
		/// </summary>
		/// <param name="name"></param>
		/// <param name="iconFilePath"></param>
		/// <param name="control"></param>
       public MenuButton(
			string name,
			string iconFilePath,
			System.Windows.Forms.Control control)
		{
            this.MenuName = name;
			this._control = control;
            this.IconFilePath = iconFilePath;
		}

		public  bool IsPushed()
		{	
			return this._control.Visible;
		}

		public void SetPushed(bool isPushed)
		{
			this._control.Visible = isPushed;
		}


    }
}
