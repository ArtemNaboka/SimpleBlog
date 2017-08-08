using Blog.Domain.Contexts;
using Blog.Domain.Contexts.Interfaces;
using Blog.Domain.Repositories;
using Blog.Domain.Repositories.Interfaces;
using Ninject.Modules;

namespace Blog.Business.Infrastructure.DI
{
    public class ServiceModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IDbContext>().To<BlogDbContext>();
            Bind<IArticlesRepository>().To<SqlArticlesRepository>();
            Bind<ICommentsRepository>().To<SqlCommentsRepository>();
            Bind<IQuestionaryAnswersRepository>().To<SqlQuestionaryAnswersRepository>();
        }
    }
}