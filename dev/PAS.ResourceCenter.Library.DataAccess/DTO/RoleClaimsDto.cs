using System;
using System.Linq.Expressions;
using PAS.ResourceCenter.Library.DataAccess.Interfaces;
using PAS.ResourceCenter.Library.DataAccess.Models;
using PAS.ResourceCenter.Library.DataAccess.Responses;
using System.Collections.Generic;

// This file is generated. DO NOT MODIFY
namespace PAS.ResourceCenter.Library.DataAccess.DTO
{
    public partial class RoleClaimsDto : IRoleClaims
    {
        public RoleClaimsDto(string byUserId = "")
        {
			ClaimType = "";
			ClaimValue = "";
			Id = 0;
			RoleId = "";

        }

        public RoleClaimsDto(IRoleClaims item, bool includeNavigation = false)
        {
            if (item != null)
                Assign(item, includeNavigation);
        }

		public String ClaimType{ get; set; }
		public String ClaimValue{ get; set; }
		public Int32 Id{ get; set; }
		public String RoleId{ get; set; }

		public Models.Roles Role { get; set; }


        internal void Assign(IRoleClaims item, bool includeNavigation = false)
        {
            if (item == null)
                throw new ArgumentNullException(nameof(item));

            RoleClaims.Assign(item, this, includeNavigation);
        }

        public static Response<RoleClaimsDto> Create(RoleClaimsDto item)
        {
            if (item == null)
            {
                return new Response<RoleClaimsDto>(StatusCodes.EXCEPTION);
            }

            return new DAL.RoleClaims().Create(item);
        }

        public static Response<RoleClaimsDto> Get(long id, bool includeNavigation = false)
        {
            return new DAL.RoleClaims().Get(id, includeNavigation);
        }

        public static Response<RoleClaimsDto> Select(Expression<Func<IRoleClaims, bool>> whereClause = null, bool includeNavigation = false)
        {
            return new DAL.RoleClaims().Select(whereClause, includeNavigation);
        }

        public static Response<RoleClaimsDto> Update(RoleClaimsDto item)
        {
            if (item == null)
            {
                return new Response<RoleClaimsDto>(StatusCodes.EXCEPTION);
            }

            return new DAL.RoleClaims().Update(item);
        }

        public Response<RoleClaimsDto> Update()
        {
            return new DAL.RoleClaims().Update(this);
        }

        public static Response<RoleClaimsDto> Delete(long id, bool cascade = false)
        {
            return new DAL.RoleClaims().Delete(id, cascade);
        }
    }
}