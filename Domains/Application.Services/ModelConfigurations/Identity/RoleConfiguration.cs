using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Application.Services.ModelConfigurations.Identity
{
    public partial class RoleConfiguration
    {
        partial void RoleConfigurationAppend()
        {
            //HasRequired(m => m.Organization).WithMany(n => n.Roles);
            HasMany(m => m.SYS_UserRoles).WithRequired().HasForeignKey(n => n.SYS_RoleId);
        }
    }
}