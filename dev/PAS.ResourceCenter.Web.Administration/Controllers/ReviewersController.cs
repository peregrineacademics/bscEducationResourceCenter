#region Using

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PAS.ResourceCenter.Library.DataAccess.DTO;
using PAS.ResourceCenter.Web.Administration.Models;
using PAS.ResourceCenter.Web.Administration.ViewModels.Reviewers;
using System.Collections.Generic;
using System;
using System.Linq;
using System.Threading.Tasks;
using PAS.ResourceCenter.Web.Administration.Common;
using PAS.ResourceCenter.Library.DataAccess.Models;
using PAS.ResourceCenter.Library.DataAccess.Responses;

#endregion

namespace PAS.ResourceCenter.Web.Administration.Controllers
{
    [Authorize(Roles = "pasadministrator,pasreadonlyuser,editor")]
    public class ReviewersController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public ReviewersController(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        public ActionResult Index()
        {
            return View();
        }

        public JsonResult List(
            string searchName,
            string sortColumnName = "ScreenName",
            string sortOrder = "asc",
            int pageSize = 50,
            int currentPage = 1)
        {
            List<ReviewerSearchViewModel> list = new List<ReviewerSearchViewModel>();

            int totalPage = 0;
            int totalRecord = 0;

            string reviewerRoleId = Common.DBUtilities.GetRoleIdByName(Constants._roleReviewer);

            if (!string.IsNullOrEmpty(searchName))
            {
                var result = UsersDto.Select(
                                x => (x.ScreenName.Contains(searchName) ||
                                      x.Email.Contains(searchName) ||
                                      x.LastName.Contains(searchName) ||
                                      x.FirstName.Contains(searchName)), true);

                if (string.IsNullOrEmpty(searchName))
                {
                    result = UsersDto.Select(null, true);
                }

                if (result.Status == Library.DataAccess.Responses.StatusCodes.OK)
                {
                    totalRecord = result.Items.Count();
                    if (totalRecord > 0)
                    {
                        totalRecord = 0;

                        List<ReviewerSearchViewModel> listReviewers = new List<ReviewerSearchViewModel>();

                        foreach (var item in result.Items.OrderBy(x => x.ScreenName))
                        {
                            ReviewerSearchViewModel model = new ReviewerSearchViewModel();
                            model.Id = item.Id;
                            model.ScreenName = item.ScreenName;
                            model.FullName = (item.LastName + ", " + item.FirstName + " " + item.MiddleName).Trim();
                            model.Email = item.Email;
                            model.Biography = item.Biography;
                            model.HideFromReviewerList = item.HideFromReviewerList;
                            model.IsActiveReviewer = item.IsActiveReviewer;
                            model.Enabled = item.IsEnabled;
                            model.Created = item.DateCreated.ToString(Constants._formatDate3);
                            model.Modified = item.LastUpdated.ToString(Constants._formatDate3);

                            model.ReviewsCount = Common.DBUtilities.GetReviewsCountByUserId(item.Id);

                            bool found = false;
                            foreach (var role in item.UserRoles)
                            {
                                if (reviewerRoleId == role.RoleId)
                                {
                                    found = true;
                                    break;
                                }
                            }

                            if (found)
                            {
                                listReviewers.Add(model);

                                totalRecord++;

                                if (totalRecord >= 100)
                                    break;
                            }
                        }

                        if (pageSize > 0)
                            totalPage = totalRecord / pageSize + ((totalRecord % pageSize) > 0 ? 1 : 0);

                        list = listReviewers;
                    }
                }
            }
            else
            {
                var result = UsersDto.Select(null, true);
                if (result.Status == Library.DataAccess.Responses.StatusCodes.OK)
                {
                    totalRecord = result.Items.Count();
                    if (totalRecord > 0)
                    {
                        totalRecord = 0;

                        List<ReviewerSearchViewModel> listReviewers = new List<ReviewerSearchViewModel>();

                        foreach (var item in result.Items.OrderBy(x => x.ScreenName))
                        {
                            ReviewerSearchViewModel model = new ReviewerSearchViewModel();
                            model.Id = item.Id;
                            model.ScreenName = item.ScreenName;
                            model.FullName = (item.LastName + ", " + item.FirstName + " " + item.MiddleName).Trim();
                            model.Email = item.Email;
                            model.Biography = item.Biography;
                            model.HideFromReviewerList = item.HideFromReviewerList;
                            model.IsActiveReviewer = item.IsActiveReviewer;
                            model.Enabled = item.IsEnabled;
                            model.Created = item.DateCreated.ToString(Constants._formatDate3);
                            model.Modified = item.LastUpdated.ToString(Constants._formatDate3);

                            model.ReviewsCount = Common.DBUtilities.GetReviewsCountByUserId(item.Id);

                            bool found = false;
                            foreach (var role in item.UserRoles)
                            {
                                if (reviewerRoleId == role.RoleId)
                                {
                                    found = true;
                                    break;
                                }
                            }

                            if (found)
                            {
                                listReviewers.Add(model);

                                totalRecord++;

                                if (totalRecord >= 100)
                                    break;
                            }
                        }

                        if (pageSize > 0)
                            totalPage = totalRecord / pageSize + ((totalRecord % pageSize) > 0 ? 1 : 0);

                        list = listReviewers;
                    }
                }
            }

            return Json(
                new
                {
                    list = list,
                    searchName = searchName,
                    totalRecord = totalRecord,
                    totalPage = totalPage,
                    sortColumnName = sortColumnName,
                    sortOrder = sortOrder,
                    currentPage = currentPage
                });
        }

        public JsonResult ListAutoCompleteValues(string searchName)
        {
            List<SearchNameViewModel> list = new List<SearchNameViewModel>();

            string reviewerRoleId = Common.DBUtilities.GetRoleIdByName(Constants._roleReviewer);

            if (!string.IsNullOrEmpty(searchName))
            {
                List<SearchNameViewModel> listUsers1 = new List<SearchNameViewModel>();
                List<SearchNameViewModel> listUsers2 = new List<SearchNameViewModel>();
                List<SearchNameViewModel> listUsers3 = new List<SearchNameViewModel>();

                var result1 = UsersDto.Select(x => x.Email.StartsWith(searchName) && !x.Email.Equals(User.Identity.Name), true);
                if (result1.Status == Library.DataAccess.Responses.StatusCodes.OK)
                {
                    if (result1.Items.Count > 0)
                    {
                        foreach (var item in result1.Items.OrderBy(x => x.Email).Take(100))
                        {
                            bool found = false;
                            foreach (var role in item.UserRoles)
                            {
                                if (reviewerRoleId == role.RoleId)
                                {
                                    found = true;
                                    break;
                                }
                            }

                            if (found)
                            {
                                SearchNameViewModel model = new SearchNameViewModel();
                                model.Name = item.Email.Trim();

                                listUsers1.Add(model);
                            }
                        }
                    }
                }

                var result2 = UsersDto.Select(x => x.LastName.StartsWith(searchName) && !x.Email.Equals(User.Identity.Name), true);
                if (result2.Status == Library.DataAccess.Responses.StatusCodes.OK)
                {
                    if (result2.Items.Count > 0)
                    {
                        foreach (var item in result2.Items.OrderBy(x => x.LastName).Take(100))
                        {
                            bool found = false;
                            foreach (var role in item.UserRoles)
                            {
                                if (reviewerRoleId == role.RoleId)
                                {
                                    found = true;
                                    break;
                                }
                            }

                            if (found)
                            {
                                SearchNameViewModel model = new SearchNameViewModel();
                                model.Name = item.LastName.Trim();

                                listUsers2.Add(model);
                            }
                        }
                    }
                }

                var result3 = UsersDto.Select(x => x.FirstName.StartsWith(searchName) && !x.Email.Equals(User.Identity.Name), true);
                if (result3.Status == Library.DataAccess.Responses.StatusCodes.OK)
                {
                    if (result3.Items.Count > 0)
                    {
                        foreach (var item in result3.Items.OrderBy(x => x.FirstName).Take(100))
                        {
                            bool found = false;
                            foreach (var role in item.UserRoles)
                            {
                                if (reviewerRoleId == role.RoleId)
                                {
                                    found = true;
                                    break;
                                }
                            }

                            if (found)
                            {
                                SearchNameViewModel model = new SearchNameViewModel();
                                model.Name = item.FirstName.Trim();

                                listUsers3.Add(model);
                            }
                        }
                    }
                }

                var listUsers4 = listUsers1.Union(listUsers2).Union(listUsers3).OrderBy(x => x.Name).Take(100);

                if (listUsers4 != null)
                {
                    if (listUsers4.Count() > 0)
                    {
                        List<SearchNameViewModel> listUsers = new List<SearchNameViewModel>();

                        foreach (var item in listUsers4)
                        {
                            SearchNameViewModel model = new SearchNameViewModel();
                            model.Name = item.Name.Trim();

                            listUsers.Add(model);
                        }

                        list = listUsers;
                    }
                }
            }
            else
            {
                var result = UsersDto.Select();
                if (result.Status == Library.DataAccess.Responses.StatusCodes.OK)
                {
                    if (result.Items.Count > 0)
                    {
                        List<SearchNameViewModel> listUsers = new List<SearchNameViewModel>();

                        foreach (var item in result.Items.OrderBy(x => x.Email).Take(100))
                        {
                            bool found = false;
                            foreach (var role in item.UserRoles)
                            {
                                if (reviewerRoleId == role.RoleId)
                                {
                                    found = true;
                                    break;
                                }
                            }

                            if (found)
                            {
                                SearchNameViewModel model = new SearchNameViewModel();
                                model.Name = item.Email.Trim();

                                listUsers.Add(model);
                            }
                        }

                        list = listUsers;
                    }
                }
            }

            return Json(new { list = list });
        }

        [Authorize(Roles = "pasadministrator,editor")]
        public ActionResult Create()
        {
            ReviewerViewModel model = new ReviewerViewModel();
            model.Id = System.Guid.NewGuid().ToString();
            model.ScreenName = string.Empty;
            model.LastName = string.Empty;
            model.FirstName = string.Empty;
            model.MiddleName = string.Empty;
            model.Biography = string.Empty;
            model.HideFromReviewerList = false;
            model.IsActiveReviewer = true;
            model.Email = string.Empty;
            model.Created = DateTime.Now;
            model.Enabled = true;

            return View(model);
        }

        [HttpPost]
        public async Task<ActionResult> Create(ReviewerViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (DBUtilities.CheckIfEmailExists(model.Email.Trim(), string.Empty))
                {
                    ViewBag.Message = Constants._valueError;

                    TempData[Constants._valueMessage] = "Email already exists.";

                    return View(model);
                }

                ApplicationUser applicationUser = new ApplicationUser();
                applicationUser.Id = model.Id;
                applicationUser.Email = model.Email.ToLower().Trim();
                applicationUser.UserName = applicationUser.Email;
                applicationUser.LastName = model.LastName.Trim();
                applicationUser.FirstName = model.FirstName.Trim();
                applicationUser.MiddleName = model.MiddleName.Trim();
                applicationUser.Title = string.Empty;
                applicationUser.ScreenName = model.ScreenName.Trim();
                applicationUser.Degree = string.Empty;
                applicationUser.Biography = model.Biography.Trim();
                applicationUser.HideFromReviewerList = model.HideFromReviewerList;
                applicationUser.IsActiveReviewer = model.IsActiveReviewer;
                applicationUser.IsEnabled = model.Enabled;
                applicationUser.DateCreated = DateTime.Now;
                applicationUser.LastUpdated = applicationUser.DateCreated;

                applicationUser.EmailConfirmed = true;

                var result = await _userManager.CreateAsync(applicationUser, "r3v13w3r");

                if (result.Succeeded)
                {
                    await _userManager.AddToRoleAsync(applicationUser, Constants._roleReviewer);

                    string message = "Reviewer with email '" + model.Email.ToString() + "' has been created.";
                    string loggedUserId = DBUtilities.GetUserIdByUserName(User.Identity.Name);

                    LogDto.Create(
                        Library.Common.Definitions.LogSource.WebsiteAdministration,
                        Library.Common.Definitions.LogType.User,
                        0,
                        model.Id,
                        message,
                        loggedUserId);

                    return RedirectToAction("Edit", "Reviewers", new { Id = model.Id });
                }
                else
                {
                    ViewBag.Message = Constants._valueError;

                    TempData[Constants._valueMessage] = "An error occured while saving. Please try again.";

                    return View(model);
                }
            }

            return View(model);
        }

        public ActionResult Edit(string Id)
        {
            if (!User.IsInRole(Constants._rolePASReadOnly))
            {
                if (!string.IsNullOrEmpty(Id))
                {
                    var result = UsersDto.Get(Id, true);
                    if (result.Status == Library.DataAccess.Responses.StatusCodes.OK)
                    {
                        if (result.Items.Count > 0)
                        {
                            var item = result.First();

                            ReviewerViewModel model = new ReviewerViewModel();
                            model.Id = item.Id;
                            model.ScreenName = item.ScreenName;
                            model.LastName = item.LastName;
                            model.FirstName = item.FirstName;
                            model.MiddleName = item.MiddleName;
                            model.HideFromReviewerList = item.HideFromReviewerList;
                            model.IsActiveReviewer = item.IsActiveReviewer;
                            model.Biography = item.Biography;
                            model.Email = item.Email;
                            model.Created = item.DateCreated;
                            model.Enabled = item.IsEnabled;

                            bool isReviewer = false;
                            foreach (var role in item.UserRoles)
                            {
                                var roleItem = RolesDto.Get(role.RoleId).Items.First();

                                if (roleItem.Name == Constants._roleReviewer)
                                {
                                    isReviewer = true;
                                }

                                break;
                            }

                            if (isReviewer)
                            {
                                return View(model);
                            }
                        }
                    }
                }
            }

            return RedirectToAction("Index", "Reviewers");
        }

        [HttpPost]
        public ActionResult Edit(ReviewerViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (DBUtilities.CheckIfEmailExists(model.Email.ToLower().Trim(), model.Id))
                {
                    ModelState.AddModelError(string.Empty, "Email already exists.");

                    return PartialView(model);
                }

                string loggedUserId = DBUtilities.GetUserIdByUserName(User.Identity.Name);

                Transaction.Begin();
                try
                {
                    var result = UsersDto.Get(model.Id);
                    if (result.Status == Library.DataAccess.Responses.StatusCodes.OK)
                    {
                        if (result.Items.Count > 0)
                        {
                            var user = result.First();

                            user.ScreenName = model.ScreenName.Trim();
                            user.LastName = model.LastName.Trim();
                            user.FirstName = model.FirstName.Trim();
                            user.MiddleName = model.MiddleName.Trim();
                            user.Email = model.Email.ToLower().Trim();
                            user.UserName = model.Email.ToLower().Trim();
                            user.HideFromReviewerList = model.HideFromReviewerList;
                            user.IsActiveReviewer = model.IsActiveReviewer;
                            user.Biography = model.Biography.Trim();
                            user.IsEnabled = model.Enabled;
                            user.LastUpdated = DateTime.Now;

                            if (user.Update().Status == Library.DataAccess.Responses.StatusCodes.OK)
                            {
                                string message =
                                    "Reviewer with email '" + model.Email.ToString() + "' has been edited.";

                                var createLog =
                                    LogDto.Create(
                                        Library.Common.Definitions.LogSource.WebsiteAdministration,
                                        Library.Common.Definitions.LogType.User,
                                        0,
                                        model.Id,
                                        message,
                                        loggedUserId);
                                if (createLog.Status != Library.DataAccess.Responses.StatusCodes.OK)
                                    throw (createLog.Ex);

                                Transaction.Commit();
                            }
                            else
                            {
                                throw (result.Ex);
                            }
                        }
                    }
                    else
                    {
                        throw (result.Ex);
                    }
                }
                catch
                {
                    Transaction.RollBack();
                    throw;
                }
                finally
                {
                    Transaction.EndTransaction();
                }

                ViewBag.Message = Constants._valueSuccess;

                TempData[Constants._valueMessage] = "Reviewer's profile successfully updated.";

                return View(model);
            }

            return View(model);
        }

        [HttpPost]
        public ActionResult Purge(ReviewerViewModel model)
        {
            string loggedUserId = DBUtilities.GetUserIdByUserName(User.Identity.Name);

            Transaction.Begin();
            try
            {
                var result = UsersDto.DeleteWithoutLogs(model.Id);
                if (result.Status == StatusCodes.OK)
                {
                    string message = "Reviewer with email '" + model.Email.ToString() + "' has been purged.";

                    LogDto.Create(
                        Library.Common.Definitions.LogSource.WebsiteAdministration,
                        Library.Common.Definitions.LogType.User,
                        0,
                        model.Id,
                        message,
                        loggedUserId);

                    Transaction.Commit();

                    return Json(new { url = Url.Action("Index", "Reviewers") });
                }
                else
                {
                    throw (result.Ex);
                }
            }
            catch
            {
                Transaction.RollBack();

                ModelState.AddModelError(string.Empty, "An error occured while purging the user. Please try again.");
            }
            finally
            {
                Transaction.EndTransaction();
            }

            return PartialView(model);
        }

        [HttpPost]
        public async Task<ActionResult> ResetReviewerPasswordEmail(ReviewerViewModel model)
        {
            try
            {
                var applicationUser = await _userManager.FindByIdAsync(model.Id);

                if (applicationUser == null)
                {
                    ModelState.AddModelError(string.Empty, "An error occured while sending the reset password email. Please try again.");

                    return PartialView(model);
                }

                string code = await _userManager.GeneratePasswordResetTokenAsync(applicationUser);

                var callbackUrl =
                    Url.Action("ResetPassword", "Account", new { Id = model.Id, code = code }, protocol: Request.Scheme);

                string fullName = (model.FirstName + " " + model.LastName).Trim();

                Email.SendCredentials(model.Email, model.Email, fullName, callbackUrl);

                string message = "Reviewer password with email '" + model.Email.ToString() + "' has been reset.";

                LogDto.Create(
                    Library.Common.Definitions.LogSource.WebsiteAdministration,
                    Library.Common.Definitions.LogType.User,
                    0,
                    model.Id,
                    message,
                    DBUtilities.GetUserIdByUserName(User.Identity.Name));

                return Json(new { url = Url.Action("Index", "Reviewers") });
            }
            catch
            {
                ModelState.AddModelError(string.Empty, "An error occured while sending the email. Please try again.");

                return PartialView(model);
            }
        }
    }
}