using Microsoft.AspNetCore.Mvc;
using PAS.ResourceCenter.Library.DataAccess.DTO;
using PAS.ResourceCenter.Web.Administration.ViewModels.Admin;

namespace PAS.ResourceCenter.Web.Administration.ViewComponents
{
    public class EditSettingViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke(long? Id)
        {
            if (Id.HasValue)
            {
                var result = SiteSettingDto.Get(Id.Value);
                if (result.Status == Library.DataAccess.Responses.StatusCodes.OK)
                {
                    if (result.Items.Count > 0)
                    {
                        var setting = result.First();

                        SettingViewModel model = new SettingViewModel();
                        model.Id = setting.Id;
                        model.Name = setting.Name.Trim();

                        model.Value1 = string.Empty;
                        model.Value2 = string.Empty;
                        model.Value3 = string.Empty;
                        model.Value4 = string.Empty;
                        model.Value5 = string.Empty;
                        model.Value6 = string.Empty;
                        model.Value7 = string.Empty;
                        model.Value8 = string.Empty;

                        if (setting.IsCollection)
                        {
                            if (!string.IsNullOrEmpty(setting.Value))
                            {
                                string[] values = setting.Value.Split('|');

                                int ctr = 0;

                                foreach (var collectionValue in values)
                                {
                                    if (ctr == 0)
                                    {
                                        model.Value1 = collectionValue;
                                    }
                                    else if (ctr == 1)
                                    {
                                        model.Value2 = collectionValue;
                                    }
                                    else if (ctr == 2)
                                    {
                                        model.Value3 = collectionValue;
                                    }
                                    else if (ctr == 3)
                                    {
                                        model.Value4 = collectionValue;
                                    }
                                    else if (ctr == 4)
                                    {
                                        model.Value5 = collectionValue;
                                    }
                                    else if (ctr == 5)
                                    {
                                        model.Value6 = collectionValue;
                                    }
                                    else if (ctr == 6)
                                    {
                                        model.Value7 = collectionValue;
                                    }
                                    else if (ctr == 7)
                                    {
                                        model.Value8 = collectionValue;
                                    }

                                    ctr++;
                                }
                            }
                        }
                        else if (setting.IsPassword)
                        {
                            model.Value1 = setting.Value;
                        }
                        else if (setting.IsBoolean)
                        {
                            model.Value1 = setting.Value;
                        }
                        else
                        {
                            model.Value1 = setting.Value;
                        }

                        model.DisplayName = setting.DisplayName;
                        model.Notes = setting.Notes.Trim();
                        model.Password = setting.IsPassword;
                        model.Boolean = setting.IsBoolean;
                        model.Collection = setting.IsCollection;
                        model.DivEditId = "divmodaleditsetting" + setting.Id.ToString();

                        return View(model);
                    }
                }
            }

            return View(string.Empty);
        }
    }
}
