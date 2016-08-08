using ServiceStack.DataAnnotations;

namespace WebShop.Domain
{
    [Alias("Customers")]
    public class Customer
    {
        [PrimaryKey]
        [AutoIncrement]
        public int Id { get; set; }
        [StringLength(200)]
        public string Title { get; private set; }
        [StringLength(200)]
        public string FirstName { get; private set; }
        [StringLength(200)]
        public string LastName { get; private set; }
        [StringLength(400)]
        public string Address { get; private set; }
        [StringLength(20)]
        public string HouseNumber { get; private set; }
        [StringLength(20)]
        public string ZipCode { get; private set; }
        [StringLength(200)]
        public string City { get; private set; }
        [StringLength(200)]
        public string Email { get; private set; }

        public Customer(string title, string firstName, string lastName, string email, string address, string houseNumber, string zipCode, string city)
        {
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
