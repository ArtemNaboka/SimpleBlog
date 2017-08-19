using System;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity.Owin;

namespace Blog.Business.Services.Interfaces
{
    public interface ISignInService : IDisposable
    {
        Task<SignInStatus> PasswordSignInAsync(string userName, string password, bool isPersistent, bool shouldLockout);
    }
}