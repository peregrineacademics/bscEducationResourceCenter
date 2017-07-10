using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using PAS.ResourceCenter.Library.DataAccess.DTO;
using PAS.ResourceCenter.Library.DataAccess.Interfaces;
using PAS.ResourceCenter.Library.DataAccess.Models;

// This file is generated. DO NOT MODIFY
namespace PAS.ResourceCenter.Library.DataAccess.DAL
{
    internal class Issue : DalBase<Issue, IssueDto, IIssue>
    {
        internal override Func<IssueDto, IssueDto> DalCreate => Models.Issue.Create;
        internal override Func<long, bool, IssueDto> DalGetLong => Models.Issue.Get;
        internal override Func<string, bool, IssueDto> DalGetString => null;
        internal override Func<Expression<Func<IIssue, bool>>, bool, List<IssueDto>> DalSelect => Models.Issue.Select;
        internal override Func<IssueDto, IssueDto> DalUpdate => Models.Issue.Update;
        internal override Func<long, bool, IssueDto> DalDeleteLong => Models.Issue.Delete;
        internal override Func<string, bool, IssueDto> DalDeleteString => null;
    }
}
