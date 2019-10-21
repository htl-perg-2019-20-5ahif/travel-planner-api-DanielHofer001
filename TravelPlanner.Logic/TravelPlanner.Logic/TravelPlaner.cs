using System.Collections.Generic;
using System.Linq;

namespace TravelPlanner.Logic
{
    public class TravelPlaner : ITravelPlaner
    {

        public ResponseTrip GetResponseTrip(List<Schedule> schedules, string from, string to, string start)
        {
            ResponseTrip response = null;

            foreach (var trip in schedules)
            {
                if (from == "Linz")
                {
                    if (trip.City == to)
                    {
                        var go = trip.FromLinz.Where(leave => leave.Leave.CompareTo(start) >= 0).FirstOrDefault();
                        if (go == null) return null;
                        return new ResponseTrip(from, go.Leave, to, go.Arrive);
                    }
                }
                else if (to == "Linz")
                {
                    if (trip.City == from)
                    {

                        var go = trip.ToLinz.Where(leave => leave.Leave.CompareTo(start) >= 0).FirstOrDefault();
                        if (go == null) return null;
                        return new ResponseTrip(from, go.Leave, to, go.Arrive);
                    }
                }
                else
                {
                    if (trip.City == from)
                    {
                        var goToLinz = trip.ToLinz.Where(leave => leave.Leave.CompareTo(start) >= 0).FirstOrDefault();
                        //response = new ResponseTrip(trip.City, goToLinz.Leave, "Linz", goToLinz.Arrive);
                        foreach (var fromLinz in schedules)
                        {
                            if (fromLinz.City == to)
                            {
                                var arrive = fromLinz.FromLinz.Where(leave => leave.Leave.CompareTo(goToLinz.Arrive) >= 0).FirstOrDefault();
                                if (arrive == null) return null;
                                response = new ResponseTrip(from, goToLinz.Leave, to, arrive.Arrive);
                                return response;
                            }
                        }
                    }
                }


            }
            return null;
        }


    }
}
