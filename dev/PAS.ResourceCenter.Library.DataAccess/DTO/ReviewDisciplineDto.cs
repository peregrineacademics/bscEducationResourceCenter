using System;
using System.Linq.Expressions;
using PAS.ResourceCenter.Library.DataAccess.Interfaces;
using PAS.ResourceCenter.Library.DataAccess.Models;
using PAS.ResourceCenter.Library.DataAccess.Responses;
using System.Collections.Generic;

// This file is generated. DO NOT MODIFY
namespace PAS.ResourceCenter.Library.DataAccess.DTO
{
    public partial class ReviewDisciplineDto : IReviewDiscipline
    {
        public ReviewDisciplineDto(string byUserId = "")
        {
			DisciplineId = 0;
			Id = 0;
			ReviewId = 0;

        }

        public ReviewDisciplineDto(IReviewDiscipline item, bool includeNavigation = false)
        {
            if (item != null)
                Assign(item, includeNavigation);
        }

		public Int64 DisciplineId{ get; set; }
		public Int64 Id{ get; set; }
		public Int64 ReviewId{ get; set; }

		public Models.Discipline Discipline { get; set; }
		public Models.Review Review { get; set; }


        internal void Assign(IReviewDiscipline item, bool includeNavigation = false)
        {
            if (item == null)
                throw new ArgumentNullException(nameof(item));

            ReviewDiscipline.Assign(item, this, includeNavigation);
        }

        public static Response<ReviewDisciplineDto> Create(ReviewDisciplineDto item)
        {
            if (item == null)
            {
                return new Response<ReviewDisciplineDto>(StatusCodes.EXCEPTION);
            }

            return new DAL.ReviewDiscipline().Create(item);
        }

        public static Response<ReviewDisciplineDto> Get(long id, bool includeNavigation = false)
        {
            return new DAL.ReviewDiscipline().Get(id, includeNavigation);
        }

        public static Response<ReviewDisciplineDto> Select(Expression<Func<IReviewDiscipline, bool>> whereClause = null, bool includeNavigation = false)
        {
            return new DAL.ReviewDiscipline().Select(whereClause, includeNavigation);
        }

        public static Response<ReviewDisciplineDto> Update(ReviewDisciplineDto item)
        {
            if (item == null)
            {
                return new Response<ReviewDisciplineDto>(StatusCodes.EXCEPTION);
            }

            return new DAL.ReviewDiscipline().Update(item);
        }

        public Response<ReviewDisciplineDto> Update()
        {
            return new DAL.ReviewDiscipline().Update(this);
        }

        public static Response<ReviewDisciplineDto> Delete(long id, bool cascade = false)
        {
            return new DAL.ReviewDiscipline().Delete(id, cascade);
        }
    }
}