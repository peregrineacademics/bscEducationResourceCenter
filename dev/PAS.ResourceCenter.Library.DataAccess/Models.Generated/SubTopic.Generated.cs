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
    public partial class SubTopic : ISubTopic
    {
        internal static void Assign(ISubTopic source, ISubTopic destination, bool includeNavigation = false)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));
            if (destination == null) throw new ArgumentNullException(nameof(destination));

			destination.DisciplineId = source.DisciplineId;
			destination.Id = source.Id;
			destination.IsEnabled = source.IsEnabled;
			destination.Name = source.Name;

			if (includeNavigation)
			{
				destination.Discipline = source.Discipline;
				destination.ReviewSubTopic = source.ReviewSubTopic;
			}
        }

        internal static SubTopicDto Create(SubTopicDto itemDto)
        {
            var context = Transaction.GetContext();

            var dbItem = new SubTopic();
            dbItem.Assign(itemDto);
            context.SubTopic.Add(dbItem);
            context.SaveChanges();

            itemDto.Assign(dbItem);

            Transaction.DisposeContext(context);

            return itemDto;
        }

        internal static SubTopicDto Get(long id, bool includeNavigation = false)
        {
            using (var context = Transaction.GetContext(true))
            {
                ISubTopic dbItem;
                if (includeNavigation)
                    dbItem = context.SubTopic
								.Include(n=>n.Discipline)
								.Include(n=>n.ReviewSubTopic).FirstOrDefault(p => p.Id == id);                
                else
                    dbItem = context.SubTopic.FirstOrDefault(p => p.Id == id);

                return (dbItem != null) ? new SubTopicDto(dbItem, includeNavigation) : null;
            }
        }

        internal static List<SubTopicDto> Select(Expression<Func<ISubTopic, bool>> whereClause = null, bool includeNavigation = false)
        {
            using (var context = Transaction.GetContext(true))
            {
                IQueryable<ISubTopic> dbItems;

                var results = new List<SubTopicDto>();

                if (whereClause == null)
                    return Select(includeNavigation);

                if (includeNavigation)
                    dbItems = context.SubTopic.Where(whereClause)
								.Include(n=>n.Discipline)
								.Include(n=>n.ReviewSubTopic);
                else
                    dbItems = context.SubTopic.Where(whereClause);

                if (dbItems.Any())
                {
                    dbItems.ToList()
                        .ForEach(o =>
                        {
                            var dto = new SubTopicDto("Id will be filled in the Assign statement");
                            dto.Assign(o, includeNavigation);
                            results.Add(dto);
                        });
                }
                return results;
            }
        }

        internal static List<SubTopicDto> Select(bool includeNavigation = false)
        {
            using (var context = Transaction.GetContext(true))
            {
                IQueryable<ISubTopic> dbItems;
                var results = new List<SubTopicDto>();

                if (includeNavigation)
                    dbItems = context.SubTopic
								.Include(n=>n.Discipline)
								.Include(n=>n.ReviewSubTopic);
                else
                    dbItems = context.SubTopic;

                if (dbItems.Any())
                    dbItems.ToList()
                        .ForEach(o =>
                        {
                            var dto = new SubTopicDto("Id will be filled in the Assign statement");
                            dto.Assign(o, includeNavigation);
                            results.Add(dto);
                        });
                return results;
            }
        }

        internal static SubTopicDto Update(SubTopicDto itemDto)
        {
            var context = Transaction.GetContext();

            var id = itemDto.Id;
            var dbItem = context.SubTopic.FirstOrDefault(o => o.Id == id);
            if (dbItem != null)
            {
                dbItem.Assign(itemDto);
                context.SaveChanges();
                itemDto.Assign(dbItem);
            }

            Transaction.DisposeContext(context);
            return itemDto;
        }

        internal static SubTopicDto Delete(long id, bool cascade = false)
        {
            var context = Transaction.GetContext();

            if (cascade)
            {
                using (var transaction = context.Database.BeginTransaction())
                {
                    var dbItem = context.SubTopic
									.Include(n=>n.ReviewSubTopic).FirstOrDefault(p => p.Id == id);
                    if (dbItem != null)
                    {   
						if (dbItem.ReviewSubTopic.Count > 0)
							context.ReviewSubTopic.RemoveRange(dbItem.ReviewSubTopic);

                        context.SubTopic.Remove(dbItem);
                        context.SaveChanges();

                        transaction.Commit();
                    }
                }
            }
            else
            {
                var dbItem = context.SubTopic.FirstOrDefault(p => p.Id == id);
                if (dbItem != null)
                {
                    context.SubTopic.Remove(dbItem);
                    context.SaveChanges();
                }
            }

            Transaction.DisposeContext(context);

            return null;
        }
    }

    internal static class SubTopicExtensions
    {
        internal static void Assign(this SubTopic destination, ISubTopic source, bool includeNavigation = false)
        {
            SubTopic.Assign(source, destination, includeNavigation);
        }
    }
}