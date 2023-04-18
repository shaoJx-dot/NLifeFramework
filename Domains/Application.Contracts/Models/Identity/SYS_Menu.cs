using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Component.Core.Data;

namespace Application.Contracts.Models.Identity
{
    public class SYS_Menu : EntityBase<int>
    {
        
        /// <summary>
        /// 获取或设置模块ID
        /// </summary>
        public int SYS_ModuleID { get; set; }
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
        /// 获取或设置程序集名称
        /// </summary>
        [Required, StringLength(100)]
        public string AssemblyName { get; set; }
        /// <summary>
        /// 获取或设置命名空间
        /// </summary>
        [Required, StringLength(100)]
        public string NameSpace { get; set; }
        /// <summary>
        /// 获取或设置窗体编码
        /// </summary>
        [Required, StringLength(100)]
        public string FormCode { get; set; }
        /// <summary>
        /// 获取或设置窗体类名
        /// </summary>
        [Required, StringLength(100)]
        public string FormName { get; set; }
        /// <summary>
        /// 获取或设置排序
        /// </summary>
        public int Sort { get; set; }
        /// <summary>
        /// 获取或设置菜单类型
        /// </summary>
        public int MenuType { get; set; }
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
        /// 获取或设置模块实体
        /// </summary>
        public virtual SYS_Module SYS_Module { get; set; }
        /// <summary>
        /// 获取或设置按钮集合
        /// </summary>
        public virtual ICollection<SYS_Btn> SYS_Btns { get; set; }
    }
}
