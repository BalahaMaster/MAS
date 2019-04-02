
using System;
using System.Collections.Generic;

namespace MiniProject2
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Association> definedAssociation = new List<Association>();

            Association s_a1 = new Association(typeof(Shipment), typeof(Address), 1, Role.ShipmentSenderAddress);
            Association s_a2 = new Association(typeof(Shipment), typeof(Address), 1, Role.ShipmentPickupAddress);
            Association c_a1 = new Association(typeof(Connection), typeof(Address), 1, Role.ConnectionStartAddress);
            Association c_a2 = new Association(typeof(Connection), typeof(Address), 1, Role.ConnectionEndAddress);
            definedAssociation.Add(s_a1);
            definedAssociation.Add(s_a2);
            definedAssociation.Add(c_a1);
            definedAssociation.Add(c_a2);

            Association s_sc = new Association(typeof(Shipment), 1, typeof(ShipmentConnection), -1, Role.Shipment_ShipmentConnection, Role.ShipmentConnection_Shipment);
            definedAssociation.Add(s_sc);
            definedAssociation.Add(s_sc.CreateReversedAssociation());

            Association c_sc = new Association(typeof(Connection), 1, typeof(ShipmentConnection), -1, Role.Connection_ShipmentConnection, Role.ShipmentConnection_Connection);
            definedAssociation.Add(c_sc);
            definedAssociation.Add(c_sc.CreateReversedAssociation());

            Association shi_cons = new Association(typeof(Shipment), 1, typeof(Consignment), -1, Role.ShipmentContainsConsignments, Role.ConsignmentsContainedByShipment);
            definedAssociation.Add(shi_cons);
            definedAssociation.Add(shi_cons.CreateReversedAssociation());

            Association con_sch = new Association(typeof(Connection), 1, typeof(Schedule), 1, Role.ConnectionShedule, Role.ScheduleConnection);
            definedAssociation.Add(con_sch);
            definedAssociation.Add(con_sch.CreateReversedAssociation());

            foreach(Association ass in definedAssociation)
            {
                ObjectPlusPlus.AddAssociation(ass);
            }

            Shipment sh1 = new Shipment { Name = "Shipment 1" };
            Address add1 = new Address("Liliowa", "25A", "Warszawa", "Polska", "05-666");
            Address add2 = new Address("Tulipanowa", "2", "9", "Olsztyn", "Polska", "21-370");

            sh1.AddConstrain(sh1.GetAssociation(Role.ShipmentPickupAddress), add1);
            sh1.AddConstrain(sh1.GetAssociation(Role.ShipmentPickupAddress), add2);
        }
    }
}
