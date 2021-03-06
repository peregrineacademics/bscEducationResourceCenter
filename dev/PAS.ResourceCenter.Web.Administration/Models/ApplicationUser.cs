﻿#region Using

 
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System;

#endregion

namespace PAS.ResourceCenter.Web.Administration.Models
{
    // Add profile data for application users by adding properties to the ApplicationUser class
    public class ApplicationUser : IdentityUser
    {
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string Title { get; set; }
        public string ScreenName { get; set; }
        public string Degree { get; set; }
        public string Biography { get; set; }
        public bool IsEnabled { get; set; }
        public bool HideFromReviewerList { get; set; }
        public bool IsActiveReviewer { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime LastUpdated { get; set; }
    }
}