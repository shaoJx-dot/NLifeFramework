using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Application.Services.ModelConfigurations.Identity
{
    public partial class UserConfiguration
    {
        partial void UserConfigurationAppend()
        {
            //HasMany(m => m.SYS_UserRoles).WithMany(n => n.SYS_Users);
            HasMany(m => m.SYS_UserRoles).WithRequired().HasForeignKey(n=>n.SYS_UserId);
        }
    }
}