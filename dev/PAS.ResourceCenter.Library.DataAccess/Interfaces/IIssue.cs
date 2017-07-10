using System;
using PAS.ResourceCenter.Library.DataAccess.Models;
using System.Collections.Generic;

// This file is generated. DO NOT MODIFY
namespace PAS.ResourceCenter.Library.DataAccess.Interfaces
{
    public interface IIssue
    {		
		String CoverImage{ get; set; }
		String CoverStoryUrl{ get; set; }
		String CreatedByUserId{ get; set; }
		DateTime DateCreated{ get; set; }
		Int64 Id{ get; set; }
		Boolean IsEnabled{ get; set; }
		DateTime IssueDate{ get; set; }
		String IssueName{ get; set; }
		String IssueTitle{ get; set; }
		String IssueUrlName{ get; set; }
		DateTime LastUpdated{ get; set; }
		String UpdatedByUserId{ get; set; }

		Models.Users CreatedByUser { get; set; }
		ICollection<Review> Review { get; set; }
		Models.Users UpdatedByUser { get; set; }

    }
}