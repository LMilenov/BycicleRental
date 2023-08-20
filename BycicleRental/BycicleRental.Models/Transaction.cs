using System;
using System.Collections.Generic;
using System.Text;

namespace BycicleRental.Models
{
    public class Transaction
    {
        public int Id { get; set; }
        public Rental Rental { get; set; }
        public DateTime TransactionDate { get; set; }
        public decimal Amount { get; set; }
        
    }
}
