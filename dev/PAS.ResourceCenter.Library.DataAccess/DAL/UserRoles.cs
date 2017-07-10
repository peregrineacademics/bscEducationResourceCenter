using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using PAS.ResourceCenter.Library.DataAccess.DTO;
using PAS.ResourceCenter.Library.DataAccess.Interfaces;
using PAS.ResourceCenter.Library.DataAccess.Models;

// This file is generated. DO NOT MODIFY
namespace PAS.ResourceCenter.Library.DataAccess.DAL
{
    internal class UserRoles : DalBase<UserRoles, UserRolesDto, IUserRoles>
    {
        internal override Func<UserRolesDto, UserRolesDto> DalCreate => Models.UserRoles.Create;
        internal override Func<long, bool, UserRolesDto> DalGetLong => Models.UserRoles.Get;
        internal override Func<string, bool, UserRolesDto> DalGetString => null;
        internal override Func<Expression<Func<IUserRoles, bool>>, bool, List<UserRolesDto>> DalSelect => Models.UserRoles.Select;
        internal override Func<UserRolesDto, UserRolesDto> DalUpdate => Models.UserRoles.Update;
        internal override Func<long, bool, UserRolesDto> DalDeleteLong => Models.UserRoles.Delete;
        internal override Func<string, bool, UserRolesDto> DalDeleteString => null;
    }
}
