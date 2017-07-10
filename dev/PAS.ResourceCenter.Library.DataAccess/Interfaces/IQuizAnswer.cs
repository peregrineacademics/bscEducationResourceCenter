using System;
using PAS.ResourceCenter.Library.DataAccess.Models;
using System.Collections.Generic;

// This file is generated. DO NOT MODIFY
namespace PAS.ResourceCenter.Library.DataAccess.Interfaces
{
    public interface IQuizAnswer
    {		
		String Answer{ get; set; }
		Int64 Id{ get; set; }
		Int64 Ordinal{ get; set; }
		Int64 QuizQuestionId{ get; set; }

		Models.QuizQuestion QuizQuestion { get; set; }

    }
}