using Blog.Domain.Contexts;
using Blog.Domain.Contexts.Interfaces;
using Blog.Domain.Entities;
using Blog.Domain.Repositories;
using Blog.Domain.Repositories.Interfaces;
using Microsoft.AspNet.Identity;
using Ninject.Modules;
using Ninject.Web.Common;

namespace Blog.Business.Infrastructure.DI
{
    public class ServiceModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IDbContext>().To<BlogDbContext>().InRequestScope();
            Bind<IArticlesRepository>().To<SqlArticlesRepository>();
            Bind<ICommentsRepository>().To<SqlCommentsRepository>();
            Bind<IQuestionaryAnswersRepository>().To<SqlQuestionaryAnswersRepository>();
            Bind<ITagsRepository>().To<SqlTagsRepository>();
            Bind<IArticleTagsRepository>().To<SqlArticleTagsRepository>();
            Bind<IUserStore<User, int>>().To<SqlUserStore>();
            Bind<IRoleStore<Role, int>>().To<SqlRoleStore>();
        }
    }
}