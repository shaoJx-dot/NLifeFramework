using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Component.Core.Data;


namespace Application.Contracts.Models.Identity
{
    /// <summary>
    /// 实体类——角色信息
    /// </summary>
    public class SYS_Role : EntityBase<int>
    {
        /// <summary>
        /// 初始化一个<see cref="Role"/>类型的新实例
        /// </summary>
        public SYS_Role()
        {
            
        }


        /// <summary>
        /// 获取或设置角色名称
        /// </summary>
        [Required, StringLength(50)]
        public string Name { get; set; }
        /// <summary>
        /// 获取或设置 是否是管理员
        /// </summary>
        public bool IsAdmin { get; set; }
        /// <summary>
        /// 获取或设置是否锁定
        /// </summary>
        public bool IsLocked { get; set; }
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
        /// 获取或设置用户与角色集合
        /// </summary>
        public virtual ICollection<SYS_UserRole> SYS_UserRoles { get; set; }

        /// <summary>
        /// 获取或设置 角色所属组织机构
        /// </summary>
        //public virtual SYS_Organization Organization { get; set; }

    }
}