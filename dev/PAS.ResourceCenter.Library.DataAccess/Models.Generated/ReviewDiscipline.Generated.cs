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
    public partial class ReviewDiscipline : IReviewDiscipline
    {
        internal static void Assign(IReviewDiscipline source, IReviewDiscipline destination, bool includeNavigation = false)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));
            if (destination == null) throw new ArgumentNullException(nameof(destination));

			destination.DisciplineId = source.DisciplineId;
			destination.Id = source.Id;
			destination.ReviewId = source.ReviewId;

			if (includeNavigation)
			{
				destination.Discipline = source.Discipline;
				destination.Review = source.Review;
			}
        }

        internal static ReviewDisciplineDto Create(ReviewDisciplineDto itemDto)
        {
            var context = Transaction.GetContext();

            var dbItem = new ReviewDiscipline();
            dbItem.Assign(itemDto);
            context.ReviewDiscipline.Add(dbItem);
            context.SaveChanges();

            itemDto.Assign(dbItem);

            Transaction.DisposeContext(context);

            return itemDto;
        }

        internal static ReviewDisciplineDto Get(long id, bool includeNavigation = false)
        {
            using (var context = Transaction.GetContext(true))
            {
                IReviewDiscipline dbItem;
                if (includeNavigation)
                    dbItem = context.ReviewDiscipline
								.Include(n=>n.Discipline)
								.Include(n=>n.Review).FirstOrDefault(p => p.Id == id);                
                else
                    dbItem = context.ReviewDiscipline.FirstOrDefault(p => p.Id == id);

                return (dbItem != null) ? new ReviewDisciplineDto(dbItem, includeNavigation) : null;
            }
        }

        internal static List<ReviewDisciplineDto> Select(Expression<Func<IReviewDiscipline, bool>> whereClause = null, bool includeNavigation = false)
        {
            using (var context = Transaction.GetContext(true))
            {
                IQueryable<IReviewDiscipline> dbItems;

                var results = new List<ReviewDisciplineDto>();

                if (whereClause == null)
                    return Select(includeNavigation);

                if (includeNavigation)
                    dbItems = context.ReviewDiscipline.Where(whereClause)
								.Include(n=>n.Discipline)
								.Include(n=>n.Review);
                else
                    dbItems = context.ReviewDiscipline.Where(whereClause);

                if (dbItems.Any())
                {
                    dbItems.ToList()
                        .ForEach(o =>
                        {
                            var dto = new ReviewDisciplineDto("Id will be filled in the Assign statement");
                            dto.Assign(o, includeNavigation);
                            results.Add(dto);
                        });
                }
                return results;
            }
        }

        internal static List<ReviewDisciplineDto> Select(bool includeNavigation = false)
        {
            using (var context = Transaction.GetContext(true))
            {
                IQueryable<IReviewDiscipline> dbItems;
                var results = new List<ReviewDisciplineDto>();

                if (includeNavigation)
                    dbItems = context.ReviewDiscipline
								.Include(n=>n.Discipline)
								.Include(n=>n.Review);
                else
                    dbItems = context.ReviewDiscipline;

                if (dbItems.Any())
                    dbItems.ToList()
                        .ForEach(o =>
                        {
                            var dto = new ReviewDisciplineDto("Id will be filled in the Assign statement");
                            dto.Assign(o, includeNavigation);
                            results.Add(dto);
                        });
                return results;
            }
        }

        internal static ReviewDisciplineDto Update(ReviewDisciplineDto itemDto)
        {
            var context = Transaction.GetContext();

            var id = itemDto.Id;
            var dbItem = context.ReviewDiscipline.FirstOrDefault(o => o.Id == id);
            if (dbItem != null)
            {
                dbItem.Assign(itemDto);
                context.SaveChanges();
                itemDto.Assign(dbItem);
            }

            Transaction.DisposeContext(context);
            return itemDto;
        }

        internal static ReviewDisciplineDto Delete(long id, bool cascade = false)
        {
            var context = Transaction.GetContext();

            if (cascade)
            {
                using (var transaction = context.Database.BeginTransaction())
                {
                    var dbItem = context.ReviewDiscipline.FirstOrDefault(p => p.Id == id);
                    if (dbItem != null)
                    {   
                        context.ReviewDiscipline.Remove(dbItem);
                        context.SaveChanges();

                        transaction.Commit();
                    }
                }
            }
            else
            {
                var dbItem = context.ReviewDiscipline.FirstOrDefault(p => p.Id == id);
                if (dbItem != null)
                {
                    context.ReviewDiscipline.Remove(dbItem);
                    context.SaveChanges();
                }
            }

            Transaction.DisposeContext(context);

            return null;
        }
    }

    internal static class ReviewDisciplineExtensions
    {
        internal static void Assign(this ReviewDiscipline destination, IReviewDiscipline source, bool includeNavigation = false)
        {
            ReviewDiscipline.Assign(source, destination, includeNavigation);
        }
    }
}