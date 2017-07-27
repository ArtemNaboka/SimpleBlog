using System;
using System.Collections.Generic;
using System.Web.Mvc;
using Blog.Repositories;
using Blog.Repositories.Interfaces;
using Blog.Services;
using Blog.Services.Interfaces;
using Ninject;

namespace Blog.Util
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
            _kernel.Bind<IArticlesRepository>().To<ArticlesRepository>();
            _kernel.Bind<ICommentsRepository>().To<CommentsRepository>();
            _kernel.Bind<IArticlesService>().To<ArticlesService>();
            _kernel.Bind<ICommentsService>().To<CommentsService>();
        }
    }
}