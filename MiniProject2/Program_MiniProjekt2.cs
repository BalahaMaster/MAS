
using System;
using System.Collections.Generic;

namespace MiniProject2
{
    class Program
    {
        static void Main(string[] args)
        {
            ObjectPlusPlus.DefineAssociations();

            Shipment sh1 = new Shipment("Shipment 1");
            Address add1 = new Address("Liliowa", "25A", "Warszawa", "Polska", "05-666");
            Address add2 = new Address("Tulipanowa", "2", "9", "Olsztyn", "Polska", "21-370");

            sh1.AddConstrain(sh1.GetAssociation(Role.ShipmentPickupAddress), add1); // Asocjacja binarna skierowana
            sh1.ShowConstrains(Role.ShipmentPickupAddress);
            try
            {
                sh1.AddConstrain(sh1.GetAssociation(Role.ShipmentPickupAddress), add2); // Bład - Shipment już jest powiązany z Address dla tej roli
            }
            catch(Exception e) { System.Console.WriteLine(e); }
            sh1.AddConstrain(sh1.GetAssociation(Role.ShipmentSenderAddress), add2);
            sh1.ShowConstrains(Role.ShipmentSenderAddress);
        }        
    }
}
