using System;
using PAS.ResourceCenter.Library.DataAccess.Models;
using System.Collections.Generic;

// This file is generated. DO NOT MODIFY
namespace PAS.ResourceCenter.Library.DataAccess.Interfaces
{
    public interface ISector
    {		
		Int64 Id{ get; set; }
		Boolean IsEnabled{ get; set; }
		String Name{ get; set; }

		ICollection<ReviewSector> ReviewSector { get; set; }

    }
}