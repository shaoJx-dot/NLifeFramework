﻿using System;
using System.Linq;
using System.Linq.Expressions;

using Application.Contracts.Dtos.Identity;
using Application.Contracts.Models.Identity;
using Component.Utils.Data;
using Component.Utils.Extensions;


namespace Application.Services.Services
{
    public partial class IdentityService
    {
        #region Implementation of IIdentityContract

        /// <summary>
        /// 获取 角色信息查询数据集
        /// </summary>
        public IQueryable<SYS_Role> Roles
        {
            get { return RoleRepository.Entities; }
        }

        /// <summary>
        /// 检查角色信息信息是否存在
        /// </summary>
        /// <param name="predicate">检查谓语表达式</param>
        /// <param name="id">更新的角色信息编号</param>
        /// <returns>角色信息是否存在</returns>
        public bool CheckRoleExists(Expression<Func<SYS_Role, bool>> predicate, int id = 0)
        {
            return RoleRepository.CheckExists(predicate, id);
        }

        /// <summary>
        /// 添加角色信息信息
        /// </summary>
        /// <param name="dtos">要添加的角色信息DTO信息</param>
        /// <returns>业务操作结果</returns>
        public OperationResult AddRoles(params SYS_RoleDto[] dtos)
        {
            return RoleRepository.Insert(dtos,
                dto =>
                {
                    //if (RoleRepository.CheckExists(m => m.Name == dto.Name && m.Organization.ID == dto.OrganizationId))
                    //{
                    //    throw new Exception("同组织机构中名称为“{0}”的角色已存在，不能重复添加。".FormatWith(dto.Name));
                    //}
                },
                (dto, entity) =>
                {
                    SYS_Organization organization = OrganizationRepository.GetByKey(dto.OrganizationId);
                    if (organization == null)
                    {
                        throw new Exception("要加入的组织机构不存在。");
                    }
                    //entity.Organization = organization;
                    return entity;
                });
        }

        /// <summary>
        /// 更新角色信息信息
        /// </summary>
        /// <param name="dtos">包含更新信息的角色信息DTO信息</param>
        /// <returns>业务操作结果</returns>
        public OperationResult EditRoles(params SYS_RoleDto[] dtos)
        {
            return RoleRepository.Update(dtos,
                dto =>
                {
                    //if (RoleRepository.CheckExists(m => m.Name == dto.Name && m.Organization.ID == dto.OrganizationId, dto.Id))
                    //{
                    //    throw new Exception("同组织机构中名称为“{0}”的角色已存在，不能重复添加。".FormatWith(dto.Name));
                    //}
                },
                (dto, entity) =>
                {
                    SYS_Organization organization = OrganizationRepository.GetByKey(dto.OrganizationId);
                    if (organization == null)
                    {
                        throw new Exception("要加入的组织机构不存在。");
                    }
                    //entity.Organization = organization;
                    return entity;
                });
        }

        /// <summary>
        /// 删除角色信息信息
        /// </summary>
        /// <param name="ids">要删除的角色信息编号</param>
        /// <returns>业务操作结果</returns>
        public OperationResult DeleteRoles(params int[] ids)
        {
            return RoleRepository.Delete(ids);
        }

        #endregion
    }
}