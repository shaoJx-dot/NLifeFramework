using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Component.Core.Data;

namespace Application.Contracts.Models.Identity
{
    /// <summary>
    /// 实体类——用户与角色信息
    /// </summary>
    public class SYS_UserRole : EntityBase<int>
    {
        //public int ID { get; set; }
        /// <summary>
        /// 获取或设置角色ID
        /// </summary>
        public int SYS_RoleId { get; set; }
        /// <summary>
        /// 获取或设置用户ID
        /// </summary>
        public int SYS_UserId { get; set; }
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
        /// 获取或设置用户集合
        /// </summary>
        public virtual ICollection<SYS_User> SYS_Users { get; set; }

        /// <summary>
        /// 获取或设置角色集合
        /// </summary>
        public virtual ICollection<SYS_Role> SYS_Roles { get; set; }
    }
}
