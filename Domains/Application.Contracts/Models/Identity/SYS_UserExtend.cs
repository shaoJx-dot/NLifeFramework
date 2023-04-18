using System.ComponentModel.DataAnnotations;

using Component.Core.Data;


namespace Application.Contracts.Models.Identity
{
    /// <summary>
    /// 实体类——用户扩展信息
    /// </summary>
    public class SYS_UserExtend : EntityBase<int>
    {
        /// <summary>
        /// 注册IP地址
        /// </summary>
        [StringLength(15)]
        public string RegistedIp { get; set; }

        public virtual SYS_User User { get; set; }
    }
}