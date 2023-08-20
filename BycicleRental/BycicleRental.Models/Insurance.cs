using System;
using System.Collections.Generic;
using System.Text;

namespace BycicleRental.Models
{
    public class Insurance
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public decimal CoverageAmount { get; set; }

        public virtual ICollection<Rental> Rentals { get; set; }
    }
}
