using Microsoft.AspNetCore.Mvc;
using PAS.ResourceCenter.Library.DataAccess.DTO;
using PAS.ResourceCenter.Web.Administration.ViewModels.ReviewProperties;

namespace PAS.ResourceCenter.Web.Administration.ViewComponents
{
    public class PurgeCompetencyViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke(long? Id)
        {
            if (Id.HasValue)
            {
                var result = CategoryDto.Get(Id.Value);
                if (result.Status == Library.DataAccess.Responses.StatusCodes.OK)
                {
                    if (result.Items.Count > 0)
                    {
                        var item = result.First();

                        CompetencyViewModel model = new CompetencyViewModel();
                        model.Id = item.Id;
                        model.Name = item.Name;
                        model.Enabled = item.IsEnabled;
                        model.DivEditId = "divmodaleditcompetency" + item.Id.ToString();
                        model.DivPurgeId = "divmodalpurgecompetency" + item.Id.ToString();

                        return View(model);
                    }
                }
            }

            return View(string.Empty);
        }
    }
}
