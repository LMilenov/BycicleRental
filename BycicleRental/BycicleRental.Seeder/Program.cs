using BycicleRental.Data;
using BycicleRental.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;

namespace BycicleRental.Seeder
{
    public static class Program
    {

        private static readonly Random Random = new Random();

        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new AppDbContext(
                serviceProvider.GetRequiredService<DbContextOptions<AppDbContext>>()))
            {
                if (context.Bycicles.Any())
                {
                    return;
                }

             
            }
        }

        private static void SeedBicycles(AppDbContext context, int count)
        {
            var bicycles = Enumerable.Range(1, count).Select(i => new Bycicle
            {
                Brand = $"Brand{i}",
                Model = $"Model{i}",
                IsAvailable = Random.Next(2) == 0 
            });

            context.Bycicles.AddRange(bicycles);
        }

        private static void SeedCustomers(AppDbContext context, int count)
        {
            var customers = Enumerable.Range(1, count).Select(i => new Customer
            {
                FullName = $"Customer{i}",
                Email = $"customer{i}@example.com",
                DateOfBirth = DateTime.Now.AddYears(-Random.Next(18, 60)) 
            });

            context.Customers.AddRange(customers);
        }

        private static void SeedLocations(AppDbContext context, int count)
        {
            var locations = Enumerable.Range(1, count).Select(i => new Location
            {
                Name = $"Location{i}",
                Address = $"Address{i}",
                ContactNumber = $"123-456-{Random.Next(1000, 9999)}" 
            });

            context.Locations.AddRange(locations);
        }

        private static void SeedInsurances(AppDbContext context, int count)
        {
            var insurances = Enumerable.Range(1, count).Select(i => new Insurance
            {
                Type = $"InsuranceType{i}",
                CoverageAmount = Random.Next(100, 500) 
            });

            context.Insurances.AddRange(insurances);
        }

        private static void SeedRentals(AppDbContext context, int count)
        {
            var bicycles = context.Bycicles.ToList();
            var customers = context.Customers.ToList();
            var locations = context.Locations.ToList();
            var insurances = context.Insurances.ToList();

            var rentals = Enumerable.Range(0, count-1).Select(i => new Rental
            {
                Bycicle = bicycles[Random.Next(0, bicycles.Count)],
                Customer = customers[Random.Next(0, customers.Count)],
                Location = locations[Random.Next(0, locations.Count)],
                Insurance = insurances[Random.Next(0, insurances.Count)],
                RentalStart = DateTime.Now.AddDays(-Random.Next(1, 30)),
                RentalEnd = DateTime.Now.AddHours(-Random.Next(1, 72))
            });

            context.Rentals.AddRange(rentals);
        }

        public static void Main(string[] args)
        {
            var serviceProvider = new ServiceCollection()
                .AddDbContext<AppDbContext>(options =>
                    options.UseSqlServer(@"Server=DESKTOP-UACUS9A; Initial Catalog=BycicleRentalEf; Integrated Security=true; Trusted_Connection=true"))
                .BuildServiceProvider();

            using (var context = serviceProvider.GetRequiredService<AppDbContext>())
            {
                if (context.Bycicles.Any()) // Check if the database is already seeded
                {
                    Console.WriteLine("Database already seeded.");
                }
                else
                {
                    SeedDatabase(context);
                    Console.WriteLine("Database seeded successfully.");
                }
            }

        }
        private static void SeedDatabase(AppDbContext context)
        {
            SeedBicycles(context, 10);
            SeedCustomers(context, 20);
            SeedLocations(context, 5);
            SeedInsurances(context, 2);

            context.SaveChanges();

            SeedRentals(context, 50); 

            context.SaveChanges();
        }
    }

}
