using System;
using System.Linq.Expressions;
using PAS.ResourceCenter.Library.DataAccess.Interfaces;
using PAS.ResourceCenter.Library.DataAccess.Models;
using PAS.ResourceCenter.Library.DataAccess.Responses;
using System.Collections.Generic;

// This file is generated. DO NOT MODIFY
namespace PAS.ResourceCenter.Library.DataAccess.DTO
{
    public partial class LogTypeDto : ILogType
    {
        public LogTypeDto(string byUserId = "")
        {
			Id = 0;
			Name = "";

        }

        public LogTypeDto(ILogType item, bool includeNavigation = false)
        {
            if (item != null)
                Assign(item, includeNavigation);
        }

		public Int64 Id{ get; set; }
		public String Name{ get; set; }

		public ICollection<Log> Log { get; set; }


        internal void Assign(ILogType item, bool includeNavigation = false)
        {
            if (item == null)
                throw new ArgumentNullException(nameof(item));

            LogType.Assign(item, this, includeNavigation);
        }

        public static Response<LogTypeDto> Create(LogTypeDto item)
        {
            if (item == null)
            {
                return new Response<LogTypeDto>(StatusCodes.EXCEPTION);
            }

            return new DAL.LogType().Create(item);
        }

        public static Response<LogTypeDto> Get(long id, bool includeNavigation = false)
        {
            return new DAL.LogType().Get(id, includeNavigation);
        }

        public static Response<LogTypeDto> Select(Expression<Func<ILogType, bool>> whereClause = null, bool includeNavigation = false)
        {
            return new DAL.LogType().Select(whereClause, includeNavigation);
        }

        public static Response<LogTypeDto> Update(LogTypeDto item)
        {
            if (item == null)
            {
                return new Response<LogTypeDto>(StatusCodes.EXCEPTION);
            }

            return new DAL.LogType().Update(item);
        }

        public Response<LogTypeDto> Update()
        {
            return new DAL.LogType().Update(this);
        }

        public static Response<LogTypeDto> Delete(long id, bool cascade = false)
        {
            return new DAL.LogType().Delete(id, cascade);
        }
    }
}