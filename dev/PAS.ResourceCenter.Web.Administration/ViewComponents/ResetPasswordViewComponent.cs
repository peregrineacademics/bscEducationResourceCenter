using Microsoft.AspNetCore.Mvc;
using PAS.ResourceCenter.Library.DataAccess.DTO;
using PAS.ResourceCenter.Web.Administration.ViewModels.ReviewProperties;
using PAS.ResourceCenter.Web.Administration.ViewModels.Users;

namespace PAS.ResourceCenter.Web.Administration.ViewComponents
{
    public class ResetPasswordViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke(string Id)
        {
            if (!string.IsNullOrEmpty(Id))
            {
                var result = UsersDto.Get(Id);
                if (result.Status == Library.DataAccess.Responses.StatusCodes.OK)
                {
                    if (result.Items.Count > 0)
                    {
                        var item = result.First();

                        UserViewModel model = new UserViewModel();
                        model.Id = item.Id;
                        model.LastName = item.LastName;
                        model.FirstName = item.FirstName;
                        model.MiddleName = item.MiddleName;
                        model.Email = item.Email;
                        model.RoleName = string.Empty;

                        return View(model);
                    }
                }
            }

            return View(string.Empty);
        }
    }
}
