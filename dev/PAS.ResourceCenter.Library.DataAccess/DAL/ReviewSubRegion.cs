using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using PAS.ResourceCenter.Library.DataAccess.DTO;
using PAS.ResourceCenter.Library.DataAccess.Interfaces;
using PAS.ResourceCenter.Library.DataAccess.Models;

// This file is generated. DO NOT MODIFY
namespace PAS.ResourceCenter.Library.DataAccess.DAL
{
    internal class ReviewSubRegion : DalBase<ReviewSubRegion, ReviewSubRegionDto, IReviewSubRegion>
    {
        internal override Func<ReviewSubRegionDto, ReviewSubRegionDto> DalCreate => Models.ReviewSubRegion.Create;
        internal override Func<long, bool, ReviewSubRegionDto> DalGetLong => Models.ReviewSubRegion.Get;
        internal override Func<string, bool, ReviewSubRegionDto> DalGetString => null;
        internal override Func<Expression<Func<IReviewSubRegion, bool>>, bool, List<ReviewSubRegionDto>> DalSelect => Models.ReviewSubRegion.Select;
        internal override Func<ReviewSubRegionDto, ReviewSubRegionDto> DalUpdate => Models.ReviewSubRegion.Update;
        internal override Func<long, bool, ReviewSubRegionDto> DalDeleteLong => Models.ReviewSubRegion.Delete;
        internal override Func<string, bool, ReviewSubRegionDto> DalDeleteString => null;
    }
}
