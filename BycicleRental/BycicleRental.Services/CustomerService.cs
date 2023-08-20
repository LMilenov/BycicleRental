using BycicleRental.Data;
using BycicleRental.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace BycicleRental.Services
{

    public class CustomerService
    {
        private readonly AppDbContext dbContext;

        public CustomerService(AppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public IEnumerable<Customer> GetAllCustomers()
        {
            return dbContext.Customers.ToList();
        }

        public Customer GetCustomerById(int id)
        {
            return dbContext.Customers.FirstOrDefault(c => c.Id == id);
        }

        public void AddNewCustomer(Customer customer)
        {
            dbContext.Customers.Add(customer);
            dbContext.SaveChanges();
        }

        public void UpdateCustomer(Customer customer)
        {
            var existingCustomer = dbContext.Customers.FirstOrDefault(c => c.Id == customer.Id);
            if (existingCustomer != null)
            {
                existingCustomer.FullName = customer.FullName;
                existingCustomer.Email = customer.Email;
                existingCustomer.DateOfBirth = customer.DateOfBirth;
                dbContext.SaveChanges();
            }
        }

        public void RemoveCustomer(int id)
        {
            var customerToRemove = dbContext.Customers.FirstOrDefault(c => c.Id == id);
            if (customerToRemove != null)
            {
                dbContext.Customers.Remove(customerToRemove);
                dbContext.SaveChanges();
            }
        }
    }

}
