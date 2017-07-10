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
    public partial class ReviewSubTopic : IReviewSubTopic
    {
        internal static void Assign(IReviewSubTopic source, IReviewSubTopic destination, bool includeNavigation = false)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));
            if (destination == null) throw new ArgumentNullException(nameof(destination));

			destination.Id = source.Id;
			destination.ReviewId = source.ReviewId;
			destination.SubTopicId = source.SubTopicId;

			if (includeNavigation)
			{
				destination.Review = source.Review;
				destination.SubTopic = source.SubTopic;
			}
        }

        internal static ReviewSubTopicDto Create(ReviewSubTopicDto itemDto)
        {
            var context = Transaction.GetContext();

            var dbItem = new ReviewSubTopic();
            dbItem.Assign(itemDto);
            context.ReviewSubTopic.Add(dbItem);
            context.SaveChanges();

            itemDto.Assign(dbItem);

            Transaction.DisposeContext(context);

            return itemDto;
        }

        internal static ReviewSubTopicDto Get(long id, bool includeNavigation = false)
        {
            using (var context = Transaction.GetContext(true))
            {
                IReviewSubTopic dbItem;
                if (includeNavigation)
                    dbItem = context.ReviewSubTopic
								.Include(n=>n.Review)
								.Include(n=>n.SubTopic).FirstOrDefault(p => p.Id == id);                
                else
                    dbItem = context.ReviewSubTopic.FirstOrDefault(p => p.Id == id);

                return (dbItem != null) ? new ReviewSubTopicDto(dbItem, includeNavigation) : null;
            }
        }

        internal static List<ReviewSubTopicDto> Select(Expression<Func<IReviewSubTopic, bool>> whereClause = null, bool includeNavigation = false)
        {
            using (var context = Transaction.GetContext(true))
            {
                IQueryable<IReviewSubTopic> dbItems;

                var results = new List<ReviewSubTopicDto>();

                if (whereClause == null)
                    return Select(includeNavigation);

                if (includeNavigation)
                    dbItems = context.ReviewSubTopic.Where(whereClause)
								.Include(n=>n.Review)
								.Include(n=>n.SubTopic);
                else
                    dbItems = context.ReviewSubTopic.Where(whereClause);

                if (dbItems.Any())
                {
                    dbItems.ToList()
                        .ForEach(o =>
                        {
                            var dto = new ReviewSubTopicDto("Id will be filled in the Assign statement");
                            dto.Assign(o, includeNavigation);
                            results.Add(dto);
                        });
                }
                return results;
            }
        }

        internal static List<ReviewSubTopicDto> Select(bool includeNavigation = false)
        {
            using (var context = Transaction.GetContext(true))
            {
                IQueryable<IReviewSubTopic> dbItems;
                var results = new List<ReviewSubTopicDto>();

                if (includeNavigation)
                    dbItems = context.ReviewSubTopic
								.Include(n=>n.Review)
								.Include(n=>n.SubTopic);
                else
                    dbItems = context.ReviewSubTopic;

                if (dbItems.Any())
                    dbItems.ToList()
                        .ForEach(o =>
                        {
                            var dto = new ReviewSubTopicDto("Id will be filled in the Assign statement");
                            dto.Assign(o, includeNavigation);
                            results.Add(dto);
                        });
                return results;
            }
        }

        internal static ReviewSubTopicDto Update(ReviewSubTopicDto itemDto)
        {
            var context = Transaction.GetContext();

            var id = itemDto.Id;
            var dbItem = context.ReviewSubTopic.FirstOrDefault(o => o.Id == id);
            if (dbItem != null)
            {
                dbItem.Assign(itemDto);
                context.SaveChanges();
                itemDto.Assign(dbItem);
            }

            Transaction.DisposeContext(context);
            return itemDto;
        }

        internal static ReviewSubTopicDto Delete(long id, bool cascade = false)
        {
            var context = Transaction.GetContext();

            if (cascade)
            {
                using (var transaction = context.Database.BeginTransaction())
                {
                    var dbItem = context.ReviewSubTopic.FirstOrDefault(p => p.Id == id);
                    if (dbItem != null)
                    {   
                        context.ReviewSubTopic.Remove(dbItem);
                        context.SaveChanges();

                        transaction.Commit();
                    }
                }
            }
            else
            {
                var dbItem = context.ReviewSubTopic.FirstOrDefault(p => p.Id == id);
                if (dbItem != null)
                {
                    context.ReviewSubTopic.Remove(dbItem);
                    context.SaveChanges();
                }
            }

            Transaction.DisposeContext(context);

            return null;
        }
    }

    internal static class ReviewSubTopicExtensions
    {
        internal static void Assign(this ReviewSubTopic destination, IReviewSubTopic source, bool includeNavigation = false)
        {
            ReviewSubTopic.Assign(source, destination, includeNavigation);
        }
    }
}