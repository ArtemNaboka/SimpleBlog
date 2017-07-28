using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using Blog.Services.Interfaces;

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

            return View(orderedComments);
        }

        [HttpPost]
        public ActionResult CreateComment()
        {
            if (!ModelState.IsValid)
            {
                
            }
            return RedirectToAction(nameof(Index));
        }
    }
}