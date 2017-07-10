using System;
using System.Linq.Expressions;
using PAS.ResourceCenter.Library.DataAccess.Interfaces;
using PAS.ResourceCenter.Library.DataAccess.Models;
using PAS.ResourceCenter.Library.DataAccess.Responses;
using System.Collections.Generic;

// This file is generated. DO NOT MODIFY
namespace PAS.ResourceCenter.Library.DataAccess.DTO
{
    public partial class UserRolesDto : IUserRoles
    {
        public UserRolesDto(string byUserId = "")
        {
			Id = 0;
			RoleId = "";
			UserId = "";

        }

        public UserRolesDto(IUserRoles item, bool includeNavigation = false)
        {
            if (item != null)
                Assign(item, includeNavigation);
        }

		public Int64 Id{ get; set; }
		public String RoleId{ get; set; }
		public String UserId{ get; set; }

		public Models.Roles Role { get; set; }
		public Models.Users User { get; set; }


        internal void Assign(IUserRoles item, bool includeNavigation = false)
        {
            if (item == null)
                throw new ArgumentNullException(nameof(item));

            UserRoles.Assign(item, this, includeNavigation);
        }

        public static Response<UserRolesDto> Create(UserRolesDto item)
        {
            if (item == null)
            {
                return new Response<UserRolesDto>(StatusCodes.EXCEPTION);
            }

            return new DAL.UserRoles().Create(item);
        }

        public static Response<UserRolesDto> Get(long id, bool includeNavigation = false)
        {
            return new DAL.UserRoles().Get(id, includeNavigation);
        }

        public static Response<UserRolesDto> Select(Expression<Func<IUserRoles, bool>> whereClause = null, bool includeNavigation = false)
        {
            return new DAL.UserRoles().Select(whereClause, includeNavigation);
        }

        public static Response<UserRolesDto> Update(UserRolesDto item)
        {
            if (item == null)
            {
                return new Response<UserRolesDto>(StatusCodes.EXCEPTION);
            }

            return new DAL.UserRoles().Update(item);
        }

        public Response<UserRolesDto> Update()
        {
            return new DAL.UserRoles().Update(this);
        }

        public static Response<UserRolesDto> Delete(long id, bool cascade = false)
        {
            return new DAL.UserRoles().Delete(id, cascade);
        }
    }
}