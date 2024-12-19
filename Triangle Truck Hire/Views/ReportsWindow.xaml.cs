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
    public partial class ReportsWindow : Window
    {
        // Full data collection
        private ObservableCollection<Report> Reports { get; set; }

        // Filtered data collection
        private ObservableCollection<Report> FilteredReports { get; set; }

        public ReportsWindow()
        {
            InitializeComponent();

            // Initialize the data collections
            Reports = new ObservableCollection<Report>
            {
                new Report { Id = 1, LoadName = "Steel Beams", Destination = "Johannesburg", Driver = "John Doe", Date = DateTime.Now.AddDays(-1), Status = "Delivered" },
                new Report { Id = 2, LoadName = "Bricks", Destination = "Pretoria", Driver = "Jane Smith", Date = DateTime.Now.AddDays(-2), Status = "In Transit" },
                new Report { Id = 3, LoadName = "Furniture", Destination = "Durban", Driver = "James Brown", Date = DateTime.Now, Status = "Pending" }
            };

            // Initially display all reports
            FilteredReports = new ObservableCollection<Report>(Reports);
            ReportsDataGrid.ItemsSource = FilteredReports;
        }

        private void ApplyFiltersButton_Click(object sender, RoutedEventArgs e)
        {
            string driverFilter = DriverFilterTextBox.Text.Trim();
            DateTime? dateFilter = DateFilterPicker.SelectedDate;

            // Filter the reports based on the inputs
            var filtered = Reports.Where(report =>
                (string.IsNullOrEmpty(driverFilter) ||
                 report.Driver.IndexOf(driverFilter, StringComparison.OrdinalIgnoreCase) >= 0) &&
                (!dateFilter.HasValue || report.Date.Date == dateFilter.Value.Date)
            ).ToList();

            // Update the filtered collection
            FilteredReports.Clear();
            foreach (var report in filtered)
            {
                FilteredReports.Add(report);
            }
        }


        private void ClearFiltersButton_Click(object sender, RoutedEventArgs e)
        {
            // Clear filter inputs
            DriverFilterTextBox.Clear();
            DateFilterPicker.SelectedDate = null;

            // Reset to full reports list
            FilteredReports.Clear();
            foreach (var report in Reports)
            {
                FilteredReports.Add(report);
            }
        }
    }

    // Report Model Class
    public class Report
    {
        public int Id { get; set; }
        public string LoadName { get; set; }
        public string Destination { get; set; }
        public string Driver { get; set; }
        public DateTime Date { get; set; }
        public string Status { get; set; }
    }
}

