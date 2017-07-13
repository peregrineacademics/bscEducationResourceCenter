using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PAS.ResourceCenter.Library.Common.Definitions;
using PAS.ResourceCenter.Library.DataAccess.DTO;
using PAS.ResourceCenter.Web.Administration.Models;
using PAS.ResourceCenter.Web.Administration.ViewModels.Home;
using System;
using System.Threading.Tasks;

namespace PAS.ResourceCenter.Web.Administration.Controllers
{
    [Authorize(Roles = "pasadministrator,pasreadonlyuser,editor")]
    public class HomeController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public HomeController(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> MyProfile(MyProfileViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByNameAsync(User.Identity.Name);

                if (Common.DBUtilities.CheckIfEmailExists(model.ProfileEmail.Trim(), user.Id))
                {
                    ModelState.AddModelError(string.Empty, "Email already exists.");

                    return PartialView(model);
                }

                bool userNameChanged = false;
                string oldEmail = string.Empty;

                var result = UsersDto.Get(user.Id);
                if (result.Status == Library.DataAccess.Responses.StatusCodes.OK)
                {
                    if (result.Items.Count > 0)
                    {
                        var item = result.First();

                        item.FirstName = model.ProfileFirstName.Trim();
                        item.LastName = model.ProfileLastName.Trim();
                        item.MiddleName = model.ProfileMiddleName.Trim();

                        if (model.ProfileEmail.ToLower().Trim() != item.Email.ToLower().Trim())
                        {
                            userNameChanged = true;

                            item.Email = model.ProfileEmail.ToLower().Trim();
                            item.UserName = model.ProfileEmail.ToLower().Trim();
                        }

                        item.LastUpdated = DateTime.UtcNow;

                        if (item.Update().Status == Library.DataAccess.Responses.StatusCodes.OK)
                        {
                            string message = string.Empty;

                            HttpContext.Session.SetString(
                                Constants._valueUserFullName,
                                (result.First().FirstName.Trim() + " " +
                                result.First().LastName.Trim()).Trim());

                            HttpContext.Session.SetString(Constants._valueUserFirstName, item.FirstName);
                            HttpContext.Session.SetString(Constants._valueUserLastName, item.LastName);
                            HttpContext.Session.SetString(Constants._valueUserMiddleName, item.MiddleName);
                            HttpContext.Session.SetString(Constants._valueUserEmail, item.Email);

                            if (userNameChanged)
                            {
                                message =
                                    "User profile has been updated and email changed from '" +
                                    oldEmail + "' to '" + model.ProfileEmail.ToLower().Trim() + "'.";

                                LogDto.Create(
                                    LogSource.WebsiteAdministration,
                                    LogType.User,
                                    0,
                                    user.Id,
                                    message,
                                    user.Id);

                                return Json(new { url = Url.Action("EmailChanged", "Account") });
                            }
                            else
                            {
                                message = "User profile has been updated.";

                                LogDto.Create(
                                    LogSource.WebsiteAdministration,
                                    LogType.User,
                                    0,
                                    user.Id,
                                    message,
                                    user.Id);
                                
                                return Json(new { url = Url.Action("Index", "Home") });
                            }
                        }
                    }
                }
            }
            else
            {
                var result = UsersDto.Select(x => x.UserName.Equals(User.Identity.Name));
                if (result.Status == Library.DataAccess.Responses.StatusCodes.OK)
                {
                    if (result.Items.Count > 0)
                    {
                        var item = result.First();

                        ModelState.Clear();

                        MyProfileViewModel myProfileViewModel = new MyProfileViewModel();

                        myProfileViewModel.ProfileFirstName = item.FirstName;
                        myProfileViewModel.ProfileLastName = item.LastName;
                        myProfileViewModel.ProfileMiddleName = item.MiddleName;
                        myProfileViewModel.ProfileEmail = item.Email;

                        return PartialView(myProfileViewModel);
                    }
                }
                else
                {
                    throw (result.Ex);
                }
            }

            return Json(new { url = Url.Action("Index", "Home") });
        }

        [HttpPost]
        public async Task<ActionResult> ChangePassword(ChangePasswordViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByNameAsync(User.Identity.Name);

                var result = _userManager.ChangePasswordAsync(user, model.OldPassword, model.ConfirmPassword);

                if (result.Result.Succeeded)
                {
                    string message = "User password has been changed.";

                    LogDto.Create(
                        LogSource.WebsiteAdministration,
                        LogType.User,
                        0,
                        user.Id,
                        message,
                        user.Id);

                    return Json(new { url = Url.Action("Index", "Home") });
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Old password is invalid.");

                    return PartialView(model);
                }
            }

            ModelState.Clear();

            return PartialView(model);
        }

        [HttpGet]
        public ActionResult SampleInstructorReviewView()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SampleInstructorReviewView(int? Id)
        {
            return RedirectToAction("EditInstructorReview", "Home");
        }

        public ActionResult SampleEdgeReviewView()
        {
            return View();
        }

        public ActionResult CreateReview()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateReview(int? Id)
        {
            return RedirectToAction("SampleInstructorReviewView", "Home");
        }

        public ActionResult EditInstructorReview()
        {
            return View();
        }

        [HttpPost]
        public ActionResult EditInstructorReview(int? Id)
        {
            return RedirectToAction("SampleInstructorReviewView", "Home");
        }

        public ActionResult EditQuizQuestions()
        {
            return View();
        }

        [HttpPost]
        public ActionResult EditQuizQuestions(int? Id)
        {
            return RedirectToAction("SampleInstructorReviewView", "Home");
        }

        public ActionResult EditEdgeReview()
        {
            return View();
        }

        [HttpPost]
        public ActionResult EditEdgeReview(int? Id)
        {
            return RedirectToAction("SampleEdgeReviewView", "Home");
        }
    }
}