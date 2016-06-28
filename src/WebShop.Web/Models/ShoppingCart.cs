using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebShop.Web.Models
{
    public class ShoppingCart
    {
        public List<ArticleViewModel> Articles { get; private set; }

        public void AddItem(ArticleViewModel article)
        {
            Articles.Add(article);
        }
        public ShoppingCart()
        {
            Articles = new List<ArticleViewModel>();
        }
        public Decimal Subtotal
        {
            get { return Articles.Sum(a => a.Price); }
        }
    }
}