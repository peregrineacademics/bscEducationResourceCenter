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
    public partial class LogType : ILogType
    {
        internal static void Assign(ILogType source, ILogType destination, bool includeNavigation = false)
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

        internal static LogTypeDto Create(LogTypeDto itemDto)
        {
            var context = Transaction.GetContext();

            var dbItem = new LogType();
            dbItem.Assign(itemDto);
            context.LogType.Add(dbItem);
            context.SaveChanges();

            itemDto.Assign(dbItem);

            Transaction.DisposeContext(context);

            return itemDto;
        }

        internal static LogTypeDto Get(long id, bool includeNavigation = false)
        {
            using (var context = Transaction.GetContext(true))
            {
                ILogType dbItem;
                if (includeNavigation)
                    dbItem = context.LogType
								.Include(n=>n.Log).FirstOrDefault(p => p.Id == id);                
                else
                    dbItem = context.LogType.FirstOrDefault(p => p.Id == id);

                return (dbItem != null) ? new LogTypeDto(dbItem, includeNavigation) : null;
            }
        }

        internal static List<LogTypeDto> Select(Expression<Func<ILogType, bool>> whereClause = null, bool includeNavigation = false)
        {
            using (var context = Transaction.GetContext(true))
            {
                IQueryable<ILogType> dbItems;

                var results = new List<LogTypeDto>();

                if (whereClause == null)
                    return Select(includeNavigation);

                if (includeNavigation)
                    dbItems = context.LogType.Where(whereClause)
								.Include(n=>n.Log);
                else
                    dbItems = context.LogType.Where(whereClause);

                if (dbItems.Any())
                {
                    dbItems.ToList()
                        .ForEach(o =>
                        {
                            var dto = new LogTypeDto("Id will be filled in the Assign statement");
                            dto.Assign(o, includeNavigation);
                            results.Add(dto);
                        });
                }
                return results;
            }
        }

        internal static List<LogTypeDto> Select(bool includeNavigation = false)
        {
            using (var context = Transaction.GetContext(true))
            {
                IQueryable<ILogType> dbItems;
                var results = new List<LogTypeDto>();

                if (includeNavigation)
                    dbItems = context.LogType
								.Include(n=>n.Log);
                else
                    dbItems = context.LogType;

                if (dbItems.Any())
                    dbItems.ToList()
                        .ForEach(o =>
                        {
                            var dto = new LogTypeDto("Id will be filled in the Assign statement");
                            dto.Assign(o, includeNavigation);
                            results.Add(dto);
                        });
                return results;
            }
        }

        internal static LogTypeDto Update(LogTypeDto itemDto)
        {
            var context = Transaction.GetContext();

            var id = itemDto.Id;
            var dbItem = context.LogType.FirstOrDefault(o => o.Id == id);
            if (dbItem != null)
            {
                dbItem.Assign(itemDto);
                context.SaveChanges();
                itemDto.Assign(dbItem);
            }

            Transaction.DisposeContext(context);
            return itemDto;
        }

        internal static LogTypeDto Delete(long id, bool cascade = false)
        {
            var context = Transaction.GetContext();

            if (cascade)
            {
                using (var transaction = context.Database.BeginTransaction())
                {
                    var dbItem = context.LogType
									.Include(n=>n.Log).FirstOrDefault(p => p.Id == id);
                    if (dbItem != null)
                    {   
						if (dbItem.Log.Count > 0)
							context.Log.RemoveRange(dbItem.Log);

                        context.LogType.Remove(dbItem);
                        context.SaveChanges();

                        transaction.Commit();
                    }
                }
            }
            else
            {
                var dbItem = context.LogType.FirstOrDefault(p => p.Id == id);
                if (dbItem != null)
                {
                    context.LogType.Remove(dbItem);
                    context.SaveChanges();
                }
            }

            Transaction.DisposeContext(context);

            return null;
        }
    }

    internal static class LogTypeExtensions
    {
        internal static void Assign(this LogType destination, ILogType source, bool includeNavigation = false)
        {
            LogType.Assign(source, destination, includeNavigation);
        }
    }
}