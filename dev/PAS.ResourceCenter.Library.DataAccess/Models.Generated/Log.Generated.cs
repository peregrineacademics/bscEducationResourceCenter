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
    public partial class Log : ILog
    {
        internal static void Assign(ILog source, ILog destination, bool includeNavigation = false)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));
            if (destination == null) throw new ArgumentNullException(nameof(destination));

			destination.CreatedByUserId = source.CreatedByUserId;
			destination.DateCreated = source.DateCreated;
			destination.Id = source.Id;
			destination.LinkId = source.LinkId;
			destination.LinkUserId = source.LinkUserId;
			destination.LogSourceId = source.LogSourceId;
			destination.LogTypeId = source.LogTypeId;
			destination.Message = source.Message;

			if (includeNavigation)
			{
				destination.CreatedByUser = source.CreatedByUser;
				destination.LogSource = source.LogSource;
				destination.LogType = source.LogType;
			}
        }

        internal static LogDto Create(LogDto itemDto)
        {
            var context = Transaction.GetContext();

            var dbItem = new Log();
            dbItem.Assign(itemDto);
            context.Log.Add(dbItem);
            context.SaveChanges();

            itemDto.Assign(dbItem);

            Transaction.DisposeContext(context);

            return itemDto;
        }

        internal static LogDto Get(long id, bool includeNavigation = false)
        {
            using (var context = Transaction.GetContext(true))
            {
                ILog dbItem;
                if (includeNavigation)
                    dbItem = context.Log
								.Include(n=>n.CreatedByUser)
								.Include(n=>n.LogSource)
								.Include(n=>n.LogType).FirstOrDefault(p => p.Id == id);                
                else
                    dbItem = context.Log.FirstOrDefault(p => p.Id == id);

                return (dbItem != null) ? new LogDto(dbItem, includeNavigation) : null;
            }
        }

        internal static List<LogDto> Select(Expression<Func<ILog, bool>> whereClause = null, bool includeNavigation = false)
        {
            using (var context = Transaction.GetContext(true))
            {
                IQueryable<ILog> dbItems;

                var results = new List<LogDto>();

                if (whereClause == null)
                    return Select(includeNavigation);

                if (includeNavigation)
                    dbItems = context.Log.Where(whereClause)
								.Include(n=>n.CreatedByUser)
								.Include(n=>n.LogSource)
								.Include(n=>n.LogType);
                else
                    dbItems = context.Log.Where(whereClause);

                if (dbItems.Any())
                {
                    dbItems.ToList()
                        .ForEach(o =>
                        {
                            var dto = new LogDto("Id will be filled in the Assign statement");
                            dto.Assign(o, includeNavigation);
                            results.Add(dto);
                        });
                }
                return results;
            }
        }

        internal static List<LogDto> Select(bool includeNavigation = false)
        {
            using (var context = Transaction.GetContext(true))
            {
                IQueryable<ILog> dbItems;
                var results = new List<LogDto>();

                if (includeNavigation)
                    dbItems = context.Log
								.Include(n=>n.CreatedByUser)
								.Include(n=>n.LogSource)
								.Include(n=>n.LogType);
                else
                    dbItems = context.Log;

                if (dbItems.Any())
                    dbItems.ToList()
                        .ForEach(o =>
                        {
                            var dto = new LogDto("Id will be filled in the Assign statement");
                            dto.Assign(o, includeNavigation);
                            results.Add(dto);
                        });
                return results;
            }
        }

        internal static LogDto Update(LogDto itemDto)
        {
            var context = Transaction.GetContext();

            var id = itemDto.Id;
            var dbItem = context.Log.FirstOrDefault(o => o.Id == id);
            if (dbItem != null)
            {
                dbItem.Assign(itemDto);
                context.SaveChanges();
                itemDto.Assign(dbItem);
            }

            Transaction.DisposeContext(context);
            return itemDto;
        }

        internal static LogDto Delete(long id, bool cascade = false)
        {
            var context = Transaction.GetContext();

            if (cascade)
            {
                using (var transaction = context.Database.BeginTransaction())
                {
                    var dbItem = context.Log.FirstOrDefault(p => p.Id == id);
                    if (dbItem != null)
                    {   
                        context.Log.Remove(dbItem);
                        context.SaveChanges();

                        transaction.Commit();
                    }
                }
            }
            else
            {
                var dbItem = context.Log.FirstOrDefault(p => p.Id == id);
                if (dbItem != null)
                {
                    context.Log.Remove(dbItem);
                    context.SaveChanges();
                }
            }

            Transaction.DisposeContext(context);

            return null;
        }
    }

    internal static class LogExtensions
    {
        internal static void Assign(this Log destination, ILog source, bool includeNavigation = false)
        {
            Log.Assign(source, destination, includeNavigation);
        }
    }
}