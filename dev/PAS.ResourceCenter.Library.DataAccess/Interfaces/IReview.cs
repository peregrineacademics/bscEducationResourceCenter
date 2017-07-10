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
		Int64 ReviewerId{ get; set; }
		Int64 ReviewStatusId{ get; set; }
		String Summary{ get; set; }
		String Title{ get; set; }
		String UpdatedByUserId{ get; set; }
		String Url{ get; set; }

		Models.Users CreatedByUser { get; set; }
		ICollection<DiscussionQuestion> DiscussionQuestion { get; set; }
		Models.GuideType GuideType { get; set; }
		Models.Issue Issue { get; set; }
		ICollection<QuizQuestion> QuizQuestion { get; set; }
		ICollection<ReviewActivity> ReviewActivity { get; set; }
		ICollection<ReviewCompetency> ReviewCompetency { get; set; }
		ICollection<ReviewDiscipline> ReviewDiscipline { get; set; }
		ICollection<ReviewEdgeGuide> ReviewEdgeGuide { get; set; }
		Models.Reviewer Reviewer { get; set; }
		ICollection<ReviewRegion> ReviewRegion { get; set; }
		ICollection<ReviewSector> ReviewSector { get; set; }
		Models.ReviewStatus ReviewStatus { get; set; }
		ICollection<ReviewSubRegion> ReviewSubRegion { get; set; }
		ICollection<ReviewSubTopic> ReviewSubTopic { get; set; }
		Models.Users UpdatedByUser { get; set; }

    }
}