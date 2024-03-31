using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Booking_Hotel.Models.data;

namespace Booking_Hotel.Controllers
{
    public class HomeController : Controller
    {
        BookingDataModels myObj = new BookingDataModels();

        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Menu()
        {
            var item = myObj.menus.Where(i => (bool)i.IsActive).OrderBy(j => j.menu_order).ToList();
            return PartialView("Menu", item);
        }
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult Layout_Contact()
        {
            var items = myObj.contacts.Take(1);
            return PartialView("Layout_Contact", items);
        }
        public ActionResult DkDv()
        {
            return View("DK_DV");
        }
        public ActionResult faqs()
        {
            return View("FAQs");
        }
    }
}