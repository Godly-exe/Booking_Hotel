using Booking_Hotel.Models.data;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Booking_Hotel.Areas.Admin.Controllers
{
    public class MenusController : BaseController
    {
        private BookingDataModels db = new BookingDataModels();

        // GET: Admin/menus
        public ActionResult Index()
        {
            return View(db.menus.ToList());
        }

        // GET: Admin/menus/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            menu menu = db.menus.Find(id);
            if (menu == null)
            {
                return HttpNotFound();
            }
            return View(menu);
        }

        // GET: Admin/menus/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/menus/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,title,link,IsActive,menu_order")] menu menu)
        {
            if (ModelState.IsValid)
            {
                db.menus.Add(menu);
                db.SaveChanges();
                ThongBao("Thêm thành công!!!", "success");

                return RedirectToAction("Index");
            }

            return View(menu);
        }

        // GET: Admin/menus/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            menu menu = db.menus.Find(id);
            if (menu == null)
            {
                return HttpNotFound();
            }
            return View(menu);
        }

        // POST: Admin/menus/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,title,link,IsActive,menu_order")] menu menu)
        {
            if (ModelState.IsValid)
            {
                db.Entry(menu).State = EntityState.Modified;
                db.SaveChanges();
                ThongBao("Sửa thành công!!!", "success");

                return RedirectToAction("Index");
            }
            return View(menu);
        }

        // GET: Admin/menus/Delete/5

        // POST: Admin/menus/Delete/5
        public ActionResult DeleteConfirmed(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            menu menu = db.menus.Find(id);
            if (menu == null)
            {
                return HttpNotFound();
            }
            db.menus.Remove(menu);
            db.SaveChanges();
            ThongBao("Xoá thành công!!!", "success");
            return RedirectToAction("Index");
        }
        [HttpPost]
        public ActionResult changeView(int? id)
        {
            menu menu = db.menus.Find(id);
            menu.IsActive = !menu.IsActive;
            db.SaveChanges();
            return Json(new
            {
                status = menu.IsActive
            });
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