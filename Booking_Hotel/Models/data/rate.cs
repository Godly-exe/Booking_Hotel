namespace Booking_Hotel.Models.data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("rate")]
    public partial class rate
    {
        public int id { get; set; }

        [StringLength(50)]
        public string name { get; set; }

        [StringLength(50)]
        public string job { get; set; }

        [StringLength(500)]
        public string rate_content { get; set; }

        public bool? IsActive { get; set; }

        [StringLength(100)]
        public string image { get; set; }
    }
}
