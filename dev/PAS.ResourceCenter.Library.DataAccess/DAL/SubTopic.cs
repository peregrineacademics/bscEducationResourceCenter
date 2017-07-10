using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using PAS.ResourceCenter.Library.DataAccess.DTO;
using PAS.ResourceCenter.Library.DataAccess.Interfaces;
using PAS.ResourceCenter.Library.DataAccess.Models;

// This file is generated. DO NOT MODIFY
namespace PAS.ResourceCenter.Library.DataAccess.DAL
{
    internal class SubTopic : DalBase<SubTopic, SubTopicDto, ISubTopic>
    {
        internal override Func<SubTopicDto, SubTopicDto> DalCreate => Models.SubTopic.Create;
        internal override Func<long, bool, SubTopicDto> DalGetLong => Models.SubTopic.Get;
        internal override Func<string, bool, SubTopicDto> DalGetString => null;
        internal override Func<Expression<Func<ISubTopic, bool>>, bool, List<SubTopicDto>> DalSelect => Models.SubTopic.Select;
        internal override Func<SubTopicDto, SubTopicDto> DalUpdate => Models.SubTopic.Update;
        internal override Func<long, bool, SubTopicDto> DalDeleteLong => Models.SubTopic.Delete;
        internal override Func<string, bool, SubTopicDto> DalDeleteString => null;
    }
}
