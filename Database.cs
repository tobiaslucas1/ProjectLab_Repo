using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Test
{
    public static class Database
    {
        public static List<Driver> Drivers { get; set; } = new List<Driver>();
        public static List<User> Users { get; set; } = new List<User>();
        public static List<RoadTrip> RoadTrips { get; set; } = new List<RoadTrip>();
        public static User CurrentUser { get; set; }



    }
}
