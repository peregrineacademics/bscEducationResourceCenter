using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using PAS.ResourceCenter.Library.DataAccess.DTO;
using PAS.ResourceCenter.Library.DataAccess.Interfaces;
using PAS.ResourceCenter.Library.DataAccess.Models;

// This file is generated. DO NOT MODIFY
namespace PAS.ResourceCenter.Library.DataAccess.DAL
{
    internal class Users : DalBase<Users, UsersDto, IUsers>
    {
        internal override Func<UsersDto, UsersDto> DalCreate => Models.Users.Create;
        internal override Func<long, bool, UsersDto> DalGetLong => null;
        internal override Func<string, bool, UsersDto> DalGetString => Models.Users.Get;
        internal override Func<Expression<Func<IUsers, bool>>, bool, List<UsersDto>> DalSelect => Models.Users.Select;
        internal override Func<UsersDto, UsersDto> DalUpdate => Models.Users.Update;
        internal override Func<long, bool, UsersDto> DalDeleteLong => null;
        internal override Func<string, bool, UsersDto> DalDeleteString => Models.Users.Delete;
    }
}
