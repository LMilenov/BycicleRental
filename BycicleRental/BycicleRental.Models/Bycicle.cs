namespace BycicleRental.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Text;

    public class Bycicle
    {

        public int Id { get; set; }
        [Required]
        public string Brand { get; set; }
        [Required]
        public string Model { get; set; }
        public bool IsAvailable { get; set; }

        public virtual ICollection<Rental> Rentals { get; set; }
    }
}
