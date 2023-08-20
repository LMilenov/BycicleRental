using System;
using BycicleRental.Models;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace BycicleRental.Data
{
    public class AppDbContext : DbContext
    {
        private const string ConnectionString = @"Server=DESKTOP-LVCQ3HO; Initial Catalog=CarRentalEf; Integrated Security=true; Trusted_Connection=true";
        public DbSet<Bycicle> Bycycles { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Insurance> Insurances { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<Rental> Rentals { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<Transaction> Transactions { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(ConnectionString);
            }
            optionsBuilder.UseLazyLoadingProxies();

        }
}
