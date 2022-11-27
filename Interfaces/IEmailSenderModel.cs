using WebApplication2.Models;

namespace WebApplication2.Interfaces
{
    public interface IEmailSenderModel
    {
        void SendEmail(MessageModel message);
    }
}
