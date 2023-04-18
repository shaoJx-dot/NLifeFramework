using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Component.Core.Data;

namespace Application.Contracts.Models.Identity
{
    public class SYS_CustomMenu : EntityBase<int>
    {
        
        /// <summary>
        /// 获取或设置用户ID
        /// </summary>
        public int SYS_UserId { get; set; }
        /// <summary>
        /// 获取或设置菜单ID
        /// </summary>
        public int SYS_MenuId { get; set; }
        /// <summary>
        /// 获取或设置排序
        /// </summary>
        public int Sort { get; set; }
        /// <summary>
        /// 获取或设置备注
        /// </summary>
        [StringLength(255)]
        public string Remark { get; set; }

        /// <summary>
        /// 获取或设置用户实体
        /// </summary>
        public virtual SYS_User SYS_User { get; set; }

        /// <summary>
        /// 获取或设置菜单实体
        /// </summary>
        public virtual SYS_Menu SYS_Menu { get; set; }
    }
}
