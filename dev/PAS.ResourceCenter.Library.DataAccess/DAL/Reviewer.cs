using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using PAS.ResourceCenter.Library.DataAccess.DTO;
using PAS.ResourceCenter.Library.DataAccess.Interfaces;
using PAS.ResourceCenter.Library.DataAccess.Models;

// This file is generated. DO NOT MODIFY
namespace PAS.ResourceCenter.Library.DataAccess.DAL
{
    internal class Reviewer : DalBase<Reviewer, ReviewerDto, IReviewer>
    {
        internal override Func<ReviewerDto, ReviewerDto> DalCreate => Models.Reviewer.Create;
        internal override Func<long, bool, ReviewerDto> DalGetLong => Models.Reviewer.Get;
        internal override Func<string, bool, ReviewerDto> DalGetString => null;
        internal override Func<Expression<Func<IReviewer, bool>>, bool, List<ReviewerDto>> DalSelect => Models.Reviewer.Select;
        internal override Func<ReviewerDto, ReviewerDto> DalUpdate => Models.Reviewer.Update;
        internal override Func<long, bool, ReviewerDto> DalDeleteLong => Models.Reviewer.Delete;
        internal override Func<string, bool, ReviewerDto> DalDeleteString => null;
    }
}
