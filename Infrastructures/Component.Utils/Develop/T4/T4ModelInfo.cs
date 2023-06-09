﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Text;

using Component.Utils.Extensions;


namespace Component.Utils.Develop.T4
{
    /// <summary>
    /// T4实体模型信息类
    /// </summary>
    public class T4ModelInfo
    {
        /// <summary>
        /// 初始化一个<see cref="T4ModelInfo"/>类型的新实例
        /// </summary>
        /// <param name="modelType">实体类型</param>
        /// <param name="useModuleDir">是否使用模块文件夹</param>
        public T4ModelInfo(Type modelType, bool useModuleDir = false)
        {
            string @namespace = modelType.Namespace;
            if (@namespace == null)
            {
                return;
            }
            Namespace = @namespace;
            UseModuleDir = useModuleDir;
            if (useModuleDir)
            {
                int index = @namespace.LastIndexOf('.') + 1;
                ModuleName = @namespace.Substring(index, @namespace.Length - index);
            }
            Name = modelType.Name;
            Description = modelType.ToDescription();
            Properties = modelType.GetProperties(BindingFlags.Public | BindingFlags.Instance);
            foreach (var property in Properties)
            {
                if (property.ExistsAttribute<KeyAttribute>() || property.Name.ToUpper() == "ID" || property.Name.ToUpper().EndsWith("ID"))
                {
                    KeyType = property.PropertyType;
                    break;
                }
            }
        }

        /// <summary>
        /// 获取或设置 主键类型
        /// </summary>
        public Type KeyType { get; private set; }

        /// <summary>
        /// 获取 是否使用模块文件夹
        /// </summary>
        public bool UseModuleDir { get; private set; }

        /// <summary>
        /// 获取 模型所在模块名称
        /// </summary>
        public string ModuleName { get; private set; }

        /// <summary>
        /// 获取 模型命名空间
        /// </summary>
        public string Namespace { get; private set; }

        /// <summary>
        /// 获取 模型名称
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// 获取 模型描述
        /// </summary>
        public string Description { get; private set; }

        /// <summary>
        /// 属性信息集合
        /// </summary>
        public IEnumerable<PropertyInfo> Properties { get; private set; }

        /// <summary>
        /// 获取或设置 工程名称，生成代码的命名空间都基于此名称
        /// </summary>
        public string ProjectName { get; set; }
    }
}