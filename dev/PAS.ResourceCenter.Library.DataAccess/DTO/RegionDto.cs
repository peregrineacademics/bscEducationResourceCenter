using System;
using System.Linq.Expressions;
using PAS.ResourceCenter.Library.DataAccess.Interfaces;
using PAS.ResourceCenter.Library.DataAccess.Models;
using PAS.ResourceCenter.Library.DataAccess.Responses;
using System.Collections.Generic;

// This file is generated. DO NOT MODIFY
namespace PAS.ResourceCenter.Library.DataAccess.DTO
{
    public partial class RegionDto : IRegion
    {
        public RegionDto(string byUserId = "")
        {
			Id = 0;
			Name = "";

        }

        public RegionDto(IRegion item, bool includeNavigation = false)
        {
            if (item != null)
                Assign(item, includeNavigation);
        }

		public Int64 Id{ get; set; }
		public Boolean IsEnabled{ get; set; }
		public String Name{ get; set; }

		public ICollection<ReviewRegion> ReviewRegion { get; set; }
		public ICollection<SubRegion> SubRegion { get; set; }


        internal void Assign(IRegion item, bool includeNavigation = false)
        {
            if (item == null)
                throw new ArgumentNullException(nameof(item));

            Region.Assign(item, this, includeNavigation);
        }

        public static Response<RegionDto> Create(RegionDto item)
        {
            if (item == null)
            {
                return new Response<RegionDto>(StatusCodes.EXCEPTION);
            }

            return new DAL.Region().Create(item);
        }

        public static Response<RegionDto> Get(long id, bool includeNavigation = false)
        {
            return new DAL.Region().Get(id, includeNavigation);
        }

        public static Response<RegionDto> Select(Expression<Func<IRegion, bool>> whereClause = null, bool includeNavigation = false)
        {
            return new DAL.Region().Select(whereClause, includeNavigation);
        }

        public static Response<RegionDto> Update(RegionDto item)
        {
            if (item == null)
            {
                return new Response<RegionDto>(StatusCodes.EXCEPTION);
            }

            return new DAL.Region().Update(item);
        }

        public Response<RegionDto> Update()
        {
            return new DAL.Region().Update(this);
        }

        public static Response<RegionDto> Delete(long id, bool cascade = false)
        {
            return new DAL.Region().Delete(id, cascade);
        }
    }
}