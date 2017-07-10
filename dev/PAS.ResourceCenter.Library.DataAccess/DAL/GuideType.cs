using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using PAS.ResourceCenter.Library.DataAccess.DTO;
using PAS.ResourceCenter.Library.DataAccess.Interfaces;
using PAS.ResourceCenter.Library.DataAccess.Models;

// This file is generated. DO NOT MODIFY
namespace PAS.ResourceCenter.Library.DataAccess.DAL
{
    internal class GuideType : DalBase<GuideType, GuideTypeDto, IGuideType>
    {
        internal override Func<GuideTypeDto, GuideTypeDto> DalCreate => Models.GuideType.Create;
        internal override Func<long, bool, GuideTypeDto> DalGetLong => Models.GuideType.Get;
        internal override Func<string, bool, GuideTypeDto> DalGetString => null;
        internal override Func<Expression<Func<IGuideType, bool>>, bool, List<GuideTypeDto>> DalSelect => Models.GuideType.Select;
        internal override Func<GuideTypeDto, GuideTypeDto> DalUpdate => Models.GuideType.Update;
        internal override Func<long, bool, GuideTypeDto> DalDeleteLong => Models.GuideType.Delete;
        internal override Func<string, bool, GuideTypeDto> DalDeleteString => null;
    }
}
