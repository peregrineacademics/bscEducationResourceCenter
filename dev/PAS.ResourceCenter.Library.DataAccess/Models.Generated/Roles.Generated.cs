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
    public partial class Roles : IRoles
    {
        internal static void Assign(IRoles source, IRoles destination, bool includeNavigation = false)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));
            if (destination == null) throw new ArgumentNullException(nameof(destination));

			destination.ConcurrencyStamp = source.ConcurrencyStamp;
			destination.Id = source.Id;
			destination.Name = source.Name;
			destination.NormalizedName = source.NormalizedName;

			if (includeNavigation)
			{
				destination.RoleClaims = source.RoleClaims;
				destination.UserRoles = source.UserRoles;
			}
        }

        internal static RolesDto Create(RolesDto itemDto)
        {
            var context = Transaction.GetContext();

            var dbItem = new Roles();
            dbItem.Assign(itemDto);
            context.Roles.Add(dbItem);
            context.SaveChanges();

            itemDto.Assign(dbItem);

            Transaction.DisposeContext(context);

            return itemDto;
        }

        internal static RolesDto Get(string id, bool includeNavigation = false)
        {
            using (var context = Transaction.GetContext(true))
            {
                IRoles dbItem;
                if (includeNavigation)
                    dbItem = context.Roles
								.Include(n=>n.RoleClaims)
								.Include(n=>n.UserRoles).FirstOrDefault(p => p.Id == id);                
                else
                    dbItem = context.Roles.FirstOrDefault(p => p.Id == id);

                return (dbItem != null) ? new RolesDto(dbItem, includeNavigation) : null;
            }
        }

        internal static List<RolesDto> Select(Expression<Func<IRoles, bool>> whereClause = null, bool includeNavigation = false)
        {
            using (var context = Transaction.GetContext(true))
            {
                IQueryable<IRoles> dbItems;

                var results = new List<RolesDto>();

                if (whereClause == null)
                    return Select(includeNavigation);

                if (includeNavigation)
                    dbItems = context.Roles.Where(whereClause)
								.Include(n=>n.RoleClaims)
								.Include(n=>n.UserRoles);
                else
                    dbItems = context.Roles.Where(whereClause);

                if (dbItems.Any())
                {
                    dbItems.ToList()
                        .ForEach(o =>
                        {
                            var dto = new RolesDto("Id will be filled in the Assign statement");
                            dto.Assign(o, includeNavigation);
                            results.Add(dto);
                        });
                }
                return results;
            }
        }

        internal static List<RolesDto> Select(bool includeNavigation = false)
        {
            using (var context = Transaction.GetContext(true))
            {
                IQueryable<IRoles> dbItems;
                var results = new List<RolesDto>();

                if (includeNavigation)
                    dbItems = context.Roles
								.Include(n=>n.RoleClaims)
								.Include(n=>n.UserRoles);
                else
                    dbItems = context.Roles;

                if (dbItems.Any())
                    dbItems.ToList()
                        .ForEach(o =>
                        {
                            var dto = new RolesDto("Id will be filled in the Assign statement");
                            dto.Assign(o, includeNavigation);
                            results.Add(dto);
                        });
                return results;
            }
        }

        internal static RolesDto Update(RolesDto itemDto)
        {
            var context = Transaction.GetContext();

            var id = itemDto.Id;
            var dbItem = context.Roles.FirstOrDefault(o => o.Id == id);
            if (dbItem != null)
            {
                dbItem.Assign(itemDto);
                context.SaveChanges();
                itemDto.Assign(dbItem);
            }

            Transaction.DisposeContext(context);
            return itemDto;
        }

        internal static RolesDto Delete(string id, bool cascade = false)
        {
            var context = Transaction.GetContext();

            if (cascade)
            {
                using (var transaction = context.Database.BeginTransaction())
                {
                    var dbItem = context.Roles
									.Include(n=>n.RoleClaims)
									.Include(n=>n.UserRoles).FirstOrDefault(p => p.Id == id);
                    if (dbItem != null)
                    {   
						if (dbItem.RoleClaims.Count > 0)
							context.RoleClaims.RemoveRange(dbItem.RoleClaims);
						if (dbItem.UserRoles.Count > 0)
							context.UserRoles.RemoveRange(dbItem.UserRoles);

                        context.Roles.Remove(dbItem);
                        context.SaveChanges();

                        transaction.Commit();
                    }
                }
            }
            else
            {
                var dbItem = context.Roles.FirstOrDefault(p => p.Id == id);
                if (dbItem != null)
                {
                    context.Roles.Remove(dbItem);
                    context.SaveChanges();
                }
            }

            Transaction.DisposeContext(context);

            return null;
        }
    }

    internal static class RolesExtensions
    {
        internal static void Assign(this Roles destination, IRoles source, bool includeNavigation = false)
        {
            Roles.Assign(source, destination, includeNavigation);
        }
    }
}