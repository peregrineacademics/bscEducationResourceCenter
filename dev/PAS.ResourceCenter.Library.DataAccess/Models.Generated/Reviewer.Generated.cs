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
    public partial class Reviewer : IReviewer
    {
        internal static void Assign(IReviewer source, IReviewer destination, bool includeNavigation = false)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));
            if (destination == null) throw new ArgumentNullException(nameof(destination));

			destination.Biography = source.Biography;
			destination.CreatedByUserId = source.CreatedByUserId;
			destination.DateCreated = source.DateCreated;
			destination.Degree = source.Degree;
			destination.HideFromReviewerList = source.HideFromReviewerList;
			destination.Id = source.Id;
			destination.IsActive = source.IsActive;
			destination.LastUpdated = source.LastUpdated;
			destination.UpdatedByUserId = source.UpdatedByUserId;
			destination.UserId = source.UserId;

			if (includeNavigation)
			{
				destination.Review = source.Review;
				destination.UpdatedByUser = source.UpdatedByUser;
				destination.User = source.User;
			}
        }

        internal static ReviewerDto Create(ReviewerDto itemDto)
        {
            var context = Transaction.GetContext();

            var dbItem = new Reviewer();
            dbItem.Assign(itemDto);
            context.Reviewer.Add(dbItem);
            context.SaveChanges();

            itemDto.Assign(dbItem);

            Transaction.DisposeContext(context);

            return itemDto;
        }

        internal static ReviewerDto Get(long id, bool includeNavigation = false)
        {
            using (var context = Transaction.GetContext(true))
            {
                IReviewer dbItem;
                if (includeNavigation)
                    dbItem = context.Reviewer
								.Include(n=>n.Review)
								.Include(n=>n.UpdatedByUser)
								.Include(n=>n.User).FirstOrDefault(p => p.Id == id);                
                else
                    dbItem = context.Reviewer.FirstOrDefault(p => p.Id == id);

                return (dbItem != null) ? new ReviewerDto(dbItem, includeNavigation) : null;
            }
        }

        internal static List<ReviewerDto> Select(Expression<Func<IReviewer, bool>> whereClause = null, bool includeNavigation = false)
        {
            using (var context = Transaction.GetContext(true))
            {
                IQueryable<IReviewer> dbItems;

                var results = new List<ReviewerDto>();

                if (whereClause == null)
                    return Select(includeNavigation);

                if (includeNavigation)
                    dbItems = context.Reviewer.Where(whereClause)
								.Include(n=>n.Review)
								.Include(n=>n.UpdatedByUser)
								.Include(n=>n.User);
                else
                    dbItems = context.Reviewer.Where(whereClause);

                if (dbItems.Any())
                {
                    dbItems.ToList()
                        .ForEach(o =>
                        {
                            var dto = new ReviewerDto("Id will be filled in the Assign statement");
                            dto.Assign(o, includeNavigation);
                            results.Add(dto);
                        });
                }
                return results;
            }
        }

        internal static List<ReviewerDto> Select(bool includeNavigation = false)
        {
            using (var context = Transaction.GetContext(true))
            {
                IQueryable<IReviewer> dbItems;
                var results = new List<ReviewerDto>();

                if (includeNavigation)
                    dbItems = context.Reviewer
								.Include(n=>n.Review)
								.Include(n=>n.UpdatedByUser)
								.Include(n=>n.User);
                else
                    dbItems = context.Reviewer;

                if (dbItems.Any())
                    dbItems.ToList()
                        .ForEach(o =>
                        {
                            var dto = new ReviewerDto("Id will be filled in the Assign statement");
                            dto.Assign(o, includeNavigation);
                            results.Add(dto);
                        });
                return results;
            }
        }

        internal static ReviewerDto Update(ReviewerDto itemDto)
        {
            var context = Transaction.GetContext();

            var id = itemDto.Id;
            var dbItem = context.Reviewer.FirstOrDefault(o => o.Id == id);
            if (dbItem != null)
            {
                dbItem.Assign(itemDto);
                context.SaveChanges();
                itemDto.Assign(dbItem);
            }

            Transaction.DisposeContext(context);
            return itemDto;
        }

        internal static ReviewerDto Delete(long id, bool cascade = false)
        {
            var context = Transaction.GetContext();

            if (cascade)
            {
                using (var transaction = context.Database.BeginTransaction())
                {
                    var dbItem = context.Reviewer
									.Include(n=>n.Review).FirstOrDefault(p => p.Id == id);
                    if (dbItem != null)
                    {   
						if (dbItem.Review.Count > 0)
							context.Review.RemoveRange(dbItem.Review);

                        context.Reviewer.Remove(dbItem);
                        context.SaveChanges();

                        transaction.Commit();
                    }
                }
            }
            else
            {
                var dbItem = context.Reviewer.FirstOrDefault(p => p.Id == id);
                if (dbItem != null)
                {
                    context.Reviewer.Remove(dbItem);
                    context.SaveChanges();
                }
            }

            Transaction.DisposeContext(context);

            return null;
        }
    }

    internal static class ReviewerExtensions
    {
        internal static void Assign(this Reviewer destination, IReviewer source, bool includeNavigation = false)
        {
            Reviewer.Assign(source, destination, includeNavigation);
        }
    }
}