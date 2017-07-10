using System;
using PAS.ResourceCenter.Library.DataAccess.Models;
using System.Collections.Generic;

// This file is generated. DO NOT MODIFY
namespace PAS.ResourceCenter.Library.DataAccess.Interfaces
{
    public interface IReviewer
    {		
		String Biography{ get; set; }
		String CreatedByUserId{ get; set; }
		DateTime DateCreated{ get; set; }
		String Degree{ get; set; }
		Boolean HideFromReviewerList{ get; set; }
		Int64 Id{ get; set; }
		Boolean IsActive{ get; set; }
		DateTime LastUpdated{ get; set; }
		String UpdatedByUserId{ get; set; }
		String UserId{ get; set; }

		ICollection<Review> Review { get; set; }
		Models.Users UpdatedByUser { get; set; }
		Models.Users User { get; set; }

    }
}