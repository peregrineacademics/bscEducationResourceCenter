using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using PAS.ResourceCenter.Library.DataAccess.DTO;
using PAS.ResourceCenter.Library.DataAccess.Interfaces;
using PAS.ResourceCenter.Library.DataAccess.Models;

// This file is generated. DO NOT MODIFY
namespace PAS.ResourceCenter.Library.DataAccess.DAL
{
    internal class QuizQuestion : DalBase<QuizQuestion, QuizQuestionDto, IQuizQuestion>
    {
        internal override Func<QuizQuestionDto, QuizQuestionDto> DalCreate => Models.QuizQuestion.Create;
        internal override Func<long, bool, QuizQuestionDto> DalGetLong => Models.QuizQuestion.Get;
        internal override Func<string, bool, QuizQuestionDto> DalGetString => null;
        internal override Func<Expression<Func<IQuizQuestion, bool>>, bool, List<QuizQuestionDto>> DalSelect => Models.QuizQuestion.Select;
        internal override Func<QuizQuestionDto, QuizQuestionDto> DalUpdate => Models.QuizQuestion.Update;
        internal override Func<long, bool, QuizQuestionDto> DalDeleteLong => Models.QuizQuestion.Delete;
        internal override Func<string, bool, QuizQuestionDto> DalDeleteString => null;
    }
}
