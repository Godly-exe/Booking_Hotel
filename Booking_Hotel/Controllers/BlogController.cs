using Microsoft.Ajax.Utilities;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Booking_Hotel.Models.data;

namespace Booking_Hotel.Controllers
{
    public class BlogController : Controller
    {
        // GET: Services
        BookingDataModels myObj = new BookingDataModels();

        public ActionResult Index(int? pageNumber)
        {
            if (pageNumber == null) pageNumber = 1;
            int pageSize = 3;
            var blog = myObj.blogs;
            return
            View(blog.Where(j => (bool)j.IsActive).ToList().OrderBy(i => i.date).ToPagedList((int)pageNumber,
            pageSize));
        }
        public ActionResult Blog_detail(int? idbv)
        {
            if (idbv == null)
            {
                return HttpNotFound();
            }
            else
            {
                var items = myObj.blogs.Find(idbv);
                return View("Details", items);
            }
        }
        public ActionResult Blog_other(int id)
        {
            var items = myObj.blogs.Where(i => (bool)i.IsActive).Where(j => j.id != id).ToList();
            return PartialView("Blog_other", items);
        }
        /*Comment*/
        public ActionResult Comment(int id)
        {
            var items = myObj.comments.Where(i => i.id == id).ToList();
            ViewBag.count = items.Count();
            return PartialView("Comment", items);
        }
        [HttpPost]
        public ActionResult AddComment(int id, string name, string comment)
        {
            comment newcmt = new comment();
            newcmt.id = id;
            newcmt.name = name;
            newcmt.comment_content = comment;
            newcmt.date = DateTime.Now;
            myObj.comments.Add(newcmt);
            myObj.SaveChanges();
            return Json(new { status = true });
        }
    }
}