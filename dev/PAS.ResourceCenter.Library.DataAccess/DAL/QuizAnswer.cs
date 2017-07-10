using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using PAS.ResourceCenter.Library.DataAccess.DTO;
using PAS.ResourceCenter.Library.DataAccess.Interfaces;
using PAS.ResourceCenter.Library.DataAccess.Models;

// This file is generated. DO NOT MODIFY
namespace PAS.ResourceCenter.Library.DataAccess.DAL
{
    internal class QuizAnswer : DalBase<QuizAnswer, QuizAnswerDto, IQuizAnswer>
    {
        internal override Func<QuizAnswerDto, QuizAnswerDto> DalCreate => Models.QuizAnswer.Create;
        internal override Func<long, bool, QuizAnswerDto> DalGetLong => Models.QuizAnswer.Get;
        internal override Func<string, bool, QuizAnswerDto> DalGetString => null;
        internal override Func<Expression<Func<IQuizAnswer, bool>>, bool, List<QuizAnswerDto>> DalSelect => Models.QuizAnswer.Select;
        internal override Func<QuizAnswerDto, QuizAnswerDto> DalUpdate => Models.QuizAnswer.Update;
        internal override Func<long, bool, QuizAnswerDto> DalDeleteLong => Models.QuizAnswer.Delete;
        internal override Func<string, bool, QuizAnswerDto> DalDeleteString => null;
    }
}
