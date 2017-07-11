using System;
using PAS.ResourceCenter.Library.DataAccess.Models;
using System.Collections.Generic;

// This file is generated. DO NOT MODIFY
namespace PAS.ResourceCenter.Library.DataAccess.Interfaces
{
    public interface IReview
    {		
		String Abstract{ get; set; }
		String CreatedByUserId{ get; set; }
		DateTime DateCreated{ get; set; }
		Int64 GuideTypeId{ get; set; }
		Int64 Id{ get; set; }
		Int64 IssueId{ get; set; }
		String KeyWords{ get; set; }
		DateTime LastUpdated{ get; set; }
		Boolean Migrated{ get; set; }
		String ReviewerId{ get; set; }
		Int64 ReviewStatusId{ get; set; }
		String Summary{ get; set; }
		String Title{ get; set; }
		String UpdatedByUserId{ get; set; }
		String Url{ get; set; }

		Models.Users CreatedByUser { get; set; }
		Models.GuideType GuideType { get; set; }
		Models.Issue Issue { get; set; }
		ICollection<ReviewCategory> ReviewCategory { get; set; }
		Models.Users Reviewer { get; set; }
		Models.ReviewStatus ReviewStatus { get; set; }
		Models.Users UpdatedByUser { get; set; }

    }
}