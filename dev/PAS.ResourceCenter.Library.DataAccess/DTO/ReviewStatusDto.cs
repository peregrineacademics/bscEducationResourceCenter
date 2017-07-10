using System;
using System.Linq.Expressions;
using PAS.ResourceCenter.Library.DataAccess.Interfaces;
using PAS.ResourceCenter.Library.DataAccess.Models;
using PAS.ResourceCenter.Library.DataAccess.Responses;
using System.Collections.Generic;

// This file is generated. DO NOT MODIFY
namespace PAS.ResourceCenter.Library.DataAccess.DTO
{
    public partial class ReviewStatusDto : IReviewStatus
    {
        public ReviewStatusDto(string byUserId = "")
        {
			Id = 0;
			Name = "";

        }

        public ReviewStatusDto(IReviewStatus item, bool includeNavigation = false)
        {
            if (item != null)
                Assign(item, includeNavigation);
        }

		public Int64 Id{ get; set; }
		public String Name{ get; set; }

		public ICollection<Review> Review { get; set; }


        internal void Assign(IReviewStatus item, bool includeNavigation = false)
        {
            if (item == null)
                throw new ArgumentNullException(nameof(item));

            ReviewStatus.Assign(item, this, includeNavigation);
        }

        public static Response<ReviewStatusDto> Create(ReviewStatusDto item)
        {
            if (item == null)
            {
                return new Response<ReviewStatusDto>(StatusCodes.EXCEPTION);
            }

            return new DAL.ReviewStatus().Create(item);
        }

        public static Response<ReviewStatusDto> Get(long id, bool includeNavigation = false)
        {
            return new DAL.ReviewStatus().Get(id, includeNavigation);
        }

        public static Response<ReviewStatusDto> Select(Expression<Func<IReviewStatus, bool>> whereClause = null, bool includeNavigation = false)
        {
            return new DAL.ReviewStatus().Select(whereClause, includeNavigation);
        }

        public static Response<ReviewStatusDto> Update(ReviewStatusDto item)
        {
            if (item == null)
            {
                return new Response<ReviewStatusDto>(StatusCodes.EXCEPTION);
            }

            return new DAL.ReviewStatus().Update(item);
        }

        public Response<ReviewStatusDto> Update()
        {
            return new DAL.ReviewStatus().Update(this);
        }

        public static Response<ReviewStatusDto> Delete(long id, bool cascade = false)
        {
            return new DAL.ReviewStatus().Delete(id, cascade);
        }
    }
}