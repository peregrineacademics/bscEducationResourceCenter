using System;
using PAS.ResourceCenter.Library.DataAccess.Models;
using System.Collections.Generic;

// This file is generated. DO NOT MODIFY
namespace PAS.ResourceCenter.Library.DataAccess.Interfaces
{
    public interface ISubTopic
    {		
		Int64 DisciplineId{ get; set; }
		Int64 Id{ get; set; }
		Boolean IsEnabled{ get; set; }
		String Name{ get; set; }

		Models.Discipline Discipline { get; set; }
		ICollection<ReviewSubTopic> ReviewSubTopic { get; set; }

    }
}