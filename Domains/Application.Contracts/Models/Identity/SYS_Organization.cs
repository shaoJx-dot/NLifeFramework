using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

using Component.Core.Data;


namespace Application.Contracts.Models.Identity
{
    /// <summary>
    /// 实体类——组织机构信息
    /// </summary>
    public class SYS_Organization : EntityBase<int>
    {
        /// <summary>
        /// 初始化一个<see cref="Organization"/>类型的新实例
        /// </summary>
        public SYS_Organization()
        {
            Children = new List<SYS_Organization>();
            //Roles = new List<SYS_Role>();
        }

        //public int ID { get; set; }
        /// <summary>
        /// 获取或设置编码
        /// </summary>
        [Required, StringLength(100)]
        public string Code { get; set; }
        /// <summary>
        /// 获取或设置名称
        /// </summary>
        [Required, StringLength(100)]
        public string Name { get; set; }
        /// <summary>
        /// 获取或设置父ID
        /// </summary>
        public int? ParentID { get; set; }
        /// <summary>
        /// 获取或设置 树形路径，树链的Id以逗号分隔构成的字符串
        /// </summary>
        public string TreePath { get; set; }
        /// <summary>
        /// 获取或设置排序码
        /// </summary>
        [Range(0, 999)]
        public int Sort { get; set; }
        /// <summary>
        /// 获取或设置描述
        /// </summary>
        [StringLength(500)]
        public string Remark { get; set; }


        /// <summary>
        /// 获取或设置 树形路径编号数组
        /// </summary>
        [NotMapped]
        public int[] TreePathIds { get { return TreePath.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray(); } }

        /// <summary>
        /// 获取或设置 父级组织机构信息
        /// </summary>
        public virtual SYS_Organization Parent { get; set; }

        /// <summary>
        /// 获取或设置 子级组织机构信息集合
        /// </summary>
        public virtual ICollection<SYS_Organization> Children { get; set; }

        /// <summary>
        /// 获取或设置 用户信息集合
        /// </summary>
        public virtual ICollection<SYS_UserOrganization> SYS_UserOrganizations { get; set; }
    }
}