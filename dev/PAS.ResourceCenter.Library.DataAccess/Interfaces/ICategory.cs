using System;
using PAS.ResourceCenter.Library.DataAccess.Models;
using System.Collections.Generic;

// This file is generated. DO NOT MODIFY
namespace PAS.ResourceCenter.Library.DataAccess.Interfaces
{
    public interface ICategory
    {		
		Int64 GroupId{ get; set; }
		Int64 Id{ get; set; }
		Boolean IsEnabled{ get; set; }
		String Name{ get; set; }
		Int64 ParentId{ get; set; }

		ICollection<ReviewCategory> ReviewCategory { get; set; }
		ICollection<ReviewerCategory> ReviewerCategory { get; set; }

    }
}