using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using PAS.ResourceCenter.Library.DataAccess.DTO;
using PAS.ResourceCenter.Library.DataAccess.Interfaces;
using PAS.ResourceCenter.Library.DataAccess.Models;

// This file is generated. DO NOT MODIFY
namespace PAS.ResourceCenter.Library.DataAccess.DAL
{
    internal class ReviewEdgeGuide : DalBase<ReviewEdgeGuide, ReviewEdgeGuideDto, IReviewEdgeGuide>
    {
        internal override Func<ReviewEdgeGuideDto, ReviewEdgeGuideDto> DalCreate => Models.ReviewEdgeGuide.Create;
        internal override Func<long, bool, ReviewEdgeGuideDto> DalGetLong => Models.ReviewEdgeGuide.Get;
        internal override Func<string, bool, ReviewEdgeGuideDto> DalGetString => null;
        internal override Func<Expression<Func<IReviewEdgeGuide, bool>>, bool, List<ReviewEdgeGuideDto>> DalSelect => Models.ReviewEdgeGuide.Select;
        internal override Func<ReviewEdgeGuideDto, ReviewEdgeGuideDto> DalUpdate => Models.ReviewEdgeGuide.Update;
        internal override Func<long, bool, ReviewEdgeGuideDto> DalDeleteLong => Models.ReviewEdgeGuide.Delete;
        internal override Func<string, bool, ReviewEdgeGuideDto> DalDeleteString => null;
    }
}
