#region Using

using System.ComponentModel.DataAnnotations;

#endregion

namespace PAS.ResourceCenter.Web.Administration.ViewModels.Account
{
    public class ForgotPasswordViewModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}