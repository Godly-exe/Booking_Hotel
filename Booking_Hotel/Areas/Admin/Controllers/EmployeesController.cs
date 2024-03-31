using Booking_Hotel.Models.data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Booking_Hotel.Areas.Admin.Controllers
{
    public class EmployeesController : BaseController
    {
        private BookingDataModels db = new BookingDataModels();

        // GET: Admin/employees
        public ActionResult Index()
        {
            return View(db.employees.ToList());
        }



        // GET: Admin/employees/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/employees/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_employee,account,pass,name,fulControl")] employee employee)
        {
            if (ModelState.IsValid)
            {
                db.employees.Add(employee);
                db.SaveChanges();
                ThongBao("Thêm thành công!!!", "success");
                return RedirectToAction("Index");
            }

            return View(employee);
        }



        // POST: Admin/employees/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.


        // GET: Admin/employees/Delete/5
        public ActionResult DeleteConfirmed(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            employee employee = db.employees.Find(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            db.employees.Remove(employee);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpPost]
        public ActionResult changeControl(int? id)
        {
            employee employee = db.employees.Find(id);
            if (employee.fulControl == true)
            {
                employee.fulControl = false;
            }
            else
            {
                employee.fulControl = true;
            }
            db.SaveChanges();
            return Json(new
            {
                status = employee.fulControl
            });

        }

        public ActionResult rename(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            employee nv = db.employees.Find(id);
            if (nv == null)
            {
                return HttpNotFound();
            }
            return View("Rename", nv);
        }
        [HttpPost]
        public ActionResult rename(int? id, string namenew)
        {
            try
            {
                employee nv = db.employees.Find(id);
                nv.name = namenew;
                db.SaveChanges();
                ThongBao("Đổi tên thành công :v", "success");
                return RedirectToAction("Index", "Home");
            }
            catch
            {
                return View("Error");
            }
        }
        public ActionResult AdminName()
        {
            var admin = Session["UserAdmin"] as Booking_Hotel.Models.data.employee;
            int id = admin.id_employee;
            var item = db.employees.Find(id);
            return PartialView("AdminName", item);
        }

        public ActionResult ChangePsw(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            employee nv = db.employees.Find(id);
            if (nv == null)
            {
                return HttpNotFound();
            }
            return View(nv);
        }
        [HttpPost]
        public ActionResult ChangePsw(int? id, string pswOld, string pswNew)
        {
            try
            {
                employee nv = db.employees.Find(id);
                if (nv.pass == pswOld)
                {
                    nv.pass = pswNew;
                    db.SaveChanges();
                    ThongBao("Đổi mật khẩu thành công :v", "success");
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ThongBao("Mật khẩu hiện tại chưa chính xác :v", "error");
                    return RedirectToAction("ChangePsw", new { id = id });
                }
            }
            catch
            {
                return View("Error");
            }

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