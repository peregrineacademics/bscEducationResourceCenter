using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using PAS.ResourceCenter.Library.DataAccess.DTO;
using PAS.ResourceCenter.Library.DataAccess.Interfaces;
using PAS.ResourceCenter.Library.DataAccess.Models;

// This file is generated. DO NOT MODIFY
namespace PAS.ResourceCenter.Library.DataAccess.DAL
{
    internal class ReviewCategory : DalBase<ReviewCategory, ReviewCategoryDto, IReviewCategory>
    {
        internal override Func<ReviewCategoryDto, ReviewCategoryDto> DalCreate => Models.ReviewCategory.Create;
        internal override Func<long, bool, ReviewCategoryDto> DalGetLong => Models.ReviewCategory.Get;
        internal override Func<string, bool, ReviewCategoryDto> DalGetString => null;
        internal override Func<Expression<Func<IReviewCategory, bool>>, bool, List<ReviewCategoryDto>> DalSelect => Models.ReviewCategory.Select;
        internal override Func<ReviewCategoryDto, ReviewCategoryDto> DalUpdate => Models.ReviewCategory.Update;
        internal override Func<long, bool, ReviewCategoryDto> DalDeleteLong => Models.ReviewCategory.Delete;
        internal override Func<string, bool, ReviewCategoryDto> DalDeleteString => null;
    }
}
