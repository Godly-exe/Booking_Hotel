namespace Booking_Hotel.Models.data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("menu")]
    public partial class menu
    {
        public int id { get; set; }

        [StringLength(50)]
        public string title { get; set; }

        [StringLength(50)]
        public string link { get; set; }

        public bool? IsActive { get; set; }

        public int? menu_order { get; set; }
    }
}
