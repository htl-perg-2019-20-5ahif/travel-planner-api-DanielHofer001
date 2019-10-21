using System;
using System.Collections.Generic;

namespace TravelPlanner.Logic
{
    public class Schedule
    {
        public string City{ get; set; }

        public List<Trip> ToLinz { get; set; }

        public List<Trip> FromLinz { get; set; }

    }
    public class Trip
    {
        public String Leave { get; set; }
        public String Arrive { get; set; }

    }
}
