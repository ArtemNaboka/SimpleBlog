using System;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Text;
using System.Web.Mvc;
using Blog.Models;
using Blog.Models.Entities;
using Blog.Services.Interfaces;
using Blog.ViewModels;

namespace Blog.Controllers
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
                Articles = await _articlesService.GetArticlesAsync()
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
            return View(article);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,Name,PublishDate,Text")] Article article)
        {
            if (ModelState.IsValid)
            {
                await _articlesService.CreateAsync(article);
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
            return View(article);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Name,Text")] Article article)
        {
            if (ModelState.IsValid)
            {
                article.PublishDate = DateTime.UtcNow;
                await _articlesService.UpdateAsync(article);
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
            return View(article);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            await _articlesService.RemoveAsync(id);
            return RedirectToAction("Index");
        }

        #region Helpers

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
