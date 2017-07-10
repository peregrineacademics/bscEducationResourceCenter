using System;
using System.Linq.Expressions;
using PAS.ResourceCenter.Library.DataAccess.Interfaces;
using PAS.ResourceCenter.Library.DataAccess.Models;
using PAS.ResourceCenter.Library.DataAccess.Responses;
using System.Collections.Generic;

// This file is generated. DO NOT MODIFY
namespace PAS.ResourceCenter.Library.DataAccess.DTO
{
    public partial class SectorDto : ISector
    {
        public SectorDto(string byUserId = "")
        {
			Id = 0;
			Name = "";

        }

        public SectorDto(ISector item, bool includeNavigation = false)
        {
            if (item != null)
                Assign(item, includeNavigation);
        }

		public Int64 Id{ get; set; }
		public Boolean IsEnabled{ get; set; }
		public String Name{ get; set; }

		public ICollection<ReviewSector> ReviewSector { get; set; }


        internal void Assign(ISector item, bool includeNavigation = false)
        {
            if (item == null)
                throw new ArgumentNullException(nameof(item));

            Sector.Assign(item, this, includeNavigation);
        }

        public static Response<SectorDto> Create(SectorDto item)
        {
            if (item == null)
            {
                return new Response<SectorDto>(StatusCodes.EXCEPTION);
            }

            return new DAL.Sector().Create(item);
        }

        public static Response<SectorDto> Get(long id, bool includeNavigation = false)
        {
            return new DAL.Sector().Get(id, includeNavigation);
        }

        public static Response<SectorDto> Select(Expression<Func<ISector, bool>> whereClause = null, bool includeNavigation = false)
        {
            return new DAL.Sector().Select(whereClause, includeNavigation);
        }

        public static Response<SectorDto> Update(SectorDto item)
        {
            if (item == null)
            {
                return new Response<SectorDto>(StatusCodes.EXCEPTION);
            }

            return new DAL.Sector().Update(item);
        }

        public Response<SectorDto> Update()
        {
            return new DAL.Sector().Update(this);
        }

        public static Response<SectorDto> Delete(long id, bool cascade = false)
        {
            return new DAL.Sector().Delete(id, cascade);
        }
    }
}