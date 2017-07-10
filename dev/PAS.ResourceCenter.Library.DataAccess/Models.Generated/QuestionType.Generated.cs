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
    public partial class QuestionType : IQuestionType
    {
        internal static void Assign(IQuestionType source, IQuestionType destination, bool includeNavigation = false)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));
            if (destination == null) throw new ArgumentNullException(nameof(destination));

			destination.Id = source.Id;
			destination.Name = source.Name;

			if (includeNavigation)
			{
				destination.QuizQuestion = source.QuizQuestion;
			}
        }

        internal static QuestionTypeDto Create(QuestionTypeDto itemDto)
        {
            var context = Transaction.GetContext();

            var dbItem = new QuestionType();
            dbItem.Assign(itemDto);
            context.QuestionType.Add(dbItem);
            context.SaveChanges();

            itemDto.Assign(dbItem);

            Transaction.DisposeContext(context);

            return itemDto;
        }

        internal static QuestionTypeDto Get(long id, bool includeNavigation = false)
        {
            using (var context = Transaction.GetContext(true))
            {
                IQuestionType dbItem;
                if (includeNavigation)
                    dbItem = context.QuestionType
								.Include(n=>n.QuizQuestion).FirstOrDefault(p => p.Id == id);                
                else
                    dbItem = context.QuestionType.FirstOrDefault(p => p.Id == id);

                return (dbItem != null) ? new QuestionTypeDto(dbItem, includeNavigation) : null;
            }
        }

        internal static List<QuestionTypeDto> Select(Expression<Func<IQuestionType, bool>> whereClause = null, bool includeNavigation = false)
        {
            using (var context = Transaction.GetContext(true))
            {
                IQueryable<IQuestionType> dbItems;

                var results = new List<QuestionTypeDto>();

                if (whereClause == null)
                    return Select(includeNavigation);

                if (includeNavigation)
                    dbItems = context.QuestionType.Where(whereClause)
								.Include(n=>n.QuizQuestion);
                else
                    dbItems = context.QuestionType.Where(whereClause);

                if (dbItems.Any())
                {
                    dbItems.ToList()
                        .ForEach(o =>
                        {
                            var dto = new QuestionTypeDto("Id will be filled in the Assign statement");
                            dto.Assign(o, includeNavigation);
                            results.Add(dto);
                        });
                }
                return results;
            }
        }

        internal static List<QuestionTypeDto> Select(bool includeNavigation = false)
        {
            using (var context = Transaction.GetContext(true))
            {
                IQueryable<IQuestionType> dbItems;
                var results = new List<QuestionTypeDto>();

                if (includeNavigation)
                    dbItems = context.QuestionType
								.Include(n=>n.QuizQuestion);
                else
                    dbItems = context.QuestionType;

                if (dbItems.Any())
                    dbItems.ToList()
                        .ForEach(o =>
                        {
                            var dto = new QuestionTypeDto("Id will be filled in the Assign statement");
                            dto.Assign(o, includeNavigation);
                            results.Add(dto);
                        });
                return results;
            }
        }

        internal static QuestionTypeDto Update(QuestionTypeDto itemDto)
        {
            var context = Transaction.GetContext();

            var id = itemDto.Id;
            var dbItem = context.QuestionType.FirstOrDefault(o => o.Id == id);
            if (dbItem != null)
            {
                dbItem.Assign(itemDto);
                context.SaveChanges();
                itemDto.Assign(dbItem);
            }

            Transaction.DisposeContext(context);
            return itemDto;
        }

        internal static QuestionTypeDto Delete(long id, bool cascade = false)
        {
            var context = Transaction.GetContext();

            if (cascade)
            {
                using (var transaction = context.Database.BeginTransaction())
                {
                    var dbItem = context.QuestionType
									.Include(n=>n.QuizQuestion).FirstOrDefault(p => p.Id == id);
                    if (dbItem != null)
                    {   
						if (dbItem.QuizQuestion.Count > 0)
							context.QuizQuestion.RemoveRange(dbItem.QuizQuestion);

                        context.QuestionType.Remove(dbItem);
                        context.SaveChanges();

                        transaction.Commit();
                    }
                }
            }
            else
            {
                var dbItem = context.QuestionType.FirstOrDefault(p => p.Id == id);
                if (dbItem != null)
                {
                    context.QuestionType.Remove(dbItem);
                    context.SaveChanges();
                }
            }

            Transaction.DisposeContext(context);

            return null;
        }
    }

    internal static class QuestionTypeExtensions
    {
        internal static void Assign(this QuestionType destination, IQuestionType source, bool includeNavigation = false)
        {
            QuestionType.Assign(source, destination, includeNavigation);
        }
    }
}