using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using PAS.ResourceCenter.Library.DataAccess.DTO;
using PAS.ResourceCenter.Library.DataAccess.Interfaces;
using PAS.ResourceCenter.Library.DataAccess.Models;

// This file is generated. DO NOT MODIFY
namespace PAS.ResourceCenter.Library.DataAccess.DAL
{
    internal class DiscussionQuestion : DalBase<DiscussionQuestion, DiscussionQuestionDto, IDiscussionQuestion>
    {
        internal override Func<DiscussionQuestionDto, DiscussionQuestionDto> DalCreate => Models.DiscussionQuestion.Create;
        internal override Func<long, bool, DiscussionQuestionDto> DalGetLong => Models.DiscussionQuestion.Get;
        internal override Func<string, bool, DiscussionQuestionDto> DalGetString => null;
        internal override Func<Expression<Func<IDiscussionQuestion, bool>>, bool, List<DiscussionQuestionDto>> DalSelect => Models.DiscussionQuestion.Select;
        internal override Func<DiscussionQuestionDto, DiscussionQuestionDto> DalUpdate => Models.DiscussionQuestion.Update;
        internal override Func<long, bool, DiscussionQuestionDto> DalDeleteLong => Models.DiscussionQuestion.Delete;
        internal override Func<string, bool, DiscussionQuestionDto> DalDeleteString => null;
    }
}
