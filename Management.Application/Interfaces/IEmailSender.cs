using System.Threading.Tasks;

namespace Management.Application.Interfaces
{
    public interface IEmailSender
    {
        Task SendEmail(string email, string subject, string htmlMessage);
    }
}