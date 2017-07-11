using System;
using System.Linq.Expressions;
using PAS.ResourceCenter.Library.DataAccess.Interfaces;
using PAS.ResourceCenter.Library.DataAccess.Models;
using PAS.ResourceCenter.Library.DataAccess.Responses;
/* Insert Collections */

// This file is generated. DO NOT MODIFY
namespace PAS.ResourceCenter.Library.DataAccess.DTO
{
    public partial class ReviewActivityDto : IReviewActivity
    {
        public ReviewActivityDto(string byUserId = "")
        {
			Activity = "";
			Id = 0;
			Ordinal = 0;
			ReviewId = 0;

        }

        public ReviewActivityDto(IReviewActivity item, bool includeNavigation = false)
        {
            if (item != null)
                Assign(item, includeNavigation);
        }

		public String Activity{ get; set; }
		public Int64 Id{ get; set; }
		public Int64 Ordinal{ get; set; }
		public Int64 ReviewId{ get; set; }


        internal void Assign(IReviewActivity item, bool includeNavigation = false)
        {
            if (item == null)
                throw new ArgumentNullException(nameof(item));

            ReviewActivity.Assign(item, this, includeNavigation);
        }

        public static Response<ReviewActivityDto> Create(ReviewActivityDto item)
        {
            if (item == null)
            {
                return new Response<ReviewActivityDto>(StatusCodes.EXCEPTION);
            }

            return new DAL.ReviewActivity().Create(item);
        }

        public static Response<ReviewActivityDto> Get(long id, bool includeNavigation = false)
        {
            return new DAL.ReviewActivity().Get(id, includeNavigation);
        }

        public static Response<ReviewActivityDto> Select(Expression<Func<IReviewActivity, bool>> whereClause = null, bool includeNavigation = false)
        {
            return new DAL.ReviewActivity().Select(whereClause, includeNavigation);
        }

        public static Response<ReviewActivityDto> Update(ReviewActivityDto item)
        {
            if (item == null)
            {
                return new Response<ReviewActivityDto>(StatusCodes.EXCEPTION);
            }

            return new DAL.ReviewActivity().Update(item);
        }

        public Response<ReviewActivityDto> Update()
        {
            return new DAL.ReviewActivity().Update(this);
        }

        public static Response<ReviewActivityDto> Delete(long id, bool cascade = false)
        {
            return new DAL.ReviewActivity().Delete(id, cascade);
        }
    }
}