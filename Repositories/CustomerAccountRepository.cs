using WebApplication2.Context;
using WebApplication2.Entities;
using WebApplication2.Interfaces;
using WebApplication2.Models;

namespace WebApplication2.Repositories
{
    public class CustomerAccountRepository : ICustomerAccountRepository
    {
        private readonly AtmDBContext _context;
        private readonly IEmailSenderModel _emailSenderModel;
        public CustomerAccountRepository(AtmDBContext context, IEmailSenderModel emailSenderModel)
        {
            _context = context;
            _emailSenderModel = emailSenderModel;
        }

        public string DoTransaction(int customerId,string customerEmail, double money)
        {
            var message = new MessageModel(new string[] { customerEmail }, "Test email", "This is the content from our email.");
            _emailSenderModel.SendEmail(message);

            if (money < 0 && MoneyInfo(customerId) < Math.Abs(money))
                return "Yetersiz Bakiye!";

            _context.CustomerAccounts.Add(
                new CustomerAccount()
                {
                    CustomerId = customerId,
                    Money = money,
                    TransactionDate = DateTime.Now
                }
                );
            if (Save() > 0)
            {
                //mail gönder
                return "Bakiye Güncellendi.";
            }
            else
            {
                return "Bakiye Güncellenirken Bir Hata Oluştu!";
            }
        }

        public double MoneyInfo(int CustomerId)
        {
            var transactions = _context.CustomerAccounts.Where(x => x.CustomerId == CustomerId).ToList();
            double money = 0.00;
            foreach (var m in transactions)
            {
                money += m.Money;
            }
            return money;
        }

        public int Save()
        {
            return _context.SaveChanges();
        }
    }
}
