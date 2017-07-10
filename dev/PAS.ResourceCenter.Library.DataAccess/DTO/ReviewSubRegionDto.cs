using System;
using System.Linq.Expressions;
using PAS.ResourceCenter.Library.DataAccess.Interfaces;
using PAS.ResourceCenter.Library.DataAccess.Models;
using PAS.ResourceCenter.Library.DataAccess.Responses;
using System.Collections.Generic;

// This file is generated. DO NOT MODIFY
namespace PAS.ResourceCenter.Library.DataAccess.DTO
{
    public partial class ReviewSubRegionDto : IReviewSubRegion
    {
        public ReviewSubRegionDto(string byUserId = "")
        {
			Id = 0;
			ReviewId = 0;
			SubRegionId = 0;

        }

        public ReviewSubRegionDto(IReviewSubRegion item, bool includeNavigation = false)
        {
            if (item != null)
                Assign(item, includeNavigation);
        }

		public Int64 Id{ get; set; }
		public Int64 ReviewId{ get; set; }
		public Int64 SubRegionId{ get; set; }

		public Models.Review Review { get; set; }
		public Models.SubRegion SubRegion { get; set; }


        internal void Assign(IReviewSubRegion item, bool includeNavigation = false)
        {
            if (item == null)
                throw new ArgumentNullException(nameof(item));

            ReviewSubRegion.Assign(item, this, includeNavigation);
        }

        public static Response<ReviewSubRegionDto> Create(ReviewSubRegionDto item)
        {
            if (item == null)
            {
                return new Response<ReviewSubRegionDto>(StatusCodes.EXCEPTION);
            }

            return new DAL.ReviewSubRegion().Create(item);
        }

        public static Response<ReviewSubRegionDto> Get(long id, bool includeNavigation = false)
        {
            return new DAL.ReviewSubRegion().Get(id, includeNavigation);
        }

        public static Response<ReviewSubRegionDto> Select(Expression<Func<IReviewSubRegion, bool>> whereClause = null, bool includeNavigation = false)
        {
            return new DAL.ReviewSubRegion().Select(whereClause, includeNavigation);
        }

        public static Response<ReviewSubRegionDto> Update(ReviewSubRegionDto item)
        {
            if (item == null)
            {
                return new Response<ReviewSubRegionDto>(StatusCodes.EXCEPTION);
            }

            return new DAL.ReviewSubRegion().Update(item);
        }

        public Response<ReviewSubRegionDto> Update()
        {
            return new DAL.ReviewSubRegion().Update(this);
        }

        public static Response<ReviewSubRegionDto> Delete(long id, bool cascade = false)
        {
            return new DAL.ReviewSubRegion().Delete(id, cascade);
        }
    }
}