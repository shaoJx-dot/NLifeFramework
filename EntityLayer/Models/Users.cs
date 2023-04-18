//
//Created: 2016-05-20 11:33:37
//Author: 代码生成
//
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//using DapperExtensions.Mapper;

namespace Models
{
    /// <summary>
    /// HY：实体对象
    /// </summary>
    [Serializable]
    public class Users 
    {
        /// <summary>
        /// 用户ID
        /// </summary>
        public int ID { get; set; }

        /// <summary>
        /// 登录名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 密码
        /// </summary>
        public string Passwd { get; set; }
        public string PassQ { get; set; }

        public string PassA { get; set; }
        public string Sex { get; set; }
        public DateTime? Birth { get; set; }
        public string Email { get; set; }
        public string DisplayName { get; set; }
        public string Blog { get; set; }
        public string FromWhere { get; set; }
        public string PerSign { get; set; }
        public DateTime? CreateTime { get; set; }
        public string Post { get; set; }
        public int? Prestige { get; set; }
        public int? Experience { get; set; }
        public int? MoneyGold { get; set; }
        public DateTime? LoginTime { get; set; }
        public string LoginIP { get; set; }
        public int? GradeID { get; set; }
        public int? HonorID { get; set; }
        public int? PurID { get; set; }

        /// <summary>
        /// 状态   1：启用  0禁用
        /// </summary>
        public int? Status { get; set; }
        public string Remark { get; set; }
        public DateTime? UpdateTime { get; set; }
        //public UserInfoEntity UserInfo { get; set; }
        
    }




    /// <summary>
    /// Users：实体对象映射关系
    /// </summary>
    //[Serializable]
    //public class UsersEntityORMMapper : ClassMapper<Users>
    //{
    //    public UsersEntityORMMapper()
    //    {
    //        base.Table("Users");
    //        //Map(f => f.Remark1).Ignore();//设置忽略 
    //        //Map(f => f.Name).Key(KeyType.Identity);//设置主键  (如果主键名称不包含字母“ID”，请设置)      
    //        AutoMap();
    //    }
    //}
}


/// <summary>
/// 赋值代码
/// </summary>
/*
UsersEntity entity = new UsersEntity;
    entity.UserId=?;
    entity.LoginName=?;
    entity.Password=?;
    entity.Status=?;
    entity.CreateTime=?;
    entity.UpdateTime=?;
    entity.Remark=?;
*/