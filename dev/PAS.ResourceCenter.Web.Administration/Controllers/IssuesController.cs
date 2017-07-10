#region Using

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PAS.ResourceCenter.Web.Administration.Models;

#endregion

namespace PAS.ResourceCenter.Web.Administration.Controllers
{
    [Authorize]
    public class IssuesController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public IssuesController(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        public ActionResult Index()
        {
            return RedirectToAction("Issues", "Issues");
        }

        public ActionResult Issues()
        {
            return View();
        }

        public ActionResult CreateIssue()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateIssue(int? Id)
        {
            return RedirectToAction("EditIssue", "Issues");
        }

        public ActionResult EditIssue()
        {
            return View();
        }

        [HttpPost]
        public ActionResult EditIssue(int? Id)
        {
            return RedirectToAction("EditIssue", "Issues");
        }
    }
}