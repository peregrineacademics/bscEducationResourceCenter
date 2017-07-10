using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using PAS.ResourceCenter.Library.DataAccess.DTO;
using PAS.ResourceCenter.Library.DataAccess.Interfaces;
using PAS.ResourceCenter.Library.DataAccess.Models;

// This file is generated. DO NOT MODIFY
namespace PAS.ResourceCenter.Library.DataAccess.DAL
{
    internal class Discipline : DalBase<Discipline, DisciplineDto, IDiscipline>
    {
        internal override Func<DisciplineDto, DisciplineDto> DalCreate => Models.Discipline.Create;
        internal override Func<long, bool, DisciplineDto> DalGetLong => Models.Discipline.Get;
        internal override Func<string, bool, DisciplineDto> DalGetString => null;
        internal override Func<Expression<Func<IDiscipline, bool>>, bool, List<DisciplineDto>> DalSelect => Models.Discipline.Select;
        internal override Func<DisciplineDto, DisciplineDto> DalUpdate => Models.Discipline.Update;
        internal override Func<long, bool, DisciplineDto> DalDeleteLong => Models.Discipline.Delete;
        internal override Func<string, bool, DisciplineDto> DalDeleteString => null;
    }
}
