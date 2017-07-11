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
    public partial class ReviewerCategory : IReviewerCategory
    {
        internal static void Assign(IReviewerCategory source, IReviewerCategory destination, bool includeNavigation = false)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));
            if (destination == null) throw new ArgumentNullException(nameof(destination));

			destination.Categoryid = source.Categoryid;
			destination.Id = source.Id;
			destination.UserId = source.UserId;

			if (includeNavigation)
			{
				destination.Category = source.Category;
				destination.User = source.User;
			}
        }

        internal static ReviewerCategoryDto Create(ReviewerCategoryDto itemDto)
        {
            var context = Transaction.GetContext();

            var dbItem = new ReviewerCategory();
            dbItem.Assign(itemDto);
            context.ReviewerCategory.Add(dbItem);
            context.SaveChanges();

            itemDto.Assign(dbItem);

            Transaction.DisposeContext(context);

            return itemDto;
        }

        internal static ReviewerCategoryDto Get(long id, bool includeNavigation = false)
        {
            using (var context = Transaction.GetContext(true))
            {
                IReviewerCategory dbItem;
                if (includeNavigation)
                    dbItem = context.ReviewerCategory
								.Include(n=>n.Category)
								.Include(n=>n.User).FirstOrDefault(p => p.Id == id);                
                else
                    dbItem = context.ReviewerCategory.FirstOrDefault(p => p.Id == id);

                return (dbItem != null) ? new ReviewerCategoryDto(dbItem, includeNavigation) : null;
            }
        }

        internal static List<ReviewerCategoryDto> Select(Expression<Func<IReviewerCategory, bool>> whereClause = null, bool includeNavigation = false)
        {
            using (var context = Transaction.GetContext(true))
            {
                IQueryable<IReviewerCategory> dbItems;

                var results = new List<ReviewerCategoryDto>();

                if (whereClause == null)
                    return Select(includeNavigation);

                if (includeNavigation)
                    dbItems = context.ReviewerCategory.Where(whereClause)
								.Include(n=>n.Category)
								.Include(n=>n.User);
                else
                    dbItems = context.ReviewerCategory.Where(whereClause);

                if (dbItems.Any())
                {
                    dbItems.ToList()
                        .ForEach(o =>
                        {
                            var dto = new ReviewerCategoryDto("Id will be filled in the Assign statement");
                            dto.Assign(o, includeNavigation);
                            results.Add(dto);
                        });
                }
                return results;
            }
        }

        internal static List<ReviewerCategoryDto> Select(bool includeNavigation = false)
        {
            using (var context = Transaction.GetContext(true))
            {
                IQueryable<IReviewerCategory> dbItems;
                var results = new List<ReviewerCategoryDto>();

                if (includeNavigation)
                    dbItems = context.ReviewerCategory
								.Include(n=>n.Category)
								.Include(n=>n.User);
                else
                    dbItems = context.ReviewerCategory;

                if (dbItems.Any())
                    dbItems.ToList()
                        .ForEach(o =>
                        {
                            var dto = new ReviewerCategoryDto("Id will be filled in the Assign statement");
                            dto.Assign(o, includeNavigation);
                            results.Add(dto);
                        });
                return results;
            }
        }

        internal static ReviewerCategoryDto Update(ReviewerCategoryDto itemDto)
        {
            var context = Transaction.GetContext();

            var id = itemDto.Id;
            var dbItem = context.ReviewerCategory.FirstOrDefault(o => o.Id == id);
            if (dbItem != null)
            {
                dbItem.Assign(itemDto);
                context.SaveChanges();
                itemDto.Assign(dbItem);
            }

            Transaction.DisposeContext(context);
            return itemDto;
        }

        internal static ReviewerCategoryDto Delete(long id, bool cascade = false)
        {
            var context = Transaction.GetContext();

            if (cascade)
            {
                using (var transaction = context.Database.BeginTransaction())
                {
                    var dbItem = context.ReviewerCategory.FirstOrDefault(p => p.Id == id);
                    if (dbItem != null)
                    {   
                        context.ReviewerCategory.Remove(dbItem);
                        context.SaveChanges();

                        transaction.Commit();
                    }
                }
            }
            else
            {
                var dbItem = context.ReviewerCategory.FirstOrDefault(p => p.Id == id);
                if (dbItem != null)
                {
                    context.ReviewerCategory.Remove(dbItem);
                    context.SaveChanges();
                }
            }

            Transaction.DisposeContext(context);

            return null;
        }
    }

    internal static class ReviewerCategoryExtensions
    {
        internal static void Assign(this ReviewerCategory destination, IReviewerCategory source, bool includeNavigation = false)
        {
            ReviewerCategory.Assign(source, destination, includeNavigation);
        }
    }
}