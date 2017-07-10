using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using PAS.ResourceCenter.Library.DataAccess.DTO;
using PAS.ResourceCenter.Library.DataAccess.Interfaces;
using PAS.ResourceCenter.Library.DataAccess.Models;

// This file is generated. DO NOT MODIFY
namespace PAS.ResourceCenter.Library.DataAccess.DAL
{
    internal class Region : DalBase<Region, RegionDto, IRegion>
    {
        internal override Func<RegionDto, RegionDto> DalCreate => Models.Region.Create;
        internal override Func<long, bool, RegionDto> DalGetLong => Models.Region.Get;
        internal override Func<string, bool, RegionDto> DalGetString => null;
        internal override Func<Expression<Func<IRegion, bool>>, bool, List<RegionDto>> DalSelect => Models.Region.Select;
        internal override Func<RegionDto, RegionDto> DalUpdate => Models.Region.Update;
        internal override Func<long, bool, RegionDto> DalDeleteLong => Models.Region.Delete;
        internal override Func<string, bool, RegionDto> DalDeleteString => null;
    }
}
