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
                return (List<Execution>)GetLinks(Role.Connection_Execution).ToList().ConvertAll(x => (Execution)x);
            }
            set
            {
                foreach(Execution e in GetLinks(Role.Shipment_Execution))
                {
                    RemoveLink(GetAssociation(Role.Connection_Execution), e);
                }
                foreach(Execution e in value)
                {
                    AddLink(GetAssociation(Role.Connection_Execution), e);
                }
            }
        }

        public Schedule Schedule
        {
            get
            {
                return (Schedule) GetLinks(Role.ConnectionShedule).FirstOrDefault();
            }
        }
        public Connection(string name, double distance) : base()
        {
            Executions = new List<Execution>();
            Name = name;
            Distance = distance;
        }

        public void CreateSchedule()
        {
            Schedule.CreateSchedule(this);
        }

        public override string ToString() 
        {
            return Name;
        }


    }
}
