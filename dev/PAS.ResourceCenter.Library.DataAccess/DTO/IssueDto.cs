using System;
using System.Linq.Expressions;
using PAS.ResourceCenter.Library.DataAccess.Interfaces;
using PAS.ResourceCenter.Library.DataAccess.Models;
using PAS.ResourceCenter.Library.DataAccess.Responses;
using System.Collections.Generic;

// This file is generated. DO NOT MODIFY
namespace PAS.ResourceCenter.Library.DataAccess.DTO
{
    public partial class IssueDto : IIssue
    {
        public IssueDto(string byUserId = "")
        {
			CoverImage = "";
			CoverStoryUrl = "";
			CreatedByUserId = byUserId;
			DateCreated = DateTime.Now;
			Id = 0;
			//	We are creating our own default Min Date. 
			//	It is here because the min date of C# and SQL Server/MySql are different which sometimes causing problems.
			//	The is no guarantee the value is defaulted in the dab to something universal. 
			//	It is pretty lame but it is a workaround for an even lamer limitation in C#/Sql Server 
			IssueDate = new DateTime(1900,1,1);
			IssueName = "";
			IssueTitle = "";
			IssueUrlName = "";
			LastUpdated = DateTime.Now;
			UpdatedByUserId = byUserId;

        }

        public IssueDto(IIssue item, bool includeNavigation = false)
        {
            if (item != null)
                Assign(item, includeNavigation);
        }

		public String CoverImage{ get; set; }
		public String CoverStoryUrl{ get; set; }
		public String CreatedByUserId{ get; set; }
		public DateTime DateCreated{ get; set; }
		public Int64 Id{ get; set; }
		public Boolean IsEnabled{ get; set; }
		public DateTime IssueDate{ get; set; }
		public String IssueName{ get; set; }
		public String IssueTitle{ get; set; }
		public String IssueUrlName{ get; set; }
		public DateTime LastUpdated{ get; set; }
		public String UpdatedByUserId{ get; set; }

		public Models.Users CreatedByUser { get; set; }
		public ICollection<Review> Review { get; set; }
		public Models.Users UpdatedByUser { get; set; }


        internal void Assign(IIssue item, bool includeNavigation = false)
        {
            if (item == null)
                throw new ArgumentNullException(nameof(item));

            Issue.Assign(item, this, includeNavigation);
        }

        public static Response<IssueDto> Create(IssueDto item)
        {
            if (item == null)
            {
                return new Response<IssueDto>(StatusCodes.EXCEPTION);
            }

            return new DAL.Issue().Create(item);
        }

        public static Response<IssueDto> Get(long id, bool includeNavigation = false)
        {
            return new DAL.Issue().Get(id, includeNavigation);
        }

        public static Response<IssueDto> Select(Expression<Func<IIssue, bool>> whereClause = null, bool includeNavigation = false)
        {
            return new DAL.Issue().Select(whereClause, includeNavigation);
        }

        public static Response<IssueDto> Update(IssueDto item)
        {
            if (item == null)
            {
                return new Response<IssueDto>(StatusCodes.EXCEPTION);
            }

            return new DAL.Issue().Update(item);
        }

        public Response<IssueDto> Update()
        {
            return new DAL.Issue().Update(this);
        }

        public static Response<IssueDto> Delete(long id, bool cascade = false)
        {
            return new DAL.Issue().Delete(id, cascade);
        }
    }
}