using System;
using PAS.ResourceCenter.Library.DataAccess.Models;
using System.Collections.Generic;

// This file is generated. DO NOT MODIFY
namespace PAS.ResourceCenter.Library.DataAccess.Interfaces
{
    public interface IRoleClaims
    {		
		String ClaimType{ get; set; }
		String ClaimValue{ get; set; }
		Int32 Id{ get; set; }
		String RoleId{ get; set; }

		Models.Roles Role { get; set; }

    }
}