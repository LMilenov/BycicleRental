namespace BycicleRental.Data
{
    using System;
    using BycicleRental.Models;
    using System.Collections.Generic;
    using System.Text;
    using Microsoft.EntityFrameworkCore;
    using System.Security.Cryptography.X509Certificates;

    public class AppDbContext : DbContext
    {
        private const string connectionString = @"Server=DESKTOP-UACUS9A; Initial Catalog=BycicleRentalEf; Integrated Security=true; Trusted_Connection=true";
        public virtual DbSet<Bycicle> Bycicles { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Insurance> Insurances { get; set; }
        public virtual DbSet<Location> Locations { get; set; }
        public virtual DbSet<Rental> Rentals { get; set; }
        public virtual DbSet<Reservation> Reservations { get; set; }
        public virtual DbSet<Transaction> Transactions { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(connectionString);
                
            }
            optionsBuilder.UseLazyLoadingProxies();
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
          

            modelBuilder.Entity<Bycicle>()
       .Property(b => b.Brand)
       .IsRequired();

            modelBuilder.Entity<Bycicle>()
                .Property(b => b.Model)
                .IsRequired();

            modelBuilder.Entity<Customer>()
                .Property(c => c.FullName)
                .IsRequired();

            modelBuilder.Entity<Location>()
                .Property(l => l.Name)
                .IsRequired();

            modelBuilder.Entity<Location>()
                .Property(l => l.Address)
                .IsRequired();

            modelBuilder.Entity<Location>()
                .Property(l => l.ContactNumber)
                .IsRequired();

            modelBuilder.Entity<Insurance>()
                .Property(i => i.Type)
                .IsRequired();
        }

    }
}
