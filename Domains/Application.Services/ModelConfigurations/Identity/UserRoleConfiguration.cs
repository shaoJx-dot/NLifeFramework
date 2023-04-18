using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Application.Services.ModelConfigurations.Identity
{
    public partial class UserRoleConfiguration
    {
        partial void UserRoleConfigurationAppend()
        {
            //HasMany(m => m.Roles).WithMany(n => n.Users);
        }
    }
}