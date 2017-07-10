using System;
using System.Linq.Expressions;
using PAS.ResourceCenter.Library.DataAccess.Interfaces;
using PAS.ResourceCenter.Library.DataAccess.Models;
using PAS.ResourceCenter.Library.DataAccess.Responses;
using System.Collections.Generic;

// This file is generated. DO NOT MODIFY
namespace PAS.ResourceCenter.Library.DataAccess.DTO
{
    public partial class ReviewSectorDto : IReviewSector
    {
        public ReviewSectorDto(string byUserId = "")
        {
			Id = 0;
			ReviewId = 0;
			SectorId = 0;

        }

        public ReviewSectorDto(IReviewSector item, bool includeNavigation = false)
        {
            if (item != null)
                Assign(item, includeNavigation);
        }

		public Int64 Id{ get; set; }
		public Int64 ReviewId{ get; set; }
		public Int64 SectorId{ get; set; }

		public Models.Review Review { get; set; }
		public Models.Sector Sector { get; set; }


        internal void Assign(IReviewSector item, bool includeNavigation = false)
        {
            if (item == null)
                throw new ArgumentNullException(nameof(item));

            ReviewSector.Assign(item, this, includeNavigation);
        }

        public static Response<ReviewSectorDto> Create(ReviewSectorDto item)
        {
            if (item == null)
            {
                return new Response<ReviewSectorDto>(StatusCodes.EXCEPTION);
            }

            return new DAL.ReviewSector().Create(item);
        }

        public static Response<ReviewSectorDto> Get(long id, bool includeNavigation = false)
        {
            return new DAL.ReviewSector().Get(id, includeNavigation);
        }

        public static Response<ReviewSectorDto> Select(Expression<Func<IReviewSector, bool>> whereClause = null, bool includeNavigation = false)
        {
            return new DAL.ReviewSector().Select(whereClause, includeNavigation);
        }

        public static Response<ReviewSectorDto> Update(ReviewSectorDto item)
        {
            if (item == null)
            {
                return new Response<ReviewSectorDto>(StatusCodes.EXCEPTION);
            }

            return new DAL.ReviewSector().Update(item);
        }

        public Response<ReviewSectorDto> Update()
        {
            return new DAL.ReviewSector().Update(this);
        }

        public static Response<ReviewSectorDto> Delete(long id, bool cascade = false)
        {
            return new DAL.ReviewSector().Delete(id, cascade);
        }
    }
}