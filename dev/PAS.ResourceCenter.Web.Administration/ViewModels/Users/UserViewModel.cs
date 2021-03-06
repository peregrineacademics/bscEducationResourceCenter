﻿using System;
using System.ComponentModel.DataAnnotations;

namespace PAS.ResourceCenter.Web.Administration.ViewModels.Users
{
    public class UserViewModel
    {
        [Required(ErrorMessage = "Id is required.")]
        public string Id { get; set; }

        [Required(ErrorMessage = "Last Name is required.")]
        [StringLength(64, ErrorMessage = "Invalid data length.")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "First Name is required.")]
        [StringLength(64, ErrorMessage = "Invalid data length.")]
        public string FirstName { get; set; }

        [StringLength(64, ErrorMessage = "Invalid data length.")]
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string MiddleName { get; set; }

        [StringLength(64, ErrorMessage = "Invalid data length.")]
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string Title { get; set; }

        [Required(ErrorMessage = "Email is required.")]
        [StringLength(64, ErrorMessage = "Invalid data length.")]
        [DataType(DataType.EmailAddress)]
        [RegularExpression(@"^[^@]+@[^@]+\.[^@\.]{2,}$", ErrorMessage = "Invalid Email.")]
        public string Email { get; set; }

        public string RoleName { get; set; }

        [Display(Name = "Enabled")]
        public bool Enabled { get; set; }

        public DateTime Created { get; set; }
    }
}