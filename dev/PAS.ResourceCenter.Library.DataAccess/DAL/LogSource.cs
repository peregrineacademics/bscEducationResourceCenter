using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using PAS.ResourceCenter.Library.DataAccess.DTO;
using PAS.ResourceCenter.Library.DataAccess.Interfaces;
using PAS.ResourceCenter.Library.DataAccess.Models;

// This file is generated. DO NOT MODIFY
namespace PAS.ResourceCenter.Library.DataAccess.DAL
{
    internal class LogSource : DalBase<LogSource, LogSourceDto, ILogSource>
    {
        internal override Func<LogSourceDto, LogSourceDto> DalCreate => Models.LogSource.Create;
        internal override Func<long, bool, LogSourceDto> DalGetLong => Models.LogSource.Get;
        internal override Func<string, bool, LogSourceDto> DalGetString => null;
        internal override Func<Expression<Func<ILogSource, bool>>, bool, List<LogSourceDto>> DalSelect => Models.LogSource.Select;
        internal override Func<LogSourceDto, LogSourceDto> DalUpdate => Models.LogSource.Update;
        internal override Func<long, bool, LogSourceDto> DalDeleteLong => Models.LogSource.Delete;
        internal override Func<string, bool, LogSourceDto> DalDeleteString => null;
    }
}
