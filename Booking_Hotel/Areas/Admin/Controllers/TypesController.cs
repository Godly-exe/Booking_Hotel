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
using Booking_Hotel.Models.data;

namespace Booking_Hotel.Areas.Admin.Controllers
{
    public class TypesController : BaseController
    {
        private BookingDataModels db = new BookingDataModels();

        // GET: Admin/types
        public ActionResult Index()
        {
            return View(db.types.ToList());
        }

        // GET: Admin/types/Details/5

        // GET: Admin/types/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/types/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_type,type1,price_day")] type type, HttpPostedFileBase image)
        {
            if (image != null && image.ContentLength > 0)
            {
                string _fn = Path.GetFileName(image.FileName);
                string path = Path.Combine(Server.MapPath("/Content/images/"), _fn);
                if (System.IO.File.Exists(path))
                {
                    System.IO.File.Delete(path);
                    image.SaveAs(path);
                }
                else
                {
                    image.SaveAs(path);
                }
                type.image = "/Content/images/" + _fn;
            }
            if (ModelState.IsValid)
            {
                db.types.Add(type);
                db.SaveChanges();
                ThongBao("Thêm thành công!!!", "success");
                return RedirectToAction("Index");
            }

            return View(type);
        }

        // GET: Admin/types/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            type type = db.types.Find(id);
            if (type == null)
            {
                return HttpNotFound();
            }
            return View(type);
        }

        // POST: Admin/types/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_type,type1,price_day")] type type, HttpPostedFileBase image)
        {
            if (image != null && image.ContentLength > 0)
            {
                string _fn = Path.GetFileName(image.FileName);
                string path = Path.Combine(Server.MapPath("/Content/images/"), _fn);
                if (System.IO.File.Exists(path))
                {
                    System.IO.File.Delete(path);
                    image.SaveAs(path);
                }
                else
                {
                    image.SaveAs(path);
                }
                type.image = "/Content/images/" + _fn;
            }
            else if (image == null)
            {
                type Rooms = db.types.Where(i => i.id_type == type.id_type).FirstOrDefault();
                type.image = Rooms.image;
            }
            if (ModelState.IsValid)
            {
                db.Set<type>().AddOrUpdate(type); db.SaveChanges();
                ThongBao("Sửa thành công!!!", "success");
                return RedirectToAction("Index");
            }
            ThongBao("Sửa thất bại!!!", "error");
            return View(type);
        }

        // POST: Admin/types/Delete/5

        public ActionResult DeleteConfirmed(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            type type = db.types.Find(id);
            if (type == null)
            {
                return HttpNotFound();
            }
            db.types.Remove(type);
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
    }
}