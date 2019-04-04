using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MiniProject2
{
    public class Execution : ObjectPlusPlus
    {
        public Shipment Shipment
        {
            get
            {
                return (Shipment) GetLinks(Role.Execution_Shipment).FirstOrDefault();
            }
            set
            {
                AddLink(GetAssociation(Role.Execution_Shipment), value);
            }
        }
        public Connection Connection
        {
            get
            {
                return (Connection) GetLinks(Role.Execution_Connection).FirstOrDefault();
            }
            set
            {
                AddLink(GetAssociation(Role.Execution_Connection), value);
            }
        }
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
                "Execution of Shipment '{0}' for Connection '{1}'\nATD: {2}\nATA: {3}\nETD: {4}\nETA: {5}", 
                Shipment, 
                Connection, 
                ATD.ToString().Equals(DateTime.MinValue.ToString()) ? "" : ATD.ToString(), 
                ATA.ToString().Equals(DateTime.MinValue.ToString()) ? "" : ATA.ToString(), 
                ETD.ToString().Equals(DateTime.MinValue.ToString()) ? "" : ETD.ToString(), 
                ETA.ToString().Equals(DateTime.MinValue.ToString()) ? "" : ETA.ToString()
                );
        }
    }
}
