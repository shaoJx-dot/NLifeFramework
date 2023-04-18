using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Component.Core.Data;

namespace Application.Contracts.Models.Identity
{
    public class SYS_Btn : EntityBase<int>
    {
        
        /// <summary>
        /// 获取或设置菜单ID
        /// </summary>
        public int SYS_MenuID { get; set; }
        /// <summary>
        /// 获取或设置编码
        /// </summary>
        [Required, StringLength(50)]
        public string Code { get; set; }
        /// <summary>
        /// 获取或设置名称
        /// </summary>
        [Required, StringLength(50)]
        public string Name { get; set; }
        /// <summary>
        /// 获取或设置排序
        /// </summary>
        public int Sort { get; set; }
        /// <summary>
        /// 获取或设置备注
        /// </summary>
        [StringLength(500)]
        public string Remark { get; set; }


        /// <summary>
        /// 获取或设置菜单实体
        /// </summary>
        public virtual SYS_Menu SYS_Menu { get; set; }
    }
}
