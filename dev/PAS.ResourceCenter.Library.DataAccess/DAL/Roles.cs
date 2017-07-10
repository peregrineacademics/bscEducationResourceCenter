using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using PAS.ResourceCenter.Library.DataAccess.DTO;
using PAS.ResourceCenter.Library.DataAccess.Interfaces;
using PAS.ResourceCenter.Library.DataAccess.Models;

// This file is generated. DO NOT MODIFY
namespace PAS.ResourceCenter.Library.DataAccess.DAL
{
    internal class Roles : DalBase<Roles, RolesDto, IRoles>
    {
        internal override Func<RolesDto, RolesDto> DalCreate => Models.Roles.Create;
        internal override Func<long, bool, RolesDto> DalGetLong => null;
        internal override Func<string, bool, RolesDto> DalGetString => Models.Roles.Get;
        internal override Func<Expression<Func<IRoles, bool>>, bool, List<RolesDto>> DalSelect => Models.Roles.Select;
        internal override Func<RolesDto, RolesDto> DalUpdate => Models.Roles.Update;
        internal override Func<long, bool, RolesDto> DalDeleteLong => null;
        internal override Func<string, bool, RolesDto> DalDeleteString => Models.Roles.Delete;
    }
}
