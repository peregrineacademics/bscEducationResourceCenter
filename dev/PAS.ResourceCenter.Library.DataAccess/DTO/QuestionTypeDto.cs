using System;
using System.Linq.Expressions;
using PAS.ResourceCenter.Library.DataAccess.Interfaces;
using PAS.ResourceCenter.Library.DataAccess.Models;
using PAS.ResourceCenter.Library.DataAccess.Responses;
using System.Collections.Generic;

// This file is generated. DO NOT MODIFY
namespace PAS.ResourceCenter.Library.DataAccess.DTO
{
    public partial class QuestionTypeDto : IQuestionType
    {
        public QuestionTypeDto(string byUserId = "")
        {
			Id = 0;
			Name = "";

        }

        public QuestionTypeDto(IQuestionType item, bool includeNavigation = false)
        {
            if (item != null)
                Assign(item, includeNavigation);
        }

		public Int64 Id{ get; set; }
		public String Name{ get; set; }

		public ICollection<QuizQuestion> QuizQuestion { get; set; }


        internal void Assign(IQuestionType item, bool includeNavigation = false)
        {
            if (item == null)
                throw new ArgumentNullException(nameof(item));

            QuestionType.Assign(item, this, includeNavigation);
        }

        public static Response<QuestionTypeDto> Create(QuestionTypeDto item)
        {
            if (item == null)
            {
                return new Response<QuestionTypeDto>(StatusCodes.EXCEPTION);
            }

            return new DAL.QuestionType().Create(item);
        }

        public static Response<QuestionTypeDto> Get(long id, bool includeNavigation = false)
        {
            return new DAL.QuestionType().Get(id, includeNavigation);
        }

        public static Response<QuestionTypeDto> Select(Expression<Func<IQuestionType, bool>> whereClause = null, bool includeNavigation = false)
        {
            return new DAL.QuestionType().Select(whereClause, includeNavigation);
        }

        public static Response<QuestionTypeDto> Update(QuestionTypeDto item)
        {
            if (item == null)
            {
                return new Response<QuestionTypeDto>(StatusCodes.EXCEPTION);
            }

            return new DAL.QuestionType().Update(item);
        }

        public Response<QuestionTypeDto> Update()
        {
            return new DAL.QuestionType().Update(this);
        }

        public static Response<QuestionTypeDto> Delete(long id, bool cascade = false)
        {
            return new DAL.QuestionType().Delete(id, cascade);
        }
    }
}