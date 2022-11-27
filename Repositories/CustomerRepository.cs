using WebApplication2.Context;
using WebApplication2.Entities;
using WebApplication2.Interfaces;

namespace WebApplication2.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly AtmDBContext _context;
        public CustomerRepository(AtmDBContext context)
        {
            _context = context;
        }
        public IEnumerable<Customer> GetAll()
        {
            return _context.Customers.ToList();
        }
    }
}
