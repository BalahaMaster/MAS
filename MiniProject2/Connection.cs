using System;
using System.Collections.Generic;
using System.Text;

namespace MiniProject2
{
    public class Connection : ObjectPlusPlus
    {
        public string Name { get; set; }
        public double Distance { get; set; }

        public Connection(string name, double distance) : base()
        {
            Name = name;
            Distance = distance;
        }

        public override string ToString() 
        {
            return Name;
        }

        public void AddStartAddress(Address address)
        {
            AddConstrain(GetAssociation(Role.ConnectionStartAddress), address);
        }

        public void AddEndAddress(Address address)
        {
            AddConstrain(GetAssociation(Role.ConnectionEndAddress), address);
        }
    }
}
