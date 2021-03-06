﻿using System.ComponentModel.DataAnnotations;

namespace PAS.ResourceCenter.Web.Administration.ViewModels.Users
{
    public class SearchNameViewModel
    {
        [Required(ErrorMessage = "Name is required.")]
        [StringLength(256, ErrorMessage = "Invalid data length.")]
        public string Name { get; set; }
    }
}