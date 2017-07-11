using System;
using PAS.ResourceCenter.Library.DataAccess.Models;
using System.Collections.Generic;

// This file is generated. DO NOT MODIFY
namespace PAS.ResourceCenter.Library.DataAccess.Interfaces
{
    public interface IReviewerCategory
    {		
		Int64 Categoryid{ get; set; }
		Int64 Id{ get; set; }
		String UserId{ get; set; }

		Models.Category Category { get; set; }
		Models.Users User { get; set; }

    }
}