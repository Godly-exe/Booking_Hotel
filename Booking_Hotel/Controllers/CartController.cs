using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Web;
using System.Web.Mvc;
using Booking_Hotel.Models;
using Booking_Hotel.Models.data;

namespace Booking_Hotel.Controllers
{
    public class CartController : Controller
    {
        // GET: Cart
        BookingDataModels myObj = new BookingDataModels();

        public ActionResult Index()
        {
            List<CartItem> giohang = Session["giohang"] as List<CartItem>;
            return View(giohang);
        }

        public ActionResult AddCart(int id)
        {
            if (Session["giohang"] == null)
            {
                Session["giohang"] = new List<CartItem>();
            }

            List<CartItem> giohang = Session["giohang"] as List<CartItem>;

            if (giohang.FirstOrDefault(m => m.id_phong == id) == null) // ko co sp nay trong gio hang
            {
                room sp = myObj.rooms.Find(id);

                CartItem newItem = new CartItem()
                {
                    id_phong = id,
                    name = sp.name,
                    SoLuong = 1,
                    image = sp.image,
                    price = (int)sp.price,
                  
                };  // Tạo ra 1 CartItem mới

                giohang.Add(newItem);  // Thêm CartItem vào giỏ 
            }
            else
            {
                //Nếu đã có sẽ thông báo không có sản phẩm 
                TempData["Notification"] = "Sản phẩm đã có trong giỏ hàng!"; // Đặt thông báo trong TempData

            }
            return Redirect(url: Request.UrlReferrer.ToString());
            // Action này sẽ chuyển hướng về trang chi tiết sp khi khách hàng đặt vào giỏ thành công. Bạn có thể chuyển về chính trang khách hàng vừa đứng bằng lệnh return Redirect(Request.UrlReferrer.ToString()); nếu muốn.
     
        }
        public RedirectToRouteResult SuaSoLuong(int SanPhamID, int soluongmoi)
        {
            // tìm card item muon sua
            List<CartItem> giohang = Session["giohang"] as List<CartItem>;
            CartItem itemSua = giohang.FirstOrDefault(m => m.id_phong == SanPhamID);
            if (itemSua != null)
            {
                itemSua.SoLuong = soluongmoi;
            }
            return RedirectToAction("Index");

        }
        public RedirectToRouteResult SuaNgay(int SanPhamID, int songaymoi)
        {
            // tìm carditem muon sua
            List<CartItem> giohang = Session["giohang"] as List<CartItem>;
            CartItem itemSuaDate = giohang.FirstOrDefault(m => m.id_phong == SanPhamID);
            
            return RedirectToAction("Index");

        }
        public RedirectToRouteResult XoaKhoiGio(int SanPhamID)
        {
            List<CartItem> giohang = Session["giohang"] as List<CartItem>;
            CartItem itemXoa = giohang.FirstOrDefault(m => m.id_phong == SanPhamID);
            if (itemXoa != null)
            {
                giohang.Remove(itemXoa);
            }
            return RedirectToAction("Index");
        }

        public ActionResult Checkout()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Checkout(FormCollection frm)
        {
            //try
            //{
            List<CartItem> carts = (List<CartItem>)Session["giohang"];
            rent rent = new rent()
            {
                name = frm["inputUsername"],
                phone = frm["inputPhone"],
                mail = frm["inputEmail"],
                note = frm["inputNote"],
                
                date = DateTime.Now,
            };
            myObj.rents.Add(rent);
            myObj.SaveChanges();

            foreach (CartItem item in carts)
            {
                rentDetail rentDetail = new rentDetail()
                {
                    id_rent = rent.id_rent,
                    id_room = item.id_phong,
                    amount = item.SoLuong,
                    IsActive = item.IsActive,

                };
                myObj.rentDetails.Add(rentDetail);
                myObj.SaveChanges();
            }

            Session.Remove("giohang");
            return View("RentSuccess");
            //} catch
            //{
            //    return View("Error");
            //}
        }
    }
}