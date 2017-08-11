using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using AutoMapper;
using Blog.Business.Models.DTO;
using Blog.Business.Services.Interfaces;
using Blog.WebUI.ViewModels.ArticleViewModels;

namespace Blog.WebUI.Controllers
{
    public class ArticlesController : Controller
    {
        private const int SymbolsForPreviewShow = 200;

        private readonly IArticlesService _articlesService;

        public ArticlesController(IArticlesService articlesService)
        {
            _articlesService = articlesService;
        }

        [HttpGet]
        public async Task<ActionResult> Index()
        {
            var articlesViewModel = new ArticlesListViewModel
            {
                Articles = Mapper.Map<IEnumerable<ArticleModel>, IEnumerable<ArticleViewModel>>
                                                            (await _articlesService.GetArticlesAsync())
            };

            foreach (var article in articlesViewModel.Articles)
            {
                if (article.Text.Length > SymbolsForPreviewShow)
                {
                    article.Text = CutToLastWord(article.Text, SymbolsForPreviewShow);
                }
            }

            return View(articlesViewModel);
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

            return View(Mapper.Map<ArticleModel, ArticleViewModel>(article));
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(ArticleViewModel article)
        {
            if (ModelState.IsValid)
            {
                article.Name = RemoveExtraSpaces(article.Name);
                article.Text = RemoveExtraSpaces(article.Text);
                article.PublishDate = DateTime.UtcNow;
                await _articlesService.CreateAsync(Mapper.Map<ArticleViewModel, ArticleModel>(article));
                return RedirectToAction("Index");
            }

            return View(article);
        }

        public async Task<ActionResult> Edit(int? id)
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

            return View(Mapper.Map<ArticleModel, ArticleViewModel>(article));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(ArticleViewModel article)
        {
            if (ModelState.IsValid)
            {
                article.Name = RemoveExtraSpaces(article.Name);
                article.Text = RemoveExtraSpaces(article.Text);
                await _articlesService.UpdateAsync(Mapper.Map<ArticleViewModel, ArticleModel>(article));
                return RedirectToAction("Index");
            }

            return View(article);
        }

        public async Task<ActionResult> Delete(int? id)
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

            return View(Mapper.Map<ArticleModel, ArticleViewModel>(article));
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            await _articlesService.RemoveAsync(id);
            return RedirectToAction("Index");
        }

        #region Helpers

        private static string RemoveExtraSpaces(string text)
        {
            var arr = text.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            var resultCharArr = arr.SelectMany(str => str + ' ').ToArray();
            return new string(resultCharArr);
        }

        private static string CutToLastWord(string text, int substrLength)
        {
            var sb = new StringBuilder(text.Substring(0, substrLength));
            char[] separators = { ' ', '.', ',', ';', '!', '?' };

            for (var i = substrLength; i < text.Length && !separators.Contains(text[i]); i++)
            {
                sb.Append(text[i]);
            }

            sb.Append("...");
            return sb.ToString();
        }

        #endregion
    }
}