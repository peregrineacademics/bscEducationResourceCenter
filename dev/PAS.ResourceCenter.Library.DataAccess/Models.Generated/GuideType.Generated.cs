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
    public partial class GuideType : IGuideType
    {
        internal static void Assign(IGuideType source, IGuideType destination, bool includeNavigation = false)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));
            if (destination == null) throw new ArgumentNullException(nameof(destination));

			destination.Id = source.Id;
			destination.Name = source.Name;

			if (includeNavigation)
			{
				destination.Review = source.Review;
			}
        }

        internal static GuideTypeDto Create(GuideTypeDto itemDto)
        {
            var context = Transaction.GetContext();

            var dbItem = new GuideType();
            dbItem.Assign(itemDto);
            context.GuideType.Add(dbItem);
            context.SaveChanges();

            itemDto.Assign(dbItem);

            Transaction.DisposeContext(context);

            return itemDto;
        }

        internal static GuideTypeDto Get(long id, bool includeNavigation = false)
        {
            using (var context = Transaction.GetContext(true))
            {
                IGuideType dbItem;
                if (includeNavigation)
                    dbItem = context.GuideType
								.Include(n=>n.Review).FirstOrDefault(p => p.Id == id);                
                else
                    dbItem = context.GuideType.FirstOrDefault(p => p.Id == id);

                return (dbItem != null) ? new GuideTypeDto(dbItem, includeNavigation) : null;
            }
        }

        internal static List<GuideTypeDto> Select(Expression<Func<IGuideType, bool>> whereClause = null, bool includeNavigation = false)
        {
            using (var context = Transaction.GetContext(true))
            {
                IQueryable<IGuideType> dbItems;

                var results = new List<GuideTypeDto>();

                if (whereClause == null)
                    return Select(includeNavigation);

                if (includeNavigation)
                    dbItems = context.GuideType.Where(whereClause)
								.Include(n=>n.Review);
                else
                    dbItems = context.GuideType.Where(whereClause);

                if (dbItems.Any())
                {
                    dbItems.ToList()
                        .ForEach(o =>
                        {
                            var dto = new GuideTypeDto("Id will be filled in the Assign statement");
                            dto.Assign(o, includeNavigation);
                            results.Add(dto);
                        });
                }
                return results;
            }
        }

        internal static List<GuideTypeDto> Select(bool includeNavigation = false)
        {
            using (var context = Transaction.GetContext(true))
            {
                IQueryable<IGuideType> dbItems;
                var results = new List<GuideTypeDto>();

                if (includeNavigation)
                    dbItems = context.GuideType
								.Include(n=>n.Review);
                else
                    dbItems = context.GuideType;

                if (dbItems.Any())
                    dbItems.ToList()
                        .ForEach(o =>
                        {
                            var dto = new GuideTypeDto("Id will be filled in the Assign statement");
                            dto.Assign(o, includeNavigation);
                            results.Add(dto);
                        });
                return results;
            }
        }

        internal static GuideTypeDto Update(GuideTypeDto itemDto)
        {
            var context = Transaction.GetContext();

            var id = itemDto.Id;
            var dbItem = context.GuideType.FirstOrDefault(o => o.Id == id);
            if (dbItem != null)
            {
                dbItem.Assign(itemDto);
                context.SaveChanges();
                itemDto.Assign(dbItem);
            }

            Transaction.DisposeContext(context);
            return itemDto;
        }

        internal static GuideTypeDto Delete(long id, bool cascade = false)
        {
            var context = Transaction.GetContext();

            if (cascade)
            {
                using (var transaction = context.Database.BeginTransaction())
                {
                    var dbItem = context.GuideType
									.Include(n=>n.Review).FirstOrDefault(p => p.Id == id);
                    if (dbItem != null)
                    {   
						if (dbItem.Review.Count > 0)
							context.Review.RemoveRange(dbItem.Review);

                        context.GuideType.Remove(dbItem);
                        context.SaveChanges();

                        transaction.Commit();
                    }
                }
            }
            else
            {
                var dbItem = context.GuideType.FirstOrDefault(p => p.Id == id);
                if (dbItem != null)
                {
                    context.GuideType.Remove(dbItem);
                    context.SaveChanges();
                }
            }

            Transaction.DisposeContext(context);

            return null;
        }
    }

    internal static class GuideTypeExtensions
    {
        internal static void Assign(this GuideType destination, IGuideType source, bool includeNavigation = false)
        {
            GuideType.Assign(source, destination, includeNavigation);
        }
    }
}