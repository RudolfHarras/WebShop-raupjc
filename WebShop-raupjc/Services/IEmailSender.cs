using System.Threading.Tasks;

namespace WebShop_raupjc.Services
{
    public interface IEmailSender
    {
        Task SendEmailAsync(string email, string subject, string message);
    }
}
