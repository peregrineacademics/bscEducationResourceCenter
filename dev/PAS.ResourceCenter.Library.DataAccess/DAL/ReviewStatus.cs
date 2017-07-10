using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using PAS.ResourceCenter.Library.DataAccess.DTO;
using PAS.ResourceCenter.Library.DataAccess.Interfaces;
using PAS.ResourceCenter.Library.DataAccess.Models;

// This file is generated. DO NOT MODIFY
namespace PAS.ResourceCenter.Library.DataAccess.DAL
{
    internal class ReviewStatus : DalBase<ReviewStatus, ReviewStatusDto, IReviewStatus>
    {
        internal override Func<ReviewStatusDto, ReviewStatusDto> DalCreate => Models.ReviewStatus.Create;
        internal override Func<long, bool, ReviewStatusDto> DalGetLong => Models.ReviewStatus.Get;
        internal override Func<string, bool, ReviewStatusDto> DalGetString => null;
        internal override Func<Expression<Func<IReviewStatus, bool>>, bool, List<ReviewStatusDto>> DalSelect => Models.ReviewStatus.Select;
        internal override Func<ReviewStatusDto, ReviewStatusDto> DalUpdate => Models.ReviewStatus.Update;
        internal override Func<long, bool, ReviewStatusDto> DalDeleteLong => Models.ReviewStatus.Delete;
        internal override Func<string, bool, ReviewStatusDto> DalDeleteString => null;
    }
}
