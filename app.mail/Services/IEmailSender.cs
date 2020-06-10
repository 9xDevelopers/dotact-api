using System.Threading.Tasks;
using app.mail.Models;

namespace app.mail.Services
{
    public interface IEmailSender
    {
        void SendEmail(Message message);
        Task SendEmailAsync(Message message);
    }
}