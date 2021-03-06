﻿using Microsoft.AspNetCore.Mvc;
using PAS.ResourceCenter.Library.DataAccess.DTO;
using PAS.ResourceCenter.Web.Administration.ViewModels.ReviewProperties;

namespace PAS.ResourceCenter.Web.Administration.ViewComponents
{
    public class EditSectorViewComponent : ViewComponent
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

                        SectorViewModel model = new SectorViewModel();
                        model.Id = item.Id;
                        model.Name = item.Name.Trim();
                        model.Enabled = item.IsEnabled;
                        model.DivEditId = "divmodaleditsector" + item.Id.ToString();
                        model.DivPurgeId = "divmodalpurgesector" + item.Id.ToString();

                        return View(model);
                    }
                }
            }

            return View(string.Empty);
        }
    }
}
