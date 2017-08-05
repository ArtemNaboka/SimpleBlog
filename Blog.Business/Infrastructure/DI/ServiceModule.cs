using Blog.Domain.Infrastructure.DI;
using Blog.Domain.Repositories;
using Blog.Domain.Repositories.Interfaces;
using Ninject.Modules;

namespace Blog.Business.Infrastructure.DI
{
    public class ServiceModule : NinjectModule
    {
        public override void Load()
        {
            var repositoryModule = new RepositoryModule();
            repositoryModule.Load();

            Bind<IArticlesRepository>().To<SqlArticlesRepository>();
        }
    }
}