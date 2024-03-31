namespace Booking_Hotel.Models.data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("comment")]
    public partial class comment
    {
        [Key]
        public int id_cmt { get; set; }

        public int? id { get; set; }

        [StringLength(50)]
        public string name { get; set; }

        [StringLength(500)]
        public string comment_content { get; set; }

        [Column(TypeName = "date")]
        public DateTime? date { get; set; }

        public virtual blog blog { get; set; }
    }
}
