using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using PAS.ResourceCenter.Library.DataAccess.DTO;
using PAS.ResourceCenter.Library.DataAccess.Interfaces;
using PAS.ResourceCenter.Library.DataAccess.Models;

// This file is generated. DO NOT MODIFY
namespace PAS.ResourceCenter.Library.DataAccess.DAL
{
    internal class ReviewCompetency : DalBase<ReviewCompetency, ReviewCompetencyDto, IReviewCompetency>
    {
        internal override Func<ReviewCompetencyDto, ReviewCompetencyDto> DalCreate => Models.ReviewCompetency.Create;
        internal override Func<long, bool, ReviewCompetencyDto> DalGetLong => Models.ReviewCompetency.Get;
        internal override Func<string, bool, ReviewCompetencyDto> DalGetString => null;
        internal override Func<Expression<Func<IReviewCompetency, bool>>, bool, List<ReviewCompetencyDto>> DalSelect => Models.ReviewCompetency.Select;
        internal override Func<ReviewCompetencyDto, ReviewCompetencyDto> DalUpdate => Models.ReviewCompetency.Update;
        internal override Func<long, bool, ReviewCompetencyDto> DalDeleteLong => Models.ReviewCompetency.Delete;
        internal override Func<string, bool, ReviewCompetencyDto> DalDeleteString => null;
    }
}
