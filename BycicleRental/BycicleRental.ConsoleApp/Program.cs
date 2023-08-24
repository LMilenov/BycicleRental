using System;
using System.Linq;
using BycicleRental.Data;
using BycicleRental.Models;
using BycicleRental.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace BycicleRental.ConsoleApp
{
    public class Program
    {
        static void Main(string[] args)
        {
            var serviceProvider = new ServiceCollection()
                .AddDbContext<AppDbContext>(options =>
                    options.UseSqlServer(@"Server=DESKTOP-UACUS9A; Initial Catalog=BycicleRentalEf; Integrated Security=true; Trusted_Connection=true"))
                .AddTransient<BycicleService>()
                .AddTransient<CustomerService>()
                .AddTransient<LocationService>()
                .AddTransient<ReservationService>()
                .BuildServiceProvider();

            while (true)
            {
                Console.WriteLine("Welcome to the Bicycle Rental System");
                Console.WriteLine("1. List Bicycles");
                Console.WriteLine("2. List Customers");
                Console.WriteLine("3. List Locations");
                Console.WriteLine("4. List Reservations");
                Console.WriteLine("5. Add Bicycle");
                Console.WriteLine("6. Add Customer");
                Console.WriteLine("7. Add Location");
                Console.WriteLine("8. Add Reservation");
                Console.WriteLine("9. Exit");
                Console.Write("Enter your choice: ");

                var choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        ListBicycles(serviceProvider);
                        break;
                    case "2":
                        ListCustomers(serviceProvider);
                        break;
                    case "3":
                        ListLocations(serviceProvider);
                        break;
                    case "4":
                        ListReservations(serviceProvider);
                        break;
                    case "5":
                        AddBicycle(serviceProvider);
                        break;
                    case "6":
                        AddCustomer(serviceProvider);
                        break;
                    case "7":
                        AddLocation(serviceProvider);
                        break;
                    case "8":
                        AddReservation(serviceProvider);
                        break;
                    case "9":
                        return;
                    default:
                        Console.WriteLine("Invalid choice. Please enter a valid option.");
                        break;
                }
            }
        }


        static void AddBicycle(IServiceProvider serviceProvider)
        {
            using var scope = serviceProvider.CreateScope();
            var bicycleService = scope.ServiceProvider.GetRequiredService<BycicleService>();

            Console.Write("Enter Brand: ");
            var brand = Console.ReadLine();

            Console.Write("Enter Model: ");
            var model = Console.ReadLine();

            Console.Write("Is Available (true/false): ");
            bool.TryParse(Console.ReadLine(), out bool isAvailable);

            var newBicycle = new Bycicle
            {
                Brand = brand,
                Model = model,
                IsAvailable = isAvailable
            };

            bicycleService.AddNewBicycle(newBicycle);
            Console.WriteLine("Bicycle added successfully.");
        }

        static void AddCustomer(IServiceProvider serviceProvider)
        {
            using var scope = serviceProvider.CreateScope();
            var customerService = scope.ServiceProvider.GetRequiredService<CustomerService>();

            Console.Write("Enter Full Name: ");
            var fullName = Console.ReadLine();

            Console.Write("Enter Email: ");
            var email = Console.ReadLine();

            Console.Write("Enter Date of Birth (YYYY-MM-DD): ");
            DateTime.TryParse(Console.ReadLine(), out DateTime dateOfBirth);

            var newCustomer = new Customer
            {
                FullName = fullName,
                Email = email,
                DateOfBirth = dateOfBirth
            };

            customerService.AddNewCustomer(newCustomer);
            Console.WriteLine("Customer added successfully.");
        }

        static void AddLocation(IServiceProvider serviceProvider)
        {
            using var scope = serviceProvider.CreateScope();
            var locationService = scope.ServiceProvider.GetRequiredService<LocationService>();

            Console.Write("Enter Name: ");
            var name = Console.ReadLine();

            Console.Write("Enter Address: ");
            var address = Console.ReadLine();

            Console.Write("Enter Contact Number: ");
            var contactNumber = Console.ReadLine();

            var newLocation = new Location
            {
                Name = name,
                Address = address,
                ContactNumber = contactNumber
            };

            locationService.AddNewLocation(newLocation);
            Console.WriteLine("Location added successfully.");
        }

        static void AddReservation(IServiceProvider serviceProvider)
        {
            using var scope = serviceProvider.CreateScope();
            var reservationService = scope.ServiceProvider.GetRequiredService<ReservationService>();

            // Collect input data
            Console.Write("Enter Bicycle Id: ");
            int.TryParse(Console.ReadLine(), out int bicycleId);

            Console.Write("Enter Customer Id: ");
            int.TryParse(Console.ReadLine(), out int customerId);

            Console.Write("Enter Location Id: ");
            int.TryParse(Console.ReadLine(), out int locationId);

            Console.Write("Enter Reservation Start Date and Time (YYYY-MM-DD HH:mm:ss): ");
            DateTime.TryParse(Console.ReadLine(), out DateTime reservationStart);

            Console.Write("Enter Reservation End Date and Time (YYYY-MM-DD HH:mm:ss): ");
            DateTime.TryParse(Console.ReadLine(), out DateTime reservationEnd);

            // Create a new Reservation object
            var newReservation = new Reservation
            {
                Bycicle = new Bycicle { Id = bicycleId }, 
                Customer = new Customer { Id = customerId },
                Location = new Location { Id = locationId },
                ReservationStart = reservationStart,
                ReservationEnd = reservationEnd
            };

            reservationService.AddNewReservation(newReservation);
            Console.WriteLine("Reservation added successfully.");
        }

        static void ListBicycles(IServiceProvider serviceProvider)
        {
            using var scope = serviceProvider.CreateScope();
            var bicycleService = scope.ServiceProvider.GetRequiredService<BycicleService>();

            var bicycles = bicycleService.GetAllBicycles();
            Console.WriteLine("List of Bicycles:");
            foreach (var bicycle in bicycles)
            {
                Console.WriteLine($"{bicycle.Id}: {bicycle.Brand} - {bicycle.Model} (Available: {bicycle.IsAvailable})");
            }
        }

        static void ListCustomers(IServiceProvider serviceProvider)
        {
            using var scope = serviceProvider.CreateScope();
            var customerService = scope.ServiceProvider.GetRequiredService<CustomerService>();

            var customers = customerService.GetAllCustomers();
            Console.WriteLine("List of Customers:");
            foreach (var customer in customers)
            {
                Console.WriteLine($"{customer.Id}: {customer.FullName} - {customer.Email} (DOB: {customer.DateOfBirth.ToShortDateString()})");
            }
        }

        static void ListLocations(IServiceProvider serviceProvider)
        {
            using var scope = serviceProvider.CreateScope();
            var locationService = scope.ServiceProvider.GetRequiredService<LocationService>();

            var locations = locationService.GetAllLocations();
            Console.WriteLine("List of Locations:");
            foreach (var location in locations)
            {
                Console.WriteLine($"{location.Id}: {location.Name} - {location.Address} (Contact: {location.ContactNumber})");
            }
        }

        static void ListReservations(IServiceProvider serviceProvider)
        {
            using var scope = serviceProvider.CreateScope();
            var reservationService = scope.ServiceProvider.GetRequiredService<ReservationService>();

            var reservations = reservationService.GetAllReservations();
            Console.WriteLine("List of Reservations:");
            foreach (var reservation in reservations)
            {
                Console.WriteLine($"{reservation.Id}: Bike {reservation.Bycicle.Id} - Customer {reservation.Customer.Id} - Location {reservation.Location.Id} (From: {reservation.ReservationStart}, To: {reservation.ReservationEnd})");
            }
        }
    }
    
}
