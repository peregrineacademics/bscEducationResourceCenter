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
    public partial class ReviewSector : IReviewSector
    {
        internal static void Assign(IReviewSector source, IReviewSector destination, bool includeNavigation = false)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));
            if (destination == null) throw new ArgumentNullException(nameof(destination));

			destination.Id = source.Id;
			destination.ReviewId = source.ReviewId;
			destination.SectorId = source.SectorId;

			if (includeNavigation)
			{
				destination.Review = source.Review;
				destination.Sector = source.Sector;
			}
        }

        internal static ReviewSectorDto Create(ReviewSectorDto itemDto)
        {
            var context = Transaction.GetContext();

            var dbItem = new ReviewSector();
            dbItem.Assign(itemDto);
            context.ReviewSector.Add(dbItem);
            context.SaveChanges();

            itemDto.Assign(dbItem);

            Transaction.DisposeContext(context);

            return itemDto;
        }

        internal static ReviewSectorDto Get(long id, bool includeNavigation = false)
        {
            using (var context = Transaction.GetContext(true))
            {
                IReviewSector dbItem;
                if (includeNavigation)
                    dbItem = context.ReviewSector
								.Include(n=>n.Review)
								.Include(n=>n.Sector).FirstOrDefault(p => p.Id == id);                
                else
                    dbItem = context.ReviewSector.FirstOrDefault(p => p.Id == id);

                return (dbItem != null) ? new ReviewSectorDto(dbItem, includeNavigation) : null;
            }
        }

        internal static List<ReviewSectorDto> Select(Expression<Func<IReviewSector, bool>> whereClause = null, bool includeNavigation = false)
        {
            using (var context = Transaction.GetContext(true))
            {
                IQueryable<IReviewSector> dbItems;

                var results = new List<ReviewSectorDto>();

                if (whereClause == null)
                    return Select(includeNavigation);

                if (includeNavigation)
                    dbItems = context.ReviewSector.Where(whereClause)
								.Include(n=>n.Review)
								.Include(n=>n.Sector);
                else
                    dbItems = context.ReviewSector.Where(whereClause);

                if (dbItems.Any())
                {
                    dbItems.ToList()
                        .ForEach(o =>
                        {
                            var dto = new ReviewSectorDto("Id will be filled in the Assign statement");
                            dto.Assign(o, includeNavigation);
                            results.Add(dto);
                        });
                }
                return results;
            }
        }

        internal static List<ReviewSectorDto> Select(bool includeNavigation = false)
        {
            using (var context = Transaction.GetContext(true))
            {
                IQueryable<IReviewSector> dbItems;
                var results = new List<ReviewSectorDto>();

                if (includeNavigation)
                    dbItems = context.ReviewSector
								.Include(n=>n.Review)
								.Include(n=>n.Sector);
                else
                    dbItems = context.ReviewSector;

                if (dbItems.Any())
                    dbItems.ToList()
                        .ForEach(o =>
                        {
                            var dto = new ReviewSectorDto("Id will be filled in the Assign statement");
                            dto.Assign(o, includeNavigation);
                            results.Add(dto);
                        });
                return results;
            }
        }

        internal static ReviewSectorDto Update(ReviewSectorDto itemDto)
        {
            var context = Transaction.GetContext();

            var id = itemDto.Id;
            var dbItem = context.ReviewSector.FirstOrDefault(o => o.Id == id);
            if (dbItem != null)
            {
                dbItem.Assign(itemDto);
                context.SaveChanges();
                itemDto.Assign(dbItem);
            }

            Transaction.DisposeContext(context);
            return itemDto;
        }

        internal static ReviewSectorDto Delete(long id, bool cascade = false)
        {
            var context = Transaction.GetContext();

            if (cascade)
            {
                using (var transaction = context.Database.BeginTransaction())
                {
                    var dbItem = context.ReviewSector.FirstOrDefault(p => p.Id == id);
                    if (dbItem != null)
                    {   
                        context.ReviewSector.Remove(dbItem);
                        context.SaveChanges();

                        transaction.Commit();
                    }
                }
            }
            else
            {
                var dbItem = context.ReviewSector.FirstOrDefault(p => p.Id == id);
                if (dbItem != null)
                {
                    context.ReviewSector.Remove(dbItem);
                    context.SaveChanges();
                }
            }

            Transaction.DisposeContext(context);

            return null;
        }
    }

    internal static class ReviewSectorExtensions
    {
        internal static void Assign(this ReviewSector destination, IReviewSector source, bool includeNavigation = false)
        {
            ReviewSector.Assign(source, destination, includeNavigation);
        }
    }
}