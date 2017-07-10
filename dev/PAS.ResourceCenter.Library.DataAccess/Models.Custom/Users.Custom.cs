using Microsoft.EntityFrameworkCore;
using PAS.ResourceCenter.Library.DataAccess.DTO;
using System.Linq;

namespace PAS.ResourceCenter.Library.DataAccess.Models.Custom
{
    public class Users
    {
        internal static UsersDto DeleteWithoutLogs(string id)
        {
            var context = Transaction.GetContext();

            var dbItem = context.Users
                                .Include(n => n.UserClaims)
                                .Include(n => n.UserLogins)
                                .Include(n => n.UserRoles).FirstOrDefault(p => p.Id == id);
            if (dbItem != null)
            {
                if (dbItem.UserClaims.Count > 0)
                    context.UserClaims.RemoveRange(dbItem.UserClaims);
                if (dbItem.UserLogins.Count > 0)
                    context.UserLogins.RemoveRange(dbItem.UserLogins);
                if (dbItem.UserRoles.Count > 0)
                    context.UserRoles.RemoveRange(dbItem.UserRoles);

                context.Users.Remove(dbItem);
                context.SaveChanges();
            }

            Transaction.DisposeContext(context);

            return null;
        }
    }
}
