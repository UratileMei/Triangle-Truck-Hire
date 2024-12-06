using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Triangle_Truck_Hire.Model
{
    public class Load
    {
        public int Id { get; set; }
        public string PickupLocation { get; set; }
        public string DropoffLocation { get; set; }
        public int TruckId { get; set; }
        public int DriverId { get; set; }
        public string Status { get; set; }
    }
}
