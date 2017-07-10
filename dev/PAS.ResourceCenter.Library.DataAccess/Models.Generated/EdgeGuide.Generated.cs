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
    public partial class EdgeGuide : IEdgeGuide
    {
        internal static void Assign(IEdgeGuide source, IEdgeGuide destination, bool includeNavigation = false)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));
            if (destination == null) throw new ArgumentNullException(nameof(destination));

			destination.Id = source.Id;
			destination.Name = source.Name;

			if (includeNavigation)
			{
				destination.ReviewEdgeGuide = source.ReviewEdgeGuide;
			}
        }

        internal static EdgeGuideDto Create(EdgeGuideDto itemDto)
        {
            var context = Transaction.GetContext();

            var dbItem = new EdgeGuide();
            dbItem.Assign(itemDto);
            context.EdgeGuide.Add(dbItem);
            context.SaveChanges();

            itemDto.Assign(dbItem);

            Transaction.DisposeContext(context);

            return itemDto;
        }

        internal static EdgeGuideDto Get(long id, bool includeNavigation = false)
        {
            using (var context = Transaction.GetContext(true))
            {
                IEdgeGuide dbItem;
                if (includeNavigation)
                    dbItem = context.EdgeGuide
								.Include(n=>n.ReviewEdgeGuide).FirstOrDefault(p => p.Id == id);                
                else
                    dbItem = context.EdgeGuide.FirstOrDefault(p => p.Id == id);

                return (dbItem != null) ? new EdgeGuideDto(dbItem, includeNavigation) : null;
            }
        }

        internal static List<EdgeGuideDto> Select(Expression<Func<IEdgeGuide, bool>> whereClause = null, bool includeNavigation = false)
        {
            using (var context = Transaction.GetContext(true))
            {
                IQueryable<IEdgeGuide> dbItems;

                var results = new List<EdgeGuideDto>();

                if (whereClause == null)
                    return Select(includeNavigation);

                if (includeNavigation)
                    dbItems = context.EdgeGuide.Where(whereClause)
								.Include(n=>n.ReviewEdgeGuide);
                else
                    dbItems = context.EdgeGuide.Where(whereClause);

                if (dbItems.Any())
                {
                    dbItems.ToList()
                        .ForEach(o =>
                        {
                            var dto = new EdgeGuideDto("Id will be filled in the Assign statement");
                            dto.Assign(o, includeNavigation);
                            results.Add(dto);
                        });
                }
                return results;
            }
        }

        internal static List<EdgeGuideDto> Select(bool includeNavigation = false)
        {
            using (var context = Transaction.GetContext(true))
            {
                IQueryable<IEdgeGuide> dbItems;
                var results = new List<EdgeGuideDto>();

                if (includeNavigation)
                    dbItems = context.EdgeGuide
								.Include(n=>n.ReviewEdgeGuide);
                else
                    dbItems = context.EdgeGuide;

                if (dbItems.Any())
                    dbItems.ToList()
                        .ForEach(o =>
                        {
                            var dto = new EdgeGuideDto("Id will be filled in the Assign statement");
                            dto.Assign(o, includeNavigation);
                            results.Add(dto);
                        });
                return results;
            }
        }

        internal static EdgeGuideDto Update(EdgeGuideDto itemDto)
        {
            var context = Transaction.GetContext();

            var id = itemDto.Id;
            var dbItem = context.EdgeGuide.FirstOrDefault(o => o.Id == id);
            if (dbItem != null)
            {
                dbItem.Assign(itemDto);
                context.SaveChanges();
                itemDto.Assign(dbItem);
            }

            Transaction.DisposeContext(context);
            return itemDto;
        }

        internal static EdgeGuideDto Delete(long id, bool cascade = false)
        {
            var context = Transaction.GetContext();

            if (cascade)
            {
                using (var transaction = context.Database.BeginTransaction())
                {
                    var dbItem = context.EdgeGuide
									.Include(n=>n.ReviewEdgeGuide).FirstOrDefault(p => p.Id == id);
                    if (dbItem != null)
                    {   
						if (dbItem.ReviewEdgeGuide.Count > 0)
							context.ReviewEdgeGuide.RemoveRange(dbItem.ReviewEdgeGuide);

                        context.EdgeGuide.Remove(dbItem);
                        context.SaveChanges();

                        transaction.Commit();
                    }
                }
            }
            else
            {
                var dbItem = context.EdgeGuide.FirstOrDefault(p => p.Id == id);
                if (dbItem != null)
                {
                    context.EdgeGuide.Remove(dbItem);
                    context.SaveChanges();
                }
            }

            Transaction.DisposeContext(context);

            return null;
        }
    }

    internal static class EdgeGuideExtensions
    {
        internal static void Assign(this EdgeGuide destination, IEdgeGuide source, bool includeNavigation = false)
        {
            EdgeGuide.Assign(source, destination, includeNavigation);
        }
    }
}