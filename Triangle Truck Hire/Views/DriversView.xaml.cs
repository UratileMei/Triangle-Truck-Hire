using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
        // ObservableCollection to store drivers dynamically
        public ObservableCollection<Driver> Drivers { get; set; }

        public DriversView()
        {
            InitializeComponent();

            // Initialize the collection and set it as the data source for the ListView
            Drivers = new ObservableCollection<Driver>();
            DriversListView.ItemsSource = Drivers;
        }

        private void AddDriverButton_Click(object sender, RoutedEventArgs e)
        {
            string name = NameTextBox.Text;
            string licenseNumber = LicenseNumberTextBox.Text;
            string phoneNumber = PhoneNumberTextBox.Text;

            // Validation
            if (string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(licenseNumber))
            {
                MessageBox.Show("Name and License Number are required fields.", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            // Add new driver to the ObservableCollection
            Drivers.Add(new Driver
            {
                Id = Drivers.Count + 1, // Generate a simple ID
                Name = name,
                LicenseNumber = licenseNumber,
                PhoneNumber = phoneNumber
            });

            // Clear input fields
            NameTextBox.Clear();
            LicenseNumberTextBox.Clear();
            PhoneNumberTextBox.Clear();
        }

        private void EditDriverButton_Click(object sender, RoutedEventArgs e)
        {
            if (DriversListView.SelectedItem is Driver selectedDriver)
            {
                selectedDriver.Name = NameTextBox.Text;
                selectedDriver.LicenseNumber = LicenseNumberTextBox.Text;
                selectedDriver.PhoneNumber = PhoneNumberTextBox.Text;

                // Refresh the ListView
                DriversListView.Items.Refresh();
            }
            else
            {
                MessageBox.Show("Please select a driver to edit.", "Edit Error", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void DeleteDriverButton_Click(object sender, RoutedEventArgs e)
        {
            if (DriversListView.SelectedItem is Driver selectedDriver)
            {
                // Remove the driver from the collection
                Drivers.Remove(selectedDriver);
            }
            else
            {
                MessageBox.Show("Please select a driver to delete.", "Delete Error", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
    }

    // Driver Model Class
    public class Driver
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LicenseNumber { get; set; }
        public string PhoneNumber { get; set; }
    }
}






