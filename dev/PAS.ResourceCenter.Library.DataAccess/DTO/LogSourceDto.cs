using System;
using System.Linq.Expressions;
using PAS.ResourceCenter.Library.DataAccess.Interfaces;
using PAS.ResourceCenter.Library.DataAccess.Models;
using PAS.ResourceCenter.Library.DataAccess.Responses;
using System.Collections.Generic;

// This file is generated. DO NOT MODIFY
namespace PAS.ResourceCenter.Library.DataAccess.DTO
{
    public partial class LogSourceDto : ILogSource
    {
        public LogSourceDto(string byUserId = "")
        {
			Id = 0;
			Name = "";

        }

        public LogSourceDto(ILogSource item, bool includeNavigation = false)
        {
            if (item != null)
                Assign(item, includeNavigation);
        }

		public Int64 Id{ get; set; }
		public String Name{ get; set; }

		public ICollection<Log> Log { get; set; }


        internal void Assign(ILogSource item, bool includeNavigation = false)
        {
            if (item == null)
                throw new ArgumentNullException(nameof(item));

            LogSource.Assign(item, this, includeNavigation);
        }

        public static Response<LogSourceDto> Create(LogSourceDto item)
        {
            if (item == null)
            {
                return new Response<LogSourceDto>(StatusCodes.EXCEPTION);
            }

            return new DAL.LogSource().Create(item);
        }

        public static Response<LogSourceDto> Get(long id, bool includeNavigation = false)
        {
            return new DAL.LogSource().Get(id, includeNavigation);
        }

        public static Response<LogSourceDto> Select(Expression<Func<ILogSource, bool>> whereClause = null, bool includeNavigation = false)
        {
            return new DAL.LogSource().Select(whereClause, includeNavigation);
        }

        public static Response<LogSourceDto> Update(LogSourceDto item)
        {
            if (item == null)
            {
                return new Response<LogSourceDto>(StatusCodes.EXCEPTION);
            }

            return new DAL.LogSource().Update(item);
        }

        public Response<LogSourceDto> Update()
        {
            return new DAL.LogSource().Update(this);
        }

        public static Response<LogSourceDto> Delete(long id, bool cascade = false)
        {
            return new DAL.LogSource().Delete(id, cascade);
        }
    }
}