using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(Blog.WebUI.Startup))]

namespace Blog.WebUI
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
