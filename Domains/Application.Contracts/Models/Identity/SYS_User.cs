using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Component.Core.Data;


namespace Application.Contracts.Models.Identity
{
    /// <summary>
    /// 实体类——用户信息
    /// </summary>
    public class SYS_User : EntityBase<int>
    {
        /// <summary>
        /// 初始化一个<see cref="User"/>类型的新实例
        /// </summary>
        public SYS_User()
        {
            
        }


        /// <summary>
        /// 获取或设置用户名
        /// </summary>
        [Required, StringLength(100)]
        public string Name { get; set; }
        /// <summary>
        /// 获取或设置密码
        /// </summary>
        [StringLength(100)]
        public string Password { get; set; }
        /// <summary>
        /// 获取或设置用户昵称
        /// </summary>
        [StringLength(50)]
        public string NickName { get; set; }
        /// <summary>
        /// 获取或设置电子邮箱
        /// </summary>
        [Required, StringLength(100)]
        public string Email { get; set; }
        /// <summary>
        /// 获取或设置是否系统管理员
        /// </summary>
        public bool IsSys { get; set; }
        /// <summary>
        /// 获取或设置是否锁定
        /// </summary>
        public bool IsLocked { get; set; }
        /// <summary>
        /// 获取或设置创建时间
        /// </summary>
        public DateTime CreateTime { get; set; }
        /// <summary>
        /// 获取或设置描述
        /// </summary>
        [StringLength(500)]
        public string Remark { get; set; }

        /// <summary>
        /// 获取或设置用户与角色集合
        /// </summary>
        public virtual ICollection<SYS_UserRole> SYS_UserRoles { get; set; }

        /// <summary>
        /// 获取或设置 用户信息集合
        /// </summary>
        public virtual ICollection<SYS_UserOrganization> SYS_UserOrganizations { get; set; }

        /// <summary>
        /// 获取或设置用户扩展信息
        /// </summary>
        public virtual SYS_UserExtend Extend { get; set; }

    }
}