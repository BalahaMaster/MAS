
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
            Address add3 = new Address("Kasztanowa", "13", "Płock", "Polska", "01-234");

            sh1.AddLink(ObjectPlusPlus.GetAssociation(Role.ShipmentPickupAddress), add3); // asocjacja binarna skierowana
            sh1.AddLink(ObjectPlusPlus.GetAssociation(Role.ShipmentSenderAddress), add1); 

            sh1.ShowLinks(Role.ShipmentPickupAddress);
            sh1.ShowLinks(Role.ShipmentSenderAddress);

            Connection c1 = new Connection("Warszawa-Płock", 110);
            c1.AddLink(ObjectPlusPlus.GetAssociation(Role.ConnectionStartAddress), add1);
            c1.AddLink(ObjectPlusPlus.GetAssociation(Role.ConnectionEndAddress), add3);

            Schedule sch1 = Schedule.CreateSchedule(c1); // kompozycja
            c1.ShowLinks(Role.ConnectionShedule);
            sch1.ShowLinks(Role.ScheduleConnection);

            Connection c2 = new Connection("Płock-Olsztyn", 180);
            c2.AddLink(ObjectPlusPlus.GetAssociation(Role.ConnectionStartAddress), add3);
            c2.AddLink(ObjectPlusPlus.GetAssociation(Role.ConnectionEndAddress), add2);

            Schedule sch2 = Schedule.CreateSchedule(c2);

            DatePair dp1 = new DatePair(new DateTime(2019,4,20,11,0,0), new DateTime(2019,4,20,13,0,0));
            DatePair dp2 = new DatePair(new DateTime(2019,4,20,18,0,0), new DateTime(2019,4,20,21,0,0));

            sch1.AddLink(ObjectPlusPlus.GetAssociation(Role.Schedule_DatePair), dp1);
            sch2.AddLink(ObjectPlusPlus.GetAssociation(Role.Schedule_DatePair), dp2);

            Execution e1 = new Execution(sch1.Etd_Eta)


            //Execution exe1 = new Execution(new DateTime(2019, 04, 26, 10, 0, 0), new DateTime(2019, 04, 26, 6, 0, 0)); // Asocjacja z atrybutem pomiędzy shipment i connection
            //Execution exe2 = new Execution(sh1, c2, c2.Name, new DateTime(2019, 04, 26, 18, 0, 0), new DateTime(2019, 04, 26, 10, 0, 0)); // Asocjacja z atrybutem pomiędzy shipment i connection
            //Execution sc3 = new Execution(sh2, c2, c2.Name, etd: new DateTime(2019, 05, 02, 12, 0, 0), eta: new DateTime(2019, 05, 02, 14, 0, 0));
            //sh1.ShowLinks(Role.Shipment_Execution);
            //c2.ShowLinks(Role.Connection_Execution);


            //Consignment csg1 = new Consignment(2.5);
            //System.Console.WriteLine(csg1.Shipment);

            //c1.CreateSchedule();
            //c1.Schedule.ShowLinks(Role.ScheduleConnection);
            //c1.ShowLinks(Role.ConnectionShedule);
            //c1.CreateSchedule();

        }
    }
}
