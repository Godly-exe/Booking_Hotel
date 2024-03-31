namespace Booking_Hotel.Models.data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class rentDetail
    {
        public int id { get; set; }

        public int id_rent { get; set; }

        public int? id_room { get; set; }

        public int? amount { get; set; }

        public virtual rent rent { get; set; }

        public virtual room room { get; set; }
        public bool? IsActive { get; internal set; }
    }
}
