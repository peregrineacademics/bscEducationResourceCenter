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

#endregion

namespace PAS.ResourceCenter.Web.Administration.Controllers
{
    [Authorize]
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

        public ActionResult Reviewers()
        {
            return View();
        }
    }
}