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
using System.Windows.Shapes;


namespace Triangle_Truck_Hire.Views
{
    public partial class LoadsWindow : Window
    {
        // ObservableCollection to dynamically manage loads
        public ObservableCollection<Load> Loads { get; set; }

        public LoadsWindow()
        {
            InitializeComponent();

            // Initialize the collection and set it as the data source for the DataGrid
            Loads = new ObservableCollection<Load>();
            LoadsDataGrid.ItemsSource = Loads;
        }

        private void AddLoadButton_Click(object sender, RoutedEventArgs e)
        {
            string name = LoadNameTextBox.Text;
            string destination = DestinationTextBox.Text;
            string driver = DriverTextBox.Text;
            DateTime? date = LoadDatePicker.SelectedDate;

            // Validation
            if (string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(destination) || string.IsNullOrWhiteSpace(driver) || date == null)
            {
                MessageBox.Show("All fields are required.", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            // Add new load to the ObservableCollection
            Loads.Add(new Load
            {
                Id = Loads.Count + 1, // Generate a simple ID
                Name = name,
                Destination = destination,
                Driver = driver,
                Date = date.Value
            });

            // Clear input fields
            LoadNameTextBox.Clear();
            DestinationTextBox.Clear();
            DriverTextBox.Clear();
            LoadDatePicker.SelectedDate = null;
        }

        private void EditLoadButton_Click(object sender, RoutedEventArgs e)
        {
            if (LoadsDataGrid.SelectedItem is Load selectedLoad)
            {
                selectedLoad.Name = LoadNameTextBox.Text;
                selectedLoad.Destination = DestinationTextBox.Text;
                selectedLoad.Driver = DriverTextBox.Text;
                selectedLoad.Date = LoadDatePicker.SelectedDate ?? selectedLoad.Date;

                // Refresh the DataGrid
                LoadsDataGrid.Items.Refresh();
            }
            else
            {
                MessageBox.Show("Please select a load to edit.", "Edit Error", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void DeleteLoadButton_Click(object sender, RoutedEventArgs e)
        {
            if (LoadsDataGrid.SelectedItem is Load selectedLoad)
            {
                // Remove the load from the collection
                Loads.Remove(selectedLoad);
            }
            else
            {
                MessageBox.Show("Please select a load to delete.", "Delete Error", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
    }

    // Load Model Class
    public class Load
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Destination { get; set; }
        public string Driver { get; set; }
        public DateTime Date { get; set; }
    }
}
