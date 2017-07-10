using System.ComponentModel.DataAnnotations;

namespace PAS.ResourceCenter.Web.Administration.ViewModels.Home
{
    public class MyProfileViewModel
    {
        [Required(ErrorMessage = "Last Name is required.")]
        [StringLength(64, ErrorMessage = "Invalid data length.")]
        public string ProfileLastName { get; set; }

        [Required(ErrorMessage = "First Name is required.")]
        [StringLength(64, ErrorMessage = "Invalid data length.")]
        public string ProfileFirstName { get; set; }

        [StringLength(64, ErrorMessage = "Invalid data length.")]
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string ProfileMiddleName { get; set; }

        [Required(ErrorMessage = "Email is required.")]
        [StringLength(64, ErrorMessage = "Invalid data length.")]
        [DataType(DataType.EmailAddress)]
        [RegularExpression(@"^[^@]+@[^@]+\.[^@\.]{2,}$", ErrorMessage = "Invalid Email.")]
        public string ProfileEmail { get; set; }
    }
}