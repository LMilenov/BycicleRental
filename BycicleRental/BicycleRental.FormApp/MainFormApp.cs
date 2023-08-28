using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BicycleRental.FormApp
{
    public partial class MainFormApp : Form
    {
        public MainFormApp()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            BicycleFormApp bicycleFormApp = new BicycleFormApp();
            bicycleFormApp.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            CustomerFormApp customerFormApp = new CustomerFormApp();
            customerFormApp.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            LocationFormApp locationFormApp = new LocationFormApp();
            locationFormApp.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            ReservationFormApp reservationFormApp = new ReservationFormApp();
            reservationFormApp.Show();
        }
    }
}
