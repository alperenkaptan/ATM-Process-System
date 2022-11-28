namespace WebApplication2.Interfaces
{
    public interface ICustomerTransactionRepository
    {
        double MoneyInfo(int CustomerID);
        //string DoTransaction(int CustomerId, string customerEmail, double Money);
        string GetMoney(int CustomerId, string customerEmail, double Money);
        string SendMoney(int CustomerId, string customerEmail, double Money);
        int Save();
    }
}
