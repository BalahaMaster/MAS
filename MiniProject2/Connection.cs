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
       public Connection(string name, double distance) : base()
        {
            Name = name;
            Distance = distance;
        }
        public override string ToString() 
        {
            return Name;
        }
    }
}
