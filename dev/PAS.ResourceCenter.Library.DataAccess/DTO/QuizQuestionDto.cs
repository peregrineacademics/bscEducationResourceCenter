using System;
using System.Linq.Expressions;
using PAS.ResourceCenter.Library.DataAccess.Interfaces;
using PAS.ResourceCenter.Library.DataAccess.Models;
using PAS.ResourceCenter.Library.DataAccess.Responses;
using System.Collections.Generic;

// This file is generated. DO NOT MODIFY
namespace PAS.ResourceCenter.Library.DataAccess.DTO
{
    public partial class QuizQuestionDto : IQuizQuestion
    {
        public QuizQuestionDto(string byUserId = "")
        {
			Id = 0;
			Ordinal = 0;
			Question = "";
			QuestionTypeId = 0;
			ReviewId = 0;

        }

        public QuizQuestionDto(IQuizQuestion item, bool includeNavigation = false)
        {
            if (item != null)
                Assign(item, includeNavigation);
        }

		public Int64 Id{ get; set; }
		public Int64 Ordinal{ get; set; }
		public String Question{ get; set; }
		public Int64 QuestionTypeId{ get; set; }
		public Int64 ReviewId{ get; set; }

		public Models.QuestionType QuestionType { get; set; }
		public ICollection<QuizAnswer> QuizAnswer { get; set; }
		public Models.Review Review { get; set; }


        internal void Assign(IQuizQuestion item, bool includeNavigation = false)
        {
            if (item == null)
                throw new ArgumentNullException(nameof(item));

            QuizQuestion.Assign(item, this, includeNavigation);
        }

        public static Response<QuizQuestionDto> Create(QuizQuestionDto item)
        {
            if (item == null)
            {
                return new Response<QuizQuestionDto>(StatusCodes.EXCEPTION);
            }

            return new DAL.QuizQuestion().Create(item);
        }

        public static Response<QuizQuestionDto> Get(long id, bool includeNavigation = false)
        {
            return new DAL.QuizQuestion().Get(id, includeNavigation);
        }

        public static Response<QuizQuestionDto> Select(Expression<Func<IQuizQuestion, bool>> whereClause = null, bool includeNavigation = false)
        {
            return new DAL.QuizQuestion().Select(whereClause, includeNavigation);
        }

        public static Response<QuizQuestionDto> Update(QuizQuestionDto item)
        {
            if (item == null)
            {
                return new Response<QuizQuestionDto>(StatusCodes.EXCEPTION);
            }

            return new DAL.QuizQuestion().Update(item);
        }

        public Response<QuizQuestionDto> Update()
        {
            return new DAL.QuizQuestion().Update(this);
        }

        public static Response<QuizQuestionDto> Delete(long id, bool cascade = false)
        {
            return new DAL.QuizQuestion().Delete(id, cascade);
        }
    }
}