using BycicleRental.Data;
using BycicleRental.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BycicleRental.Services
{
    public class BycicleService
    {
        private readonly AppDbContext dbContext;

        public BycicleService(AppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public IEnumerable<Bycicle> GetAllBicycles()
        {
            return dbContext.Bycicles.ToList();
        }

        public Bycicle GetBicycleById(int id)
        {
            return dbContext.Bycicles.FirstOrDefault(b => b.Id == id);
        }

        public void AddNewBicycle(Bycicle bicycle)
        {
            dbContext.Bycicles.Add(bicycle);
            dbContext.SaveChanges();
        }

        public void UpdateBicycle(Bycicle bicycle)
        {
            var existingBicycle = dbContext.Bycicles.FirstOrDefault(b => b.Id == bicycle.Id);
            if (existingBicycle != null)
            {
                existingBicycle.Brand = bicycle.Brand;
                existingBicycle.Model = bicycle.Model;
                existingBicycle.IsAvailable = bicycle.IsAvailable;
                dbContext.SaveChanges();
            }
        }

        public void RemoveBicycle(int id)
        {
            var bicycleToRemove = dbContext.Bycicles.FirstOrDefault(b => b.Id == id);
            if (bicycleToRemove != null)
            {
                dbContext.Bycicles.Remove(bicycleToRemove);
                dbContext.SaveChanges();
            }
        }
    }
}
