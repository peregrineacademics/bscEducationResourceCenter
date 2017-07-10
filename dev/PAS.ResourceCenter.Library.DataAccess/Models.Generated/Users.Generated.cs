// Generated file do not modify this can be overwritten.
// To extend this class use the template file found in models.custom folder an make a copy using the class name.
using PAS.ResourceCenter.Library.DataAccess.DTO;
using PAS.ResourceCenter.Library.DataAccess.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

// This file is generated. DO NOT MODIFY
namespace PAS.ResourceCenter.Library.DataAccess.Models
{
    public partial class Users : IUsers
    {
        internal static void Assign(IUsers source, IUsers destination, bool includeNavigation = false)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));
            if (destination == null) throw new ArgumentNullException(nameof(destination));

			destination.AccessFailedCount = source.AccessFailedCount;
			destination.ConcurrencyStamp = source.ConcurrencyStamp;
			destination.DateCreated = source.DateCreated;
			destination.Email = source.Email;
			destination.EmailConfirmed = source.EmailConfirmed;
			destination.FirstName = source.FirstName;
			destination.Id = source.Id;
			destination.IsEnabled = source.IsEnabled;
			destination.LastName = source.LastName;
			destination.LastUpdated = source.LastUpdated;
			destination.LockoutEnabled = source.LockoutEnabled;
			destination.LockoutEnd = source.LockoutEnd;
			destination.MiddleName = source.MiddleName;
			destination.NormalizedEmail = source.NormalizedEmail;
			destination.NormalizedUserName = source.NormalizedUserName;
			destination.PasswordHash = source.PasswordHash;
			destination.PhoneNumber = source.PhoneNumber;
			destination.PhoneNumberConfirmed = source.PhoneNumberConfirmed;
			destination.ScreenName = source.ScreenName;
			destination.SecurityStamp = source.SecurityStamp;
			destination.Title = source.Title;
			destination.TwoFactorEnabled = source.TwoFactorEnabled;
			destination.UserName = source.UserName;

			if (includeNavigation)
			{
				destination.IssueCreatedByUser = source.IssueCreatedByUser;
				destination.IssueUpdatedByUser = source.IssueUpdatedByUser;
				destination.Log = source.Log;
				destination.ReviewCreatedByUser = source.ReviewCreatedByUser;
				destination.ReviewerUpdatedByUser = source.ReviewerUpdatedByUser;
				destination.ReviewerUser = source.ReviewerUser;
				destination.ReviewUpdatedByUser = source.ReviewUpdatedByUser;
				destination.UserClaims = source.UserClaims;
				destination.UserLogins = source.UserLogins;
				destination.UserRoles = source.UserRoles;
			}
        }

        internal static UsersDto Create(UsersDto itemDto)
        {
            var context = Transaction.GetContext();

            var dbItem = new Users();
            dbItem.Assign(itemDto);
            context.Users.Add(dbItem);
            context.SaveChanges();

            itemDto.Assign(dbItem);

            Transaction.DisposeContext(context);

            return itemDto;
        }

        internal static UsersDto Get(string id, bool includeNavigation = false)
        {
            using (var context = Transaction.GetContext(true))
            {
                IUsers dbItem;
                if (includeNavigation)
                    dbItem = context.Users
								.Include(n=>n.IssueCreatedByUser)
								.Include(n=>n.IssueUpdatedByUser)
								.Include(n=>n.Log)
								.Include(n=>n.ReviewCreatedByUser)
								.Include(n=>n.ReviewerUpdatedByUser)
								.Include(n=>n.ReviewerUser)
								.Include(n=>n.ReviewUpdatedByUser)
								.Include(n=>n.UserClaims)
								.Include(n=>n.UserLogins)
								.Include(n=>n.UserRoles).FirstOrDefault(p => p.Id == id);                
                else
                    dbItem = context.Users.FirstOrDefault(p => p.Id == id);

                return (dbItem != null) ? new UsersDto(dbItem, includeNavigation) : null;
            }
        }

        internal static List<UsersDto> Select(Expression<Func<IUsers, bool>> whereClause = null, bool includeNavigation = false)
        {
            using (var context = Transaction.GetContext(true))
            {
                IQueryable<IUsers> dbItems;

                var results = new List<UsersDto>();

                if (whereClause == null)
                    return Select(includeNavigation);

                if (includeNavigation)
                    dbItems = context.Users.Where(whereClause)
								.Include(n=>n.IssueCreatedByUser)
								.Include(n=>n.IssueUpdatedByUser)
								.Include(n=>n.Log)
								.Include(n=>n.ReviewCreatedByUser)
								.Include(n=>n.ReviewerUpdatedByUser)
								.Include(n=>n.ReviewerUser)
								.Include(n=>n.ReviewUpdatedByUser)
								.Include(n=>n.UserClaims)
								.Include(n=>n.UserLogins)
								.Include(n=>n.UserRoles);
                else
                    dbItems = context.Users.Where(whereClause);

                if (dbItems.Any())
                {
                    dbItems.ToList()
                        .ForEach(o =>
                        {
                            var dto = new UsersDto("Id will be filled in the Assign statement");
                            dto.Assign(o, includeNavigation);
                            results.Add(dto);
                        });
                }
                return results;
            }
        }

        internal static List<UsersDto> Select(bool includeNavigation = false)
        {
            using (var context = Transaction.GetContext(true))
            {
                IQueryable<IUsers> dbItems;
                var results = new List<UsersDto>();

                if (includeNavigation)
                    dbItems = context.Users
								.Include(n=>n.IssueCreatedByUser)
								.Include(n=>n.IssueUpdatedByUser)
								.Include(n=>n.Log)
								.Include(n=>n.ReviewCreatedByUser)
								.Include(n=>n.ReviewerUpdatedByUser)
								.Include(n=>n.ReviewerUser)
								.Include(n=>n.ReviewUpdatedByUser)
								.Include(n=>n.UserClaims)
								.Include(n=>n.UserLogins)
								.Include(n=>n.UserRoles);
                else
                    dbItems = context.Users;

                if (dbItems.Any())
                    dbItems.ToList()
                        .ForEach(o =>
                        {
                            var dto = new UsersDto("Id will be filled in the Assign statement");
                            dto.Assign(o, includeNavigation);
                            results.Add(dto);
                        });
                return results;
            }
        }

        internal static UsersDto Update(UsersDto itemDto)
        {
            var context = Transaction.GetContext();

            var id = itemDto.Id;
            var dbItem = context.Users.FirstOrDefault(o => o.Id == id);
            if (dbItem != null)
            {
                dbItem.Assign(itemDto);
                context.SaveChanges();
                itemDto.Assign(dbItem);
            }

            Transaction.DisposeContext(context);
            return itemDto;
        }

        internal static UsersDto Delete(string id, bool cascade = false)
        {
            var context = Transaction.GetContext();

            if (cascade)
            {
                using (var transaction = context.Database.BeginTransaction())
                {
                    var dbItem = context.Users
									.Include(n=>n.IssueCreatedByUser)
									.Include(n=>n.IssueUpdatedByUser)
									.Include(n=>n.Log)
									.Include(n=>n.ReviewCreatedByUser)
									.Include(n=>n.ReviewerUpdatedByUser)
									.Include(n=>n.ReviewerUser)
									.Include(n=>n.ReviewUpdatedByUser)
									.Include(n=>n.UserClaims)
									.Include(n=>n.UserLogins)
									.Include(n=>n.UserRoles).FirstOrDefault(p => p.Id == id);
                    if (dbItem != null)
                    {   
						if (dbItem.IssueCreatedByUser.Count > 0)
							context.Issue.RemoveRange(dbItem.IssueCreatedByUser);
						if (dbItem.IssueUpdatedByUser.Count > 0)
							context.Issue.RemoveRange(dbItem.IssueUpdatedByUser);
						if (dbItem.Log.Count > 0)
							context.Log.RemoveRange(dbItem.Log);
						if (dbItem.ReviewCreatedByUser.Count > 0)
							context.Review.RemoveRange(dbItem.ReviewCreatedByUser);
						if (dbItem.ReviewerUpdatedByUser.Count > 0)
							context.Reviewer.RemoveRange(dbItem.ReviewerUpdatedByUser);
						if (dbItem.ReviewerUser != null)
							context.Reviewer.RemoveRange(dbItem.ReviewerUser);
						if (dbItem.ReviewUpdatedByUser.Count > 0)
							context.Review.RemoveRange(dbItem.ReviewUpdatedByUser);
						if (dbItem.UserClaims.Count > 0)
							context.UserClaims.RemoveRange(dbItem.UserClaims);
						if (dbItem.UserLogins.Count > 0)
							context.UserLogins.RemoveRange(dbItem.UserLogins);
						if (dbItem.UserRoles.Count > 0)
							context.UserRoles.RemoveRange(dbItem.UserRoles);

                        context.Users.Remove(dbItem);
                        context.SaveChanges();

                        transaction.Commit();
                    }
                }
            }
            else
            {
                var dbItem = context.Users.FirstOrDefault(p => p.Id == id);
                if (dbItem != null)
                {
                    context.Users.Remove(dbItem);
                    context.SaveChanges();
                }
            }

            Transaction.DisposeContext(context);

            return null;
        }
    }

    internal static class UsersExtensions
    {
        internal static void Assign(this Users destination, IUsers source, bool includeNavigation = false)
        {
            Users.Assign(source, destination, includeNavigation);
        }
    }
}