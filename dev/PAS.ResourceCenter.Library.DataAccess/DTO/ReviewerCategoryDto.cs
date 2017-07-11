using System;
using System.Linq.Expressions;
using PAS.ResourceCenter.Library.DataAccess.Interfaces;
using PAS.ResourceCenter.Library.DataAccess.Models;
using PAS.ResourceCenter.Library.DataAccess.Responses;
using System.Collections.Generic;

// This file is generated. DO NOT MODIFY
namespace PAS.ResourceCenter.Library.DataAccess.DTO
{
    public partial class ReviewerCategoryDto : IReviewerCategory
    {
        public ReviewerCategoryDto(string byUserId = "")
        {
			Categoryid = 0;
			Id = 0;
			UserId = "";

        }

        public ReviewerCategoryDto(IReviewerCategory item, bool includeNavigation = false)
        {
            if (item != null)
                Assign(item, includeNavigation);
        }

		public Int64 Categoryid{ get; set; }
		public Int64 Id{ get; set; }
		public String UserId{ get; set; }

		public Models.Category Category { get; set; }
		public Models.Users User { get; set; }


        internal void Assign(IReviewerCategory item, bool includeNavigation = false)
        {
            if (item == null)
                throw new ArgumentNullException(nameof(item));

            ReviewerCategory.Assign(item, this, includeNavigation);
        }

        public static Response<ReviewerCategoryDto> Create(ReviewerCategoryDto item)
        {
            if (item == null)
            {
                return new Response<ReviewerCategoryDto>(StatusCodes.EXCEPTION);
            }

            return new DAL.ReviewerCategory().Create(item);
        }

        public static Response<ReviewerCategoryDto> Get(long id, bool includeNavigation = false)
        {
            return new DAL.ReviewerCategory().Get(id, includeNavigation);
        }

        public static Response<ReviewerCategoryDto> Select(Expression<Func<IReviewerCategory, bool>> whereClause = null, bool includeNavigation = false)
        {
            return new DAL.ReviewerCategory().Select(whereClause, includeNavigation);
        }

        public static Response<ReviewerCategoryDto> Update(ReviewerCategoryDto item)
        {
            if (item == null)
            {
                return new Response<ReviewerCategoryDto>(StatusCodes.EXCEPTION);
            }

            return new DAL.ReviewerCategory().Update(item);
        }

        public Response<ReviewerCategoryDto> Update()
        {
            return new DAL.ReviewerCategory().Update(this);
        }

        public static Response<ReviewerCategoryDto> Delete(long id, bool cascade = false)
        {
            return new DAL.ReviewerCategory().Delete(id, cascade);
        }
    }
}