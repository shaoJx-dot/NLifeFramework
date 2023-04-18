using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Application.Services.ModelConfigurations.Identity
{
    public partial class OrganizationConfiguration
    {
        partial void OrganizationConfigurationAppend()
        {
            HasOptional(m => m.Parent).WithMany(n => n.Children);
        }
    }
}