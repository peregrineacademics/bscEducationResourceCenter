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
    public partial class Issue : IIssue
    {
        internal static void Assign(IIssue source, IIssue destination, bool includeNavigation = false)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));
            if (destination == null) throw new ArgumentNullException(nameof(destination));

			destination.CoverImage = source.CoverImage;
			destination.CoverStoryUrl = source.CoverStoryUrl;
			destination.CreatedByUserId = source.CreatedByUserId;
			destination.DateCreated = source.DateCreated;
			destination.Id = source.Id;
			destination.IsEnabled = source.IsEnabled;
			destination.IssueDate = source.IssueDate;
			destination.IssueName = source.IssueName;
			destination.IssueTitle = source.IssueTitle;
			destination.IssueUrlName = source.IssueUrlName;
			destination.LastUpdated = source.LastUpdated;
			destination.UpdatedByUserId = source.UpdatedByUserId;

			if (includeNavigation)
			{
				destination.CreatedByUser = source.CreatedByUser;
				destination.Review = source.Review;
				destination.UpdatedByUser = source.UpdatedByUser;
			}
        }

        internal static IssueDto Create(IssueDto itemDto)
        {
            var context = Transaction.GetContext();

            var dbItem = new Issue();
            dbItem.Assign(itemDto);
            context.Issue.Add(dbItem);
            context.SaveChanges();

            itemDto.Assign(dbItem);

            Transaction.DisposeContext(context);

            return itemDto;
        }

        internal static IssueDto Get(long id, bool includeNavigation = false)
        {
            using (var context = Transaction.GetContext(true))
            {
                IIssue dbItem;
                if (includeNavigation)
                    dbItem = context.Issue
								.Include(n=>n.CreatedByUser)
								.Include(n=>n.Review)
								.Include(n=>n.UpdatedByUser).FirstOrDefault(p => p.Id == id);                
                else
                    dbItem = context.Issue.FirstOrDefault(p => p.Id == id);

                return (dbItem != null) ? new IssueDto(dbItem, includeNavigation) : null;
            }
        }

        internal static List<IssueDto> Select(Expression<Func<IIssue, bool>> whereClause = null, bool includeNavigation = false)
        {
            using (var context = Transaction.GetContext(true))
            {
                IQueryable<IIssue> dbItems;

                var results = new List<IssueDto>();

                if (whereClause == null)
                    return Select(includeNavigation);

                if (includeNavigation)
                    dbItems = context.Issue.Where(whereClause)
								.Include(n=>n.CreatedByUser)
								.Include(n=>n.Review)
								.Include(n=>n.UpdatedByUser);
                else
                    dbItems = context.Issue.Where(whereClause);

                if (dbItems.Any())
                {
                    dbItems.ToList()
                        .ForEach(o =>
                        {
                            var dto = new IssueDto("Id will be filled in the Assign statement");
                            dto.Assign(o, includeNavigation);
                            results.Add(dto);
                        });
                }
                return results;
            }
        }

        internal static List<IssueDto> Select(bool includeNavigation = false)
        {
            using (var context = Transaction.GetContext(true))
            {
                IQueryable<IIssue> dbItems;
                var results = new List<IssueDto>();

                if (includeNavigation)
                    dbItems = context.Issue
								.Include(n=>n.CreatedByUser)
								.Include(n=>n.Review)
								.Include(n=>n.UpdatedByUser);
                else
                    dbItems = context.Issue;

                if (dbItems.Any())
                    dbItems.ToList()
                        .ForEach(o =>
                        {
                            var dto = new IssueDto("Id will be filled in the Assign statement");
                            dto.Assign(o, includeNavigation);
                            results.Add(dto);
                        });
                return results;
            }
        }

        internal static IssueDto Update(IssueDto itemDto)
        {
            var context = Transaction.GetContext();

            var id = itemDto.Id;
            var dbItem = context.Issue.FirstOrDefault(o => o.Id == id);
            if (dbItem != null)
            {
                dbItem.Assign(itemDto);
                context.SaveChanges();
                itemDto.Assign(dbItem);
            }

            Transaction.DisposeContext(context);
            return itemDto;
        }

        internal static IssueDto Delete(long id, bool cascade = false)
        {
            var context = Transaction.GetContext();

            if (cascade)
            {
                using (var transaction = context.Database.BeginTransaction())
                {
                    var dbItem = context.Issue
									.Include(n=>n.Review).FirstOrDefault(p => p.Id == id);
                    if (dbItem != null)
                    {   
						if (dbItem.Review.Count > 0)
							context.Review.RemoveRange(dbItem.Review);

                        context.Issue.Remove(dbItem);
                        context.SaveChanges();

                        transaction.Commit();
                    }
                }
            }
            else
            {
                var dbItem = context.Issue.FirstOrDefault(p => p.Id == id);
                if (dbItem != null)
                {
                    context.Issue.Remove(dbItem);
                    context.SaveChanges();
                }
            }

            Transaction.DisposeContext(context);

            return null;
        }
    }

    internal static class IssueExtensions
    {
        internal static void Assign(this Issue destination, IIssue source, bool includeNavigation = false)
        {
            Issue.Assign(source, destination, includeNavigation);
        }
    }
}