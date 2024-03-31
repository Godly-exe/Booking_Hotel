using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Booking_Hotel.Models;
using Booking_Hotel.Models.data;

namespace Booking_Hotel.Areas.Admin.Controllers
{
    public class RoomController : BaseController
    {
        private BookingDataModels db = new BookingDataModels();

       
        public ActionResult Index()
        {
            var rooms = db.rooms.Include(b => b.types);
            return View(rooms.ToList());
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            room room = db.rooms.Find(id);
            if (room == null)
            {
                return HttpNotFound();
            }
            return View(room);
        }

        public ActionResult Create()
        {
            ViewBag.id_type = new SelectList(db.types, "id_type", "type1");
            return View();
        }

        //
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.ss
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Create([Bind(Include = "id_room,name,price,IsActive,id_type,IsHot,describe,bed,size,view_room")] room room, HttpPostedFileBase image)
        {
            if (image != null && image.ContentLength > 0)
            {
                string _fn = Path.GetFileName(image.FileName);
                string path = Path.Combine(Server.MapPath("/Content/images/room/"), _fn);
                if (System.IO.File.Exists(path))
                {
                    System.IO.File.Delete(path);
                    image.SaveAs(path);
                }
                else
                {
                    image.SaveAs(path);
                }
                room.image = "/Content/images/room/" + _fn;
            }
            if (ModelState.IsValid)
            {
                db.rooms.Add(room);
                db.SaveChanges();
                ThongBao("Thêm thành công!!!", "success");
                return RedirectToAction("Index");
            }
            
            ViewBag.id_type = new SelectList(db.types, "id_room", "type1", room.id_type);
            return View(room);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            room room = db.rooms.Find(id);
            if (room == null)
            {
                return HttpNotFound();
            }

            ViewBag.id_room = new SelectList(db.types, "id_type", "type1", room.id_type);
            return View(room);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Edit([Bind(Include = "id_room,name,price,IsActive,id_type,IsHot,describe,bed,size,view_room")] room room, HttpPostedFileBase image)
        {
            if (image != null && image.ContentLength > 0)
            {
                string _fn = Path.GetFileName(image.FileName);
                string path = Path.Combine(Server.MapPath("/Content/images/room/"), _fn);

                if (System.IO.File.Exists(path))
                {
                    System.IO.File.Delete(path);
                }

                image.SaveAs(path);
                room.image = "/Content/images/room/" + _fn;
            }
            else if (image == null)
            {
                room existingRoom = db.rooms.FirstOrDefault(i => i.id_room == room.id_room);
                room.image = existingRoom.image;
            }

            if (ModelState.IsValid)
            {
                db.Set<room>().AddOrUpdate(room);
                db.SaveChanges();
                ThongBao("Sửa thành công!!!", "success");
                return RedirectToAction("Index");
            }

            ViewBag.id_room = new SelectList(db.types, "id_type", "type1", room.id_room);
            return View(room);
        }
        public ActionResult DeleteConfirmed(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            room room = db.rooms.Find(id);
            if (room == null)
            {
                return HttpNotFound();
            }
            db.rooms.Remove(room);
            db.SaveChanges();
            ThongBao("Xoá thành công!!!", "success");
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        public ActionResult CommentRoom(int Blogcmt = 0)
        {
            var rooms = from i in db.rooms select i;
            ViewBag.Blogcmt = new SelectList(rooms, "id_room", "name");
            var cmt = db.Comment_Room.Include(m => m.room);
            if (Blogcmt != 0)
            {
                cmt = cmt.Where(i => i.id_room == Blogcmt);
            }
            return View(cmt.ToList());

        }

        public ActionResult DeleteComment(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Comment_Room room = db.Comment_Room.Find(id);
            if (room == null)
            {
                return HttpNotFound();
            } 
            db.Comment_Room.Remove(room);
            db.SaveChanges();
            ThongBao("Xoá thành công!!!", "success");
            return RedirectToAction("CommentRoom");
        }
    }
}