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
    public partial class ReviewStatus : IReviewStatus
    {
        internal static void Assign(IReviewStatus source, IReviewStatus destination, bool includeNavigation = false)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));
            if (destination == null) throw new ArgumentNullException(nameof(destination));

			destination.Id = source.Id;
			destination.Name = source.Name;

			if (includeNavigation)
			{
				destination.Review = source.Review;
			}
        }

        internal static ReviewStatusDto Create(ReviewStatusDto itemDto)
        {
            var context = Transaction.GetContext();

            var dbItem = new ReviewStatus();
            dbItem.Assign(itemDto);
            context.ReviewStatus.Add(dbItem);
            context.SaveChanges();

            itemDto.Assign(dbItem);

            Transaction.DisposeContext(context);

            return itemDto;
        }

        internal static ReviewStatusDto Get(long id, bool includeNavigation = false)
        {
            using (var context = Transaction.GetContext(true))
            {
                IReviewStatus dbItem;
                if (includeNavigation)
                    dbItem = context.ReviewStatus
								.Include(n=>n.Review).FirstOrDefault(p => p.Id == id);                
                else
                    dbItem = context.ReviewStatus.FirstOrDefault(p => p.Id == id);

                return (dbItem != null) ? new ReviewStatusDto(dbItem, includeNavigation) : null;
            }
        }

        internal static List<ReviewStatusDto> Select(Expression<Func<IReviewStatus, bool>> whereClause = null, bool includeNavigation = false)
        {
            using (var context = Transaction.GetContext(true))
            {
                IQueryable<IReviewStatus> dbItems;

                var results = new List<ReviewStatusDto>();

                if (whereClause == null)
                    return Select(includeNavigation);

                if (includeNavigation)
                    dbItems = context.ReviewStatus.Where(whereClause)
								.Include(n=>n.Review);
                else
                    dbItems = context.ReviewStatus.Where(whereClause);

                if (dbItems.Any())
                {
                    dbItems.ToList()
                        .ForEach(o =>
                        {
                            var dto = new ReviewStatusDto("Id will be filled in the Assign statement");
                            dto.Assign(o, includeNavigation);
                            results.Add(dto);
                        });
                }
                return results;
            }
        }

        internal static List<ReviewStatusDto> Select(bool includeNavigation = false)
        {
            using (var context = Transaction.GetContext(true))
            {
                IQueryable<IReviewStatus> dbItems;
                var results = new List<ReviewStatusDto>();

                if (includeNavigation)
                    dbItems = context.ReviewStatus
								.Include(n=>n.Review);
                else
                    dbItems = context.ReviewStatus;

                if (dbItems.Any())
                    dbItems.ToList()
                        .ForEach(o =>
                        {
                            var dto = new ReviewStatusDto("Id will be filled in the Assign statement");
                            dto.Assign(o, includeNavigation);
                            results.Add(dto);
                        });
                return results;
            }
        }

        internal static ReviewStatusDto Update(ReviewStatusDto itemDto)
        {
            var context = Transaction.GetContext();

            var id = itemDto.Id;
            var dbItem = context.ReviewStatus.FirstOrDefault(o => o.Id == id);
            if (dbItem != null)
            {
                dbItem.Assign(itemDto);
                context.SaveChanges();
                itemDto.Assign(dbItem);
            }

            Transaction.DisposeContext(context);
            return itemDto;
        }

        internal static ReviewStatusDto Delete(long id, bool cascade = false)
        {
            var context = Transaction.GetContext();

            if (cascade)
            {
                using (var transaction = context.Database.BeginTransaction())
                {
                    var dbItem = context.ReviewStatus
									.Include(n=>n.Review).FirstOrDefault(p => p.Id == id);
                    if (dbItem != null)
                    {   
						if (dbItem.Review.Count > 0)
							context.Review.RemoveRange(dbItem.Review);

                        context.ReviewStatus.Remove(dbItem);
                        context.SaveChanges();

                        transaction.Commit();
                    }
                }
            }
            else
            {
                var dbItem = context.ReviewStatus.FirstOrDefault(p => p.Id == id);
                if (dbItem != null)
                {
                    context.ReviewStatus.Remove(dbItem);
                    context.SaveChanges();
                }
            }

            Transaction.DisposeContext(context);

            return null;
        }
    }

    internal static class ReviewStatusExtensions
    {
        internal static void Assign(this ReviewStatus destination, IReviewStatus source, bool includeNavigation = false)
        {
            ReviewStatus.Assign(source, destination, includeNavigation);
        }
    }
}