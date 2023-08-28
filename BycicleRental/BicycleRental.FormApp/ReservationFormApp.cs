using BycicleRental.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace BicycleRental.FormApp
{
    public partial class ReservationFormApp : Form
    {
        private List<Reservation> reservations; 
        private List<Customer> customers;      
        private List<Bycicle> bicycles;
        public ReservationFormApp()
        {
            InitializeComponent();
            reservations = new List<Reservation>();
            customers = new List<Customer>();
            bicycles = new List<Bycicle>();
            reservations = new List<Reservation>
            {
                new Reservation { Id = 1, ReservationStart = DateTime.Now, ReservationEnd = DateTime.Now.AddDays(3) },
                new Reservation { Id = 2, ReservationStart = DateTime.Now, ReservationEnd = DateTime.Now.AddDays(2) },
            };
        }

        private void ReservationFormApp_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (int.TryParse(textBox1.Text, out int searchId))
            {
                Reservation foundReservation = reservations.Find(reservation => reservation.Id == searchId);

                if (foundReservation != null)
                {
                    DisplayReservation(foundReservation);
                }
                else
                {
                    MessageBox.Show("Reservation not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    ClearReservationDisplay();
                }
            }
            else
            {
                MessageBox.Show("Invalid ID format.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ClearReservationDisplay();
            }
        }
        private void DisplayReservation(Reservation reservation)
        {
            listBox1.Items.Clear();
            listBox1.Items.Add($"ID: {reservation.Id}");
            listBox1.Items.Add($"Start Date: {reservation.ReservationStart}");
            listBox1.Items.Add($"End Date: {reservation.ReservationEnd}");
        }

        private void ClearReservationDisplay()
        {
            listBox1.Items.Clear();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (int.TryParse(textBox2.Text, out int customerId) &&
        int.TryParse(textBox3.Text, out int bicycleId))
            {
                Customer customer = customers.FirstOrDefault(c => c.Id == customerId);
                Bycicle bicycle = bicycles.FirstOrDefault(b => b.Id == bicycleId);

                if (customer != null && bicycle != null)
                {
                    DateTime startDate = dateTimePicker1.Value;
                    DateTime endDate = dateTimePicker2.Value;

                    Reservation newReservation = new Reservation
                    {
                        ReservationStart = startDate,
                        ReservationEnd = endDate,
                        Customer = customer,
                        Bycicle = bicycle,
                    };

                    // Assuming reservations is a list that holds reservations
                    reservations.Add(newReservation);
                    MessageBox.Show("Reservation created successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Customer or Bicycle not found. Please enter valid IDs.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Invalid ID format. Please enter valid numbers.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
