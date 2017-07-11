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
    public partial class ReviewCategory : IReviewCategory
    {
        internal static void Assign(IReviewCategory source, IReviewCategory destination, bool includeNavigation = false)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));
            if (destination == null) throw new ArgumentNullException(nameof(destination));

			destination.Categoryid = source.Categoryid;
			destination.Id = source.Id;
			destination.ReviewId = source.ReviewId;

			if (includeNavigation)
			{
				destination.Category = source.Category;
				destination.Review = source.Review;
			}
        }

        internal static ReviewCategoryDto Create(ReviewCategoryDto itemDto)
        {
            var context = Transaction.GetContext();

            var dbItem = new ReviewCategory();
            dbItem.Assign(itemDto);
            context.ReviewCategory.Add(dbItem);
            context.SaveChanges();

            itemDto.Assign(dbItem);

            Transaction.DisposeContext(context);

            return itemDto;
        }

        internal static ReviewCategoryDto Get(long id, bool includeNavigation = false)
        {
            using (var context = Transaction.GetContext(true))
            {
                IReviewCategory dbItem;
                if (includeNavigation)
                    dbItem = context.ReviewCategory
								.Include(n=>n.Category)
								.Include(n=>n.Review).FirstOrDefault(p => p.Id == id);                
                else
                    dbItem = context.ReviewCategory.FirstOrDefault(p => p.Id == id);

                return (dbItem != null) ? new ReviewCategoryDto(dbItem, includeNavigation) : null;
            }
        }

        internal static List<ReviewCategoryDto> Select(Expression<Func<IReviewCategory, bool>> whereClause = null, bool includeNavigation = false)
        {
            using (var context = Transaction.GetContext(true))
            {
                IQueryable<IReviewCategory> dbItems;

                var results = new List<ReviewCategoryDto>();

                if (whereClause == null)
                    return Select(includeNavigation);

                if (includeNavigation)
                    dbItems = context.ReviewCategory.Where(whereClause)
								.Include(n=>n.Category)
								.Include(n=>n.Review);
                else
                    dbItems = context.ReviewCategory.Where(whereClause);

                if (dbItems.Any())
                {
                    dbItems.ToList()
                        .ForEach(o =>
                        {
                            var dto = new ReviewCategoryDto("Id will be filled in the Assign statement");
                            dto.Assign(o, includeNavigation);
                            results.Add(dto);
                        });
                }
                return results;
            }
        }

        internal static List<ReviewCategoryDto> Select(bool includeNavigation = false)
        {
            using (var context = Transaction.GetContext(true))
            {
                IQueryable<IReviewCategory> dbItems;
                var results = new List<ReviewCategoryDto>();

                if (includeNavigation)
                    dbItems = context.ReviewCategory
								.Include(n=>n.Category)
								.Include(n=>n.Review);
                else
                    dbItems = context.ReviewCategory;

                if (dbItems.Any())
                    dbItems.ToList()
                        .ForEach(o =>
                        {
                            var dto = new ReviewCategoryDto("Id will be filled in the Assign statement");
                            dto.Assign(o, includeNavigation);
                            results.Add(dto);
                        });
                return results;
            }
        }

        internal static ReviewCategoryDto Update(ReviewCategoryDto itemDto)
        {
            var context = Transaction.GetContext();

            var id = itemDto.Id;
            var dbItem = context.ReviewCategory.FirstOrDefault(o => o.Id == id);
            if (dbItem != null)
            {
                dbItem.Assign(itemDto);
                context.SaveChanges();
                itemDto.Assign(dbItem);
            }

            Transaction.DisposeContext(context);
            return itemDto;
        }

        internal static ReviewCategoryDto Delete(long id, bool cascade = false)
        {
            var context = Transaction.GetContext();

            if (cascade)
            {
                using (var transaction = context.Database.BeginTransaction())
                {
                    var dbItem = context.ReviewCategory.FirstOrDefault(p => p.Id == id);
                    if (dbItem != null)
                    {   
                        context.ReviewCategory.Remove(dbItem);
                        context.SaveChanges();

                        transaction.Commit();
                    }
                }
            }
            else
            {
                var dbItem = context.ReviewCategory.FirstOrDefault(p => p.Id == id);
                if (dbItem != null)
                {
                    context.ReviewCategory.Remove(dbItem);
                    context.SaveChanges();
                }
            }

            Transaction.DisposeContext(context);

            return null;
        }
    }

    internal static class ReviewCategoryExtensions
    {
        internal static void Assign(this ReviewCategory destination, IReviewCategory source, bool includeNavigation = false)
        {
            ReviewCategory.Assign(source, destination, includeNavigation);
        }
    }
}