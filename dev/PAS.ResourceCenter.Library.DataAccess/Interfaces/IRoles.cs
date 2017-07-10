using System;
using PAS.ResourceCenter.Library.DataAccess.Models;
using System.Collections.Generic;

// This file is generated. DO NOT MODIFY
namespace PAS.ResourceCenter.Library.DataAccess.Interfaces
{
    public interface IRoles
    {		
		String ConcurrencyStamp{ get; set; }
		String Id{ get; set; }
		String Name{ get; set; }
		String NormalizedName{ get; set; }

		ICollection<RoleClaims> RoleClaims { get; set; }
		ICollection<UserRoles> UserRoles { get; set; }

    }
}