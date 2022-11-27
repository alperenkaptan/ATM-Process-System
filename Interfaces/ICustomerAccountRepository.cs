namespace WebApplication2.Interfaces
{
    public interface ICustomerAccountRepository
    {
        double MoneyInfo(int CustomerID);
        string DoTransaction(int CustomerId, string customerEmail, double Money);
        int Save();
    }
}
