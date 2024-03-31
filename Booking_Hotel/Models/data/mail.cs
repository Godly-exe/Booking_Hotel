namespace Booking_Hotel.Models.data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("mail")]
    public partial class mail
    {
        [Key]
        public int ContactId { get; set; }

        [StringLength(150)]
        public string Name { get; set; }

        [StringLength(15)]
        public string Phone { get; set; }

        [StringLength(150)]
        public string Email { get; set; }

        public string Message { get; set; }

        public bool IsRead { get; set; }

        public DateTime? CreatedDate { get; set; }
    }
}
