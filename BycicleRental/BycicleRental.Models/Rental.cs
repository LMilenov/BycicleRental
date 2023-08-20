namespace BycicleRental.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Text;
    public  class Rental
    {
        public int Id { get; set; }
        public virtual Bycicle Bycicle { get; set; }
        public virtual Customer Customer { get; set; }
        public virtual Location Location { get; set; }
        public virtual Insurance Insurance { get; set; }
       
        public DateTime RentalStart { get; set; }
        
        public DateTime RentalEnd { get; set; }
    }
}
