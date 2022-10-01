using System;
using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Configuration;

namespace Infosys.TravelAway.DAL.Models
{
    public partial class TravelAwayDBContext : DbContext
    {
        public TravelAwayDBContext()
        {
        }

        public TravelAwayDBContext(DbContextOptions<TravelAwayDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Accomodation> Accomodation { get; set; }
        public virtual DbSet<BookPackage> BookPackage { get; set; }
        public virtual DbSet<Customer> Customer { get; set; }
        public virtual DbSet<CustomerCare> CustomerCare { get; set; }
        public virtual DbSet<Employee> Employee { get; set; }
        public virtual DbSet<Hotel> Hotel { get; set; }
        public virtual DbSet<Package> Package { get; set; }
        public virtual DbSet<PackageCategory> PackageCategory { get; set; }
        public virtual DbSet<PackageDetails> PackageDetails { get; set; }
        public virtual DbSet<Payment> Payment { get; set; }
        public virtual DbSet<Rating> Rating { get; set; }
        public virtual DbSet<Roles> Roles { get; set; }
        public virtual DbSet<Vehicle> Vehicle { get; set; }
        public virtual DbSet<VehicleBooked> VehicleBooked { get; set; }
        public virtual DbSet<ViewBookings> ViewBookings { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //            if (!optionsBuilder.IsConfigured)
            //            {
            //#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
            //                optionsBuilder.UseSqlServer("Data Source =(localdb)\\MSSQLLocalDB;Initial Catalog=TravelAwayDB;Integrated Security=true");
            //            }
            var builder = new ConfigurationBuilder()
                                  .SetBasePath(Directory.GetCurrentDirectory())
                                  .AddJsonFile("appsettings.json");

            var config = builder.Build();
            var connectionString = config.GetConnectionString("TravelAwayDBConnectionString");
            if (!optionsBuilder.IsConfigured)
            {
                // #warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer(connectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Accomodation>(entity =>
            {
                entity.Property(e => e.City)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.HotelName)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Price).HasColumnType("money");

                entity.Property(e => e.RoomType)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.HasOne(d => d.Booking)
                    .WithMany(p => p.Accomodation)
                    .HasForeignKey(d => d.BookingId)
                    .HasConstraintName("fk_BookingId");
            });

            modelBuilder.Entity<BookPackage>(entity =>
            {
                entity.HasKey(e => e.BookingId)
                    .HasName("pk_BookingId");

                entity.HasIndex(e => e.ContactNumber)
                    .HasName("UQ__BookPack__570665C61E784124")
                    .IsUnique();

                entity.Property(e => e.Address)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.ContactNumber).HasColumnType("numeric(10, 0)");

                entity.Property(e => e.DateOfTravel).HasColumnType("date");

                entity.Property(e => e.EmailId)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Status)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.HasOne(d => d.Email)
                    .WithMany(p => p.BookPackage)
                    .HasForeignKey(d => d.EmailId)
                    .HasConstraintName("fk_EmailId");

                entity.HasOne(d => d.Package)
                    .WithMany(p => p.BookPackage)
                    .HasForeignKey(d => d.PackageId)
                    .HasConstraintName("fk_packId");
            });

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.HasKey(e => e.EmailId)
                    .HasName("pk_EmailId");

                entity.Property(e => e.EmailId)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Address)
                    .IsRequired()
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.ContactNumber).HasColumnType("numeric(10, 0)");

                entity.Property(e => e.DateOfBirth).HasColumnType("date");

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Gender)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UserPassword)
                    .IsRequired()
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.Customer)
                    .HasForeignKey(d => d.RoleId)
                    .HasConstraintName("fk_RoleId");
            });

            modelBuilder.Entity<CustomerCare>(entity =>
            {
                entity.HasKey(e => e.QueryId)
                    .HasName("pk_QueryId");

                entity.Property(e => e.Assignee).HasColumnType("int");
                //.HasMaxLength(50)
                //.IsUnicode(false);

                entity.Property(e => e.Query)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.QueryAnswer)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.QueryStatus)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.HasOne(d => d.Booking)
                    .WithMany(p => p.CustomerCare)
                    .HasForeignKey(d => d.BookingId)
                    .HasConstraintName("fk_BId");
            });

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.HasKey(e => e.EmpId)
                    .HasName("pk_EMPID");

                entity.Property(e => e.EmailId)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.Employee)
                    .HasForeignKey(d => d.RoleId)
                    .HasConstraintName("fk_RId");
            });

            modelBuilder.Entity<Hotel>(entity =>
            {
                entity.Property(e => e.City)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.DeluxeeRoomPrice).HasColumnType("money");

                entity.Property(e => e.DoubleRoomPrice).HasColumnType("money");

                entity.Property(e => e.HotelName)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.SingleRoomPrice).HasColumnType("money");

                entity.Property(e => e.SuiteRoomPrice).HasColumnType("money");

                entity.HasOne(d => d.Package)
                    .WithMany(p => p.Hotel)
                   .HasForeignKey(d => d.PackageId)
                    .HasConstraintName("fk_packId_hotels");
            });

            modelBuilder.Entity<Package>(entity =>
            {
                entity.HasIndex(e => e.PackageName)
                    .HasName("UQ__Package__73856F7AB7D69EEC")
                    .IsUnique();

                entity.Property(e => e.PackageName)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.TypeOfPackage)
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.HasOne(d => d.PackageCategory)
                    .WithMany(p => p.Package)
                    .HasForeignKey(d => d.PackageCategoryId)
                    .HasConstraintName("fk_PackageCategoryId");
            });

            modelBuilder.Entity<PackageCategory>(entity =>
            {
                entity.HasIndex(e => e.PackageCategoryName)
                    .HasName("UQ__PackageC__DD8EB474F8241CFC")
                    .IsUnique();

                entity.Property(e => e.PackageCategoryName)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<PackageDetails>(entity =>
            {
                entity.Property(e => e.Accomodation)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.PlacesToVisit)
                    .IsRequired()
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.PricePerAdult).HasColumnType("decimal(18, 0)");

                entity.HasOne(d => d.Package)
                    .WithMany(p => p.PackageDetails)
                    .HasForeignKey(d => d.PackageId)
                    .HasConstraintName("fk_PackageId");
            });

            modelBuilder.Entity<Payment>(entity =>
            {
                entity.Property(e => e.PaymentStatus)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.TotalAmount).HasColumnType("money");

                entity.HasOne(d => d.Booking)
                    .WithMany(p => p.Payment)
                    .HasForeignKey(d => d.BookingId)
                    .HasConstraintName("fk_PaymentBookId");
            });

            modelBuilder.Entity<Rating>(entity =>
            {
                entity.Property(e => e.Comments)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Rating1).HasColumnName("Rating");

                entity.HasOne(d => d.Booking)
                    .WithMany(p => p.Rating)
                    .HasForeignKey(d => d.BookingId)
                    .HasConstraintName("fk_BookId");
            });

            modelBuilder.Entity<Roles>(entity =>
            {
                entity.HasKey(e => e.RoleId)
                    .HasName("pk_RoleId");

                entity.HasIndex(e => e.RoleName)
                    .HasName("uq_RoleName")
                    .IsUnique();

                entity.Property(e => e.RoleId).ValueGeneratedOnAdd();

                entity.Property(e => e.RoleName)
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Vehicle>(entity =>
            {
                entity.Property(e => e.BasePrice).HasColumnType("decimal(20, 2)");

                entity.Property(e => e.RatePerHour).HasColumnType("decimal(20, 2)");

                entity.Property(e => e.RatePerKm).HasColumnType("decimal(20, 2)");

                entity.Property(e => e.VehicleName)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.VehicleType)
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<VehicleBooked>(entity =>
            {
                entity.HasKey(e => e.VehicleBookingId)
                    .HasName("pk_VehicleBookingId");

                entity.Property(e => e.BookingDate).HasColumnType("date");

                entity.Property(e => e.PickupTime)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.TotalCost).HasColumnType("decimal(20, 2)");

                entity.Property(e => e.VehicleName)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.VehicleStatus)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.HasOne(d => d.Vehicle)
                    .WithMany(p => p.VehicleBooked)
                    .HasForeignKey(d => d.VehicleId)
                    .HasConstraintName("fk_VehicleId");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
