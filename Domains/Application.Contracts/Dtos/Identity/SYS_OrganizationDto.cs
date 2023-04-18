using System.ComponentModel.DataAnnotations;

using Component.Core.Data;


namespace Application.Contracts.Dtos.Identity
{
    public class SYS_OrganizationDto : IAddDto, IEditDto<int>
    {
        /// <summary>
        /// 获取或设置 主键，唯一标识
        /// </summary>
        public int Id { get; set; }

        [Required, StringLength(100)]
        public string Name { get; set; }

        [StringLength(500)]
        public string Remark { get; set; }

        [Range(0, 999)]
        public int Sort { get; set; }

        public int? ParentId { get; set; }
    }
}