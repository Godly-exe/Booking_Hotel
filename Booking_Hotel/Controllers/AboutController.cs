using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Booking_Hotel.Models.data;

namespace Booking_Hotel.Controllers
{
    public class AboutController : Controller
    {
        // GET: About
        public ActionResult Index()
        {
            return View();
        }
        BookingDataModels myObj = new BookingDataModels();

        public ActionResult Rate()
        {
            var items = myObj.rates.Where(i => (bool)i.IsActive).ToList();
            return PartialView("Rate", items);
        }
    }
}