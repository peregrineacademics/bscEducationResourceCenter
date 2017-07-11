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
    public partial class ReviewActivity : IReviewActivity
    {
        internal static void Assign(IReviewActivity source, IReviewActivity destination, bool includeNavigation = false)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));
            if (destination == null) throw new ArgumentNullException(nameof(destination));

			destination.Activity = source.Activity;
			destination.Id = source.Id;
			destination.Ordinal = source.Ordinal;
			destination.ReviewId = source.ReviewId;

        }

        internal static ReviewActivityDto Create(ReviewActivityDto itemDto)
        {
            var context = Transaction.GetContext();

            var dbItem = new ReviewActivity();
            dbItem.Assign(itemDto);
            context.ReviewActivity.Add(dbItem);
            context.SaveChanges();

            itemDto.Assign(dbItem);

            Transaction.DisposeContext(context);

            return itemDto;
        }

        internal static ReviewActivityDto Get(long id, bool includeNavigation = false)
        {
            using (var context = Transaction.GetContext(true))
            {
                IReviewActivity dbItem;
                if (includeNavigation)
                    dbItem = context.ReviewActivity.FirstOrDefault(p => p.Id == id);                
                else
                    dbItem = context.ReviewActivity.FirstOrDefault(p => p.Id == id);

                return (dbItem != null) ? new ReviewActivityDto(dbItem, includeNavigation) : null;
            }
        }

        internal static List<ReviewActivityDto> Select(Expression<Func<IReviewActivity, bool>> whereClause = null, bool includeNavigation = false)
        {
            using (var context = Transaction.GetContext(true))
            {
                IQueryable<IReviewActivity> dbItems;

                var results = new List<ReviewActivityDto>();

                if (whereClause == null)
                    return Select(includeNavigation);

                if (includeNavigation)
                    dbItems = context.ReviewActivity.Where(whereClause);
                else
                    dbItems = context.ReviewActivity.Where(whereClause);

                if (dbItems.Any())
                {
                    dbItems.ToList()
                        .ForEach(o =>
                        {
                            var dto = new ReviewActivityDto("Id will be filled in the Assign statement");
                            dto.Assign(o, includeNavigation);
                            results.Add(dto);
                        });
                }
                return results;
            }
        }

        internal static List<ReviewActivityDto> Select(bool includeNavigation = false)
        {
            using (var context = Transaction.GetContext(true))
            {
                IQueryable<IReviewActivity> dbItems;
                var results = new List<ReviewActivityDto>();

                if (includeNavigation)
                    dbItems = context.ReviewActivity;
                else
                    dbItems = context.ReviewActivity;

                if (dbItems.Any())
                    dbItems.ToList()
                        .ForEach(o =>
                        {
                            var dto = new ReviewActivityDto("Id will be filled in the Assign statement");
                            dto.Assign(o, includeNavigation);
                            results.Add(dto);
                        });
                return results;
            }
        }

        internal static ReviewActivityDto Update(ReviewActivityDto itemDto)
        {
            var context = Transaction.GetContext();

            var id = itemDto.Id;
            var dbItem = context.ReviewActivity.FirstOrDefault(o => o.Id == id);
            if (dbItem != null)
            {
                dbItem.Assign(itemDto);
                context.SaveChanges();
                itemDto.Assign(dbItem);
            }

            Transaction.DisposeContext(context);
            return itemDto;
        }

        internal static ReviewActivityDto Delete(long id, bool cascade = false)
        {
            var context = Transaction.GetContext();

            if (cascade)
            {
                using (var transaction = context.Database.BeginTransaction())
                {
                    var dbItem = context.ReviewActivity.FirstOrDefault(p => p.Id == id);
                    if (dbItem != null)
                    {   
                        context.ReviewActivity.Remove(dbItem);
                        context.SaveChanges();

                        transaction.Commit();
                    }
                }
            }
            else
            {
                var dbItem = context.ReviewActivity.FirstOrDefault(p => p.Id == id);
                if (dbItem != null)
                {
                    context.ReviewActivity.Remove(dbItem);
                    context.SaveChanges();
                }
            }

            Transaction.DisposeContext(context);

            return null;
        }
    }

    internal static class ReviewActivityExtensions
    {
        internal static void Assign(this ReviewActivity destination, IReviewActivity source, bool includeNavigation = false)
        {
            ReviewActivity.Assign(source, destination, includeNavigation);
        }
    }
}