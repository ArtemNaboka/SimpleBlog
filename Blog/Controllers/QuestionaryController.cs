using System;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Blog.Infrastructure;
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

        public async Task<ActionResult> Index()
        {
            var qvm = new QuestionaryViewModel();

            if (HttpContext.Request.HttpMethod.Equals("POST", StringComparison.InvariantCultureIgnoreCase))
            {
                var fillingQuestionary = new FillingQuestionaryViewModel();
                if (!TryUpdateModel(fillingQuestionary))
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }

                TrimModelStrings(fillingQuestionary);
                var answers = SimpleMapper.ViewModelToQuestionary(fillingQuestionary);
                await _questionariesService.AddRangeAsync(answers);
                HttpContext.Response.Cookies.Add(new HttpCookie("UserHasFilled", "true"));
                return RedirectToAction("Index");
            }

            qvm.UserHasFilled = HttpContext.Request.Cookies.AllKeys.Contains("UserHasFilled") 
                && Convert.ToBoolean(HttpContext.Request.Cookies["UserHasFilled"]?.Value);

            qvm.QuestionaryResults = await _questionariesService.GetStatistics();

            return View(qvm);
        }

        #region Helpers

        private void TrimModelStrings(FillingQuestionaryViewModel model)
        {
            model.City = model.City.Trim();
            model.Wishes = model.Wishes.Trim();
        }

        #endregion
    }
}