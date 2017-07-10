using Microsoft.AspNetCore.Mvc;
using PAS.ResourceCenter.Web.Administration.ViewModels.Home;

namespace PAS.ResourceCenter.Web.Administration.ViewComponents
{
    public class ChangePasswordViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            ChangePasswordViewModel model = new ChangePasswordViewModel();
            model.OldPassword = string.Empty;
            model.NewPassword = string.Empty;
            model.ConfirmPassword = string.Empty;

            return View(model);
        }
    }
}
