using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MiniProject2
{
    [Serializable]
    public class Shipment : ObjectPlusPlus
    {
        public string Name { get; set; }
        public Shipment(string name) : base()
        {
            Name = name;
        }

        public override string ToString()
        {
            return Name;       
        }
    }
}
