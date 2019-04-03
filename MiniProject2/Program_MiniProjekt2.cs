
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

            try
            {
                sh1.GetAssociation(Role.ConnectionShedule); // Bład - nie ma zdefiniowanej asocjacji dla tej roli i tego obiektu
            }
            catch (Exception e) {  System.Console.WriteLine(e); }

            sh1.AddSenderAddress(add1); // Asocjacja binarna skierowana
            sh1.ShowConstrains(Role.ShipmentPickupAddress);
            try
            {
                sh1.AddConstrain(sh1.GetAssociation(Role.ShipmentPickupAddress), add2); // Bład - Shipment już jest powiązany z Address dla tej roli
            }
            catch(Exception e) { System.Console.WriteLine(e); }
            sh1.AddConstrain(sh1.GetAssociation(Role.ShipmentSenderAddress), add2);
            sh1.ShowConstrains(Role.ShipmentSenderAddress);
            

            Address add3 = new Address("Kasztanowa", "13", "Płock", "Polska", "01-234");

            Connection c1 = new Connection("Warszawa-Płock", 120);
            Connection c2 = new Connection("Płock-Olsztyn", 220);

            ShipmentConnection sc1 = new ShipmentConnection(sh1, c1, +"Warszawa-Płock", new DateTime(2019, 04, 26, 10, 0, 0), new DateTime(2019, 04, 26, 6, 0, 0));
            ShipmentConnection sc2 = new ShipmentConnection("Płock=Olsztyn", new DateTime(2019, 04, 26, 18, 0, 0), new DateTime(2019, 04, 26, 10, 0, 0));

            ShipmentConnection sc3 = new ShipmentConnection("Warszawa-Płock", new DateTime(2019, 04, 27, 10, 0, 0), new DateTime(2019, 04, 27, 6, 0, 0));
            ShipmentConnection sc4 = new ShipmentConnection("Płock=Olsztyn", new DateTime(2019, 04, 27, 18, 0, 0), new DateTime(2019, 04, 27, 10, 0, 0));

            sh1.AddConstrain(sh1.GetAssociation(Role.Shipment_ShipmentConnection), sc1); 
            sh1.AddConstrain(sh1.GetAssociation(Role.Shipment_ShipmentConnection), sc2); // dodanie powiązania asocjacji z atrybutem do obiektu sh1
            c1.AddConstrain(c1.GetAssociation(Role.Connection_ShipmentConnection), sc1); // dodanie powiązania asocjacji z atrybutem do obiektu c1
            c2.AddConstrain(c2.GetAssociation(Role.Connection_ShipmentConnection), sc2);
            c1.AddConstrain(c1.GetAssociation(Role.Connection_ShipmentConnection), sc3);

            Shipment sh2 = new Shipment("Shipment 2");

        }        
    }
}
