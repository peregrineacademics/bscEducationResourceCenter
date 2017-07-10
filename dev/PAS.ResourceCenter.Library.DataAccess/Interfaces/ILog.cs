using System;
using PAS.ResourceCenter.Library.DataAccess.Models;
using System.Collections.Generic;

// This file is generated. DO NOT MODIFY
namespace PAS.ResourceCenter.Library.DataAccess.Interfaces
{
    public interface ILog
    {		
		String CreatedByUserId{ get; set; }
		DateTime DateCreated{ get; set; }
		Int64 Id{ get; set; }
		Int64 LinkId{ get; set; }
		String LinkUserId{ get; set; }
		Int64 LogSourceId{ get; set; }
		Int64 LogTypeId{ get; set; }
		String Message{ get; set; }

		Models.Users CreatedByUser { get; set; }
		Models.LogSource LogSource { get; set; }
		Models.LogType LogType { get; set; }

    }
}