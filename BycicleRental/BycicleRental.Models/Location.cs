using System;
using System.Collections.Generic;
using System.Text;

namespace BycicleRental.Models
{
    public class Location
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string ContactNumber { get; set; }

        public virtual ICollection<Rental> Rentals { get; set; }
        public virtual ICollection<Reservation> Reservations { get; set; }
    }
}
