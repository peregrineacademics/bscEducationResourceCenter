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
    public partial class UserRoles : IUserRoles
    {
        internal static void Assign(IUserRoles source, IUserRoles destination, bool includeNavigation = false)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));
            if (destination == null) throw new ArgumentNullException(nameof(destination));

			destination.Id = source.Id;
			destination.RoleId = source.RoleId;
			destination.UserId = source.UserId;

			if (includeNavigation)
			{
				destination.Role = source.Role;
				destination.User = source.User;
			}
        }

        internal static UserRolesDto Create(UserRolesDto itemDto)
        {
            var context = Transaction.GetContext();

            var dbItem = new UserRoles();
            dbItem.Assign(itemDto);
            context.UserRoles.Add(dbItem);
            context.SaveChanges();

            itemDto.Assign(dbItem);

            Transaction.DisposeContext(context);

            return itemDto;
        }

        internal static UserRolesDto Get(long id, bool includeNavigation = false)
        {
            using (var context = Transaction.GetContext(true))
            {
                IUserRoles dbItem;
                if (includeNavigation)
                    dbItem = context.UserRoles
								.Include(n=>n.Role)
								.Include(n=>n.User).FirstOrDefault(p => p.Id == id);                
                else
                    dbItem = context.UserRoles.FirstOrDefault(p => p.Id == id);

                return (dbItem != null) ? new UserRolesDto(dbItem, includeNavigation) : null;
            }
        }

        internal static List<UserRolesDto> Select(Expression<Func<IUserRoles, bool>> whereClause = null, bool includeNavigation = false)
        {
            using (var context = Transaction.GetContext(true))
            {
                IQueryable<IUserRoles> dbItems;

                var results = new List<UserRolesDto>();

                if (whereClause == null)
                    return Select(includeNavigation);

                if (includeNavigation)
                    dbItems = context.UserRoles.Where(whereClause)
								.Include(n=>n.Role)
								.Include(n=>n.User);
                else
                    dbItems = context.UserRoles.Where(whereClause);

                if (dbItems.Any())
                {
                    dbItems.ToList()
                        .ForEach(o =>
                        {
                            var dto = new UserRolesDto("Id will be filled in the Assign statement");
                            dto.Assign(o, includeNavigation);
                            results.Add(dto);
                        });
                }
                return results;
            }
        }

        internal static List<UserRolesDto> Select(bool includeNavigation = false)
        {
            using (var context = Transaction.GetContext(true))
            {
                IQueryable<IUserRoles> dbItems;
                var results = new List<UserRolesDto>();

                if (includeNavigation)
                    dbItems = context.UserRoles
								.Include(n=>n.Role)
								.Include(n=>n.User);
                else
                    dbItems = context.UserRoles;

                if (dbItems.Any())
                    dbItems.ToList()
                        .ForEach(o =>
                        {
                            var dto = new UserRolesDto("Id will be filled in the Assign statement");
                            dto.Assign(o, includeNavigation);
                            results.Add(dto);
                        });
                return results;
            }
        }

        internal static UserRolesDto Update(UserRolesDto itemDto)
        {
            var context = Transaction.GetContext();

            var id = itemDto.Id;
            var dbItem = context.UserRoles.FirstOrDefault(o => o.Id == id);
            if (dbItem != null)
            {
                dbItem.Assign(itemDto);
                context.SaveChanges();
                itemDto.Assign(dbItem);
            }

            Transaction.DisposeContext(context);
            return itemDto;
        }

        internal static UserRolesDto Delete(long id, bool cascade = false)
        {
            var context = Transaction.GetContext();

            if (cascade)
            {
                using (var transaction = context.Database.BeginTransaction())
                {
                    var dbItem = context.UserRoles.FirstOrDefault(p => p.Id == id);
                    if (dbItem != null)
                    {   
                        context.UserRoles.Remove(dbItem);
                        context.SaveChanges();

                        transaction.Commit();
                    }
                }
            }
            else
            {
                var dbItem = context.UserRoles.FirstOrDefault(p => p.Id == id);
                if (dbItem != null)
                {
                    context.UserRoles.Remove(dbItem);
                    context.SaveChanges();
                }
            }

            Transaction.DisposeContext(context);

            return null;
        }
    }

    internal static class UserRolesExtensions
    {
        internal static void Assign(this UserRoles destination, IUserRoles source, bool includeNavigation = false)
        {
            UserRoles.Assign(source, destination, includeNavigation);
        }
    }
}