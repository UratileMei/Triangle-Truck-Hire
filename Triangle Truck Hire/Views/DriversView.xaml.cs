using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;


namespace Triangle_Truck_Hire.Views
{
    public partial class DriversView : UserControl
    {
        public DriversView()
        {
            InitializeComponent();
        }

        private void AddDriverButton_Click(object sender, RoutedEventArgs e)
        {
            // Logic to add a new driver
            string name = NameTextBox.Text;
            string licenseNumber = LicenseNumberTextBox.Text;
            string phoneNumber = PhoneNumberTextBox.Text;

            // Example validation
            if (string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(licenseNumber))
            {
                MessageBox.Show("Please fill in all required fields.");
                return;
            }

            // Add the driver to the list (replace with actual logic for database or collection)
            MessageBox.Show($"Driver '{name}' added successfully!");
        }

        private void EditDriverButton_Click(object sender, RoutedEventArgs e)
        {
            // Logic to edit a selected driver
            var selectedDriver = DriversListView.SelectedItem;
            if (selectedDriver == null)
            {
                MessageBox.Show("Please select a driver to edit.");
                return;
            }

            // Update the driver details (replace with actual logic for database or collection)
            MessageBox.Show("Driver details updated successfully!");
        }

        private void DeleteDriverButton_Click(object sender, RoutedEventArgs e)
        {
            // Logic to delete a selected driver
            var selectedDriver = DriversListView.SelectedItem;
            if (selectedDriver == null)
            {
                MessageBox.Show("Please select a driver to delete.");
                return;
            }

            // Remove the driver from the list (replace with actual logic for database or collection)
            MessageBox.Show("Driver deleted successfully!");
        }
    }
}

