namespace Booking_Hotel.Models.data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("employee")]
    public partial class employee
    {
        [Key]
        public int id_employee { get; set; }

        [StringLength(20)]
        public string account { get; set; }

        [StringLength(30)]
        public string pass { get; set; }

        [StringLength(50)]
        public string name { get; set; }

        public bool? fulControl { get; set; }
    }
}
