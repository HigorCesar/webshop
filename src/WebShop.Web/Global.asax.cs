using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
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

            var connectionFactory = new OrmLiteConnectionFactory("E:\\projetos\\webshop\\database\\localdb", SqliteDialect.Provider);
            using (var db = connectionFactory.Open())
            {
                db.CreateTableIfNotExists<Customer>();
                db.CreateTableIfNotExists<Order>();
            }

            var container = new UnityContainer();
            container.RegisterType<IDbConnectionFactory, OrmLiteConnectionFactory>(new InjectionConstructor("E:\\projetos\\webshop\\database\\localdb", SqliteDialect.Provider));
            container.RegisterType<ICheckoutRepository, CheckoutRepository>();
            container.RegisterType<IArticleRepository, ArticleRepository>(new InjectionConstructor(@"E:\projetos\webshop\src\WebShop.Web\App_Data\articles.xml"));
            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}
