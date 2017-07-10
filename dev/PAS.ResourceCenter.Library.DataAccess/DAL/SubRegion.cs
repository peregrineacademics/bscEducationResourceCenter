using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using PAS.ResourceCenter.Library.DataAccess.DTO;
using PAS.ResourceCenter.Library.DataAccess.Interfaces;
using PAS.ResourceCenter.Library.DataAccess.Models;

// This file is generated. DO NOT MODIFY
namespace PAS.ResourceCenter.Library.DataAccess.DAL
{
    internal class SubRegion : DalBase<SubRegion, SubRegionDto, ISubRegion>
    {
        internal override Func<SubRegionDto, SubRegionDto> DalCreate => Models.SubRegion.Create;
        internal override Func<long, bool, SubRegionDto> DalGetLong => Models.SubRegion.Get;
        internal override Func<string, bool, SubRegionDto> DalGetString => null;
        internal override Func<Expression<Func<ISubRegion, bool>>, bool, List<SubRegionDto>> DalSelect => Models.SubRegion.Select;
        internal override Func<SubRegionDto, SubRegionDto> DalUpdate => Models.SubRegion.Update;
        internal override Func<long, bool, SubRegionDto> DalDeleteLong => Models.SubRegion.Delete;
        internal override Func<string, bool, SubRegionDto> DalDeleteString => null;
    }
}
