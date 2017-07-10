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
    public partial class SubRegion : ISubRegion
    {
        internal static void Assign(ISubRegion source, ISubRegion destination, bool includeNavigation = false)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));
            if (destination == null) throw new ArgumentNullException(nameof(destination));

			destination.Id = source.Id;
			destination.IsEnabled = source.IsEnabled;
			destination.Name = source.Name;
			destination.RegionId = source.RegionId;

			if (includeNavigation)
			{
				destination.Region = source.Region;
				destination.ReviewSubRegion = source.ReviewSubRegion;
			}
        }

        internal static SubRegionDto Create(SubRegionDto itemDto)
        {
            var context = Transaction.GetContext();

            var dbItem = new SubRegion();
            dbItem.Assign(itemDto);
            context.SubRegion.Add(dbItem);
            context.SaveChanges();

            itemDto.Assign(dbItem);

            Transaction.DisposeContext(context);

            return itemDto;
        }

        internal static SubRegionDto Get(long id, bool includeNavigation = false)
        {
            using (var context = Transaction.GetContext(true))
            {
                ISubRegion dbItem;
                if (includeNavigation)
                    dbItem = context.SubRegion
								.Include(n=>n.Region)
								.Include(n=>n.ReviewSubRegion).FirstOrDefault(p => p.Id == id);                
                else
                    dbItem = context.SubRegion.FirstOrDefault(p => p.Id == id);

                return (dbItem != null) ? new SubRegionDto(dbItem, includeNavigation) : null;
            }
        }

        internal static List<SubRegionDto> Select(Expression<Func<ISubRegion, bool>> whereClause = null, bool includeNavigation = false)
        {
            using (var context = Transaction.GetContext(true))
            {
                IQueryable<ISubRegion> dbItems;

                var results = new List<SubRegionDto>();

                if (whereClause == null)
                    return Select(includeNavigation);

                if (includeNavigation)
                    dbItems = context.SubRegion.Where(whereClause)
								.Include(n=>n.Region)
								.Include(n=>n.ReviewSubRegion);
                else
                    dbItems = context.SubRegion.Where(whereClause);

                if (dbItems.Any())
                {
                    dbItems.ToList()
                        .ForEach(o =>
                        {
                            var dto = new SubRegionDto("Id will be filled in the Assign statement");
                            dto.Assign(o, includeNavigation);
                            results.Add(dto);
                        });
                }
                return results;
            }
        }

        internal static List<SubRegionDto> Select(bool includeNavigation = false)
        {
            using (var context = Transaction.GetContext(true))
            {
                IQueryable<ISubRegion> dbItems;
                var results = new List<SubRegionDto>();

                if (includeNavigation)
                    dbItems = context.SubRegion
								.Include(n=>n.Region)
								.Include(n=>n.ReviewSubRegion);
                else
                    dbItems = context.SubRegion;

                if (dbItems.Any())
                    dbItems.ToList()
                        .ForEach(o =>
                        {
                            var dto = new SubRegionDto("Id will be filled in the Assign statement");
                            dto.Assign(o, includeNavigation);
                            results.Add(dto);
                        });
                return results;
            }
        }

        internal static SubRegionDto Update(SubRegionDto itemDto)
        {
            var context = Transaction.GetContext();

            var id = itemDto.Id;
            var dbItem = context.SubRegion.FirstOrDefault(o => o.Id == id);
            if (dbItem != null)
            {
                dbItem.Assign(itemDto);
                context.SaveChanges();
                itemDto.Assign(dbItem);
            }

            Transaction.DisposeContext(context);
            return itemDto;
        }

        internal static SubRegionDto Delete(long id, bool cascade = false)
        {
            var context = Transaction.GetContext();

            if (cascade)
            {
                using (var transaction = context.Database.BeginTransaction())
                {
                    var dbItem = context.SubRegion
									.Include(n=>n.ReviewSubRegion).FirstOrDefault(p => p.Id == id);
                    if (dbItem != null)
                    {   
						if (dbItem.ReviewSubRegion.Count > 0)
							context.ReviewSubRegion.RemoveRange(dbItem.ReviewSubRegion);

                        context.SubRegion.Remove(dbItem);
                        context.SaveChanges();

                        transaction.Commit();
                    }
                }
            }
            else
            {
                var dbItem = context.SubRegion.FirstOrDefault(p => p.Id == id);
                if (dbItem != null)
                {
                    context.SubRegion.Remove(dbItem);
                    context.SaveChanges();
                }
            }

            Transaction.DisposeContext(context);

            return null;
        }
    }

    internal static class SubRegionExtensions
    {
        internal static void Assign(this SubRegion destination, ISubRegion source, bool includeNavigation = false)
        {
            SubRegion.Assign(source, destination, includeNavigation);
        }
    }
}