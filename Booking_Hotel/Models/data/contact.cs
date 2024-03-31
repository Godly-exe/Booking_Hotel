namespace Booking_Hotel.Models.data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("contact")]
    public partial class contact
    {
        public int id { get; set; }

        [StringLength(50)]
        public string address { get; set; }

        [StringLength(15)]
        public string phone { get; set; }

        [StringLength(50)]
        public string email { get; set; }

        [StringLength(100)]
        public string facebook_link { get; set; }
    }
}
