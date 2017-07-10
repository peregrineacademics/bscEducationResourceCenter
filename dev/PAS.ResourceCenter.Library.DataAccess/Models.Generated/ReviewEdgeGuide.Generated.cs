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
    public partial class ReviewEdgeGuide : IReviewEdgeGuide
    {
        internal static void Assign(IReviewEdgeGuide source, IReviewEdgeGuide destination, bool includeNavigation = false)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));
            if (destination == null) throw new ArgumentNullException(nameof(destination));

			destination.EdgeGuideId = source.EdgeGuideId;
			destination.Id = source.Id;
			destination.ReviewId = source.ReviewId;

			if (includeNavigation)
			{
				destination.EdgeGuide = source.EdgeGuide;
				destination.Review = source.Review;
			}
        }

        internal static ReviewEdgeGuideDto Create(ReviewEdgeGuideDto itemDto)
        {
            var context = Transaction.GetContext();

            var dbItem = new ReviewEdgeGuide();
            dbItem.Assign(itemDto);
            context.ReviewEdgeGuide.Add(dbItem);
            context.SaveChanges();

            itemDto.Assign(dbItem);

            Transaction.DisposeContext(context);

            return itemDto;
        }

        internal static ReviewEdgeGuideDto Get(long id, bool includeNavigation = false)
        {
            using (var context = Transaction.GetContext(true))
            {
                IReviewEdgeGuide dbItem;
                if (includeNavigation)
                    dbItem = context.ReviewEdgeGuide
								.Include(n=>n.EdgeGuide)
								.Include(n=>n.Review).FirstOrDefault(p => p.Id == id);                
                else
                    dbItem = context.ReviewEdgeGuide.FirstOrDefault(p => p.Id == id);

                return (dbItem != null) ? new ReviewEdgeGuideDto(dbItem, includeNavigation) : null;
            }
        }

        internal static List<ReviewEdgeGuideDto> Select(Expression<Func<IReviewEdgeGuide, bool>> whereClause = null, bool includeNavigation = false)
        {
            using (var context = Transaction.GetContext(true))
            {
                IQueryable<IReviewEdgeGuide> dbItems;

                var results = new List<ReviewEdgeGuideDto>();

                if (whereClause == null)
                    return Select(includeNavigation);

                if (includeNavigation)
                    dbItems = context.ReviewEdgeGuide.Where(whereClause)
								.Include(n=>n.EdgeGuide)
								.Include(n=>n.Review);
                else
                    dbItems = context.ReviewEdgeGuide.Where(whereClause);

                if (dbItems.Any())
                {
                    dbItems.ToList()
                        .ForEach(o =>
                        {
                            var dto = new ReviewEdgeGuideDto("Id will be filled in the Assign statement");
                            dto.Assign(o, includeNavigation);
                            results.Add(dto);
                        });
                }
                return results;
            }
        }

        internal static List<ReviewEdgeGuideDto> Select(bool includeNavigation = false)
        {
            using (var context = Transaction.GetContext(true))
            {
                IQueryable<IReviewEdgeGuide> dbItems;
                var results = new List<ReviewEdgeGuideDto>();

                if (includeNavigation)
                    dbItems = context.ReviewEdgeGuide
								.Include(n=>n.EdgeGuide)
								.Include(n=>n.Review);
                else
                    dbItems = context.ReviewEdgeGuide;

                if (dbItems.Any())
                    dbItems.ToList()
                        .ForEach(o =>
                        {
                            var dto = new ReviewEdgeGuideDto("Id will be filled in the Assign statement");
                            dto.Assign(o, includeNavigation);
                            results.Add(dto);
                        });
                return results;
            }
        }

        internal static ReviewEdgeGuideDto Update(ReviewEdgeGuideDto itemDto)
        {
            var context = Transaction.GetContext();

            var id = itemDto.Id;
            var dbItem = context.ReviewEdgeGuide.FirstOrDefault(o => o.Id == id);
            if (dbItem != null)
            {
                dbItem.Assign(itemDto);
                context.SaveChanges();
                itemDto.Assign(dbItem);
            }

            Transaction.DisposeContext(context);
            return itemDto;
        }

        internal static ReviewEdgeGuideDto Delete(long id, bool cascade = false)
        {
            var context = Transaction.GetContext();

            if (cascade)
            {
                using (var transaction = context.Database.BeginTransaction())
                {
                    var dbItem = context.ReviewEdgeGuide.FirstOrDefault(p => p.Id == id);
                    if (dbItem != null)
                    {   
                        context.ReviewEdgeGuide.Remove(dbItem);
                        context.SaveChanges();

                        transaction.Commit();
                    }
                }
            }
            else
            {
                var dbItem = context.ReviewEdgeGuide.FirstOrDefault(p => p.Id == id);
                if (dbItem != null)
                {
                    context.ReviewEdgeGuide.Remove(dbItem);
                    context.SaveChanges();
                }
            }

            Transaction.DisposeContext(context);

            return null;
        }
    }

    internal static class ReviewEdgeGuideExtensions
    {
        internal static void Assign(this ReviewEdgeGuide destination, IReviewEdgeGuide source, bool includeNavigation = false)
        {
            ReviewEdgeGuide.Assign(source, destination, includeNavigation);
        }
    }
}