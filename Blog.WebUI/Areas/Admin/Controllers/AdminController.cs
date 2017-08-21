using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using Blog.Business.Models.DTO;
using Blog.Business.Services.Interfaces;
using Blog.WebUI.ViewModels.AccountViewModels;
using Blog.WebUI.ViewModels.ArticleViewModels;
using Blog.WebUI.ViewModels.TagsViewModels;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;

namespace Blog.WebUI.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        private const int SymbolsForPreviewShow = 200;

        private readonly IArticlesService _articlesService;
        private readonly ITagsService _tagsService;
        private ISignInService _signInService;

        protected ISignInService SignInService
            => _signInService ?? (_signInService = HttpContext.GetOwinContext().Get<ISignInService>());


        public AdminController(IArticlesService articlesService, ITagsService tagsService)
        {
            _articlesService = articlesService;
            _tagsService = tagsService;
        }

        public async Task<ActionResult> Index()
        {
            var articleList =
                Mapper.Map<IEnumerable<ArticleModel>, IEnumerable<ArticleViewModel>>
                (await _articlesService.GetArticlesAsync())
                .ToList();

            foreach (var article in articleList)
            {
                if (article.Text.Length > SymbolsForPreviewShow)
                {
                    article.Text = article.Text.Substring(0, SymbolsForPreviewShow) + "...";
                }
            }

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
        public async Task<ActionResult> Login(LoginViewModel model)
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
            return RedirectToAction("Login");
        }

        [HttpGet]
        public async Task<ActionResult> CreateArticle()
        {
            var vm = new CreateArticleViewModel
            {
                Tags = (await _tagsService.GetTags())
                    .Select(t => new SelectListItem { Value =  t.Id.ToString(), Text = t.Name })
            };

            return View(vm);
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
                var articleModel = Mapper.Map<CreateArticleViewModel, ArticleModel>(article);
                await _articlesService.CreateAsync(articleModel, article.ChoosenTagsId);

                return RedirectToAction("Index");
            }

            return View(article);
        }


        public async Task<ActionResult> DeleteArticle(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var article = await _articlesService.GetArticleAsync(id.Value);

            if (article == null)
            {
                return HttpNotFound();
            }

            return View(Mapper.Map<ArticleModel, CreateArticleViewModel>(article));
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            await _articlesService.RemoveAsync(id);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var article = await _articlesService.GetArticleAsync(id.Value);

            if (article == null)
            {
                return HttpNotFound();
            }

            var articleVm = Mapper.Map<ArticleModel, ArticleViewModel>(article);
            articleVm.Tags = (await _articlesService.GetArticleTags(id.Value)).ToList();

            return View(articleVm);
        }

        [HttpGet]
        public ActionResult CreateTags()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> CreateTags(CreateTagsViewModel tagsViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(tagsViewModel);
            }

            var tags = tagsViewModel.AllTags.Trim().Split(new[] {','}, StringSplitOptions.RemoveEmptyEntries);
            foreach (var tag in tags)
            {
                await _tagsService.CreateAsync(new TagModel { Name = tag.Trim() });
            }

            return RedirectToAction("Index");
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