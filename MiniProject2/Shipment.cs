using System;
using System.Collections.Generic;
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

        public void AddPickupAddress(Address address)
        {
            AddConstrain(this.GetAssociation(Role.ShipmentPickupAddress), address);
        }

        public void AddSenderAddress(Address address)
        {
            AddConstrain(this.GetAssociation(Role.ShipmentSenderAddress), address);
        }
    }
}
