using System;
using System.Web.Mvc;
using Blog.Services.Interfaces;
using Blog.ViewModels;

namespace Blog.Controllers
{
    public class QuestionaryController : Controller
    {
        private readonly IQuestionariesService _questionariesService;

        public QuestionaryController(IQuestionariesService questionariesService)
        {
            _questionariesService = questionariesService;
        }

        public ActionResult Index()
        {
            var qvm = new QuestionaryViewModel();

            if (HttpContext.Request.HttpMethod.Equals("POST", StringComparison.InvariantCultureIgnoreCase))
            {
                //HttpContext.Response.Cookies.Add(new HttpCookie());
            }

            qvm.UserHasFilled = Convert.ToBoolean(HttpContext.Response.Cookies["UserHasFilled"]?.Value);

            return View(qvm);
        }
    }
}