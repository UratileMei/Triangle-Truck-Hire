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
    /// <summary>
    /// Interaction logic for DashboardView.xaml
    /// </summary>
    public partial class DashboardView : UserControl
    {
        public DashboardView()
        {

            InitializeComponent();
            LoadTruckStatus();
            LoadDrivers();
        }

        private void LoadTruckStatus()
        {
            var truckData = new List<Truck>
            {
                new Truck { Size = "32", RegNo = "HX76CK", Status = "Available", Driver = "Isaac", Destination = "Local" },
                new Truck { Size = "8", RegNo = "CJ83BS", Status = "In Transit", Driver = "Eugene", Destination = "Multotec" },
                new Truck { Size = "4", RegNo = "DN90WL", Status = "Under Maintenance", Driver = "N/A", Destination = "Workshop" }
            };
            TruckStatusGrid.ItemsSource = truckData;
        }

        private void LoadDrivers()
        {
            DriverList.Items.Add("Isaac");
            DriverList.Items.Add("Eugene");
            DriverList.Items.Add("Patrick");
        }
    }

    public class Truck
    {
        public string Size { get; set; }
        public string RegNo { get; set; }
        public string Status { get; set; }
        public string Driver { get; set; }
        public string Destination { get; set; }
    }
}
