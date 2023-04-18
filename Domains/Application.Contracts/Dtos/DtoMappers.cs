using AutoMapper;

using Application.Contracts.Dtos.Identity;
using Application.Contracts.Models.Identity;


namespace Application.Contracts.Dtos
{
    public class DtoMappers
    {
        public static void MapperRegister()
        {
            //Identity
            Mapper.CreateMap<SYS_OrganizationDto, SYS_Organization>();
            Mapper.CreateMap<SYS_UserDto, SYS_User>();
            Mapper.CreateMap<SYS_RoleDto, SYS_Role>();
        }
    }
}