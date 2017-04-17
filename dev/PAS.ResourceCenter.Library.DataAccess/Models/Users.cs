using System;
using System.Collections.Generic;

namespace PAS.ResourceCenter.Library.DataAccess.Models
{
    public partial class Users
    {
        public Users()
        {
            ArticleCreatedByUser = new HashSet<Article>();
            ArticleUpdatedByUser = new HashSet<Article>();
            IssueCreatedByUser = new HashSet<Issue>();
            IssueUpdatedByUser = new HashSet<Issue>();
            ReviewerCreatedByUser = new HashSet<Reviewer>();
            ReviewerUpdatedByUser = new HashSet<Reviewer>();
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
        public bool IsEnabled { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime LastUpdated { get; set; }

        public virtual ICollection<Article> ArticleCreatedByUser { get; set; }
        public virtual ICollection<Article> ArticleUpdatedByUser { get; set; }
        public virtual ICollection<Issue> IssueCreatedByUser { get; set; }
        public virtual ICollection<Issue> IssueUpdatedByUser { get; set; }
        public virtual ICollection<Reviewer> ReviewerCreatedByUser { get; set; }
        public virtual ICollection<Reviewer> ReviewerUpdatedByUser { get; set; }
        public virtual ICollection<UserClaims> UserClaims { get; set; }
        public virtual ICollection<UserLogins> UserLogins { get; set; }
        public virtual ICollection<UserRoles> UserRoles { get; set; }
    }
}
