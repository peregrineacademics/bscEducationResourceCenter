using System;
using PAS.ResourceCenter.Library.DataAccess.Models;
using System.Collections.Generic;

// This file is generated. DO NOT MODIFY
namespace PAS.ResourceCenter.Library.DataAccess.Interfaces
{
    public interface IUsers
    {		
		Int32 AccessFailedCount{ get; set; }
		String ConcurrencyStamp{ get; set; }
		DateTime DateCreated{ get; set; }
		String Email{ get; set; }
		Boolean EmailConfirmed{ get; set; }
		String FirstName{ get; set; }
		String Id{ get; set; }
		Boolean IsEnabled{ get; set; }
		String LastName{ get; set; }
		DateTime LastUpdated{ get; set; }
		Boolean LockoutEnabled{ get; set; }
		DateTimeOffset? LockoutEnd{ get; set; }
		String MiddleName{ get; set; }
		String NormalizedEmail{ get; set; }
		String NormalizedUserName{ get; set; }
		String PasswordHash{ get; set; }
		String PhoneNumber{ get; set; }
		Boolean PhoneNumberConfirmed{ get; set; }
		String ScreenName{ get; set; }
		String SecurityStamp{ get; set; }
		String Title{ get; set; }
		Boolean TwoFactorEnabled{ get; set; }
		String UserName{ get; set; }

		ICollection<Issue> IssueCreatedByUser { get; set; }
		ICollection<Issue> IssueUpdatedByUser { get; set; }
		ICollection<Log> Log { get; set; }
		ICollection<Review> ReviewCreatedByUser { get; set; }
		ICollection<Reviewer> ReviewerUpdatedByUser { get; set; }
		Models.Reviewer ReviewerUser { get; set; }
		ICollection<Review> ReviewUpdatedByUser { get; set; }
		ICollection<UserClaims> UserClaims { get; set; }
		ICollection<UserLogins> UserLogins { get; set; }
		ICollection<UserRoles> UserRoles { get; set; }

    }
}