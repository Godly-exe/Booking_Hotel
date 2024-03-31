namespace Booking_Hotel.Models.data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("rent")]
    public partial class rent
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public rent()
        {
            bills = new HashSet<bill>();
            rentDetails = new HashSet<rentDetail>();
        }

        [Key]
        public int id_rent { get; set; }

        [StringLength(50)]
        public string note { get; set; }

        [StringLength(50)]
        public string name { get; set; }

        [StringLength(20)]
        public string phone { get; set; }

        [StringLength(50)]
        public string mail { get; set; }

        public DateTime? date { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<bill> bills { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<rentDetail> rentDetails { get; set; }
    }
}
