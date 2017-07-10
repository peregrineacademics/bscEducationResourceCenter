using System;
using System.Linq.Expressions;
using PAS.ResourceCenter.Library.DataAccess.Interfaces;
using PAS.ResourceCenter.Library.DataAccess.Models;
using PAS.ResourceCenter.Library.DataAccess.Responses;
using System.Collections.Generic;

// This file is generated. DO NOT MODIFY
namespace PAS.ResourceCenter.Library.DataAccess.DTO
{
    public partial class DiscussionQuestionDto : IDiscussionQuestion
    {
        public DiscussionQuestionDto(string byUserId = "")
        {
			Id = 0;
			Ordinal = 0;
			Question = "";
			ReviewId = 0;

        }

        public DiscussionQuestionDto(IDiscussionQuestion item, bool includeNavigation = false)
        {
            if (item != null)
                Assign(item, includeNavigation);
        }

		public Int64 Id{ get; set; }
		public Int64 Ordinal{ get; set; }
		public String Question{ get; set; }
		public Int64 ReviewId{ get; set; }

		public Models.Review Review { get; set; }


        internal void Assign(IDiscussionQuestion item, bool includeNavigation = false)
        {
            if (item == null)
                throw new ArgumentNullException(nameof(item));

            DiscussionQuestion.Assign(item, this, includeNavigation);
        }

        public static Response<DiscussionQuestionDto> Create(DiscussionQuestionDto item)
        {
            if (item == null)
            {
                return new Response<DiscussionQuestionDto>(StatusCodes.EXCEPTION);
            }

            return new DAL.DiscussionQuestion().Create(item);
        }

        public static Response<DiscussionQuestionDto> Get(long id, bool includeNavigation = false)
        {
            return new DAL.DiscussionQuestion().Get(id, includeNavigation);
        }

        public static Response<DiscussionQuestionDto> Select(Expression<Func<IDiscussionQuestion, bool>> whereClause = null, bool includeNavigation = false)
        {
            return new DAL.DiscussionQuestion().Select(whereClause, includeNavigation);
        }

        public static Response<DiscussionQuestionDto> Update(DiscussionQuestionDto item)
        {
            if (item == null)
            {
                return new Response<DiscussionQuestionDto>(StatusCodes.EXCEPTION);
            }

            return new DAL.DiscussionQuestion().Update(item);
        }

        public Response<DiscussionQuestionDto> Update()
        {
            return new DAL.DiscussionQuestion().Update(this);
        }

        public static Response<DiscussionQuestionDto> Delete(long id, bool cascade = false)
        {
            return new DAL.DiscussionQuestion().Delete(id, cascade);
        }
    }
}