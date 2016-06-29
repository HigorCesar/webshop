using System;
using ServiceStack.DataAnnotations;

namespace WebShop.Domain
{
    [Alias("Customers")]
    public class Customer
    {
        [PrimaryKey]
        public string Id { get; private set; }
        public string Title { get; private  set; }
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string Address { get; private set; }
        public string HouseNumber { get; private set; }
        public string ZipCode { get; private set; }
        public string City { get; private set; }
        public string Email { get; private set; }

        public Customer(string title, string firstName, string lastName, string email, string address, string houseNumber, string zipCode, string city)
        {
            Id = DateTime.UtcNow.ToString("yyyyMMddhhmmssfff");
            Title = title;
            FirstName = firstName;
            LastName = lastName;
            Address = address;
            HouseNumber = houseNumber;
            ZipCode = zipCode;
            City = city;
            Email = email;
        }
    }
}
