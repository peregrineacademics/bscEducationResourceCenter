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
    public partial class DiscussionQuestion : IDiscussionQuestion
    {
        internal static void Assign(IDiscussionQuestion source, IDiscussionQuestion destination, bool includeNavigation = false)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));
            if (destination == null) throw new ArgumentNullException(nameof(destination));

			destination.Id = source.Id;
			destination.Ordinal = source.Ordinal;
			destination.Question = source.Question;
			destination.ReviewId = source.ReviewId;

			if (includeNavigation)
			{
				destination.Review = source.Review;
			}
        }

        internal static DiscussionQuestionDto Create(DiscussionQuestionDto itemDto)
        {
            var context = Transaction.GetContext();

            var dbItem = new DiscussionQuestion();
            dbItem.Assign(itemDto);
            context.DiscussionQuestion.Add(dbItem);
            context.SaveChanges();

            itemDto.Assign(dbItem);

            Transaction.DisposeContext(context);

            return itemDto;
        }

        internal static DiscussionQuestionDto Get(long id, bool includeNavigation = false)
        {
            using (var context = Transaction.GetContext(true))
            {
                IDiscussionQuestion dbItem;
                if (includeNavigation)
                    dbItem = context.DiscussionQuestion
								.Include(n=>n.Review).FirstOrDefault(p => p.Id == id);                
                else
                    dbItem = context.DiscussionQuestion.FirstOrDefault(p => p.Id == id);

                return (dbItem != null) ? new DiscussionQuestionDto(dbItem, includeNavigation) : null;
            }
        }

        internal static List<DiscussionQuestionDto> Select(Expression<Func<IDiscussionQuestion, bool>> whereClause = null, bool includeNavigation = false)
        {
            using (var context = Transaction.GetContext(true))
            {
                IQueryable<IDiscussionQuestion> dbItems;

                var results = new List<DiscussionQuestionDto>();

                if (whereClause == null)
                    return Select(includeNavigation);

                if (includeNavigation)
                    dbItems = context.DiscussionQuestion.Where(whereClause)
								.Include(n=>n.Review);
                else
                    dbItems = context.DiscussionQuestion.Where(whereClause);

                if (dbItems.Any())
                {
                    dbItems.ToList()
                        .ForEach(o =>
                        {
                            var dto = new DiscussionQuestionDto("Id will be filled in the Assign statement");
                            dto.Assign(o, includeNavigation);
                            results.Add(dto);
                        });
                }
                return results;
            }
        }

        internal static List<DiscussionQuestionDto> Select(bool includeNavigation = false)
        {
            using (var context = Transaction.GetContext(true))
            {
                IQueryable<IDiscussionQuestion> dbItems;
                var results = new List<DiscussionQuestionDto>();

                if (includeNavigation)
                    dbItems = context.DiscussionQuestion
								.Include(n=>n.Review);
                else
                    dbItems = context.DiscussionQuestion;

                if (dbItems.Any())
                    dbItems.ToList()
                        .ForEach(o =>
                        {
                            var dto = new DiscussionQuestionDto("Id will be filled in the Assign statement");
                            dto.Assign(o, includeNavigation);
                            results.Add(dto);
                        });
                return results;
            }
        }

        internal static DiscussionQuestionDto Update(DiscussionQuestionDto itemDto)
        {
            var context = Transaction.GetContext();

            var id = itemDto.Id;
            var dbItem = context.DiscussionQuestion.FirstOrDefault(o => o.Id == id);
            if (dbItem != null)
            {
                dbItem.Assign(itemDto);
                context.SaveChanges();
                itemDto.Assign(dbItem);
            }

            Transaction.DisposeContext(context);
            return itemDto;
        }

        internal static DiscussionQuestionDto Delete(long id, bool cascade = false)
        {
            var context = Transaction.GetContext();

            if (cascade)
            {
                using (var transaction = context.Database.BeginTransaction())
                {
                    var dbItem = context.DiscussionQuestion.FirstOrDefault(p => p.Id == id);
                    if (dbItem != null)
                    {   
                        context.DiscussionQuestion.Remove(dbItem);
                        context.SaveChanges();

                        transaction.Commit();
                    }
                }
            }
            else
            {
                var dbItem = context.DiscussionQuestion.FirstOrDefault(p => p.Id == id);
                if (dbItem != null)
                {
                    context.DiscussionQuestion.Remove(dbItem);
                    context.SaveChanges();
                }
            }

            Transaction.DisposeContext(context);

            return null;
        }
    }

    internal static class DiscussionQuestionExtensions
    {
        internal static void Assign(this DiscussionQuestion destination, IDiscussionQuestion source, bool includeNavigation = false)
        {
            DiscussionQuestion.Assign(source, destination, includeNavigation);
        }
    }
}