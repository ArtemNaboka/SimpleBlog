using System.Web.Mvc;

namespace Blog.WebUI.Areas.Admin
{
    public class AdminAreaRegistration : AreaRegistration 
    {
        public override string AreaName => "Admin";

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "Admin_articles",
                "admin/articles",
                new { action = "Index", controller = "Admin" }
            );

            context.MapRoute(
                "Admin_login",
                "admin",
                new { action = "Login", controller = "Admin" }
            );

            context.MapRoute(
                "Admin_route",
                "admin/{action}/{id}",
                new { action = "Index", controller = "Admin", id = UrlParameter.Optional }
            );

            context.MapRoute(
                "Admin_default",
                "Admin/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}