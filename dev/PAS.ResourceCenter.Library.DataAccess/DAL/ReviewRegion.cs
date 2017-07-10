using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using PAS.ResourceCenter.Library.DataAccess.DTO;
using PAS.ResourceCenter.Library.DataAccess.Interfaces;
using PAS.ResourceCenter.Library.DataAccess.Models;

// This file is generated. DO NOT MODIFY
namespace PAS.ResourceCenter.Library.DataAccess.DAL
{
    internal class ReviewRegion : DalBase<ReviewRegion, ReviewRegionDto, IReviewRegion>
    {
        internal override Func<ReviewRegionDto, ReviewRegionDto> DalCreate => Models.ReviewRegion.Create;
        internal override Func<long, bool, ReviewRegionDto> DalGetLong => Models.ReviewRegion.Get;
        internal override Func<string, bool, ReviewRegionDto> DalGetString => null;
        internal override Func<Expression<Func<IReviewRegion, bool>>, bool, List<ReviewRegionDto>> DalSelect => Models.ReviewRegion.Select;
        internal override Func<ReviewRegionDto, ReviewRegionDto> DalUpdate => Models.ReviewRegion.Update;
        internal override Func<long, bool, ReviewRegionDto> DalDeleteLong => Models.ReviewRegion.Delete;
        internal override Func<string, bool, ReviewRegionDto> DalDeleteString => null;
    }
}
