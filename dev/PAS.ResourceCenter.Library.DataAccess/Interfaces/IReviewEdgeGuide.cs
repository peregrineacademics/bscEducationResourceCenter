using System;
using PAS.ResourceCenter.Library.DataAccess.Models;
using System.Collections.Generic;

// This file is generated. DO NOT MODIFY
namespace PAS.ResourceCenter.Library.DataAccess.Interfaces
{
    public interface IReviewEdgeGuide
    {		
		Int64 EdgeGuideId{ get; set; }
		Int64 Id{ get; set; }
		Int64 ReviewId{ get; set; }

		Models.EdgeGuide EdgeGuide { get; set; }

    }
}