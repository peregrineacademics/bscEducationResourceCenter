using System;
using PAS.ResourceCenter.Library.DataAccess.Models;
using System.Collections.Generic;

// This file is generated. DO NOT MODIFY
namespace PAS.ResourceCenter.Library.DataAccess.Interfaces
{
    public interface IQuizQuestion
    {		
		Int64 Id{ get; set; }
		Int64 Ordinal{ get; set; }
		String Question{ get; set; }
		Int64 QuestionTypeId{ get; set; }
		Int64 ReviewId{ get; set; }

		Models.QuestionType QuestionType { get; set; }
		ICollection<QuizAnswer> QuizAnswer { get; set; }
		Models.Review Review { get; set; }

    }
}