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
    public partial class Competency : ICompetency
    {
        internal static void Assign(ICompetency source, ICompetency destination, bool includeNavigation = false)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));
            if (destination == null) throw new ArgumentNullException(nameof(destination));

			destination.Id = source.Id;
			destination.IsEnabled = source.IsEnabled;
			destination.Name = source.Name;

			if (includeNavigation)
			{
				destination.ReviewCompetency = source.ReviewCompetency;
			}
        }

        internal static CompetencyDto Create(CompetencyDto itemDto)
        {
            var context = Transaction.GetContext();

            var dbItem = new Competency();
            dbItem.Assign(itemDto);
            context.Competency.Add(dbItem);
            context.SaveChanges();

            itemDto.Assign(dbItem);

            Transaction.DisposeContext(context);

            return itemDto;
        }

        internal static CompetencyDto Get(long id, bool includeNavigation = false)
        {
            using (var context = Transaction.GetContext(true))
            {
                ICompetency dbItem;
                if (includeNavigation)
                    dbItem = context.Competency
								.Include(n=>n.ReviewCompetency).FirstOrDefault(p => p.Id == id);                
                else
                    dbItem = context.Competency.FirstOrDefault(p => p.Id == id);

                return (dbItem != null) ? new CompetencyDto(dbItem, includeNavigation) : null;
            }
        }

        internal static List<CompetencyDto> Select(Expression<Func<ICompetency, bool>> whereClause = null, bool includeNavigation = false)
        {
            using (var context = Transaction.GetContext(true))
            {
                IQueryable<ICompetency> dbItems;

                var results = new List<CompetencyDto>();

                if (whereClause == null)
                    return Select(includeNavigation);

                if (includeNavigation)
                    dbItems = context.Competency.Where(whereClause)
								.Include(n=>n.ReviewCompetency);
                else
                    dbItems = context.Competency.Where(whereClause);

                if (dbItems.Any())
                {
                    dbItems.ToList()
                        .ForEach(o =>
                        {
                            var dto = new CompetencyDto("Id will be filled in the Assign statement");
                            dto.Assign(o, includeNavigation);
                            results.Add(dto);
                        });
                }
                return results;
            }
        }

        internal static List<CompetencyDto> Select(bool includeNavigation = false)
        {
            using (var context = Transaction.GetContext(true))
            {
                IQueryable<ICompetency> dbItems;
                var results = new List<CompetencyDto>();

                if (includeNavigation)
                    dbItems = context.Competency
								.Include(n=>n.ReviewCompetency);
                else
                    dbItems = context.Competency;

                if (dbItems.Any())
                    dbItems.ToList()
                        .ForEach(o =>
                        {
                            var dto = new CompetencyDto("Id will be filled in the Assign statement");
                            dto.Assign(o, includeNavigation);
                            results.Add(dto);
                        });
                return results;
            }
        }

        internal static CompetencyDto Update(CompetencyDto itemDto)
        {
            var context = Transaction.GetContext();

            var id = itemDto.Id;
            var dbItem = context.Competency.FirstOrDefault(o => o.Id == id);
            if (dbItem != null)
            {
                dbItem.Assign(itemDto);
                context.SaveChanges();
                itemDto.Assign(dbItem);
            }

            Transaction.DisposeContext(context);
            return itemDto;
        }

        internal static CompetencyDto Delete(long id, bool cascade = false)
        {
            var context = Transaction.GetContext();

            if (cascade)
            {
                using (var transaction = context.Database.BeginTransaction())
                {
                    var dbItem = context.Competency
									.Include(n=>n.ReviewCompetency).FirstOrDefault(p => p.Id == id);
                    if (dbItem != null)
                    {   
						if (dbItem.ReviewCompetency.Count > 0)
							context.ReviewCompetency.RemoveRange(dbItem.ReviewCompetency);

                        context.Competency.Remove(dbItem);
                        context.SaveChanges();

                        transaction.Commit();
                    }
                }
            }
            else
            {
                var dbItem = context.Competency.FirstOrDefault(p => p.Id == id);
                if (dbItem != null)
                {
                    context.Competency.Remove(dbItem);
                    context.SaveChanges();
                }
            }

            Transaction.DisposeContext(context);

            return null;
        }
    }

    internal static class CompetencyExtensions
    {
        internal static void Assign(this Competency destination, ICompetency source, bool includeNavigation = false)
        {
            Competency.Assign(source, destination, includeNavigation);
        }
    }
}