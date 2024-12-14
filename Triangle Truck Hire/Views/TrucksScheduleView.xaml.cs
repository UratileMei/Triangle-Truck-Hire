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
    /// <summary>
    /// Interaction logic for TrucksScheduleView.xaml
    /// </summary>
    public partial class TrucksScheduleView : UserControl
    {
        public ObservableCollection<TruckSchedule> TruckData { get; set; }

        public TrucksScheduleView()
        {
            InitializeComponent();

            TruckData = new ObservableCollection<TruckSchedule>
            {
                new TruckSchedule { Size = 32, RegNo = "HX76CK", Hire = "ROAD FREIGHT", Booking = "22-Nov", ContractNo = "78797", Driver = "ISAAC", Destination = "LOCAL", Notes = "" }
                // Initial data here...
            };

            DataContext = this;
        }

        private void AddOrUpdateTruck(object sender, RoutedEventArgs e)
        {
            // Validate input
            if (string.IsNullOrWhiteSpace(RegNoInput.Text) || string.IsNullOrWhiteSpace(SizeInput.Text))
            {
                MessageBox.Show("Size and Registration Number are required fields.", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            // Parse size
            if (!int.TryParse(SizeInput.Text, out int size))
            {
                MessageBox.Show("Size must be a number.", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            // Find existing truck or create new
            var existingTruck = TruckData.FirstOrDefault(t => t.RegNo == RegNoInput.Text);
            if (existingTruck != null)
            {
                // Update existing truck
                existingTruck.Size = size;
                existingTruck.Hire = HireInput.Text;
                existingTruck.Booking = BookingInput.Text;
                existingTruck.ContractNo = ContractNoInput.Text;
                existingTruck.Driver = DriverInput.Text;
                existingTruck.Destination = DestinationInput.Text;
                existingTruck.Notes = NotesInput.Text;
            }
            else
            {
                // Add new truck
                TruckData.Add(new TruckSchedule
                {
                    Size = size,
                    RegNo = RegNoInput.Text,
                    Hire = HireInput.Text,
                    Booking = BookingInput.Text,
                    ContractNo = ContractNoInput.Text,
                    Driver = DriverInput.Text,
                    Destination = DestinationInput.Text,
                    Notes = NotesInput.Text
                });
            }

            // Clear form inputs
            ClearInputs();
        }

        private void ClearInputs()
        {
            SizeInput.Text = "";
            RegNoInput.Text = "";
            HireInput.Text = "";
            BookingInput.Text = "";
            ContractNoInput.Text = "";
            DriverInput.Text = "";
            DestinationInput.Text = "";
            NotesInput.Text = "";
        }
    }

    public class TruckSchedule
    {
        public int Size { get; set; }
        public string RegNo { get; set; }
        public string Hire { get; set; }
        public string Booking { get; set; }
        public string ContractNo { get; set; }
        public string Driver { get; set; }
        public string Destination { get; set; }
        public string Notes { get; set; }
    }
}
