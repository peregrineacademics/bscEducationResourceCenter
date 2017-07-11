using System;
using System.Linq.Expressions;
using PAS.ResourceCenter.Library.DataAccess.Interfaces;
using PAS.ResourceCenter.Library.DataAccess.Models;
using PAS.ResourceCenter.Library.DataAccess.Responses;
using System.Collections.Generic;

// This file is generated. DO NOT MODIFY
namespace PAS.ResourceCenter.Library.DataAccess.DTO
{
    public partial class ReviewCategoryDto : IReviewCategory
    {
        public ReviewCategoryDto(string byUserId = "")
        {
			Categoryid = 0;
			Id = 0;
			ReviewId = 0;

        }

        public ReviewCategoryDto(IReviewCategory item, bool includeNavigation = false)
        {
            if (item != null)
                Assign(item, includeNavigation);
        }

		public Int64 Categoryid{ get; set; }
		public Int64 Id{ get; set; }
		public Int64 ReviewId{ get; set; }

		public Models.Category Category { get; set; }
		public Models.Review Review { get; set; }


        internal void Assign(IReviewCategory item, bool includeNavigation = false)
        {
            if (item == null)
                throw new ArgumentNullException(nameof(item));

            ReviewCategory.Assign(item, this, includeNavigation);
        }

        public static Response<ReviewCategoryDto> Create(ReviewCategoryDto item)
        {
            if (item == null)
            {
                return new Response<ReviewCategoryDto>(StatusCodes.EXCEPTION);
            }

            return new DAL.ReviewCategory().Create(item);
        }

        public static Response<ReviewCategoryDto> Get(long id, bool includeNavigation = false)
        {
            return new DAL.ReviewCategory().Get(id, includeNavigation);
        }

        public static Response<ReviewCategoryDto> Select(Expression<Func<IReviewCategory, bool>> whereClause = null, bool includeNavigation = false)
        {
            return new DAL.ReviewCategory().Select(whereClause, includeNavigation);
        }

        public static Response<ReviewCategoryDto> Update(ReviewCategoryDto item)
        {
            if (item == null)
            {
                return new Response<ReviewCategoryDto>(StatusCodes.EXCEPTION);
            }

            return new DAL.ReviewCategory().Update(item);
        }

        public Response<ReviewCategoryDto> Update()
        {
            return new DAL.ReviewCategory().Update(this);
        }

        public static Response<ReviewCategoryDto> Delete(long id, bool cascade = false)
        {
            return new DAL.ReviewCategory().Delete(id, cascade);
        }
    }
}