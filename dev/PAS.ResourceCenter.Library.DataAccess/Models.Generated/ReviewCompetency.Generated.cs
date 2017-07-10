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
    public partial class ReviewCompetency : IReviewCompetency
    {
        internal static void Assign(IReviewCompetency source, IReviewCompetency destination, bool includeNavigation = false)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));
            if (destination == null) throw new ArgumentNullException(nameof(destination));

			destination.CompetencyId = source.CompetencyId;
			destination.Id = source.Id;
			destination.ReviewId = source.ReviewId;

			if (includeNavigation)
			{
				destination.Competency = source.Competency;
				destination.Review = source.Review;
			}
        }

        internal static ReviewCompetencyDto Create(ReviewCompetencyDto itemDto)
        {
            var context = Transaction.GetContext();

            var dbItem = new ReviewCompetency();
            dbItem.Assign(itemDto);
            context.ReviewCompetency.Add(dbItem);
            context.SaveChanges();

            itemDto.Assign(dbItem);

            Transaction.DisposeContext(context);

            return itemDto;
        }

        internal static ReviewCompetencyDto Get(long id, bool includeNavigation = false)
        {
            using (var context = Transaction.GetContext(true))
            {
                IReviewCompetency dbItem;
                if (includeNavigation)
                    dbItem = context.ReviewCompetency
								.Include(n=>n.Competency)
								.Include(n=>n.Review).FirstOrDefault(p => p.Id == id);                
                else
                    dbItem = context.ReviewCompetency.FirstOrDefault(p => p.Id == id);

                return (dbItem != null) ? new ReviewCompetencyDto(dbItem, includeNavigation) : null;
            }
        }

        internal static List<ReviewCompetencyDto> Select(Expression<Func<IReviewCompetency, bool>> whereClause = null, bool includeNavigation = false)
        {
            using (var context = Transaction.GetContext(true))
            {
                IQueryable<IReviewCompetency> dbItems;

                var results = new List<ReviewCompetencyDto>();

                if (whereClause == null)
                    return Select(includeNavigation);

                if (includeNavigation)
                    dbItems = context.ReviewCompetency.Where(whereClause)
								.Include(n=>n.Competency)
								.Include(n=>n.Review);
                else
                    dbItems = context.ReviewCompetency.Where(whereClause);

                if (dbItems.Any())
                {
                    dbItems.ToList()
                        .ForEach(o =>
                        {
                            var dto = new ReviewCompetencyDto("Id will be filled in the Assign statement");
                            dto.Assign(o, includeNavigation);
                            results.Add(dto);
                        });
                }
                return results;
            }
        }

        internal static List<ReviewCompetencyDto> Select(bool includeNavigation = false)
        {
            using (var context = Transaction.GetContext(true))
            {
                IQueryable<IReviewCompetency> dbItems;
                var results = new List<ReviewCompetencyDto>();

                if (includeNavigation)
                    dbItems = context.ReviewCompetency
								.Include(n=>n.Competency)
								.Include(n=>n.Review);
                else
                    dbItems = context.ReviewCompetency;

                if (dbItems.Any())
                    dbItems.ToList()
                        .ForEach(o =>
                        {
                            var dto = new ReviewCompetencyDto("Id will be filled in the Assign statement");
                            dto.Assign(o, includeNavigation);
                            results.Add(dto);
                        });
                return results;
            }
        }

        internal static ReviewCompetencyDto Update(ReviewCompetencyDto itemDto)
        {
            var context = Transaction.GetContext();

            var id = itemDto.Id;
            var dbItem = context.ReviewCompetency.FirstOrDefault(o => o.Id == id);
            if (dbItem != null)
            {
                dbItem.Assign(itemDto);
                context.SaveChanges();
                itemDto.Assign(dbItem);
            }

            Transaction.DisposeContext(context);
            return itemDto;
        }

        internal static ReviewCompetencyDto Delete(long id, bool cascade = false)
        {
            var context = Transaction.GetContext();

            if (cascade)
            {
                using (var transaction = context.Database.BeginTransaction())
                {
                    var dbItem = context.ReviewCompetency.FirstOrDefault(p => p.Id == id);
                    if (dbItem != null)
                    {   
                        context.ReviewCompetency.Remove(dbItem);
                        context.SaveChanges();

                        transaction.Commit();
                    }
                }
            }
            else
            {
                var dbItem = context.ReviewCompetency.FirstOrDefault(p => p.Id == id);
                if (dbItem != null)
                {
                    context.ReviewCompetency.Remove(dbItem);
                    context.SaveChanges();
                }
            }

            Transaction.DisposeContext(context);

            return null;
        }
    }

    internal static class ReviewCompetencyExtensions
    {
        internal static void Assign(this ReviewCompetency destination, IReviewCompetency source, bool includeNavigation = false)
        {
            ReviewCompetency.Assign(source, destination, includeNavigation);
        }
    }
}