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
        public string Description { get; set; }
        public DateTime PickupDate { get; set; }
        public string Destination { get; set; }
        public int DriverId { get; set; }
        public Driver Driver { get; set; }
    }
}
