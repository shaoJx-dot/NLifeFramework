using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Component.Core;
using Component.Core.Data;
using Application.Contracts.Contracts;
using Application.Contracts.Models.Identity;


namespace Application.Services.Services
{
    /// <summary>
    /// 业务实现——身份认证模块
    /// </summary>
    public partial class IdentityService : ServiceBase, IIdentityContract
    {
        public IdentityService(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        { }

        /// <summary>
        /// 获取或设置 组织机构信息仓储操作对象
        /// </summary>
        public IRepository<SYS_Organization, int> OrganizationRepository { protected get; set; }

        /// <summary>
        /// 获取或设置 角色信息仓储对象
        /// </summary>
        public IRepository<SYS_Role, int> RoleRepository { protected get; set; }

        /// <summary>
        /// 获取或设置 用户信息仓储对象
        /// </summary>
        public IRepository<SYS_User, int> UserRepository { protected get; set; }

        /// <summary>
        /// 获取或设置 用户扩展信息仓储对象
        /// </summary>
        public IRepository<SYS_UserExtend, int> UserExtendRepository { protected get; set; }
    }
}