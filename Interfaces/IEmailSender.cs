using WebApplication2.Models;

namespace WebApplication2.Interfaces
{
    public interface IEmailSender
    {
        void SendEmail(MessageModel message);
    }
}
