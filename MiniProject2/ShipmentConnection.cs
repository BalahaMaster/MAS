using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MiniProject2
{
    class ShipmentConnection : ObjectPlusPlus
    {
        public string Name { get; set; }
        public DateTime ATA { get; set; }
        public DateTime ATD { get; set; }
        public DateTime ETA { get; set; }
        public DateTime ETD { get; set; }

        public ShipmentConnection(Shipment shipment, Connection connection, string name, DateTime ata, DateTime atd, DateTime eta, DateTime etd) : this(shipment, connection, name, eta, etd)
        {
            ATA = ata;
            ATD = atd;
        }

        public ShipmentConnection(Shipment shipment, Connection connection, string name, DateTime eta, DateTime etd) : base()
        {
            AddConstrain(GetAssociation(Role.ShipmentConnection_Shipment), shipment);
            AddConstrain(GetAssociation(Role.ShipmentConnection_Connection), connection);
            Name = name;
            ETA = eta;
            ETD = etd;
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
