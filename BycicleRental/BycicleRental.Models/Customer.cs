﻿namespace BycicleRental.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Text;

    public class Customer
    {

        public int Id { get; set; }
        [Required]
        public string FullName { get; set; }
        public string Email { get; set; }
        public DateTime DateOfBirth { get; set; }


        public virtual ICollection<Rental> Rentals { get; set; }
    }
}
