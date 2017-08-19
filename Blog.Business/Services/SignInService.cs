using Blog.Business.Services.Interfaces;
using Blog.Domain.Entities;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;

namespace Blog.Business.Services
{
    public class SignInService : SignInManager<User, int>, ISignInService
    {
        public SignInService(UserManager<User, int> userManager, IAuthenticationManager authenticationManager) 
            : base(userManager, authenticationManager)
        {

        }
    }
}