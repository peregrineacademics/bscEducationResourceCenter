using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PAS.ResourceCenter.Library.DataAccess.DTO;
using PAS.ResourceCenter.Web.Administration.ViewModels.Home;

namespace PAS.ResourceCenter.Web.Administration.ViewComponents
{
    public class MyProfileViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            if (HttpContext.Session.GetString(Constants._valueUserFirstName) != null &&
                HttpContext.Session.GetString(Constants._valueUserLastName) != null &&
                HttpContext.Session.GetString(Constants._valueUserMiddleName) != null &&
                HttpContext.Session.GetString(Constants._valueUserEmail) != null)
            {
                MyProfileViewModel model = new MyProfileViewModel();
                model.ProfileFirstName = HttpContext.Session.GetString(Constants._valueUserFirstName).ToString();
                model.ProfileLastName = HttpContext.Session.GetString(Constants._valueUserLastName).ToString();
                model.ProfileMiddleName = HttpContext.Session.GetString(Constants._valueUserMiddleName).ToString();
                model.ProfileEmail = HttpContext.Session.GetString(Constants._valueUserEmail).ToString();

                HttpContext.Session.SetString(Constants._valueUserFirstName, model.ProfileFirstName);
                HttpContext.Session.SetString(Constants._valueUserLastName, model.ProfileLastName);
                HttpContext.Session.SetString(Constants._valueUserMiddleName, model.ProfileMiddleName);
                HttpContext.Session.SetString(Constants._valueUserEmail, model.ProfileEmail);

                return View(model);
            }
            else
            {
                var result = UsersDto.Select(x => x.UserName.Equals(User.Identity.Name));
                if (result.Status == Library.DataAccess.Responses.StatusCodes.OK)
                {
                    if (result.Items.Count > 0)
                    {
                        MyProfileViewModel model = new MyProfileViewModel();
                        model.ProfileFirstName = result.First().FirstName;
                        model.ProfileLastName = result.First().LastName;
                        model.ProfileMiddleName = result.First().MiddleName;
                        model.ProfileEmail = result.First().Email;

                        HttpContext.Session.SetString(Constants._valueUserFirstName, model.ProfileFirstName);
                        HttpContext.Session.SetString(Constants._valueUserLastName, model.ProfileLastName);
                        HttpContext.Session.SetString(Constants._valueUserMiddleName, model.ProfileMiddleName);
                        HttpContext.Session.SetString(Constants._valueUserEmail, model.ProfileEmail);

                        return View(model);
                    }
                }
            }

            return View(string.Empty);
        }
    }
}
