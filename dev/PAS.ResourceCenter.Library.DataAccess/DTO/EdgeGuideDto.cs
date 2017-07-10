using System;
using System.Linq.Expressions;
using PAS.ResourceCenter.Library.DataAccess.Interfaces;
using PAS.ResourceCenter.Library.DataAccess.Models;
using PAS.ResourceCenter.Library.DataAccess.Responses;
using System.Collections.Generic;

// This file is generated. DO NOT MODIFY
namespace PAS.ResourceCenter.Library.DataAccess.DTO
{
    public partial class EdgeGuideDto : IEdgeGuide
    {
        public EdgeGuideDto(string byUserId = "")
        {
			Id = 0;
			Name = "";

        }

        public EdgeGuideDto(IEdgeGuide item, bool includeNavigation = false)
        {
            if (item != null)
                Assign(item, includeNavigation);
        }

		public Int64 Id{ get; set; }
		public String Name{ get; set; }

		public ICollection<ReviewEdgeGuide> ReviewEdgeGuide { get; set; }


        internal void Assign(IEdgeGuide item, bool includeNavigation = false)
        {
            if (item == null)
                throw new ArgumentNullException(nameof(item));

            EdgeGuide.Assign(item, this, includeNavigation);
        }

        public static Response<EdgeGuideDto> Create(EdgeGuideDto item)
        {
            if (item == null)
            {
                return new Response<EdgeGuideDto>(StatusCodes.EXCEPTION);
            }

            return new DAL.EdgeGuide().Create(item);
        }

        public static Response<EdgeGuideDto> Get(long id, bool includeNavigation = false)
        {
            return new DAL.EdgeGuide().Get(id, includeNavigation);
        }

        public static Response<EdgeGuideDto> Select(Expression<Func<IEdgeGuide, bool>> whereClause = null, bool includeNavigation = false)
        {
            return new DAL.EdgeGuide().Select(whereClause, includeNavigation);
        }

        public static Response<EdgeGuideDto> Update(EdgeGuideDto item)
        {
            if (item == null)
            {
                return new Response<EdgeGuideDto>(StatusCodes.EXCEPTION);
            }

            return new DAL.EdgeGuide().Update(item);
        }

        public Response<EdgeGuideDto> Update()
        {
            return new DAL.EdgeGuide().Update(this);
        }

        public static Response<EdgeGuideDto> Delete(long id, bool cascade = false)
        {
            return new DAL.EdgeGuide().Delete(id, cascade);
        }
    }
}