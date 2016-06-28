using System.Web;
using System.Web.Http.Controllers;
using System.Web.Mvc;

namespace WebShop.Web.Models
{
    public class ShoppingCartModelBinder : IModelBinder
    {
        private string sessionKey = "ShoppingCart";
        public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            var cart = (ShoppingCart)HttpContext.Current.Session[this.sessionKey];
            if (cart == null)
            {
                cart = new ShoppingCart();
                HttpContext.Current.Session[sessionKey] = cart;
            }
            return cart;
        }
    }
}