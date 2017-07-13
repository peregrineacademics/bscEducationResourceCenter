using Microsoft.AspNetCore.Mvc;
using PAS.ResourceCenter.Library.DataAccess.DTO;
using PAS.ResourceCenter.Web.Administration.ViewModels.Reviewers;

namespace PAS.ResourceCenter.Web.Administration.ViewComponents
{
    public class ResetReviewerPasswordViewComponent : ViewComponent
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

                        ReviewerViewModel model = new ReviewerViewModel();
                        model.Id = item.Id;
                        model.ScreenName = string.Empty;
                        model.LastName = item.LastName;
                        model.FirstName = item.FirstName;
                        model.MiddleName = item.MiddleName;
                        model.Email = item.Email;

                        return View(model);
                    }
                }
            }

            return View(string.Empty);
        }
    }
}
