using System;
using PAS.ResourceCenter.Library.DataAccess.Models;
using System.Collections.Generic;

// This file is generated. DO NOT MODIFY
namespace PAS.ResourceCenter.Library.DataAccess.Interfaces
{
    public interface ISubRegion
    {		
		Int64 Id{ get; set; }
		Boolean IsEnabled{ get; set; }
		String Name{ get; set; }
		Int64 RegionId{ get; set; }

		Models.Region Region { get; set; }
		ICollection<ReviewSubRegion> ReviewSubRegion { get; set; }

    }
}