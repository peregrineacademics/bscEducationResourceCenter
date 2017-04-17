#region Using
 
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using PAS.ResourceCenter.Library.DataAccess.Models;
using PAS.ResourceCenter.Library.DataAccess.Repositories;
using PAS.ResourceCenter.Web.Administration.Models;
using PAS.ResourceCenter.Web.Administration.ViewModels.Account;
using System.Threading.Tasks;

#endregion

namespace PAS.ResourceCenter.Web.Administration.Controllers
{
    [Authorize]
    public class IssuesController : Controller
    {
        private readonly ISectorsRepository _repo;
        private readonly UserManager<ApplicationUser> _userManager;

        public IssuesController(UserManager<ApplicationUser> userManager, ISectorsRepository sectorsRepository)
        {
            _userManager = userManager;
            _repo = sectorsRepository;
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