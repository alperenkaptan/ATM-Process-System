namespace WebApplication2.Entities
{
    public class Customer
    {
        public int CustomerId { get; set; }
        public string CustomerName { get; set; }
        public string CustomerPassword { get; set; }
        public string CustomerEmail { get; set; }
        public ICollection<CustomerAccount> CustomerAccounts { get; set; }

    }
}
