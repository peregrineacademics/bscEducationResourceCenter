﻿using Microsoft.AspNetCore.Mvc;
using PAS.ResourceCenter.Web.Administration.ViewModels.ReviewProperties;

namespace PAS.ResourceCenter.Web.Administration.ViewComponents
{
    public class CreateSectorViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            SectorViewModel model = new SectorViewModel();
            model.Id = 0;
            model.Name = string.Empty;
            model.Enabled = true;
            model.DivEditId = string.Empty;
            model.DivPurgeId = string.Empty;

            return View(model);
        }        
    }
}
