using System;
using System.Linq.Expressions;
using PAS.ResourceCenter.Library.DataAccess.Interfaces;
using PAS.ResourceCenter.Library.DataAccess.Models;
using PAS.ResourceCenter.Library.DataAccess.Responses;
using System.Collections.Generic;

// This file is generated. DO NOT MODIFY
namespace PAS.ResourceCenter.Library.DataAccess.DTO
{
    public partial class ReviewSubTopicDto : IReviewSubTopic
    {
        public ReviewSubTopicDto(string byUserId = "")
        {
			Id = 0;
			ReviewId = 0;
			SubTopicId = 0;

        }

        public ReviewSubTopicDto(IReviewSubTopic item, bool includeNavigation = false)
        {
            if (item != null)
                Assign(item, includeNavigation);
        }

		public Int64 Id{ get; set; }
		public Int64 ReviewId{ get; set; }
		public Int64 SubTopicId{ get; set; }

		public Models.Review Review { get; set; }
		public Models.SubTopic SubTopic { get; set; }


        internal void Assign(IReviewSubTopic item, bool includeNavigation = false)
        {
            if (item == null)
                throw new ArgumentNullException(nameof(item));

            ReviewSubTopic.Assign(item, this, includeNavigation);
        }

        public static Response<ReviewSubTopicDto> Create(ReviewSubTopicDto item)
        {
            if (item == null)
            {
                return new Response<ReviewSubTopicDto>(StatusCodes.EXCEPTION);
            }

            return new DAL.ReviewSubTopic().Create(item);
        }

        public static Response<ReviewSubTopicDto> Get(long id, bool includeNavigation = false)
        {
            return new DAL.ReviewSubTopic().Get(id, includeNavigation);
        }

        public static Response<ReviewSubTopicDto> Select(Expression<Func<IReviewSubTopic, bool>> whereClause = null, bool includeNavigation = false)
        {
            return new DAL.ReviewSubTopic().Select(whereClause, includeNavigation);
        }

        public static Response<ReviewSubTopicDto> Update(ReviewSubTopicDto item)
        {
            if (item == null)
            {
                return new Response<ReviewSubTopicDto>(StatusCodes.EXCEPTION);
            }

            return new DAL.ReviewSubTopic().Update(item);
        }

        public Response<ReviewSubTopicDto> Update()
        {
            return new DAL.ReviewSubTopic().Update(this);
        }

        public static Response<ReviewSubTopicDto> Delete(long id, bool cascade = false)
        {
            return new DAL.ReviewSubTopic().Delete(id, cascade);
        }
    }
}