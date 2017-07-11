#region Using

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PAS.ResourceCenter.Web.Administration.Models;

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

        public ActionResult Reviewers()
        {
            return View();
        }
    }
}