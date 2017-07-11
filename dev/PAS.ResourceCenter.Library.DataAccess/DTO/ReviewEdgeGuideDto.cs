using System;
using System.Linq.Expressions;
using PAS.ResourceCenter.Library.DataAccess.Interfaces;
using PAS.ResourceCenter.Library.DataAccess.Models;
using PAS.ResourceCenter.Library.DataAccess.Responses;
using System.Collections.Generic;

// This file is generated. DO NOT MODIFY
namespace PAS.ResourceCenter.Library.DataAccess.DTO
{
    public partial class ReviewEdgeGuideDto : IReviewEdgeGuide
    {
        public ReviewEdgeGuideDto(string byUserId = "")
        {
			EdgeGuideId = 0;
			Id = 0;
			ReviewId = 0;

        }

        public ReviewEdgeGuideDto(IReviewEdgeGuide item, bool includeNavigation = false)
        {
            if (item != null)
                Assign(item, includeNavigation);
        }

		public Int64 EdgeGuideId{ get; set; }
		public Int64 Id{ get; set; }
		public Int64 ReviewId{ get; set; }

		public Models.EdgeGuide EdgeGuide { get; set; }


        internal void Assign(IReviewEdgeGuide item, bool includeNavigation = false)
        {
            if (item == null)
                throw new ArgumentNullException(nameof(item));

            ReviewEdgeGuide.Assign(item, this, includeNavigation);
        }

        public static Response<ReviewEdgeGuideDto> Create(ReviewEdgeGuideDto item)
        {
            if (item == null)
            {
                return new Response<ReviewEdgeGuideDto>(StatusCodes.EXCEPTION);
            }

            return new DAL.ReviewEdgeGuide().Create(item);
        }

        public static Response<ReviewEdgeGuideDto> Get(long id, bool includeNavigation = false)
        {
            return new DAL.ReviewEdgeGuide().Get(id, includeNavigation);
        }

        public static Response<ReviewEdgeGuideDto> Select(Expression<Func<IReviewEdgeGuide, bool>> whereClause = null, bool includeNavigation = false)
        {
            return new DAL.ReviewEdgeGuide().Select(whereClause, includeNavigation);
        }

        public static Response<ReviewEdgeGuideDto> Update(ReviewEdgeGuideDto item)
        {
            if (item == null)
            {
                return new Response<ReviewEdgeGuideDto>(StatusCodes.EXCEPTION);
            }

            return new DAL.ReviewEdgeGuide().Update(item);
        }

        public Response<ReviewEdgeGuideDto> Update()
        {
            return new DAL.ReviewEdgeGuide().Update(this);
        }

        public static Response<ReviewEdgeGuideDto> Delete(long id, bool cascade = false)
        {
            return new DAL.ReviewEdgeGuide().Delete(id, cascade);
        }
    }
}