using PAS.ResourceCenter.Library.DataAccess.Interfaces;
using PAS.ResourceCenter.Library.DataAccess.Responses;
using System;

namespace PAS.ResourceCenter.Library.DataAccess.DTO
{
    public partial class LogDto : ILog
    {
        public static Response<LogDto> Create(
            long logSourceId,
            long logTypeId,
            long linkId,
            string linkUserId,
            string message,
            string createdByUserId,
            Models.ercContext context = null)
        {
            var log = new LogDto
            {
                CreatedByUserId = createdByUserId,
                DateCreated = DateTime.Now,
                LinkId = linkId,
                LinkUserId = linkUserId,
                LogSourceId = logSourceId,
                LogTypeId = logTypeId,
                Message = message
            };

            return new DAL.Log().Create(log);
        }
    }
}
