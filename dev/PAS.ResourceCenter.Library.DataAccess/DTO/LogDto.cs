using System;
using System.Linq.Expressions;
using PAS.ResourceCenter.Library.DataAccess.Interfaces;
using PAS.ResourceCenter.Library.DataAccess.Models;
using PAS.ResourceCenter.Library.DataAccess.Responses;
using System.Collections.Generic;

// This file is generated. DO NOT MODIFY
namespace PAS.ResourceCenter.Library.DataAccess.DTO
{
    public partial class LogDto : ILog
    {
        public LogDto(string byUserId = "")
        {
			CreatedByUserId = byUserId;
			DateCreated = DateTime.Now;
			Id = 0;
			LinkId = 0;
			LinkUserId = "";
			LogSourceId = 0;
			LogTypeId = 0;
			Message = "";

        }

        public LogDto(ILog item, bool includeNavigation = false)
        {
            if (item != null)
                Assign(item, includeNavigation);
        }

		public String CreatedByUserId{ get; set; }
		public DateTime DateCreated{ get; set; }
		public Int64 Id{ get; set; }
		public Int64 LinkId{ get; set; }
		public String LinkUserId{ get; set; }
		public Int64 LogSourceId{ get; set; }
		public Int64 LogTypeId{ get; set; }
		public String Message{ get; set; }

		public Models.Users CreatedByUser { get; set; }
		public Models.LogSource LogSource { get; set; }
		public Models.LogType LogType { get; set; }


        internal void Assign(ILog item, bool includeNavigation = false)
        {
            if (item == null)
                throw new ArgumentNullException(nameof(item));

            Log.Assign(item, this, includeNavigation);
        }

        public static Response<LogDto> Create(LogDto item)
        {
            if (item == null)
            {
                return new Response<LogDto>(StatusCodes.EXCEPTION);
            }

            return new DAL.Log().Create(item);
        }

        public static Response<LogDto> Get(long id, bool includeNavigation = false)
        {
            return new DAL.Log().Get(id, includeNavigation);
        }

        public static Response<LogDto> Select(Expression<Func<ILog, bool>> whereClause = null, bool includeNavigation = false)
        {
            return new DAL.Log().Select(whereClause, includeNavigation);
        }

        public static Response<LogDto> Update(LogDto item)
        {
            if (item == null)
            {
                return new Response<LogDto>(StatusCodes.EXCEPTION);
            }

            return new DAL.Log().Update(item);
        }

        public Response<LogDto> Update()
        {
            return new DAL.Log().Update(this);
        }

        public static Response<LogDto> Delete(long id, bool cascade = false)
        {
            return new DAL.Log().Delete(id, cascade);
        }
    }
}