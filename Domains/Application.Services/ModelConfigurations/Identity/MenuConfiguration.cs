using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Application.Services.ModelConfigurations.Identity
{
    public partial class MenuConfiguration
    {
        partial void ExtraConfigurationAppend()
        {
            HasMany(m => m.SYS_Btns).WithRequired(n => n.SYS_Menu);
        }
    }
}