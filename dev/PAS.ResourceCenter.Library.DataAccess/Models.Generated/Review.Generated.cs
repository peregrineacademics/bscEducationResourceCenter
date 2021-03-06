﻿// Generated file do not modify this can be overwritten.
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
    public partial class Review : IReview
    {
        internal static void Assign(IReview source, IReview destination, bool includeNavigation = false)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));
            if (destination == null) throw new ArgumentNullException(nameof(destination));

			destination.Abstract = source.Abstract;
			destination.CreatedByUserId = source.CreatedByUserId;
			destination.DateCreated = source.DateCreated;
			destination.GuideTypeId = source.GuideTypeId;
			destination.Id = source.Id;
			destination.IssueId = source.IssueId;
			destination.KeyWords = source.KeyWords;
			destination.LastUpdated = source.LastUpdated;
			destination.Migrated = source.Migrated;
			destination.ReviewerId = source.ReviewerId;
			destination.ReviewStatusId = source.ReviewStatusId;
			destination.Summary = source.Summary;
			destination.Title = source.Title;
			destination.UpdatedByUserId = source.UpdatedByUserId;
			destination.Url = source.Url;

			if (includeNavigation)
			{
				destination.CreatedByUser = source.CreatedByUser;
				destination.GuideType = source.GuideType;
				destination.Issue = source.Issue;
				destination.ReviewCategory = source.ReviewCategory;
				destination.Reviewer = source.Reviewer;
				destination.ReviewStatus = source.ReviewStatus;
				destination.UpdatedByUser = source.UpdatedByUser;
			}
        }

        internal static ReviewDto Create(ReviewDto itemDto)
        {
            var context = Transaction.GetContext();

            var dbItem = new Review();
            dbItem.Assign(itemDto);
            context.Review.Add(dbItem);
            context.SaveChanges();

            itemDto.Assign(dbItem);

            Transaction.DisposeContext(context);

            return itemDto;
        }

        internal static ReviewDto Get(long id, bool includeNavigation = false)
        {
            using (var context = Transaction.GetContext(true))
            {
                IReview dbItem;
                if (includeNavigation)
                    dbItem = context.Review
								.Include(n=>n.CreatedByUser)
								.Include(n=>n.GuideType)
								.Include(n=>n.Issue)
								.Include(n=>n.ReviewCategory)
								.Include(n=>n.Reviewer)
								.Include(n=>n.ReviewStatus)
								.Include(n=>n.UpdatedByUser).FirstOrDefault(p => p.Id == id);                
                else
                    dbItem = context.Review.FirstOrDefault(p => p.Id == id);

                return (dbItem != null) ? new ReviewDto(dbItem, includeNavigation) : null;
            }
        }

        internal static List<ReviewDto> Select(Expression<Func<IReview, bool>> whereClause = null, bool includeNavigation = false)
        {
            using (var context = Transaction.GetContext(true))
            {
                IQueryable<IReview> dbItems;

                var results = new List<ReviewDto>();

                if (whereClause == null)
                    return Select(includeNavigation);

                if (includeNavigation)
                    dbItems = context.Review.Where(whereClause)
								.Include(n=>n.CreatedByUser)
								.Include(n=>n.GuideType)
								.Include(n=>n.Issue)
								.Include(n=>n.ReviewCategory)
								.Include(n=>n.Reviewer)
								.Include(n=>n.ReviewStatus)
								.Include(n=>n.UpdatedByUser);
                else
                    dbItems = context.Review.Where(whereClause);

                if (dbItems.Any())
                {
                    dbItems.ToList()
                        .ForEach(o =>
                        {
                            var dto = new ReviewDto("Id will be filled in the Assign statement");
                            dto.Assign(o, includeNavigation);
                            results.Add(dto);
                        });
                }
                return results;
            }
        }

        internal static List<ReviewDto> Select(bool includeNavigation = false)
        {
            using (var context = Transaction.GetContext(true))
            {
                IQueryable<IReview> dbItems;
                var results = new List<ReviewDto>();

                if (includeNavigation)
                    dbItems = context.Review
								.Include(n=>n.CreatedByUser)
								.Include(n=>n.GuideType)
								.Include(n=>n.Issue)
								.Include(n=>n.ReviewCategory)
								.Include(n=>n.Reviewer)
								.Include(n=>n.ReviewStatus)
								.Include(n=>n.UpdatedByUser);
                else
                    dbItems = context.Review;

                if (dbItems.Any())
                    dbItems.ToList()
                        .ForEach(o =>
                        {
                            var dto = new ReviewDto("Id will be filled in the Assign statement");
                            dto.Assign(o, includeNavigation);
                            results.Add(dto);
                        });
                return results;
            }
        }

        internal static ReviewDto Update(ReviewDto itemDto)
        {
            var context = Transaction.GetContext();

            var id = itemDto.Id;
            var dbItem = context.Review.FirstOrDefault(o => o.Id == id);
            if (dbItem != null)
            {
                dbItem.Assign(itemDto);
                context.SaveChanges();
                itemDto.Assign(dbItem);
            }

            Transaction.DisposeContext(context);
            return itemDto;
        }

        internal static ReviewDto Delete(long id, bool cascade = false)
        {
            var context = Transaction.GetContext();

            if (cascade)
            {
                using (var transaction = context.Database.BeginTransaction())
                {
                    var dbItem = context.Review
									.Include(n=>n.ReviewCategory).FirstOrDefault(p => p.Id == id);
                    if (dbItem != null)
                    {   
						if (dbItem.ReviewCategory.Count > 0)
							context.ReviewCategory.RemoveRange(dbItem.ReviewCategory);

                        context.Review.Remove(dbItem);
                        context.SaveChanges();

                        transaction.Commit();
                    }
                }
            }
            else
            {
                var dbItem = context.Review.FirstOrDefault(p => p.Id == id);
                if (dbItem != null)
                {
                    context.Review.Remove(dbItem);
                    context.SaveChanges();
                }
            }

            Transaction.DisposeContext(context);

            return null;
        }
    }

    internal static class ReviewExtensions
    {
        internal static void Assign(this Review destination, IReview source, bool includeNavigation = false)
        {
            Review.Assign(source, destination, includeNavigation);
        }
    }
}