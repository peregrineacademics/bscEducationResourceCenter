using System;
using System.Linq.Expressions;
using PAS.ResourceCenter.Library.DataAccess.Interfaces;
using PAS.ResourceCenter.Library.DataAccess.Models;
using PAS.ResourceCenter.Library.DataAccess.Responses;
using System.Collections.Generic;

// This file is generated. DO NOT MODIFY
namespace PAS.ResourceCenter.Library.DataAccess.DTO
{
    public partial class RolesDto : IRoles
    {
        public RolesDto(string byUserId = "")
        {
			ConcurrencyStamp = "";
			Id = "";
			Name = "";
			NormalizedName = "";

        }

        public RolesDto(IRoles item, bool includeNavigation = false)
        {
            if (item != null)
                Assign(item, includeNavigation);
        }

		public String ConcurrencyStamp{ get; set; }
		public String Id{ get; set; }
		public String Name{ get; set; }
		public String NormalizedName{ get; set; }

		public ICollection<RoleClaims> RoleClaims { get; set; }
		public ICollection<UserRoles> UserRoles { get; set; }


        internal void Assign(IRoles item, bool includeNavigation = false)
        {
            if (item == null)
                throw new ArgumentNullException(nameof(item));

            Roles.Assign(item, this, includeNavigation);
        }

        public static Response<RolesDto> Create(RolesDto item)
        {
            if (item == null)
            {
                return new Response<RolesDto>(StatusCodes.EXCEPTION);
            }

            return new DAL.Roles().Create(item);
        }

        public static Response<RolesDto> Get(string id, bool includeNavigation = false)
        {
            return new DAL.Roles().Get(id, includeNavigation);
        }

        public static Response<RolesDto> Select(Expression<Func<IRoles, bool>> whereClause = null, bool includeNavigation = false)
        {
            return new DAL.Roles().Select(whereClause, includeNavigation);
        }

        public static Response<RolesDto> Update(RolesDto item)
        {
            if (item == null)
            {
                return new Response<RolesDto>(StatusCodes.EXCEPTION);
            }

            return new DAL.Roles().Update(item);
        }

        public Response<RolesDto> Update()
        {
            return new DAL.Roles().Update(this);
        }

        public static Response<RolesDto> Delete(string id, bool cascade = false)
        {
            return new DAL.Roles().Delete(id, cascade);
        }
    }
}