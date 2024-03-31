using System.Web.Mvc;

namespace Booking_Hotel.Areas.Admin
{
    public class AdminAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "Admin";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "AdminLogin",
                "Admin/Login",
                new { controller = "Auth", action = "Login", id = UrlParameter.Optional }
            );
            context.MapRoute(
                "AdminLogout",
                "Admin/Logout",
                new { controller = "Auth", action = "Logout", id = UrlParameter.Optional }
            );
            context.MapRoute(
                "Admin_default",
                "Admin/{controller}/{action}/{id}",
                new { controller = "Home", action = "Index", id = UrlParameter.Optional },
                new[] { "Booking_Hotel.Areas.Admin.Controllers" }
            );
        } 
    }
}