using System;
using System.Collections.Generic;
using System.Text;

namespace MiniProject2
{
    [Serializable]
    class Shipment
    {
        public Address SenderAddress { get; set; }
        public Address PickupAddress { get; set; }
        public List<ShipmentConnection> Executions { get; set; }
        public Dictionary<string, Consignment> Consignments { get; set; }

        public void AddConsignment(Consignment newConsignment)
        {
            if (!Consignments.ContainsKey(newConsignment.Id))
            {
                Consignments.Add(newConsignment.Id, newConsignment);
                newConsignment.Shipment = this;
            }
        }
    }
}
