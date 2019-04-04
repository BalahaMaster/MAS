using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MiniProject2
{
    public class Connection : ObjectPlusPlus
    {
        public string Name { get; set; }
        public double Distance { get; set; }
        public Address StartAddress 
        { 
            get
            {
                return (Address) GetLinks(Role.ConnectionStartAddress).FirstOrDefault();
            }
            set
            {
                AddLink(GetAssociation(Role.ConnectionStartAddress), value);
            }
        }
        public Address EndAddress 
        { 
            get
            {
                return (Address) GetLinks(Role.ConnectionEndAddress).FirstOrDefault();
            }
            set
            {
                AddLink(GetAssociation(Role.ConnectionEndAddress), value);
            }
        }
        public List<Execution> Executions
        { 
            get
            {
                return (List<Execution>) GetLinks(Role.Connection_Execution).ToList().ConvertAll(x => (Execution) x);
            }
            private set
            { }
        }
        public Schedule Schedule
        {
            get
            {
                return (Schedule) GetLinks(Role.ConnectionShedule).FirstOrDefault();
            }
            private set
            { }
        }
        public Connection(string name, double distance) : base()
        {
            Executions = new List<Execution>();
            Name = name;
            Distance = distance;
        }

        public void CreateSchedule()
        {
            Schedule = Schedule.CreateSchedule(this);
        }

        public override string ToString() 
        {
            return Name;
        }


    }
}
