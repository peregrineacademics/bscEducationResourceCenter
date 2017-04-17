#region Using

using System.ComponentModel.DataAnnotations;

#endregion

namespace PAS.ResourceCenter.Web.Administration.ViewModels.Account
{
    public class ExternalLoginConfirmationViewModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}