using Microsoft.Ajax.Utilities;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Booking_Hotel.Models.data;
using System.Data.Entity;

namespace Booking_Hotel.Controllers
{
    public class RoomsController : Controller
    {
        BookingDataModels myObj = new BookingDataModels();

        public ActionResult Index(string Name, int Type = 0)
        {
            var typees = from i in myObj.types select i;
            ViewBag.Type = new SelectList(typees, "id_type", "type1");
            var names = myObj.rooms.Include(j => j.types);
            if (!string.IsNullOrEmpty(Name))
            {
                names = names.Where(i => i.name.Contains(Name));
            }
            if (Type != 0)
            {
                names = names.Where(j => j.id_type == Type);
            }
            return View(names.ToList());
        }
        public ActionResult RoomList_Home()
        {
            var items = myObj.rooms.Include(j => j.types);
            items = items.Where(i => (bool)i.IsActive).Where(j => (bool)j.IsHot);
            return PartialView("RoomList", items.ToList());
        }
        public ActionResult Details(int? idx)
        {
            if (idx == null) return HttpNotFound();
            else
            {
                var items = myObj.rooms.Find(idx);
                return View("Detail", items);
            }
        }
        /*Comment*/
        public ActionResult CommentRoom(int id)
        {
            var items = myObj.Comment_Room.Where(i => i.id_room == id).ToList();
            ViewBag.room = items.Count();
            return PartialView("CommentRoom", items);
        }
        [HttpPost]
        public ActionResult AddCommentRoom(int id, string name, string content)
        {
            Comment_Room newcmt_room = new Comment_Room();
            newcmt_room.id_room = id;
            newcmt_room.name_cmt = name;
            newcmt_room.cmt_room = content;
            newcmt_room.date_cmt = DateTime.Now;
            myObj.Comment_Room.Add(newcmt_room);
            myObj.SaveChanges();
            return Json(new { status = true });
        }
    }
}