using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;

namespace Booking_Hotel.Areas.Admin.Controllers
{
    public class BaseController : Controller
    {
        // GET: Admin/Base
        public BaseController()
        {
            if (System.Web.HttpContext.Current.Session["UserAdmin"].Equals(""))
            {
                System.Web.HttpContext.Current.Response.Redirect("~/Admin/Login");
            }
        }

        protected void ThongBao(string message, string type)
        {
            TempData["ThongBao"] = message;
            if (type == "success")
            {
                TempData["Type"] = "alert-success";
            }
            else if (type == "warning")
            {
                TempData["Type"] = "alert-waring";
            }
            else if (type == "error")
            {
                TempData["Type"] = "alert-danger";
            }
        }
    }
}