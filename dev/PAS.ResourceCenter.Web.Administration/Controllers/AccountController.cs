using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using PAS.ResourceCenter.Library.DataAccess.DTO;
using PAS.ResourceCenter.Web.Administration.Common;
using PAS.ResourceCenter.Web.Administration.Models;
using PAS.ResourceCenter.Web.Administration.ViewModels.Account;
using System.Linq;
using System.Security.Principal;
using System.Threading.Tasks;

namespace PAS.ResourceCenter.Web.Administration.Controllers
{
    [Authorize(Roles = "pasadministrator,pasreadonlyuser,editor")]
    public class AccountController : Controller
    {
        private readonly ILogger _logger;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;

        public AccountController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, ILoggerFactory loggerFactory)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _logger = loggerFactory.CreateLogger<AccountController>();
        }
        
        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> Login(string returnUrl = null)
        {
            await EnsureLoggedOut();

            var viewModel = new LoginViewModel { ReturnUrl = returnUrl };

            return View(viewModel);
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel model, string returnUrl = null)
        {
            ViewData["ReturnUrl"] = returnUrl;

            if (!ModelState.IsValid)
                return View(model);

            var result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, false);

            if (result.Succeeded)
            {
                _logger.LogInformation(1, "User logged in.");
                return RedirectToLocal(returnUrl);
            }

            if (result.RequiresTwoFactor)
            {
                return RedirectToAction(nameof(SendCode), new
                {
                    ReturnUrl = returnUrl,
                    model.RememberMe
                });
            }

            if (result.IsLockedOut)
            {
                _logger.LogWarning(2, "User account locked out.");
                return View("Lock");
            }

            ModelState.AddModelError(string.Empty, "Invalid login attempt.");

            return View(model);
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> Register()
        {
            await EnsureLoggedOut();

            return View(new RegisterViewModel());
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var user = new ApplicationUser
            {
                UserName = model.Email,
                Email = model.Email
            };

            var result = await _userManager.CreateAsync(user, model.Password);

            if (result.Succeeded)
            {
                await _signInManager.SignInAsync(user, false);

                return RedirectToAction(nameof(HomeController.Index), "Home");
            }

            AddErrors(result);

            return View(model);
        }

        [AllowAnonymous]
        public async Task<IActionResult> Error()
        {
            await EnsureLoggedOut();

            return View();
        }

        [AllowAnonymous]
        public async Task<IActionResult> AccessDenied()
        {
            await EnsureLoggedOut();

            return View();
        }

        [AllowAnonymous]
        public async Task<IActionResult> EmailChanged()
        {
            await EnsureLoggedOut();

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> LogOff()
        {
            await _signInManager.SignOutAsync();

            HttpContext.User = new GenericPrincipal(new GenericIdentity(string.Empty), null);

            _logger.LogInformation(4, "User logged out.");

            return RedirectToLocal();
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> ConfirmEmail(string userId, string code)
        {
            if (userId == null || code == null)
            {
                return View("Error");
            }
            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
            {
                return View("Error");
            }
            var result = await _userManager.ConfirmEmailAsync(user, code);
            return View(result.Succeeded ? "ConfirmEmail" : "Error");
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> ForgotPassword()
        {
            await EnsureLoggedOut();

            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ForgotPassword(ForgotPasswordViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByNameAsync(model.Email);
                if (user == null || !await _userManager.IsEmailConfirmedAsync(user))
                {
                    ModelState.AddModelError(string.Empty, "Email does not exists.");

                    return View();
                }

                string code = await _userManager.GeneratePasswordResetTokenAsync(user);

                var callbackUrl =
                    Url.Action("ResetPassword", "Account", new { userId = user.Id, code = code }, protocol: Request.Scheme);

                if (Email.SendCredentials(
                        user.Email,
                        user.Email,
                        user.FirstName + " " + user.LastName,
                        callbackUrl) == Common.Email.Result.Error)
                {
                    return RedirectToAction("Error", "Account");
                }

                return RedirectToAction("ForgotPasswordConfirmation", "Account");
            }

            return View(model);
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> ForgotPasswordConfirmation()
        {
            await EnsureLoggedOut();

            return View();
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> ResetPassword(string code = null)
        {
            await EnsureLoggedOut();

            return code == null ? View("Error") : View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ResetPassword(ResetPasswordViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var user = await _userManager.FindByNameAsync(model.Email);
            if (user == null)
            {
                return RedirectToAction("ResetPasswordConfirmation", "Account");
            }

            var result = await _userManager.ResetPasswordAsync(user, model.Code, model.Password);
            if (result.Succeeded)
            {
                return RedirectToAction("ResetPasswordConfirmation", "Account");
            }

            AddErrors(result);

            return View();
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult ResetPasswordConfirmation()
        {
            return View();
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<ActionResult> SendCode(string returnUrl = null, bool rememberMe = false)
        {
            var user = await _signInManager.GetTwoFactorAuthenticationUserAsync();
            if (user == null)
            {
                return View("Error");
            }

            var userFactors = await _userManager.GetValidTwoFactorProvidersAsync(user);
            var factorOptions = userFactors.Select(purpose => new SelectListItem
            {
                Text = purpose,
                Value = purpose
            }).ToList();

            return View(new SendCodeViewModel
            {
                Providers = factorOptions,
                ReturnUrl = returnUrl,
                RememberMe = rememberMe
            });
        }

        private void AddErrors(IdentityResult result)
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(string.Empty, error.Description);
            }
        }

        private IActionResult RedirectToLocal(string returnUrl = null)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            return RedirectToAction(nameof(HomeController.Index), "Home");
        }

        private async Task EnsureLoggedOut()
        {
            if (User.Identity.IsAuthenticated)
                await LogOff();
        }
                
        public ActionResult FullName()
        {
            string fullName = string.Empty;

            if (HttpContext.Session.GetString(Constants._valueUserFullName) != null)
            {
                fullName = HttpContext.Session.GetString(Constants._valueUserFullName).ToString();
                HttpContext.Session.SetString(Constants._valueUserFullName, fullName);
            }
            else
            {
                var result = UsersDto.Select(x => x.UserName.Contains(User.Identity.Name));
                if (result.Status == Library.DataAccess.Responses.StatusCodes.OK)
                {
                    if (result.Items.Count > 0)
                    {
                        fullName = (result.First().FirstName.Trim() + " " + result.First().LastName.Trim()).Trim();
                        HttpContext.Session.SetString(Constants._valueUserFullName, fullName);
                    }
                }
            }

            return Json(new { fullName = fullName });
        }
    }
}