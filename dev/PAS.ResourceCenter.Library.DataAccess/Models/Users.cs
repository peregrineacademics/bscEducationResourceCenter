﻿using System;
using System.Collections.Generic;

namespace PAS.ResourceCenter.Library.DataAccess.Models
{
    public partial class Users
    {
        public Users()
        {
            IssueCreatedByUser = new HashSet<Issue>();
            IssueUpdatedByUser = new HashSet<Issue>();
            Log = new HashSet<Log>();
            ReviewCreatedByUser = new HashSet<Review>();
            ReviewReviewer = new HashSet<Review>();
            ReviewUpdatedByUser = new HashSet<Review>();
            ReviewerCategory = new HashSet<ReviewerCategory>();
            UserClaims = new HashSet<UserClaims>();
            UserLogins = new HashSet<UserLogins>();
            UserRoles = new HashSet<UserRoles>();
        }

        public string Id { get; set; }
        public int AccessFailedCount { get; set; }
        public string ConcurrencyStamp { get; set; }
        public string Email { get; set; }
        public bool EmailConfirmed { get; set; }
        public bool LockoutEnabled { get; set; }
        public DateTimeOffset? LockoutEnd { get; set; }
        public string NormalizedEmail { get; set; }
        public string NormalizedUserName { get; set; }
        public string PasswordHash { get; set; }
        public string PhoneNumber { get; set; }
        public bool PhoneNumberConfirmed { get; set; }
        public string SecurityStamp { get; set; }
        public bool TwoFactorEnabled { get; set; }
        public string UserName { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string Title { get; set; }
        public string ScreenName { get; set; }
        public string Degree { get; set; }
        public string Biography { get; set; }
        public bool HideFromReviewerList { get; set; }
        public bool IsActiveReviewer { get; set; }
        public bool IsEnabled { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime LastUpdated { get; set; }

        public virtual ICollection<Issue> IssueCreatedByUser { get; set; }
        public virtual ICollection<Issue> IssueUpdatedByUser { get; set; }
        public virtual ICollection<Log> Log { get; set; }
        public virtual ICollection<Review> ReviewCreatedByUser { get; set; }
        public virtual ICollection<Review> ReviewReviewer { get; set; }
        public virtual ICollection<Review> ReviewUpdatedByUser { get; set; }
        public virtual ICollection<ReviewerCategory> ReviewerCategory { get; set; }
        public virtual ICollection<UserClaims> UserClaims { get; set; }
        public virtual ICollection<UserLogins> UserLogins { get; set; }
        public virtual ICollection<UserRoles> UserRoles { get; set; }
    }
}
