using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace K_Hotels_API.Models
{
    public partial class K_HotelsContext : DbContext
    {
        public K_HotelsContext()
        {
        }

        public K_HotelsContext(DbContextOptions<K_HotelsContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Booking> Bookings { get; set; } = null!;
        public virtual DbSet<Hotel> Hotels { get; set; } = null!;
        public virtual DbSet<Resident> Residents { get; set; } = null!;
        public virtual DbSet<ResidentBooking> ResidentBookings { get; set; } = null!;
        public virtual DbSet<Room> Rooms { get; set; } = null!;
        public virtual DbSet<RoomType> RoomTypes { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("server=.\\SQLExpress;Database=K_Hotels;Trusted_Connection=true");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Booking>(entity =>
            {
                entity.ToTable("booking");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.EndDate)
                    .HasColumnType("date")
                    .HasColumnName("end_date");

                entity.Property(e => e.Location).HasColumnName("location");

                entity.Property(e => e.Price).HasColumnName("price");

                entity.Property(e => e.RoomType).HasColumnName("room_type");

                entity.Property(e => e.StartDate)
                    .HasColumnType("date")
                    .HasColumnName("start_date");

                entity.HasOne(d => d.LocationNavigation)
                    .WithMany(p => p.Bookings)
                    .HasForeignKey(d => d.Location)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__booking__locatio__2D27B809");

                entity.HasOne(d => d.RoomTypeNavigation)
                    .WithMany(p => p.Bookings)
                    .HasForeignKey(d => d.RoomType)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__booking__room_ty__2E1BDC42");
            });

            modelBuilder.Entity<Hotel>(entity =>
            {
                entity.ToTable("hotel");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.BasePrice).HasColumnName("base_price");

                entity.Property(e => e.Location).HasColumnName("location");
            });

            modelBuilder.Entity<Resident>(entity =>
            {
                entity.ToTable("resident");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .HasColumnName("email");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .HasColumnName("name");

                entity.Property(e => e.NationalId).HasColumnName("national_id");
            });

            modelBuilder.Entity<ResidentBooking>(entity =>
            {
                entity.ToTable("resident_booking");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Booking).HasColumnName("booking");

                entity.Property(e => e.Resident).HasColumnName("resident");

                entity.HasOne(d => d.BookingNavigation)
                    .WithMany(p => p.ResidentBookings)
                    .HasForeignKey(d => d.Booking)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__resident___booki__33D4B598");

                entity.HasOne(d => d.ResidentNavigation)
                    .WithMany(p => p.ResidentBookings)
                    .HasForeignKey(d => d.Resident)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__resident___resid__32E0915F");
            });

            modelBuilder.Entity<Room>(entity =>
            {
                entity.ToTable("room");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Empty).HasColumnName("empty");

                entity.Property(e => e.Location).HasColumnName("location");

                entity.Property(e => e.RoomType).HasColumnName("room_type");

                entity.HasOne(d => d.LocationNavigation)
                    .WithMany(p => p.Rooms)
                    .HasForeignKey(d => d.Location)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__room__location__286302EC");

                entity.HasOne(d => d.RoomTypeNavigation)
                    .WithMany(p => p.Rooms)
                    .HasForeignKey(d => d.RoomType)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__room__room_type__29572725");
            });

            modelBuilder.Entity<RoomType>(entity =>
            {
                entity.ToTable("room_type");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Description).HasColumnName("description");

                entity.Property(e => e.Price).HasColumnName("price");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
