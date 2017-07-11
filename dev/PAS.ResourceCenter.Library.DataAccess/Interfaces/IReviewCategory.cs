using System;
using PAS.ResourceCenter.Library.DataAccess.Models;
using System.Collections.Generic;

// This file is generated. DO NOT MODIFY
namespace PAS.ResourceCenter.Library.DataAccess.Interfaces
{
    public interface IReviewCategory
    {		
		Int64 Categoryid{ get; set; }
		Int64 Id{ get; set; }
		Int64 ReviewId{ get; set; }

		Models.Category Category { get; set; }
		Models.Review Review { get; set; }

    }
}