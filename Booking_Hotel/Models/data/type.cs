namespace Booking_Hotel.Models.data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("type")]
    public partial class type
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public type()
        {
            rooms = new HashSet<room>();
        }

        [Key]
        public int id_type { get; set; }

        [Column("type")]
        [Required]
        [StringLength(50)]
        public string type1 { get; set; }

        public int? price_day { get; set; }

        [StringLength(100)]
        public string image { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<room> rooms { get; set; }
    }
}
