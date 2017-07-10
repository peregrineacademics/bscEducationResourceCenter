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
			destination.ReviewerId = source.ReviewerId;
			destination.ReviewStatusId = source.ReviewStatusId;
			destination.Summary = source.Summary;
			destination.Title = source.Title;
			destination.UpdatedByUserId = source.UpdatedByUserId;
			destination.Url = source.Url;

			if (includeNavigation)
			{
				destination.CreatedByUser = source.CreatedByUser;
				destination.DiscussionQuestion = source.DiscussionQuestion;
				destination.GuideType = source.GuideType;
				destination.Issue = source.Issue;
				destination.QuizQuestion = source.QuizQuestion;
				destination.ReviewActivity = source.ReviewActivity;
				destination.ReviewCompetency = source.ReviewCompetency;
				destination.ReviewDiscipline = source.ReviewDiscipline;
				destination.ReviewEdgeGuide = source.ReviewEdgeGuide;
				destination.Reviewer = source.Reviewer;
				destination.ReviewRegion = source.ReviewRegion;
				destination.ReviewSector = source.ReviewSector;
				destination.ReviewStatus = source.ReviewStatus;
				destination.ReviewSubRegion = source.ReviewSubRegion;
				destination.ReviewSubTopic = source.ReviewSubTopic;
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
								.Include(n=>n.DiscussionQuestion)
								.Include(n=>n.GuideType)
								.Include(n=>n.Issue)
								.Include(n=>n.QuizQuestion)
								.Include(n=>n.ReviewActivity)
								.Include(n=>n.ReviewCompetency)
								.Include(n=>n.ReviewDiscipline)
								.Include(n=>n.ReviewEdgeGuide)
								.Include(n=>n.Reviewer)
								.Include(n=>n.ReviewRegion)
								.Include(n=>n.ReviewSector)
								.Include(n=>n.ReviewStatus)
								.Include(n=>n.ReviewSubRegion)
								.Include(n=>n.ReviewSubTopic)
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
								.Include(n=>n.DiscussionQuestion)
								.Include(n=>n.GuideType)
								.Include(n=>n.Issue)
								.Include(n=>n.QuizQuestion)
								.Include(n=>n.ReviewActivity)
								.Include(n=>n.ReviewCompetency)
								.Include(n=>n.ReviewDiscipline)
								.Include(n=>n.ReviewEdgeGuide)
								.Include(n=>n.Reviewer)
								.Include(n=>n.ReviewRegion)
								.Include(n=>n.ReviewSector)
								.Include(n=>n.ReviewStatus)
								.Include(n=>n.ReviewSubRegion)
								.Include(n=>n.ReviewSubTopic)
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
								.Include(n=>n.DiscussionQuestion)
								.Include(n=>n.GuideType)
								.Include(n=>n.Issue)
								.Include(n=>n.QuizQuestion)
								.Include(n=>n.ReviewActivity)
								.Include(n=>n.ReviewCompetency)
								.Include(n=>n.ReviewDiscipline)
								.Include(n=>n.ReviewEdgeGuide)
								.Include(n=>n.Reviewer)
								.Include(n=>n.ReviewRegion)
								.Include(n=>n.ReviewSector)
								.Include(n=>n.ReviewStatus)
								.Include(n=>n.ReviewSubRegion)
								.Include(n=>n.ReviewSubTopic)
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
									.Include(n=>n.DiscussionQuestion)
									.Include(n=>n.QuizQuestion)
									.Include(n=>n.ReviewActivity)
									.Include(n=>n.ReviewCompetency)
									.Include(n=>n.ReviewDiscipline)
									.Include(n=>n.ReviewEdgeGuide)
									.Include(n=>n.ReviewRegion)
									.Include(n=>n.ReviewSector)
									.Include(n=>n.ReviewSubRegion)
									.Include(n=>n.ReviewSubTopic).FirstOrDefault(p => p.Id == id);
                    if (dbItem != null)
                    {   
						if (dbItem.DiscussionQuestion.Count > 0)
							context.DiscussionQuestion.RemoveRange(dbItem.DiscussionQuestion);
						if (dbItem.QuizQuestion.Count > 0)
							context.QuizQuestion.RemoveRange(dbItem.QuizQuestion);
						if (dbItem.ReviewActivity.Count > 0)
							context.ReviewActivity.RemoveRange(dbItem.ReviewActivity);
						if (dbItem.ReviewCompetency.Count > 0)
							context.ReviewCompetency.RemoveRange(dbItem.ReviewCompetency);
						if (dbItem.ReviewDiscipline.Count > 0)
							context.ReviewDiscipline.RemoveRange(dbItem.ReviewDiscipline);
						if (dbItem.ReviewEdgeGuide.Count > 0)
							context.ReviewEdgeGuide.RemoveRange(dbItem.ReviewEdgeGuide);
						if (dbItem.ReviewRegion.Count > 0)
							context.ReviewRegion.RemoveRange(dbItem.ReviewRegion);
						if (dbItem.ReviewSector.Count > 0)
							context.ReviewSector.RemoveRange(dbItem.ReviewSector);
						if (dbItem.ReviewSubRegion.Count > 0)
							context.ReviewSubRegion.RemoveRange(dbItem.ReviewSubRegion);
						if (dbItem.ReviewSubTopic.Count > 0)
							context.ReviewSubTopic.RemoveRange(dbItem.ReviewSubTopic);

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