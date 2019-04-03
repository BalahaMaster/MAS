using System;
using System.Collections.Generic;
using System.Text;

namespace MiniProject2
{
    public class Connection : ObjectPlusPlus
    {
        public string Name { get; set; }
        public Address StartAddress{ get; set; }
        public Address EndAddress { get; set; }
        public double Distance { get; set; }
        //public List<ShipmentConnection> Executions { get; set; }

        public Connection() : base()
        {}

        public override string ToString() 
        {
            return Name;
        }
    }
}
