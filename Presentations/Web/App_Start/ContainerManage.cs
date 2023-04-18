using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Security;
using System.Web.SessionState;
using System.Web.Http;
using Autofac;
using Autofac.Configuration;
using Autofac.Integration.Mvc;
using System.Reflection;
//using DapperExtensions.Demo.Web.App_Start;
using System.IO;
//using HY.Freamework.Demo;
//using HY.DataAccess;
namespace Web
{
    public class RegisterManage
    {
        public static void Register(ContainerBuilder builder)
        {

            //Controllers
            Assembly[] asm = GetAllAssembly("*.Web.dll").ToArray();
            builder.RegisterAssemblyTypes(asm);

            //注册仓储
            List<Assembly> asmRepositoryImp = GetAllAssembly("*.Core.dll");
            builder.RegisterAssemblyTypes(asmRepositoryImp.ToArray())
            .Where(t => t.Name.EndsWith("Repository"))
            .AsSelf().AsImplementedInterfaces().InstancePerHttpRequest();

            //组册服务
            List<Assembly> asmServiceImp = GetAllAssembly("*.Domain.dll");
            builder.RegisterAssemblyTypes(asmServiceImp.ToArray())
            .Where(t => t.Name.EndsWith("Service"))
            .AsSelf().AsImplementedInterfaces().InstancePerHttpRequest();


            builder.RegisterControllers(Assembly.GetExecutingAssembly());
            builder.RegisterModelBinders(Assembly.GetExecutingAssembly());
            builder.RegisterModelBinderProvider();

            //注册过滤器 
            //builder.RegisterFilterProvider();
            //builder.RegisterType<HY.Web.Areas.Sys.App_Start.SysLoginFilter>().PropertiesAutowired();
            //builder.RegisterControllers(typeof(Global).Assembly);
        }





   





        #region 加载程序集
        private static List<Assembly> GetAllAssembly(string dllName)
        {
            List<string> pluginpath = FindPlugin(dllName);
            var list = new List<Assembly>();
            foreach (string filename in pluginpath)
            {
                try
                {
                    string asmname = Path.GetFileNameWithoutExtension(filename);
                    if (asmname != string.Empty)
                    {
                        Assembly asm = Assembly.LoadFrom(filename);
                        list.Add(asm);
                    }
                }
                catch (Exception ex)
                {
                    Console.Write(ex.Message);
                }
            }
            return list;
        }
        //查找所有插件的路径
        private static List<string> FindPlugin(string dllName)
        {
            List<string> pluginpath = new List<string>();

            string path = AppDomain.CurrentDomain.BaseDirectory;
            string dir = Path.Combine(path, "bin\\");
            string[] dllList = Directory.GetFiles(dir, dllName);
            if (dllList.Length > 0)
            {
                pluginpath.AddRange(dllList.Select(item => Path.Combine(dir, item.Substring(dir.Length))));
            }
            return pluginpath;
        }
        #endregion
    }
}