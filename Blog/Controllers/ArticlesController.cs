using System.Threading.Tasks;
using System.Net;
using System.Web.Mvc;
using Blog.Models;
using Blog.Services.Interfaces;

namespace Blog.Controllers
{
    public class ArticlesController : Controller
    {
        private readonly IArticlesService _articlesService;

        public ArticlesController(IArticlesService articlesService)
        {
            _articlesService = articlesService;
        }

        [HttpGet]
        public async Task<ActionResult> Index()
        {
            return View(await _articlesService.GetArticlesAsync());
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
        public async Task<ActionResult> Edit([Bind(Include = "Id,Name,PublishDate,Text")] Article article)
        {
            if (ModelState.IsValid)
            {
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
    }
}
