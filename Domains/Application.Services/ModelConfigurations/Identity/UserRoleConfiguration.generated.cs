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
    /// 实体类-数据表映射——User
    /// </summary> 
	public partial class UserRoleConfiguration : EntityConfigurationBase<SYS_UserRole, Int32>
    { 
        /// <summary>
        /// 初始化一个<see cref="UserConfiguration"/>类型的新实例
        /// </summary>
        public UserRoleConfiguration()
        {
            UserRoleConfigurationAppend();
        }

        /// <summary>
        /// 额外的数据映射
        /// </summary>
        partial void UserRoleConfigurationAppend();
    }
}
