using System;
using Blog.Domain.Contexts;
using Blog.Domain.Contexts.Interfaces;
using Ninject.Modules;

namespace Blog.Domain.Infrastructure.DI
{
    public class RepositoryModule : NinjectModule
    {
        public override void Load()
        {
            //Bind<IDbContext>().To<BlogDbContext>();
        }
    }
}