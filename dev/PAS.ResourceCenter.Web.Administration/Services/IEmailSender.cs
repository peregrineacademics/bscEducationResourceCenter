#region Using

using System.Threading.Tasks;

#endregion

namespace PAS.ResourceCenter.Web.Administration.Services
{
    public interface IEmailSender
    {
        Task SendEmailAsync(string email, string subject, string message);
    }
}