using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using NUnit.Framework;
using ServiceStack;
using ServiceStack.OrmLite;
using WebShop.Domain;
using WebShop.Infrastructure;

namespace WebShop.Tests.Integrated
{
    public class CheckoutRepositoryTests
    {
        private OrmLiteConnectionFactory inMemoryFactory;
        private CheckoutRepository repository;

        [SetUp]
        public void Setup()
        {
            inMemoryFactory = new OrmLiteConnectionFactory(":memory:", SqliteDialect.Provider);
            using (var db = inMemoryFactory.Open())
            {
                db.CreateTableIfNotExists<Customer>();
                db.CreateTableIfNotExists<Order>();
                db.CreateTableIfNotExists<OrderItem>();
            }
            repository = new CheckoutRepository(inMemoryFactory);
        }
        [Test]
        public async Task Checkout_failure_when_cant_save_customer()
        {
            using (var db = inMemoryFactory.Open())
                db.DropTable<Customer>();

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
                // ignored
            }

            using (var db = inMemoryFactory.Open())
                Assert.IsNull((await db.SingleAsync<Order>(o => o.Id == order.Id, CancellationToken.None)));
        }

        [Test]
        public async Task Checkout_failure_when_cant_save_order()
        {
            using (var db = inMemoryFactory.Open())
                db.DropTable<Order>();

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
                // ignored
            }

            using (var db = inMemoryFactory.Open())
                Assert.IsNull((await db.SingleAsync<Customer>(c => c.Id == customer.Id, CancellationToken.None)));
        }
        [Test]
        public async Task Checkout_failure_when_cant_save_order_item()
        {
            using (var db = inMemoryFactory.Open())
                db.DropTable<OrderItem>();

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
                // ignored
            }

            using (var db = inMemoryFactory.Open())
                Assert.IsNull((await db.SingleAsync<Customer>(c => c.Id == customer.Id, CancellationToken.None)));
        }

        [Test]
        public async Task Checkout_success()
        {
            var customer = new Customer("Mr Higor", "Higor", "Ramos", "higor@mail.com", "abcd", "21", "20220-150",
                "Rio de janeiro");
            var articles = new List<Tuple<Article, int>>
            {
                new Tuple<Article, int>(new Article {Name = "a1", Price = 10, Vat = 1}, 1),
                new Tuple<Article, int>(new Article {Name = "a2", Price = 12, Vat = 2}, 2)
            };
            var order = new Order(customer, articles);

            await repository.Checkout(customer, order, CancellationToken.None);

            using (var db = inMemoryFactory.Open())
            {
                Assert.IsNotNull((await db.SingleAsync<Customer>(c => c.Id == customer.Id, CancellationToken.None)));
                Assert.IsNotNull((await db.SingleAsync<Order>(c => c.Id == order.Id, CancellationToken.None)));
            }
        }
    }
}
