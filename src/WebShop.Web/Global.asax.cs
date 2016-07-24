using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Hosting;
using System.Web.Http;
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

namespace WebShop.Web
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            ModelBinders.Binders.Add(typeof(ShoppingCart), new ShoppingCartModelBinder());
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
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
            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}
