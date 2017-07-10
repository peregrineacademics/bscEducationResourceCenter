using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using PAS.ResourceCenter.Library.DataAccess.DTO;
using PAS.ResourceCenter.Library.DataAccess.Interfaces;
using PAS.ResourceCenter.Library.DataAccess.Models;

// This file is generated. DO NOT MODIFY
namespace PAS.ResourceCenter.Library.DataAccess.DAL
{
    internal class ReviewDiscipline : DalBase<ReviewDiscipline, ReviewDisciplineDto, IReviewDiscipline>
    {
        internal override Func<ReviewDisciplineDto, ReviewDisciplineDto> DalCreate => Models.ReviewDiscipline.Create;
        internal override Func<long, bool, ReviewDisciplineDto> DalGetLong => Models.ReviewDiscipline.Get;
        internal override Func<string, bool, ReviewDisciplineDto> DalGetString => null;
        internal override Func<Expression<Func<IReviewDiscipline, bool>>, bool, List<ReviewDisciplineDto>> DalSelect => Models.ReviewDiscipline.Select;
        internal override Func<ReviewDisciplineDto, ReviewDisciplineDto> DalUpdate => Models.ReviewDiscipline.Update;
        internal override Func<long, bool, ReviewDisciplineDto> DalDeleteLong => Models.ReviewDiscipline.Delete;
        internal override Func<string, bool, ReviewDisciplineDto> DalDeleteString => null;
    }
}
