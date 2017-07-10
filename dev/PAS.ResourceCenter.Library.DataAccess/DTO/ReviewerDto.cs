using System;
using System.Linq.Expressions;
using PAS.ResourceCenter.Library.DataAccess.Interfaces;
using PAS.ResourceCenter.Library.DataAccess.Models;
using PAS.ResourceCenter.Library.DataAccess.Responses;
using System.Collections.Generic;

// This file is generated. DO NOT MODIFY
namespace PAS.ResourceCenter.Library.DataAccess.DTO
{
    public partial class ReviewerDto : IReviewer
    {
        public ReviewerDto(string byUserId = "")
        {
			Biography = "";
			CreatedByUserId = byUserId;
			DateCreated = DateTime.Now;
			Degree = "";
			Id = 0;
			LastUpdated = DateTime.Now;
			UpdatedByUserId = byUserId;
			UserId = "";

        }

        public ReviewerDto(IReviewer item, bool includeNavigation = false)
        {
            if (item != null)
                Assign(item, includeNavigation);
        }

		public String Biography{ get; set; }
		public String CreatedByUserId{ get; set; }
		public DateTime DateCreated{ get; set; }
		public String Degree{ get; set; }
		public Boolean HideFromReviewerList{ get; set; }
		public Int64 Id{ get; set; }
		public Boolean IsActive{ get; set; }
		public DateTime LastUpdated{ get; set; }
		public String UpdatedByUserId{ get; set; }
		public String UserId{ get; set; }

		public ICollection<Review> Review { get; set; }
		public Models.Users UpdatedByUser { get; set; }
		public Models.Users User { get; set; }


        internal void Assign(IReviewer item, bool includeNavigation = false)
        {
            if (item == null)
                throw new ArgumentNullException(nameof(item));

            Reviewer.Assign(item, this, includeNavigation);
        }

        public static Response<ReviewerDto> Create(ReviewerDto item)
        {
            if (item == null)
            {
                return new Response<ReviewerDto>(StatusCodes.EXCEPTION);
            }

            return new DAL.Reviewer().Create(item);
        }

        public static Response<ReviewerDto> Get(long id, bool includeNavigation = false)
        {
            return new DAL.Reviewer().Get(id, includeNavigation);
        }

        public static Response<ReviewerDto> Select(Expression<Func<IReviewer, bool>> whereClause = null, bool includeNavigation = false)
        {
            return new DAL.Reviewer().Select(whereClause, includeNavigation);
        }

        public static Response<ReviewerDto> Update(ReviewerDto item)
        {
            if (item == null)
            {
                return new Response<ReviewerDto>(StatusCodes.EXCEPTION);
            }

            return new DAL.Reviewer().Update(item);
        }

        public Response<ReviewerDto> Update()
        {
            return new DAL.Reviewer().Update(this);
        }

        public static Response<ReviewerDto> Delete(long id, bool cascade = false)
        {
            return new DAL.Reviewer().Delete(id, cascade);
        }
    }
}