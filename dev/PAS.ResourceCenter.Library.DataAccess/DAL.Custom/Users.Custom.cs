using PAS.ResourceCenter.Library.DataAccess.DTO;
using PAS.ResourceCenter.Library.DataAccess.Responses;
using System;

namespace PAS.ResourceCenter.Library.DataAccess.DAL.Custom
{
    internal static class Users
    {
        internal static Response<UsersDto> DeleteWithoutLogs(string Id)
        {
            var result = new Response<UsersDto>();
            try
            {
                var dbResult = Models.Custom.Users.DeleteWithoutLogs(Id);
                if (dbResult != null)
                    result.Items.Add(dbResult);
            }

            catch (Exception ex)
            {
                result = new Response<UsersDto>(StatusCodes.EXCEPTION, ex)
                {
                    Message = $"Get failed for {typeof(UsersDto).Name}"
                };
            }
            return result;
        }
    }
}
