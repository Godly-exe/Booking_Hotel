using Booking_Hotel.Models.data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Booking_Hotel.Areas.Admin.Controllers
{
    public class AuthController : Controller
    {
        // GET: Admin/Auth
        public employee acc;
        BookingDataModels myObj = new BookingDataModels();
        // GET: Admin/Auth
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(FormCollection collection)
        {
            var tendn = collection["account"];
            var mk = collection["pass"];
            if (string.IsNullOrEmpty(tendn))
            {
                ViewData["loi1"] = "Vui lòng nhập tên đăng nhập !!!";
            }
            else if (string.IsNullOrEmpty(mk))
            {
                ViewData["loi2"] = "Nhập mật khẩu !!!";
            }
            else
            {
                acc = myObj.employees.SingleOrDefault(i => i.account == tendn && i.pass == mk);
                if (acc != null)
                {
                    Session["UserAdmin"] = acc;
                    return RedirectToAction("Index", "Home");
                }
                else
                    ViewBag.ThongBao = "Tài khoản hoặc mật khẩu không chính xác!!!";
            }
            return View();
        }
        public ActionResult Logout()
        {
            Session["UserAdmin"] = "";
            return Redirect("~/Admin/Login");
        }
    }
}