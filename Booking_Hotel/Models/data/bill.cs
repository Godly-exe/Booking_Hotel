namespace Booking_Hotel.Models.data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("bill")]
    public partial class bill
    {
        [Key]
        public int id_bill { get; set; }

        public int id_rent { get; set; }

        public int? money_day { get; set; }

        public DateTime? date_start { get; set; }

        public DateTime? date_end { get; set; }

        [StringLength(50)]
        public string status { get; set; }

        public virtual rent rent { get; set; }
    }
}
