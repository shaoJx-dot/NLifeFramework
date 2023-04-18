using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Component.Core.Data;

namespace Application.Contracts.Models.Identity
{
    public class SYS_Privilege : EntityBase<int>
    {
        //public int ID { get; set; }
        /// <summary>
        /// 获取或设置类型("User"或"Role")
        /// </summary>
        [Required, StringLength(20)]
        public string PMaster { get; set; }
        /// <summary>
        /// 获取或设置用户ID、角色ID("userId"或"roleId")
        /// </summary>
        public int PMasterValue { get; set; }
        /// <summary>
        /// 获取或设置模块类型("Menu"或"Button"或"Module")
        /// </summary>
        [Required, StringLength(20)]
        public string PAccess { get; set; }
        /// <summary>
        /// 获取或设置模块代码("BtnCode"或"MenuCode"或"ModuleCode")
        /// </summary>
        [Required, StringLength(50)]
        public string PAccessValue { get; set; }
        /// <summary>
        /// 获取或设置模块状态("Enabled"或"Disabled"或"Authorization")
        /// </summary>
        [Required, StringLength(20)]
        public string POperation { get; set; }
        /// <summary>
        /// 获取或设置备注
        /// </summary>
        [StringLength(500)]
        public string Remark { get; set; }


        /// <summary>
        /// 获取或设置用户实体
        /// </summary>
        //public virtual SYS_User SYS_User { get; set; }

        /// <summary>
        /// 获取或设置角色实体
        /// </summary>
        //public virtual SYS_Role SYS_Role { get; set; }
    }
}
