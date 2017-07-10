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
    public partial class Discipline : IDiscipline
    {
        internal static void Assign(IDiscipline source, IDiscipline destination, bool includeNavigation = false)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));
            if (destination == null) throw new ArgumentNullException(nameof(destination));

			destination.Id = source.Id;
			destination.IsEnabled = source.IsEnabled;
			destination.Name = source.Name;

			if (includeNavigation)
			{
				destination.ReviewDiscipline = source.ReviewDiscipline;
				destination.SubTopic = source.SubTopic;
			}
        }

        internal static DisciplineDto Create(DisciplineDto itemDto)
        {
            var context = Transaction.GetContext();

            var dbItem = new Discipline();
            dbItem.Assign(itemDto);
            context.Discipline.Add(dbItem);
            context.SaveChanges();

            itemDto.Assign(dbItem);

            Transaction.DisposeContext(context);

            return itemDto;
        }

        internal static DisciplineDto Get(long id, bool includeNavigation = false)
        {
            using (var context = Transaction.GetContext(true))
            {
                IDiscipline dbItem;
                if (includeNavigation)
                    dbItem = context.Discipline
								.Include(n=>n.ReviewDiscipline)
								.Include(n=>n.SubTopic).FirstOrDefault(p => p.Id == id);                
                else
                    dbItem = context.Discipline.FirstOrDefault(p => p.Id == id);

                return (dbItem != null) ? new DisciplineDto(dbItem, includeNavigation) : null;
            }
        }

        internal static List<DisciplineDto> Select(Expression<Func<IDiscipline, bool>> whereClause = null, bool includeNavigation = false)
        {
            using (var context = Transaction.GetContext(true))
            {
                IQueryable<IDiscipline> dbItems;

                var results = new List<DisciplineDto>();

                if (whereClause == null)
                    return Select(includeNavigation);

                if (includeNavigation)
                    dbItems = context.Discipline.Where(whereClause)
								.Include(n=>n.ReviewDiscipline)
								.Include(n=>n.SubTopic);
                else
                    dbItems = context.Discipline.Where(whereClause);

                if (dbItems.Any())
                {
                    dbItems.ToList()
                        .ForEach(o =>
                        {
                            var dto = new DisciplineDto("Id will be filled in the Assign statement");
                            dto.Assign(o, includeNavigation);
                            results.Add(dto);
                        });
                }
                return results;
            }
        }

        internal static List<DisciplineDto> Select(bool includeNavigation = false)
        {
            using (var context = Transaction.GetContext(true))
            {
                IQueryable<IDiscipline> dbItems;
                var results = new List<DisciplineDto>();

                if (includeNavigation)
                    dbItems = context.Discipline
								.Include(n=>n.ReviewDiscipline)
								.Include(n=>n.SubTopic);
                else
                    dbItems = context.Discipline;

                if (dbItems.Any())
                    dbItems.ToList()
                        .ForEach(o =>
                        {
                            var dto = new DisciplineDto("Id will be filled in the Assign statement");
                            dto.Assign(o, includeNavigation);
                            results.Add(dto);
                        });
                return results;
            }
        }

        internal static DisciplineDto Update(DisciplineDto itemDto)
        {
            var context = Transaction.GetContext();

            var id = itemDto.Id;
            var dbItem = context.Discipline.FirstOrDefault(o => o.Id == id);
            if (dbItem != null)
            {
                dbItem.Assign(itemDto);
                context.SaveChanges();
                itemDto.Assign(dbItem);
            }

            Transaction.DisposeContext(context);
            return itemDto;
        }

        internal static DisciplineDto Delete(long id, bool cascade = false)
        {
            var context = Transaction.GetContext();

            if (cascade)
            {
                using (var transaction = context.Database.BeginTransaction())
                {
                    var dbItem = context.Discipline
									.Include(n=>n.ReviewDiscipline)
									.Include(n=>n.SubTopic).FirstOrDefault(p => p.Id == id);
                    if (dbItem != null)
                    {   
						if (dbItem.ReviewDiscipline.Count > 0)
							context.ReviewDiscipline.RemoveRange(dbItem.ReviewDiscipline);
						if (dbItem.SubTopic.Count > 0)
							context.SubTopic.RemoveRange(dbItem.SubTopic);

                        context.Discipline.Remove(dbItem);
                        context.SaveChanges();

                        transaction.Commit();
                    }
                }
            }
            else
            {
                var dbItem = context.Discipline.FirstOrDefault(p => p.Id == id);
                if (dbItem != null)
                {
                    context.Discipline.Remove(dbItem);
                    context.SaveChanges();
                }
            }

            Transaction.DisposeContext(context);

            return null;
        }
    }

    internal static class DisciplineExtensions
    {
        internal static void Assign(this Discipline destination, IDiscipline source, bool includeNavigation = false)
        {
            Discipline.Assign(source, destination, includeNavigation);
        }
    }
}