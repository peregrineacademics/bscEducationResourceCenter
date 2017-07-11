using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using PAS.ResourceCenter.Library.DataAccess.DTO;
using PAS.ResourceCenter.Library.DataAccess.Interfaces;
using PAS.ResourceCenter.Library.DataAccess.Models;

// This file is generated. DO NOT MODIFY
namespace PAS.ResourceCenter.Library.DataAccess.DAL
{
    internal class ReviewerCategory : DalBase<ReviewerCategory, ReviewerCategoryDto, IReviewerCategory>
    {
        internal override Func<ReviewerCategoryDto, ReviewerCategoryDto> DalCreate => Models.ReviewerCategory.Create;
        internal override Func<long, bool, ReviewerCategoryDto> DalGetLong => Models.ReviewerCategory.Get;
        internal override Func<string, bool, ReviewerCategoryDto> DalGetString => null;
        internal override Func<Expression<Func<IReviewerCategory, bool>>, bool, List<ReviewerCategoryDto>> DalSelect => Models.ReviewerCategory.Select;
        internal override Func<ReviewerCategoryDto, ReviewerCategoryDto> DalUpdate => Models.ReviewerCategory.Update;
        internal override Func<long, bool, ReviewerCategoryDto> DalDeleteLong => Models.ReviewerCategory.Delete;
        internal override Func<string, bool, ReviewerCategoryDto> DalDeleteString => null;
    }
}
