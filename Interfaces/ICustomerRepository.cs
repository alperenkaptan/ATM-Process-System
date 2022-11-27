using WebApplication2.Entities;

namespace WebApplication2.Interfaces
{
    public interface ICustomerRepository
    {
        IEnumerable<Customer> GetAll();
    }
}
