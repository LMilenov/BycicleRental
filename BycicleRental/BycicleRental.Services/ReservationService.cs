using BycicleRental.Data;
using BycicleRental.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace BycicleRental.Services
{
    public class ReservationService
    {
        private readonly AppDbContext dbContext;

        public ReservationService(AppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public IEnumerable<Reservation> GetAllReservations()
        {
            return dbContext.Reservations.ToList();
        }

        public Reservation GetReservationById(int id)
        {
            return dbContext.Reservations.FirstOrDefault(r => r.Id == id);
        }

        public void AddNewReservation(Reservation reservation)
        {
            dbContext.Reservations.Add(reservation);
            dbContext.SaveChanges();
        }

        public void UpdateReservation(Reservation reservation)
        {
            var existingReservation = dbContext.Reservations.FirstOrDefault(r => r.Id == reservation.Id);
            if (existingReservation != null)
            {
                existingReservation.Bicycle = reservation.Bicycle;
                existingReservation.Customer = reservation.Customer;
                existingReservation.Location = reservation.Location;
                existingReservation.ReservationStart = reservation.ReservationStart;
                existingReservation.ReservationEnd = reservation.ReservationEnd;
                dbContext.SaveChanges();
            }
        }

        public void RemoveReservation(int id)
        {
            var reservationToRemove = dbContext.Reservations.FirstOrDefault(r => r.Id == id);
            if (reservationToRemove != null)
            {
                dbContext.Reservations.Remove(reservationToRemove);
                dbContext.SaveChanges();
            }
        }
    }
}
