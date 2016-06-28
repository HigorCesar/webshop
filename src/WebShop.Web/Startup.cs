using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WebShop.Web.Startup))]
namespace WebShop.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
