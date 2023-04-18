using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Application.Services.ModelConfigurations.Identity
{
    public partial class BtnConfiguration
    {
        partial void ExtraConfigurationAppend()
        {
            //HasMany(m => m.Roles).WithMany(n => n.Users);
        }
    }
}