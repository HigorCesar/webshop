using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace WebShop.Web.Models
{
    public class CheckoutViewModel
    {
        public IEnumerable<ShoppingCartItem> Items { get; }

        public decimal Subtotal()
        {
            return Items.Sum(a => a.Price());
        }
        public decimal Vat()
        {
            return Items.Sum(a => a.Vat());
        }
        public decimal Total()
        {
            return Items.Sum(a => a.Total());
        }

        public CheckoutViewModel(ShoppingCart shoppingCart)
        {
            Items = shoppingCart.GetItems();
        }

        public CheckoutViewModel()
        {
            Items = Enumerable.Empty<ShoppingCartItem>();
        }
        [Required]
        public string Title { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Address { get; set; }

        [Required]
        public string HouseNumber { get; set; }

        [Required]
        public string ZipCode { get; set; }

        [Required]
        public string City { get; set; }
    }
}