using System;
using ServiceStack.DataAnnotations;

namespace WebShop.Domain
{
    [Alias("Customers")]
    public class Customer
    {
        [PrimaryKey]
        public string Id { get; set; }
        public string Title { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string HouseNumber { get; set; }
        public string ZipCode { get; set; }
        public string City { get; set; }
        public string Email { get; set; }

        public Customer(string title, string firstName, string lastName, string email, string address, string houseNumber, string zipCode, string city)
        {
            Id = DateTime.UtcNow.ToString("hhmmssfff");
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
