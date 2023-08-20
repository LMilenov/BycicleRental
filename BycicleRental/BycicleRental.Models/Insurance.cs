namespace BycicleRental.Models
{

    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Text;

    public class Insurance
    {
        public int Id { get; set; }
        [Required]
        public string Type { get; set; }
        public decimal CoverageAmount { get; set; }
        
        public virtual ICollection<Rental> Rentals { get; set; }
    }
}
