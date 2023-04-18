using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Component.Core.Data;

namespace Application.Contracts.Models.Identity
{
    /// <summary>
    /// 实体类——机构与用户信息
    /// </summary>
    public class SYS_UserOrganization : EntityBase<int>
    {

        /// <summary>
        /// 获取或设置角色ID
        /// </summary>
        public int SYS_UserId { get; set; }
        /// <summary>
        /// 获取或设置用户ID
        /// </summary>
        public int SYS_OrganizationId { get; set; }
        /// <summary>
        /// 获取或设置创建时间
        /// </summary>
        public DateTime CreateTime { get; set; }
        /// <summary>
        /// 获取或设置备注
        /// </summary>
        [StringLength(500)]
        public string Remark { get; set; }

        /// <summary>
        /// 获取或设置用户
        /// </summary>
        public virtual SYS_User SYS_User { get; set; }

        /// <summary>
        /// 获取或设置机构
        /// </summary>
        public virtual SYS_Organization SYS_Organization { get; set; }
    }
}
