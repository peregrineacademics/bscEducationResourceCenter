using System;
using System.ComponentModel.DataAnnotations;

namespace PAS.ResourceCenter.Web.Administration.ViewModels.Reviewers
{
    public class ReviewerSearchViewModel
    {
        [Required(ErrorMessage = "Id is required.")]
        public string Id { get; set; }

        [StringLength(64, ErrorMessage = "Invalid data length.")]
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string ScreenName { get; set; }

        [Required(ErrorMessage = "Last Name is required.")]
        [StringLength(192, ErrorMessage = "Invalid data length.")]
        public string FullName { get; set; }

        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string Biography { get; set; }

        [Required(ErrorMessage = "Email is required.")]
        [StringLength(64, ErrorMessage = "Invalid data length.")]
        [DataType(DataType.EmailAddress)]
        [RegularExpression(@"^[^@]+@[^@]+\.[^@\.]{2,}$", ErrorMessage = "Invalid Email.")]
        public string Email { get; set; }

        [Display(Name = "Hidden")]
        public bool HideFromReviewerList { get; set; }

        [Display(Name = "Active")]
        public bool IsActiveReviewer { get; set; }

        [Display(Name = "Enabled")]
        public bool Enabled { get; set; }

        public string Created { get; set; }

        public string Modified { get; set; }

        public int ReviewsCount { get; set; }
    }
}