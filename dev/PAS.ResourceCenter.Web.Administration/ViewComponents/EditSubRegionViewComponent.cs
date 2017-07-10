using Microsoft.AspNetCore.Mvc;
using PAS.ResourceCenter.Library.DataAccess.DTO;
using PAS.ResourceCenter.Web.Administration.ViewModels.ReviewProperties;

namespace PAS.ResourceCenter.Web.Administration.ViewComponents
{
    public class EditSubRegionViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke(long? subRegionId)
        {
            if (subRegionId.HasValue)
            {
                var result = SubRegionDto.Get(subRegionId.Value);
                if (result.Status == Library.DataAccess.Responses.StatusCodes.OK)
                {
                    if (result.Items.Count > 0)
                    {
                        var item = result.First();

                        SubRegionViewModel model = new SubRegionViewModel();
                        model.SubRegionId = item.Id;
                        model.RegionId = item.RegionId;
                        model.Name = item.Name;
                        model.Enabled = item.IsEnabled;
                        model.DivEditId = "divmodaleditsubregion" + item.Id.ToString();
                        model.DivPurgeId = "divmodalpurgesubregion" + item.Id.ToString();

                        return View(model);
                    }
                }
            }

            return View(string.Empty);
        }
    }
}
