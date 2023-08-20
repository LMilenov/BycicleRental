namespace BycicleRental.Models
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    public class Reservation
    {
        public int Id { get; set; }
        public DateTime ReservationStart { get; set; }
        public DateTime ReservationEnd { get; set; }

        public virtual Bycicle Bycicle { get; set; }
        public virtual Customer Customer { get; set; }
        public virtual Location Location { get; set; }
    }
}
