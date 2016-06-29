using System;
using System.Collections.Generic;

namespace WebShop.Domain
{
    public class Paging<T> where T : class
    {
        public Paging(IEnumerable<T> values, int quantity, int page)
        {
            if (values == null)
                throw new ArgumentNullException();

            Values = values;
            Quantity = quantity;
            Page = page;
        }
        public int Quantity { get; private set; }
        public int Page { get; private set; }
        public IEnumerable<T> Values { get; private set; }
    }
}
