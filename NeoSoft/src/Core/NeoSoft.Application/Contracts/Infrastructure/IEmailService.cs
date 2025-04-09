using NeoSoft.Application.Models.Mail;
using System.Threading.Tasks;

namespace NeoSoft.Application.Contracts.Infrastructure
{
    public interface IEmailService
    {
        Task<bool> SendEmail(Email email);
    }
}
