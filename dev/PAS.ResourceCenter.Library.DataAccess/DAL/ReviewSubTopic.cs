using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using PAS.ResourceCenter.Library.DataAccess.DTO;
using PAS.ResourceCenter.Library.DataAccess.Interfaces;
using PAS.ResourceCenter.Library.DataAccess.Models;

// This file is generated. DO NOT MODIFY
namespace PAS.ResourceCenter.Library.DataAccess.DAL
{
    internal class ReviewSubTopic : DalBase<ReviewSubTopic, ReviewSubTopicDto, IReviewSubTopic>
    {
        internal override Func<ReviewSubTopicDto, ReviewSubTopicDto> DalCreate => Models.ReviewSubTopic.Create;
        internal override Func<long, bool, ReviewSubTopicDto> DalGetLong => Models.ReviewSubTopic.Get;
        internal override Func<string, bool, ReviewSubTopicDto> DalGetString => null;
        internal override Func<Expression<Func<IReviewSubTopic, bool>>, bool, List<ReviewSubTopicDto>> DalSelect => Models.ReviewSubTopic.Select;
        internal override Func<ReviewSubTopicDto, ReviewSubTopicDto> DalUpdate => Models.ReviewSubTopic.Update;
        internal override Func<long, bool, ReviewSubTopicDto> DalDeleteLong => Models.ReviewSubTopic.Delete;
        internal override Func<string, bool, ReviewSubTopicDto> DalDeleteString => null;
    }
}
