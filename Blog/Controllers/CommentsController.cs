using System.Web.Mvc;

namespace Blog.Controllers
{
    public class CommentsController : Controller
    {

        public CommentsController()
        {
            
        }

        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateComment()
        {
            return RedirectToAction(nameof(Index));
        }
    }
}