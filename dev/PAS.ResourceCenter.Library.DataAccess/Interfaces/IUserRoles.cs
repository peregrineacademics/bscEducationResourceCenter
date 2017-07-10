using System;
using PAS.ResourceCenter.Library.DataAccess.Models;
using System.Collections.Generic;

// This file is generated. DO NOT MODIFY
namespace PAS.ResourceCenter.Library.DataAccess.Interfaces
{
    public interface IUserRoles
    {		
		Int64 Id{ get; set; }
		String RoleId{ get; set; }
		String UserId{ get; set; }

		Models.Roles Role { get; set; }
		Models.Users User { get; set; }

    }
}