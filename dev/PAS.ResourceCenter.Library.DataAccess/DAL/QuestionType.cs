using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using PAS.ResourceCenter.Library.DataAccess.DTO;
using PAS.ResourceCenter.Library.DataAccess.Interfaces;
using PAS.ResourceCenter.Library.DataAccess.Models;

// This file is generated. DO NOT MODIFY
namespace PAS.ResourceCenter.Library.DataAccess.DAL
{
    internal class QuestionType : DalBase<QuestionType, QuestionTypeDto, IQuestionType>
    {
        internal override Func<QuestionTypeDto, QuestionTypeDto> DalCreate => Models.QuestionType.Create;
        internal override Func<long, bool, QuestionTypeDto> DalGetLong => Models.QuestionType.Get;
        internal override Func<string, bool, QuestionTypeDto> DalGetString => null;
        internal override Func<Expression<Func<IQuestionType, bool>>, bool, List<QuestionTypeDto>> DalSelect => Models.QuestionType.Select;
        internal override Func<QuestionTypeDto, QuestionTypeDto> DalUpdate => Models.QuestionType.Update;
        internal override Func<long, bool, QuestionTypeDto> DalDeleteLong => Models.QuestionType.Delete;
        internal override Func<string, bool, QuestionTypeDto> DalDeleteString => null;
    }
}
