using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Hosting;
using System.Web.Http;
using System.Web.Http.Dependencies;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Microsoft.Practices.Unity;
using ServiceStack.Data;
using ServiceStack.OrmLite;
using Unity.Mvc4;
using WebShop.Domain;
using WebShop.Infrastructure;
using WebShop.Web.Models;
using IDependencyResolver = System.Web.Http.Dependencies.IDependencyResolver;

namespace WebShop.Web
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            var localDbPath = HostingEnvironment.MapPath("/App_Data/database/localdb");
            var connectionFactory = new OrmLiteConnectionFactory(localDbPath, SqliteDialect.Provider);
            using (var db = connectionFactory.Open())
            {
                db.CreateTableIfNotExists<Customer>();
                db.CreateTableIfNotExists<Order>();
            }

            var container = new UnityContainer();
            container.RegisterType<IDbConnectionFactory, OrmLiteConnectionFactory>(new InjectionConstructor(localDbPath, SqliteDialect.Provider));
            container.RegisterType<ICheckoutRepository, CheckoutRepository>();
            container.RegisterType<IArticleRepository, ArticleRepository>(new InjectionConstructor(HostingEnvironment.MapPath(ConfigurationManager.AppSettings["articles-file"])));

            ModelBinders.Binders.Add(typeof(ShoppingCart), new ShoppingCartModelBinder());
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configuration.DependencyResolver = new WebApiDependencyResolver(container, new UnityDependencyResolver(container));
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            DependencyResolver.SetResolver(new UnityDependencyResolver(container));


        }
    }
}
