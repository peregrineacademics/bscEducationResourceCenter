using System;
using PAS.ResourceCenter.Library.DataAccess.Models;
using System.Collections.Generic;

// This file is generated. DO NOT MODIFY
namespace PAS.ResourceCenter.Library.DataAccess.Interfaces
{
    public interface IReviewCompetency
    {		
		Int64 CompetencyId{ get; set; }
		Int64 Id{ get; set; }
		Int64 ReviewId{ get; set; }

		Models.Competency Competency { get; set; }
		Models.Review Review { get; set; }

    }
}