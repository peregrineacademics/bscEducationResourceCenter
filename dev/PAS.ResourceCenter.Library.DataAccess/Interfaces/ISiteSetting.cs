using System;
using PAS.ResourceCenter.Library.DataAccess.Models;
/* Insert Collections */

// This file is generated. DO NOT MODIFY
namespace PAS.ResourceCenter.Library.DataAccess.Interfaces
{
    public interface ISiteSetting
    {		
		String DisplayName{ get; set; }
		Int64 Id{ get; set; }
		Boolean IsBoolean{ get; set; }
		Boolean IsCollection{ get; set; }
		Boolean IsPassword{ get; set; }
		String Name{ get; set; }
		String Notes{ get; set; }
		String Value{ get; set; }

    }
}