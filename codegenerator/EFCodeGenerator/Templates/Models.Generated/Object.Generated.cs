// Generated file do not modify this can be overwritten.
// To extend this class use the template file found in models.custom folder an make a copy using the class name.
using dbNameSpace.DTO;
using dbNameSpace.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

// This file is generated. DO NOT MODIFY
namespace dbNameSpace.Models
{
    public partial class Object : IObject
    {
        internal static void Assign(IObject source, IObject destination, bool includeNavigation = false)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));
            if (destination == null) throw new ArgumentNullException(nameof(destination));

/* insert assignProperties *//* insert assignNavigation */
        }

        internal static ObjectDto Create(ObjectDto itemDto)
        {
            var context = Transaction.GetContext();

            var dbItem = new Object();
            dbItem.Assign(itemDto);
            context.Object.Add(dbItem);
            context.SaveChanges();

            itemDto.Assign(dbItem);

            Transaction.DisposeContext(context);

            return itemDto;
        }

        internal static ObjectDto Get(/* insert IdType */ id, bool includeNavigation = false)
        {
            using (var context = Transaction.GetContext(true))
            {
                IObject dbItem;
                if (includeNavigation)
                    dbItem = context.Object/* insert navigationIncludes */.FirstOrDefault(p => p./* Primary Key */ == id);                
                else
                    dbItem = context.Object.FirstOrDefault(p => p./* Primary Key */ == id);

                return (dbItem != null) ? new ObjectDto(dbItem, includeNavigation) : null;
            }
        }

        internal static List<ObjectDto> Select(Expression<Func<IObject, bool>> whereClause = null, bool includeNavigation = false)
        {
            using (var context = Transaction.GetContext(true))
            {
                IQueryable<IObject> dbItems;

                var results = new List<ObjectDto>();

                if (whereClause == null)
                    return Select(includeNavigation);

                if (includeNavigation)
                    dbItems = context.Object.Where(whereClause)/* insert navigationIncludes */;
                else
                    dbItems = context.Object.Where(whereClause);

                if (dbItems.Any())
                {
                    dbItems.ToList()
                        .ForEach(o =>
                        {
                            var dto = new ObjectDto("Id will be filled in the Assign statement");
                            dto.Assign(o, includeNavigation);
                            results.Add(dto);
                        });
                }
                return results;
            }
        }

        internal static List<ObjectDto> Select(bool includeNavigation = false)
        {
            using (var context = Transaction.GetContext(true))
            {
                IQueryable<IObject> dbItems;
                var results = new List<ObjectDto>();

                if (includeNavigation)
                    dbItems = context.Object/* insert navigationIncludes */;
                else
                    dbItems = context.Object;

                if (dbItems.Any())
                    dbItems.ToList()
                        .ForEach(o =>
                        {
                            var dto = new ObjectDto("Id will be filled in the Assign statement");
                            dto.Assign(o, includeNavigation);
                            results.Add(dto);
                        });
                return results;
            }
        }

        internal static ObjectDto Update(ObjectDto itemDto)
        {
            var context = Transaction.GetContext();

            var id = itemDto./* Primary Key */;
            var dbItem = context.Object.FirstOrDefault(o => o./* Primary Key */ == id);
            if (dbItem != null)
            {
                dbItem.Assign(itemDto);
                context.SaveChanges();
                itemDto.Assign(dbItem);
            }

            Transaction.DisposeContext(context);
            return itemDto;
        }

        internal static ObjectDto Delete(/* insert IdType */ id, bool cascade = false)
        {
            var context = Transaction.GetContext();

            if (cascade)
            {
                using (var transaction = context.Database.BeginTransaction())
                {
                    var dbItem = context.Object/* insert deleteNavigationIncludes */.FirstOrDefault(p => p./* Primary Key */ == id);
                    if (dbItem != null)
                    {   /* insert NavDeletes */
                        context.Object.Remove(dbItem);
                        context.SaveChanges();

                        transaction.Commit();
                    }
                }
            }
            else
            {
                var dbItem = context.Object.FirstOrDefault(p => p./* Primary Key */ == id);
                if (dbItem != null)
                {
                    context.Object.Remove(dbItem);
                    context.SaveChanges();
                }
            }

            Transaction.DisposeContext(context);

            return null;
        }
    }

    internal static class ObjectExtensions
    {
        internal static void Assign(this Object destination, IObject source, bool includeNavigation = false)
        {
            Object.Assign(source, destination, includeNavigation);
        }
    }
}