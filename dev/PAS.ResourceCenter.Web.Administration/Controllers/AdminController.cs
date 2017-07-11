using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PAS.ResourceCenter.Library.Common.Definitions;
using PAS.ResourceCenter.Library.DataAccess.DTO;
using PAS.ResourceCenter.Library.DataAccess.Responses;
using PAS.ResourceCenter.Web.Administration.Models;
using PAS.ResourceCenter.Web.Administration.ViewModels.Admin;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace PAS.ResourceCenter.Web.Administration.Controllers
{
    [Authorize(Roles = "pasadministrator")]
    public class AdminController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public AdminController(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        public ActionResult Index()
        {
            return RedirectToAction("SiteSettings", "Admin");
        }

        private ActionResult RedirectToLocal(string returnUrl = "")
        {
            if (!string.IsNullOrWhiteSpace(returnUrl) && Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }

            return RedirectToAction("SiteSettings", "Admin");
        }

        public ActionResult SiteSettings()
        {
            var result = SiteSettingDto.Select();
            if (result.Status == StatusCodes.OK)
            {
                SettingsViewModel model = new SettingsViewModel();

                List<SettingViewModel> settingList = new List<SettingViewModel>();

                if (result.Items.Count > 0)
                {
                    foreach (var item in result.Items.OrderBy(x => x.DisplayName))
                    {
                        SettingViewModel settingModel = new SettingViewModel();
                        settingModel.Id = item.Id;
                        settingModel.Name = item.Name;

                        settingModel.Value1 = string.Empty;
                        settingModel.Value2 = string.Empty;
                        settingModel.Value3 = string.Empty;
                        settingModel.Value4 = string.Empty;
                        settingModel.Value5 = string.Empty;
                        settingModel.Value6 = string.Empty;
                        settingModel.Value7 = string.Empty;
                        settingModel.Value8 = string.Empty;
                        settingModel.CollectionValue = string.Empty;

                        if (item.IsCollection)
                        {
                            if (!string.IsNullOrEmpty(item.Value))
                            {
                                string tempValue = string.Empty;
                                string[] values = item.Value.Split('|');

                                int ctr = 0;

                                foreach (var collectionValue in values)
                                {
                                    if (!string.IsNullOrEmpty(collectionValue))
                                    {
                                        if (!string.IsNullOrEmpty(tempValue))
                                        {
                                            tempValue += ", " + collectionValue;
                                        }
                                        else
                                        {
                                            tempValue += collectionValue;
                                        }

                                        if (ctr == 0)
                                        {
                                            settingModel.Value1 = collectionValue;
                                        }
                                        else if (ctr == 1)
                                        {
                                            settingModel.Value2 = collectionValue;
                                        }
                                        else if (ctr == 2)
                                        {
                                            settingModel.Value3 = collectionValue;
                                        }
                                        else if (ctr == 3)
                                        {
                                            settingModel.Value4 = collectionValue;
                                        }
                                        else if (ctr == 4)
                                        {
                                            settingModel.Value5 = collectionValue;
                                        }
                                        else if (ctr == 5)
                                        {
                                            settingModel.Value6 = collectionValue;
                                        }
                                        else if (ctr == 6)
                                        {
                                            settingModel.Value7 = collectionValue;
                                        }
                                        else if (ctr == 7)
                                        {
                                            settingModel.Value8 = collectionValue;
                                        }

                                        ctr++;
                                    }
                                }

                                settingModel.CollectionValue = tempValue;
                            }
                        }
                        else if (item.IsPassword)
                        {
                            settingModel.Value1 = item.Value;
                        }
                        else if (item.IsBoolean)
                        {
                            settingModel.Value1 = item.Value;
                        }
                        else
                        {
                            settingModel.Value1 = item.Value;
                        }

                        settingModel.DisplayName = item.DisplayName;
                        settingModel.Notes = item.Notes.Trim();
                        settingModel.Password = item.IsPassword;
                        settingModel.Boolean = item.IsBoolean;
                        settingModel.Collection = item.IsCollection;
                        settingModel.DivEditId = "divmodaleditsetting" + item.Id.ToString();

                        settingList.Add(settingModel);
                    }
                }

                model.Settings = settingList;

                return View(model);
            }

            return RedirectToLocal();
        }

        [HttpPost]
        public ActionResult EditSetting(SettingViewModel model)
        {
            if (ModelState.IsValid)
            {
                var result = SiteSettingDto.Get(model.Id);
                if (result.Status == StatusCodes.OK)
                {
                    if (result.Items.Count > 0)
                    {
                        var setting = result.First();

                        if (setting.IsCollection)
                        {
                            string tempValue = string.Empty;

                            if (!string.IsNullOrEmpty(model.Value1))
                            {
                                if (!string.IsNullOrEmpty(tempValue))
                                {
                                    tempValue += "|" + model.Value1;
                                }
                                else
                                {
                                    tempValue += model.Value1;
                                }
                            }

                            if (!string.IsNullOrEmpty(model.Value2))
                            {
                                if (!string.IsNullOrEmpty(tempValue))
                                {
                                    tempValue += "|" + model.Value2;
                                }
                                else
                                {
                                    tempValue += model.Value2;
                                }
                            }

                            if (!string.IsNullOrEmpty(model.Value3))
                            {
                                if (!string.IsNullOrEmpty(tempValue))
                                {
                                    tempValue += "|" + model.Value3;
                                }
                                else
                                {
                                    tempValue += model.Value3;
                                }
                            }

                            if (!string.IsNullOrEmpty(model.Value4))
                            {
                                if (!string.IsNullOrEmpty(tempValue))
                                {
                                    tempValue += "|" + model.Value4;
                                }
                                else
                                {
                                    tempValue += model.Value4;
                                }
                            }

                            if (!string.IsNullOrEmpty(model.Value5))
                            {
                                if (!string.IsNullOrEmpty(tempValue))
                                {
                                    tempValue += "|" + model.Value5;
                                }
                                else
                                {
                                    tempValue += model.Value5;
                                }
                            }

                            if (!string.IsNullOrEmpty(model.Value6))
                            {
                                if (!string.IsNullOrEmpty(tempValue))
                                {
                                    tempValue += "|" + model.Value6;
                                }
                                else
                                {
                                    tempValue += model.Value6;
                                }
                            }

                            if (!string.IsNullOrEmpty(model.Value7))
                            {
                                if (!string.IsNullOrEmpty(tempValue))
                                {
                                    tempValue += "|" + model.Value7;
                                }
                                else
                                {
                                    tempValue += model.Value7;
                                }
                            }

                            if (!string.IsNullOrEmpty(model.Value8))
                            {
                                if (!string.IsNullOrEmpty(tempValue))
                                {
                                    tempValue += "|" + model.Value8;
                                }
                                else
                                {
                                    tempValue += model.Value8;
                                }
                            }

                            setting.Value = tempValue;
                        }
                        else
                        {
                            setting.Value = model.Value1;
                        }

                        if (setting.Update().Status == StatusCodes.OK)
                        {
                            string message =
                                "Site settings '" + model.Name + "' has been updated by " + Common.DBUtilities.GetUsersFullName(User.Identity.Name) + ".";

                            LogDto.Create(
                                LogSource.WebsiteAdministration,
                                LogType.Administration,
                                0,
                                string.Empty,
                                message,
                                Common.DBUtilities.GetUserIdByUserName(User.Identity.Name));

                            return Json(new { url = Url.Action("SiteSettings", "Admin") });
                        }
                    }
                }
            }

            return PartialView(model);
        }

        public ActionResult Logs()
        {
            return View();
        }

        public JsonResult ListLogs(
            string searchLogSources,
            string searchLogTypes,
            string searchUsers,
            string searchStartDate = "",
            string searchEndDate = "",
            string sortColumnName = "CreatedOn",
            string sortOrder = "desc",
            int pageSize = 50,
            int currentPage = 1)
        {
            List<long> listLogSourceIds = new List<long>();

            if (!string.IsNullOrEmpty(searchLogSources))
            {
                string[] tempList = searchLogSources.Split(',');

                foreach (var item in tempList)
                {
                    try
                    {
                        listLogSourceIds.Add(Convert.ToInt64(item));
                    }
                    catch
                    {
                        // Do nothing
                    }
                }
            }

            List<long> listLogTypeIds = new List<long>();

            if (!string.IsNullOrEmpty(searchLogTypes))
            {
                string[] tempList = searchLogTypes.Split(',');

                foreach (var item in tempList)
                {
                    try
                    {
                        listLogTypeIds.Add(Convert.ToInt64(item));
                    }
                    catch
                    {
                        // Do nothing
                    }
                }
            }

            List<string> listUserIds = new List<string>();

            if (!string.IsNullOrEmpty(searchUsers))
            {
                string[] tempList = searchUsers.Split(',');

                foreach (var item in tempList)
                {
                    try
                    {
                        listUserIds.Add(item.ToString());
                    }
                    catch
                    {
                        // Do nothing
                    }
                }
            }

            DateTime startDate = DateTime.Now.Date.AddMonths(-1);
            DateTime endDate = DateTime.Now.Date;

            try
            {
                startDate = Convert.ToDateTime(searchStartDate).Date;
            }
            catch
            {
                startDate = DateTime.Now.Date.AddMonths(-1);
            }

            try
            {
                endDate = Convert.ToDateTime(searchEndDate).Date;
            }
            catch
            {
                endDate = DateTime.Now.Date;
            }

            List<LogViewModel> list = new List<LogViewModel>();

            int totalPage = 0;
            int totalRecord = 0;

            endDate = endDate.AddDays(1);

            List<LogViewModel> listLogs = new List<LogViewModel>();

            var result = LogDto.Select(x => x.DateCreated >= startDate && x.DateCreated < endDate, true);
            if (result.Status == StatusCodes.OK)
            {
                totalRecord = result.Items.Count();
                if (totalRecord > 0)
                {
                    totalRecord = 0;

                    foreach (var item in result.Items.OrderBy(x => x.DateCreated))
                    {
                        LogViewModel model = new LogViewModel();
                        model.Id = item.Id;
                        model.LogSourceId = item.LogSourceId;
                        model.LogSourceName = item.LogSource.Name;
                        model.LogTypeId = item.LogTypeId;
                        model.LogTypeName = item.LogType.Name;
                        model.UserId = item.LinkUserId;
                        model.Message = item.Message;
                        model.CreatedOn = item.DateCreated;
                        model.CreatedOnString = item.DateCreated.ToString(Constants._formatDate3);
                        model.CreatedByUserId = item.CreatedByUserId;
                        model.CreatedBy = (item.CreatedByUser.LastName + ", " + item.CreatedByUser.FirstName).Trim();

                        model.LinkURL = string.Empty;
                        model.Description = string.Empty;

                        if (item.LogTypeId == LogType.Administration)
                        {
                            model.LinkURL = string.Empty;
                            model.Description = string.Empty;
                        }
                        else if (item.LogTypeId == LogType.User)
                        {
                            model.LinkURL = "/Users/Detail?Id=" + item.LinkUserId;
                            model.Description = Common.DBUtilities.GetUsersFullNameById(item.LinkUserId);
                        }
                        else if (item.LogTypeId == LogType.Review)
                        {
                            model.LinkURL = "/Reviews/Detail?Id=" + item.LinkId.ToString();
                            model.Description = Common.DBUtilities.GetReviewTitleById(item.LinkId);
                        }
                        else if (item.LogTypeId == LogType.Issue)
                        {
                            model.LinkURL = "/Issues/Detail?Id=" + item.LinkId.ToString();
                            model.Description = Common.DBUtilities.GetIssueDateStringById(item.LinkId);
                        }
                        else if (item.LogTypeId == LogType.Reviewer)
                        {
                            model.LinkURL = "/Reviewers/Detail?Id=" + item.LinkId.ToString();
                            model.Description = Common.DBUtilities.GetUsersFullNameById(item.LinkUserId);
                        }

                        bool bAdd = true;

                        if (listLogSourceIds.Count() > 0)
                        {
                            if (listLogSourceIds.IndexOf(item.LogSourceId) < 0)
                            {
                                bAdd = false;
                            }
                        }

                        if (bAdd)
                        {
                            if (listLogTypeIds.Count() > 0)
                            {
                                if (listLogTypeIds.IndexOf(item.LogTypeId) < 0)
                                {
                                    bAdd = false;
                                }
                            }
                        }

                        if (bAdd)
                        {
                            if (listUserIds.Count() > 0)
                            {
                                if (listUserIds.IndexOf(item.LinkUserId) < 0 &&
                                    listUserIds.IndexOf(item.CreatedByUserId) < 0)
                                {
                                    bAdd = false;
                                }
                            }
                        }

                        if (bAdd)
                        {
                            listLogs.Add(model);

                            totalRecord++;
                        }
                    }

                    if (pageSize > 0)
                    {
                        totalPage = totalRecord / pageSize + ((totalRecord % pageSize) > 0 ? 1 : 0);

                        if (sortColumnName == "Description")
                        {
                            if (sortOrder == "desc")
                                list = listLogs.OrderByDescending(x => x.Description).Skip(pageSize * (currentPage - 1)).Take(pageSize).ToList();
                            else
                                list = listLogs.OrderBy(x => x.Description).Skip(pageSize * (currentPage - 1)).Take(pageSize).ToList();
                        }
                        else if (sortColumnName == "LogSourceName")
                        {
                            if (sortOrder == "desc")
                                list = listLogs.OrderByDescending(x => x.LogSourceName).Skip(pageSize * (currentPage - 1)).Take(pageSize).ToList();
                            else
                                list = listLogs.OrderBy(x => x.LogSourceName).Skip(pageSize * (currentPage - 1)).Take(pageSize).ToList();
                        }
                        else if (sortColumnName == "LogTypeName")
                        {
                            if (sortOrder == "desc")
                                list = listLogs.OrderByDescending(x => x.LogTypeName).Skip(pageSize * (currentPage - 1)).Take(pageSize).ToList();
                            else
                                list = listLogs.OrderBy(x => x.LogTypeName).Skip(pageSize * (currentPage - 1)).Take(pageSize).ToList();
                        }
                        else if (sortColumnName == "Message")
                        {
                            if (sortOrder == "desc")
                                list = listLogs.OrderByDescending(x => x.Message).Skip(pageSize * (currentPage - 1)).Take(pageSize).ToList();
                            else
                                list = listLogs.OrderBy(x => x.Message).Skip(pageSize * (currentPage - 1)).Take(pageSize).ToList();
                        }
                        else if (sortColumnName == "Message")
                        {
                            if (sortOrder == "desc")
                                list = listLogs.OrderByDescending(x => x.Message).Skip(pageSize * (currentPage - 1)).Take(pageSize).ToList();
                            else
                                list = listLogs.OrderBy(x => x.Message).Skip(pageSize * (currentPage - 1)).Take(pageSize).ToList();
                        }
                        else if (sortColumnName == "CreatedBy")
                        {
                            if (sortOrder == "desc")
                                list = listLogs.OrderByDescending(x => x.CreatedBy).Skip(pageSize * (currentPage - 1)).Take(pageSize).ToList();
                            else
                                list = listLogs.OrderBy(x => x.CreatedBy).Skip(pageSize * (currentPage - 1)).Take(pageSize).ToList();
                        }
                        else if (sortColumnName == "CreatedOn")
                        {
                            if (sortOrder == "desc")
                                list = listLogs.OrderByDescending(x => x.CreatedOn).Skip(pageSize * (currentPage - 1)).Take(pageSize).ToList();
                            else
                                list = listLogs.OrderBy(x => x.CreatedOn).Skip(pageSize * (currentPage - 1)).Take(pageSize).ToList();
                        }
                    }
                    else
                    {
                        list = listLogs;
                    }
                }
            }

            List<LogSourceViewModel> logSourceList = new List<LogSourceViewModel>();

            var resultLogSource = LogSourceDto.Select();
            if (resultLogSource.Status == StatusCodes.OK)
            {
                if (resultLogSource.Items.Count > 0)
                {
                    foreach (var item in resultLogSource.Items.OrderBy(x => x.Name))
                    {
                        LogSourceViewModel logSourceModel = new LogSourceViewModel();
                        logSourceModel.Id = item.Id;
                        logSourceModel.Name = item.Name;

                        logSourceList.Add(logSourceModel);
                    }
                }
            }

            List<LogTypeViewModel> logTypeList = new List<LogTypeViewModel>();

            var resultLogType = LogTypeDto.Select();
            if (resultLogType.Status == StatusCodes.OK)
            {
                if (resultLogType.Items.Count > 0)
                {
                    foreach (var item in resultLogType.Items.OrderBy(x => x.Name))
                    {
                        LogTypeViewModel logTypeModel = new LogTypeViewModel();
                        logTypeModel.Id = item.Id;
                        logTypeModel.Name = item.Name;

                        logTypeList.Add(logTypeModel);
                    }
                }
            }

            List<UserSearchViewModel> userList = new List<UserSearchViewModel>();

            var resultUsers = UsersDto.Select();
            if (resultUsers.Status == StatusCodes.OK)
            {
                if (resultUsers.Items.Count > 0)
                {
                    foreach (var item in resultUsers.Items.OrderBy(x => x.LastName).ThenBy(x => x.FirstName).ThenBy(x => x.UserName))
                    {
                        UserSearchViewModel userSearchModel = new UserSearchViewModel();
                        userSearchModel.Id = item.Id;
                        userSearchModel.FullName = (item.LastName + ", " + item.FirstName).Trim();

                        userList.Add(userSearchModel);
                    }
                }
            }

            return Json(
                new {
                    list = list,
                    logSourceList = logSourceList,
                    logTypeList = logTypeList,
                    userList = userList,
                    searchLogSources = searchLogSources,
                    searchLogTypes = searchLogTypes,
                    searchUsers = searchUsers,
                    totalRecord = totalRecord,
                    totalPage = totalPage,
                    sortColumnName = sortColumnName,
                    sortOrder = sortOrder,
                    currentPage = currentPage
                });
        }

        public ActionResult ExportLogsToExcel(
            string searchLogSources,
            string searchLogTypes,
            string searchClients,
            string searchUsers,
            string searchStartDate,
            string searchEndDate)
        {
            List<long> listLogSourceIds = new List<long>();

            if (!string.IsNullOrEmpty(searchLogSources))
            {
                string[] tempList = searchLogSources.Split(',');

                foreach (var item in tempList)
                {
                    try
                    {
                        listLogSourceIds.Add(Convert.ToInt64(item));
                    }
                    catch
                    {
                        // Do nothing
                    }
                }
            }

            List<long> listLogTypeIds = new List<long>();

            if (!string.IsNullOrEmpty(searchLogTypes))
            {
                string[] tempList = searchLogTypes.Split(',');

                foreach (var item in tempList)
                {
                    try
                    {
                        listLogTypeIds.Add(Convert.ToInt64(item));
                    }
                    catch
                    {
                        // Do nothing
                    }
                }
            }

            List<string> listUserIds = new List<string>();

            if (!string.IsNullOrEmpty(searchUsers))
            {
                string[] tempList = searchUsers.Split(',');

                foreach (var item in tempList)
                {
                    try
                    {
                        listUserIds.Add(item.ToString());
                    }
                    catch
                    {
                        // Do nothing
                    }
                }
            }

            DateTime startDate = DateTime.Now.Date.AddMonths(-1);
            DateTime endDate = DateTime.Now.Date;

            try
            {
                startDate = Convert.ToDateTime(searchStartDate).Date;
            }
            catch
            {
                startDate = DateTime.Now.Date.AddMonths(-1);
            }

            try
            {
                endDate = Convert.ToDateTime(searchEndDate).Date;
            }
            catch
            {
                endDate = DateTime.Now.Date;
            }

            endDate = endDate.AddDays(1);

            List<LogViewModel> listLogs = new List<LogViewModel>();

            var result = LogDto.Select(x => x.DateCreated >= startDate && x.DateCreated < endDate, true);
            if (result.Status == StatusCodes.OK)
            {
                if (result.Items.Count > 0)
                {
                    foreach (var item in result.Items.OrderBy(x => x.DateCreated))
                    {
                        LogViewModel model = new LogViewModel();
                        model.Id = item.Id;
                        model.LogSourceId = item.LogSourceId;
                        model.LogSourceName = item.LogSource.Name;
                        model.LogTypeId = item.LogTypeId;
                        model.LogTypeName = item.LogType.Name;
                        model.UserId = item.LinkUserId;
                        model.Message = item.Message;
                        model.CreatedOn = item.DateCreated;
                        model.CreatedOnString = item.DateCreated.ToString(Constants._formatDate3);
                        model.CreatedByUserId = item.CreatedByUserId;
                        model.CreatedBy = (item.CreatedByUser.LastName + ", " + item.CreatedByUser.FirstName).Trim();

                        model.LinkURL = string.Empty;
                        model.Description = string.Empty;

                        if (item.LogTypeId == LogType.Administration)
                        {
                            model.LinkURL = string.Empty;
                            model.Description = string.Empty;
                        }
                        else if (item.LogTypeId == LogType.User)
                        {
                            model.LinkURL = "/Users/Detail?Id=" + item.LinkUserId;
                            model.Description = Common.DBUtilities.GetUsersFullNameById(item.LinkUserId);
                        }
                        else if (item.LogTypeId == LogType.Review)
                        {
                            model.LinkURL = "/Reviews/Detail?Id=" + item.LinkId.ToString();
                            model.Description = Common.DBUtilities.GetReviewTitleById(item.LinkId);
                        }
                        else if (item.LogTypeId == LogType.Issue)
                        {
                            model.LinkURL = "/Issues/Detail?Id=" + item.LinkId.ToString();
                            model.Description = Common.DBUtilities.GetIssueDateStringById(item.LinkId);
                        }
                        else if (item.LogTypeId == LogType.Reviewer)
                        {
                            model.LinkURL = "/Reviewers/Detail?Id=" + item.LinkId.ToString();
                            model.Description = Common.DBUtilities.GetUsersFullNameById(item.LinkUserId);
                        }

                        bool bAdd = true;

                        if (listLogSourceIds.Count() > 0)
                        {
                            if (listLogSourceIds.IndexOf(item.LogSourceId) < 0)
                            {
                                bAdd = false;
                            }
                        }

                        if (bAdd)
                        {
                            if (listLogTypeIds.Count() > 0)
                            {
                                if (listLogTypeIds.IndexOf(item.LogTypeId) < 0)
                                {
                                    bAdd = false;
                                }
                            }
                        }

                        if (bAdd)
                        {
                            if (listUserIds.Count() > 0)
                            {
                                if (listUserIds.IndexOf(item.LinkUserId) < 0 &&
                                    listUserIds.IndexOf(item.CreatedByUserId) < 0)
                                {
                                    bAdd = false;
                                }
                            }
                        }

                        if (bAdd)
                        {
                            listLogs.Add(model);
                        }
                    }
                }
            }

            if (listLogs.Count() > 0)
            {
                // TODO : Write a new code that runs in ASP.NET Core
                //var grid = new GridView();
                //grid.DataSource = listLogs;
                //grid.DataBind();

                //Response.ClearContent();
                //Response.Buffer = true;
                //Response.AddHeader("content-disposition", "attachment; filename=Logs.xls");
                //Response.ContentType = "application/ms-excel";

                //Response.Charset = string.Empty;
                //StringWriter sw = new StringWriter();
                //HtmlTextWriter htw = new HtmlTextWriter(sw);

                //grid.RenderControl(htw);

                //Response.Output.Write(sw.ToString());
                //Response.Flush();
                //Response.End();
            }

            return RedirectToLocal();
        }
    }
}