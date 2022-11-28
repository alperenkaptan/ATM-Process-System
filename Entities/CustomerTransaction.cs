
namespace WebApplication2.Entities
{
    public class CustomerTransaction
    {
        public Guid CustomerTransactionId{ get; set; }
        public double Money { get; set; }
        public DateTime TransactionDate { get; set; }
        public int TransactionNumber { get; set; }
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
    }
}
