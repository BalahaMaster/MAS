
using System;

namespace MiniProject2
{
    public class DatePair : ObjectPlusPlus
    {
        public DateTime Departure { get; set; }
        public DateTime Arrival { get; set; }
        public DatePair(DateTime departure, DateTime arrival)
        {
            if(departure == null || arrival == null)        
            {
                throw new Exception("ETA and ETD cannot be null");
            }
            if(departure > arrival)
            {
                throw new Exception("ETA must be later than ETD");
            }
            Departure = departure;
            Arrival = arrival;
        }
    } 
}