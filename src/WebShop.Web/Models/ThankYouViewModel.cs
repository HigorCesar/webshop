namespace WebShop.Web.Models
{
    public class ThankYouViewModel
    {
        public string Customer { get; set; }

        public ThankYouViewModel()
        {

        }
        public ThankYouViewModel(string customer)
        {
            Customer = customer;
        }
    }
}