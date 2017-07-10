using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using PAS.ResourceCenter.Library.DataAccess.DTO;
using PAS.ResourceCenter.Library.DataAccess.Interfaces;
using PAS.ResourceCenter.Library.DataAccess.Models;

// This file is generated. DO NOT MODIFY
namespace PAS.ResourceCenter.Library.DataAccess.DAL
{
    internal class Sector : DalBase<Sector, SectorDto, ISector>
    {
        internal override Func<SectorDto, SectorDto> DalCreate => Models.Sector.Create;
        internal override Func<long, bool, SectorDto> DalGetLong => Models.Sector.Get;
        internal override Func<string, bool, SectorDto> DalGetString => null;
        internal override Func<Expression<Func<ISector, bool>>, bool, List<SectorDto>> DalSelect => Models.Sector.Select;
        internal override Func<SectorDto, SectorDto> DalUpdate => Models.Sector.Update;
        internal override Func<long, bool, SectorDto> DalDeleteLong => Models.Sector.Delete;
        internal override Func<string, bool, SectorDto> DalDeleteString => null;
    }
}
