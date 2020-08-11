using System.Threading.Tasks;
using App.Mail.Models;

namespace App.Mail.Services
{
    public interface IEmailSender
    {
        void SendEmail(Message message);
        void SendMailWithTemplate(Message message, dynamic paramList);
        Task SendEmailAsync(Message message);
    }
}