using System;
using System.Linq.Expressions;
using PAS.ResourceCenter.Library.DataAccess.Interfaces;
using PAS.ResourceCenter.Library.DataAccess.Models;
using PAS.ResourceCenter.Library.DataAccess.Responses;
using System.Collections.Generic;

// This file is generated. DO NOT MODIFY
namespace PAS.ResourceCenter.Library.DataAccess.DTO
{
    public partial class ReviewRegionDto : IReviewRegion
    {
        public ReviewRegionDto(string byUserId = "")
        {
			Id = 0;
			RegionId = 0;
			ReviewId = 0;

        }

        public ReviewRegionDto(IReviewRegion item, bool includeNavigation = false)
        {
            if (item != null)
                Assign(item, includeNavigation);
        }

		public Int64 Id{ get; set; }
		public Int64 RegionId{ get; set; }
		public Int64 ReviewId{ get; set; }

		public Models.Region Region { get; set; }
		public Models.Review Review { get; set; }


        internal void Assign(IReviewRegion item, bool includeNavigation = false)
        {
            if (item == null)
                throw new ArgumentNullException(nameof(item));

            ReviewRegion.Assign(item, this, includeNavigation);
        }

        public static Response<ReviewRegionDto> Create(ReviewRegionDto item)
        {
            if (item == null)
            {
                return new Response<ReviewRegionDto>(StatusCodes.EXCEPTION);
            }

            return new DAL.ReviewRegion().Create(item);
        }

        public static Response<ReviewRegionDto> Get(long id, bool includeNavigation = false)
        {
            return new DAL.ReviewRegion().Get(id, includeNavigation);
        }

        public static Response<ReviewRegionDto> Select(Expression<Func<IReviewRegion, bool>> whereClause = null, bool includeNavigation = false)
        {
            return new DAL.ReviewRegion().Select(whereClause, includeNavigation);
        }

        public static Response<ReviewRegionDto> Update(ReviewRegionDto item)
        {
            if (item == null)
            {
                return new Response<ReviewRegionDto>(StatusCodes.EXCEPTION);
            }

            return new DAL.ReviewRegion().Update(item);
        }

        public Response<ReviewRegionDto> Update()
        {
            return new DAL.ReviewRegion().Update(this);
        }

        public static Response<ReviewRegionDto> Delete(long id, bool cascade = false)
        {
            return new DAL.ReviewRegion().Delete(id, cascade);
        }
    }
}