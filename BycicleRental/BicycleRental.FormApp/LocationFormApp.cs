using BycicleRental.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace BicycleRental.FormApp
{
    public partial class LocationFormApp : Form
    {
        private List<Location> locations;
        public LocationFormApp()
        {

            InitializeComponent();
            locations = new List<Location>
            {
                new Location { Id = 1, Name = "Location 1", Address = "Address 1", ContactNumber = "123-456-7890" },
                new Location { Id = 2, Name = "Location 2", Address = "Address 2", ContactNumber = "987-654-3210" },
                new Location { Id = 3, Name = "Location 3", Address = "Address 3", ContactNumber = "555-123-4567" }
                // Add more locations as needed
            };

            // Populate the ListBox with location names
            foreach (Location location in locations)
            {
                listBox1.Items.Add(location.Name);
            }
        }

        private void LocationFormApp_Load(object sender, EventArgs e)
        {
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int searchId;
            if (int.TryParse(textBox1.Text, out searchId))
            {
                Location foundLocation = locations.Find(location => location.Id == searchId);

                if (foundLocation != null)
                {
                    // Clear the ListBox and add the location info
                    listBox1.Items.Clear();
                    listBox1.Items.Add($"ID: {foundLocation.Id}");
                    listBox1.Items.Add($"Name: {foundLocation.Name}");
                    listBox1.Items.Add($"Address: {foundLocation.Address}");
                    listBox1.Items.Add($"Contact Number: {foundLocation.ContactNumber}");
                }
                else
                {
                    MessageBox.Show("Location not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Invalid ID format.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string newName = textBox2.Text;
            string newAddress = textBox3.Text;
            string newContactNumber = textBox4.Text;

            if (!string.IsNullOrEmpty(newName) && !string.IsNullOrEmpty(newAddress) && !string.IsNullOrEmpty(newContactNumber))
            {
                int newId = locations.Count + 1; // You might want to use a more robust ID generation mechanism
                Location newLocation = new Location { Id = newId, Name = newName, Address = newAddress, ContactNumber = newContactNumber };
                locations.Add(newLocation);

                // Optionally, you can clear the textboxes after creating a new location
                textBox2.Clear();
                textBox3.Clear();
                textBox4.Clear();

                // Update the listbox to reflect the new location
                UpdateLocationListBox();
            }
            else
            {
                MessageBox.Show("Please fill in all fields.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void UpdateLocationListBox()
        {
            listBox1.Items.Clear();
            foreach (Location location in locations)
            {
                listBox1.Items.Add($"ID: {location.Id}");
                listBox1.Items.Add($"Name: {location.Name}");
                listBox1.Items.Add($"Address: {location.Address}");
                listBox1.Items.Add($"Contact Number: {location.ContactNumber}");
                listBox1.Items.Add("----------");
            }
        }
    }
    
}
