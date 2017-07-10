using System;
using System.Linq.Expressions;
using PAS.ResourceCenter.Library.DataAccess.Interfaces;
using PAS.ResourceCenter.Library.DataAccess.Models;
using PAS.ResourceCenter.Library.DataAccess.Responses;
using System.Collections.Generic;

// This file is generated. DO NOT MODIFY
namespace PAS.ResourceCenter.Library.DataAccess.DTO
{
    public partial class ReviewCompetencyDto : IReviewCompetency
    {
        public ReviewCompetencyDto(string byUserId = "")
        {
			CompetencyId = 0;
			Id = 0;
			ReviewId = 0;

        }

        public ReviewCompetencyDto(IReviewCompetency item, bool includeNavigation = false)
        {
            if (item != null)
                Assign(item, includeNavigation);
        }

		public Int64 CompetencyId{ get; set; }
		public Int64 Id{ get; set; }
		public Int64 ReviewId{ get; set; }

		public Models.Competency Competency { get; set; }
		public Models.Review Review { get; set; }


        internal void Assign(IReviewCompetency item, bool includeNavigation = false)
        {
            if (item == null)
                throw new ArgumentNullException(nameof(item));

            ReviewCompetency.Assign(item, this, includeNavigation);
        }

        public static Response<ReviewCompetencyDto> Create(ReviewCompetencyDto item)
        {
            if (item == null)
            {
                return new Response<ReviewCompetencyDto>(StatusCodes.EXCEPTION);
            }

            return new DAL.ReviewCompetency().Create(item);
        }

        public static Response<ReviewCompetencyDto> Get(long id, bool includeNavigation = false)
        {
            return new DAL.ReviewCompetency().Get(id, includeNavigation);
        }

        public static Response<ReviewCompetencyDto> Select(Expression<Func<IReviewCompetency, bool>> whereClause = null, bool includeNavigation = false)
        {
            return new DAL.ReviewCompetency().Select(whereClause, includeNavigation);
        }

        public static Response<ReviewCompetencyDto> Update(ReviewCompetencyDto item)
        {
            if (item == null)
            {
                return new Response<ReviewCompetencyDto>(StatusCodes.EXCEPTION);
            }

            return new DAL.ReviewCompetency().Update(item);
        }

        public Response<ReviewCompetencyDto> Update()
        {
            return new DAL.ReviewCompetency().Update(this);
        }

        public static Response<ReviewCompetencyDto> Delete(long id, bool cascade = false)
        {
            return new DAL.ReviewCompetency().Delete(id, cascade);
        }
    }
}