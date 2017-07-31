using System;
using System.Web;
using System.Web.Mvc;

namespace Blog.Controllers
{
    public class QuestionaryController : Controller
    {
        public ActionResult Index()
        {
            if (HttpContext.Request.HttpMethod.Equals("POST", StringComparison.InvariantCultureIgnoreCase))
            {
                //HttpContext.Response.Cookies.Add(new HttpCookie());
            }

            return View();
        }
    }
}