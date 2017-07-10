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
    public partial class QuizAnswer : IQuizAnswer
    {
        internal static void Assign(IQuizAnswer source, IQuizAnswer destination, bool includeNavigation = false)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));
            if (destination == null) throw new ArgumentNullException(nameof(destination));

			destination.Answer = source.Answer;
			destination.Id = source.Id;
			destination.Ordinal = source.Ordinal;
			destination.QuizQuestionId = source.QuizQuestionId;

			if (includeNavigation)
			{
				destination.QuizQuestion = source.QuizQuestion;
			}
        }

        internal static QuizAnswerDto Create(QuizAnswerDto itemDto)
        {
            var context = Transaction.GetContext();

            var dbItem = new QuizAnswer();
            dbItem.Assign(itemDto);
            context.QuizAnswer.Add(dbItem);
            context.SaveChanges();

            itemDto.Assign(dbItem);

            Transaction.DisposeContext(context);

            return itemDto;
        }

        internal static QuizAnswerDto Get(long id, bool includeNavigation = false)
        {
            using (var context = Transaction.GetContext(true))
            {
                IQuizAnswer dbItem;
                if (includeNavigation)
                    dbItem = context.QuizAnswer
								.Include(n=>n.QuizQuestion).FirstOrDefault(p => p.Id == id);                
                else
                    dbItem = context.QuizAnswer.FirstOrDefault(p => p.Id == id);

                return (dbItem != null) ? new QuizAnswerDto(dbItem, includeNavigation) : null;
            }
        }

        internal static List<QuizAnswerDto> Select(Expression<Func<IQuizAnswer, bool>> whereClause = null, bool includeNavigation = false)
        {
            using (var context = Transaction.GetContext(true))
            {
                IQueryable<IQuizAnswer> dbItems;

                var results = new List<QuizAnswerDto>();

                if (whereClause == null)
                    return Select(includeNavigation);

                if (includeNavigation)
                    dbItems = context.QuizAnswer.Where(whereClause)
								.Include(n=>n.QuizQuestion);
                else
                    dbItems = context.QuizAnswer.Where(whereClause);

                if (dbItems.Any())
                {
                    dbItems.ToList()
                        .ForEach(o =>
                        {
                            var dto = new QuizAnswerDto("Id will be filled in the Assign statement");
                            dto.Assign(o, includeNavigation);
                            results.Add(dto);
                        });
                }
                return results;
            }
        }

        internal static List<QuizAnswerDto> Select(bool includeNavigation = false)
        {
            using (var context = Transaction.GetContext(true))
            {
                IQueryable<IQuizAnswer> dbItems;
                var results = new List<QuizAnswerDto>();

                if (includeNavigation)
                    dbItems = context.QuizAnswer
								.Include(n=>n.QuizQuestion);
                else
                    dbItems = context.QuizAnswer;

                if (dbItems.Any())
                    dbItems.ToList()
                        .ForEach(o =>
                        {
                            var dto = new QuizAnswerDto("Id will be filled in the Assign statement");
                            dto.Assign(o, includeNavigation);
                            results.Add(dto);
                        });
                return results;
            }
        }

        internal static QuizAnswerDto Update(QuizAnswerDto itemDto)
        {
            var context = Transaction.GetContext();

            var id = itemDto.Id;
            var dbItem = context.QuizAnswer.FirstOrDefault(o => o.Id == id);
            if (dbItem != null)
            {
                dbItem.Assign(itemDto);
                context.SaveChanges();
                itemDto.Assign(dbItem);
            }

            Transaction.DisposeContext(context);
            return itemDto;
        }

        internal static QuizAnswerDto Delete(long id, bool cascade = false)
        {
            var context = Transaction.GetContext();

            if (cascade)
            {
                using (var transaction = context.Database.BeginTransaction())
                {
                    var dbItem = context.QuizAnswer.FirstOrDefault(p => p.Id == id);
                    if (dbItem != null)
                    {   
                        context.QuizAnswer.Remove(dbItem);
                        context.SaveChanges();

                        transaction.Commit();
                    }
                }
            }
            else
            {
                var dbItem = context.QuizAnswer.FirstOrDefault(p => p.Id == id);
                if (dbItem != null)
                {
                    context.QuizAnswer.Remove(dbItem);
                    context.SaveChanges();
                }
            }

            Transaction.DisposeContext(context);

            return null;
        }
    }

    internal static class QuizAnswerExtensions
    {
        internal static void Assign(this QuizAnswer destination, IQuizAnswer source, bool includeNavigation = false)
        {
            QuizAnswer.Assign(source, destination, includeNavigation);
        }
    }
}