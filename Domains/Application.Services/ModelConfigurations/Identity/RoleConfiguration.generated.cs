﻿// <autogenerated>
//   This file was generated by T4 code generator ModelCodeScript.tt.
//   Any changes made to this file manually will be lost next time the file is regenerated.
// </autogenerated>


using System;

using Component.Data;

using Application.Contracts.Models.Identity;


namespace Application.Services.ModelConfigurations.Identity
{
    /// <summary>
    /// 实体类-数据表映射——Role
    /// </summary> 
	public partial class RoleConfiguration : EntityConfigurationBase<SYS_Role, Int32>
    { 
        /// <summary>
        /// 初始化一个<see cref="RoleConfiguration"/>类型的新实例
        /// </summary>
        public RoleConfiguration()
        {
            RoleConfigurationAppend();
        }

        /// <summary>
        /// 额外的数据映射
        /// </summary>
        partial void RoleConfigurationAppend();
    }
}