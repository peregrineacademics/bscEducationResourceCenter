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
    public partial class LogSource : ILogSource
    {
        internal static void Assign(ILogSource source, ILogSource destination, bool includeNavigation = false)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));
            if (destination == null) throw new ArgumentNullException(nameof(destination));

			destination.Id = source.Id;
			destination.Name = source.Name;

			if (includeNavigation)
			{
				destination.Log = source.Log;
			}
        }

        internal static LogSourceDto Create(LogSourceDto itemDto)
        {
            var context = Transaction.GetContext();

            var dbItem = new LogSource();
            dbItem.Assign(itemDto);
            context.LogSource.Add(dbItem);
            context.SaveChanges();

            itemDto.Assign(dbItem);

            Transaction.DisposeContext(context);

            return itemDto;
        }

        internal static LogSourceDto Get(long id, bool includeNavigation = false)
        {
            using (var context = Transaction.GetContext(true))
            {
                ILogSource dbItem;
                if (includeNavigation)
                    dbItem = context.LogSource
								.Include(n=>n.Log).FirstOrDefault(p => p.Id == id);                
                else
                    dbItem = context.LogSource.FirstOrDefault(p => p.Id == id);

                return (dbItem != null) ? new LogSourceDto(dbItem, includeNavigation) : null;
            }
        }

        internal static List<LogSourceDto> Select(Expression<Func<ILogSource, bool>> whereClause = null, bool includeNavigation = false)
        {
            using (var context = Transaction.GetContext(true))
            {
                IQueryable<ILogSource> dbItems;

                var results = new List<LogSourceDto>();

                if (whereClause == null)
                    return Select(includeNavigation);

                if (includeNavigation)
                    dbItems = context.LogSource.Where(whereClause)
								.Include(n=>n.Log);
                else
                    dbItems = context.LogSource.Where(whereClause);

                if (dbItems.Any())
                {
                    dbItems.ToList()
                        .ForEach(o =>
                        {
                            var dto = new LogSourceDto("Id will be filled in the Assign statement");
                            dto.Assign(o, includeNavigation);
                            results.Add(dto);
                        });
                }
                return results;
            }
        }

        internal static List<LogSourceDto> Select(bool includeNavigation = false)
        {
            using (var context = Transaction.GetContext(true))
            {
                IQueryable<ILogSource> dbItems;
                var results = new List<LogSourceDto>();

                if (includeNavigation)
                    dbItems = context.LogSource
								.Include(n=>n.Log);
                else
                    dbItems = context.LogSource;

                if (dbItems.Any())
                    dbItems.ToList()
                        .ForEach(o =>
                        {
                            var dto = new LogSourceDto("Id will be filled in the Assign statement");
                            dto.Assign(o, includeNavigation);
                            results.Add(dto);
                        });
                return results;
            }
        }

        internal static LogSourceDto Update(LogSourceDto itemDto)
        {
            var context = Transaction.GetContext();

            var id = itemDto.Id;
            var dbItem = context.LogSource.FirstOrDefault(o => o.Id == id);
            if (dbItem != null)
            {
                dbItem.Assign(itemDto);
                context.SaveChanges();
                itemDto.Assign(dbItem);
            }

            Transaction.DisposeContext(context);
            return itemDto;
        }

        internal static LogSourceDto Delete(long id, bool cascade = false)
        {
            var context = Transaction.GetContext();

            if (cascade)
            {
                using (var transaction = context.Database.BeginTransaction())
                {
                    var dbItem = context.LogSource
									.Include(n=>n.Log).FirstOrDefault(p => p.Id == id);
                    if (dbItem != null)
                    {   
						if (dbItem.Log.Count > 0)
							context.Log.RemoveRange(dbItem.Log);

                        context.LogSource.Remove(dbItem);
                        context.SaveChanges();

                        transaction.Commit();
                    }
                }
            }
            else
            {
                var dbItem = context.LogSource.FirstOrDefault(p => p.Id == id);
                if (dbItem != null)
                {
                    context.LogSource.Remove(dbItem);
                    context.SaveChanges();
                }
            }

            Transaction.DisposeContext(context);

            return null;
        }
    }

    internal static class LogSourceExtensions
    {
        internal static void Assign(this LogSource destination, ILogSource source, bool includeNavigation = false)
        {
            LogSource.Assign(source, destination, includeNavigation);
        }
    }
}