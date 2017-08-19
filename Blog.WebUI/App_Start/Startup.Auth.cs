using System.Web.Mvc;
using Blog.Business.Services;
using Blog.Business.Services.Interfaces;
using Blog.Domain.Contexts;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Owin;
using Blog.Domain.Entities;
using Blog.Domain.Repositories;

namespace Blog.WebUI
{
    public partial class Startup
    {
        public void ConfigureAuth(IAppBuilder app)
        {
            app.CreatePerOwinContext<ISignInService>(IdentityFactory.CreateSignInService);

            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
                LoginPath = new PathString("/Admin/Login"),
                Provider = new CookieAuthenticationProvider
                {
                    //OnValidateIdentity = SecurityStampValidator.OnValidateIdentity<UserManager<User, int>, User, int>(
                    //    validateInterval: TimeSpan.FromMinutes(30),
                    //    regenerateIdentityCallback: (manager, user) => user.GenerateUserIdentityAsync(manager))
                }
            });
        }
    }

    public static class IdentityFactory
    {
        public static ISignInService CreateSignInService(IdentityFactoryOptions<ISignInService> options, IOwinContext context)
        {
            var userManager = DependencyResolver.Current.GetService<UserManager<User, int>>();
            return new SignInService(userManager, context.Authentication);
        }
    }
}