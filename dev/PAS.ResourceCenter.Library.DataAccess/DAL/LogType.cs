using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using PAS.ResourceCenter.Library.DataAccess.DTO;
using PAS.ResourceCenter.Library.DataAccess.Interfaces;
using PAS.ResourceCenter.Library.DataAccess.Models;

// This file is generated. DO NOT MODIFY
namespace PAS.ResourceCenter.Library.DataAccess.DAL
{
    internal class LogType : DalBase<LogType, LogTypeDto, ILogType>
    {
        internal override Func<LogTypeDto, LogTypeDto> DalCreate => Models.LogType.Create;
        internal override Func<long, bool, LogTypeDto> DalGetLong => Models.LogType.Get;
        internal override Func<string, bool, LogTypeDto> DalGetString => null;
        internal override Func<Expression<Func<ILogType, bool>>, bool, List<LogTypeDto>> DalSelect => Models.LogType.Select;
        internal override Func<LogTypeDto, LogTypeDto> DalUpdate => Models.LogType.Update;
        internal override Func<long, bool, LogTypeDto> DalDeleteLong => Models.LogType.Delete;
        internal override Func<string, bool, LogTypeDto> DalDeleteString => null;
    }
}
