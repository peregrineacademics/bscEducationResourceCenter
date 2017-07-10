using System;
using PAS.ResourceCenter.Library.DataAccess.Models;
using System.Collections.Generic;

// This file is generated. DO NOT MODIFY
namespace PAS.ResourceCenter.Library.DataAccess.Interfaces
{
    public interface IReviewRegion
    {		
		Int64 Id{ get; set; }
		Int64 RegionId{ get; set; }
		Int64 ReviewId{ get; set; }

		Models.Region Region { get; set; }
		Models.Review Review { get; set; }

    }
}