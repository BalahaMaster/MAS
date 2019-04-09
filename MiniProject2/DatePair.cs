
using System;

namespace MiniProject2
{
    public class DatePair : ObjectPlusPlus
    {
        public DateTime ETD { get; set; }
        public DateTime ETA { get; set; }
        public DatePair(DateTime etd, DateTime eta)
        {
            if(etd == null || eta == null)        
            {
                throw new Exception("ETA and ETD cannot be null");
            }
            if(etd > eta)
            {
                throw new Exception("ETA must be later than ETD");
            }
            ETD = etd;
            ETA = eta;
        }
    }
}