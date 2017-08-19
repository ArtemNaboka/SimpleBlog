using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Blog.Business.Services.Interfaces;
using Blog.Domain.Entities;
using Blog.WebUI.ViewModels.AccountViewModels;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;

namespace Blog.WebUI.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        private ISignInService _signInService;

        protected ISignInService SignInService
            => _signInService ?? (_signInService = HttpContext.GetOwinContext().Get<ISignInService>());
        
        public ActionResult Index()
        {
            
            return View();
        }

        [HttpGet]
        [AllowAnonymous]        
        public ActionResult Login()
        {
            if (User.IsInRole("Admin"))
            {
                return RedirectToAction("Index");
            }

            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<ActionResult> Login(LoginViewModel model, string returnUrl)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var result = await SignInService.PasswordSignInAsync(model.UserName, model.Password, model.RememberMe, shouldLockout: false);
            switch (result)
            {
                case SignInStatus.Success:
                    return RedirectToAction("Index");
                default:
                    ModelState.AddModelError("", "Неудачная попытка входа.");
                    return View(model);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LogOff()
        {
            AuthenticationManager.SignOut(DefaultAuthenticationTypes.ApplicationCookie);
            return RedirectToAction("Index");
        }

        #region Helpers

        private IAuthenticationManager AuthenticationManager => HttpContext.GetOwinContext().Authentication;

        #endregion
    }
}