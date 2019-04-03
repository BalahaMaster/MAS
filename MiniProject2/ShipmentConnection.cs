using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MiniProject2
{
    class ShipmentConnection : ObjectPlusPlus
    {
        public Shipment Shipment { get; set; }
        public Connection Connection { get; set; }
        public DateTime ATA { get; set; }
        public DateTime ATD { get; set; }
        public DateTime ETA { get; set; }
        public DateTime ETD { get; set; }

        public ShipmentConnection(Shipment shipment, Connection connection, DateTime aTA, DateTime aTD, DateTime eTA, DateTime eTD) : base()
        {
            Shipment = shipment ?? throw new ArgumentNullException(nameof(shipment));
            Connection = connection ?? throw new ArgumentNullException(nameof(connection));
            ATA = aTA;
            ATD = aTD;
            ETA = eTA;
            ETD = eTD;
        }

        public override string ToString()
        {
            List<ObjectPlusPlus> allConstrains = GetConsrtains(Role.ShipmentConnection_Connection).ToList();
            Connection connection = (Connection) allConstrains.First();
            allConstrains = GetConsrtains(Role.ShipmentConnection_Shipment).ToList();
            Shipment shipment = (Shipment) allConstrains.First();
            return String.Format("Execution of Shipment {0} for Connection {1}", shipment, connection);
        }
    }
}
