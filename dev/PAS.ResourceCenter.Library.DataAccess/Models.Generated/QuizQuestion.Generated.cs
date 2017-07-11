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
    public partial class QuizQuestion : IQuizQuestion
    {
        internal static void Assign(IQuizQuestion source, IQuizQuestion destination, bool includeNavigation = false)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));
            if (destination == null) throw new ArgumentNullException(nameof(destination));

			destination.Id = source.Id;
			destination.Ordinal = source.Ordinal;
			destination.Question = source.Question;
			destination.QuestionTypeId = source.QuestionTypeId;
			destination.ReviewId = source.ReviewId;

			if (includeNavigation)
			{
				destination.QuestionType = source.QuestionType;
				destination.QuizAnswer = source.QuizAnswer;
			}
        }

        internal static QuizQuestionDto Create(QuizQuestionDto itemDto)
        {
            var context = Transaction.GetContext();

            var dbItem = new QuizQuestion();
            dbItem.Assign(itemDto);
            context.QuizQuestion.Add(dbItem);
            context.SaveChanges();

            itemDto.Assign(dbItem);

            Transaction.DisposeContext(context);

            return itemDto;
        }

        internal static QuizQuestionDto Get(long id, bool includeNavigation = false)
        {
            using (var context = Transaction.GetContext(true))
            {
                IQuizQuestion dbItem;
                if (includeNavigation)
                    dbItem = context.QuizQuestion
								.Include(n=>n.QuestionType)
								.Include(n=>n.QuizAnswer).FirstOrDefault(p => p.Id == id);                
                else
                    dbItem = context.QuizQuestion.FirstOrDefault(p => p.Id == id);

                return (dbItem != null) ? new QuizQuestionDto(dbItem, includeNavigation) : null;
            }
        }

        internal static List<QuizQuestionDto> Select(Expression<Func<IQuizQuestion, bool>> whereClause = null, bool includeNavigation = false)
        {
            using (var context = Transaction.GetContext(true))
            {
                IQueryable<IQuizQuestion> dbItems;

                var results = new List<QuizQuestionDto>();

                if (whereClause == null)
                    return Select(includeNavigation);

                if (includeNavigation)
                    dbItems = context.QuizQuestion.Where(whereClause)
								.Include(n=>n.QuestionType)
								.Include(n=>n.QuizAnswer);
                else
                    dbItems = context.QuizQuestion.Where(whereClause);

                if (dbItems.Any())
                {
                    dbItems.ToList()
                        .ForEach(o =>
                        {
                            var dto = new QuizQuestionDto("Id will be filled in the Assign statement");
                            dto.Assign(o, includeNavigation);
                            results.Add(dto);
                        });
                }
                return results;
            }
        }

        internal static List<QuizQuestionDto> Select(bool includeNavigation = false)
        {
            using (var context = Transaction.GetContext(true))
            {
                IQueryable<IQuizQuestion> dbItems;
                var results = new List<QuizQuestionDto>();

                if (includeNavigation)
                    dbItems = context.QuizQuestion
								.Include(n=>n.QuestionType)
								.Include(n=>n.QuizAnswer);
                else
                    dbItems = context.QuizQuestion;

                if (dbItems.Any())
                    dbItems.ToList()
                        .ForEach(o =>
                        {
                            var dto = new QuizQuestionDto("Id will be filled in the Assign statement");
                            dto.Assign(o, includeNavigation);
                            results.Add(dto);
                        });
                return results;
            }
        }

        internal static QuizQuestionDto Update(QuizQuestionDto itemDto)
        {
            var context = Transaction.GetContext();

            var id = itemDto.Id;
            var dbItem = context.QuizQuestion.FirstOrDefault(o => o.Id == id);
            if (dbItem != null)
            {
                dbItem.Assign(itemDto);
                context.SaveChanges();
                itemDto.Assign(dbItem);
            }

            Transaction.DisposeContext(context);
            return itemDto;
        }

        internal static QuizQuestionDto Delete(long id, bool cascade = false)
        {
            var context = Transaction.GetContext();

            if (cascade)
            {
                using (var transaction = context.Database.BeginTransaction())
                {
                    var dbItem = context.QuizQuestion
									.Include(n=>n.QuizAnswer).FirstOrDefault(p => p.Id == id);
                    if (dbItem != null)
                    {   
						if (dbItem.QuizAnswer.Count > 0)
							context.QuizAnswer.RemoveRange(dbItem.QuizAnswer);

                        context.QuizQuestion.Remove(dbItem);
                        context.SaveChanges();

                        transaction.Commit();
                    }
                }
            }
            else
            {
                var dbItem = context.QuizQuestion.FirstOrDefault(p => p.Id == id);
                if (dbItem != null)
                {
                    context.QuizQuestion.Remove(dbItem);
                    context.SaveChanges();
                }
            }

            Transaction.DisposeContext(context);

            return null;
        }
    }

    internal static class QuizQuestionExtensions
    {
        internal static void Assign(this QuizQuestion destination, IQuizQuestion source, bool includeNavigation = false)
        {
            QuizQuestion.Assign(source, destination, includeNavigation);
        }
    }
}