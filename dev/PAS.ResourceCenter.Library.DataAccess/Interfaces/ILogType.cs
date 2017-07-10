using System;
using PAS.ResourceCenter.Library.DataAccess.Models;
using System.Collections.Generic;

// This file is generated. DO NOT MODIFY
namespace PAS.ResourceCenter.Library.DataAccess.Interfaces
{
    public interface ILogType
    {		
		Int64 Id{ get; set; }
		String Name{ get; set; }

		ICollection<Log> Log { get; set; }

    }
}