using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MiniProject2
{
    public class Execution : ObjectPlusPlus
    {
       public DateTime ATA { get; set; }
        public DateTime ATD { get; set; }
        public DateTime ETA { get; set; }
        public DateTime ETD { get; set; }
        public Execution(DateTime etd, DateTime eta, DateTime atd, DateTime ata) : this(etd, eta)
        {
            ATA = ata;
            ATD = atd;
        }
        public Execution(DateTime etd, DateTime eta) : base()
        {
            ETA = eta;
            ETD = etd;
        }
        public override string ToString()
        {
            return String.Format(
                "Execution Dates\nATD: {0}\nATA: {1}\nETD: {2}\nETA: {3}", 
                ATD.ToString().Equals(DateTime.MinValue.ToString()) ? "" : ATD.ToString(), 
                ATA.ToString().Equals(DateTime.MinValue.ToString()) ? "" : ATA.ToString(), 
                ETD.ToString().Equals(DateTime.MinValue.ToString()) ? "" : ETD.ToString(), 
                ETA.ToString().Equals(DateTime.MinValue.ToString()) ? "" : ETA.ToString()
                );
        }
    }
}
