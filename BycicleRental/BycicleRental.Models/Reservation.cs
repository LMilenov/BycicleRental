using System;
using System.Collections.Generic;
using System.Text;

namespace BycicleRental.Models
{
    public class Reservation
    {
        public int Id { get; set; }
        public DateTime ReservationStart { get; set; }
        public DateTime ReservationEnd { get; set; }

        public virtual Bycicle Bicycle { get; set; }
        public virtual Customer Customer { get; set; }
        public virtual Location Location { get; set; }
    }
}
