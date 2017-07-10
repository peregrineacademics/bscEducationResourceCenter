using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using PAS.ResourceCenter.Library.DataAccess.DTO;
using PAS.ResourceCenter.Library.DataAccess.Interfaces;
using PAS.ResourceCenter.Library.DataAccess.Models;

// This file is generated. DO NOT MODIFY
namespace PAS.ResourceCenter.Library.DataAccess.DAL
{
    internal class ReviewActivity : DalBase<ReviewActivity, ReviewActivityDto, IReviewActivity>
    {
        internal override Func<ReviewActivityDto, ReviewActivityDto> DalCreate => Models.ReviewActivity.Create;
        internal override Func<long, bool, ReviewActivityDto> DalGetLong => Models.ReviewActivity.Get;
        internal override Func<string, bool, ReviewActivityDto> DalGetString => null;
        internal override Func<Expression<Func<IReviewActivity, bool>>, bool, List<ReviewActivityDto>> DalSelect => Models.ReviewActivity.Select;
        internal override Func<ReviewActivityDto, ReviewActivityDto> DalUpdate => Models.ReviewActivity.Update;
        internal override Func<long, bool, ReviewActivityDto> DalDeleteLong => Models.ReviewActivity.Delete;
        internal override Func<string, bool, ReviewActivityDto> DalDeleteString => null;
    }
}
