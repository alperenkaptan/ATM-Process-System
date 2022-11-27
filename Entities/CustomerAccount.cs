using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication2.Entities
{
    public class CustomerAccount
    {
        public Guid CustomerAccountId { get; set; }
        public double Money { get; set; }
        public DateTime TransactionDate { get; set; }
        public int TransactionNumber { get; set; }
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
    }
}
