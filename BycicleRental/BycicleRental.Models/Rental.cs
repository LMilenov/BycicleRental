using System;
using System.Collections.Generic;
using System.Text;

namespace BycicleRental.Models
{
    public class Rental
    {
        public int Id { get; set; }
        public virtual Bycicle Bicycle { get; set; }
        public virtual Customer Customer { get; set; }
        public virtual Location Location { get; set; }
        public virtual Insurance Insurance { get; set; }
        public DateTime RentalStart { get; set; }
        public DateTime RentalEnd { get; set; }
    }
}
