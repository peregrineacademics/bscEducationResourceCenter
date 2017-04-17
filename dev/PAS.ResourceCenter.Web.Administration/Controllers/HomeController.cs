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
    public class HomeController : Controller
    {
        private readonly ISectorsRepository _repo;
        private readonly UserManager<ApplicationUser> _userManager;

        public HomeController(UserManager<ApplicationUser> userManager, ISectorsRepository sectorsRepository)
        {
            _userManager = userManager;
            _repo = sectorsRepository;
        }

        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult SampleInstructorGuideView()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SampleInstructorGuideView(int? Id)
        {
            return RedirectToAction("EditInstructorGuide", "Home");
        }

        public ActionResult SampleEdgeGuideView()
        {
            return View();
        }

        public ActionResult CreateGuide()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateGuide(int? Id)
        {
            return RedirectToAction("SampleInstructorGuideView", "Home");
        }

        public ActionResult EditInstructorGuide()
        {
            return View();
        }

        [HttpPost]
        public ActionResult EditInstructorGuide(int? Id)
        {
            return RedirectToAction("SampleInstructorGuideView", "Home");
        }

        public ActionResult EditQuizQuestions()
        {
            return View();
        }

        [HttpPost]
        public ActionResult EditQuizQuestions(int? Id)
        {
            return RedirectToAction("SampleInstructorGuideView", "Home");
        }

        public ActionResult EditEdgeGuide()
        {
            return View();
        }

        [HttpPost]
        public ActionResult EditEdgeGuide(int? Id)
        {
            return RedirectToAction("SampleEdgeGuideView", "Home");
        }

        public ActionResult ChangePassword()
        {
            return PartialView();
        }

        [HttpPost]
        public async Task<ActionResult> ChangePassword(ChangePasswordViewModel model)
        {
            if (ModelState.IsValid)
            {
                var applicationUser = await _userManager.FindByNameAsync(User.Identity.Name);

                if (applicationUser != null)
                {
                    if (await _userManager.CheckPasswordAsync(applicationUser, model.OldPassword))
                    {
                        var result = await _userManager.ChangePasswordAsync(applicationUser, model.OldPassword, model.NewPassword);

                        if (result.Succeeded)
                        {
                            return Json(new { url = Url.Action("Index", "Home") });
                        }
                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, "Old password is invalid.");
                    }
                }
            }

            return PartialView(model);
        }
    }
}