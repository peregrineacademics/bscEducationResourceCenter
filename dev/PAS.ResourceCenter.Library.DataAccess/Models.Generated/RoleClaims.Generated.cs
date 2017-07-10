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
    public partial class RoleClaims : IRoleClaims
    {
        internal static void Assign(IRoleClaims source, IRoleClaims destination, bool includeNavigation = false)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));
            if (destination == null) throw new ArgumentNullException(nameof(destination));

			destination.ClaimType = source.ClaimType;
			destination.ClaimValue = source.ClaimValue;
			destination.Id = source.Id;
			destination.RoleId = source.RoleId;

			if (includeNavigation)
			{
				destination.Role = source.Role;
			}
        }

        internal static RoleClaimsDto Create(RoleClaimsDto itemDto)
        {
            var context = Transaction.GetContext();

            var dbItem = new RoleClaims();
            dbItem.Assign(itemDto);
            context.RoleClaims.Add(dbItem);
            context.SaveChanges();

            itemDto.Assign(dbItem);

            Transaction.DisposeContext(context);

            return itemDto;
        }

        internal static RoleClaimsDto Get(long id, bool includeNavigation = false)
        {
            using (var context = Transaction.GetContext(true))
            {
                IRoleClaims dbItem;
                if (includeNavigation)
                    dbItem = context.RoleClaims
								.Include(n=>n.Role).FirstOrDefault(p => p.Id == id);                
                else
                    dbItem = context.RoleClaims.FirstOrDefault(p => p.Id == id);

                return (dbItem != null) ? new RoleClaimsDto(dbItem, includeNavigation) : null;
            }
        }

        internal static List<RoleClaimsDto> Select(Expression<Func<IRoleClaims, bool>> whereClause = null, bool includeNavigation = false)
        {
            using (var context = Transaction.GetContext(true))
            {
                IQueryable<IRoleClaims> dbItems;

                var results = new List<RoleClaimsDto>();

                if (whereClause == null)
                    return Select(includeNavigation);

                if (includeNavigation)
                    dbItems = context.RoleClaims.Where(whereClause)
								.Include(n=>n.Role);
                else
                    dbItems = context.RoleClaims.Where(whereClause);

                if (dbItems.Any())
                {
                    dbItems.ToList()
                        .ForEach(o =>
                        {
                            var dto = new RoleClaimsDto("Id will be filled in the Assign statement");
                            dto.Assign(o, includeNavigation);
                            results.Add(dto);
                        });
                }
                return results;
            }
        }

        internal static List<RoleClaimsDto> Select(bool includeNavigation = false)
        {
            using (var context = Transaction.GetContext(true))
            {
                IQueryable<IRoleClaims> dbItems;
                var results = new List<RoleClaimsDto>();

                if (includeNavigation)
                    dbItems = context.RoleClaims
								.Include(n=>n.Role);
                else
                    dbItems = context.RoleClaims;

                if (dbItems.Any())
                    dbItems.ToList()
                        .ForEach(o =>
                        {
                            var dto = new RoleClaimsDto("Id will be filled in the Assign statement");
                            dto.Assign(o, includeNavigation);
                            results.Add(dto);
                        });
                return results;
            }
        }

        internal static RoleClaimsDto Update(RoleClaimsDto itemDto)
        {
            var context = Transaction.GetContext();

            var id = itemDto.Id;
            var dbItem = context.RoleClaims.FirstOrDefault(o => o.Id == id);
            if (dbItem != null)
            {
                dbItem.Assign(itemDto);
                context.SaveChanges();
                itemDto.Assign(dbItem);
            }

            Transaction.DisposeContext(context);
            return itemDto;
        }

        internal static RoleClaimsDto Delete(long id, bool cascade = false)
        {
            var context = Transaction.GetContext();

            if (cascade)
            {
                using (var transaction = context.Database.BeginTransaction())
                {
                    var dbItem = context.RoleClaims.FirstOrDefault(p => p.Id == id);
                    if (dbItem != null)
                    {   
                        context.RoleClaims.Remove(dbItem);
                        context.SaveChanges();

                        transaction.Commit();
                    }
                }
            }
            else
            {
                var dbItem = context.RoleClaims.FirstOrDefault(p => p.Id == id);
                if (dbItem != null)
                {
                    context.RoleClaims.Remove(dbItem);
                    context.SaveChanges();
                }
            }

            Transaction.DisposeContext(context);

            return null;
        }
    }

    internal static class RoleClaimsExtensions
    {
        internal static void Assign(this RoleClaims destination, IRoleClaims source, bool includeNavigation = false)
        {
            RoleClaims.Assign(source, destination, includeNavigation);
        }
    }
}