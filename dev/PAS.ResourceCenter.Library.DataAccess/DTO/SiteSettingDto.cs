using System;
using System.Linq.Expressions;
using PAS.ResourceCenter.Library.DataAccess.Interfaces;
using PAS.ResourceCenter.Library.DataAccess.Models;
using PAS.ResourceCenter.Library.DataAccess.Responses;
/* Insert Collections */

// This file is generated. DO NOT MODIFY
namespace PAS.ResourceCenter.Library.DataAccess.DTO
{
    public partial class SiteSettingDto : ISiteSetting
    {
        public SiteSettingDto(string byUserId = "")
        {
			DisplayName = "";
			Id = 0;
			Name = "";
			Notes = "";
			Value = "";

        }

        public SiteSettingDto(ISiteSetting item, bool includeNavigation = false)
        {
            if (item != null)
                Assign(item, includeNavigation);
        }

		public String DisplayName{ get; set; }
		public Int64 Id{ get; set; }
		public Boolean IsBoolean{ get; set; }
		public Boolean IsCollection{ get; set; }
		public Boolean IsPassword{ get; set; }
		public String Name{ get; set; }
		public String Notes{ get; set; }
		public String Value{ get; set; }


        internal void Assign(ISiteSetting item, bool includeNavigation = false)
        {
            if (item == null)
                throw new ArgumentNullException(nameof(item));

            SiteSetting.Assign(item, this, includeNavigation);
        }

        public static Response<SiteSettingDto> Create(SiteSettingDto item)
        {
            if (item == null)
            {
                return new Response<SiteSettingDto>(StatusCodes.EXCEPTION);
            }

            return new DAL.SiteSetting().Create(item);
        }

        public static Response<SiteSettingDto> Get(long id, bool includeNavigation = false)
        {
            return new DAL.SiteSetting().Get(id, includeNavigation);
        }

        public static Response<SiteSettingDto> Select(Expression<Func<ISiteSetting, bool>> whereClause = null, bool includeNavigation = false)
        {
            return new DAL.SiteSetting().Select(whereClause, includeNavigation);
        }

        public static Response<SiteSettingDto> Update(SiteSettingDto item)
        {
            if (item == null)
            {
                return new Response<SiteSettingDto>(StatusCodes.EXCEPTION);
            }

            return new DAL.SiteSetting().Update(item);
        }

        public Response<SiteSettingDto> Update()
        {
            return new DAL.SiteSetting().Update(this);
        }

        public static Response<SiteSettingDto> Delete(long id, bool cascade = false)
        {
            return new DAL.SiteSetting().Delete(id, cascade);
        }
    }
}