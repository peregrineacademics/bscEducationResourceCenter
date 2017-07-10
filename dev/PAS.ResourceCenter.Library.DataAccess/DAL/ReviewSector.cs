using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using PAS.ResourceCenter.Library.DataAccess.DTO;
using PAS.ResourceCenter.Library.DataAccess.Interfaces;
using PAS.ResourceCenter.Library.DataAccess.Models;

// This file is generated. DO NOT MODIFY
namespace PAS.ResourceCenter.Library.DataAccess.DAL
{
    internal class ReviewSector : DalBase<ReviewSector, ReviewSectorDto, IReviewSector>
    {
        internal override Func<ReviewSectorDto, ReviewSectorDto> DalCreate => Models.ReviewSector.Create;
        internal override Func<long, bool, ReviewSectorDto> DalGetLong => Models.ReviewSector.Get;
        internal override Func<string, bool, ReviewSectorDto> DalGetString => null;
        internal override Func<Expression<Func<IReviewSector, bool>>, bool, List<ReviewSectorDto>> DalSelect => Models.ReviewSector.Select;
        internal override Func<ReviewSectorDto, ReviewSectorDto> DalUpdate => Models.ReviewSector.Update;
        internal override Func<long, bool, ReviewSectorDto> DalDeleteLong => Models.ReviewSector.Delete;
        internal override Func<string, bool, ReviewSectorDto> DalDeleteString => null;
    }
}
