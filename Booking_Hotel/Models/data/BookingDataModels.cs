using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace Booking_Hotel.Models.data
{
    public partial class BookingDataModels : DbContext
    {
        public BookingDataModels()
            : base("name=BookingDataModels")
        {
        }

        public virtual DbSet<bill> bills { get; set; }
        public virtual DbSet<blog> blogs { get; set; }
        public virtual DbSet<comment> comments { get; set; }
        public virtual DbSet<Comment_Room> Comment_Room { get; set; }
        public virtual DbSet<contact> contacts { get; set; }
        public virtual DbSet<employee> employees { get; set; }
        public virtual DbSet<mail> mails { get; set; }
        public virtual DbSet<menu> menus { get; set; }
        public virtual DbSet<rate> rates { get; set; }
        public virtual DbSet<rent> rents { get; set; }
        public virtual DbSet<rentDetail> rentDetails { get; set; }
        public virtual DbSet<room> rooms { get; set; }
        public virtual DbSet<type> types { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<rent>()
                .HasMany(e => e.bills)
                .WithRequired(e => e.rent)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<rent>()
                .HasMany(e => e.rentDetails)
                .WithRequired(e => e.rent)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<room>()
                .Property(e => e.bed)
                .IsFixedLength();

            modelBuilder.Entity<room>()
                .Property(e => e.size)
                .IsFixedLength();

            modelBuilder.Entity<room>()
                .Property(e => e.view_room)
                .IsFixedLength();
        }
    }
}
