
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
            Shipment sh2 = new Shipment("Shipment 2");

            Address add1 = new Address("Liliowa", "25A", "Warszawa", "Polska", "05-666"); 
            Address add2 = new Address("Tulipanowa", "2", "9", "Olsztyn", "Polska", "21-370");
            Address add3 = new Address("Kasztanowa", "13", "Płock", "Polska", "01-234");

            sh1.AddLink(ObjectPlusPlus.GetAssociation(Role.ShipmentPickupAddress), add2); // asocjacja binarna skierowana
            sh1.AddLink(ObjectPlusPlus.GetAssociation(Role.ShipmentSenderAddress), add1); 

            Connection c1 = new Connection("Warszawa-Płock", 120);
            c1.AddLink(c1.GetAssociation(Role.ConnectionStartAddress), add1);
            c1.AddLink(c1.GetAssociation(Role.ConnectionEndAddress), add3);
            Connection c2 = new Connection("Płock-Olsztyn", 220);
            c2.AddLink(c1.GetAssociation)
            c2.EndAddress = add2;
            Connection c3 = new Connection("Płock-Warszawa", 120);
            c3.StartAddress = add3;
            c3.EndAddress = add1;

            List<Execution> execs = new List<Execution>()
            {
                new Execution(new DateTime(), new DateTime()),
                new Execution(new DateTime(), new DateTime())
            }; 

            c1.Executions.Add(new Execution(new DateTime(), new DateTime()));
            c1.ShowLinks(Role.Connection_Execution);
            c1.Executions = execs;
            c1.ShowLinks(Role.Connection_Execution);

            c1.CreateSchedule();
            c1.Schedule.Etd_Eta.Add(new DateTime(), new DateTime());
            c1.Schedule.ShowLinks(Role.ScheduleConnection);
            c1.ShowLinks(Role.ConnectionShedule);
            c1.CreateSchedule();


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
