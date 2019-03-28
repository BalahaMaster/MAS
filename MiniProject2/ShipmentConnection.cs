using System;
using System.Collections.Generic;
using System.Text;

namespace MiniProject2
{
    class ShipmentConnection
    {
        public Shipment Shipment { get; set; }
        public Connection Connection { get; set; }
        public DateTime ATA { get; set; }
        public DateTime ATD { get; set; }
        public DateTime ETA { get; set; }
        public DateTime ETD { get; set; }

        public ShipmentConnection(Shipment shipment, Connection connection, DateTime aTA, DateTime aTD, DateTime eTA, DateTime eTD)
        {
            Shipment = shipment ?? throw new ArgumentNullException(nameof(shipment));
            Connection = connection ?? throw new ArgumentNullException(nameof(connection));
            ATA = aTA;
            ATD = aTD;
            ETA = eTA;
            ETD = eTD;
        }
    }
}
