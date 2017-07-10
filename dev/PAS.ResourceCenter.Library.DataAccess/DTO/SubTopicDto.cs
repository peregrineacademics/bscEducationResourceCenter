using System;
using System.Linq.Expressions;
using PAS.ResourceCenter.Library.DataAccess.Interfaces;
using PAS.ResourceCenter.Library.DataAccess.Models;
using PAS.ResourceCenter.Library.DataAccess.Responses;
using System.Collections.Generic;

// This file is generated. DO NOT MODIFY
namespace PAS.ResourceCenter.Library.DataAccess.DTO
{
    public partial class SubTopicDto : ISubTopic
    {
        public SubTopicDto(string byUserId = "")
        {
			DisciplineId = 0;
			Id = 0;
			Name = "";

        }

        public SubTopicDto(ISubTopic item, bool includeNavigation = false)
        {
            if (item != null)
                Assign(item, includeNavigation);
        }

		public Int64 DisciplineId{ get; set; }
		public Int64 Id{ get; set; }
		public Boolean IsEnabled{ get; set; }
		public String Name{ get; set; }

		public Models.Discipline Discipline { get; set; }
		public ICollection<ReviewSubTopic> ReviewSubTopic { get; set; }


        internal void Assign(ISubTopic item, bool includeNavigation = false)
        {
            if (item == null)
                throw new ArgumentNullException(nameof(item));

            SubTopic.Assign(item, this, includeNavigation);
        }

        public static Response<SubTopicDto> Create(SubTopicDto item)
        {
            if (item == null)
            {
                return new Response<SubTopicDto>(StatusCodes.EXCEPTION);
            }

            return new DAL.SubTopic().Create(item);
        }

        public static Response<SubTopicDto> Get(long id, bool includeNavigation = false)
        {
            return new DAL.SubTopic().Get(id, includeNavigation);
        }

        public static Response<SubTopicDto> Select(Expression<Func<ISubTopic, bool>> whereClause = null, bool includeNavigation = false)
        {
            return new DAL.SubTopic().Select(whereClause, includeNavigation);
        }

        public static Response<SubTopicDto> Update(SubTopicDto item)
        {
            if (item == null)
            {
                return new Response<SubTopicDto>(StatusCodes.EXCEPTION);
            }

            return new DAL.SubTopic().Update(item);
        }

        public Response<SubTopicDto> Update()
        {
            return new DAL.SubTopic().Update(this);
        }

        public static Response<SubTopicDto> Delete(long id, bool cascade = false)
        {
            return new DAL.SubTopic().Delete(id, cascade);
        }
    }
}