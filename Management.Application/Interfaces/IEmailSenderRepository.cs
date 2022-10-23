using System.Threading.Tasks;

namespace Management.Application.Interfaces
{
    public interface IEmailSenderRepository
    {
        Task SendEmail(string email, string subject, string htmlMessage);
    }
}