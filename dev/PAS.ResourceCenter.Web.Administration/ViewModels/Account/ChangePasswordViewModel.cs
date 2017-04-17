#region Using

using System.ComponentModel.DataAnnotations;

#endregion

namespace PAS.ResourceCenter.Web.Administration.ViewModels.Account
{
    public class ChangePasswordViewModel
    {
        [Required(ErrorMessage = "Old password is required.")]
        [StringLength(64, ErrorMessage = "Invalid data length.")]
        [MinLength(6, ErrorMessage = "Minimum of 6 characters.")]
        [DataType(DataType.Password)]
        public string OldPassword { get; set; }

        [Required(ErrorMessage = "New password is required.")]
        [StringLength(64, ErrorMessage = "Invalid data length.")]
        [MinLength(6, ErrorMessage = "Minimum of 6 characters.")]
        [DataType(DataType.Password)]
        public string NewPassword { get; set; }

        [Required(ErrorMessage = "Password is required.")]
        [StringLength(64, ErrorMessage = "Invalid data length.")]
        [DataType(DataType.Password)]
        [Compare("NewPassword", ErrorMessage = "New password must match.")]
        public string ConfirmPassword { get; set; }
    }
}