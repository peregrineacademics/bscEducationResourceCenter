using PAS.ResourceCenter.Library.DataAccess.Responses;

namespace PAS.ResourceCenter.Library.DataAccess.DTO
{
    public partial class UsersDto
    {
        public static Response<UsersDto> DeleteWithoutLogs(string Id)
        {
            return DAL.Custom.Users.DeleteWithoutLogs(Id);
        }
    }
}
