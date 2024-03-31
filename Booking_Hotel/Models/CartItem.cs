using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Web;

namespace Booking_Hotel.Models
{
    public class CartItem
    {
        public string image { get; set; }
        public int id_phong { get; set; }
        public string name { get; set; }
        public int SoLuong { get; set; }

        public bool? IsActive { get; set; }

        public DateTime DataIn { get; set; }
        [Required(ErrorMessage = "The Date field is required.")]
        [DataType(DataType.Date, ErrorMessage = "The Date field must be a valid date.")]
        public DateTime DataOut { get; set; }
        [Required(ErrorMessage = "The Date field is required.")]
        [DataType(DataType.Date, ErrorMessage = "The Date field must be a valid date.")]
        public int price { get; set; }


        public int TongNgay
        {
            get
            {
                TimeSpan duration = DataOut - DataIn;
                return duration.Days;
            }
        }
        public int TongTien
        {
            get
            {
                return SoLuong * price ;
            }
        }
    }
}