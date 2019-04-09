
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

            Schedule sch1 = Schedule.CreateSchedule(c1, "Schedule for " + c1.Name); // kompozycja
            c1.ShowLinks(Role.ConnectionShedule);
            sch1.ShowLinks(Role.ScheduleConnection);

            Connection c2 = new Connection("Płock-Olsztyn", 180);
            c2.AddLink(ObjectPlusPlus.GetAssociation(Role.ConnectionStartAddress), add3);
            c2.AddLink(ObjectPlusPlus.GetAssociation(Role.ConnectionEndAddress), add2);

            Schedule sch2 = Schedule.CreateSchedule(c2, "Schedule for " + c2.Name);

            DatePair dp1 = new DatePair(new DateTime(2019,4,20,11,0,0), new DateTime(2019,4,20,13,0,0));
            DatePair dp2 = new DatePair(new DateTime(2019,4,20,18,0,0), new DateTime(2019,4,20,21,0,0));

            sch1.AddLink(ObjectPlusPlus.GetAssociation(Role.Schedule_DatePair), dp1, "Estimated 1"); // Asocjacja kwalifikowana
            sch2.AddLink(ObjectPlusPlus.GetAssociation(Role.Schedule_DatePair), dp2, "Estimated 2"); // Asocjacja kwalifikowana
            
            Execution exe1 = new Execution("Execution 1", (DatePair) sch1.GetLinknedObject(Role.Schedule_DatePair, "Estimated 1"));
            Execution exe2 = new Execution("Execution 2", (DatePair) sch2.GetLinknedObject(Role.Schedule_DatePair, "Estimated 2"));

            exe1.AddLinks(sh1, c1);
            exe2.AddLinks(sh1, c2);

            sh1.ShowLinks(Role.Shipment_Execution);
            c1.ShowLinks(Role.Connection_Execution);

        }
    }
}
