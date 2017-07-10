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
    public partial class Region : IRegion
    {
        internal static void Assign(IRegion source, IRegion destination, bool includeNavigation = false)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));
            if (destination == null) throw new ArgumentNullException(nameof(destination));

			destination.Id = source.Id;
			destination.IsEnabled = source.IsEnabled;
			destination.Name = source.Name;

			if (includeNavigation)
			{
				destination.ReviewRegion = source.ReviewRegion;
				destination.SubRegion = source.SubRegion;
			}
        }

        internal static RegionDto Create(RegionDto itemDto)
        {
            var context = Transaction.GetContext();

            var dbItem = new Region();
            dbItem.Assign(itemDto);
            context.Region.Add(dbItem);
            context.SaveChanges();

            itemDto.Assign(dbItem);

            Transaction.DisposeContext(context);

            return itemDto;
        }

        internal static RegionDto Get(long id, bool includeNavigation = false)
        {
            using (var context = Transaction.GetContext(true))
            {
                IRegion dbItem;
                if (includeNavigation)
                    dbItem = context.Region
								.Include(n=>n.ReviewRegion)
								.Include(n=>n.SubRegion).FirstOrDefault(p => p.Id == id);                
                else
                    dbItem = context.Region.FirstOrDefault(p => p.Id == id);

                return (dbItem != null) ? new RegionDto(dbItem, includeNavigation) : null;
            }
        }

        internal static List<RegionDto> Select(Expression<Func<IRegion, bool>> whereClause = null, bool includeNavigation = false)
        {
            using (var context = Transaction.GetContext(true))
            {
                IQueryable<IRegion> dbItems;

                var results = new List<RegionDto>();

                if (whereClause == null)
                    return Select(includeNavigation);

                if (includeNavigation)
                    dbItems = context.Region.Where(whereClause)
								.Include(n=>n.ReviewRegion)
								.Include(n=>n.SubRegion);
                else
                    dbItems = context.Region.Where(whereClause);

                if (dbItems.Any())
                {
                    dbItems.ToList()
                        .ForEach(o =>
                        {
                            var dto = new RegionDto("Id will be filled in the Assign statement");
                            dto.Assign(o, includeNavigation);
                            results.Add(dto);
                        });
                }
                return results;
            }
        }

        internal static List<RegionDto> Select(bool includeNavigation = false)
        {
            using (var context = Transaction.GetContext(true))
            {
                IQueryable<IRegion> dbItems;
                var results = new List<RegionDto>();

                if (includeNavigation)
                    dbItems = context.Region
								.Include(n=>n.ReviewRegion)
								.Include(n=>n.SubRegion);
                else
                    dbItems = context.Region;

                if (dbItems.Any())
                    dbItems.ToList()
                        .ForEach(o =>
                        {
                            var dto = new RegionDto("Id will be filled in the Assign statement");
                            dto.Assign(o, includeNavigation);
                            results.Add(dto);
                        });
                return results;
            }
        }

        internal static RegionDto Update(RegionDto itemDto)
        {
            var context = Transaction.GetContext();

            var id = itemDto.Id;
            var dbItem = context.Region.FirstOrDefault(o => o.Id == id);
            if (dbItem != null)
            {
                dbItem.Assign(itemDto);
                context.SaveChanges();
                itemDto.Assign(dbItem);
            }

            Transaction.DisposeContext(context);
            return itemDto;
        }

        internal static RegionDto Delete(long id, bool cascade = false)
        {
            var context = Transaction.GetContext();

            if (cascade)
            {
                using (var transaction = context.Database.BeginTransaction())
                {
                    var dbItem = context.Region
									.Include(n=>n.ReviewRegion)
									.Include(n=>n.SubRegion).FirstOrDefault(p => p.Id == id);
                    if (dbItem != null)
                    {   
						if (dbItem.ReviewRegion.Count > 0)
							context.ReviewRegion.RemoveRange(dbItem.ReviewRegion);
						if (dbItem.SubRegion.Count > 0)
							context.SubRegion.RemoveRange(dbItem.SubRegion);

                        context.Region.Remove(dbItem);
                        context.SaveChanges();

                        transaction.Commit();
                    }
                }
            }
            else
            {
                var dbItem = context.Region.FirstOrDefault(p => p.Id == id);
                if (dbItem != null)
                {
                    context.Region.Remove(dbItem);
                    context.SaveChanges();
                }
            }

            Transaction.DisposeContext(context);

            return null;
        }
    }

    internal static class RegionExtensions
    {
        internal static void Assign(this Region destination, IRegion source, bool includeNavigation = false)
        {
            Region.Assign(source, destination, includeNavigation);
        }
    }
}