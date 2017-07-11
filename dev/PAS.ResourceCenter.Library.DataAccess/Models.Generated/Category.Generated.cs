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
    public partial class Category : ICategory
    {
        internal static void Assign(ICategory source, ICategory destination, bool includeNavigation = false)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));
            if (destination == null) throw new ArgumentNullException(nameof(destination));

			destination.GroupId = source.GroupId;
			destination.Id = source.Id;
			destination.IsEnabled = source.IsEnabled;
			destination.Name = source.Name;
			destination.ParentId = source.ParentId;

			if (includeNavigation)
			{
				destination.ReviewCategory = source.ReviewCategory;
				destination.ReviewerCategory = source.ReviewerCategory;
			}
        }

        internal static CategoryDto Create(CategoryDto itemDto)
        {
            var context = Transaction.GetContext();

            var dbItem = new Category();
            dbItem.Assign(itemDto);
            context.Category.Add(dbItem);
            context.SaveChanges();

            itemDto.Assign(dbItem);

            Transaction.DisposeContext(context);

            return itemDto;
        }

        internal static CategoryDto Get(long id, bool includeNavigation = false)
        {
            using (var context = Transaction.GetContext(true))
            {
                ICategory dbItem;
                if (includeNavigation)
                    dbItem = context.Category
								.Include(n=>n.ReviewCategory)
								.Include(n=>n.ReviewerCategory).FirstOrDefault(p => p.Id == id);                
                else
                    dbItem = context.Category.FirstOrDefault(p => p.Id == id);

                return (dbItem != null) ? new CategoryDto(dbItem, includeNavigation) : null;
            }
        }

        internal static List<CategoryDto> Select(Expression<Func<ICategory, bool>> whereClause = null, bool includeNavigation = false)
        {
            using (var context = Transaction.GetContext(true))
            {
                IQueryable<ICategory> dbItems;

                var results = new List<CategoryDto>();

                if (whereClause == null)
                    return Select(includeNavigation);

                if (includeNavigation)
                    dbItems = context.Category.Where(whereClause)
								.Include(n=>n.ReviewCategory)
								.Include(n=>n.ReviewerCategory);
                else
                    dbItems = context.Category.Where(whereClause);

                if (dbItems.Any())
                {
                    dbItems.ToList()
                        .ForEach(o =>
                        {
                            var dto = new CategoryDto("Id will be filled in the Assign statement");
                            dto.Assign(o, includeNavigation);
                            results.Add(dto);
                        });
                }
                return results;
            }
        }

        internal static List<CategoryDto> Select(bool includeNavigation = false)
        {
            using (var context = Transaction.GetContext(true))
            {
                IQueryable<ICategory> dbItems;
                var results = new List<CategoryDto>();

                if (includeNavigation)
                    dbItems = context.Category
								.Include(n=>n.ReviewCategory)
								.Include(n=>n.ReviewerCategory);
                else
                    dbItems = context.Category;

                if (dbItems.Any())
                    dbItems.ToList()
                        .ForEach(o =>
                        {
                            var dto = new CategoryDto("Id will be filled in the Assign statement");
                            dto.Assign(o, includeNavigation);
                            results.Add(dto);
                        });
                return results;
            }
        }

        internal static CategoryDto Update(CategoryDto itemDto)
        {
            var context = Transaction.GetContext();

            var id = itemDto.Id;
            var dbItem = context.Category.FirstOrDefault(o => o.Id == id);
            if (dbItem != null)
            {
                dbItem.Assign(itemDto);
                context.SaveChanges();
                itemDto.Assign(dbItem);
            }

            Transaction.DisposeContext(context);
            return itemDto;
        }

        internal static CategoryDto Delete(long id, bool cascade = false)
        {
            var context = Transaction.GetContext();

            if (cascade)
            {
                using (var transaction = context.Database.BeginTransaction())
                {
                    var dbItem = context.Category
									.Include(n=>n.ReviewCategory)
									.Include(n=>n.ReviewerCategory).FirstOrDefault(p => p.Id == id);
                    if (dbItem != null)
                    {   
						if (dbItem.ReviewCategory.Count > 0)
							context.ReviewCategory.RemoveRange(dbItem.ReviewCategory);
						if (dbItem.ReviewerCategory.Count > 0)
							context.ReviewerCategory.RemoveRange(dbItem.ReviewerCategory);

                        context.Category.Remove(dbItem);
                        context.SaveChanges();

                        transaction.Commit();
                    }
                }
            }
            else
            {
                var dbItem = context.Category.FirstOrDefault(p => p.Id == id);
                if (dbItem != null)
                {
                    context.Category.Remove(dbItem);
                    context.SaveChanges();
                }
            }

            Transaction.DisposeContext(context);

            return null;
        }
    }

    internal static class CategoryExtensions
    {
        internal static void Assign(this Category destination, ICategory source, bool includeNavigation = false)
        {
            Category.Assign(source, destination, includeNavigation);
        }
    }
}