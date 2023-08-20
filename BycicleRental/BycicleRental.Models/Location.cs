namespace BycicleRental.Models
{

    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Text;
    public class Location
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public string ContactNumber { get; set; }

        public virtual ICollection<Rental> Rentals { get; set; }
        public virtual ICollection<Reservation> Reservations { get; set; }
    }
}
