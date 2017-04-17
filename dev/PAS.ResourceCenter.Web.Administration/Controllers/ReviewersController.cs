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
    public class ReviewersController : Controller
    {
        private readonly ISectorsRepository _repo;
        private readonly UserManager<ApplicationUser> _userManager;

        public ReviewersController(UserManager<ApplicationUser> userManager, ISectorsRepository sectorsRepository)
        {
            _userManager = userManager;
            _repo = sectorsRepository;
        }

        public ActionResult Index()
        {
            return RedirectToAction("Reviewers", "Reviewers");
        }

        public ActionResult Reviewers()
        {
            return View();
        }
    }
}