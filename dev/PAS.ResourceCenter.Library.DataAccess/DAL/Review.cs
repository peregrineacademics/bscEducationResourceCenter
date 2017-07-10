using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using PAS.ResourceCenter.Library.DataAccess.DTO;
using PAS.ResourceCenter.Library.DataAccess.Interfaces;
using PAS.ResourceCenter.Library.DataAccess.Models;

// This file is generated. DO NOT MODIFY
namespace PAS.ResourceCenter.Library.DataAccess.DAL
{
    internal class Review : DalBase<Review, ReviewDto, IReview>
    {
        internal override Func<ReviewDto, ReviewDto> DalCreate => Models.Review.Create;
        internal override Func<long, bool, ReviewDto> DalGetLong => Models.Review.Get;
        internal override Func<string, bool, ReviewDto> DalGetString => null;
        internal override Func<Expression<Func<IReview, bool>>, bool, List<ReviewDto>> DalSelect => Models.Review.Select;
        internal override Func<ReviewDto, ReviewDto> DalUpdate => Models.Review.Update;
        internal override Func<long, bool, ReviewDto> DalDeleteLong => Models.Review.Delete;
        internal override Func<string, bool, ReviewDto> DalDeleteString => null;
    }
}
