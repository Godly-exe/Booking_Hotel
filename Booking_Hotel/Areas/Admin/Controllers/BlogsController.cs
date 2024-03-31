using Booking_Hotel.Models.data;
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

namespace Booking_Hotel.Areas.Admin.Controllers
{
    public class BlogsController : BaseController
    {
      
            private BookingDataModels db = new BookingDataModels();

            // GET: Admin/blogs
            public ActionResult Index()
            {
                return View(db.blogs.ToList());
            }
            [HttpPost]
            public ActionResult changeView(int? id)
            {
                blog blog = db.blogs.Find(id);
                if (blog.IsActive == true)
                {
                    blog.IsActive = false;
                }
                else
                {
                    blog.IsActive = true;
                }
                db.SaveChanges();
                return Json(new
                {
                    status = blog.IsActive
                });
            }
            // GET: Admin/blogs/Create
            public ActionResult Create()
            {
                return View();
            }

            // POST: Admin/blogs/Create
            // To protect from overposting attacks, enable the specific properties you want to bind to, for 
            // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
            [HttpPost]
            [ValidateAntiForgeryToken]
            [ValidateInput(false)]
            public ActionResult Create([Bind(Include = "id,title,head,blog_content,IsActive")] blog blog, HttpPostedFileBase image)
            {
                if (image != null && image.ContentLength > 0)
                {
                    string _fn = Path.GetFileName(image.FileName);
                    string path = Path.Combine(Server.MapPath("/Content/images/blog/"), _fn);
                    if (System.IO.File.Exists(path))
                    {
                        System.IO.File.Delete(path);
                        image.SaveAs(path);
                    }
                    else
                    {
                        image.SaveAs(path);
                    }
                    blog.image = "/Content/images/blog/" + _fn;
                }
                blog.date = DateTime.Now.ToLocalTime();
                if (ModelState.IsValid)
                {
                    db.blogs.Add(blog);
                    db.SaveChanges();
                    ThongBao("Thêm thành công!!!", "success");
                    return RedirectToAction("Index");
                }

                return View(blog);
            }

            // GET: Admin/blogs/Edit/5
            public ActionResult Edit(int? id)
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                blog blog = db.blogs.Find(id);
                if (blog == null)
                {
                    return HttpNotFound();
                }
                return View(blog);
            }

            // POST: Admin/blogs/Edit/5
            // To protect from overposting attacks, enable the specific properties you want to bind to, for 
            // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
            [HttpPost]
            [ValidateAntiForgeryToken]
            [ValidateInput(false)]

            public ActionResult Edit([Bind(Include = "id,title,head,blog_content,IsActive,date")] blog blog, HttpPostedFileBase image)
            {
                if (image != null && image.ContentLength > 0)
                {
                    string _fn = Path.GetFileName(image.FileName);
                    string path = Path.Combine(Server.MapPath("/Content/images/blog/"), _fn);
                    if (System.IO.File.Exists(path))
                    {
                        System.IO.File.Delete(path);
                        image.SaveAs(path);
                    }
                    else
                    {
                        image.SaveAs(path);
                    }
                    blog.image = "/Content/images/blog/" + _fn;
                }
                else if (image == null)
                {
                    blog rooms = db.blogs.Where(i => i.id == blog.id).FirstOrDefault();
                    blog.image = rooms.image;
                }
                if (ModelState.IsValid)
                {
                    db.Set<blog>().AddOrUpdate(blog);
                    db.SaveChanges();
                    ThongBao("Sửa thành công!!!", "success");
                    return RedirectToAction("Index");
                }
                return View(blog);
            }

            public ActionResult DeleteConfirmed(int? id)
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                blog blog = db.blogs.Find(id);
                if (blog == null)
                {
                    return HttpNotFound();
                }
                db.blogs.Remove(blog);
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

            public ActionResult Comment(int Blogg = 0)
            {
                var blogs = from i in db.blogs select i;
                ViewBag.Blogg = new SelectList(blogs, "id", "title");
                var cmt = db.comments.Include(m => m.blog);
                if (Blogg != 0)
                {
                    cmt = cmt.Where(i => i.id == Blogg);
                }
                return View(cmt.ToList());

            }

            public ActionResult DeleteComment(int? id)
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                comment blog = db.comments.Find(id);
                if (blog == null)
                {
                    return HttpNotFound();
                }
                db.comments.Remove(blog);
                db.SaveChanges();
                ThongBao("Xoá thành công!!!", "success");
                return RedirectToAction("Comment");
            }
        }
    }
