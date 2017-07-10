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
    public partial class ReviewRegion : IReviewRegion
    {
        internal static void Assign(IReviewRegion source, IReviewRegion destination, bool includeNavigation = false)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));
            if (destination == null) throw new ArgumentNullException(nameof(destination));

			destination.Id = source.Id;
			destination.RegionId = source.RegionId;
			destination.ReviewId = source.ReviewId;

			if (includeNavigation)
			{
				destination.Region = source.Region;
				destination.Review = source.Review;
			}
        }

        internal static ReviewRegionDto Create(ReviewRegionDto itemDto)
        {
            var context = Transaction.GetContext();

            var dbItem = new ReviewRegion();
            dbItem.Assign(itemDto);
            context.ReviewRegion.Add(dbItem);
            context.SaveChanges();

            itemDto.Assign(dbItem);

            Transaction.DisposeContext(context);

            return itemDto;
        }

        internal static ReviewRegionDto Get(long id, bool includeNavigation = false)
        {
            using (var context = Transaction.GetContext(true))
            {
                IReviewRegion dbItem;
                if (includeNavigation)
                    dbItem = context.ReviewRegion
								.Include(n=>n.Region)
								.Include(n=>n.Review).FirstOrDefault(p => p.Id == id);                
                else
                    dbItem = context.ReviewRegion.FirstOrDefault(p => p.Id == id);

                return (dbItem != null) ? new ReviewRegionDto(dbItem, includeNavigation) : null;
            }
        }

        internal static List<ReviewRegionDto> Select(Expression<Func<IReviewRegion, bool>> whereClause = null, bool includeNavigation = false)
        {
            using (var context = Transaction.GetContext(true))
            {
                IQueryable<IReviewRegion> dbItems;

                var results = new List<ReviewRegionDto>();

                if (whereClause == null)
                    return Select(includeNavigation);

                if (includeNavigation)
                    dbItems = context.ReviewRegion.Where(whereClause)
								.Include(n=>n.Region)
								.Include(n=>n.Review);
                else
                    dbItems = context.ReviewRegion.Where(whereClause);

                if (dbItems.Any())
                {
                    dbItems.ToList()
                        .ForEach(o =>
                        {
                            var dto = new ReviewRegionDto("Id will be filled in the Assign statement");
                            dto.Assign(o, includeNavigation);
                            results.Add(dto);
                        });
                }
                return results;
            }
        }

        internal static List<ReviewRegionDto> Select(bool includeNavigation = false)
        {
            using (var context = Transaction.GetContext(true))
            {
                IQueryable<IReviewRegion> dbItems;
                var results = new List<ReviewRegionDto>();

                if (includeNavigation)
                    dbItems = context.ReviewRegion
								.Include(n=>n.Region)
								.Include(n=>n.Review);
                else
                    dbItems = context.ReviewRegion;

                if (dbItems.Any())
                    dbItems.ToList()
                        .ForEach(o =>
                        {
                            var dto = new ReviewRegionDto("Id will be filled in the Assign statement");
                            dto.Assign(o, includeNavigation);
                            results.Add(dto);
                        });
                return results;
            }
        }

        internal static ReviewRegionDto Update(ReviewRegionDto itemDto)
        {
            var context = Transaction.GetContext();

            var id = itemDto.Id;
            var dbItem = context.ReviewRegion.FirstOrDefault(o => o.Id == id);
            if (dbItem != null)
            {
                dbItem.Assign(itemDto);
                context.SaveChanges();
                itemDto.Assign(dbItem);
            }

            Transaction.DisposeContext(context);
            return itemDto;
        }

        internal static ReviewRegionDto Delete(long id, bool cascade = false)
        {
            var context = Transaction.GetContext();

            if (cascade)
            {
                using (var transaction = context.Database.BeginTransaction())
                {
                    var dbItem = context.ReviewRegion.FirstOrDefault(p => p.Id == id);
                    if (dbItem != null)
                    {   
                        context.ReviewRegion.Remove(dbItem);
                        context.SaveChanges();

                        transaction.Commit();
                    }
                }
            }
            else
            {
                var dbItem = context.ReviewRegion.FirstOrDefault(p => p.Id == id);
                if (dbItem != null)
                {
                    context.ReviewRegion.Remove(dbItem);
                    context.SaveChanges();
                }
            }

            Transaction.DisposeContext(context);

            return null;
        }
    }

    internal static class ReviewRegionExtensions
    {
        internal static void Assign(this ReviewRegion destination, IReviewRegion source, bool includeNavigation = false)
        {
            ReviewRegion.Assign(source, destination, includeNavigation);
        }
    }
}