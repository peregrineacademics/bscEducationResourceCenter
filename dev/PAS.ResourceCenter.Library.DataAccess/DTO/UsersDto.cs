using System;
using System.Linq.Expressions;
using PAS.ResourceCenter.Library.DataAccess.Interfaces;
using PAS.ResourceCenter.Library.DataAccess.Models;
using PAS.ResourceCenter.Library.DataAccess.Responses;
using System.Collections.Generic;

// This file is generated. DO NOT MODIFY
namespace PAS.ResourceCenter.Library.DataAccess.DTO
{
    public partial class UsersDto : IUsers
    {
        public UsersDto(string byUserId = "")
        {
			AccessFailedCount = 0;
			ConcurrencyStamp = "";
			DateCreated = DateTime.Now;
			Email = "";
			FirstName = "";
			Id = "";
			LastName = "";
			LastUpdated = DateTime.Now;
			LockoutEnd = null;
			MiddleName = "";
			NormalizedEmail = "";
			NormalizedUserName = "";
			PasswordHash = "";
			PhoneNumber = "";
			ScreenName = "";
			SecurityStamp = "";
			Title = "";
			UserName = "";

        }

        public UsersDto(IUsers item, bool includeNavigation = false)
        {
            if (item != null)
                Assign(item, includeNavigation);
        }

		public Int32 AccessFailedCount{ get; set; }
		public String ConcurrencyStamp{ get; set; }
		public DateTime DateCreated{ get; set; }
		public String Email{ get; set; }
		public Boolean EmailConfirmed{ get; set; }
		public String FirstName{ get; set; }
		public String Id{ get; set; }
		public Boolean IsEnabled{ get; set; }
		public String LastName{ get; set; }
		public DateTime LastUpdated{ get; set; }
		public Boolean LockoutEnabled{ get; set; }
		public DateTimeOffset? LockoutEnd{ get; set; }
		public String MiddleName{ get; set; }
		public String NormalizedEmail{ get; set; }
		public String NormalizedUserName{ get; set; }
		public String PasswordHash{ get; set; }
		public String PhoneNumber{ get; set; }
		public Boolean PhoneNumberConfirmed{ get; set; }
		public String ScreenName{ get; set; }
		public String SecurityStamp{ get; set; }
		public String Title{ get; set; }
		public Boolean TwoFactorEnabled{ get; set; }
		public String UserName{ get; set; }

		public ICollection<Issue> IssueCreatedByUser { get; set; }
		public ICollection<Issue> IssueUpdatedByUser { get; set; }
		public ICollection<Log> Log { get; set; }
		public ICollection<Review> ReviewCreatedByUser { get; set; }
		public ICollection<Reviewer> ReviewerUpdatedByUser { get; set; }
		public Models.Reviewer ReviewerUser { get; set; }
		public ICollection<Review> ReviewUpdatedByUser { get; set; }
		public ICollection<UserClaims> UserClaims { get; set; }
		public ICollection<UserLogins> UserLogins { get; set; }
		public ICollection<UserRoles> UserRoles { get; set; }


        internal void Assign(IUsers item, bool includeNavigation = false)
        {
            if (item == null)
                throw new ArgumentNullException(nameof(item));

            Users.Assign(item, this, includeNavigation);
        }

        public static Response<UsersDto> Create(UsersDto item)
        {
            if (item == null)
            {
                return new Response<UsersDto>(StatusCodes.EXCEPTION);
            }

            return new DAL.Users().Create(item);
        }

        public static Response<UsersDto> Get(string id, bool includeNavigation = false)
        {
            return new DAL.Users().Get(id, includeNavigation);
        }

        public static Response<UsersDto> Select(Expression<Func<IUsers, bool>> whereClause = null, bool includeNavigation = false)
        {
            return new DAL.Users().Select(whereClause, includeNavigation);
        }

        public static Response<UsersDto> Update(UsersDto item)
        {
            if (item == null)
            {
                return new Response<UsersDto>(StatusCodes.EXCEPTION);
            }

            return new DAL.Users().Update(item);
        }

        public Response<UsersDto> Update()
        {
            return new DAL.Users().Update(this);
        }

        public static Response<UsersDto> Delete(string id, bool cascade = false)
        {
            return new DAL.Users().Delete(id, cascade);
        }
    }
}