using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Component.Core.Data;

namespace Application.Contracts.Models.Identity
{
    public class SYS_Module : EntityBase<int>
    {
        
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
        /// 获取或设置类别
        /// </summary>
        public int Category { get; set; }
        /// <summary>
        /// 获取或设置图标
        /// </summary>
        [Required, StringLength(50)]
        public string Icon { get; set; }
        /// <summary>
        /// 获取或设置备注
        /// </summary>
        [StringLength(500)]
        public string Remark { get; set; }


        /// <summary>
        /// 获取或设置菜单集合
        /// </summary>
        public virtual ICollection<SYS_Menu> SYS_Menus { get; set; }
    }
}
