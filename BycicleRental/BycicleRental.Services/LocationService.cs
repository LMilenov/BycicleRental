using BycicleRental.Data;
using BycicleRental.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace BycicleRental.Services
{

    public class LocationService
    {
        private readonly AppDbContext dbContext;

        public LocationService(AppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public IEnumerable<Location> GetAllLocations()
        {
            return dbContext.Locations.ToList();
        }

        public Location GetLocationById(int id)
        {
            return dbContext.Locations.FirstOrDefault(l => l.Id == id);
        }

        public void AddNewLocation(Location location)
        {
            dbContext.Locations.Add(location);
            dbContext.SaveChanges();
        }

        public void UpdateLocation(Location location)
        {
            var existingLocation = dbContext.Locations.FirstOrDefault(l => l.Id == location.Id);
            if (existingLocation != null)
            {
                existingLocation.Name = location.Name;
                existingLocation.Address = location.Address;
                existingLocation.ContactNumber = location.ContactNumber;
                dbContext.SaveChanges();
            }
        }

        public void RemoveLocation(int id)
        {
            var locationToRemove = dbContext.Locations.FirstOrDefault(l => l.Id == id);
            if (locationToRemove != null)
            {
                dbContext.Locations.Remove(locationToRemove);
                dbContext.SaveChanges();
            }
        }
    }

}
