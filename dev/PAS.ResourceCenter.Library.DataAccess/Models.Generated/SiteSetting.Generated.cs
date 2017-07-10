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
    public partial class SiteSetting : ISiteSetting
    {
        internal static void Assign(ISiteSetting source, ISiteSetting destination, bool includeNavigation = false)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));
            if (destination == null) throw new ArgumentNullException(nameof(destination));

			destination.DisplayName = source.DisplayName;
			destination.Id = source.Id;
			destination.IsBoolean = source.IsBoolean;
			destination.IsCollection = source.IsCollection;
			destination.IsPassword = source.IsPassword;
			destination.Name = source.Name;
			destination.Notes = source.Notes;
			destination.Value = source.Value;

        }

        internal static SiteSettingDto Create(SiteSettingDto itemDto)
        {
            var context = Transaction.GetContext();

            var dbItem = new SiteSetting();
            dbItem.Assign(itemDto);
            context.SiteSetting.Add(dbItem);
            context.SaveChanges();

            itemDto.Assign(dbItem);

            Transaction.DisposeContext(context);

            return itemDto;
        }

        internal static SiteSettingDto Get(long id, bool includeNavigation = false)
        {
            using (var context = Transaction.GetContext(true))
            {
                ISiteSetting dbItem;
                if (includeNavigation)
                    dbItem = context.SiteSetting.FirstOrDefault(p => p.Id == id);                
                else
                    dbItem = context.SiteSetting.FirstOrDefault(p => p.Id == id);

                return (dbItem != null) ? new SiteSettingDto(dbItem, includeNavigation) : null;
            }
        }

        internal static List<SiteSettingDto> Select(Expression<Func<ISiteSetting, bool>> whereClause = null, bool includeNavigation = false)
        {
            using (var context = Transaction.GetContext(true))
            {
                IQueryable<ISiteSetting> dbItems;

                var results = new List<SiteSettingDto>();

                if (whereClause == null)
                    return Select(includeNavigation);

                if (includeNavigation)
                    dbItems = context.SiteSetting.Where(whereClause);
                else
                    dbItems = context.SiteSetting.Where(whereClause);

                if (dbItems.Any())
                {
                    dbItems.ToList()
                        .ForEach(o =>
                        {
                            var dto = new SiteSettingDto("Id will be filled in the Assign statement");
                            dto.Assign(o, includeNavigation);
                            results.Add(dto);
                        });
                }
                return results;
            }
        }

        internal static List<SiteSettingDto> Select(bool includeNavigation = false)
        {
            using (var context = Transaction.GetContext(true))
            {
                IQueryable<ISiteSetting> dbItems;
                var results = new List<SiteSettingDto>();

                if (includeNavigation)
                    dbItems = context.SiteSetting;
                else
                    dbItems = context.SiteSetting;

                if (dbItems.Any())
                    dbItems.ToList()
                        .ForEach(o =>
                        {
                            var dto = new SiteSettingDto("Id will be filled in the Assign statement");
                            dto.Assign(o, includeNavigation);
                            results.Add(dto);
                        });
                return results;
            }
        }

        internal static SiteSettingDto Update(SiteSettingDto itemDto)
        {
            var context = Transaction.GetContext();

            var id = itemDto.Id;
            var dbItem = context.SiteSetting.FirstOrDefault(o => o.Id == id);
            if (dbItem != null)
            {
                dbItem.Assign(itemDto);
                context.SaveChanges();
                itemDto.Assign(dbItem);
            }

            Transaction.DisposeContext(context);
            return itemDto;
        }

        internal static SiteSettingDto Delete(long id, bool cascade = false)
        {
            var context = Transaction.GetContext();

            if (cascade)
            {
                using (var transaction = context.Database.BeginTransaction())
                {
                    var dbItem = context.SiteSetting.FirstOrDefault(p => p.Id == id);
                    if (dbItem != null)
                    {   
                        context.SiteSetting.Remove(dbItem);
                        context.SaveChanges();

                        transaction.Commit();
                    }
                }
            }
            else
            {
                var dbItem = context.SiteSetting.FirstOrDefault(p => p.Id == id);
                if (dbItem != null)
                {
                    context.SiteSetting.Remove(dbItem);
                    context.SaveChanges();
                }
            }

            Transaction.DisposeContext(context);

            return null;
        }
    }

    internal static class SiteSettingExtensions
    {
        internal static void Assign(this SiteSetting destination, ISiteSetting source, bool includeNavigation = false)
        {
            SiteSetting.Assign(source, destination, includeNavigation);
        }
    }
}