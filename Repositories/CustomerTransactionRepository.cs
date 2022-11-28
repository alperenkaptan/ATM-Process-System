using WebApplication2.Context;
using WebApplication2.Entities;
using WebApplication2.Interfaces;
using WebApplication2.Models;

namespace WebApplication2.Repositories
{
    public class CustomerTransactionRepository : ICustomerTransactionRepository
    {
        private readonly AtmDBContext _context;
        private readonly IEmailSender _emailSenderModel;
        public CustomerTransactionRepository(AtmDBContext context, IEmailSender emailSenderModel)
        {
            _context = context;
            _emailSenderModel = emailSenderModel;
        }

        //public string DoTransaction(int customerId,string customerEmail, double money)
        //{
        //    var message = new MessageModel(new string[] { customerEmail }, "Test email", "This is the content from our email.");
        //    _emailSenderModel.SendEmail(message);

        //    if (money < 0 && MoneyInfo(customerId) < Math.Abs(money))
        //        return "Yetersiz Bakiye!";

        //    _context.CustomerAccounts.Add(
        //        new CustomerTransaction()
        //        {
        //            CustomerId = customerId,
        //            Money = money,
        //            TransactionDate = DateTime.Now
        //        }
        //        );
        //    if (Save() > 0)
        //    {
        //        //mail gönder
        //        return "Bakiye Güncellendi.";
        //    }
        //    else
        //    {
        //        return "Bakiye Güncellenirken Bir Hata Oluştu!";
        //    }
        //}

        public string GetMoney(int customerId, string customerEmail, double money)
        {
            var message = new MessageModel(new string[] { customerEmail }, "Test email", $"Hesabınızdan {money} miktar");
            
            if (MoneyInfo(customerId) < money)
            {
                var msg = "Yetersiz Bakiye!";
                message.Content +="  çekilmeye çalışıldı. Yetersiz bakiye nedeni ile çekilemedi.";
                _emailSenderModel.SendEmail(message);
                return msg;
            }

            _context.CustomerTransaction.Add(
                new CustomerTransaction()
                {
                    CustomerId = customerId,
                    Money = -money,
                    TransactionDate = DateTime.Now
                }
                );

            if (Save() > 0)
            {
                message.Content += "  başarı ile çekildi.";
                _emailSenderModel.SendEmail(message);
                return $"Hesabınızdan {money} miktar çekildi.";
            }
            else
            {
                message.Content += "  çekilmeye çalışıldı. Sistem arızası nedeni ile çekilemedi.";
                _emailSenderModel.SendEmail(message);
                return "Bakiye Güncellenirken Bir Hata Oluştu!";
            }
        }

        public string SendMoney(int customerId, string customerEmail, double money)
        {
            var message = new MessageModel(new string[] { customerEmail }, "Test email", $"Hesabınıza {money} miktar");

            _context.CustomerTransaction.Add(
                new CustomerTransaction()
                {
                    CustomerId = customerId,
                    Money = money,
                    TransactionDate = DateTime.Now
                }
                );

            if (Save() > 0)
            {
                message.Content += "  başarı ile yüklendi.";
                _emailSenderModel.SendEmail(message);
                return $"Hesabınıza {money} miktar yüklendi.";
            }
            else
            {
                message.Content += "  yüklenmeye çalışıldı. Sistem arızası nedeni ile çekilemedi.";
                _emailSenderModel.SendEmail(message);
                return "Bakiye Güncellenirken Bir Hata Oluştu!";
            }
        }

        public double MoneyInfo(int CustomerId)
        {
            var transactions = _context.CustomerTransaction.Where(x => x.CustomerId == CustomerId).ToList();
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
