using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using Blog.Business.Models.DTO;
using Blog.Business.Services.Interfaces;
using Blog.WebUI.ViewModels.AccountViewModels;
using Blog.WebUI.ViewModels.ArticleViewModels;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;

namespace Blog.WebUI.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        private readonly IArticlesService _articlesService;
        private ISignInService _signInService;

        protected ISignInService SignInService
            => _signInService ?? (_signInService = HttpContext.GetOwinContext().Get<ISignInService>());


        public AdminController(IArticlesService articlesService)
        {
            _articlesService = articlesService;
        }

        public async Task<ActionResult> Index()
        {
            var articleList =
                Mapper.Map<IEnumerable<ArticleModel>, IEnumerable<ArticleViewModel>>
                (await _articlesService.GetArticlesAsync())
                .ToList();

            return View(articleList);
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

        [HttpGet]
        public ActionResult CreateArticle()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> CreateArticle(CreateArticleViewModel article)
        {
            if (ModelState.IsValid)
            {
                article.Name = RemoveExtraSpaces(article.Name);
                article.Text = RemoveExtraSpaces(article.Text);
                article.PublishDate = DateTime.UtcNow;
                await _articlesService.CreateAsync(Mapper.Map<CreateArticleViewModel, ArticleModel>(article));
                return RedirectToAction("Index");
            }

            return View(article);
        }



        #region Helpers

        private IAuthenticationManager AuthenticationManager => HttpContext.GetOwinContext().Authentication;

        private static string RemoveExtraSpaces(string text)
        {
            var arr = text.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            var resultCharArr = arr.SelectMany(str => str + ' ').ToArray();
            return new string(resultCharArr);
        }

        #endregion
    }
}