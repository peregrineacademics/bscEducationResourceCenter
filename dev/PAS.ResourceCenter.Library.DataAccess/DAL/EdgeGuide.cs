using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using PAS.ResourceCenter.Library.DataAccess.DTO;
using PAS.ResourceCenter.Library.DataAccess.Interfaces;
using PAS.ResourceCenter.Library.DataAccess.Models;

// This file is generated. DO NOT MODIFY
namespace PAS.ResourceCenter.Library.DataAccess.DAL
{
    internal class EdgeGuide : DalBase<EdgeGuide, EdgeGuideDto, IEdgeGuide>
    {
        internal override Func<EdgeGuideDto, EdgeGuideDto> DalCreate => Models.EdgeGuide.Create;
        internal override Func<long, bool, EdgeGuideDto> DalGetLong => Models.EdgeGuide.Get;
        internal override Func<string, bool, EdgeGuideDto> DalGetString => null;
        internal override Func<Expression<Func<IEdgeGuide, bool>>, bool, List<EdgeGuideDto>> DalSelect => Models.EdgeGuide.Select;
        internal override Func<EdgeGuideDto, EdgeGuideDto> DalUpdate => Models.EdgeGuide.Update;
        internal override Func<long, bool, EdgeGuideDto> DalDeleteLong => Models.EdgeGuide.Delete;
        internal override Func<string, bool, EdgeGuideDto> DalDeleteString => null;
    }
}
