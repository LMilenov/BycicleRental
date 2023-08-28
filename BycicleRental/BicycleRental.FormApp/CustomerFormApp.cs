using BycicleRental.Data;
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
    public partial class CustomerFormApp : Form
    {
        public CustomerFormApp()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (int.TryParse(textBox1.Text, out int customerId))
            {
                var customer = GetCustomerById(customerId);

                if (customer != null)
                {
                    // Display customer information in the ListBox
                    listBox1.Items.Clear();
                    listBox1.Items.Add($"Customer ID: {customer.Id}");
                    listBox1.Items.Add($"Name: {customer.FullName}");
                    listBox1.Items.Add($"Email: {customer.Email}");
                }
                else
                {
                    listBox1.Items.Clear();
                    listBox1.Items.Add("Customer not found.");
                }
            }
            else
            {
                listBox1.Items.Clear();
                listBox1.Items.Add("Invalid customer ID format.");
            }
        }
        public Customer GetCustomerById(int id)
        {
            using (var context = new AppDbContext()) 
            {
                var customer = context.Customers.FirstOrDefault(c => c.Id == id);
                return customer;
            }
        }

        private void CustomerFormApp_Load(object sender, EventArgs e)
        {
            DisplayAllCustomers();
        }
        private void DisplayAllCustomers()
        {
            listBox2.Items.Clear();

            var customers = GetAllCustomers();

            if (customers.Count > 0)
            {
                foreach (var customer in customers)
                {
                    listBox2.Items.Add($"Customer ID: {customer.Id} - Name: {customer.FullName} - Email: {customer.Email}");
                }
            }
            else
            {
                listBox2.Items.Add("No customers found.");
            }
        }
        public List<Customer> GetAllCustomers()
        {
            using (var context = new AppDbContext()) 
            {
                var customers = context.Customers.ToList();
                return customers;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string name = textBox2.Text;
            string email = textBox3.Text;
            DateTime birthdate = dateTimePicker1.Value;

            if (string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(email))
            {
                MessageBox.Show("Name and email are required.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            using (var context = new AppDbContext()) 
            {
                Customer newCustomer = new Customer
                {
                    FullName = name,
                    Email = email,
                    DateOfBirth = birthdate
                };

                context.Customers.Add(newCustomer);
                context.SaveChanges();

                MessageBox.Show("Customer created successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
