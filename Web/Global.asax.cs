using Autofac;
using Autofac.Integration.Mvc;
using Autofac.Integration.WebApi;
using Domain.IConcrete;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Routing;

namespace Web
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);

            #region 自动注入

            //创建autofac管理注册类的容器实例
            var builder = new ContainerBuilder();
            HttpConfiguration config = GlobalConfiguration.Configuration;
            Assembly[] assemblies = Directory.GetFiles(AppDomain.CurrentDomain.RelativeSearchPath, "*.dll").Select(Assembly.LoadFrom).ToArray();
            //注册所有实现了 IDependency 接口的类型
            Type baseType = typeof(ICompanyInfoRepository);
            builder.RegisterAssemblyTypes(assemblies).Where(type => baseType.IsAssignableFrom(type) && !type.IsAbstract) .AsSelf().AsImplementedInterfaces().PropertiesAutowired().InstancePerLifetimeScope();
            //注册MVC类型
            // builder.RegisterControllers(assemblies).PropertiesAutowired();
            //注册Api类型
            builder.RegisterApiControllers(assemblies).PropertiesAutowired();
            //builder.RegisterFilterProvider();
            builder.RegisterWebApiFilterProvider(config);
            var container = builder.Build();
            //注册api容器需要使用HttpConfiguration对象
            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);
            //注册解析
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
            #endregion
        }
    }
}
