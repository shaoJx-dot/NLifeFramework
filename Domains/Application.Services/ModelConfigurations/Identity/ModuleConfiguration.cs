using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Application.Services.ModelConfigurations.Identity
{
    public partial class ModuleConfiguration
    {
        partial void ExtraConfigurationAppend()
        {
            HasMany(m => m.SYS_Menus).WithRequired().HasForeignKey(n => n.SYS_ModuleID);
        }
    }
}