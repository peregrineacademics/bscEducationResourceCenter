using System;
using System.Linq.Expressions;
using PAS.ResourceCenter.Library.DataAccess.Interfaces;
using PAS.ResourceCenter.Library.DataAccess.Models;
using PAS.ResourceCenter.Library.DataAccess.Responses;
using System.Collections.Generic;

// This file is generated. DO NOT MODIFY
namespace PAS.ResourceCenter.Library.DataAccess.DTO
{
    public partial class SubRegionDto : ISubRegion
    {
        public SubRegionDto(string byUserId = "")
        {
			Id = 0;
			Name = "";
			RegionId = 0;

        }

        public SubRegionDto(ISubRegion item, bool includeNavigation = false)
        {
            if (item != null)
                Assign(item, includeNavigation);
        }

		public Int64 Id{ get; set; }
		public Boolean IsEnabled{ get; set; }
		public String Name{ get; set; }
		public Int64 RegionId{ get; set; }

		public Models.Region Region { get; set; }
		public ICollection<ReviewSubRegion> ReviewSubRegion { get; set; }


        internal void Assign(ISubRegion item, bool includeNavigation = false)
        {
            if (item == null)
                throw new ArgumentNullException(nameof(item));

            SubRegion.Assign(item, this, includeNavigation);
        }

        public static Response<SubRegionDto> Create(SubRegionDto item)
        {
            if (item == null)
            {
                return new Response<SubRegionDto>(StatusCodes.EXCEPTION);
            }

            return new DAL.SubRegion().Create(item);
        }

        public static Response<SubRegionDto> Get(long id, bool includeNavigation = false)
        {
            return new DAL.SubRegion().Get(id, includeNavigation);
        }

        public static Response<SubRegionDto> Select(Expression<Func<ISubRegion, bool>> whereClause = null, bool includeNavigation = false)
        {
            return new DAL.SubRegion().Select(whereClause, includeNavigation);
        }

        public static Response<SubRegionDto> Update(SubRegionDto item)
        {
            if (item == null)
            {
                return new Response<SubRegionDto>(StatusCodes.EXCEPTION);
            }

            return new DAL.SubRegion().Update(item);
        }

        public Response<SubRegionDto> Update()
        {
            return new DAL.SubRegion().Update(this);
        }

        public static Response<SubRegionDto> Delete(long id, bool cascade = false)
        {
            return new DAL.SubRegion().Delete(id, cascade);
        }
    }
}