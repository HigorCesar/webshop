using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebShop.Web.Models
{
    public class ShoppingCartItem
    {
        public ArticleViewModel Article { get; private set; }
        public int Quantity { get; private set; }

        public ShoppingCartItem(ArticleViewModel article)
        {
            this.Article = article;
            Quantity = 1;
        }

        public decimal Price()
        {
            return Quantity * Article.Price;
        }
        public decimal Vat()
        {
            return Quantity * Article.Vat;
        }
        public decimal Total()
        {
            return Quantity * Article.TotalPrice;
        }

        public void Add()
        {
            Quantity++;
        }
    }
    public class ShoppingCart
    {
        public Dictionary<string, ShoppingCartItem> Items { get; private set; }

        public void AddItem(ArticleViewModel article)
        {
            if (Items.Any(x => x.Key == article.Id))
                Items[article.Id].Add();
            else
                Items.Add(article.Id, new ShoppingCartItem(article));
        }
        public ShoppingCart()
        {
            Items = new Dictionary<string, ShoppingCartItem>();
        }
        public void Clear()
        {
            Items = new Dictionary<string, ShoppingCartItem>();
        }
        public int Count()
        {
            return Items.Sum(a => a.Value.Quantity);
        }
        public IEnumerable<ShoppingCartItem> GetItems()
        {
            return Items.Select(i => i.Value);
        }
    }
}