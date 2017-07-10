using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using PAS.ResourceCenter.Library.DataAccess.DTO;
using PAS.ResourceCenter.Library.DataAccess.Interfaces;
using PAS.ResourceCenter.Library.DataAccess.Models;

// This file is generated. DO NOT MODIFY
namespace PAS.ResourceCenter.Library.DataAccess.DAL
{
    internal class RoleClaims : DalBase<RoleClaims, RoleClaimsDto, IRoleClaims>
    {
        internal override Func<RoleClaimsDto, RoleClaimsDto> DalCreate => Models.RoleClaims.Create;
        internal override Func<long, bool, RoleClaimsDto> DalGetLong => Models.RoleClaims.Get;
        internal override Func<string, bool, RoleClaimsDto> DalGetString => null;
        internal override Func<Expression<Func<IRoleClaims, bool>>, bool, List<RoleClaimsDto>> DalSelect => Models.RoleClaims.Select;
        internal override Func<RoleClaimsDto, RoleClaimsDto> DalUpdate => Models.RoleClaims.Update;
        internal override Func<long, bool, RoleClaimsDto> DalDeleteLong => Models.RoleClaims.Delete;
        internal override Func<string, bool, RoleClaimsDto> DalDeleteString => null;
    }
}
