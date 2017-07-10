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
    public partial class Sector : ISector
    {
        internal static void Assign(ISector source, ISector destination, bool includeNavigation = false)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));
            if (destination == null) throw new ArgumentNullException(nameof(destination));

			destination.Id = source.Id;
			destination.IsEnabled = source.IsEnabled;
			destination.Name = source.Name;

			if (includeNavigation)
			{
				destination.ReviewSector = source.ReviewSector;
			}
        }

        internal static SectorDto Create(SectorDto itemDto)
        {
            var context = Transaction.GetContext();

            var dbItem = new Sector();
            dbItem.Assign(itemDto);
            context.Sector.Add(dbItem);
            context.SaveChanges();

            itemDto.Assign(dbItem);

            Transaction.DisposeContext(context);

            return itemDto;
        }

        internal static SectorDto Get(long id, bool includeNavigation = false)
        {
            using (var context = Transaction.GetContext(true))
            {
                ISector dbItem;
                if (includeNavigation)
                    dbItem = context.Sector
								.Include(n=>n.ReviewSector).FirstOrDefault(p => p.Id == id);                
                else
                    dbItem = context.Sector.FirstOrDefault(p => p.Id == id);

                return (dbItem != null) ? new SectorDto(dbItem, includeNavigation) : null;
            }
        }

        internal static List<SectorDto> Select(Expression<Func<ISector, bool>> whereClause = null, bool includeNavigation = false)
        {
            using (var context = Transaction.GetContext(true))
            {
                IQueryable<ISector> dbItems;

                var results = new List<SectorDto>();

                if (whereClause == null)
                    return Select(includeNavigation);

                if (includeNavigation)
                    dbItems = context.Sector.Where(whereClause)
								.Include(n=>n.ReviewSector);
                else
                    dbItems = context.Sector.Where(whereClause);

                if (dbItems.Any())
                {
                    dbItems.ToList()
                        .ForEach(o =>
                        {
                            var dto = new SectorDto("Id will be filled in the Assign statement");
                            dto.Assign(o, includeNavigation);
                            results.Add(dto);
                        });
                }
                return results;
            }
        }

        internal static List<SectorDto> Select(bool includeNavigation = false)
        {
            using (var context = Transaction.GetContext(true))
            {
                IQueryable<ISector> dbItems;
                var results = new List<SectorDto>();

                if (includeNavigation)
                    dbItems = context.Sector
								.Include(n=>n.ReviewSector);
                else
                    dbItems = context.Sector;

                if (dbItems.Any())
                    dbItems.ToList()
                        .ForEach(o =>
                        {
                            var dto = new SectorDto("Id will be filled in the Assign statement");
                            dto.Assign(o, includeNavigation);
                            results.Add(dto);
                        });
                return results;
            }
        }

        internal static SectorDto Update(SectorDto itemDto)
        {
            var context = Transaction.GetContext();

            var id = itemDto.Id;
            var dbItem = context.Sector.FirstOrDefault(o => o.Id == id);
            if (dbItem != null)
            {
                dbItem.Assign(itemDto);
                context.SaveChanges();
                itemDto.Assign(dbItem);
            }

            Transaction.DisposeContext(context);
            return itemDto;
        }

        internal static SectorDto Delete(long id, bool cascade = false)
        {
            var context = Transaction.GetContext();

            if (cascade)
            {
                using (var transaction = context.Database.BeginTransaction())
                {
                    var dbItem = context.Sector
									.Include(n=>n.ReviewSector).FirstOrDefault(p => p.Id == id);
                    if (dbItem != null)
                    {   
						if (dbItem.ReviewSector.Count > 0)
							context.ReviewSector.RemoveRange(dbItem.ReviewSector);

                        context.Sector.Remove(dbItem);
                        context.SaveChanges();

                        transaction.Commit();
                    }
                }
            }
            else
            {
                var dbItem = context.Sector.FirstOrDefault(p => p.Id == id);
                if (dbItem != null)
                {
                    context.Sector.Remove(dbItem);
                    context.SaveChanges();
                }
            }

            Transaction.DisposeContext(context);

            return null;
        }
    }

    internal static class SectorExtensions
    {
        internal static void Assign(this Sector destination, ISector source, bool includeNavigation = false)
        {
            Sector.Assign(source, destination, includeNavigation);
        }
    }
}