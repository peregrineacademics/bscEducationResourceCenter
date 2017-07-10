using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PAS.ResourceCenter.Library.Common.Definitions;
using PAS.ResourceCenter.Library.DataAccess.DTO;
using PAS.ResourceCenter.Library.DataAccess.Models;
using PAS.ResourceCenter.Library.DataAccess.Responses;
using PAS.ResourceCenter.Web.Administration.Common;
using PAS.ResourceCenter.Web.Administration.Models;
using PAS.ResourceCenter.Web.Administration.ViewModels.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PAS.ResourceCenter.Web.Administration.Controllers
{
    [Authorize(Roles = "pasadministrator,pasreadonlyuser,editor")]
    public class UsersController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public UsersController(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        public ActionResult Index()
        {
            return View();
        }

        public JsonResult List(
            string searchRoles, 
            string searchName, 
            string sortColumnName = "FullName", 
            string sortOrder = "asc", 
            int pageSize = 50, 
            int currentPage = 1)
        {
            List<string> listRoles = new List<string>();

            if (!string.IsNullOrEmpty(searchRoles))
            {
                string[] tempList = searchRoles.Split(',');

                foreach (var item in tempList)
                {
                    listRoles.Add(item);
                }
            }

            List<UserSearchViewModel> list = new List<UserSearchViewModel>();

            int totalPage = 0;
            int totalRecord = 0;

            if (!(string.IsNullOrEmpty(searchName) && listRoles.Count() == 0))
            {
                var result = UsersDto.Select(
                                x => (x.Email.Contains(searchName) ||
                                      x.LastName.Contains(searchName) ||
                                      x.FirstName.Contains(searchName)) &&
                                    !x.Email.Equals(User.Identity.Name), true);

                if (string.IsNullOrEmpty(searchName))
                {
                    result = UsersDto.Select(x => !x.Email.Equals(User.Identity.Name), true);
                }

                if (result.Status == Library.DataAccess.Responses.StatusCodes.OK)
                {
                    totalRecord = result.Items.Count();
                    if (totalRecord > 0)
                    {
                        totalRecord = 0;

                        List<UserSearchViewModel> listUsers = new List<UserSearchViewModel>();

                        foreach (var item in result.Items.OrderBy(x => x.LastName).ThenBy(x => x.FirstName).ThenBy(x => x.Email))
                        {
                            UserSearchViewModel model = new UserSearchViewModel();
                            model.Id = item.Id;
                            model.FullName = (item.LastName + ", " + item.FirstName + " " + item.MiddleName).Trim();
                            model.LastName = item.LastName;
                            model.FirstName = item.FirstName;
                            model.MiddleName = item.MiddleName;
                            model.Email = item.Email;

                            string roleDBName = string.Empty;
                            
                            foreach (var role in item.UserRoles)
                            {
                                var roleItem = RolesDto.Get(role.RoleId).Items.First();

                                roleDBName = roleItem.Name;

                                switch (roleItem.Name)
                                {
                                    case Constants._rolePASAdministrator:
                                        model.RoleName = Constants._valueRolePASAdministrator;
                                        break;
                                    case Constants._rolePASReadOnly:
                                        model.RoleName = Constants._valueRolePASReadOnly;
                                        break;
                                    case Constants._roleEditor:
                                        model.RoleName = Constants._valueRoleEditor;
                                        break;
                                    case Constants._roleReviewer:
                                        model.RoleName = Constants._valueRoleReviewer;
                                        break;
                                    case Constants._roleFacultyAdministrator:
                                        model.RoleName = Constants._valueRoleFacultyAdministrator;
                                        break;
                                    case Constants._roleFaculty:
                                        model.RoleName = Constants._valueRoleFaculty;
                                        break;
                                    case Constants._roleLearner:
                                        model.RoleName = Constants._valueRoleLearner;
                                        break;
                                    default:
                                        break;
                                }

                                break;
                            }

                            model.Created = item.DateCreated.ToString(Constants._formatDate3);
                            model.Enabled = item.IsEnabled;

                            bool bAdd = false;

                            if (User.IsInRole(Constants._rolePASAdministrator))
                            {
                                bAdd = true;
                            }
                            else if (User.IsInRole(Constants._roleEditor))
                            {
                                if (model.RoleName != Constants._valueRolePASAdministrator)
                                {
                                    bAdd = true;
                                }
                            }
                            else if (User.IsInRole(Constants._rolePASReadOnly))
                            {
                                if (model.RoleName != Constants._valueRolePASAdministrator &&
                                    model.RoleName != Constants._valueRoleEditor)
                                {
                                    bAdd = true;
                                }
                            }

                            if (bAdd)
                            {
                                if (listRoles.Count() > 0)
                                {
                                    if (listRoles.IndexOf(roleDBName) >= 0)
                                    {
                                        listUsers.Add(model);

                                        totalRecord++;

                                        if (totalRecord >= 100)
                                        {
                                            break;
                                        }
                                    }
                                }
                                else
                                {
                                    listUsers.Add(model);

                                    totalRecord++;

                                    if (totalRecord >= 100)
                                    {
                                        break;
                                    }
                                }
                            }
                        }

                        if (pageSize > 0)
                        {
                            totalPage = totalRecord / pageSize + ((totalRecord % pageSize) > 0 ? 1 : 0);

                            if (sortColumnName == "RoleName")
                            {
                                if (sortOrder == "desc")
                                    list = listUsers.OrderByDescending(x => x.RoleName).Skip(pageSize * (currentPage - 1)).Take(pageSize).ToList();
                                else
                                    list = listUsers.OrderBy(x => x.RoleName).Skip(pageSize * (currentPage - 1)).Take(pageSize).ToList();
                            }
                            else if (sortColumnName == "FullName")
                            {
                                if (sortOrder == "desc")
                                    list = listUsers.OrderByDescending(x => x.FullName).Skip(pageSize * (currentPage - 1)).Take(pageSize).ToList();
                                else
                                    list = listUsers.OrderBy(x => x.FullName).Skip(pageSize * (currentPage - 1)).Take(pageSize).ToList();
                            }
                            else if (sortColumnName == "Email")
                            {
                                if (sortOrder == "desc")
                                    list = listUsers.OrderByDescending(x => x.Email).Skip(pageSize * (currentPage - 1)).Take(pageSize).ToList();
                                else
                                    list = listUsers.OrderBy(x => x.Email).Skip(pageSize * (currentPage - 1)).Take(pageSize).ToList();
                            }
                            else if (sortColumnName == "Created")
                            {
                                if (sortOrder == "desc")
                                    list = listUsers.OrderByDescending(x => x.Created).Skip(pageSize * (currentPage - 1)).Take(pageSize).ToList();
                                else
                                    list = listUsers.OrderBy(x => x.Created).Skip(pageSize * (currentPage - 1)).Take(pageSize).ToList();
                            }
                            else if (sortColumnName == "Enabled")
                            {
                                if (sortOrder == "desc")
                                    list = listUsers.OrderByDescending(x => x.Enabled).Skip(pageSize * (currentPage - 1)).Take(pageSize).ToList();
                                else
                                    list = listUsers.OrderBy(x => x.Enabled).Skip(pageSize * (currentPage - 1)).Take(pageSize).ToList();
                            }
                        }
                        else
                        {
                            list = listUsers;
                        }
                    }
                }
            }
            else
            {
                var result = UsersDto.Select(x => !x.Email.Equals(User.Identity.Name), true);
                if (result.Status == Library.DataAccess.Responses.StatusCodes.OK)
                {
                    totalRecord = result.Items.Count();
                    if (totalRecord > 0)
                    {
                        totalRecord = 0;

                        List<UserSearchViewModel> listUsers = new List<UserSearchViewModel>();

                        foreach (var item in result.Items.OrderByDescending(x => x.DateCreated))
                        {
                            UserSearchViewModel model = new UserSearchViewModel();
                            model.Id = item.Id;
                            model.FullName = (item.LastName + ", " + item.FirstName + " " + item.MiddleName).Trim();
                            model.LastName = item.LastName;
                            model.FirstName = item.FirstName;
                            model.MiddleName = item.MiddleName;
                            model.Email = item.Email;

                            string roleDBName = string.Empty;

                            foreach (var role in item.UserRoles)
                            {
                                var roleItem = RolesDto.Get(role.RoleId).Items.First();

                                roleDBName = roleItem.Name;

                                switch (roleItem.Name)
                                {
                                    case Constants._rolePASAdministrator:
                                        model.RoleName = Constants._valueRolePASAdministrator;
                                        break;
                                    case Constants._rolePASReadOnly:
                                        model.RoleName = Constants._valueRolePASReadOnly;
                                        break;
                                    case Constants._roleEditor:
                                        model.RoleName = Constants._valueRoleEditor;
                                        break;
                                    case Constants._roleReviewer:
                                        model.RoleName = Constants._valueRoleReviewer;
                                        break;
                                    case Constants._roleFacultyAdministrator:
                                        model.RoleName = Constants._valueRoleFacultyAdministrator;
                                        break;
                                    case Constants._roleFaculty:
                                        model.RoleName = Constants._valueRoleFaculty;
                                        break;
                                    case Constants._roleLearner:
                                        model.RoleName = Constants._valueRoleLearner;
                                        break;
                                    default:
                                        break;
                                }

                                break;
                            }

                            model.Created = item.DateCreated.ToString(Constants._formatDate3);
                            model.Enabled = item.IsEnabled;

                            bool bAdd = false;

                            if (User.IsInRole(Constants._rolePASAdministrator))
                            {
                                bAdd = true;
                            }
                            else if (User.IsInRole(Constants._roleEditor))
                            {
                                if (model.RoleName != Constants._valueRolePASAdministrator)
                                {
                                    bAdd = true;
                                }
                            }
                            else if (User.IsInRole(Constants._rolePASReadOnly))
                            {
                                if (model.RoleName != Constants._valueRolePASAdministrator &&
                                    model.RoleName != Constants._valueRoleEditor)
                                {
                                    bAdd = true;
                                }
                            }

                            if (bAdd)
                            {
                                if (listRoles.Count() > 0)
                                {
                                    if (listRoles.IndexOf(roleDBName) >= 0)
                                    {
                                        listUsers.Add(model);

                                        totalRecord++;

                                        if (totalRecord >= 100)
                                        {
                                            break;
                                        }
                                    }
                                }
                                else
                                {
                                    listUsers.Add(model);

                                    totalRecord++;

                                    if (totalRecord >= 100)
                                    {
                                        break;
                                    }
                                }
                            }
                        }

                        if (pageSize > 0)
                        {
                            totalPage = totalRecord / pageSize + ((totalRecord % pageSize) > 0 ? 1 : 0);

                            if (sortColumnName == "RoleName")
                            {
                                if (sortOrder == "desc")
                                    list = listUsers.OrderByDescending(x => x.RoleName).Skip(pageSize * (currentPage - 1)).Take(pageSize).ToList();
                                else
                                    list = listUsers.OrderBy(x => x.RoleName).Skip(pageSize * (currentPage - 1)).Take(pageSize).ToList();
                            }
                            else if (sortColumnName == "FullName")
                            {
                                if (sortOrder == "desc")
                                    list = listUsers.OrderByDescending(x => x.FullName).Skip(pageSize * (currentPage - 1)).Take(pageSize).ToList();
                                else
                                    list = listUsers.OrderBy(x => x.FullName).Skip(pageSize * (currentPage - 1)).Take(pageSize).ToList();
                            }
                            else if (sortColumnName == "Email")
                            {
                                if (sortOrder == "desc")
                                    list = listUsers.OrderByDescending(x => x.Email).Skip(pageSize * (currentPage - 1)).Take(pageSize).ToList();
                                else
                                    list = listUsers.OrderBy(x => x.Email).Skip(pageSize * (currentPage - 1)).Take(pageSize).ToList();
                            }
                            else if (sortColumnName == "Created")
                            {
                                if (sortOrder == "desc")
                                    list = listUsers.OrderByDescending(x => x.Created).Skip(pageSize * (currentPage - 1)).Take(pageSize).ToList();
                                else
                                    list = listUsers.OrderBy(x => x.Created).Skip(pageSize * (currentPage - 1)).Take(pageSize).ToList();
                            }
                            else if (sortColumnName == "Enabled")
                            {
                                if (sortOrder == "desc")
                                    list = listUsers.OrderByDescending(x => x.Enabled).Skip(pageSize * (currentPage - 1)).Take(pageSize).ToList();
                                else
                                    list = listUsers.OrderBy(x => x.Enabled).Skip(pageSize * (currentPage - 1)).Take(pageSize).ToList();
                            }
                        }
                        else
                        {
                            list = listUsers;
                        }
                    }
                }
            }

            return Json(
                new
                {
                    list = list,
                    searchRoles = searchRoles,
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

            if (!string.IsNullOrEmpty(searchName))
            {
                List<SearchNameViewModel> listUsers1 = new List<SearchNameViewModel>();
                List<SearchNameViewModel> listUsers2 = new List<SearchNameViewModel>();
                List<SearchNameViewModel> listUsers3 = new List<SearchNameViewModel>();

                var result1 = UsersDto.Select(x => x.Email.StartsWith(searchName) && !x.Email.Equals(User.Identity.Name));
                if (result1.Status == Library.DataAccess.Responses.StatusCodes.OK)
                {
                    if (result1.Items.Count > 0)
                    {
                        foreach (var item in result1.Items.OrderBy(x => x.Email).Take(100))
                        {
                            SearchNameViewModel model = new SearchNameViewModel();
                            model.Name = item.Email.Trim();

                            listUsers1.Add(model);
                        }
                    }
                }

                var result2 = UsersDto.Select(x => x.LastName.StartsWith(searchName) && !x.Email.Equals(User.Identity.Name));
                if (result2.Status == Library.DataAccess.Responses.StatusCodes.OK)
                {
                    if (result2.Items.Count > 0)
                    {
                        foreach (var item in result2.Items.OrderBy(x => x.LastName).Take(100))
                        {
                            SearchNameViewModel model = new SearchNameViewModel();
                            model.Name = item.LastName.Trim();

                            listUsers2.Add(model);
                        }
                    }
                }

                var result3 = UsersDto.Select(x => x.FirstName.StartsWith(searchName) && !x.Email.Equals(User.Identity.Name));
                if (result3.Status == Library.DataAccess.Responses.StatusCodes.OK)
                {
                    if (result3.Items.Count > 0)
                    {
                        foreach (var item in result3.Items.OrderBy(x => x.FirstName).Take(100))
                        {
                            SearchNameViewModel model = new SearchNameViewModel();
                            model.Name = item.FirstName.Trim();

                            listUsers3.Add(model);
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
                            SearchNameViewModel model = new SearchNameViewModel();
                            model.Name = item.Email.Trim();

                            listUsers.Add(model);
                        }

                        list = listUsers;
                    }
                }
            }

            return Json(new { list = list });
        }

        public ActionResult ExportToExcel(string searchRoles, string searchClients, string searchName)
        {
            List<string> listRoles = new List<string>();

            if (!string.IsNullOrEmpty(searchRoles))
            {
                string[] tempList = searchRoles.Split(',');

                foreach (var item in tempList)
                {
                    listRoles.Add(item);
                }
            }

            List<UserSearchViewModel> listUsers = new List<UserSearchViewModel>();

            if (!(string.IsNullOrEmpty(searchName) && listRoles.Count() == 0))
            {
                var result = UsersDto.Select(x => (x.Email.Contains(searchName) ||
                                x.LastName.Contains(searchName) ||
                                x.FirstName.Contains(searchName)) &&
                                !x.Email.Equals(User.Identity.Name), true);

                if (string.IsNullOrEmpty(searchName))
                {
                    result = UsersDto.Select(x => !x.Email.Equals(User.Identity.Name));
                }

                if (result.Status == Library.DataAccess.Responses.StatusCodes.OK)
                {
                    if (result.Items.Count > 0)
                    {
                        foreach (var item in result.Items.OrderBy(x => x.LastName).ThenBy(x => x.FirstName).ThenBy(x => x.Email))
                        {
                            UserSearchViewModel model = new UserSearchViewModel();
                            model.Id = item.Id;
                            model.FullName = (item.LastName + ", " + item.FirstName + " " + item.MiddleName).Trim();
                            model.LastName = item.LastName;
                            model.FirstName = item.FirstName;
                            model.MiddleName = item.MiddleName;
                            model.Email = item.Email;

                            string roleDBName = string.Empty;

                            foreach (var role in item.UserRoles)
                            {
                                var roleItem = RolesDto.Get(role.RoleId).Items.First();

                                roleDBName = roleItem.Name;

                                switch (roleItem.Name)
                                {
                                    case Constants._rolePASAdministrator:
                                        model.RoleName = Constants._valueRolePASAdministrator;
                                        break;
                                    case Constants._rolePASReadOnly:
                                        model.RoleName = Constants._valueRolePASReadOnly;
                                        break;
                                    case Constants._roleEditor:
                                        model.RoleName = Constants._valueRoleEditor;
                                        break;
                                    case Constants._roleReviewer:
                                        model.RoleName = Constants._valueRoleReviewer;
                                        break;
                                    case Constants._roleFacultyAdministrator:
                                        model.RoleName = Constants._valueRoleFacultyAdministrator;
                                        break;
                                    case Constants._roleFaculty:
                                        model.RoleName = Constants._valueRoleFaculty;
                                        break;
                                    case Constants._roleLearner:
                                        model.RoleName = Constants._valueRoleLearner;
                                        break;
                                    default:
                                        break;
                                }

                                break;
                            }

                            model.Created = item.DateCreated.ToString(Constants._formatDate3);
                            model.Enabled = item.IsEnabled;

                            bool bAdd = false;

                            if (User.IsInRole(Constants._rolePASAdministrator))
                            {
                                bAdd = true;
                            }
                            else if (User.IsInRole(Constants._roleEditor))
                            {
                                if (model.RoleName != Constants._valueRolePASAdministrator)
                                {
                                    bAdd = true;
                                }
                            }
                            else if (User.IsInRole(Constants._rolePASReadOnly))
                            {
                                if (model.RoleName != Constants._valueRolePASAdministrator &&
                                    model.RoleName != Constants._valueRoleEditor)
                                {
                                    bAdd = true;
                                }
                            }

                            if (bAdd)
                            {
                                if (listRoles.Count() > 0)
                                {
                                    if (listRoles.IndexOf(roleDBName) >= 0)
                                        listUsers.Add(model);
                                }
                                else
                                {
                                    listUsers.Add(model);
                                }
                            }
                        }
                    }
                }
            }
            else
            {
                var result = UsersDto.Select(x => !x.Email.Equals(User.Identity.Name), true);

                if (string.IsNullOrEmpty(searchName))
                {
                    result = UsersDto.Select(x => !x.Email.Equals(User.Identity.Name));
                }

                if (result.Status == Library.DataAccess.Responses.StatusCodes.OK)
                {
                    if (result.Items.Count > 0)
                    {
                        foreach (var item in result.Items.OrderByDescending(x => x.DateCreated))
                        {
                            UserSearchViewModel model = new UserSearchViewModel();
                            model.Id = item.Id;
                            model.FullName = (item.LastName + ", " + item.FirstName + " " + item.MiddleName).Trim();
                            model.LastName = item.LastName;
                            model.FirstName = item.FirstName;
                            model.MiddleName = item.MiddleName;
                            model.Email = item.Email;

                            string roleDBName = string.Empty;

                            foreach (var role in item.UserRoles)
                            {
                                var roleItem = RolesDto.Get(role.RoleId).Items.First();

                                roleDBName = roleItem.Name;

                                switch (roleItem.Name)
                                {
                                    case Constants._rolePASAdministrator:
                                        model.RoleName = Constants._valueRolePASAdministrator;
                                        break;
                                    case Constants._rolePASReadOnly:
                                        model.RoleName = Constants._valueRolePASReadOnly;
                                        break;
                                    case Constants._roleEditor:
                                        model.RoleName = Constants._valueRoleEditor;
                                        break;
                                    case Constants._roleReviewer:
                                        model.RoleName = Constants._valueRoleReviewer;
                                        break;
                                    case Constants._roleFacultyAdministrator:
                                        model.RoleName = Constants._valueRoleFacultyAdministrator;
                                        break;
                                    case Constants._roleFaculty:
                                        model.RoleName = Constants._valueRoleFaculty;
                                        break;
                                    case Constants._roleLearner:
                                        model.RoleName = Constants._valueRoleLearner;
                                        break;
                                    default:
                                        break;
                                }

                                break;
                            }

                            model.Created = item.DateCreated.ToString(Constants._formatDate3);
                            model.Enabled = item.IsEnabled;

                            bool bAdd = false;

                            if (User.IsInRole(Constants._rolePASAdministrator))
                            {
                                bAdd = true;
                            }
                            else if (User.IsInRole(Constants._roleEditor))
                            {
                                if (model.RoleName != Constants._valueRolePASAdministrator)
                                {
                                    bAdd = true;
                                }
                            }
                            else if (User.IsInRole(Constants._rolePASReadOnly))
                            {
                                if (model.RoleName != Constants._valueRolePASAdministrator &&
                                    model.RoleName != Constants._valueRoleEditor)
                                {
                                    bAdd = true;
                                }
                            }

                            if (bAdd)
                            {
                                if (listRoles.Count() > 0)
                                {
                                    if (listRoles.IndexOf(roleDBName) >= 0)
                                        listUsers.Add(model);
                                }
                                else
                                {
                                    listUsers.Add(model);
                                }
                            }
                        }
                    }
                }
            }

            if (listUsers.Count() > 0)
            {
                // TODO : Write a new code that runs in ASP.NET Core
                //var grid = new GridView();
                //grid.DataSource = listUsers;
                //grid.DataBind();

                //Response.ClearContent();
                //Response.Buffer = true;
                //Response.AddHeader("content-disposition", "attachment; filename=Users.xls");
                //Response.ContentType = "application/ms-excel";

                //Response.Charset = string.Empty;
                //StringWriter sw = new StringWriter();
                //HtmlTextWriter htw = new HtmlTextWriter(sw);

                //grid.RenderControl(htw);

                //Response.Output.Write(sw.ToString());
                //Response.Flush();
                //Response.End();
            }

            return RedirectToAction("Index", "Users");
        }

        [Authorize(Roles = "pasadministrator,clientservicemanager")]
        public ActionResult Create()
        {
            UserViewModel model = new UserViewModel();
            model.Id = System.Guid.NewGuid().ToString();
            model.LastName = string.Empty;
            model.FirstName = string.Empty;
            model.MiddleName = string.Empty;
            model.Title = string.Empty;
            model.Email = string.Empty;
            model.RoleName = Constants._valueRoleLearner;
            model.Created = DateTime.Now;
            model.Enabled = true;

            return View(model);
        }

        [HttpPost]
        public async Task<ActionResult> Create(UserViewModel model)
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
                applicationUser.LastName = model.LastName.Trim();
                applicationUser.FirstName = model.FirstName.Trim();
                applicationUser.MiddleName = model.MiddleName.Trim();
                applicationUser.Title = model.Title.Trim();
                applicationUser.ScreenName = string.Empty;
                applicationUser.Email = model.Email.ToLower().Trim();
                applicationUser.UserName = applicationUser.Email;
                applicationUser.IsEnabled = model.Enabled;
                applicationUser.DateCreated = DateTime.Now;
                applicationUser.LastUpdated = applicationUser.DateCreated;

                applicationUser.EmailConfirmed = true;

                var result = await _userManager.CreateAsync(applicationUser, "Pass@word1");

                if (result.Succeeded)
                {
                    switch (model.RoleName)
                    {
                        case Constants._valueRolePASAdministrator:
                            await _userManager.AddToRoleAsync(applicationUser, Constants._rolePASAdministrator);
                            break;
                        case Constants._valueRolePASReadOnly:
                            await _userManager.AddToRoleAsync(applicationUser, Constants._rolePASReadOnly);
                            break;
                        case Constants._valueRoleEditor:
                            await _userManager.AddToRoleAsync(applicationUser, Constants._roleEditor);
                            break;
                        case Constants._valueRoleReviewer:
                            await _userManager.AddToRoleAsync(applicationUser, Constants._roleReviewer);
                            break;
                        case Constants._valueRoleFacultyAdministrator:
                            await _userManager.AddToRoleAsync(applicationUser, Constants._roleFacultyAdministrator);
                            break;
                        case Constants._valueRoleFaculty:
                            await _userManager.AddToRoleAsync(applicationUser, Constants._roleFaculty);
                            break;
                        case Constants._valueRoleLearner:
                            await _userManager.AddToRoleAsync(applicationUser, Constants._roleLearner);
                            break;
                        default:
                            break;
                    }

                    string message = "User with email '" + model.Email.ToString() + "' has been created.";
                    string loggedUserId = DBUtilities.GetUserIdByUserName(User.Identity.Name);

                    LogDto.Create(
                        Library.Common.Definitions.LogSource.WebsiteAdministration,
                        Library.Common.Definitions.LogType.User,
                        0,
                        model.Id,
                        message,
                        loggedUserId);

                    return RedirectToAction("Edit", "Users", new { Id = model.Id });
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
            if (User.IsInRole(Constants._rolePASReadOnly))
            {
                return RedirectToAction("Detail", "Users", new { Id = Id });
            }

            if (!string.IsNullOrEmpty(Id))
            {
                var result = UsersDto.Get(Id, true);
                if (result.Status == Library.DataAccess.Responses.StatusCodes.OK)
                {
                    if (result.Items.Count > 0)
                    {
                        var item = result.First();

                        UserViewModel model = new UserViewModel();
                        model.Id = item.Id;
                        model.LastName = item.LastName;
                        model.FirstName = item.FirstName;
                        model.MiddleName = item.MiddleName;
                        model.Title = item.Title;
                        model.Email = item.Email;
                        model.RoleName = string.Empty;
                        
                        foreach (var role in item.UserRoles)
                        {
                            var roleItem = RolesDto.Get(role.RoleId).Items.First();

                            if (roleItem.Name == Constants._rolePASAdministrator)
                            {
                                model.RoleName = Constants._valueRolePASAdministrator;
                            }
                            else if (roleItem.Name == Constants._rolePASReadOnly)
                            {
                                model.RoleName = Constants._valueRolePASReadOnly;
                            }
                            else if (roleItem.Name == Constants._roleEditor)
                            {
                                model.RoleName = Constants._valueRoleEditor;
                            }
                            else if (roleItem.Name == Constants._roleReviewer)
                            {
                                model.RoleName = Constants._valueRoleReviewer;
                            }
                            else if (roleItem.Name == Constants._roleFacultyAdministrator)
                            {
                                model.RoleName = Constants._valueRoleFacultyAdministrator;
                            }
                            else if (roleItem.Name == Constants._roleFaculty)
                            {
                                model.RoleName = Constants._valueRoleFaculty;
                            }
                            else if (roleItem.Name == Constants._roleLearner)
                            {
                                model.RoleName = Constants._valueRoleLearner;
                            }
                            else
                            {
                                model.RoleName = string.Empty;
                            }

                            break;
                        }

                        model.Created = item.DateCreated;
                        model.Enabled = item.IsEnabled;

                        if (User.IsInRole(Constants._rolePASAdministrator))
                        {
                            return View(model);
                        }
                        else if (User.IsInRole(Constants._roleEditor))
                        {
                            if (model.RoleName != Constants._valueRolePASAdministrator)
                            {
                                return View(model);
                            }
                        }
                    }
                }

                return RedirectToAction("Index", "Users");
            }
            else
            {
                return RedirectToAction("Index", "Users");
            }
        }

        [HttpPost]
        public ActionResult Edit(UserViewModel model)
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

                            user.LastName = model.LastName.Trim();
                            user.FirstName = model.FirstName.Trim();
                            user.MiddleName = model.MiddleName.Trim();
                            user.Title = model.Title.Trim();
                            user.Email = model.Email.ToLower().Trim();
                            user.UserName = model.Email.ToLower().Trim();
                            user.IsEnabled = model.Enabled;
                            user.LastUpdated = DateTime.Now;

                            user.Update();

                            var userRolesResult = UserRolesDto.Select(x => x.UserId.Equals(model.Id));
                            if (userRolesResult.Status == Library.DataAccess.Responses.StatusCodes.OK)
                            {
                                string roleId = string.Empty;
                                switch (model.RoleName)
                                {
                                    case Constants._valueRolePASAdministrator:
                                        roleId = DBUtilities.GetRoleIdByName(Constants._rolePASAdministrator);
                                        break;
                                    case Constants._valueRolePASReadOnly:
                                        roleId = DBUtilities.GetRoleIdByName(Constants._rolePASReadOnly);
                                        break;
                                    case Constants._valueRoleEditor:
                                        roleId = DBUtilities.GetRoleIdByName(Constants._roleEditor);
                                        break;
                                    case Constants._valueRoleReviewer:
                                        roleId = DBUtilities.GetRoleIdByName(Constants._roleReviewer);
                                        break;
                                    case Constants._valueRoleFacultyAdministrator:
                                        roleId = DBUtilities.GetRoleIdByName(Constants._roleFacultyAdministrator);
                                        break;
                                    case Constants._valueRoleFaculty:
                                        roleId = DBUtilities.GetRoleIdByName(Constants._roleFaculty);
                                        break;
                                    case Constants._valueRoleLearner:
                                        roleId = DBUtilities.GetRoleIdByName(Constants._roleLearner);
                                        break;
                                    default:
                                        break;
                                }

                                if (userRolesResult.Items.Count > 0)
                                {
                                    var userRole = userRolesResult.First();
                                    userRole.RoleId = roleId;

                                    userRole.Update();
                                }
                                else
                                {
                                    UserRolesDto item = new UserRolesDto();
                                    item.UserId = model.Id;
                                    item.RoleId = roleId;

                                    var createUserRoles = UserRolesDto.Create(item);
                                    if (createUserRoles.Status != Library.DataAccess.Responses.StatusCodes.OK)
                                        throw (createUserRoles.Ex);
                                }

                                string message =
                                    "User with email '" + model.Email.ToString() + "' has been edited.";

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

                TempData[Constants._valueMessage] = "User's profile successfully updated.";

                return View(model);
            }

            return View(model);
        }

        public ActionResult Detail(string Id)
        {
            if (!string.IsNullOrEmpty(Id))
            {
                var result = UsersDto.Get(Id, true);
                if (result.Status == StatusCodes.OK)
                {
                    if (result.Items.Count > 0)
                    {
                        var item = result.First();

                        UserViewModel model = new UserViewModel();
                        model.Id = item.Id;
                        model.LastName = item.LastName;
                        model.FirstName = item.FirstName;
                        model.MiddleName = item.MiddleName;
                        model.Title = item.Title;
                        model.Email = item.Email;
                        model.RoleName = string.Empty;

                        foreach (var role in item.UserRoles)
                        {
                            var roleItem = RolesDto.Get(role.RoleId).Items.First();

                            if (roleItem.Name == Constants._rolePASAdministrator)
                            {
                                model.RoleName = Constants._valueRolePASAdministrator;
                            }
                            else if (roleItem.Name == Constants._rolePASReadOnly)
                            {
                                model.RoleName = Constants._valueRolePASReadOnly;
                            }
                            else if (roleItem.Name == Constants._roleEditor)
                            {
                                model.RoleName = Constants._valueRoleEditor;
                            }
                            else if (roleItem.Name == Constants._roleReviewer)
                            {
                                model.RoleName = Constants._valueRoleReviewer;
                            }
                            else if (roleItem.Name == Constants._roleFacultyAdministrator)
                            {
                                model.RoleName = Constants._valueRoleFacultyAdministrator;
                            }
                            else if (roleItem.Name == Constants._roleFaculty)
                            {
                                model.RoleName = Constants._valueRoleFaculty;
                            }
                            else if (roleItem.Name == Constants._roleLearner)
                            {
                                model.RoleName = Constants._valueRoleLearner;
                            }
                            else
                            {
                                model.RoleName = string.Empty;
                            }

                            break;
                        }

                        model.Created = item.DateCreated;
                        model.Enabled = item.IsEnabled;

                        return View(model);
                    }
                }
            }

            return RedirectToAction("Index", "Users");
        }

        [HttpPost]
        public ActionResult Purge(UserViewModel model)
        {
            string loggedUserId = DBUtilities.GetUserIdByUserName(User.Identity.Name);

            Transaction.Begin();
            try
            {
                var result = UsersDto.DeleteWithoutLogs(model.Id);
                if (result.Status == StatusCodes.OK)
                {
                    string message = "User with email '" + model.Email.ToString() + "' has been purged.";

                    LogDto.Create(
                        Library.Common.Definitions.LogSource.WebsiteAdministration,
                        Library.Common.Definitions.LogType.User,
                        0,
                        model.Id,
                        message,
                        loggedUserId);

                    Transaction.Commit();

                    return Json(new { url = Url.Action("Index", "Users") });
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
        public async Task<ActionResult> ResetPasswordEmailAsync(UserViewModel model)
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

                string message = "User password with email '" + model.Email.ToString() + "' has been reset.";

                LogDto.Create(
                    Library.Common.Definitions.LogSource.WebsiteAdministration,
                    Library.Common.Definitions.LogType.User,
                    0,
                    model.Id,
                    message,
                    DBUtilities.GetUserIdByUserName(User.Identity.Name));

                return Json(new { url = Url.Action("Index", "Users") });
            }
            catch
            {
                ModelState.AddModelError(string.Empty, "An error occured while sending the email. Please try again.");

                return PartialView(model);
            }
        }
    }
}