using System;
using System.Collections.Generic;
using System.Text;

namespace MiniProject2
{
    class Connection
    {
        public Address StartAddress{ get; set; }
        public Address EndAddress { get; set; }
        public double Distance { get; set; }
        public List<ShipmentConnection> Executions { get; set; }
    }
}
