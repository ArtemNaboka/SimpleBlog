using System;
using System.Collections.Generic;
using System.Web.Mvc;
using Blog.Business.Services;
using Blog.Business.Services.Interfaces;
using Blog.Domain.Entities;
using Microsoft.AspNet.Identity;
using Ninject;

namespace Blog.WebUI.Util
{
    public class NinjectDependencyResolver : IDependencyResolver
    {
        private readonly IKernel _kernel;

        public NinjectDependencyResolver(IKernel kernelParam)
        {
            _kernel = kernelParam;
            AddBindings();

        }
        public object GetService(Type serviceType)
        {
            return _kernel.TryGet(serviceType);
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return _kernel.GetAll(serviceType);
        }

        private void AddBindings()
        {
            _kernel.Bind<IArticlesService>().To<ArticlesService>();
            _kernel.Bind<ICommentsService>().To<CommentsService>();
            _kernel.Bind<IQuestionaryAnswersService>().To<QuestionaryAnswersService>();
            _kernel.Bind<IVoteService>().To<VoteService>();
            _kernel.Bind<ITagsService>().To<TagsService>();
            _kernel.Bind<UserManager<User, int>>().ToSelf();
            _kernel.Bind<ISignInService>().To<SignInService>();
        }
    }
}