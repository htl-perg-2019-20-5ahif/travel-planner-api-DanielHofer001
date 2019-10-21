using System;

namespace TravelPlanner.Logic
{
    public class ResponseTrip
    {
        public string depart { get; set; }
        public string departureTime { get; set; }
        public string arrive { get; set; }
        public string arrivalTime { get; set; }
        public ResponseTrip(string depart, string departureTime, string arrive, string arrivalTime)
        {
            this.depart = depart;
            this.departureTime = departureTime;
            this.arrive = arrive;
            this.arrivalTime = arrivalTime;
        }
    }
}
