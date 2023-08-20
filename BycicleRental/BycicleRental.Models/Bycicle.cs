using System;
using System.Collections.Generic;
using System.Text;

namespace BycicleRental.Models
{
    public class Bycicle
    {
        public int Id { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public bool IsAvailable { get; set; }

        public virtual ICollection<Rental> Rentals { get; set; }
    }
}
