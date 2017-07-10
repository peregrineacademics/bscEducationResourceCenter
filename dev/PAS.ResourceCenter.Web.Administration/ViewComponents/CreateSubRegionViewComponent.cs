using Microsoft.AspNetCore.Mvc;
using PAS.ResourceCenter.Web.Administration.ViewModels.ReviewProperties;

namespace PAS.ResourceCenter.Web.Administration.ViewComponents
{
    public class CreateSubRegionViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke(long? regionId)
        {
            if (regionId.HasValue)
            {
                SubRegionViewModel model = new SubRegionViewModel();
                model.SubRegionId = 0;
                model.RegionId = regionId.Value;
                model.Name = string.Empty;
                model.Enabled = true;
                model.DivEditId = string.Empty;
                model.DivPurgeId = string.Empty;

                return View(model);
            }
            else
            {
                return View(string.Empty);
            }
        }        
    }
}
