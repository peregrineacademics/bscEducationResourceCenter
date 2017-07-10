using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using PAS.ResourceCenter.Library.DataAccess.DTO;
using PAS.ResourceCenter.Library.DataAccess.Interfaces;
using PAS.ResourceCenter.Library.DataAccess.Models;

// This file is generated. DO NOT MODIFY
namespace PAS.ResourceCenter.Library.DataAccess.DAL
{
    internal class Log : DalBase<Log, LogDto, ILog>
    {
        internal override Func<LogDto, LogDto> DalCreate => Models.Log.Create;
        internal override Func<long, bool, LogDto> DalGetLong => Models.Log.Get;
        internal override Func<string, bool, LogDto> DalGetString => null;
        internal override Func<Expression<Func<ILog, bool>>, bool, List<LogDto>> DalSelect => Models.Log.Select;
        internal override Func<LogDto, LogDto> DalUpdate => Models.Log.Update;
        internal override Func<long, bool, LogDto> DalDeleteLong => Models.Log.Delete;
        internal override Func<string, bool, LogDto> DalDeleteString => null;
    }
}
