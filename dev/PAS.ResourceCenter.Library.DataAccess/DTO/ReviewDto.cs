using System;
using System.Linq.Expressions;
using PAS.ResourceCenter.Library.DataAccess.Interfaces;
using PAS.ResourceCenter.Library.DataAccess.Models;
using PAS.ResourceCenter.Library.DataAccess.Responses;
using System.Collections.Generic;

// This file is generated. DO NOT MODIFY
namespace PAS.ResourceCenter.Library.DataAccess.DTO
{
    public partial class ReviewDto : IReview
    {
        public ReviewDto(string byUserId = "")
        {
			Abstract = "";
			CreatedByUserId = byUserId;
			DateCreated = DateTime.Now;
			GuideTypeId = 0;
			Id = 0;
			IssueId = 0;
			KeyWords = "";
			LastUpdated = DateTime.Now;
			ReviewerId = "";
			ReviewStatusId = 0;
			Summary = "";
			Title = "";
			UpdatedByUserId = byUserId;
			Url = "";

        }

        public ReviewDto(IReview item, bool includeNavigation = false)
        {
            if (item != null)
                Assign(item, includeNavigation);
        }

		public String Abstract{ get; set; }
		public String CreatedByUserId{ get; set; }
		public DateTime DateCreated{ get; set; }
		public Int64 GuideTypeId{ get; set; }
		public Int64 Id{ get; set; }
		public Int64 IssueId{ get; set; }
		public String KeyWords{ get; set; }
		public DateTime LastUpdated{ get; set; }
		public Boolean Migrated{ get; set; }
		public String ReviewerId{ get; set; }
		public Int64 ReviewStatusId{ get; set; }
		public String Summary{ get; set; }
		public String Title{ get; set; }
		public String UpdatedByUserId{ get; set; }
		public String Url{ get; set; }

		public Models.Users CreatedByUser { get; set; }
		public Models.GuideType GuideType { get; set; }
		public Models.Issue Issue { get; set; }
		public ICollection<ReviewCategory> ReviewCategory { get; set; }
		public Models.Users Reviewer { get; set; }
		public Models.ReviewStatus ReviewStatus { get; set; }
		public Models.Users UpdatedByUser { get; set; }


        internal void Assign(IReview item, bool includeNavigation = false)
        {
            if (item == null)
                throw new ArgumentNullException(nameof(item));

            Review.Assign(item, this, includeNavigation);
        }

        public static Response<ReviewDto> Create(ReviewDto item)
        {
            if (item == null)
            {
                return new Response<ReviewDto>(StatusCodes.EXCEPTION);
            }

            return new DAL.Review().Create(item);
        }

        public static Response<ReviewDto> Get(long id, bool includeNavigation = false)
        {
            return new DAL.Review().Get(id, includeNavigation);
        }

        public static Response<ReviewDto> Select(Expression<Func<IReview, bool>> whereClause = null, bool includeNavigation = false)
        {
            return new DAL.Review().Select(whereClause, includeNavigation);
        }

        public static Response<ReviewDto> Update(ReviewDto item)
        {
            if (item == null)
            {
                return new Response<ReviewDto>(StatusCodes.EXCEPTION);
            }

            return new DAL.Review().Update(item);
        }

        public Response<ReviewDto> Update()
        {
            return new DAL.Review().Update(this);
        }

        public static Response<ReviewDto> Delete(long id, bool cascade = false)
        {
            return new DAL.Review().Delete(id, cascade);
        }
    }
}