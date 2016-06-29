using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using NUnit.Framework;
using ServiceStack.OrmLite;
using WebShop.Domain;
using WebShop.Infrastructure;

namespace WebShop.Tests.Integrated
{
    public class CheckoutRepositoryTests
    {
        private OrmLiteConnectionFactory inMemoryFactory;
        private CheckoutRepository repository;
        [Test]
        public async Task Checkout_failure()
        {
            inMemoryFactory = new OrmLiteConnectionFactory(":memory:", SqliteDialect.Provider);
            using (var db = inMemoryFactory.Open())
            {
                db.DropAndCreateTable<Customer>();
                //db.CreateTableIfNotExists<Order>();
            }
            repository = new CheckoutRepository(inMemoryFactory);

            var customer = new Customer("Mr Higor", "Higor", "Ramos", "higor@mail.com", "abcd", "21", "20220-150",
                "Rio de janeiro");
            var articles = new List<Tuple<Article, int>>
            {
                new Tuple<Article, int>(new Article {Name = "a1", Price = 10, Vat = 1}, 1),
                new Tuple<Article, int>(new Article {Name = "a2", Price = 12, Vat = 2}, 2)
            };
            try
            {
                await repository.Checkout(customer, new Order(), CancellationToken.None);
            }
            catch
            {
            }

            using (var db = inMemoryFactory.Open())
                Assert.IsNull((await db.SingleAsync<Customer>(c => c.Id == customer.Id, CancellationToken.None)));
        }
        [Test]
        public async Task Checkout_success()
        {
            inMemoryFactory = new OrmLiteConnectionFactory(":memory:", SqliteDialect.Provider);
            using (var db = inMemoryFactory.Open())
            {
                db.DropAndCreateTable<Customer>();
                db.DropAndCreateTable<Order>();
            }
            repository = new CheckoutRepository(inMemoryFactory);

            var customer = new Customer("Mr Higor", "Higor", "Ramos", "higor@mail.com", "abcd", "21", "20220-150",
                "Rio de janeiro");
            var articles = new List<Tuple<Article, int>>
            {
                new Tuple<Article, int>(new Article {Name = "a1", Price = 10, Vat = 1}, 1),
                new Tuple<Article, int>(new Article {Name = "a2", Price = 12, Vat = 2}, 2)
            };
            var order = new Order(customer, articles);

            try
            {
                await repository.Checkout(customer, order, CancellationToken.None);
            }
            catch
            {
            }

            using (var db = inMemoryFactory.Open())
            {
                Assert.IsNotNull((await db.SingleAsync<Customer>(c => c.Id == customer.Id, CancellationToken.None)));
                Assert.IsNotNull((await db.SingleAsync<Order>(c => c.Id == order.Id, CancellationToken.None)));
            }
        }
    }
}
