namespace Booking_Hotel.Models.data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("room")]
    public partial class room
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public room()
        {
            Comment_Room = new HashSet<Comment_Room>();
            rentDetails = new HashSet<rentDetail>();
        }

        [Key]
        public int id_room { get; set; }

        [StringLength(50)]
        public string name { get; set; }

        [StringLength(100)]
        public string image { get; set; }

        public int? price { get; set; }

        public bool? IsActive { get; set; }

        public int? id_type { get; set; }

        public bool? IsHot { get; set; }

        public string describe { get; set; }

        [StringLength(10)]
        public string bed { get; set; }

        [StringLength(30)]
        public string size { get; set; }

        [StringLength(10)]
        public string view_room { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Comment_Room> Comment_Room { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<rentDetail> rentDetails { get; set; }

        public virtual type types { get; set; }
    }
}
