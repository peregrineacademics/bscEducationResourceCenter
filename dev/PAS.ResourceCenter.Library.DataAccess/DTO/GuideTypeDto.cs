using System;
using System.Linq.Expressions;
using PAS.ResourceCenter.Library.DataAccess.Interfaces;
using PAS.ResourceCenter.Library.DataAccess.Models;
using PAS.ResourceCenter.Library.DataAccess.Responses;
using System.Collections.Generic;

// This file is generated. DO NOT MODIFY
namespace PAS.ResourceCenter.Library.DataAccess.DTO
{
    public partial class GuideTypeDto : IGuideType
    {
        public GuideTypeDto(string byUserId = "")
        {
			Id = 0;
			Name = "";

        }

        public GuideTypeDto(IGuideType item, bool includeNavigation = false)
        {
            if (item != null)
                Assign(item, includeNavigation);
        }

		public Int64 Id{ get; set; }
		public String Name{ get; set; }

		public ICollection<Review> Review { get; set; }


        internal void Assign(IGuideType item, bool includeNavigation = false)
        {
            if (item == null)
                throw new ArgumentNullException(nameof(item));

            GuideType.Assign(item, this, includeNavigation);
        }

        public static Response<GuideTypeDto> Create(GuideTypeDto item)
        {
            if (item == null)
            {
                return new Response<GuideTypeDto>(StatusCodes.EXCEPTION);
            }

            return new DAL.GuideType().Create(item);
        }

        public static Response<GuideTypeDto> Get(long id, bool includeNavigation = false)
        {
            return new DAL.GuideType().Get(id, includeNavigation);
        }

        public static Response<GuideTypeDto> Select(Expression<Func<IGuideType, bool>> whereClause = null, bool includeNavigation = false)
        {
            return new DAL.GuideType().Select(whereClause, includeNavigation);
        }

        public static Response<GuideTypeDto> Update(GuideTypeDto item)
        {
            if (item == null)
            {
                return new Response<GuideTypeDto>(StatusCodes.EXCEPTION);
            }

            return new DAL.GuideType().Update(item);
        }

        public Response<GuideTypeDto> Update()
        {
            return new DAL.GuideType().Update(this);
        }

        public static Response<GuideTypeDto> Delete(long id, bool cascade = false)
        {
            return new DAL.GuideType().Delete(id, cascade);
        }
    }
}