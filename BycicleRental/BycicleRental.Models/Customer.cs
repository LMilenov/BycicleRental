using System;
using System.Collections.Generic;
using System.Text;

namespace BycicleRental.Models
{
    public class Customer
    {

        public int Id { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public DateTime DateOfBirth { get; set; }


        public virtual ICollection<Rental> Rentals { get; set; }
    }
}
