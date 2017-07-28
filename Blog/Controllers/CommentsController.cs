using System;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using Blog.Models;
using Blog.Services.Interfaces;
using Blog.ViewModels;

namespace Blog.Controllers
{
    public class CommentsController : Controller
    {
        private readonly ICommentsService _commentsService;

        public CommentsController(ICommentsService commentsService)
        {
            _commentsService = commentsService;
        }

        [HttpGet]
        public async Task<ActionResult> Index()
        {
            var orderedComments = (await _commentsService.GetCommentsAsync())
                .OrderByDescending(c => c.PublishDate)
                .ToList();

            var commentsViewModel = new CommentsListViewModel
            {
                Comments = orderedComments,
                CommentsCount = orderedComments.Count
            };

            return View(commentsViewModel);
        }

        [HttpPost]
        public async Task<ActionResult> CreateComment(Comment comment)
        {
            if (!ModelState.IsValid)
            {
                return Content("Enter valid data!");
            }

            comment.PublishDate = DateTime.UtcNow;
            await _commentsService.CreateAsync(comment);
            return RedirectToAction(nameof(Index));
        }
    }
}