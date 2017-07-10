using System;
using System.Linq.Expressions;
using PAS.ResourceCenter.Library.DataAccess.Interfaces;
using PAS.ResourceCenter.Library.DataAccess.Models;
using PAS.ResourceCenter.Library.DataAccess.Responses;
using System.Collections.Generic;

// This file is generated. DO NOT MODIFY
namespace PAS.ResourceCenter.Library.DataAccess.DTO
{
    public partial class QuizAnswerDto : IQuizAnswer
    {
        public QuizAnswerDto(string byUserId = "")
        {
			Answer = "";
			Id = 0;
			Ordinal = 0;
			QuizQuestionId = 0;

        }

        public QuizAnswerDto(IQuizAnswer item, bool includeNavigation = false)
        {
            if (item != null)
                Assign(item, includeNavigation);
        }

		public String Answer{ get; set; }
		public Int64 Id{ get; set; }
		public Int64 Ordinal{ get; set; }
		public Int64 QuizQuestionId{ get; set; }

		public Models.QuizQuestion QuizQuestion { get; set; }


        internal void Assign(IQuizAnswer item, bool includeNavigation = false)
        {
            if (item == null)
                throw new ArgumentNullException(nameof(item));

            QuizAnswer.Assign(item, this, includeNavigation);
        }

        public static Response<QuizAnswerDto> Create(QuizAnswerDto item)
        {
            if (item == null)
            {
                return new Response<QuizAnswerDto>(StatusCodes.EXCEPTION);
            }

            return new DAL.QuizAnswer().Create(item);
        }

        public static Response<QuizAnswerDto> Get(long id, bool includeNavigation = false)
        {
            return new DAL.QuizAnswer().Get(id, includeNavigation);
        }

        public static Response<QuizAnswerDto> Select(Expression<Func<IQuizAnswer, bool>> whereClause = null, bool includeNavigation = false)
        {
            return new DAL.QuizAnswer().Select(whereClause, includeNavigation);
        }

        public static Response<QuizAnswerDto> Update(QuizAnswerDto item)
        {
            if (item == null)
            {
                return new Response<QuizAnswerDto>(StatusCodes.EXCEPTION);
            }

            return new DAL.QuizAnswer().Update(item);
        }

        public Response<QuizAnswerDto> Update()
        {
            return new DAL.QuizAnswer().Update(this);
        }

        public static Response<QuizAnswerDto> Delete(long id, bool cascade = false)
        {
            return new DAL.QuizAnswer().Delete(id, cascade);
        }
    }
}