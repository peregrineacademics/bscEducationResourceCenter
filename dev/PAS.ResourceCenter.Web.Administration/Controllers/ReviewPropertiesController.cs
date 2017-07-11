using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PAS.ResourceCenter.Library.Common.Definitions;
using PAS.ResourceCenter.Library.DataAccess.DTO;
using PAS.ResourceCenter.Library.DataAccess.Responses;
using PAS.ResourceCenter.Web.Administration.Models;
using PAS.ResourceCenter.Web.Administration.ViewModels.ReviewProperties;
using System.Collections.Generic;
using System.Linq;

namespace PAS.ResourceCenter.Web.Administration.Controllers
{
    [Authorize(Roles = "pasadministrator,editor")]
    public class ReviewPropertiesController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public ReviewPropertiesController(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        public ActionResult Index()
        {
            return RedirectToAction("Sectors", "ReviewProperties");
        }

        private ActionResult RedirectToLocal(string returnUrl = "")
        {
            if (!string.IsNullOrWhiteSpace(returnUrl) && Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }

            return RedirectToAction("Sectors", "ReviewProperties");
        }

        public ActionResult Disciplines()
        {
            var result = CategoryDto.Select(x => x.GroupId.Equals(Group.Disciplines) && x.ParentId.Equals(0));
            if (result.Status == StatusCodes.OK)
            {
                DisciplinesViewModel model = new DisciplinesViewModel();

                List<DisciplineViewModel> disciplineList = new List<DisciplineViewModel>();

                if (result.Items.Count > 0)
                {
                    foreach (var item in result.Items.OrderBy(x => x.Name))
                    {
                        DisciplineViewModel disciplineModel = new DisciplineViewModel();
                        disciplineModel.Id = item.Id;
                        disciplineModel.Name = item.Name;
                        disciplineModel.Enabled = item.IsEnabled;
                        disciplineModel.DivEditId = "divmodaleditdiscipline" + item.Id.ToString();
                        disciplineModel.DivPurgeId = "divmodalpurgediscipline" + item.Id.ToString();

                        string topicList = string.Empty;
                        var resultTopic = CategoryDto.Select(x => x.ParentId.Equals(item.Id) && x.GroupId.Equals(Group.Disciplines));
                        if (resultTopic.Status == StatusCodes.OK)
                        {
                            if (resultTopic.Items.Count > 0)
                            {
                                int ctr = 0;
                                foreach (var topic in resultTopic.Items.OrderBy(x => x.Name))
                                {
                                    if (ctr == 0)
                                        topicList += topic.Name;
                                    else
                                        topicList += " / " + topic.Name;

                                    ctr++;
                                }
                            }
                        }
                        disciplineModel.Topics = topicList;

                        disciplineList.Add(disciplineModel);
                    }
                }

                model.Disciplines = disciplineList;

                return View(model);
            }

            return RedirectToLocal();
        }

        [HttpPost]
        public ActionResult CreateDiscipline(DisciplineViewModel model)
        {
            if (ModelState.IsValid)
            {
                var result = CategoryDto.Select(x => x.Name.Equals(model.Name.Trim()) && x.GroupId.Equals(Group.Disciplines));
                if (result.Status == StatusCodes.OK)
                {
                    if (result.Items.Count > 0)
                    {
                        ModelState.AddModelError(string.Empty, "Discipline already exists.");

                        return PartialView(model);
                    }
                    else
                    {
                        CategoryDto item = new CategoryDto
                        {
                            Name = model.Name.Trim(),
                            GroupId = Group.Disciplines,
                            ParentId = 0,
                            IsEnabled = model.Enabled
                        };

                        var resultCreate = CategoryDto.Create(item);
                        if (resultCreate.Status == StatusCodes.OK)
                        {
                            string message =
                                "Discipline '" + model.Name + "' has been created by " + Common.DBUtilities.GetUsersFullName(User.Identity.Name) + ".";

                            LogDto.Create(
                                LogSource.WebsiteAdministration,
                                LogType.Administration,
                                0,
                                string.Empty,
                                message,
                                Common.DBUtilities.GetUserIdByUserName(User.Identity.Name));

                            return Json(new { url = Url.Action("Disciplines", "ReviewProperties") });
                        }
                        else
                        {
                            ModelState.AddModelError(string.Empty, "An error occured. Please try again.");

                            return PartialView(model);
                        }
                    }
                }
            }

            return PartialView(model);
        }

        [HttpPost]
        public ActionResult EditDiscipline(DisciplineViewModel model)
        {
            if (ModelState.IsValid)
            {
                var result = CategoryDto.Get(model.Id);
                if (result.Status == StatusCodes.OK)
                {
                    if (result.Items.Count > 0)
                    {
                        var item = result.First();

                        string oldName = item.Name;
                        item.Name = model.Name.Trim();
                        item.IsEnabled = model.Enabled;

                        if (item.Update().Status == StatusCodes.OK)
                        {
                            string message =
                                "Discipline '" + oldName + "' has been updated to '" + model.Name + "' by " + Common.DBUtilities.GetUsersFullName(User.Identity.Name) + ".";

                            LogDto.Create(
                                LogSource.WebsiteAdministration,
                                LogType.Administration,
                                0,
                                string.Empty,
                                message,
                                Common.DBUtilities.GetUserIdByUserName(User.Identity.Name));

                            return Json(new { url = Url.Action("Disciplines", "ReviewProperties") });
                        }
                    }
                }
            }

            return PartialView(model);
        }

        [HttpPost]
        public ActionResult PurgeDiscipline(DisciplineViewModel model)
        {
            try
            {
                var result = CategoryDto.Delete(model.Id);
                if (result.Status == StatusCodes.OK)
                {
                    string message = "Discipline '" + model.Name + "' has been purged.";

                    LogDto.Create(
                                LogSource.WebsiteAdministration,
                                LogType.Administration,
                                0,
                                string.Empty,
                                message,
                                Common.DBUtilities.GetUserIdByUserName(User.Identity.Name));

                    return Json(new { url = Url.Action("Disciplines", "ReviewProperties") });
                }
                else
                {
                    throw (result.Ex);
                }
            }
            catch
            {
                ModelState.AddModelError(string.Empty, "Cannot delete selected discipline. It is already in use.");
            }

            return PartialView(model);
        }

        public ActionResult Topics(long? Id)
        {
            if (Id.HasValue)
            {
                var result =
                   CategoryDto.Select(
                       x => (x.Id.Equals(Id.Value) || x.ParentId.Equals(Id.Value)) && x.GroupId.Equals(Group.Disciplines));
                if (result.Status == StatusCodes.OK)
                {
                    TopicsViewModel model = new TopicsViewModel();

                    if (result.Items.Count > 0)
                    {
                        model.DisciplineId = result.First().Id;
                        model.DisciplineName = result.First().Name;

                        List<TopicViewModel> topicList = new List<TopicViewModel>();
                        foreach (var item in result.Items.OrderBy(x => x.Name))
                        {
                            if (item.ParentId == 0)
                            {
                                model.DisciplineId = result.First().Id;
                                model.DisciplineName = result.First().Name;
                            }
                            else
                            {
                                TopicViewModel topicViewModel = new TopicViewModel();
                                topicViewModel.TopicId = item.Id;
                                topicViewModel.DisciplineId = Id.Value;
                                topicViewModel.Name = item.Name;
                                topicViewModel.Enabled = item.IsEnabled;
                                topicViewModel.DivEditId = "divmodaledittopic" + item.Id.ToString();
                                topicViewModel.DivPurgeId = "divmodalpurgetopic" + item.Id.ToString();

                                topicList.Add(topicViewModel);
                            }
                        }

                        model.Topics = topicList;
                    }

                    return View(model);
                }
            }

            return RedirectToAction("Disciplines", "ReviewProperties");;
        }

        [HttpPost]
        public ActionResult CreateTopic(TopicViewModel model)
        {
            if (ModelState.IsValid)
            {
                var result =
                   CategoryDto.Select(
                       x => x.Name.Equals(model.Name.Trim()) &&
                            x.ParentId.Equals(model.DisciplineId) &&
                            x.GroupId.Equals(Group.Disciplines));
                if (result.Status == StatusCodes.OK)
                {
                    if (result.Items.Count > 0)
                    {
                        ModelState.AddModelError(string.Empty, "Topic already exists.");

                        return PartialView(model);
                    }
                    else
                    {
                        CategoryDto item = new CategoryDto
                        {
                            Name = model.Name.Trim(),
                            GroupId = Group.Disciplines,
                            ParentId = model.DisciplineId,
                            IsEnabled = model.Enabled
                        };

                        var resultCreate = CategoryDto.Create(item);
                        if (resultCreate.Status == StatusCodes.OK)
                        {
                            string message =
                                "Topic '" + model.Name + "' has been created by " + Common.DBUtilities.GetUsersFullName(User.Identity.Name) + ".";

                            LogDto.Create(
                                LogSource.WebsiteAdministration,
                                LogType.Administration,
                                0,
                                string.Empty,
                                message,
                                Common.DBUtilities.GetUserIdByUserName(User.Identity.Name));

                            return Json(new { url = Url.Action("Topics", "ReviewProperties", new { Id = model.DisciplineId }) });
                        }
                        else
                        {
                            ModelState.AddModelError(string.Empty, "An error occured. Please try again.");

                            return PartialView(model);
                        }
                    }
                }
            }

            return PartialView(model);
        }

        [HttpPost]
        public ActionResult EditTopic(TopicViewModel model)
        {
            if (ModelState.IsValid)
            {
                var result = CategoryDto.Get(model.TopicId);
                if (result.Status == StatusCodes.OK)
                {
                    if (result.Items.Count > 0)
                    {
                        var item = result.First();

                        string oldName = item.Name;
                        item.Name = model.Name.Trim();
                        item.IsEnabled = model.Enabled;

                        if (item.Update().Status == StatusCodes.OK)
                        {
                            string message =
                                "Topic '" + oldName + "' has been updated to '" + model.Name + "' by " + Common.DBUtilities.GetUsersFullName(User.Identity.Name) + ".";

                            LogDto.Create(
                                LogSource.WebsiteAdministration,
                                LogType.Administration,
                                0,
                                string.Empty,
                                message,
                                Common.DBUtilities.GetUserIdByUserName(User.Identity.Name));

                            return Json(new { url = Url.Action("Topics", "ReviewProperties", new { Id = model.DisciplineId }) });
                        }
                    }
                }
            }

            return PartialView(model);
        }

        [HttpPost]
        public ActionResult PurgeTopic(TopicViewModel model)
        {
            try
            {
                var result = CategoryDto.Delete(model.TopicId);
                if (result.Status == StatusCodes.OK)
                {
                    string message = "Topic '" + model.Name + "' has been purged.";

                    LogDto.Create(
                        LogSource.WebsiteAdministration,
                        LogType.Administration,
                        0,
                        string.Empty,
                        message,
                        Common.DBUtilities.GetUserIdByUserName(User.Identity.Name));

                    return Json(new { url = Url.Action("Topics", "ReviewProperties", new { Id = model.DisciplineId }) });
                }
                else
                {
                    throw (result.Ex);
                }
            }
            catch
            {
                ModelState.AddModelError(string.Empty, "Cannot delete selected topic. It is already in use.");
            }

            return PartialView(model);
        }

        public ActionResult Sectors()
        {
            var result = CategoryDto.Select(x => x.GroupId.Equals(Group.Sectors));
            if (result.Status == StatusCodes.OK)
            {
                SectorsViewModel model = new SectorsViewModel();

                List<SectorViewModel> sectorList = new List<SectorViewModel>();

                if (result.Items.Count > 0)
                {
                    foreach (var item in result.Items.OrderBy(x => x.Name))
                    {
                        SectorViewModel sectorModel = new SectorViewModel();
                        sectorModel.Id = item.Id;
                        sectorModel.Name = item.Name;
                        sectorModel.Enabled = item.IsEnabled;
                        sectorModel.DivEditId = "divmodaleditsector" + item.Id.ToString();
                        sectorModel.DivPurgeId = "divmodalpurgesector" + item.Id.ToString();

                        sectorList.Add(sectorModel);
                    }
                }

                model.Sectors = sectorList;

                return View(model);
            }

            return RedirectToLocal();
        }

        [HttpPost]
        public ActionResult CreateSector(SectorViewModel model)
        {
            if (ModelState.IsValid)
            {
                var result = CategoryDto.Select(x => x.Name.Equals(model.Name.Trim()) && x.GroupId.Equals(Group.Sectors));
                if (result.Status == StatusCodes.OK)
                {
                    if (result.Items.Count > 0)
                    {
                        ModelState.AddModelError(string.Empty, "Sector already exists.");

                        return PartialView(model);
                    }
                    else
                    {
                        CategoryDto item = new CategoryDto
                        {
                            Name = model.Name.Trim(),
                            GroupId = Group.Sectors,
                            ParentId = 0,
                            IsEnabled = model.Enabled
                        };

                        var resultCreate = CategoryDto.Create(item);
                        if (resultCreate.Status == StatusCodes.OK)
                        {
                            string message =
                                "Sector '" + model.Name + "' has been created by " + Common.DBUtilities.GetUsersFullName(User.Identity.Name) + ".";

                            LogDto.Create(
                                LogSource.WebsiteAdministration,
                                LogType.Administration,
                                0,
                                string.Empty,
                                message,
                                Common.DBUtilities.GetUserIdByUserName(User.Identity.Name));

                            return Json(new { url = Url.Action("Sectors", "ReviewProperties") });
                        }
                        else
                        {
                            ModelState.AddModelError(string.Empty, "An error occured. Please try again.");

                            return PartialView(model);
                        }
                    }
                }
            }

            return PartialView(model);
        }

        [HttpPost]
        public ActionResult EditSector(SectorViewModel model)
        {
            if (ModelState.IsValid)
            {
                var result = CategoryDto.Get(model.Id);
                if (result.Status == StatusCodes.OK)
                {
                    if (result.Items.Count > 0)
                    {
                        var item = result.First();

                        string oldName = item.Name;
                        item.Name = model.Name.Trim();
                        item.IsEnabled = model.Enabled;

                        if (item.Update().Status == StatusCodes.OK)
                        {
                            string message =
                                "Sector '" + oldName + "' has been updated to '" + model.Name + "' by " + Common.DBUtilities.GetUsersFullName(User.Identity.Name) + ".";

                            LogDto.Create(
                                LogSource.WebsiteAdministration,
                                LogType.Administration,
                                0,
                                string.Empty,
                                message,
                                Common.DBUtilities.GetUserIdByUserName(User.Identity.Name));

                            return Json(new { url = Url.Action("Sectors", "ReviewProperties") });
                        }
                    }
                }
            }

            return PartialView(model);
        }

        [HttpPost]
        public ActionResult PurgeSector(SectorViewModel model)
        {
            try
            {
                var result = CategoryDto.Delete(model.Id);
                if (result.Status == StatusCodes.OK)
                {
                    string message = "Sector '" + model.Name + "' has been purged.";

                    LogDto.Create(
                                LogSource.WebsiteAdministration,
                                LogType.Administration,
                                0,
                                string.Empty,
                                message,
                                Common.DBUtilities.GetUserIdByUserName(User.Identity.Name));

                    return Json(new { url = Url.Action("Sectors", "ReviewProperties") });
                }
                else
                {
                    throw (result.Ex);
                }
            }
            catch
            {
                ModelState.AddModelError(string.Empty, "Cannot delete selected sector. It is already in use.");
            }

            return PartialView(model);
        }

        public ActionResult Competencies()
        {
            var result = CategoryDto.Select(x => x.GroupId.Equals(Group.Competencies));
            if (result.Status == StatusCodes.OK)
            {
                CompetenciesViewModel model = new CompetenciesViewModel();

                List<CompetencyViewModel> competencyList = new List<CompetencyViewModel>();

                if (result.Items.Count > 0)
                {
                    foreach (var item in result.Items.OrderBy(x => x.Name))
                    {
                        CompetencyViewModel competencyModel = new CompetencyViewModel();
                        competencyModel.Id = item.Id;
                        competencyModel.Name = item.Name;
                        competencyModel.Enabled = item.IsEnabled;
                        competencyModel.DivEditId = "divmodaleditcompetency" + item.Id.ToString();
                        competencyModel.DivPurgeId = "divmodalpurgecompetency" + item.Id.ToString();

                        competencyList.Add(competencyModel);
                    }
                }

                model.Competencies = competencyList;

                return View(model);
            }

            return RedirectToLocal();
        }

        [HttpPost]
        public ActionResult CreateCompetency(CompetencyViewModel model)
        {
            if (ModelState.IsValid)
            {
                var result = CategoryDto.Select(x => x.Name.Equals(model.Name.Trim()) && x.GroupId.Equals(Group.Competencies));
                if (result.Status == StatusCodes.OK)
                {
                    if (result.Items.Count > 0)
                    {
                        ModelState.AddModelError(string.Empty, "Competency already exists.");

                        return PartialView(model);
                    }
                    else
                    {
                        CategoryDto item = new CategoryDto
                        {
                            Name = model.Name.Trim(),
                            GroupId = Group.Competencies,
                            ParentId = 0,
                            IsEnabled = model.Enabled
                        };

                        var resultCreate = CategoryDto.Create(item);
                        if (resultCreate.Status == StatusCodes.OK)
                        {
                            string message =
                                "Competency '" + model.Name + "' has been created by " + Common.DBUtilities.GetUsersFullName(User.Identity.Name) + ".";

                            LogDto.Create(
                                LogSource.WebsiteAdministration,
                                LogType.Administration,
                                0,
                                string.Empty,
                                message,
                                Common.DBUtilities.GetUserIdByUserName(User.Identity.Name));

                            return Json(new { url = Url.Action("Competencies", "ReviewProperties") });
                        }
                        else
                        {
                            ModelState.AddModelError(string.Empty, "An error occured. Please try again.");

                            return PartialView(model);
                        }
                    }
                }
            }

            return PartialView(model);
        }

        [HttpPost]
        public ActionResult EditCompetency(CompetencyViewModel model)
        {
            if (ModelState.IsValid)
            {
                var result = CategoryDto.Get(model.Id);
                if (result.Status == StatusCodes.OK)
                {
                    if (result.Items.Count > 0)
                    {
                        var item = result.First();

                        string oldName = item.Name;
                        item.Name = model.Name.Trim();
                        item.IsEnabled = model.Enabled;

                        if (item.Update().Status == StatusCodes.OK)
                        {
                            string message =
                                "Competency '" + oldName + "' has been updated to '" + model.Name + "' by " + Common.DBUtilities.GetUsersFullName(User.Identity.Name) + ".";

                            LogDto.Create(
                                LogSource.WebsiteAdministration,
                                LogType.Administration,
                                0,
                                string.Empty,
                                message,
                                Common.DBUtilities.GetUserIdByUserName(User.Identity.Name));

                            return Json(new { url = Url.Action("Competencies", "ReviewProperties") });
                        }
                    }
                }
            }

            return PartialView(model);
        }

        [HttpPost]
        public ActionResult PurgeCompetency(CompetencyViewModel model)
        {
            try
            {
                var result = CategoryDto.Delete(model.Id);
                if (result.Status == StatusCodes.OK)
                {
                    string message = "Competency '" + model.Name + "' has been purged.";

                    LogDto.Create(
                                LogSource.WebsiteAdministration,
                                LogType.Administration,
                                0,
                                string.Empty,
                                message,
                                Common.DBUtilities.GetUserIdByUserName(User.Identity.Name));

                    return Json(new { url = Url.Action("Competencies", "ReviewProperties") });
                }
                else
                {
                    throw (result.Ex);
                }
            }
            catch
            {
                ModelState.AddModelError(string.Empty, "Cannot delete selected competency. It is already in use.");
            }

            return PartialView(model);
        }

        public ActionResult Regions()
        {
            var result = CategoryDto.Select(x => x.GroupId.Equals(Group.Regions) && x.ParentId.Equals(0));
            if (result.Status == StatusCodes.OK)
            {
                RegionsViewModel model = new RegionsViewModel();

                List<RegionViewModel> regionList = new List<RegionViewModel>();

                if (result.Items.Count > 0)
                {
                    foreach (var item in result.Items.OrderBy(x => x.Name))
                    {
                        RegionViewModel regionModel = new RegionViewModel();
                        regionModel.Id = item.Id;
                        regionModel.Name = item.Name;
                        regionModel.Enabled = item.IsEnabled;
                        regionModel.DivEditId = "divmodaleditregion" + item.Id.ToString();
                        regionModel.DivPurgeId = "divmodalpurgeregion" + item.Id.ToString();

                        string subRegionList = string.Empty;
                        var resultSubRegion = CategoryDto.Select(x => x.ParentId.Equals(item.Id) && x.GroupId.Equals(Group.Regions));
                        if (resultSubRegion.Status == StatusCodes.OK)
                        {
                            if (resultSubRegion.Items.Count > 0)
                            {
                                int ctr = 0;
                                foreach (var subRegion in resultSubRegion.Items.OrderBy(x => x.Name))
                                {
                                    if (ctr == 0)
                                        subRegionList += subRegion.Name;
                                    else
                                        subRegionList += " / " + subRegion.Name;

                                    ctr++;
                                }
                            }
                        }
                        regionModel.SubRegions = subRegionList;

                        regionList.Add(regionModel);
                    }
                }

                model.Regions = regionList;

                return View(model);
            }

            return RedirectToLocal();
        }

        [HttpPost]
        public ActionResult CreateRegion(RegionViewModel model)
        {
            if (ModelState.IsValid)
            {
                var result = CategoryDto.Select(x => x.Name.Equals(model.Name.Trim()) && x.GroupId.Equals(Group.Regions));
                if (result.Status == StatusCodes.OK)
                {
                    if (result.Items.Count > 0)
                    {
                        ModelState.AddModelError(string.Empty, "Region already exists.");

                        return PartialView(model);
                    }
                    else
                    {
                        CategoryDto item = new CategoryDto
                        {
                            Name = model.Name.Trim(),
                            GroupId = Group.Regions,
                            ParentId = 0,
                            IsEnabled = model.Enabled
                        };

                        var resultCreate = CategoryDto.Create(item);
                        if (resultCreate.Status == StatusCodes.OK)
                        {
                            string message =
                                "Region '" + model.Name + "' has been created by " + Common.DBUtilities.GetUsersFullName(User.Identity.Name) + ".";

                            LogDto.Create(
                                LogSource.WebsiteAdministration,
                                LogType.Administration,
                                0,
                                string.Empty,
                                message,
                                Common.DBUtilities.GetUserIdByUserName(User.Identity.Name));

                            return Json(new { url = Url.Action("Regions", "ReviewProperties") });
                        }
                        else
                        {
                            ModelState.AddModelError(string.Empty, "An error occured. Please try again.");

                            return PartialView(model);
                        }
                    }
                }
            }

            return PartialView(model);
        }

        [HttpPost]
        public ActionResult EditRegion(RegionViewModel model)
        {
            if (ModelState.IsValid)
            {
                var result = CategoryDto.Get(model.Id);
                if (result.Status == StatusCodes.OK)
                {
                    if (result.Items.Count > 0)
                    {
                        var item = result.First();

                        string oldName = item.Name;
                        item.Name = model.Name.Trim();
                        item.IsEnabled = model.Enabled;

                        if (item.Update().Status == StatusCodes.OK)
                        {
                            string message =
                                "Region '" + oldName + "' has been updated to '" + model.Name + "' by " + Common.DBUtilities.GetUsersFullName(User.Identity.Name) + ".";

                            LogDto.Create(
                                LogSource.WebsiteAdministration,
                                LogType.Administration,
                                0,
                                string.Empty,
                                message,
                                Common.DBUtilities.GetUserIdByUserName(User.Identity.Name));

                            return Json(new { url = Url.Action("Regions", "ReviewProperties") });
                        }
                    }
                }
            }

            return PartialView(model);
        }

        [HttpPost]
        public ActionResult PurgeRegion(RegionViewModel model)
        {
            try
            {
                var result = CategoryDto.Select(x => x.ParentId.Equals(model.Id));
                if (result.Status == StatusCodes.OK)
                {
                    if (result.Items.Count > 0)
                    {
                        ModelState.AddModelError(string.Empty, "Cannot delete selected region. It is already in use.");

                        return PartialView(model);
                    }
                }
                else
                {
                    throw (result.Ex);
                }

                var resultDelete = CategoryDto.Delete(model.Id);
                if (resultDelete.Status == StatusCodes.OK)
                {
                    string message = "Region '" + model.Name + "' has been purged.";

                    LogDto.Create(
                                LogSource.WebsiteAdministration,
                                LogType.Administration,
                                0,
                                string.Empty,
                                message,
                                Common.DBUtilities.GetUserIdByUserName(User.Identity.Name));

                    return Json(new { url = Url.Action("Regions", "ReviewProperties") });
                }
                else
                {
                    throw (resultDelete.Ex);
                }
            }
            catch
            {
                ModelState.AddModelError(string.Empty, "Cannot delete selected region. It is already in use.");
            }

            return PartialView(model);
        }

        public ActionResult SubRegions(long? Id)
        {
            if (Id.HasValue)
            {
                var result = 
                    CategoryDto.Select(
                        x => (x.Id.Equals(Id.Value) || x.ParentId.Equals(Id.Value)) && x.GroupId.Equals(Group.Regions));
                if (result.Status == StatusCodes.OK)
                {
                    SubRegionsViewModel model = new SubRegionsViewModel();

                    if (result.Items.Count > 0)
                    {
                        List<SubRegionViewModel> subRegionList = new List<SubRegionViewModel>();
                        foreach (var item in result.Items.OrderBy(x => x.Name))
                        {
                            if (item.ParentId == 0)
                            {
                                model.RegionId = result.First().Id;
                                model.RegionName = result.First().Name;
                            }
                            else
                            {
                                SubRegionViewModel subRegionViewModel = new SubRegionViewModel();
                                subRegionViewModel.SubRegionId = item.Id;
                                subRegionViewModel.RegionId = Id.Value;
                                subRegionViewModel.Name = item.Name;
                                subRegionViewModel.Enabled = item.IsEnabled;
                                subRegionViewModel.DivEditId = "divmodaleditsubregion" + item.Id.ToString();
                                subRegionViewModel.DivPurgeId = "divmodalpurgesubregion" + item.Id.ToString();

                                subRegionList.Add(subRegionViewModel);
                            }
                        }
                        model.SubRegions = subRegionList;
                    }

                    return View(model);
                }
            }

            return RedirectToAction("Regions", "ReviewProperties"); ;
        }

        [HttpPost]
        public ActionResult CreateSubRegion(SubRegionViewModel model)
        {
            if (ModelState.IsValid)
            {
                var result = 
                    CategoryDto.Select(
                        x => x.Name.Equals(model.Name.Trim()) && 
                             x.ParentId.Equals(model.RegionId) && 
                             x.GroupId.Equals(Group.Regions));
                if (result.Status == StatusCodes.OK)
                {
                    if (result.Items.Count > 0)
                    {
                        ModelState.AddModelError(string.Empty, "Subregion already exists.");

                        return PartialView(model);
                    }
                    else
                    {
                        CategoryDto item = new CategoryDto
                        {
                            Name = model.Name.Trim(),
                            GroupId = Group.Regions,
                            ParentId = model.RegionId,
                            IsEnabled = model.Enabled
                        };

                        var resultCreate = CategoryDto.Create(item);
                        if (resultCreate.Status == StatusCodes.OK)
                        {
                            string message =
                                "Subregion '" + model.Name + "' has been created by " + Common.DBUtilities.GetUsersFullName(User.Identity.Name) + ".";

                            LogDto.Create(
                                LogSource.WebsiteAdministration,
                                LogType.Administration,
                                0,
                                string.Empty,
                                message,
                                Common.DBUtilities.GetUserIdByUserName(User.Identity.Name));

                            return Json(new { url = Url.Action("SubRegions", "ReviewProperties", new { Id = model.RegionId }) });
                        }
                        else
                        {
                            ModelState.AddModelError(string.Empty, "An error occured. Please try again.");

                            return PartialView(model);
                        }
                    }
                }
            }

            return PartialView(model);
        }

        [HttpPost]
        public ActionResult EditSubRegion(SubRegionViewModel model)
        {
            if (ModelState.IsValid)
            {
                var result = CategoryDto.Get(model.SubRegionId);
                if (result.Status == StatusCodes.OK)
                {
                    if (result.Items.Count > 0)
                    {
                        var item = result.First();

                        string oldName = item.Name;
                        item.Name = model.Name.Trim();
                        item.IsEnabled = model.Enabled;

                        if (item.Update().Status == StatusCodes.OK)
                        {
                            string message =
                                "Subregion '" + oldName + "' has been updated to '" + model.Name + "' by " + Common.DBUtilities.GetUsersFullName(User.Identity.Name) + ".";

                            LogDto.Create(
                                LogSource.WebsiteAdministration,
                                LogType.Administration,
                                0,
                                string.Empty,
                                message,
                                Common.DBUtilities.GetUserIdByUserName(User.Identity.Name));

                            return Json(new { url = Url.Action("SubRegions", "ReviewProperties", new { Id = model.RegionId }) });
                        }
                    }
                }
            }

            return PartialView(model);
        }

        [HttpPost]
        public ActionResult PurgeSubRegion(SubRegionViewModel model)
        {
            try
            {
                var result = CategoryDto.Delete(model.SubRegionId);
                if (result.Status == StatusCodes.OK)
                {
                    string message = "Subregion '" + model.Name + "' has been purged.";

                    LogDto.Create(
                        LogSource.WebsiteAdministration,
                        LogType.Administration,
                        0,
                        string.Empty,
                        message,
                        Common.DBUtilities.GetUserIdByUserName(User.Identity.Name));

                    return Json(new { url = Url.Action("SubRegions", "ReviewProperties", new { Id = model.RegionId }) });
                }
                else
                {
                    throw (result.Ex);
                }
            }
            catch
            {
                ModelState.AddModelError(string.Empty, "Cannot delete selected subRegion. It is already in use.");
            }

            return PartialView(model);
        }
    }
}