#region Using

using System.Threading.Tasks;

#endregion

namespace PAS.ResourceCenter.Web.Administration.Services
{
    public interface ISmsSender
    {
        Task SendSmsAsync(string number, string message);
    }
}