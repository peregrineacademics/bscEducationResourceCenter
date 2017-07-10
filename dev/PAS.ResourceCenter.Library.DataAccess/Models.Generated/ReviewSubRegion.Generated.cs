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
    public partial class ReviewSubRegion : IReviewSubRegion
    {
        internal static void Assign(IReviewSubRegion source, IReviewSubRegion destination, bool includeNavigation = false)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));
            if (destination == null) throw new ArgumentNullException(nameof(destination));

			destination.Id = source.Id;
			destination.ReviewId = source.ReviewId;
			destination.SubRegionId = source.SubRegionId;

			if (includeNavigation)
			{
				destination.Review = source.Review;
				destination.SubRegion = source.SubRegion;
			}
        }

        internal static ReviewSubRegionDto Create(ReviewSubRegionDto itemDto)
        {
            var context = Transaction.GetContext();

            var dbItem = new ReviewSubRegion();
            dbItem.Assign(itemDto);
            context.ReviewSubRegion.Add(dbItem);
            context.SaveChanges();

            itemDto.Assign(dbItem);

            Transaction.DisposeContext(context);

            return itemDto;
        }

        internal static ReviewSubRegionDto Get(long id, bool includeNavigation = false)
        {
            using (var context = Transaction.GetContext(true))
            {
                IReviewSubRegion dbItem;
                if (includeNavigation)
                    dbItem = context.ReviewSubRegion
								.Include(n=>n.Review)
								.Include(n=>n.SubRegion).FirstOrDefault(p => p.Id == id);                
                else
                    dbItem = context.ReviewSubRegion.FirstOrDefault(p => p.Id == id);

                return (dbItem != null) ? new ReviewSubRegionDto(dbItem, includeNavigation) : null;
            }
        }

        internal static List<ReviewSubRegionDto> Select(Expression<Func<IReviewSubRegion, bool>> whereClause = null, bool includeNavigation = false)
        {
            using (var context = Transaction.GetContext(true))
            {
                IQueryable<IReviewSubRegion> dbItems;

                var results = new List<ReviewSubRegionDto>();

                if (whereClause == null)
                    return Select(includeNavigation);

                if (includeNavigation)
                    dbItems = context.ReviewSubRegion.Where(whereClause)
								.Include(n=>n.Review)
								.Include(n=>n.SubRegion);
                else
                    dbItems = context.ReviewSubRegion.Where(whereClause);

                if (dbItems.Any())
                {
                    dbItems.ToList()
                        .ForEach(o =>
                        {
                            var dto = new ReviewSubRegionDto("Id will be filled in the Assign statement");
                            dto.Assign(o, includeNavigation);
                            results.Add(dto);
                        });
                }
                return results;
            }
        }

        internal static List<ReviewSubRegionDto> Select(bool includeNavigation = false)
        {
            using (var context = Transaction.GetContext(true))
            {
                IQueryable<IReviewSubRegion> dbItems;
                var results = new List<ReviewSubRegionDto>();

                if (includeNavigation)
                    dbItems = context.ReviewSubRegion
								.Include(n=>n.Review)
								.Include(n=>n.SubRegion);
                else
                    dbItems = context.ReviewSubRegion;

                if (dbItems.Any())
                    dbItems.ToList()
                        .ForEach(o =>
                        {
                            var dto = new ReviewSubRegionDto("Id will be filled in the Assign statement");
                            dto.Assign(o, includeNavigation);
                            results.Add(dto);
                        });
                return results;
            }
        }

        internal static ReviewSubRegionDto Update(ReviewSubRegionDto itemDto)
        {
            var context = Transaction.GetContext();

            var id = itemDto.Id;
            var dbItem = context.ReviewSubRegion.FirstOrDefault(o => o.Id == id);
            if (dbItem != null)
            {
                dbItem.Assign(itemDto);
                context.SaveChanges();
                itemDto.Assign(dbItem);
            }

            Transaction.DisposeContext(context);
            return itemDto;
        }

        internal static ReviewSubRegionDto Delete(long id, bool cascade = false)
        {
            var context = Transaction.GetContext();

            if (cascade)
            {
                using (var transaction = context.Database.BeginTransaction())
                {
                    var dbItem = context.ReviewSubRegion.FirstOrDefault(p => p.Id == id);
                    if (dbItem != null)
                    {   
                        context.ReviewSubRegion.Remove(dbItem);
                        context.SaveChanges();

                        transaction.Commit();
                    }
                }
            }
            else
            {
                var dbItem = context.ReviewSubRegion.FirstOrDefault(p => p.Id == id);
                if (dbItem != null)
                {
                    context.ReviewSubRegion.Remove(dbItem);
                    context.SaveChanges();
                }
            }

            Transaction.DisposeContext(context);

            return null;
        }
    }

    internal static class ReviewSubRegionExtensions
    {
        internal static void Assign(this ReviewSubRegion destination, IReviewSubRegion source, bool includeNavigation = false)
        {
            ReviewSubRegion.Assign(source, destination, includeNavigation);
        }
    }
}