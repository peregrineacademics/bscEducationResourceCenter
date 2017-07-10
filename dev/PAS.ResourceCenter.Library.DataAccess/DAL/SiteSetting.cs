using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using PAS.ResourceCenter.Library.DataAccess.DTO;
using PAS.ResourceCenter.Library.DataAccess.Interfaces;
using PAS.ResourceCenter.Library.DataAccess.Models;

// This file is generated. DO NOT MODIFY
namespace PAS.ResourceCenter.Library.DataAccess.DAL
{
    internal class SiteSetting : DalBase<SiteSetting, SiteSettingDto, ISiteSetting>
    {
        internal override Func<SiteSettingDto, SiteSettingDto> DalCreate => Models.SiteSetting.Create;
        internal override Func<long, bool, SiteSettingDto> DalGetLong => Models.SiteSetting.Get;
        internal override Func<string, bool, SiteSettingDto> DalGetString => null;
        internal override Func<Expression<Func<ISiteSetting, bool>>, bool, List<SiteSettingDto>> DalSelect => Models.SiteSetting.Select;
        internal override Func<SiteSettingDto, SiteSettingDto> DalUpdate => Models.SiteSetting.Update;
        internal override Func<long, bool, SiteSettingDto> DalDeleteLong => Models.SiteSetting.Delete;
        internal override Func<string, bool, SiteSettingDto> DalDeleteString => null;
    }
}
