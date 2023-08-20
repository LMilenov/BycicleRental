namespace BycicleRental.Models
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    public class Transaction
    {
        public int Id { get; set; }
        public virtual Rental Rental { get; set; }
        public DateTime TransactionDate { get; set; }
        public decimal Amount { get; set; }
        
    }
}
