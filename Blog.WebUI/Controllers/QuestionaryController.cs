using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using Blog.Business.Models.DTO;
using Blog.Business.Models.QuestionaryAnswerModels;
using Blog.Business.Services.Interfaces;
using Blog.WebUI.ViewModels.QuestionariesViewModels;

namespace Blog.WebUI.Controllers
{
    public class QuestionaryController : Controller
    {
        private readonly IQuestionaryAnswersService _questionariesService;

        public QuestionaryController(IQuestionaryAnswersService questionariesService)
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
                var questionary = Mapper.Map<FillingQuestionaryViewModel, QuestionaryModel>(fillingQuestionary);
                await _questionariesService.CreateQuestionaryAsync(questionary);
                HttpContext.Response.Cookies.Add(new HttpCookie("UserHasFilled", "true"));
                return RedirectToAction("Index");
            }

            qvm.UserHasFilled = HttpContext.Request.Cookies.AllKeys.Contains("UserHasFilled")
                && Convert.ToBoolean(HttpContext.Request.Cookies["UserHasFilled"]?.Value);

            if (qvm.UserHasFilled)
            {
                qvm.QuestionaryResults = Mapper.Map<QuestionaryResults, QuestionaryResultsViewModel>
                                        (await _questionariesService.GetStatistics());
            }            

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