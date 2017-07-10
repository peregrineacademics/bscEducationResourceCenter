using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using PAS.ResourceCenter.Library.DataAccess.DTO;
using PAS.ResourceCenter.Library.DataAccess.Interfaces;
using PAS.ResourceCenter.Library.DataAccess.Models;

// This file is generated. DO NOT MODIFY
namespace PAS.ResourceCenter.Library.DataAccess.DAL
{
    internal class Competency : DalBase<Competency, CompetencyDto, ICompetency>
    {
        internal override Func<CompetencyDto, CompetencyDto> DalCreate => Models.Competency.Create;
        internal override Func<long, bool, CompetencyDto> DalGetLong => Models.Competency.Get;
        internal override Func<string, bool, CompetencyDto> DalGetString => null;
        internal override Func<Expression<Func<ICompetency, bool>>, bool, List<CompetencyDto>> DalSelect => Models.Competency.Select;
        internal override Func<CompetencyDto, CompetencyDto> DalUpdate => Models.Competency.Update;
        internal override Func<long, bool, CompetencyDto> DalDeleteLong => Models.Competency.Delete;
        internal override Func<string, bool, CompetencyDto> DalDeleteString => null;
    }
}
