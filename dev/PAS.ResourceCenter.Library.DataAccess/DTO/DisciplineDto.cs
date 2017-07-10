using System;
using System.Linq.Expressions;
using PAS.ResourceCenter.Library.DataAccess.Interfaces;
using PAS.ResourceCenter.Library.DataAccess.Models;
using PAS.ResourceCenter.Library.DataAccess.Responses;
using System.Collections.Generic;

// This file is generated. DO NOT MODIFY
namespace PAS.ResourceCenter.Library.DataAccess.DTO
{
    public partial class DisciplineDto : IDiscipline
    {
        public DisciplineDto(string byUserId = "")
        {
			Id = 0;
			Name = "";

        }

        public DisciplineDto(IDiscipline item, bool includeNavigation = false)
        {
            if (item != null)
                Assign(item, includeNavigation);
        }

		public Int64 Id{ get; set; }
		public Boolean IsEnabled{ get; set; }
		public String Name{ get; set; }

		public ICollection<ReviewDiscipline> ReviewDiscipline { get; set; }
		public ICollection<SubTopic> SubTopic { get; set; }


        internal void Assign(IDiscipline item, bool includeNavigation = false)
        {
            if (item == null)
                throw new ArgumentNullException(nameof(item));

            Discipline.Assign(item, this, includeNavigation);
        }

        public static Response<DisciplineDto> Create(DisciplineDto item)
        {
            if (item == null)
            {
                return new Response<DisciplineDto>(StatusCodes.EXCEPTION);
            }

            return new DAL.Discipline().Create(item);
        }

        public static Response<DisciplineDto> Get(long id, bool includeNavigation = false)
        {
            return new DAL.Discipline().Get(id, includeNavigation);
        }

        public static Response<DisciplineDto> Select(Expression<Func<IDiscipline, bool>> whereClause = null, bool includeNavigation = false)
        {
            return new DAL.Discipline().Select(whereClause, includeNavigation);
        }

        public static Response<DisciplineDto> Update(DisciplineDto item)
        {
            if (item == null)
            {
                return new Response<DisciplineDto>(StatusCodes.EXCEPTION);
            }

            return new DAL.Discipline().Update(item);
        }

        public Response<DisciplineDto> Update()
        {
            return new DAL.Discipline().Update(this);
        }

        public static Response<DisciplineDto> Delete(long id, bool cascade = false)
        {
            return new DAL.Discipline().Delete(id, cascade);
        }
    }
}