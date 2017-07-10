using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using dbNameSpace.DTO;
using dbNameSpace.Interfaces;
using dbNameSpace.Models;

// This file is generated. DO NOT MODIFY
namespace dbNameSpace.DAL
{
    internal class Object : DalBase<Object, ObjectDto, IObject>
    {
        internal override Func<ObjectDto, ObjectDto> DalCreate => Models.Object.Create;
        internal override Func<long, bool, ObjectDto> DalGetLong => Models.Object.Get;
        internal override Func<string, bool, ObjectDto> DalGetString => Models.Object.Get;
        internal override Func<Expression<Func<IObject, bool>>, bool, List<ObjectDto>> DalSelect => Models.Object.Select;
        internal override Func<ObjectDto, ObjectDto> DalUpdate => Models.Object.Update;
        internal override Func<long, bool, ObjectDto> DalDeleteLong => Models.Object.Delete;
        internal override Func<string, bool, ObjectDto> DalDeleteString => Models.Object.Delete;
    }
}
