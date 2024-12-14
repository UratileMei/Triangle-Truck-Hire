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
using System.Data.Sql;
using Triangle_Truck_Hire.Data;
using System.Collections.ObjectModel;
using Triangle_Truck_Hire.Model;
using Triangle_Truck_Hire.Views;


namespace Triangle_Truck_Hire
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void ShowDashboard(object sender, RoutedEventArgs e)
        {
            MainContent.Content = new Views.DashboardView();
           
        }

        private void ShowTrucks(object sender, RoutedEventArgs e)
        {
            MainContent.Content = new Views.TrucksView();
        }

        private void ShowDrivers(object sender, RoutedEventArgs e)
        {
            MainContent.Content = new Views.DriversView();
        }

        private void OpenLoadsWindow(object sender, RoutedEventArgs e)
        {
            var loadsWindow = new LoadsWindow();
            loadsWindow.Show();
        }

        private void OpenReportsWindow(object sender, RoutedEventArgs e)
        {
            var reportsWindow = new ReportsWindow();
            reportsWindow.Show();
        }
        private void OpenTrucksSchedule(object sender, RoutedEventArgs e)
        {
            MainContent.Content = new Views.TrucksScheduleView();
        }
    }
}

