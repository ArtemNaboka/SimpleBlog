using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using AutoMapper;
using Blog.Business.Models.DTO;
using Blog.Business.Services.Interfaces;
using Blog.WebUI.ViewModels.CommentViewModels;

namespace Blog.WebUI.Controllers
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
            var commentsViewModel = await GetOrderedList();

            return View(commentsViewModel);
        }

        [HttpPost]
        public async Task<ActionResult> CreateComment(CommentViewModel comment)
        {
            if (!ModelState.IsValid)
            {
                var commentsViewModel = await GetOrderedList(comment);

                return View("Index", commentsViewModel);
            }

            comment.PublishDate = DateTime.UtcNow;
            await _commentsService.CreateAsync(Mapper.Map<CommentViewModel, CommentModel>(comment));
            return RedirectToAction(nameof(Index));
        }


        #region Helpers

        private async Task<CommentsListViewModel> GetOrderedList(CommentViewModel commentToAdd = null)
        {
            var orderedComments = (await _commentsService.GetCommentsAsync())
                .OrderByDescending(c => c.PublishDate)
                .ToList();

            var commentsViewModel = new CommentsListViewModel
            {
                Comments = Mapper.Map<IEnumerable<CommentModel>, IEnumerable<CommentViewModel>>(orderedComments),
                CommentsCount = orderedComments.Count,
                CommentToAdd = commentToAdd ?? new CommentViewModel()
            };

            return commentsViewModel;
        }

        #endregion
    }
}