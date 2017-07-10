using System;
using System.Linq.Expressions;
using PAS.ResourceCenter.Library.DataAccess.Interfaces;
using PAS.ResourceCenter.Library.DataAccess.Models;
using PAS.ResourceCenter.Library.DataAccess.Responses;
using System.Collections.Generic;

// This file is generated. DO NOT MODIFY
namespace PAS.ResourceCenter.Library.DataAccess.DTO
{
    public partial class CompetencyDto : ICompetency
    {
        public CompetencyDto(string byUserId = "")
        {
			Id = 0;
			Name = "";

        }

        public CompetencyDto(ICompetency item, bool includeNavigation = false)
        {
            if (item != null)
                Assign(item, includeNavigation);
        }

		public Int64 Id{ get; set; }
		public Boolean IsEnabled{ get; set; }
		public String Name{ get; set; }

		public ICollection<ReviewCompetency> ReviewCompetency { get; set; }


        internal void Assign(ICompetency item, bool includeNavigation = false)
        {
            if (item == null)
                throw new ArgumentNullException(nameof(item));

            Competency.Assign(item, this, includeNavigation);
        }

        public static Response<CompetencyDto> Create(CompetencyDto item)
        {
            if (item == null)
            {
                return new Response<CompetencyDto>(StatusCodes.EXCEPTION);
            }

            return new DAL.Competency().Create(item);
        }

        public static Response<CompetencyDto> Get(long id, bool includeNavigation = false)
        {
            return new DAL.Competency().Get(id, includeNavigation);
        }

        public static Response<CompetencyDto> Select(Expression<Func<ICompetency, bool>> whereClause = null, bool includeNavigation = false)
        {
            return new DAL.Competency().Select(whereClause, includeNavigation);
        }

        public static Response<CompetencyDto> Update(CompetencyDto item)
        {
            if (item == null)
            {
                return new Response<CompetencyDto>(StatusCodes.EXCEPTION);
            }

            return new DAL.Competency().Update(item);
        }

        public Response<CompetencyDto> Update()
        {
            return new DAL.Competency().Update(this);
        }

        public static Response<CompetencyDto> Delete(long id, bool cascade = false)
        {
            return new DAL.Competency().Delete(id, cascade);
        }
    }
}