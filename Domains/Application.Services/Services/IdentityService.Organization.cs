﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

using Application.Contracts.Dtos.Identity;
using Application.Contracts.Models.Identity;
using Component.Utils;
using Component.Utils.Data;
using Component.Utils.Extensions;


namespace Application.Services.Services
{
    public partial class IdentityService
    {
        #region Implementation of IIdentityContract

        /// <summary>
        /// 获取 组织机构信息查询数据集
        /// </summary>
        public IQueryable<SYS_Organization> Organizations
        {
            get { return OrganizationRepository.Entities; }
        }

        /// <summary>
        /// 检查组织机构信息信息是否存在
        /// </summary>
        /// <param name="predicate">检查谓语表达式</param>
        /// <param name="id">更新的组织机构信息编号</param>
        /// <returns>组织机构信息是否存在</returns>
        public bool CheckOrganizationExists(Expression<Func<SYS_Organization, bool>> predicate, int id = 0)
        {
            return OrganizationRepository.CheckExists(predicate, id);
        }

        /// <summary>
        /// 添加组织机构信息信息
        /// </summary>
        /// <param name="dtos">要添加的组织机构信息DTO信息</param>
        /// <returns>业务操作结果</returns>
        public OperationResult AddOrganizations(params SYS_OrganizationDto[] dtos)
        {
            dtos.CheckNotNull("dtos");
            List<SYS_Organization> organizations = new List<SYS_Organization>();
            OperationResult result = OrganizationRepository.Insert(dtos,
                dto =>
                {
                    if (OrganizationRepository.CheckExists(m => m.Name == dto.Name))
                    {
                        throw new Exception("名称为“{0}”的组织机构已存在，不能重复添加。".FormatWith(dto.Name));
                    }
                },
                (dto, entity) =>
                {
                    if (dto.ParentId.HasValue && dto.ParentId.Value > 0)
                    {
                        SYS_Organization parent = OrganizationRepository.GetByKey(dto.ParentId.Value);
                        if (parent == null)
                        {
                            throw new Exception("指定父组织机构不存在。");
                        }
                        entity.Parent = parent;
                    }
                    organizations.Add(entity);
                    return entity;
                });
            if (result.ResultType == OperationResultType.Success)
            {
                int[] ids = organizations.Select(m => m.ID).ToArray();
                RefreshOrganizationsTreePath(ids);
            }
            return result;
        }

        /// <summary>
        /// 更新组织机构信息信息
        /// </summary>
        /// <param name="dtos">包含更新信息的组织机构信息DTO信息</param>
        /// <returns>业务操作结果</returns>
        public OperationResult EditOrganizations(params SYS_OrganizationDto[] dtos)
        {
            dtos.CheckNotNull("dtos");
            List<SYS_Organization> organizations = new List<SYS_Organization>();
            OperationResult result = OrganizationRepository.Update(dtos,
                dto =>
                {
                    if (OrganizationRepository.CheckExists(m => m.Name == dto.Name, dto.Id))
                    {
                        throw new Exception("名称为“{0}”的组织机构已存在，不能重复添加。".FormatWith(dto.Name));
                    }
                },
                (dto, entity) =>
                {
                    if (!dto.ParentId.HasValue || dto.ParentId == 0)
                    {
                        entity.Parent = null;
                    }
                    else if (entity.Parent != null && entity.Parent.ID != dto.ParentId)
                    {
                        SYS_Organization parent = OrganizationRepository.GetByKey(dto.Id);
                        if (parent == null)
                        {
                            throw new Exception("指定父组织机构不存在。");
                        }
                        entity.Parent = parent;
                    }
                    organizations.Add(entity);
                    return entity;
                });
            if (result.ResultType == OperationResultType.Success)
            {
                int[] ids = organizations.Select(m => m.ID).ToArray();
                RefreshOrganizationsTreePath(ids);
            }
            return result;
        }

        /// <summary>
        /// 删除组织机构信息信息
        /// </summary>
        /// <param name="ids">要删除的组织机构信息编号</param>
        /// <returns>业务操作结果</returns>
        public OperationResult DeleteOrganizations(params int[] ids)
        {
            ids.CheckNotNull("ids");
            OperationResult result = OrganizationRepository.Delete(ids,
                entity =>
                {
                    if (entity.Children.Any())
                    {
                        throw new Exception("组织机构“{0}”的子级不为空，不能删除。".FormatWith(entity.Name));
                    }
                });
            return result;
        }

        #endregion

        #region 私有方法

        private void RefreshOrganizationsTreePath(params int[] ids)
        {
            if (ids.Length == 0)
            {
                return;
            }
            List<SYS_Organization> organizations = OrganizationRepository.GetInclude(m => m.Parent).Where(m => ids.Contains(m.ID)).ToList();
            UnitOfWork.TransactionEnabled = true;
            foreach (SYS_Organization organization in organizations)
            {
                organization.TreePath = organization.Parent == null
                    ? organization.ID.ToString()
                    : organization.Parent.TreePathIds.Union(new[] { organization.ID }).ExpandAndToString();
                OrganizationRepository.Update(organization);
            }
            UnitOfWork.SaveChanges();
        }

        #endregion
    }
}