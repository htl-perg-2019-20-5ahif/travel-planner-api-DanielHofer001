using System;
using System.Collections.Generic;

namespace TravelPlanner.Logic
{
    public interface ITravelPlaner
    {
        ResponseTrip GetResponseTrip(List<Schedule> schedules, string from, string to, string start);
        
    }
}
