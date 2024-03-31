namespace Booking_Hotel.Models.data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Comment_Room
    {
        [Key]
        public int ID_Comment { get; set; }

        public int? id_room { get; set; }

        [StringLength(50)]
        public string name_cmt { get; set; }

        [StringLength(500)]
        public string cmt_room { get; set; }

        [Column(TypeName = "date")]
        public DateTime? date_cmt { get; set; }

        public virtual room room { get; set; }
    }
}
