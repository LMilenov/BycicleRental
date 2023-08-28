using BycicleRental.Data;
using BycicleRental.Models;
using BycicleRental.Services;
using Microsoft.EntityFrameworkCore;
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
    public partial class BicycleFormApp : Form
    {
     
        private readonly BycicleService bycicleService;
        public BicycleFormApp()
        {
            InitializeComponent();
            bycicleService = new BycicleService(new AppDbContext());
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void BicycleFormApp_Load(object sender, EventArgs e)
        {
            LoadBicycles();
        }
        private void LoadBicycles()
        {
            listBox2.Items.Clear();

            var bicycles = bycicleService.GetAllBicycles();

            foreach (var bicycle in bicycles)
            {
                listBox2.Items.Add($"ID: {bicycle.Id}, Brand: {bicycle.Brand}, Model: {bicycle.Model}, Available: {bicycle.IsAvailable}");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (int.TryParse(textBox1.Text, out int bicycleId))
            {
                var bicycle = bycicleService.GetBicycleById(bicycleId);
                if (bicycle != null)
                {
                    bycicleService.RemoveBicycle(bicycle.Id);
                    LoadBicycles(); // Refresh the list after deletion
                    MessageBox.Show($"Bicycle with ID {bicycle.Id} has been deleted.");
                }
                else
                {
                    MessageBox.Show($"Bicycle with ID {bicycleId} not found.");
                }
            }
            else
            {
                MessageBox.Show("Please enter a valid bicycle ID.");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (int.TryParse(textBox2.Text, out int bicycleId))
            {
                var bicycle = bycicleService.GetBicycleById(bicycleId);

                if (bicycle != null)
                {
                    // Bicycle with the specified ID found
                    // Add its information to the ListBox
                    listBox3.Items.Clear();
                    listBox3.Items.Add($"ID: {bicycle.Id}, Brand: {bicycle.Brand}, Model: {bicycle.Model}");
                }
                else
                {
                    // Bicycle with the specified ID was not found
                    listBox3.Items.Clear();
                    listBox3.Items.Add("Bicycle not found");
                }
            }
            else
            {
                // Invalid input for bicycle ID
                listBox3.Items.Clear();
                listBox3.Items.Add("Invalid bicycle ID");
            }
        }

      
        
    }
}



