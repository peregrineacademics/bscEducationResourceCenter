using System;
using PAS.ResourceCenter.Library.DataAccess.Models;
/* Insert Collections */

// This file is generated. DO NOT MODIFY
namespace PAS.ResourceCenter.Library.DataAccess.Interfaces
{
    public interface IDiscussionQuestion
    {		
		Int64 Id{ get; set; }
		Int64 Ordinal{ get; set; }
		String Question{ get; set; }
		Int64 ReviewId{ get; set; }

    }
}